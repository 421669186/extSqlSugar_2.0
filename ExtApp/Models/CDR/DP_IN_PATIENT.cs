using System;
using System.Linq;
using System.Text;

namespace Models
{
    ///<summary>
    ///DP住院患者就诊信息
    ///</summary>
    public partial class DP_IN_PATIENT
    {
           public DP_IN_PATIENT(){


           }
           /// <summary>
           /// Desc:本次住院唯一标识
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string PATIENT_NO {get;set;}

           /// <summary>
           /// Desc:患者唯一标识
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string PATIENT_ID {get;set;}

           /// <summary>
           /// Desc:在本院第几次住院
           /// Default:
           /// Nullable:True
           /// </summary>           
           public int? IN_TIMES {get;set;}

           /// <summary>
           /// Desc:住院病案号
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
           /// Desc:患者办理入院的时间 yyyy-mm-dd hh24:mi:ss
           /// Default:
           /// Nullable:False
           /// </summary>           
           public DateTime IN_DATE {get;set;}

           /// <summary>
           /// Desc:办理出院的时间（挂账时间） yyyy-mm-dd hh24:mi:ss
           /// Default:
           /// Nullable:False
           /// </summary>           
           public DateTime OUT_DATE {get;set;}

           /// <summary>
           /// Desc:患者住院处办理出院结算的时间 yyyy-mm-dd hh24:mi:ss
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? CLM_DATE {get;set;}

           /// <summary>
           /// Desc:入院科室代码
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string IN_DEPT_CODE {get;set;}

           /// <summary>
           /// Desc:办理入院后的接收科室
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string IN_DEPT_NAME {get;set;}

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
           /// Desc:出院科室代码
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string OUT_DEPT_CODE {get;set;}

           /// <summary>
           /// Desc:办理出院时的所在科室
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string OUT_DEPT_NAME {get;set;}

           /// <summary>
           /// Desc:护士接收患者时间（或分床时间） yyyy-mm-dd hh24:mi:ss
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? IN_DEPT_DATE {get;set;}

           /// <summary>
           /// Desc:医师（或护士）下达出院通知时间（转科时重点使用） yyyy-mm-dd hh24:mi:ss
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? OUT_DEPT_DATE {get;set;}

           /// <summary>
           /// Desc:主治医师代码
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string DOCTOR_CODE {get;set;}

           /// <summary>
           /// Desc:主治医师姓名
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string DOCTOR_NAME {get;set;}

           /// <summary>
           /// Desc:1:门诊;  2:急诊;  3:转科;  4:转院;  9:其他;  
           /// Default:
           /// Nullable:True
           /// </summary>           
           public int? IN_SOURCE_CODE {get;set;}

           /// <summary>
           /// Desc:1:病危;  2:急症;  3:一般;  9:其他;  
           /// Default:
           /// Nullable:True
           /// </summary>           
           public int? IN_STATUS_CODE {get;set;}

           /// <summary>
           /// Desc:1:医嘱离院;  2:医嘱转院;  3:医嘱转社区卫生服务机构/乡镇卫生院;  4:非医嘱离院;  5:死亡;  9:其他;  
           /// Default:
           /// Nullable:True
           /// </summary>           
           public int? OUT_WAY_CODE {get;set;}

           /// <summary>
           /// Desc:0:出院;  1:治愈;  2:好转;  3:未愈;  4:死亡;  5:转科;  9:其他;  
           /// Default:
           /// Nullable:True
           /// </summary>           
           public int? OUT_STATUS_CODE {get;set;}

           /// <summary>
           /// Desc:办理入院时录入的诊断代码
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string IN_DIAG_CODE {get;set;}

           /// <summary>
           /// Desc:办理入院时录入的诊断名称
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string IN_DIAG_NAME {get;set;}

           /// <summary>
           /// Desc:办理出院时录入的诊断代码
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string OUT_DIAG_CODE {get;set;}

           /// <summary>
           /// Desc:办理出院时录入的诊断名称
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string OUT_DIAG_NAME {get;set;}

           /// <summary>
           /// Desc:记录抽取时间，不需院方提供
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? UPD_DATE {get;set;}

    }
}
