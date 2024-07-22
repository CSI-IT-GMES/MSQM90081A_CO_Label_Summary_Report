using JPlatform.Client.Controls6;
using JPlatform.Client.CSIGMESBaseform6;
using JPlatform.Client.Library6.interFace;
using System;
using System.Data;
using System.Drawing;

namespace CSI.GMES.PD {
    public partial class MSPD90199A_Request_Register : CSIGMESBaseform6 {
        public MSPD90199A_Request_Register() {
            InitializeComponent();
            cboAccCode.Closed += cbo_Closed;
            cboBudgetCode.Closed += cbo_Closed;
            cboPartCode.Closed += cbo_Closed;
            cboPartGroup.Closed += cbo_Closed;
            btnSave.Click += BtnSave_Click;
            gvwMain.CustomRowCellEdit += GvwMain_CustomRowCellEdit;
        }

        public string _plantCd, _whCd, _acccode, _budgetcode, _partGrp = "_", _partCd = "_", _icYmd = "_";
        public bool _historySearch = false;
        DataTable _dtRqType, _dtUnit;
        enum Combo {
            FACTORY,
            WH_CD,
            ACCOUNT_CD,
            ACCOUNT_TITLE,
            PART_GROUP,
            PART,
            RQ_TYPE,
            UNIT,
        }

        protected override void OnLoad(EventArgs e) {
            base.OnLoad(e);
            SetComboAccCode();
            SetComboAccTitle();
            SetComboPartGroup();
            SetComboPart();
            SetDataGrid();
            if (_partGrp != "_") {
                SetComboPart();
                SetDataGrid();
                SetPriceDefault();
            }

            this.grpRequest.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpRequest.Appearance.Options.UseFont = true;
            this.grpRequest.AppearanceCaption.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.grpRequest.AppearanceCaption.Options.UseFont = true;

            _dtRqType = SelectComboData(Combo.RQ_TYPE);
            _dtUnit = SelectComboData(Combo.UNIT);
        }

        public void SetBrowserMain(IBrowserMain JbrowserMain) {
            this._browserMain = JbrowserMain;
        }

        private void BtnSave_Click(object sender, EventArgs e) {
            SaveData();
        }



        private void SetComboAccCode() {
            DataTable dt = SelectComboData(Combo.ACCOUNT_CD);
            Function.SetDataCombobox(cboAccCode, dt, "Account Code", _acccode);
        }

        private void SetComboAccTitle() {
            DataTable dt = SelectComboData(Combo.ACCOUNT_TITLE);
            Function.SetDataCombobox(cboBudgetCode, dt, "Account Title", _budgetcode);
            //Font font = cboBudgetCode.Font;
            //int width = 0;
            //foreach (DataRow row in dt.Rows) {
            //    string name = row["NAME"].ToString();
            //    int calcWidth = (int)cboBudgetCode.CreateGraphics().MeasureString(name, font).Width;
            //    if (width < calcWidth) width = calcWidth;
            //}
            cboBudgetCode.Properties.PopupWidth = 500;
        }
        private void SetComboPartGroup() {
            DataTable dt = SelectComboData(Combo.PART_GROUP);
            Function.SetDataCombobox(cboPartGroup, dt, "Part Group", _partGrp);
        }
        private void SetComboPart() {
            DataTable dt = SelectComboData(Combo.PART);
            Function.SetDataCombobox(cboPartCode, dt, "Part Name", _partCd);

        }

        private void SetPriceDefault() {
            try {
                DataTable data = cboPartCode.Properties.DataSource as DataTable;
                int rowIndex = cboPartCode.ItemIndex;
                /// string currency = data.Rows[rowIndex]["CURRENCY"].ToString();
                // lbl_Price.Text = data.Rows[rowIndex]["PRICE"].ToString();
                // lblSafeInv.Text = data.Rows[rowIndex]["SAFETY_INV"].ToString();
                //if (currency != "") cboCurrency.EditValue = currency;

            } catch (Exception ex) {
                SetStatusMessage($"SetPriceDefault: {ex.Message}");
            }

        }

