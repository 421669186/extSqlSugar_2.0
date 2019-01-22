using System;
using System.Linq;
using System.Text;

namespace Models
{
    ///<summary>
    ///DP麻醉记录
    ///</summary>
    public partial class DP_ANESTHESIA_RECORD
    {
           public DP_ANESTHESIA_RECORD(){


           }
           /// <summary>
           /// Desc:主键，可以是业务数据主键或者GUID
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string ANE_REC_ID {get;set;}

           /// <summary>
           /// Desc:手术ID，用于与手术关联
           /// Default:
           /// Nullable:True
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
           /// Desc:体重(KG)
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string WEIGHT {get;set;}

           /// <summary>
           /// Desc:1:A型;  2:B型;  3:O型;  4:AB型;  9:不详;  
           /// Default:
           /// Nullable:True
           /// </summary>           
           public int? ABO_BLOOD_CODE {get;set;}

           /// <summary>
           /// Desc:1:阴性;  2:阳性;  3:不详;  4:未查;  
           /// Default:
           /// Nullable:True
           /// </summary>           
           public int? RH_BLOOD_CODE {get;set;}

           /// <summary>
           /// Desc:手术及操作编码
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string OPERATION_CODE {get;set;}

           /// <summary>
           /// Desc:	   
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string OPERATION_NAME {get;set;}

           /// <summary>
           /// Desc:手术部位编码
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string POSITION_CODE {get;set;}

           /// <summary>
           /// Desc:手术部位名称
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string POSITION_NAME {get;set;}

           /// <summary>
           /// Desc:麻醉方法代码
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string ANESTHESIA_CODE {get;set;}

           /// <summary>
           /// Desc:麻醉方法名称
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string ANESTHESIA_NAME {get;set;}

           /// <summary>
           /// Desc:气管插管分类
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string TRACHEALTUBE_TYPE {get;set;}

           /// <summary>
           /// Desc:麻醉药物名称
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string ANESTHESIA_DRUG_NAME {get;set;}

           /// <summary>
           /// Desc:麻醉体位
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string ANESTHESIA_POSITION {get;set;}

           /// <summary>
           /// Desc:1:自主呼吸;  2:辅助呼吸;  3:控制呼吸;  
           /// Default:
           /// Nullable:True
           /// </summary>           
           public int? BREATH_TYPE_CODE {get;set;}

           /// <summary>
           /// Desc:麻醉描述
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string ANESTHESIA_DESC {get;set;}

           /// <summary>
           /// Desc:常规监测项目名称
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string ROUTINE_MONITOR_NAME {get;set;}

           /// <summary>
           /// Desc:常规监测项目结果
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string ROUTINE_MONITOR_RESULT {get;set;}

           /// <summary>
           /// Desc:特殊监测项目名称
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string SPECIAL_MONITOR_NAME {get;set;}

           /// <summary>
           /// Desc:特殊监测项目结果
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string SPECIAL_MONITOR_RESULT {get;set;}

           /// <summary>
           /// Desc:1:否;  2:是;  3:不确定;  
           /// Default:
           /// Nullable:True
           /// </summary>           
           public int? COMPLICATION_FLAG {get;set;}

           /// <summary>
           /// Desc:诊疗过程描述
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string TREATMENT_COURSE {get;set;}

           /// <summary>
           /// Desc:刺穿过程
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string PUNCTURE_COURSE {get;set;}

           /// <summary>
           /// Desc:I:无基础疾病;  II:存在基础疾病，但没有影响正常生活;  III:存在基础疾病，影响正常生活;  IV:存在严重基础疾病，明显影响生活;  V:无论手术与否，病人都可能在24小时内死亡;  
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string ASA_GRADE {get;set;}

           /// <summary>
           /// Desc:麻醉效果
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string ANESTHETIC_EFFECT {get;set;}

           /// <summary>
           /// Desc:麻醉前用药
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string ANESTHETIC_BEFORE_DRUG {get;set;}

           /// <summary>
           /// Desc:手术记录里有 yyyy-mm-dd hh24:mi:ss
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? START_DATE {get;set;}

           /// <summary>
           /// Desc:手术记录里有 yyyy-mm-dd hh24:mi:ss
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? END_DATE {get;set;}

           /// <summary>
           /// Desc:yyyy-mm-dd hh24:mi:ss
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? ANESTHESIA_START_DATE {get;set;}

           /// <summary>
           /// Desc:yyyy-mm-dd hh24:mi:ss
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? ANESTHESIA_END_DATE {get;set;}

           /// <summary>
           /// Desc:手术记录里有 yyyy-mm-dd hh24:mi:ss
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? IN_DATE {get;set;}

           /// <summary>
           /// Desc:手术记录里有 yyyy-mm-dd hh24:mi:ss
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? OUT_DATE {get;set;}

           /// <summary>
           /// Desc:yyyy-mm-dd hh24:mi:ss
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? IN_PACU_TIME {get;set;}

           /// <summary>
           /// Desc:yyyy-mm-dd hh24:mi:ss
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? OUT_PACU_TIME {get;set;}

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
           /// Desc:药物编码
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string DRUG_CODE {get;set;}

           /// <summary>
           /// Desc:药物名称
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string DRUG_NAME {get;set;}

           /// <summary>
           /// Desc:频次代码
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string FREQ_CODE {get;set;}

           /// <summary>
           /// Desc:频次名称
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string FREQ_NAME {get;set;}

           /// <summary>
           /// Desc:药物使用剂量单位
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string DRUG_DOSE_UNIT {get;set;}

           /// <summary>
           /// Desc:药物使用次剂量
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? DRUG_DOSE_ONCE {get;set;}

           /// <summary>
           /// Desc:药物使用总剂量
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? DRUG_DOSE_TOT {get;set;}

           /// <summary>
           /// Desc:给药途径代码
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string GYTJ_CODE {get;set;}

           /// <summary>
           /// Desc:给药途径名称	   口服、肌肉注射等
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string GYTJ_NAME {get;set;}

           /// <summary>
           /// Desc:输血量(ml)
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? TRANSFUSION_BLOOD {get;set;}

           /// <summary>
           /// Desc:输血剂量单位
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string TRANSFUSION_BLOOD_UNIT {get;set;}

           /// <summary>
           /// Desc:开始输血时间 yyyy-mm-dd hh24:mi:ss
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? TRANSFUSION_BLOOD_DATE {get;set;}

           /// <summary>
           /// Desc:输血品种代码
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string TRANSFUSION_BREED_CODE {get;set;}

           /// <summary>
           /// Desc:输血品种名称
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string TRANSFUSION_BREED_NAME {get;set;}

           /// <summary>
           /// Desc:0 否	   1 是
           /// Default:
           /// Nullable:True
           /// </summary>           
           public int? BLOOD_TRANREACT_FLAG {get;set;}

           /// <summary>
           /// Desc:手术过程输入液体的描述
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string OPERATION_ING_INFUSION {get;set;}

           /// <summary>
           /// Desc:出血量(ml)
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? SHED_BLOOD {get;set;}

           /// <summary>
           /// Desc:麻醉医师签名
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string ANESTHESIA_DOCTOR {get;set;}

           /// <summary>
           /// Desc:麻醉医师在麻醉记录中确认签名的日期 yyyy-mm-dd hh24:mi:ss
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? ANESTHESIA_DATE {get;set;}

           /// <summary>
           /// Desc:记录抽取时间，不需院方提供
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? UPD_DATE {get;set;}

    }
}
