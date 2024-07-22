using System.Data;
using JPlatform.Client.JBaseForm6;

namespace CSI.GMES.PD
{
    public class P_MSPD90199A_S_OUTGOING : BaseProcClass
    {
        public P_MSPD90199A_S_OUTGOING()
        {
            // Modify Code : Procedure Name
            _ProcName = "P_MSPD90199A_S_OUTGOING";
            ParamAdd();
        }

        private void ParamAdd()
        {
            // Modify Code : Procedure Parameter
            _ParamInfo.Add(new ParamInfo("V_P_WORK_TYPE", "Varchar2", 0, "Input", typeof(string)));
            _ParamInfo.Add(new ParamInfo("V_P_PLANT_CD", "Varchar2", 0, "Input", typeof(string)));
            _ParamInfo.Add(new ParamInfo("V_P_WH_CD", "Varchar2", 0, "Input", typeof(string)));
            _ParamInfo.Add(new ParamInfo("V_P_OG_YMD", "Varchar2", 0, "Input", typeof(string)));
            _ParamInfo.Add(new ParamInfo("V_P_OG_NO", "Varchar2", 0, "Input", typeof(string)));
            _ParamInfo.Add(new ParamInfo("V_P_PART_GROUP", "Varchar2", 0, "Input", typeof(string)));
            _ParamInfo.Add(new ParamInfo("V_P_PART_CD", "Varchar2", 0, "Input", typeof(string)));
            _ParamInfo.Add(new ParamInfo("V_P_PRICE", "Varchar2", 0, "Input", typeof(string)));
            _ParamInfo.Add(new ParamInfo("V_P_CURRENCY", "Varchar2", 0, "Input", typeof(string)));
            _ParamInfo.Add(new ParamInfo("V_P_RQ_YMD", "Varchar2", 0, "Input", typeof(string)));
            _ParamInfo.Add(new ParamInfo("V_P_RQ_SEQ", "Varchar2", 0, "Input", typeof(string)));
            _ParamInfo.Add(new ParamInfo("V_P_RQ_NUMBER", "Varchar2", 0, "Input", typeof(string)));
            _ParamInfo.Add(new ParamInfo("V_P_REMARK", "Varchar2", 0, "Input", typeof(string)));
            _ParamInfo.Add(new ParamInfo("V_P_IN_QTY", "Varchar2", 0, "Input", typeof(string)));
            _ParamInfo.Add(new ParamInfo("V_P_OG_LOC", "Varchar2", 0, "Input", typeof(string)));
            _ParamInfo.Add(new ParamInfo("V_P_USER", "Varchar2", 0, "Input", typeof(string)));
            _ParamInfo.Add(new ParamInfo("V_P_IP", "Varchar2", 0, "Input", typeof(string)));
        }

