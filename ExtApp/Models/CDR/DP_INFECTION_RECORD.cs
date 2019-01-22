using System;
using System.Linq;
using System.Text;

namespace Models
{
    ///<summary>
    ///DP院感记录
    ///</summary>
    public partial class DP_INFECTION_RECORD
    {
           public DP_INFECTION_RECORD(){


           }
           /// <summary>
           /// Desc:主键，可以是业务数据主键或者GUID
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string INFE_REC_ID {get;set;}

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
           /// Desc:院感系统自带的流水号
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string INFE_NO {get;set;}

           /// <summary>
           /// Desc:患者办理入院的时间 yyyy-mm-dd hh24:mi:ss
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? IN_DATE {get;set;}

           /// <summary>
           /// Desc:可以多个，逗号区分
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string IN_DIAG_CODE {get;set;}

           /// <summary>
           /// Desc:可以多个，逗号区分
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string IN_DIAG_NAME {get;set;}

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
           /// Desc:办理出院的时间（挂账时间） yyyy-mm-dd hh24:mi:ss
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? OUT_DATE {get;set;}

           /// <summary>
           /// Desc:可以多个，逗号区分
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string OUT_DIAG_CODE {get;set;}

           /// <summary>
           /// Desc:可以多个，逗号区分
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string OUT_DIAG_NAME {get;set;}

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
           /// Desc:在医院感染后的上报时间 yyyy-mm-dd hh24:mi:ss
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? INFE_DATE {get;set;}

           /// <summary>
           /// Desc:感染类型代码
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string INFE_TYPE_CODE {get;set;}

           /// <summary>
           /// Desc:感染类型名称
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string INFE_TYPE_NAME {get;set;}

           /// <summary>
           /// Desc:感染部位代码
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string INFE_POS_CODE {get;set;}

           /// <summary>
           /// Desc:如上呼吸道、眼耳口腔
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string INFE_POS_NAME {get;set;}

           /// <summary>
           /// Desc:其他感染部位描述
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string INFE_POS_OTHER {get;set;}

           /// <summary>
           /// Desc:0 否；1 是
           /// Default:
           /// Nullable:True
           /// </summary>           
           public int? IS_BABY_INFE {get;set;}

           /// <summary>
           /// Desc:感染科室代码
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string INFE_DEPT_CODE {get;set;}

           /// <summary>
           /// Desc:上报的科室名称
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string INFE_DEPT_NAME {get;set;}

           /// <summary>
           /// Desc:感染预后代码
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string INFE_PROG_CODE {get;set;}

           /// <summary>
           /// Desc:感染预后名称
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string INFE_PROG_NAME {get;set;}

           /// <summary>
           /// Desc:易感因素代码
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string PRED_FACT_CODE {get;set;}

           /// <summary>
           /// Desc:易感因素名称
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string PRED_FACT_NAME {get;set;}

           /// <summary>
           /// Desc:记录抽取时间，不需院方提供
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? UPD_DATE {get;set;}

    }
}
