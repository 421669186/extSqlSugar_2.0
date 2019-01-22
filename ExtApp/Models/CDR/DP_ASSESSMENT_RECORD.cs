using System;
using System.Linq;
using System.Text;

namespace Models
{
    ///<summary>
    ///DP评估记录
    ///</summary>
    public partial class DP_ASSESSMENT_RECORD
    {
           public DP_ASSESSMENT_RECORD(){


           }
           /// <summary>
           /// Desc:主键，可以是业务数据主键或者GUID
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string ASS_REC_ID {get;set;}

           /// <summary>
           /// Desc:本次住院唯一标识
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string PATIENT_NO {get;set;}

           /// <summary>
           /// Desc:患者唯一标识
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string PATIENT_ID {get;set;}

           /// <summary>
           /// Desc:病区代码
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string AREA_CODE {get;set;}

           /// <summary>
           /// Desc:护理单元
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string AREA_NAME {get;set;}

           /// <summary>
           /// Desc:科室代码
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string DEPT_CODE {get;set;}

           /// <summary>
           /// Desc:患者做评估时所在的科室名称
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string DEPT_NAME {get;set;}

           /// <summary>
           /// Desc:主要症状
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string SYMPTOM {get;set;}

           /// <summary>
           /// Desc:评估项目编码
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string ITEM_CODE {get;set;}

           /// <summary>
           /// Desc:评估项目名称
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string ITEM_NAME {get;set;}

           /// <summary>
           /// Desc:评估分值
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string SCORE {get;set;}

           /// <summary>
           /// Desc:评估结果
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string RESULT {get;set;}

           /// <summary>
           /// Desc:结果值类型
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string VALUE_TYPE {get;set;}

           /// <summary>
           /// Desc:医护人员进行评估的时间 yyyy-mm-dd hh24:mi:ss
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? ASS_DATE {get;set;}

           /// <summary>
           /// Desc:记录抽取时间，不需院方提供
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? UPD_DATE {get;set;}

    }
}
