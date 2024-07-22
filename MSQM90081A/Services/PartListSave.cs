using System.Data;
using JPlatform.Client.JBaseForm6;

namespace CSI.GMES.PD
{
    public class P_MSKP10019A_S : BaseProcClass
    {
        public P_MSKP10019A_S()
        {
            // Modify Code : Procedure Name
            _ProcName = "P_MSKP10019A_S";
            ParamAdd();
        }

        private void ParamAdd()
        {
            // Modify Code : Procedure Parameter
            _ParamInfo.Add(new ParamInfo("V_P_WORK_TYPE", "Varchar2", 0, "Input", typeof(string)));
            _ParamInfo.Add(new ParamInfo("V_P_PLANT_CD", "Varchar2", 0, "Input", typeof(string)));
            _ParamInfo.Add(new ParamInfo("V_P_TYPE_NAME", "Varchar2", 0, "Input", typeof(string)));
            _ParamInfo.Add(new ParamInfo("V_P_DIV_NAME", "Varchar2", 0, "Input", typeof(string)));
            _ParamInfo.Add(new ParamInfo("V_P_KPI_NAME", "Varchar2", 0, "Input", typeof(string)));
            _ParamInfo.Add(new ParamInfo("V_P_KPI_NAME_SUB", "Varchar2", 0, "Input", typeof(string)));
            _ParamInfo.Add(new ParamInfo("V_P_TARGET_1", "Varchar2", 0, "Input", typeof(string)));
            _ParamInfo.Add(new ParamInfo("V_P_TARGET_2", "Varchar2", 0, "Input", typeof(string)));
            _ParamInfo.Add(new ParamInfo("V_P_TARGET_3", "Varchar2", 0, "Input", typeof(string)));
            _ParamInfo.Add(new ParamInfo("V_P_TARGET_4", "Varchar2", 0, "Input", typeof(string)));
            _ParamInfo.Add(new ParamInfo("V_P_TARGET_5", "Varchar2", 0, "Input", typeof(string)));
            _ParamInfo.Add(new ParamInfo("V_P_USER", "Varchar2", 0, "Input", typeof(string)));
            _ParamInfo.Add(new ParamInfo("V_P_IP", "Varchar2", 0, "Input", typeof(string)));
        }

        public DataTable SetParamData(DataTable dataTable, string V_P_WORK_TYPE, string V_P_PLANT_CD, string V_P_TYPE_NAME, string V_P_DIV_NAME, string V_P_KPI_NAME, string V_P_KPI_NAME_SUB, string V_P_TARGET_1, string V_P_TARGET_2, string V_P_TARGET_3, string V_P_TARGET_4, string V_P_TARGET_5,
            string V_P_USER, string V_P_IP)
        {
            if (dataTable == null)
            {
                dataTable = new DataTable(_ProcName);
                foreach (ParamInfo pi in _ParamInfo) dataTable.Columns.Add(pi.ParamName, pi.TypeClass);
            }

            // Modify Code : Procedure Parameter
            object[] objData =
            {
                V_P_WORK_TYPE,
                V_P_PLANT_CD,
                V_P_TYPE_NAME,
                V_P_DIV_NAME,
                V_P_KPI_NAME,
                V_P_KPI_NAME_SUB,
                V_P_TARGET_1,
                V_P_TARGET_2,
                V_P_TARGET_3,
                V_P_TARGET_4,
                V_P_TARGET_5,
                V_P_USER,
                V_P_IP
            };
            dataTable.Rows.Add(objData);
            return dataTable;
        }
    }
}
