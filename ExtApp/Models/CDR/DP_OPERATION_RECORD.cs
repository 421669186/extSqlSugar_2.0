using System;
using System.Linq;
using System.Text;

namespace Models
{
    ///<summary>
    ///DP手术记录
    ///</summary>
    public partial class DP_OPERATION_RECORD
    {
           public DP_OPERATION_RECORD(){


           }
           /// <summary>
           /// Desc:主键，可以是业务数据主键或者GUID
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string OP_REC_ID {get;set;}

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
           /// Desc:门急诊时冗余PATIENT_NO字段
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string CLINIC_CODE {get;set;}

           /// <summary>
           /// Desc:患者唯一标识
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string PATIENT_ID {get;set;}

           /// <summary>
           /// Desc:对应医嘱“申请单号”
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string APPLY_NO {get;set;}

           /// <summary>
           /// Desc:术前诊断
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string PREOPERATIVE_DIAG {get;set;}

           /// <summary>
           /// Desc:术后诊断
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string POSTOPERATIVE_DIAG {get;set;}

           /// <summary>
           /// Desc:0:择期;  1:急诊;  
           /// Default:
           /// Nullable:True
           /// </summary>           
           public int? EMERGENCY_INDICATOR {get;set;}

           /// <summary>
           /// Desc:yyyy-mm-dd hh24:mi:ss
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? START_DATE {get;set;}

           /// <summary>
           /// Desc:yyyy-mm-dd hh24:mi:ss
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? END_DATE {get;set;}

           /// <summary>
           /// Desc:麻醉专业医疗质量指标用 yyyy-mm-dd hh24:mi:ss
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? IN_DATE {get;set;}

           /// <summary>
           /// Desc:yyyy-mm-dd hh24:mi:ss
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? OUT_DATE {get;set;}

           /// <summary>
           /// Desc:手术类型
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string OPERATION_TYPE {get;set;}

           /// <summary>
           /// Desc:如：支架类型，钉子
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string EQUIPMENT_TYPE {get;set;}

           /// <summary>
           /// Desc:材料数量
           /// Default:
           /// Nullable:True
           /// </summary>           
           public int? EQUIPMENT_COUNT {get;set;}

           /// <summary>
           /// Desc:手术及操作编码
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string OPERATION_CODE {get;set;}

           /// <summary>
           /// Desc:手术名称
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string OPERATION_NAME {get;set;}

           /// <summary>
           /// Desc:指手术规模，取值：特、大、中、小
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string OPERATION_GRADE {get;set;}

           /// <summary>
           /// Desc:切口等级
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string WOUND_GRADE {get;set;}

           /// <summary>
           /// Desc:手术部位名称
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string POSITION_NAME {get;set;}

           /// <summary>
           /// Desc:手术过程描述
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string OPERATION_COURSE {get;set;}

           /// <summary>
           /// Desc:0 否；1 是
           /// Default:
           /// Nullable:True
           /// </summary>           
           public int? OPERATION_HISTORY_FLAG {get;set;}

           /// <summary>
           /// Desc:皮肤消毒描述
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string SKIN_DISINFECTION {get;set;}

           /// <summary>
           /// Desc:出血量(ml)
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? SHED_BLOOD {get;set;}

           /// <summary>
           /// Desc:输血量(ml)
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? TRANSFUSION_BLOOD {get;set;}

           /// <summary>
           /// Desc:输液量(ml)
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? INFUSION {get;set;}

           /// <summary>
           /// Desc:术前用药
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string PREOPERATIVE_DRUG {get;set;}

           /// <summary>
           /// Desc:术中用药
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string OPERATION_ING_DRUG {get;set;}

           /// <summary>
           /// Desc:手术医师编码
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string OPERATION_DOCTOR_CODE {get;set;}

           /// <summary>
           /// Desc:手术医师姓名
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string OPERATION_DOCTOR_NAME {get;set;}

           /// <summary>
           /// Desc:手术医师在手术记录中确认签名的日期 yyyy-mm-dd hh24:mi:ss
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? OPERATION_DATE {get;set;}

           /// <summary>
           /// Desc:记录抽取时间，不需院方提供
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? UPD_DATE {get;set;}

    }
}
