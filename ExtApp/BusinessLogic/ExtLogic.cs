using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using CommonHelper;
using Models;
using ViewModel;
using SqlSugar;
using HJ.Common.Funcs;
using HJ.Common;
using HJSSD.EtlCommon;
using HJ.Common.Trans;
using ETL_EXAM.EtlExamDataItemLogic;
using System.Threading.Tasks;
using HJ.Common.Datas.Operate;

namespace ExtApp.BusinessLogic
{
    public partial class ExtLogic : DataBase, IImplement
    {

        /// <summary>
        /// TODO: 获取下拉框绑定的初始数据
        /// </summary>
        /// <returns></returns>
        public List<DataTable> InitDataLoad()
        {
            List<DataTable> lstDt = new List<DataTable>();
            DataTable dt = CreateDataTable("ITEM_CODE,ITEM_NAME");
            var dictCode = db.Ado.SqlQuery<COM_DICT_DETAIL>(@"SELECT ITEM_CODE,ITEM_NAME FROM dbo.COM_DICT_DETAIL WHERE CLASS_CODE='HOSPITAL_CODE'").ToList();
            foreach (var item in dictCode)
            {
                DataRow dr = dt.NewRow();
                dr["ITEM_CODE"] = item.ITEM_CODE.ToStringOrEmpty();
                dr["ITEM_NAME"] = item.ITEM_NAME.ToStringOrEmpty();
                dt.Rows.Add(dr);
            }
            lstDt.Add(dt);

            DataTable dt2 = CreateDataTable("ITEM_CODE,ITEM_NAME");
            var dictDiseaCode = db.Ado.SqlQuery<COM_DICT_DETAIL>(@"SELECT ITEM_CODE,ITEM_NAME FROM dbo.COM_DICT_DETAIL WHERE CLASS_CODE='DISEASE_CODE'").ToList();
            foreach (var item in dictDiseaCode)
            {
                DataRow dr = dt2.NewRow();
                dr["ITEM_CODE"] = item.ITEM_CODE.ToStringOrEmpty();
                dr["ITEM_NAME"] = item.ITEM_NAME.ToStringOrEmpty();
                dt2.Rows.Add(dr);
            }
            lstDt.Add(dt2);

            return lstDt;
        }

        public Tuple<bool, string> ExcelDataToDB(DataTable dt, string strHosCode, string strDiseaseCode)
        {
            try
            {
                bool blFlag = true;
                string strMsg = string.Empty;
                if (dt.Rows.Count > 0)
                {
                    string strTableName = "STA_SITEM_RESULT_TEMP_" + strHosCode;

                    //TODO:判断下拉框与导入EXCEL病种和医院编码是否一致
                    var row = (from r in dt.Rows.Cast<DataRow>() select r).FirstOrDefault();
                    string strExcelCode = row.Field<string>("HOSPITAL_CODE");
                    string strExcelDiseCode = row.Field<string>("DISEASE_CODE");
                    if (string.Equals(strExcelCode, strHosCode) && string.Equals(strDiseaseCode, strExcelDiseCode))
                    {

                        DataView dv = dt.DefaultView;
                        DataTable disDt = dv.ToTable(true, "SD_ITEM_CODE");
                        string strItemCode = string.Empty;
                        for (int i = 0; i < disDt.Rows.Count; i++)
                        {
                            strItemCode += "'" + disDt.Rows[i][0].ToString() + "',";
                        }
                        strItemCode = strItemCode.Substring(0, strItemCode.Length - 1);

                        string selSql = "SELECT 1 FROM DBO." + strTableName + " WHERE HOSPITAL_CODE='"+ strExcelCode + "' AND DISEASE_CODE='" + strDiseaseCode + "' AND SD_ITEM_CODE IN (" + strItemCode + ")";
                        int existFl = db.Ado.GetInt(selSql);
                        if (existFl > 0)
                        {
                            string delSql = "DELETE FROM DBO." + strTableName + " WHERE DISEASE_CODE='" + strDiseaseCode + "' AND SD_ITEM_CODE IN (" + strItemCode + ")";

                            int bl = db.Ado.ExecuteCommand(delSql);
                            if (bl <= 0)
                            {
                                blFlag = false;
                                strMsg = "执行失败!";
                            }
                            else
                            {
                                //TODO:执行插入操作
                                MSSQL mssql = new MSSQL(db.CurrentConnectionConfig.ConnectionString);
                                mssql.BatchExecuteCommand(strTableName, dt);
                            }
                        }
                        else
                        {
                            //TODO:执行插入操作
                            MSSQL mssql = new MSSQL(db.CurrentConnectionConfig.ConnectionString);
                            mssql.BatchExecuteCommand(strTableName, dt);
                        }

                    }
                    else
                    {
                        blFlag = false;
                        strMsg = "所选医院编码和疾病编码与导入EXCEL不一致!";
                    }
                }

                return new Tuple<bool, string>(blFlag, strMsg);
            }
            catch (Exception ex)
            {

                return new Tuple<bool, string>(false, ex.Message);
            }
        }
    }
}
