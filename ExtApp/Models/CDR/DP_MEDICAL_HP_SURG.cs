using System;
using System.Linq;
using System.Text;

namespace Models
{
    ///<summary>
    ///DP病案首页手术记录
    ///</summary>
    public partial class DP_MEDICAL_HP_SURG
    {
           public DP_MEDICAL_HP_SURG(){


           }
           /// <summary>
           /// Desc:主键，可以是业务数据主键或者GUID
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string HP_SURG_ID {get;set;}

           /// <summary>
           /// Desc:本次住院唯一标识（与病案首页进行关联）
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string PATIENT_NO {get;set;}

           /// <summary>
           /// Desc:手术操作编码
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string OP_CODE {get;set;}

           /// <summary>
           /// Desc:yyyy-mm-dd hh24:mi:ss
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? OP_DATE {get;set;}

           /// <summary>
           /// Desc:手术操作名称
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string OP_NAME {get;set;}

           /// <summary>
           /// Desc:手术部位名称
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string POSITION_NAME {get;set;}

           /// <summary>
           /// Desc:手术持续时间
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string CONTINUED_TIME {get;set;}

           /// <summary>
           /// Desc:主刀手术医师
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string OP_DOCTOR {get;set;}

           /// <summary>
           /// Desc:I助
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string ASSISTANT_I {get;set;}

           /// <summary>
           /// Desc:II助
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string ASSISTANT_II {get;set;}

           /// <summary>
           /// Desc:麻醉方式
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string ANESTHESIA_NAME {get;set;}

           /// <summary>
           /// Desc:麻醉分级
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string ANESTHESIA_GRADE {get;set;}

           /// <summary>
           /// Desc:切口愈合等级
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string WOUND_GRADE {get;set;}

           /// <summary>
           /// Desc:麻醉医师
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string ANESTHESIA_DOCTOR {get;set;}

           /// <summary>
           /// Desc:记录抽取时间，不需院方提供
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? UPD_DATE {get;set;}

    }
}
