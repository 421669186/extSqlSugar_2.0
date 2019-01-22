using System;
using System.Linq;
using System.Text;

namespace Models
{
    ///<summary>
    ///DP门诊病历
    ///</summary>
    public partial class DP_OUT_EMR
    {
           public DP_OUT_EMR(){


           }
           /// <summary>
           /// Desc:主键，可以是业务数据主键或者GUID
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string EMR_REC_ID {get;set;}

           /// <summary>
           /// Desc:患者唯一标识
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string PATIENT_ID {get;set;}

           /// <summary>
           /// Desc:本次就诊唯一标识
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string PATIENT_NO {get;set;}

           /// <summary>
           /// Desc:患者姓名
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string PATIENT_NAME {get;set;}

           /// <summary>
           /// Desc:患者就诊时间（在科室内看病的时间） yyyy-mm-dd hh24:mi:ss
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? VISIT_DATE {get;set;}

           /// <summary>
           /// Desc:主诉
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string COMPLAINTS {get;set;}

           /// <summary>
           /// Desc:过敏史
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string CASE_ALLERGY {get;set;}

           /// <summary>
           /// Desc:现病史
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string CASE_NOW {get;set;}

           /// <summary>
           /// Desc:既往史
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string CASE_OLD {get;set;}

           /// <summary>
           /// Desc:0 否  	   1 是
           /// Default:
           /// Nullable:True
           /// </summary>           
           public int? FIRST_VISIT_FLAG {get;set;}

           /// <summary>
           /// Desc:体格检查
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string PHYSICAL {get;set;}

           /// <summary>
           /// Desc:辅助检查项目名称
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string CHECK_ITEM_NAME {get;set;}

           /// <summary>
           /// Desc:辅助检查结果
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string CHECK_RESULT {get;set;}

           /// <summary>
           /// Desc:多个诊断使用双引号封闭，逗号分隔，如：“D65”,“D66”
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string DIAGNOSIS_CODE {get;set;}

           /// <summary>
           /// Desc:多个诊断使用双引号封闭，逗号分隔，如：“肺炎”,“腹膜炎”
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string DIAGNOSIS_NAME {get;set;}

           /// <summary>
           /// Desc:门诊病历段落
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string CONTENT {get;set;}

           /// <summary>
           /// Desc:记录抽取时间，不需院方提供
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? UPD_DATE {get;set;}

    }
}
