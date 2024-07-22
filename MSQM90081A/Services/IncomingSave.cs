using System.Data;
using JPlatform.Client.JBaseForm6;

namespace CSI.GMES.PD
{
    public class P_MSPD90199A_S_INCOMING : BaseProcClass
    {
        public P_MSPD90199A_S_INCOMING()
        {
            // Modify Code : Procedure Name
            _ProcName = "P_MSPD90199A_S_INCOMING";
            ParamAdd();
        }

        private void ParamAdd()
        {
            // Modify Code : Procedure Parameter
            _ParamInfo.Add(new ParamInfo("V_P_WORK_TYPE", "Varchar2", 0, "Input", typeof(string)));
            _ParamInfo.Add(new ParamInfo("V_P_PLANT_CD", "Varchar2", 0, "Input", typeof(string)));
            _ParamInfo.Add(new ParamInfo("V_P_WH_CD", "Varchar2", 0, "Input", typeof(string)));
            _ParamInfo.Add(new ParamInfo("V_P_IC_YMD", "Varchar2", 0, "Input", typeof(string)));
            _ParamInfo.Add(new ParamInfo("V_P_IC_NO", "Varchar2", 0, "Input", typeof(string)));
            _ParamInfo.Add(new ParamInfo("V_P_PART_GROUP", "Varchar2", 0, "Input", typeof(string)));
            _ParamInfo.Add(new ParamInfo("V_P_PART_CD", "Varchar2", 0, "Input", typeof(string)));
            _ParamInfo.Add(new ParamInfo("V_P_PRICE", "Varchar2", 0, "Input", typeof(string)));
            _ParamInfo.Add(new ParamInfo("V_P_CURRENCY", "Varchar2", 0, "Input", typeof(string)));
            _ParamInfo.Add(new ParamInfo("V_P_RQ_YMD", "Varchar2", 0, "Input", typeof(string)));
            _ParamInfo.Add(new ParamInfo("V_P_RQ_SEQ", "Varchar2", 0, "Input", typeof(string)));
            _ParamInfo.Add(new ParamInfo("V_P_RQ_NUMBER", "Varchar2", 0, "Input", typeof(string)));
            _ParamInfo.Add(new ParamInfo("V_P_REMARK", "Varchar2", 0, "Input", typeof(string)));
            _ParamInfo.Add(new ParamInfo("V_P_IN_QTY", "Varchar2", 0, "Input", typeof(string)));
            _ParamInfo.Add(new ParamInfo("V_P_IC_LOC", "Varchar2", 0, "Input", typeof(string)));
            _ParamInfo.Add(new ParamInfo("V_P_USER", "Varchar2", 0, "Input", typeof(string)));
            _ParamInfo.Add(new ParamInfo("V_P_IP", "Varchar2", 0, "Input", typeof(string)));
        }

