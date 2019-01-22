using System;
using System.Linq;
using System.Text;

namespace Models
{
    ///<summary>
    ///DP门诊患者就诊信息
    ///</summary>
    public partial class DP_OUT_PATIENT
    {
           public DP_OUT_PATIENT(){


           }
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
           /// Desc:门诊病案号
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string CASE_NO {get;set;}

           /// <summary>
           /// Desc:本院就诊卡号;  社保卡号
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string CARD_NO {get;set;}

           /// <summary>
           /// Desc:患者姓名
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string PATIENT_NAME {get;set;}

           /// <summary>
           /// Desc:身份证号
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string ID_NO {get;set;}

           /// <summary>
           /// Desc:yyyy-mm-dd
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? BIRTH_DATE {get;set;}

           /// <summary>
           /// Desc:1:男;  2:女;  9:未知;  
           /// Default:
           /// Nullable:True
           /// </summary>           
           public int? GENDER_CODE {get;set;}

           /// <summary>
           /// Desc:国家名称
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string COUNTRY_NAME {get;set;}

           /// <summary>
           /// Desc:民族名称
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string NATION_NAME {get;set;}

           /// <summary>
           /// Desc:1:已婚;  2:未婚;  3:离婚;  4:丧偶;  9:其他;  
           /// Default:
           /// Nullable:True
           /// </summary>           
           public int? MARI_STAT_CODE {get;set;}

           /// <summary>
           /// Desc:收费类别代码（取自源系统）	   城镇职工、城镇居民、新型农村合作医疗、贫困救助、商业医疗保险、全公费、全自费 等的编码
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string CHARGE_TYPE_CODE {get;set;}

           /// <summary>
           /// Desc:收费类别名称（取自源系统）	   城镇职工、城镇居民、新型农村合作医疗、贫困救助、商业医疗保险、全公费、全自费 等
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string CHARGE_TYPE_NAME {get;set;}

           /// <summary>
           /// Desc:到院实际挂号时间。预约的也是到院取号时间 yyyy-mm-dd hh24:mi:ss
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? REG_DATE {get;set;}

           /// <summary>
           /// Desc:挂号科室代码
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string REG_DEPT_CODE {get;set;}

           /// <summary>
           /// Desc:挂号科室名称
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string REG_DEPT_NAME {get;set;}

           /// <summary>
           /// Desc:挂号级别代码
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string REG_LEVEL_CODE {get;set;}

           /// <summary>
           /// Desc:普通号、专家号、特需专家号
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string REG_LEVEL_NAME {get;set;}

           /// <summary>
           /// Desc:看诊序号
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string SEE_NO {get;set;}

           /// <summary>
           /// Desc:患者开始看诊时间（在科室内看病的时间） yyyy-mm-dd hh24:mi:ss
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? SEE_DATE {get;set;}

           /// <summary>
           /// Desc:医师代码
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string DOCTOR_CODE {get;set;}

           /// <summary>
           /// Desc:看诊医师
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string DOCTOR_NAME {get;set;}

           /// <summary>
           /// Desc:主诊断代码
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string DIAG_CODE {get;set;}

           /// <summary>
           /// Desc:主诊断名称
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string DIAG_NAME {get;set;}

           /// <summary>
           /// Desc:下诊断文书的时间 yyyy-mm-dd hh24:mi:ss
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? DIAG_DATE {get;set;}

           /// <summary>
           /// Desc:0 否  1 是
           /// Default:
           /// Nullable:True
           /// </summary>           
           public int? FIRST_VISIT_FLAG {get;set;}

           /// <summary>
           /// Desc:记录抽取时间，不需院方提供
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? UPD_DATE {get;set;}

    }
}