        public DataTable SetParamData(DataTable dataTable, string V_P_TYPE, string V_P_PLANT_CD, string V_P_WH_CD, string V_P_OG_YMD, string V_P_OG_NO, string V_P_PART_GROUP, string V_P_PART_CD, string V_P_PRICE, string V_P_CURRENCY, string V_P_RQ_YMD, string V_P_RQ_SEQ, string V_P_RQ_NUMBER,
            string V_P_REMARK, string V_P_OG_QTY, string V_P_OG_LOC, string V_P_USER, string V_P_IP)
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
                V_P_OG_YMD,
                V_P_OG_NO,
                V_P_PART_GROUP,
                V_P_PART_CD,
                V_P_PRICE,
                V_P_CURRENCY,
                V_P_RQ_YMD,
                V_P_RQ_SEQ,
                V_P_RQ_NUMBER,
                V_P_REMARK,
                V_P_OG_QTY,
                V_P_OG_LOC,
                V_P_USER,
                V_P_IP
            };
            dataTable.Rows.Add(objData);
            return dataTable;
        }
    }
    public class P_MSPD90199A_S_OUTGOING_E : BaseProcClass
    {
        public P_MSPD90199A_S_OUTGOING_E()
        {
            // Modify Code : Procedure Name
            _ProcName = "P_MSPD90199A_S_OUTGOING_E";
            ParamAdd();
        }

        private void ParamAdd()
        {
            // Modify Code : Procedure Parameter
            _ParamInfo.Add(new ParamInfo("V_P_WORK_TYPE", "Varchar2", 0, "Input", typeof(string)));
            _ParamInfo.Add(new ParamInfo("V_P_PLANT_CD", "Varchar2", 0, "Input", typeof(string)));
            _ParamInfo.Add(new ParamInfo("V_P_WH_CD", "Varchar2", 0, "Input", typeof(string)));
            _ParamInfo.Add(new ParamInfo("V_P_OG_YMD", "Varchar2", 0, "Input", typeof(string)));
            _ParamInfo.Add(new ParamInfo("V_P_OG_NO", "Varchar2", 0, "Input", typeof(string)));
            _ParamInfo.Add(new ParamInfo("V_P_PART_GROUP", "Varchar2", 0, "Input", typeof(string)));
            _ParamInfo.Add(new ParamInfo("V_P_PART_CD", "Varchar2", 0, "Input", typeof(string)));
            _ParamInfo.Add(new ParamInfo("V_P_PRICE", "Varchar2", 0, "Input", typeof(string)));
            _ParamInfo.Add(new ParamInfo("V_P_CURRENCY", "Varchar2", 0, "Input", typeof(string)));
            _ParamInfo.Add(new ParamInfo("V_P_RQ_YMD", "Varchar2", 0, "Input", typeof(string)));
            _ParamInfo.Add(new ParamInfo("V_P_RQ_SEQ", "Varchar2", 0, "Input", typeof(string)));
            _ParamInfo.Add(new ParamInfo("V_P_RQ_NUMBER", "Varchar2", 0, "Input", typeof(string)));
            _ParamInfo.Add(new ParamInfo("V_P_REMARK", "Varchar2", 0, "Input", typeof(string)));
            _ParamInfo.Add(new ParamInfo("V_P_IN_QTY", "Varchar2", 0, "Input", typeof(string)));
            _ParamInfo.Add(new ParamInfo("V_P_OG_LOC", "Varchar2", 0, "Input", typeof(string)));
            _ParamInfo.Add(new ParamInfo("V_P_USER", "Varchar2", 0, "Input", typeof(string)));
            _ParamInfo.Add(new ParamInfo("V_P_IP", "Varchar2", 0, "Input", typeof(string)));
            _ParamInfo.Add(new ParamInfo("V_P_BARCODE", "Varchar2", 0, "Input", typeof(string)));
            _ParamInfo.Add(new ParamInfo("V_P_SERIAL", "Varchar2", 0, "Input", typeof(string)));
        }

        public DataTable SetParamData(DataTable dataTable, string V_P_TYPE, string V_P_PLANT_CD, string V_P_WH_CD, string V_P_OG_YMD, string V_P_OG_NO, string V_P_PART_GROUP, string V_P_PART_CD, string V_P_PRICE, string V_P_CURRENCY, string V_P_RQ_YMD, string V_P_RQ_SEQ, string V_P_RQ_NUMBER,
            string V_P_REMARK, string V_P_OG_QTY, string V_P_OG_LOC, string V_P_USER, string V_P_IP, string V_P_BARCODE, string V_P_SERIAL)
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
                V_P_OG_YMD,
                V_P_OG_NO,
                V_P_PART_GROUP,
                V_P_PART_CD,
                V_P_PRICE,
                V_P_CURRENCY,
                V_P_RQ_YMD,
                V_P_RQ_SEQ,
                V_P_RQ_NUMBER,
                V_P_REMARK,
                V_P_OG_QTY,
                V_P_OG_LOC,
                V_P_USER,
                V_P_IP,
                V_P_BARCODE,
                V_P_SERIAL
            };
            dataTable.Rows.Add(objData);
            return dataTable;
        }
    }
}