        private void btnClose_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void GvwMain_CustomRowCellEdit(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e) {
            if (e.Column.FieldName == "PO_YN") {
                RepositoryItemLookUpEditEx lookup = AddComboToGrid(_dtRqType);
                e.RepositoryItem = lookup;
                e.Column.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowForFocusedCell;// ShowAlways;}
            } else if (e.Column.FieldName == "UNIT") {
                RepositoryItemLookUpEditEx lookup = AddComboToGrid(_dtUnit);
                e.RepositoryItem = lookup;
                e.Column.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowForFocusedCell;// ShowAlways;}
            }
        }

        private RepositoryItemLookUpEditEx AddComboToGrid(DataTable dt, string caption = "Name") {
            RepositoryItemLookUpEditEx lookup = new RepositoryItemLookUpEditEx {
                DataSource = dt,
                DisplayMember = "NAME",
                ValueMember = "CODE",
                NullText = "",
            };

            DevExpress.XtraEditors.Controls.LookUpColumnInfo col2 = new DevExpress.XtraEditors.Controls.LookUpColumnInfo {
                FieldName = "NAME",
                Caption = caption,
            };
            lookup.Columns.Add(col2);
            return lookup;
        }

        private void gvwMain_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e) {
            if (e.Column.AbsoluteIndex <= 5) {
                e.Appearance.BackColor = Color.LightYellow;
                e.Appearance.ForeColor = Color.Black;

            }

            if (e.Column.FieldName == "STATUS") {
                if (e.CellValue.ToString().ToUpper().Contains("ORDER")) {
                    e.Appearance.BackColor = Color.Red;
                    e.Appearance.ForeColor = Color.White;
                } else if (e.CellValue.ToString().ToUpper().Contains("SAFETY")) {
                    e.Appearance.BackColor = Color.Yellow;
                    e.Appearance.ForeColor = Color.Black;
                } else {
                    e.Appearance.BackColor = Color.Green;
                    e.Appearance.ForeColor = Color.White;
                }
            }



        }

        private void SetDataGrid() {
            ResultSet rs = SelectData(_historySearch ? Var.RequestData.REQUEST_HIS : Var.RequestData.Q_REQUEST_POP);

            if (rs == null) return;
            DataTable dtData = rs.ResultDataSet.Tables[0];
            DataTable dtColumn = rs.ResultDataSet.Tables[1];
            DataTable dtBand = rs.ResultDataSet.Tables[2];
            SetData(grdMain, dtData);
            Format.GridBand(grdMain, gvwMain, dtBand);
            Format.GridBandColumn(gvwMain, dtColumn);
            // gvwMain.OptionsView.AllowCellMerge = false;
            //formatgridmain();
        }



        private void ResetDataAfterSave() {
            grdMain.DataSource = null;
            //lbl_Price.Text = "";
            _partCd = "_";
            _partGrp = "_";
        }

        private void cbo_Closed(object sender, DevExpress.XtraEditors.Controls.ClosedEventArgs e) {
            LookUpEditEx cbo = sender as LookUpEditEx;
            if (cbo == null) return;
            if (cbo.Name == cboPartGroup.Name) {
                SetComboPart();
            } else if (cbo.Name == cboPartCode.Name) {
                SetDataGrid();
                //SetPriceDefault();
            }
        }

        //private bool CheckRequired() {
        //    double.TryParse(txtPrice.Text, out double price);
        //    if (price == 0) {
        //        lbl_Price.Text = "Input Price";
        //        lbl_Price.Appearance.ForeColor = Color.Red;
        //        return false;
        //    }
        //    return true;
        //}

