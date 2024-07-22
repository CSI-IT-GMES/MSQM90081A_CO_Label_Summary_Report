using System;
using System.Data;
using System.Diagnostics;
using DevExpress.XtraEditors.Controls;
using JPlatform.Client.Controls6;

namespace CSI.GMES.QM
{
    public class Function
    {
        public static string GetValueCombo(LookUpEditEx cbo)
        {
            if (cbo.EditValue != null && cbo.EditValue.ToString() != "")
                return cbo == null ? "" : cbo.EditValue.ToString();
            return null;
        }

        public static void SetDataCombobox(LookUpEditEx combobox, DataTable data, string caption = "", string selectedValue = "")
        {
            try
            {
                var columnNameValue = data.Columns[0].ColumnName;
                var columnNameDisplay = data.Columns[1].ColumnName;
                combobox.Properties.Columns.Clear();
                combobox.Properties.DataSource = data;
                combobox.Properties.ValueMember = columnNameValue;
                combobox.Properties.DisplayMember = columnNameDisplay;
                combobox.Properties.Columns.Add(new LookUpColumnInfo(columnNameValue));
                combobox.Properties.Columns.Add(new LookUpColumnInfo(columnNameDisplay));
                if (caption == "Account Code" || caption == "Budget Ammount")
                    combobox.Properties.Columns[columnNameValue].Visible = true;
                else
                    combobox.Properties.Columns[columnNameValue].Visible = false;

                combobox.Properties.Columns[columnNameDisplay].Caption = caption == "" ? columnNameDisplay : caption;
                if (selectedValue == "_") return;
                if (selectedValue != "")
                    combobox.EditValue = selectedValue;
                else
                    combobox.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"SetDataCombobox: {ex.Message}");
            }
        }
    }
}
