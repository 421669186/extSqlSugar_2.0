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

namespace ExtApp.BusinessLogic
{
    public partial class ExtLogic : DataBase, IImplement
    {

        public DataTable GetData()
        {
            DataTable dt = CreateDataTable("PATIENT_NO,PATIENT_ID,EMR_TYPE_CODE,EMR_TYPE_NAME,REC_CONTENT,REC_DATE,cut,split,num");

            //var patientinfo = db.Queryable<DP_IN_PATIENT>().ToList();
            var emrRecords =
                db.Ado.SqlQuery<DP_EMR_RECORD>(
                        //@" SELECT b.* FROM dbo.DP_IN_PATIENT a,dbo.DP_EMR_RECORD b WHERE a.PATIENT_NO=b.PATIENT_NO AND a.OUT_DEPT_NAME LIKE '%脑%' AND (b.EMR_TYPE_NAME LIKE '%出院%' OR b.EMR_TYPE_NAME LIKE '%死亡%')"
                        @" SELECT TOP 100000 PATIENT_NO FROM dbo.DP_EMR_RECORD"
                        )
                    .ToList();
            //基本信息表OUT_DEPT_NAME含“脑”的患者， EMR中，EMR_TYPE_NAME含“出院|死亡”的，REC_CONTENT中找到“出院诊断：|死亡诊断：|最后诊断：|出院诊断:|死亡诊断:|最后诊断:”向后截取至“入院|手术|出院”（不含后置截取词的，向后截取之字段结尾），记为【出院诊断】；
            //【出院诊断】中，①有“数字，| 数字.| 数字、| 数字,”的，以“数字，| 数字.| 数字、| 数字,”做诊断截取，②不含“数字，| 数字.| 数字、| 数字,”的，直接输出字段内容。

            foreach (var emr in emrRecords)
            {
                //var content = emr.REC_CONTENT.ToStringOrEmpty();
                // var cut = content.CoreWord("出院诊断：|死亡诊断：|最后诊断：|出院诊断:|死亡诊断:|最后诊断:").after.keyWord("入院|手术|出院").toLast.endStr;

                //  var lsSplit = Regex.Split(cut, @"\d+[，\.、,]").ToList();
                DataRow dr = dt.NewRow();
                dr["PATIENT_NO"] = emr.PATIENT_NO.ToStringOrEmpty();
                dt.Rows.Add(dr);
                int i = 0;
                //  foreach (var str in lsSplit)
                //  {
                //   if (i==0)
                //   {
                //    i = i + 1;
                //    continue;
                //   }
                //DataRow dr = dt.NewRow();
                //dr["PATIENT_NO"] = emr.PATIENT_NO.ToStringOrEmpty();
                //dr["PATIENT_ID"] = emr.PATIENT_ID.ToStringOrEmpty();
                //dr["EMR_TYPE_CODE"] = emr.EMR_TYPE_CODE.ToStringOrEmpty();
                //dr["EMR_TYPE_NAME"] = emr.EMR_TYPE_NAME.ToStringOrEmpty();
                //dr["REC_CONTENT"] = emr.REC_CONTENT.ToStringOrEmpty();
                //dr["REC_DATE"] = emr.REC_DATE.ToDate();
                //dr["cut"] = cut;
                //dr["split"] = str;
                //dr["num"] = i;
                //dt.Rows.Add(dr);
                //   i = i + 1;
                //  }
            }
            return dt;
        }

        
    }
}
