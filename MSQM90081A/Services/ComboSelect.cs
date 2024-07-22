using System.Data;
using JPlatform.Client.JBaseForm6;

namespace CSI.GMES.PD
{
    public class P_MSKP10019A_Q_COMBO : BaseProcClass
    {
        public P_MSKP10019A_Q_COMBO()
        {
            // Modify Code : Procedure Name
            _ProcName = "P_MSPD90198A_Q_COMBO";
            ParamAdd();
        }

        private void ParamAdd()
        {
            // Modify Code : Procedure Parameter
            _ParamInfo.Add(new ParamInfo("V_P_TYPE", "Varchar2", 0, "Input", typeof(string)));
            _ParamInfo.Add(new ParamInfo("V_P_PLANT_CD", "Varchar2", 0, "Input", typeof(string)));
            _ParamInfo.Add(new ParamInfo("V_P_WH_CD", "Varchar2", 0, "Input", typeof(string)));
        }

        public DataTable SetParamData(DataTable dataTable, string V_P_TYPE, string V_P_PLANT_CD, string V_P_WH_CD)
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
                V_P_WH_CD
            };
            dataTable.Rows.Add(objData);
            return dataTable;
        }
    }

    public class P_MSPD90199A_Q_COM : BaseProcClass
    {
        public P_MSPD90199A_Q_COM()
        {
            // Modify Code : Procedure Name
            _ProcName = "P_MSPD90199A_Q_COM_V1";
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
            _ParamInfo.Add(new ParamInfo("V_P_USER", "Varchar2", 0, "Input", typeof(string)));
            _ParamInfo.Add(new ParamInfo("V_P_IP", "Varchar2", 0, "Input", typeof(string)));
            _ParamInfo.Add(new ParamInfo("V_P_DIV", "Varchar2", 0, "Input", typeof(string)));
        }

        public DataTable SetParamData(DataTable dataTable, string V_P_TYPE, string V_P_PLANT_CD, string V_P_WH_CD, string V_P_PART_GROUP, string V_P_PART, string V_P_USER, string V_P_IP,string V_P_DIV)
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
                V_P_USER,
                V_P_IP,
                V_P_DIV
            };
            dataTable.Rows.Add(objData);
            return dataTable;
        }
    }

    public class P_MSPD90199A_Q_COM_REQUEST : BaseProcClass
    {
        public P_MSPD90199A_Q_COM_REQUEST()
        {
            // Modify Code : Procedure Name
            _ProcName = "P_MSPD90199A_POP_COM";
            ParamAdd();
        }

        private void ParamAdd()
        {
            // Modify Code : Procedure Parameter
            _ParamInfo.Add(new ParamInfo("V_P_TYPE", "Varchar2", 0, "Input", typeof(string)));
            _ParamInfo.Add(new ParamInfo("V_P_PLANT_CD", "Varchar2", 0, "Input", typeof(string)));
            _ParamInfo.Add(new ParamInfo("V_P_WH_CD", "Varchar2", 0, "Input", typeof(string)));
            _ParamInfo.Add(new ParamInfo("V_P_ACCOUNT_CD", "Varchar2", 0, "Input", typeof(string)));
            _ParamInfo.Add(new ParamInfo("V_P_BUDGET_CD", "Varchar2", 0, "Input", typeof(string)));
            _ParamInfo.Add(new ParamInfo("V_P_PART_GROUP", "Varchar2", 0, "Input", typeof(string)));
            _ParamInfo.Add(new ParamInfo("V_P_PART", "Varchar2", 0, "Input", typeof(string)));
            _ParamInfo.Add(new ParamInfo("V_P_USER", "Varchar2", 0, "Input", typeof(string)));
            _ParamInfo.Add(new ParamInfo("V_P_IP", "Varchar2", 0, "Input", typeof(string)));
        }

        public DataTable SetParamData(DataTable dataTable, string V_P_TYPE, string V_P_PLANT_CD, string V_P_WH_CD, string V_P_ACCOUNT_CD, string V_P_BUDGET_CD, string V_P_PART_GROUP, string V_P_PART, string V_P_USER, string V_P_IP)
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
                V_P_ACCOUNT_CD,
                V_P_BUDGET_CD,
                V_P_PART_GROUP,
                V_P_PART,
                V_P_USER,
                V_P_IP
            };
            dataTable.Rows.Add(objData);
            return dataTable;
        }
    }
}
