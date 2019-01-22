using System;
using System.Linq;
using System.Text;

namespace Models
{
    ///<summary>
    ///DP诊断记录
    ///</summary>
    public partial class DP_DIAGNOSIS
    {
           public DP_DIAGNOSIS(){


           }
           /// <summary>
           /// Desc:主键，可以是业务数据主键或者GUID
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string DIAG_ID {get;set;}

           /// <summary>
           /// Desc:本次就诊唯一标识
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string PATIENT_NO {get;set;}

           /// <summary>
           /// Desc:I:住院;  E:急诊;  O:门诊;  9:其他;  
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string IN_FLAG {get;set;}

           /// <summary>
           /// Desc:患者唯一标识
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string PATIENT_ID {get;set;}

           /// <summary>
           /// Desc:1:门诊诊断;  2:入院诊断;  3:出院诊断;  
           /// Default:
           /// Nullable:True
           /// </summary>           
           public int? DIAG_TYPE_CODE {get;set;}

           /// <summary>
           /// Desc:诊断序号
           /// Default:
           /// Nullable:True
           /// </summary>           
           public int? DIAG_NO {get;set;}

           /// <summary>
           /// Desc:诊断编码
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string DIAG_CODE {get;set;}

           /// <summary>
           /// Desc:诊断名称
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string DIAG_NAME {get;set;}

           /// <summary>
           /// Desc:下诊断的时间 yyyy-mm-dd hh24:mi:ss
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? DIAG_DATE {get;set;}

           /// <summary>
           /// Desc:治疗结果
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string TREAT_RESULT {get;set;}

           /// <summary>
           /// Desc:记录抽取时间，不需院方提供
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? UPD_DATE {get;set;}

    }
}
