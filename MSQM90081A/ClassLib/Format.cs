using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using DevExpress.Utils;
using DevExpress.XtraGrid.Columns;
using JPlatform.Client.Controls6;

namespace CSI.GMES.QM
{
    public class Format
    {
        public static Dictionary<string, GridBandEx> Band = new Dictionary<string, GridBandEx>();

        public static void GridBand(GridControlEx arg_Grid, BandedGridViewEx arg_GridView, DataTable arg_DtBand, DataTable arg_BandDynamic = null)
        {
            arg_GridView.BeginUpdate();
            arg_GridView.Bands.Clear();
            arg_GridView.Columns.Clear();

            Band.Clear();
            var dtBand = arg_DtBand.Copy();
            var col = new ColumnBand();


            try
            {
                int.TryParse(dtBand.Rows[0][col.BAND_ROW_HEIGHT].ToString(), out var bandRowHeight);
                arg_GridView.BandPanelRowHeight = bandRowHeight;
                foreach (DataRow row in dtBand.Rows)
                    if (row[col.COL_DYNAMIC].ToString() != "" && arg_BandDynamic != null)
                    {
                        var bandCaptionColumn = row[col.CAP_DYNAMIC].ToString();
                        var bandNameColumn = row[col.COL_DYNAMIC].ToString();
                        var bandName = row[col.BAND_NAME].ToString();
                        var parentBand = row[col.PARENT_BAND].ToString();
                        var parentRow = arg_DtBand.Select($"{col.BAND_NAME} = '{parentBand}' ").FirstOrDefault();
                        var parentName = parentRow[col.BAND_NAME].ToString();
                        var isBandDynamic = false;
                        if (parentRow != null && parentRow[col.COL_DYNAMIC].ToString() != "")
                            isBandDynamic = true;

                        foreach (DataRow rowDynamic in arg_BandDynamic.Rows)
                        {
                            row[col.BAND_NAME] = bandName + rowDynamic[bandNameColumn];
                            row[col.CAPTION] = bandCaptionColumn == "" ? " " : rowDynamic[bandCaptionColumn];
                            if (parentBand != "" && isBandDynamic)
                            {
                                row[col.PARENT_BAND] = parentName + rowDynamic[bandNameColumn];
                                row[col.COL_NAME] = rowDynamic[parentBand];
                            }

                            CreateBand(arg_Grid, arg_GridView, row);
                        }
                    }
                    else
                    {
                        CreateBand(arg_Grid, arg_GridView, row);
                    }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(MethodBase.GetCurrentMethod().Name + ": " + ex.Message);
            }

            arg_GridView.EndUpdate();
        }

        private static void CreateBand(GridControlEx arg_Grid, BandedGridViewEx arg_GridView, DataRow arg_Row)
        {
            var col = new ColumnBand();
            var bandName = arg_Row[col.BAND_NAME].ToString();
            try
            {
                var parentBand = arg_Row[col.PARENT_BAND].ToString();
                var colName = arg_Row[col.COL_NAME].ToString();
                var fontName = arg_Row[col.FONT_NAME].ToString();
                var fontStyle = (FontStyle)Enum.Parse(typeof(FontStyle), arg_Row[col.FONT_STYLE].ToString());
                float.TryParse(arg_Row[col.FONT_SIZE].ToString(), out var fontSize);
                int.TryParse(arg_Row[col.BAND_ROW].ToString(), out var rowCount);

                if (arg_Row[col.CAPTION].ToString() == "___")
                {
                    Band[parentBand].Columns.Add(new BandedGridColumnEx { Name = colName, FieldName = colName, Visible = true, Caption = " " });
                    return;
                }

                var band = new GridBandEx
                {
                    Caption = arg_Row[col.CAPTION].ToString() == "" ? " " : arg_Row[col.CAPTION].ToString(),
                    Name = bandName,
                    Visible = bool.Parse(arg_Row[col.VISIBLE].ToString())
                };
                if (parentBand == "")
                    arg_GridView.Bands.Add(band);
                else
                    Band[parentBand].Children.Add(band);

                if (colName != "")
                    band.Columns.Add(new BandedGridColumnEx { Name = colName, FieldName = colName, Visible = true, Caption = " " });

                Band.Add(bandName, band);

                band.AppearanceHeader.Font = new Font(fontName, fontSize, fontStyle);
                band.Fixed = (FixedStyle)Enum.Parse(typeof(FixedStyle), arg_Row[col.FIX_COL].ToString());
                band.AppearanceHeader.TextOptions.HAlignment = (HorzAlignment)Enum.Parse(typeof(HorzAlignment), arg_Row[col.ALIGN].ToString());
                band.AppearanceHeader.TextOptions.WordWrap = (WordWrap)Enum.Parse(typeof(WordWrap), arg_Row[col.WORD_WRAP].ToString());

                if (arg_Row[col.BCOLOR].ToString() != "")
                    band.AppearanceHeader.BackColor = GetColor(arg_Row[col.BCOLOR]);
                if (arg_Row[col.FCOLOR].ToString() != "")
                    band.AppearanceHeader.ForeColor = GetColor(arg_Row[col.FCOLOR]);
                band.RowCount = rowCount;

                //using (var g = arg_Grid.CreateGraphics()) {
                //    band.MinWidth = (int)g.MeasureString(band.Caption, band.AppearanceHeader.Font).Width;
                //}
            }
            catch (Exception ex)
            {
                Debug.WriteLine(MethodBase.GetCurrentMethod().Name + $"({bandName}): " + ex.Message);
            }
        }