        private void SaveData() {

            string strYYYMMDD = "";
            string strReq_Qty = "";
            string strPrice = "";
            string strReq_Number = "";
            string strRemark = "";
            string strPO = "";


            string budgetcode = Function.GetValueCombo(cboBudgetCode);
            string partcode = Function.GetValueCombo(cboPartCode);
            string user = SessionInfo.UserID;
            string ip = GetIPAddress();

            DataTable dataSource = BindingData(grdMain, true);
            if (dataSource == null || dataSource.Rows.Count == 0) return;


            DataTable dtData = null;
            P_MSPD90199A_S_REQUEST dal2 = new P_MSPD90199A_S_REQUEST();



            foreach (DataRow row in dataSource.Rows) {
                //V_P_RQ_NO = row["RQ_NO"].ToString();
                strYYYMMDD = MSPD90199A.__GetDataCombo(MSPD90199A.Combo.YMD);
                strReq_Qty = row["RQ_QTY"].ToString();
                strPrice = row["PRICE"].ToString();
                strReq_Number = row["REQUEST_NUMBER"].ToString();
                strPO = row["PO_YN"].ToString();

                strRemark = row["REMARKS"].ToString();


                dtData = dal2.SetParamData(dtData,
                                        V_P_TYPE: "S_REQUEST",
                                        _plantCd,
                                        _whCd,
                                        strYYYMMDD,
                                        "1",
                                        budgetcode,
                                        partcode,
                                       strReq_Qty,
                                       strPrice.Replace(",", ""),
                                       strReq_Number,
                                       strRemark,
                                       strPO,
                                       user,
                                       ip

                      );
            }


            ResultSet rs = CommonCallQuery(dtData, dal2.ProcName, dal2.GetParamInfo(), false, 90000, "", true);

            if (rs == null) {
                MessageBoxW("Save Fail");
            } else if (rs.ReturnString.ToUpper() == "SAVE SUCCESS") {
                MessageBoxW("Save Success");
                ResetDataAfterSave();
            } else {
                MessageBoxW(rs.ErrorStr.ToUpper());
            }
        }


        private DataTable SelectComboData(Combo type) {
            string partgroup = "";
            string partcode = "";
            DataTable dtData = null;
            P_MSPD90199A_Q_COM dal2 = new P_MSPD90199A_Q_COM();

            if (cboPartGroup.EditValue.ToString() != "") {
                partgroup = Function.GetValueCombo(cboPartGroup);
            }
            if (cboPartCode.EditValue.ToString() != "") {
                partcode = Function.GetValueCombo(cboPartCode);
            }

            dtData = dal2.SetParamData(dtData,
                V_P_TYPE: type.ToString(),
                V_P_PLANT_CD: _plantCd,
                V_P_WH_CD: _whCd,
                V_P_PART_GROUP: partgroup,
                V_P_PART: partcode,
                V_P_USER: SessionInfo.UserID,
                V_P_IP: GetIPAddress()
            );
            ResultSet rs = CommonCallQuery(dtData, dal2.ProcName, dal2.GetParamInfo(), false, 90000, "", true);

            if (rs == null || rs.ResultDataSet == null || rs.ResultDataSet.Tables.Count == 0)
                return null;
            else
                return rs.ResultDataSet.Tables[0];
        }

        private ResultSet SelectData(Var.RequestData type) {
            DataTable dtData = null;

            string acccode = Function.GetValueCombo(cboAccCode);
            string budgetcode = Function.GetValueCombo(cboBudgetCode);
            string partgroup = Function.GetValueCombo(cboPartGroup);
            string partcode = Function.GetValueCombo(cboPartCode);

            if (acccode == "" || budgetcode == "" || partgroup == "" || partcode == "") {
                return null;
            }

            P_MSPD90199A_Q_REQUEST dal2 = new P_MSPD90199A_Q_REQUEST();


            dtData = dal2.SetParamData(dtData,
                V_P_TYPE: type.ToString(),
                V_P_YMD: DateTime.Now.ToString("yyyyMMdd"),
                V_P_PLANT_CD: _plantCd,
                V_P_WH_CD: _whCd,
                V_P_ACCOUNT_CD: acccode,
                V_P_BUDGET_CD: budgetcode,
                V_P_PART_GRP_CD: partgroup,
                V_P_PART_CODE: partcode,
                V_P_USER: SessionInfo.UserID,
                V_P_IP: GetIPAddress()
            );
            ResultSet rs = CommonCallQuery(dtData, dal2.ProcName, dal2.GetParamInfo(), false, 90000, "", true);

            if (rs == null || rs.ResultDataSet == null || rs.ResultDataSet.Tables.Count == 0)
                return null;
            else
                return rs;
        }

    }
}