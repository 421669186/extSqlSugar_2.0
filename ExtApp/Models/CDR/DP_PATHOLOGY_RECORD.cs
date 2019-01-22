using System;
using System.Linq;
using System.Text;

namespace Models
{
    ///<summary>
    ///DP病理记录
    ///</summary>
    public partial class DP_PATHOLOGY_RECORD
    {
           public DP_PATHOLOGY_RECORD(){


           }
           /// <summary>
           /// Desc:主键，可以是业务数据主键或者GUID
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string PATHOLOGY_ID {get;set;}

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
           /// Desc:患者姓名
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string PATIENT_NAME {get;set;}

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
           /// Desc:住院病案号
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string CASE_NO {get;set;}

           /// <summary>
           /// Desc:病理系统自带的流水号
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string MO_CHECK_NO {get;set;}

           /// <summary>
           /// Desc:主诉
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string COMPLAINTS {get;set;}

           /// <summary>
           /// Desc:临床诊断名称
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string DIAGNOSE_NAME {get;set;}

           /// <summary>
           /// Desc:病史
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string MEDICAL_HISTORY {get;set;}

           /// <summary>
           /// Desc:与医嘱的申请单号关联
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string APPLY_NO {get;set;}

           /// <summary>
           /// Desc:登记室预约时间 yyyy-mm-dd hh24:mi:ss
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? APPLY_DATE {get;set;}

           /// <summary>
           /// Desc:申请科室编码
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string APPLY_DEPT_CODE {get;set;}

           /// <summary>
           /// Desc:申请人所在的科室
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string APPLY_DEPT_NAME {get;set;}

           /// <summary>
           /// Desc:发起申请的医师姓名
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string APPLY_DOCTOR_NAME {get;set;}

           /// <summary>
           /// Desc:医技人员进行样本采集的时间（病理是先接收，后采样） yyyy-mm-dd hh24:mi:ss
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? SAMPLING_DATE {get;set;}

           /// <summary>
           /// Desc:取样部位
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string SAMPLE_PART {get;set;}

           /// <summary>
           /// Desc:组织液等
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string SAMPLE_TYPE_NAME {get;set;}

           /// <summary>
           /// Desc:收到组织的时间（病理是先接收，后采样） yyyy-mm-dd hh24:mi:ss
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? RECEIVE_DATE {get;set;}

           /// <summary>
           /// Desc:检查项目编码
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string ITEM_CODE {get;set;}

           /// <summary>
           /// Desc:检查项目名称
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string ITEM_NAME {get;set;}

           /// <summary>
           /// Desc:医技科室中进行病理检查的医师姓名
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string CHECK_DOCTOR_NAME {get;set;}

           /// <summary>
           /// Desc:进行病理检查的时间 yyyy-mm-dd hh24:mi:ss
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? CHECK_DATE {get;set;}

           /// <summary>
           /// Desc:报告结果-客观所见（检查所见）
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string REPORT_OBJECTIVE {get;set;}

           /// <summary>
           /// Desc:报告结果-主观提示（肉眼所见）
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string REPORT_SUBJECTIVE {get;set;}

           /// <summary>
           /// Desc:同主观提示，考虑可删除
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string REPORT_RESULT {get;set;}

           /// <summary>
           /// Desc:活检
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string BIOPSY {get;set;}

           /// <summary>
           /// Desc:病理
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string PATHOLOGY {get;set;}

           /// <summary>
           /// Desc:阳性
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string POSITIVE {get;set;}

           /// <summary>
           /// Desc:切片数
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string SECTION_COUNT {get;set;}

           /// <summary>
           /// Desc:冰冻结果
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string FROZEN_RESULT {get;set;}

           /// <summary>
           /// Desc:进行冰冻后，完成报告的时间 yyyy-mm-dd hh24:mi:ss
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? FROZEN_REPORT_DATE {get;set;}

           /// <summary>
           /// Desc:医技人员完成报告的时间 yyyy-mm-dd hh24:mi:ss
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? REPORT_DATE_TIME {get;set;}

           /// <summary>
           /// Desc:编写报告的医师姓名
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string REPORT_DOCTOR_NAME {get;set;}

           /// <summary>
           /// Desc:yyyy-mm-dd hh24:mi:ss
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? CHK_DATE {get;set;}

           /// <summary>
           /// Desc:审核医师姓名
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string CHK_DOCTOR_NAME {get;set;}

           /// <summary>
           /// Desc:记录抽取时间，不需院方提供
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? UPD_DATE {get;set;}

    }
}
