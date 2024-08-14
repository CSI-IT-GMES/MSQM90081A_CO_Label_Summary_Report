using DevExpress.Utils;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.BandedGrid;
using DevExpress.XtraGrid.Views.Grid;
using JPlatform.Client.Controls6;
using JPlatform.Client.CSIGMESBaseform6;
using JPlatform.Client.JBaseForm6;
using JPlatform.Client.Library6.interFace;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace CSI.GMES.QM {
    public partial class MSQM90081A : CSIGMESBaseform6
    {
        public bool _firstLoad = true;


        public MSQM90081A()
        {
            InitializeComponent();
        }

        #region Event Action Form

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            QueryButton = true;
            AddButton = false;
            SaveButton = false;
            DeleteButton = false;
            PreviewButton = false;
            PrintButton = false;
            NewButton = false;
            DeleteRowButton = false;

            _firstLoad = true;

            InitCombobox();

            txtStyleName.BackColor = Color.FromArgb(255, 228, 225);
            lbUnit.Font = new Font("Calibri", 12, FontStyle.Italic);
            lbUnit.ForeColor = Color.Blue;

            _firstLoad = false;
        }

        public override void AddClick()
        {

        }

        public override void PrintClick()
        {

        }

        public override void NewClick()
        {

        }

        public override void DeleteRowClick()
        {

        }

        public override void QueryClick()
        {
            base.QueryClick();
            SearchData();
        }

        public override void SaveClick()
        {

        }

        #endregion Event Action Form

        #region [Combobox]

        private void InitCombobox()
        {
            LoadDataCbo(cboFactory, "Factory", "Q_PLANT");
            LoadDataCbo(cboPoNo, "PO Number", "Q_PO");
            LoadDataCbo(cboPoItem, "PO Item", "Q_PO_ITEM");
        }

        private void LoadDataCbo(LookUpEditEx argCbo, string _cbo_nm, string _type, string _search = "")
        {
            try
            {
                DataTable dt = Get_Data_Combobox(_type, _search);

                if (dt == null || dt.Rows.Count < 1)
                {
                    argCbo.Properties.Columns.Clear();
                    argCbo.Properties.DataSource = null;

                    return;
                }

                string columnCode = dt.Columns[0].ColumnName;
                string columnName = dt.Columns[1].ColumnName;
                string captionCode = "Code";
                string captionName = _cbo_nm;

                argCbo.Properties.Columns.Clear();
                argCbo.Properties.DataSource = dt;
                argCbo.Properties.ValueMember = columnCode;
                argCbo.Properties.DisplayMember = columnName;
                argCbo.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo(columnCode));
                argCbo.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo(columnName));
                argCbo.Properties.Columns[columnCode].Visible = false;
                argCbo.Properties.Columns[columnCode].Width = 10;
                argCbo.Properties.Columns[columnCode].Caption = captionCode;
                argCbo.Properties.Columns[columnName].Caption = captionName;
                argCbo.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        public DataTable Get_Data_Combobox(string _type, string _search)
        {
            try
            {
                P_MSQM90081A_Q proc = new P_MSQM90081A_Q();
                DataTable dtData = null;

                string _factory = string.IsNullOrEmpty(cboFactory.EditValue.ToString()) ? "" : cboFactory.EditValue.ToString();
                string _po_no = string.IsNullOrEmpty(cboPoNo.EditValue.ToString()) ? "" : cboPoNo.EditValue.ToString();
                string _po_item = string.IsNullOrEmpty(cboPoItem.EditValue.ToString()) ? "" : cboPoItem.EditValue.ToString();

                if (_type.Equals("Q_PO"))
                {
                    dtData = proc.SetParamData(dtData, _type, _factory, _search, "");
                }
                else
                {
                    dtData = proc.SetParamData(dtData, _type, _factory, _po_no, _po_item);
                }

                ResultSet rs = CommonCallQuery(dtData, proc.ProcName, proc.GetParamInfo(), false, 90000, "", true);

                if (rs == null || rs.ResultDataSet == null || rs.ResultDataSet.Tables.Count == 0 || rs.ResultDataSet.Tables[0].Rows.Count == 0)
                {
                    return null;
                }
                return rs.ResultDataSet.Tables[0];
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return null;
            }
        }

        #endregion [Combobox]

        #region Data

        private void SearchData()
        {
            InitControls(grdBase);
            SearchGrid();
        }

        private void SearchGrid()
        {
            frmSplashScreenWait frmSplash = new frmSplashScreenWait();

            try
            {
                frmSplash.Show();
                DataTable _dtSource = GetData("Q",
                                            cboFactory.EditValue.ToString(),
                                            cboPoNo.EditValue.ToString(),
                                            cboPoItem.EditValue.ToString());

                if(_dtSource != null && _dtSource.Rows.Count > 0)
                {
                    var distinctValues = _dtSource.AsEnumerable()
                                        .Select(row => new
                                        {
                                            CS_SIZE = row.Field<string>("CS_SIZE"),
                                            ORD = row.Field<decimal>("ORD"),
                                        })
                                        .Distinct().OrderBy(r => r.ORD);
                    DataTable _dtHead = LINQResultToDataTable(distinctValues).Select("", "ORD").CopyToDataTable();

                    CreateSizeGrid(grdBase, gvwBase, _dtSource, _dtHead);
                    DataTable _dtf = Binding_Data(_dtSource);
                    SetData(grdBase, _dtf);
                    Formart_Grid_Summary(grdBase, gvwBase);
                }

                frmSplash.Close();
            }
            catch {
                frmSplash.Close();
            }
        }

        public void Formart_Grid_Summary(GridControlEx gridControl, BandedGridViewEx gridView)
        {
            try
            {
                gridControl.BeginUpdate();

                for (int i = 0; i < gridView.Columns.Count; i++)
                {
                    gridView.Columns[i].OptionsColumn.AllowEdit = false;
                    gridView.Columns[i].OptionsColumn.ReadOnly = true;
                    gridView.Columns[i].OptionsColumn.AllowSort = DefaultBoolean.False;

                    gridView.Columns[i].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                    gridView.Columns[i].AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
                    gridView.Columns[i].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                    gridView.Columns[i].AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
                    gridView.Columns[i].AppearanceCell.TextOptions.WordWrap = WordWrap.Wrap;
                    gridView.Columns[i].AppearanceCell.Font = new System.Drawing.Font("Calibri", 12, FontStyle.Regular);

                    if (gridView.Columns[i].AbsoluteIndex >= 5)
                    {
                        gridView.Columns[i].DisplayFormat.FormatType = FormatType.Numeric;
                        gridView.Columns[i].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
                        gridView.Columns[i].DisplayFormat.FormatString = "#,#0.#";
                    }

                    if (gridView.Columns[i].FieldName.ToString().Equals("DIV"))
                    {
                        gridView.Columns[i].Width = 170;
                        gridView.Columns[i].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
                    }

                    if (gridView.Columns[i].FieldName.ToString().Equals("MODEL_NAME"))
                    {
                        gridView.Columns[i].Width = 150;
                        gridView.Columns[i].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
                        gridView.Columns[i].ColumnEdit = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
                    }
                }

                gridView.RowHeight = 30;
                gridControl.EndUpdate();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public DataTable Binding_Data(DataTable dtSource)
        {
            try
            {
                DataTable _dtf = null;

                _dtf = GetDataTable(gvwBase);
                string _col_nm = "", _distinct_row = "";

                for (int iRow = 0; iRow < dtSource.Rows.Count; iRow++)
                {
                    if (!dtSource.Rows[iRow]["DISTINCT_ROW"].ToString().Equals(_distinct_row))
                    {
                        _dtf.Rows.Add();

                        _dtf.Rows[_dtf.Rows.Count - 1]["OBS_NU"] = dtSource.Rows[iRow]["OBS_NU"].ToString();
                        _dtf.Rows[_dtf.Rows.Count - 1]["OBS_SEQ_NU"] = dtSource.Rows[iRow]["OBS_SEQ_NU"].ToString();
                        _dtf.Rows[_dtf.Rows.Count - 1]["STYLE_CD"] = dtSource.Rows[iRow]["STYLE_CD"].ToString();
                        _dtf.Rows[_dtf.Rows.Count - 1]["MODEL_NAME"] = dtSource.Rows[iRow]["MODEL_NAME"].ToString();
                        _dtf.Rows[_dtf.Rows.Count - 1]["DIV"] = dtSource.Rows[iRow]["DIV"].ToString();

                        _distinct_row = dtSource.Rows[iRow]["DISTINCT_ROW"].ToString();
                    }

                    _col_nm = dtSource.Rows[iRow]["CS_SIZE"].ToString();
                    _dtf.Rows[_dtf.Rows.Count - 1][_col_nm] = dtSource.Rows[iRow]["QTY"].ToString();
                }

                return _dtf;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        public void CreateSizeGrid(GridControlEx gridControl, BandedGridViewEx gridView, DataTable dtSource, DataTable dtHead)
        {
            gridView.BeginDataUpdate();
            try
            {
                gridControl.DataSource = null;
                InitControls(gridControl);
                gridView.Columns.Clear();
                gridView.Bands.Clear();

                while (gridView.Columns.Count > 0)
                {
                    gridView.Columns.RemoveAt(0);
                }

                gridView.OptionsView.ShowColumnHeaders = false;

                GridBandEx gridBand = null;
                BandedGridColumnEx colBand = new BandedGridColumnEx();

                ////////// PO Column
                gridBand = new GridBandEx() { Caption = "PO No." };
                gridView.Bands.Add(gridBand);
                gridBand.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
                gridBand.AppearanceHeader.TextOptions.WordWrap = WordWrap.Wrap;
                gridBand.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
                gridBand.AppearanceHeader.Options.UseBackColor = true;
                gridBand.RowCount = 1;
                gridBand.Visible = true;

                colBand = new BandedGridColumnEx() { FieldName = "OBS_NU", Visible = true };
                colBand.Width = 100;
                gridBand.Columns.Add(colBand);

                ////////// PO Seq Column
                gridBand = new GridBandEx() { Caption = "PO Item" };
                gridView.Bands.Add(gridBand);
                gridBand.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
                gridBand.AppearanceHeader.TextOptions.WordWrap = WordWrap.Wrap;
                gridBand.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
                gridBand.AppearanceHeader.Options.UseBackColor = true;
                gridBand.RowCount = 1;
                gridBand.Visible = true;

                colBand = new BandedGridColumnEx() { FieldName = "OBS_SEQ_NU", Visible = true };
                colBand.Width = 100;
                gridBand.Columns.Add(colBand);

                ////////// Style Column
                gridBand = new GridBandEx() { Caption = "Style Code" };
                gridView.Bands.Add(gridBand);
                gridBand.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
                gridBand.AppearanceHeader.TextOptions.WordWrap = WordWrap.Wrap;
                gridBand.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
                gridBand.AppearanceHeader.Options.UseBackColor = true;
                gridBand.RowCount = 1;
                gridBand.Visible = true;

                colBand = new BandedGridColumnEx() { FieldName = "STYLE_CD", Visible = true };
                colBand.Width = 100;
                gridBand.Columns.Add(colBand);

                ////////// Model Column
                gridBand = new GridBandEx() { Caption = "Model Name" };
                gridView.Bands.Add(gridBand);
                gridBand.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
                gridBand.AppearanceHeader.TextOptions.WordWrap = WordWrap.Wrap;
                gridBand.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
                gridBand.AppearanceHeader.Options.UseBackColor = true;
                gridBand.RowCount = 1;
                gridBand.Visible = true;

                colBand = new BandedGridColumnEx() { FieldName = "MODEL_NAME", Visible = true };
                colBand.Width = 200;
                gridBand.Columns.Add(colBand);

                ////////// Model Column
                gridBand = new GridBandEx() { Caption = "Division" };
                gridView.Bands.Add(gridBand);
                gridBand.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
                gridBand.AppearanceHeader.TextOptions.WordWrap = WordWrap.Wrap;
                gridBand.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
                gridBand.AppearanceHeader.Options.UseBackColor = true;
                gridBand.RowCount = 1;
                gridBand.Visible = true;

                colBand = new BandedGridColumnEx() { FieldName = "DIV", Visible = true };
                colBand.Width = 100;
                gridBand.Columns.Add(colBand);

                if(dtHead != null && dtHead.Rows.Count > 0)
                {
                    for(int iRow = 0; iRow < dtHead.Rows.Count; iRow++)
                    {
                        gridBand = new GridBandEx() { Caption = dtHead.Rows[iRow]["CS_SIZE"].ToString() };
                        gridView.Bands.Add(gridBand);
                        gridBand.AppearanceHeader.TextOptions.WordWrap = WordWrap.Wrap;
                        gridBand.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
                        gridBand.AppearanceHeader.Options.UseBackColor = true;
                        gridBand.RowCount = 1;
                        gridBand.Visible = true;

                        colBand = new BandedGridColumnEx() { FieldName = dtHead.Rows[iRow]["CS_SIZE"].ToString(), Visible = true };
                        colBand.Width = 70;
                        gridBand.Columns.Add(colBand);
                    }
                }
            }
            catch
            {
                //throw EX;
            }
            gridView.EndDataUpdate();
            gridView.ExpandAllGroups();
        }

        #endregion

        #region Events 

        private void gvwBase_CellMerge(object sender, CellMergeEventArgs e)
        {
            try
            {
                if (grdBase.DataSource == null || gvwBase.RowCount < 1) return;

                e.Merge = false;
                e.Handled = true;

                if (e.Column.FieldName.ToString().Equals("OBS_NU"))
                {
                    string _value1 = gvwBase.GetRowCellValue(e.RowHandle1, e.Column.FieldName.ToString()).ToString();
                    string _value2 = gvwBase.GetRowCellValue(e.RowHandle2, e.Column.FieldName.ToString()).ToString();

                    if (_value1 == _value2 && !string.IsNullOrEmpty(_value1))
                    {
                        e.Merge = true;
                    }
                }

                if (e.Column.FieldName.ToString().Equals("OBS_SEQ_NU"))
                {
                    string _value1 = gvwBase.GetRowCellValue(e.RowHandle1, "OBS_NU").ToString();
                    string _value2 = gvwBase.GetRowCellValue(e.RowHandle2, "OBS_NU").ToString();
                    string _value3 = gvwBase.GetRowCellValue(e.RowHandle1, e.Column.FieldName.ToString()).ToString();
                    string _value4 = gvwBase.GetRowCellValue(e.RowHandle2, e.Column.FieldName.ToString()).ToString();

                    if (_value1 == _value2 && _value3 == _value4 && !string.IsNullOrEmpty(_value1) && !string.IsNullOrEmpty(_value3))
                    {
                        e.Merge = true;
                    }
                }

                if (e.Column.FieldName.ToString().Equals("STYLE_CD") || e.Column.FieldName.ToString().Equals("MODEL_NAME"))
                {
                    string _value1 = gvwBase.GetRowCellValue(e.RowHandle1, "OBS_NU").ToString();
                    string _value2 = gvwBase.GetRowCellValue(e.RowHandle2, "OBS_NU").ToString();
                    string _value3 = gvwBase.GetRowCellValue(e.RowHandle1, "OBS_SEQ_NU").ToString();
                    string _value4 = gvwBase.GetRowCellValue(e.RowHandle2, "OBS_SEQ_NU").ToString();
                    string _value5 = gvwBase.GetRowCellValue(e.RowHandle1, e.Column.FieldName.ToString()).ToString();
                    string _value6 = gvwBase.GetRowCellValue(e.RowHandle2, e.Column.FieldName.ToString()).ToString();

                    if (_value1 == _value2 && _value3 == _value4 && _value5 == _value6 && 
                        !string.IsNullOrEmpty(_value1) && !string.IsNullOrEmpty(_value3) && !string.IsNullOrEmpty(_value5))
                    {
                        e.Merge = true;
                    }
                }
            }
            catch { }
        }

        private void gvwBase_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            try
            {
                if (grdBase.DataSource == null || gvwBase.RowCount < 1) return;

                if (e.Column.FieldName.ToString().Equals("DIV"))
                {
                    e.Appearance.BackColor = Color.FromArgb(237, 237, 237);
                }

                if(e.Column.AbsoluteIndex >= 4)
                {
                    if(e.RowHandle == 2)
                    {
                        e.Appearance.BackColor = Color.FromArgb(215,237,213);
                    }

                    if (e.RowHandle == 0)
                    {
                        e.Appearance.BackColor = Color.FromArgb(255, 219, 201);
                    }

                    if (e.RowHandle == 1)
                    {
                        e.Appearance.BackColor = Color.FromArgb(206, 227, 242);
                    }
                }

                if (e.Column.FieldName.ToString().ToUpper().Equals("TOTAL"))
                {
                    e.Appearance.BackColor = Color.LightYellow;
                }
            }
            catch
            {

            }
        }

        private void txtStyleName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (txtStyleName.Text != null)
                {
                    LoadDataCbo(cboPoNo, "PO Number", "Q_PO", txtStyleName.Text.ToString().Trim());
                    LoadDataCbo(cboPoItem, "PO Item", "Q_PO_ITEM");
                }
                txtStyleName.Text = "";
            }
        }

        private void cboPoNo_Closed(object sender, DevExpress.XtraEditors.Controls.ClosedEventArgs e)
        {
            if (!_firstLoad)
            {
                LoadDataCbo(cboPoItem, "PO Item", "Q_PO_ITEM");
            }
        }

        #endregion

        #region Grid

        private DataTable GetData(string argType, string _factory = "", string _po_no = "", string _po_item = "")
        {
            try
            {
                P_MSQM90081A_Q proc = new P_MSQM90081A_Q();
                DataTable dtData = null;
                dtData = proc.SetParamData(dtData, argType, _factory, _po_no, _po_item);
                ResultSet rs = CommonCallQuery(dtData, proc.ProcName, proc.GetParamInfo(), false, 90000, "", true);
                if (rs == null || rs.ResultDataSet == null || rs.ResultDataSet.Tables.Count == 0 || rs.ResultDataSet.Tables[0].Rows.Count == 0)
                {
                    return null;
                }
                return rs.ResultDataSet.Tables[0];
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return null;
            }
        }

        #endregion

        #region Database

        public class P_MSQM90081A_Q : BaseProcClass
        {
            public P_MSQM90081A_Q()
            {
                // Modify Code : Procedure Name
                _ProcName = "LMES.P_MSQM90081A_Q";
                ParamAdd();
            }
            private void ParamAdd()
            {
                _ParamInfo.Add(new ParamInfo("@ARG_TYPE", "Varchar", 100, "Input", typeof(System.String)));
                _ParamInfo.Add(new ParamInfo("@ARG_PLANT", "Varchar", 100, "Input", typeof(System.String)));
                _ParamInfo.Add(new ParamInfo("@ARG_PO_NO", "Varchar", 100, "Input", typeof(System.String)));
                _ParamInfo.Add(new ParamInfo("@ARG_PO_ITEM", "Varchar", 100, "Input", typeof(System.String)));
            }
            public DataTable SetParamData(DataTable dataTable,
                                        System.String ARG_TYPE,
                                        System.String ARG_PLANT,
                                        System.String ARG_PO_NO,
                                        System.String ARG_PO_ITEM)
            {
                if (dataTable == null)
                {
                    dataTable = new DataTable(_ProcName);
                    foreach (ParamInfo pi in _ParamInfo)
                    {
                        dataTable.Columns.Add(pi.ParamName, pi.TypeClass);
                    }
                }
                // Modify Code : Procedure Parameter
                object[] objData = new object[] {
                                                ARG_TYPE,
                                                ARG_PLANT,
                                                ARG_PO_NO,
                                                ARG_PO_ITEM
                };
                dataTable.Rows.Add(objData);
                return dataTable;
            }
        }

        #endregion

        DataTable GetDataTable(GridView view)
        {
            DataTable dt = new DataTable();
            foreach (GridColumn c in view.Columns)
                dt.Columns.Add(c.FieldName, c.ColumnType);
            for (int r = 0; r < view.RowCount; r++)
            {
                object[] rowValues = new object[dt.Columns.Count];
                for (int c = 0; c < dt.Columns.Count; c++)
                    rowValues[c] = view.GetRowCellValue(r, dt.Columns[c].ColumnName);
                dt.Rows.Add(rowValues);
            }
            return dt;
        }

        private DataTable LINQResultToDataTable<T>(IEnumerable<T> Linqlist)
        {
            DataTable dt = new DataTable();
            PropertyInfo[] columns = null;
            if (Linqlist == null) return dt;
            foreach (T Record in Linqlist)
            {
                if (columns == null)
                {
                    columns = ((Type)Record.GetType()).GetProperties();
                    foreach (PropertyInfo GetProperty in columns)
                    {
                        Type colType = GetProperty.PropertyType;

                        if ((colType.IsGenericType) && (colType.GetGenericTypeDefinition()
                        == typeof(Nullable<>)))
                        {
                            colType = colType.GetGenericArguments()[0];
                        }

                        dt.Columns.Add(new DataColumn(GetProperty.Name, colType));
                    }
                }
                DataRow dr = dt.NewRow();
                foreach (PropertyInfo pinfo in columns)
                {
                    dr[pinfo.Name] = pinfo.GetValue(Record, null) == null ? DBNull.Value : pinfo.GetValue
                    (Record, null);
                }
                dt.Rows.Add(dr);
            }
            return dt;
        }
    }
}