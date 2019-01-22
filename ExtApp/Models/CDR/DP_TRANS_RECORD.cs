using System;
using System.Linq;
using System.Text;

namespace Models
{
    ///<summary>
    ///DP转科记录
    ///</summary>
    public partial class DP_TRANS_RECORD
    {
           public DP_TRANS_RECORD(){


           }
           /// <summary>
           /// Desc:主键，可以是业务数据主键或者GUID
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string TRANS_REC_ID {get;set;}

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
           /// Desc:转出科室编码
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string OUT_DEPT_CODE {get;set;}

           /// <summary>
           /// Desc:患者从哪个科室转出去的
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string OUT_DEPT_NAME {get;set;}

           /// <summary>
           /// Desc:转入科室编码
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string IN_DEPT_CODE {get;set;}

           /// <summary>
           /// Desc:将患者转入到哪个科室
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string IN_DEPT_NAME {get;set;}

           /// <summary>
           /// Desc:yyyy-mm-dd hh24:mi:ss
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? TRANS_IN_DATE {get;set;}

           /// <summary>
           /// Desc:yyyy-mm-dd hh24:mi:ss
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? TRANS_OUT_DATE {get;set;}

           /// <summary>
           /// Desc:理由及目的
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string REASON {get;set;}

           /// <summary>
           /// Desc:记录抽取时间，不需院方提供
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? UPD_DATE {get;set;}

    }
}
