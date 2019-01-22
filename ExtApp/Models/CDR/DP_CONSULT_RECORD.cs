using System;
using System.Linq;
using System.Text;

namespace Models
{
    ///<summary>
    ///DP会诊记录
    ///</summary>
    public partial class DP_CONSULT_RECORD
    {
           public DP_CONSULT_RECORD(){


           }
           /// <summary>
           /// Desc:主键，可以是业务数据主键或者GUID
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string CONSULT_ID {get;set;}

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
           /// Desc:对患者进行会诊的时间，yyyy-mm-dd hh24:mi:ss
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? CONSULT_DATE {get;set;}

           /// <summary>
           /// Desc:yyyy-mm-dd hh24:mi:ss
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? CONSULT_ARIV_DATE {get;set;}

           /// <summary>
           /// Desc:发起会诊申请的科室代码
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string APPLY_DEPT_CODE {get;set;}

           /// <summary>
           /// Desc:参与会诊的科室代码
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string CONSULT_DEPT_CODE {get;set;}

           /// <summary>
           /// Desc:会诊理由
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string REASON {get;set;}

           /// <summary>
           /// Desc:会诊治疗方案
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string SUGGESTION {get;set;}

           /// <summary>
           /// Desc:原始记录文本，整个会诊记录段落
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
