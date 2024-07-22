using System.Data;
using JPlatform.Client.JBaseForm6;

namespace CSI.GMES.PD
{
    public class P_MSPD90199A_S_REQUEST : BaseProcClass
    {
        public P_MSPD90199A_S_REQUEST()
        {
            // Modify Code : Procedure Name
            _ProcName = "P_MSPD90199A_S_REQUEST_V03";
            ParamAdd();
        }

        private void ParamAdd()
        {
            // Modify Code : Procedure Parameter

            _ParamInfo.Add(new ParamInfo("V_P_WORK_TYPE", "Varchar2", 0, "Input", typeof(string)));
            _ParamInfo.Add(new ParamInfo("V_P_PLANT_CD", "Varchar2", 0, "Input", typeof(string)));
            _ParamInfo.Add(new ParamInfo("V_P_WH_CD", "Varchar2", 0, "Input", typeof(string)));
            _ParamInfo.Add(new ParamInfo("V_P_RQ_YMD", "Varchar2", 0, "Input", typeof(string)));
            _ParamInfo.Add(new ParamInfo("V_P_RQ_NO", "Varchar2", 0, "Input", typeof(string)));
            _ParamInfo.Add(new ParamInfo("V_P_BUDGET_CD", "Varchar2", 0, "Input", typeof(string)));
            _ParamInfo.Add(new ParamInfo("V_P_PART_CD", "Varchar2", 0, "Input", typeof(string)));
            _ParamInfo.Add(new ParamInfo("V_P_REQ_QTY", "Varchar2", 0, "Input", typeof(string)));
            _ParamInfo.Add(new ParamInfo("V_P_PRICE", "Varchar2", 0, "Input", typeof(string)));
            _ParamInfo.Add(new ParamInfo("V_P_RQ_NUMBER", "Varchar2", 0, "Input", typeof(string)));
            _ParamInfo.Add(new ParamInfo("V_P_REMARK", "Varchar2", 0, "Input", typeof(string)));
            _ParamInfo.Add(new ParamInfo("V_P_PO", "Varchar2", 0, "Input", typeof(string)));
            _ParamInfo.Add(new ParamInfo("V_P_BUDGET_YM", "Varchar2", 0, "Input", typeof(string)));
            _ParamInfo.Add(new ParamInfo("V_P_BUDGET_AMT", "Varchar2", 0, "Input", typeof(string)));
            _ParamInfo.Add(new ParamInfo("V_P_DEPT", "Varchar2", 0, "Input", typeof(string)));
            _ParamInfo.Add(new ParamInfo("V_P_DEPT_NM", "Varchar2", 0, "Input", typeof(string)));
            _ParamInfo.Add(new ParamInfo("V_P_USER", "Varchar2", 0, "Input", typeof(string)));
            _ParamInfo.Add(new ParamInfo("V_P_IP", "Varchar2", 0, "Input", typeof(string)));
        }

        public DataTable SetParamData(DataTable dataTable, string V_P_TYPE, string V_P_PLANT_CD, string V_P_WH_CD, string V_P_RQ_YMD, string V_P_RQ_NO, string V_P_BUDGET_CD, string V_P_PART_CD, string V_P_REQ_QTY, string V_P_PRICE, string V_P_RQ_NUMBER, string V_P_REMARK, string V_P_PO,
            string V_P_BUDGET_YM, string V_P_BUDGET_AMT,string V_P_DEPT,string V_P_DEPT_NM, string V_P_USER, string V_P_IP)
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
                V_P_RQ_YMD,
                V_P_RQ_NO,
                V_P_BUDGET_CD,
                V_P_PART_CD,
                V_P_REQ_QTY,
                V_P_PRICE,
                V_P_RQ_NUMBER,
                V_P_REMARK,
                V_P_PO,
                V_P_BUDGET_YM,
                V_P_BUDGET_AMT,
                V_P_DEPT,
                V_P_DEPT_NM,
                V_P_USER,
                V_P_IP
            };
            dataTable.Rows.Add(objData);
            return dataTable;
        }
    }
}
