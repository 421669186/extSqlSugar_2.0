using System;
using System.Linq;
using System.Text;

namespace Models
{
    ///<summary>
    ///检验记录、检验申请
    ///</summary>
    public partial class DP_TEST_RECORD
    {
           public DP_TEST_RECORD(){


           }
           /// <summary>
           /// Desc:主键，与检验结果中的样本和关联
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string SAMPLE_NO {get;set;}

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
           /// Desc:检验系统自带的流水号
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string MO_TEST_NO {get;set;}

           /// <summary>
           /// Desc:与医嘱关联
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string APPLY_NO {get;set;}

           /// <summary>
           /// Desc:0 否 ;1 是
           /// Default:
           /// Nullable:True
           /// </summary>           
           public int? GERM_FLAG {get;set;}

           /// <summary>
           /// Desc:检验项目编码
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string TEST_ITEM_CODE {get;set;}

           /// <summary>
           /// Desc:检验项目名称
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string TEST_ITEM_NAME {get;set;}

           /// <summary>
           /// Desc:样本类型编码
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string SAMPLE_TYPE_CODE {get;set;}

           /// <summary>
           /// Desc:如尿、血清、血浆
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string SAMPLE_TYPE_NAME {get;set;}

           /// <summary>
           /// Desc:如左上肢
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string SAMPLE_BODY {get;set;}

           /// <summary>
           /// Desc:申请科室编码
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string APPLY_DEP_CODE {get;set;}

           /// <summary>
           /// Desc:申请医师所在的科室
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string APPLY_DEP_NAME {get;set;}

           /// <summary>
           /// Desc:Lis系统收到的申请时间 yyyy-mm-dd hh24:mi:ss
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? APPLY_DATE {get;set;}

           /// <summary>
           /// Desc:进行样本采集的时间 yyyy-mm-dd hh24:mi:ss
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? SAMPLING_DATE {get;set;}

           /// <summary>
           /// Desc:医技人员接收到样本的时间 yyyy-mm-dd hh24:mi:ss
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? RECEIVE_DATE {get;set;}

           /// <summary>
           /// Desc:医技人员进行样本检验的开始时间 yyyy-mm-dd hh24:mi:ss
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? TEST_DATE {get;set;}

           /// <summary>
           /// Desc:医技人员编写检验报告的时间 yyyy-mm-dd hh24:mi:ss
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? REPORT_DATE {get;set;}

           /// <summary>
           /// Desc:编写检验报告的医技人员的姓名
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
