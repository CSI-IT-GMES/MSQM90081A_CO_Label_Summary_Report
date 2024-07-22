using System.Data;
using JPlatform.Client.JBaseForm6;

namespace CSI.GMES.PD
{
    public class P_MSPD90199A_Q_STOCK : BaseProcClass
    {
        public P_MSPD90199A_Q_STOCK()
        {
            // Modify Code : Procedure Name
            _ProcName = "P_MSPD90199A_Q_STOCK";
            ParamAdd();
        }

        private void ParamAdd()
        {
            // Modify Code : Procedure Parameter
            _ParamInfo.Add(new ParamInfo("V_P_TYPE", "Varchar2", 0, "Input", typeof(string)));
            _ParamInfo.Add(new ParamInfo("V_P_PLANT_CD", "Varchar2", 0, "Input", typeof(string)));
            _ParamInfo.Add(new ParamInfo("V_P_WH_CD", "Varchar2", 0, "Input", typeof(string)));
            _ParamInfo.Add(new ParamInfo("V_P_PART_GROUP", "Varchar2", 0, "Input", typeof(string)));
            _ParamInfo.Add(new ParamInfo("V_P_PART", "Varchar2", 0, "Input", typeof(string)));
            _ParamInfo.Add(new ParamInfo("V_P_YMD", "Varchar2", 0, "Input", typeof(string)));
            _ParamInfo.Add(new ParamInfo("V_P_LOC_WH", "Varchar2", 0, "Input", typeof(string)));
            _ParamInfo.Add(new ParamInfo("V_P_USER", "Varchar2", 0, "Input", typeof(string)));
            _ParamInfo.Add(new ParamInfo("V_P_IP", "Varchar2", 0, "Input", typeof(string)));
        }

        public DataTable SetParamData(DataTable dataTable, string V_P_TYPE, string V_P_PLANT_CD, string V_P_WH_CD, string V_P_PART_GROUP, string V_P_PART, string V_P_YMD, string V_P_LOC_WH, string V_P_USER, string V_P_IP)
        {
            if (dataTable == null)
            {
                dataTable = new DataTable(_ProcName);
                foreach (ParamInfo pi in _ParamInfo) dataTable.Columns.Add(pi.ParamName, pi.TypeClass);
            }

            // Modify Code : Procedure Parameter
            object[] objData =
            {
                V_P_TYPE,
                V_P_PLANT_CD,
                V_P_WH_CD,
                V_P_PART_GROUP,
                V_P_PART,
                V_P_YMD,
                V_P_LOC_WH,
                V_P_USER,
                V_P_IP
            };
            dataTable.Rows.Add(objData);
            return dataTable;
        }
    }
}
