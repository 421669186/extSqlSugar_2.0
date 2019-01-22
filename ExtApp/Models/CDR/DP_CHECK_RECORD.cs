using System;
using System.Linq;
using System.Text;

namespace Models
{
    ///<summary>
    ///DP检查记录
    ///</summary>
    public partial class DP_CHECK_RECORD
    {
           public DP_CHECK_RECORD(){


           }
           /// <summary>
           /// Desc:主键，可以是业务数据主键或者GUID
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string CHECK_ID {get;set;}

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
           /// Desc:检查系统自带的流水号
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string MO_CHECK_NO {get;set;}

           /// <summary>
           /// Desc:与医嘱关联
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string APPLY_NO {get;set;}

           /// <summary>
           /// Desc:1:放射;  2:超声;  3:内镜;  5:心电;  6:核医学;  9:其他;  
           /// Default:
           /// Nullable:True
           /// </summary>           
           public int? CHK_SYSTEM_CODE {get;set;}

           /// <summary>
           /// Desc:例如当系统代码为1时，有：X线/CT/MRI
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string CHECK_TYPE {get;set;}

           /// <summary>
           /// Desc:检查项目代码
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string CHECK_ITEM_CODE {get;set;}

           /// <summary>
           /// Desc:如,胸部X线，腹部CT
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string CHECK_ITEM_NAME {get;set;}

           /// <summary>
           /// Desc:登记室预约时间 yyyy-mm-dd hh24:mi:ss
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? APPLY_DATE {get;set;}

           /// <summary>
           /// Desc:申请科室代码
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string APPLY_DEPT_CODE {get;set;}

           /// <summary>
           /// Desc:记账的科室
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string APPLY_DEPT_NAME {get;set;}

           /// <summary>
           /// Desc:医技科室接收的时间 yyyy-mm-dd hh24:mi:ss
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? RECEIVE_DATE {get;set;}

           /// <summary>
           /// Desc:患者做检查的时间 yyyy-mm-dd hh24:mi:ss
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? CHECK_DATE {get;set;}

           /// <summary>
           /// Desc:执行科室代码
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string EXEC_DEPT_CODE {get;set;}

           /// <summary>
           /// Desc:医技科室名称
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string EXEC_DEPT_NAME {get;set;}

           /// <summary>
           /// Desc:如头颅、胸部、腹部
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string BODY_PART_NAME {get;set;}

           /// <summary>
           /// Desc:检查结果类型，如胸部正片
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string CHECK_RESULT_TYPE {get;set;}

           /// <summary>
           /// Desc:客观所见的报告
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string REPORT_OBJECTIVE {get;set;}

           /// <summary>
           /// Desc:检查结论
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
           /// Desc:医技人员编写检查报告后的审核/上传时间 yyyy-mm-dd hh24:mi:ss
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? REPORT_DATE {get;set;}

           /// <summary>
           /// Desc:编写检查报告后的医技人员的姓名
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
