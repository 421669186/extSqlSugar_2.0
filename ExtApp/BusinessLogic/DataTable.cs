﻿using Models;
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