        public static void GridBandColumn(BandedGridViewEx arg_GridView, DataTable arg_DtColumn, DataTable arg_BandDynamic = null)
        {
            var col = new ColumnBand();
            arg_GridView.BeginUpdate();
            arg_GridView.OptionsView.AllowCellMerge = true;
            arg_GridView.OptionsView.ColumnAutoWidth = false;
            arg_GridView.OptionsCustomization.AllowFilter = false;
            arg_GridView.OptionsCustomization.AllowColumnMoving = false;
            arg_GridView.OptionsCustomization.AllowColumnResizing = false;

            for (var i = 0; i < arg_GridView.Columns.Count(); i++)
                try
                {
                    GridColumn gridColumn = arg_GridView.Columns[i];
                    var fieldName = gridColumn.FieldName;
                    if (arg_BandDynamic != null)
                    {
                        var colName = arg_BandDynamic.Columns[0].ColumnName;
                        var rowsDynamic = arg_BandDynamic.Select($"{colName} = '{fieldName}'");
                        if (rowsDynamic.Count() > 0)
                            fieldName = colName;
                    }

                    var rows = arg_DtColumn.Select($"COL_NAME = '{fieldName}'");
                    if (rows.Count() == 0)
                    {
                        gridColumn.Visible = false;
                        continue;
                    }

                    var row = rows[0];

                    gridColumn.Caption = row["COL_TEXT"].ToString();
                    //gridColumn.Visible = Convert.ToBoolean(row["SHOW_YN"]);
                    if (row["BCOLOR"].ToString() != "")
                        gridColumn.AppearanceCell.BackColor = GetColor(row["BCOLOR"]);
                    if (row["FCOLOR"].ToString() != "")
                        gridColumn.AppearanceCell.BackColor = GetColor(row["FCOLOR"]);

                    gridColumn.OptionsColumn.AllowEdit = Convert.ToBoolean(row["ALLOW_EDIT"]);
                    gridColumn.OptionsColumn.AllowMerge = (DefaultBoolean)Enum.Parse(typeof(DefaultBoolean), row["MERGE_YN"].ToString());
                    gridColumn.DisplayFormat.FormatType = (FormatType)Enum.Parse(typeof(FormatType), row["COL_TYPE"].ToString());
                    if (gridColumn.DisplayFormat.FormatType == FormatType.Numeric)
                        gridColumn.DisplayFormat.FormatString = "#,#0.#";

                    var fontStyle = (FontStyle)Enum.Parse(typeof(FontStyle), row[col.FONT_STYLE].ToString());
                    float.TryParse(row[col.FONT_SIZE].ToString(), out var fontSize);

                    gridColumn.AppearanceCell.Font = new Font(row[col.FONT_NAME].ToString(), fontSize, fontStyle);
                    ;
                    gridColumn.AppearanceCell.TextOptions.VAlignment = VertAlignment.Center;
                    gridColumn.AppearanceCell.TextOptions.HAlignment = (HorzAlignment)Enum.Parse(typeof(HorzAlignment), row["ALIGN"].ToString());

                    int.TryParse(row["WIDTH"].ToString(), out var width);
                    int.TryParse(row["MIN_WIDTH"].ToString(), out var minWidth);
                    gridColumn.MinWidth = minWidth == 0 ? gridColumn.MinWidth : minWidth;
                    if (width == 0)
                        gridColumn.BestFit();
                    else
                        gridColumn.Width = width;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(MethodBase.GetCurrentMethod().Name + ": " + ex.Message);
                }

            int.TryParse(arg_DtColumn.Rows[0]["ROW_HEIGHT"].ToString(), out var rowHeight);
            arg_GridView.RowHeight = rowHeight;
            arg_GridView.EndUpdate();
        }


        private static Color GetColor(object color)
        {
            int colorCode;
            try
            {
                colorCode = Convert.ToInt32(color.ToString(), 16);
            }
            catch
            {
                colorCode = 0x000000;
            }

            return Color.FromArgb(colorCode);
        }
    }

    internal class ColumnBand
    {
        public string GRID_NAME => "GRID_NAME";
        public string BAND_NAME => "BAND_NAME";
        public string PARENT_BAND => "PARENT_BAND";
        public string CAPTION => "CAPTION";
        public string COL_NAME => "COL_NAME";
        public string VISIBLE => "VISIBLE";
        public string ALIGN => "ALIGN";
        public string FIX_COL => "FIX_COL";
        public string ORD => "ORD";
        public string BCOLOR => "BCOLOR";
        public string FCOLOR => "FCOLOR";
        public string FONT_NAME => "FONT_NAME";
        public string FONT_SIZE => "FONT_SIZE";
        public string FONT_STYLE => "FONT_STYLE";
        public string BAND_ROW => "BAND_ROW";
        public string BAND_DYNAMIC => "BAND_DYNAMIC";
        public string COL_DYNAMIC => "COL_DYNAMIC";
        public string CAP_DYNAMIC => "CAP_DYNAMIC";
        public string Name => "GRID_NAME";
        public string BAND_ROW_HEIGHT => "BAND_ROW_HEIGHT";
        public string WORD_WRAP => "WORD_WRAP";
    }
}