        public DataTable SetParamData(DataTable dataTable, string V_P_TYPE, string V_P_PLANT_CD, string V_P_WH_CD, string V_P_IC_YMD, string V_P_IC_NO, string V_P_PART_GROUP, string V_P_PART_CD, string V_P_PRICE, string V_P_CURRENCY, string V_P_RQ_YMD, string V_P_RQ_SEQ, string V_P_RQ_NUMBER,
            string V_P_REMARK, string V_P_IN_QTY, string V_P_IC_LOC, string V_P_USER, string V_P_IP)
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
                V_P_IC_YMD,
                V_P_IC_NO,
                V_P_PART_GROUP,
                V_P_PART_CD,
                V_P_PRICE,
                V_P_CURRENCY,
                V_P_RQ_YMD,
                V_P_RQ_SEQ,
                V_P_RQ_NUMBER,
                V_P_REMARK,
                V_P_IN_QTY,
                V_P_IC_LOC,
                V_P_USER,
                V_P_IP
            };
            dataTable.Rows.Add(objData);
            return dataTable;
        }
    }

    public class P_MSPD90199A_S_QR : BaseProcClass
    {
        public P_MSPD90199A_S_QR()
        {
            // Modify Code : Procedure Name
            _ProcName = "P_MSPD90199A_S_QR";
            ParamAdd();
        }

        private void ParamAdd()
        {
            // Modify Code : Procedure Parameter
            _ParamInfo.Add(new ParamInfo("V_P_WORK_TYPE", "Varchar2", 0, "Input", typeof(string)));
            _ParamInfo.Add(new ParamInfo("V_P_BARCODE", "Varchar2", 0, "Input", typeof(string)));
            _ParamInfo.Add(new ParamInfo("V_P_SERIAL_NO", "Varchar2", 0, "Input", typeof(string)));
            _ParamInfo.Add(new ParamInfo("V_P_COMN_NM", "Varchar2", 0, "Input", typeof(string)));
            _ParamInfo.Add(new ParamInfo("V_P_USER", "Varchar2", 0, "Input", typeof(string)));
            _ParamInfo.Add(new ParamInfo("V_P_IP", "Varchar2", 0, "Input", typeof(string)));
        }

        public DataTable SetParamData(DataTable dataTable, string V_P_WORK_TYPE, string V_P_BARCODE, string V_P_SERIAL_NO, string V_P_COMN_NM, string V_P_USER, string V_P_IP)
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
                V_P_BARCODE,
                V_P_SERIAL_NO,
                V_P_COMN_NM,
                V_P_USER,
                V_P_IP
            };
            dataTable.Rows.Add(objData);
            return dataTable;
        }
    }

    public class P_MSPD90199A_S_INCOMING_E : BaseProcClass
    {
        public P_MSPD90199A_S_INCOMING_E()
        {
            // Modify Code : Procedure Name
            _ProcName = "P_MSPD90199A_S_INCOMING_E";
            ParamAdd();
        }

        private void ParamAdd()
        {
            // Modify Code : Procedure Parameter
            _ParamInfo.Add(new ParamInfo("V_P_WORK_TYPE", "Varchar2", 0, "Input", typeof(string)));
            _ParamInfo.Add(new ParamInfo("V_P_PLANT_CD", "Varchar2", 0, "Input", typeof(string)));
            _ParamInfo.Add(new ParamInfo("V_P_WH_CD", "Varchar2", 0, "Input", typeof(string)));
            _ParamInfo.Add(new ParamInfo("V_P_IC_YMD", "Varchar2", 0, "Input", typeof(string)));
            _ParamInfo.Add(new ParamInfo("V_P_IC_NO", "Varchar2", 0, "Input", typeof(string)));
            _ParamInfo.Add(new ParamInfo("V_P_PART_GROUP", "Varchar2", 0, "Input", typeof(string)));
            _ParamInfo.Add(new ParamInfo("V_P_PART_CD", "Varchar2", 0, "Input", typeof(string)));
            _ParamInfo.Add(new ParamInfo("V_P_PRICE", "Varchar2", 0, "Input", typeof(string)));
            _ParamInfo.Add(new ParamInfo("V_P_CURRENCY", "Varchar2", 0, "Input", typeof(string)));
            _ParamInfo.Add(new ParamInfo("V_P_RQ_YMD", "Varchar2", 0, "Input", typeof(string)));
            _ParamInfo.Add(new ParamInfo("V_P_RQ_SEQ", "Varchar2", 0, "Input", typeof(string)));
            _ParamInfo.Add(new ParamInfo("V_P_RQ_NUMBER", "Varchar2", 0, "Input", typeof(string)));
            _ParamInfo.Add(new ParamInfo("V_P_REMARK", "Varchar2", 0, "Input", typeof(string)));
            _ParamInfo.Add(new ParamInfo("V_P_IN_QTY", "Varchar2", 0, "Input", typeof(string)));
            _ParamInfo.Add(new ParamInfo("V_P_IC_LOC", "Varchar2", 0, "Input", typeof(string)));
            _ParamInfo.Add(new ParamInfo("V_P_USER", "Varchar2", 0, "Input", typeof(string)));
            _ParamInfo.Add(new ParamInfo("V_P_IP", "Varchar2", 0, "Input", typeof(string)));
            _ParamInfo.Add(new ParamInfo("V_P_BARCODE", "Varchar2", 0, "Input", typeof(string)));
            _ParamInfo.Add(new ParamInfo("V_P_SERIAL_NO", "Varchar2", 0, "Input", typeof(string)));
            _ParamInfo.Add(new ParamInfo("V_P_WARRANTY_TYPE", "Varchar2", 0, "Input", typeof(string)));
            _ParamInfo.Add(new ParamInfo("V_P_WARRANTY_DATE", "Varchar2", 0, "Input", typeof(string)));
            _ParamInfo.Add(new ParamInfo("V_P_REPAIR_DATE", "Varchar2", 0, "Input", typeof(string)));
            _ParamInfo.Add(new ParamInfo("V_P_REPAIR_DATE_1", "Varchar2", 0, "Input", typeof(string)));
            _ParamInfo.Add(new ParamInfo("V_P_REPAIR_DATE_2", "Varchar2", 0, "Input", typeof(string)));
            _ParamInfo.Add(new ParamInfo("V_P_REASON", "Varchar2", 0, "Input", typeof(string)));
            _ParamInfo.Add(new ParamInfo("V_P_REASON_1", "Varchar2", 0, "Input", typeof(string)));
            _ParamInfo.Add(new ParamInfo("V_P_REASON_2", "Varchar2", 0, "Input", typeof(string)));
            _ParamInfo.Add(new ParamInfo("V_P_ABROGATION_DATE", "Varchar2", 0, "Input", typeof(string)));
            _ParamInfo.Add(new ParamInfo("V_P_PREVIOUS_USER", "Varchar2", 0, "Input", typeof(string)));
        }

        public DataTable SetParamData(DataTable dataTable, string V_P_TYPE, string V_P_PLANT_CD, string V_P_WH_CD, string V_P_IC_YMD, string V_P_IC_NO, string V_P_PART_GROUP, string V_P_PART_CD, string V_P_PRICE, string V_P_CURRENCY, string V_P_RQ_YMD, string V_P_RQ_SEQ, string V_P_RQ_NUMBER,
            string V_P_REMARK, string V_P_IN_QTY, string V_P_IC_LOC, string V_P_USER, string V_P_IP,string V_P_BARCODE,  string V_P_SERIAL_NO, string V_P_WARRANTY_TYPE, string V_P_WARRANTY_DATE, string V_P_REPAIR_DATE, string V_P_REPAIR_DATE_1, string V_P_REPAIR_DATE_2,
            string V_P_REASON, string V_P_REASON_1, string V_P_REASON_2, string V_P_ABROGATION_DATE,string V_P_PREVIOUS_USER)
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
                V_P_IC_YMD,
                V_P_IC_NO,
                V_P_PART_GROUP,
                V_P_PART_CD,
                V_P_PRICE,
                V_P_CURRENCY,
                V_P_RQ_YMD,
                V_P_RQ_SEQ,
                V_P_RQ_NUMBER,
                V_P_REMARK,
                V_P_IN_QTY,
                V_P_IC_LOC,
                V_P_USER,
                V_P_IP,
                V_P_BARCODE,
                V_P_SERIAL_NO,
                V_P_WARRANTY_TYPE,
                V_P_WARRANTY_DATE,
                V_P_REPAIR_DATE,
                V_P_REPAIR_DATE_1,
                V_P_REPAIR_DATE_2,
                V_P_REASON,
                V_P_REASON_1,
                V_P_REASON_2,
                V_P_ABROGATION_DATE,
                V_P_PREVIOUS_USER
            };
            dataTable.Rows.Add(objData);
            return dataTable;
        }
    }

    public class P_MSPD90199A_S_INCOMING_GIRD : BaseProcClass
    {
        public P_MSPD90199A_S_INCOMING_GIRD()
        {
            // Modify Code : Procedure Name
            _ProcName = "P_MSPD90199A_S_INCOMING_GIRD";
            ParamAdd();
        }

        private void ParamAdd()
        {
            // Modify Code : Procedure Parameter
            _ParamInfo.Add(new ParamInfo("V_P_WORK_TYPE", "Varchar2", 0, "Input", typeof(string)));
            _ParamInfo.Add(new ParamInfo("V_P_PLANT_CD", "Varchar2", 0, "Input", typeof(string)));
            _ParamInfo.Add(new ParamInfo("V_P_WH_CD", "Varchar2", 0, "Input", typeof(string)));
            _ParamInfo.Add(new ParamInfo("V_P_IC_YMD", "Varchar2", 0, "Input", typeof(string)));
            _ParamInfo.Add(new ParamInfo("V_P_IC_NO", "Varchar2", 0, "Input", typeof(string)));
            _ParamInfo.Add(new ParamInfo("V_P_PART_GROUP", "Varchar2", 0, "Input", typeof(string)));
            _ParamInfo.Add(new ParamInfo("V_P_PART_CD", "Varchar2", 0, "Input", typeof(string)));
            _ParamInfo.Add(new ParamInfo("V_P_USER", "Varchar2", 0, "Input", typeof(string)));
            _ParamInfo.Add(new ParamInfo("V_P_IP", "Varchar2", 0, "Input", typeof(string)));
            _ParamInfo.Add(new ParamInfo("V_P_BARCODE", "Varchar2", 0, "Input", typeof(string)));
            _ParamInfo.Add(new ParamInfo("V_P_SERIAL_NO", "Varchar2", 0, "Input", typeof(string)));
            _ParamInfo.Add(new ParamInfo("V_P_PREVIOUS_USER", "Varchar2", 0, "Input", typeof(string)));
        }

        public DataTable SetParamData(DataTable dataTable, string V_P_TYPE, string V_P_PLANT_CD, string V_P_WH_CD, string V_P_IC_YMD,
            string V_P_IC_NO, string V_P_PART_GROUP, string V_P_PART_CD, string V_P_USER, string V_P_IP, string V_P_BARCODE, string V_P_SERIAL_NO, string V_P_PREVIOUS_USER)
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
                V_P_IC_YMD,
                V_P_IC_NO,
                V_P_PART_GROUP,
                V_P_PART_CD,
                V_P_USER,
                V_P_IP,
                V_P_BARCODE,
                V_P_SERIAL_NO,
                V_P_PREVIOUS_USER
            };
            dataTable.Rows.Add(objData);
            return dataTable;
        }
    }
}
