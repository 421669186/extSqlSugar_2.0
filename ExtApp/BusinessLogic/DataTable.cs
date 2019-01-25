using Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtApp.BusinessLogic
{
    public partial class ExtLogic : DataBase, IImplement
    {
        #region 多张表
        /// <summary>
        /// 多张表
        /// </summary>
        /// <returns></returns>
        public List<DataTable> GetDataTableList()
        {
            List<DataTable> lsTable = new List<DataTable>();

            return lsTable;
        } 
        #endregion
        #region 单张表
        /// <summary>
        /// 单张表
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTable()
        {
            DataTable dtd = new DataTable();
            //入口
            //dtd = ListToDataTable<CheckRecordViewModel>(GetCheckRecordFromOracle());
            return dtd;
        }
        #endregion


        #region 病种统计导入数据
        public Tuple<bool, string> InsertDataToDb(DataTable dt, string hospitalCode,string strDiseaseCode)
        {
            dt.Columns["医院编码"].ColumnName = "HOSPITAL_CODE";
            dt.Columns["病种编码"].ColumnName = "DISEASE_CODE";
            dt.Columns["数据项编码"].ColumnName = "SD_ITEM_CODE";
            dt.Columns["PN"].ColumnName = "PATIENT_NO";
            dt.Columns["值"].ColumnName = "ITEM_VALUE";
            dt.Columns["医学负责人"].ColumnName = "MEDICAL_NAME";
            dt.Columns["计算机负责人"].ColumnName = "COMPUTER_NAME";
            dt.Columns["备注"].ColumnName = "MEMO";
            dt.Columns["创建时间"].ColumnName = "CREATE_DATE";

            dt.Columns.Remove("数据项名称");

            Tuple<bool,string> blflag = ExcelDataToDB(dt,hospitalCode,strDiseaseCode);
            return blflag;
        }

        public List<DataTable> GetInitData()
        {
            List<DataTable> initDt = InitDataLoad();
            return initDt;
        }

        #endregion
    }
}
