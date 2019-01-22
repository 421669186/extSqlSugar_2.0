using System;
using System.Linq;
using System.Text;

namespace Models
{
    ///<summary>
    ///DP住院患者病历记录
    ///</summary>
    public partial class DP_EMR_RECORD
    {
           public DP_EMR_RECORD(){


           }
           /// <summary>
           /// Desc:主键，可以是业务数据主键或者GUID
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string EMR_REC_ID {get;set;}

           /// <summary>
           /// Desc:患者唯一标识
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string PATIENT_ID {get;set;}

           /// <summary>
           /// Desc:本次住院唯一标识
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string PATIENT_NO {get;set;}

           /// <summary>
           /// Desc:21601:入院记录;  216616:24小时入出院记录;  31601:首次病程记录;  31602:日常病程记录;  31615:术后首次病程记录;  31603:上级医师查房记录;  31604:疑难病例讨论记录;  31607:阶段小结;  31609:会诊记录;  81601:护理记录;  31610:术前小结;  31611:术前讨论记录;  31613:手术记录;  61601:出院记录;  71601:死亡记录;  41601:转入记录;  41602:转出记录;  51601:转科小结;  99000:病案首页;  99999:其他（无法对应到上面的）;  
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string EMR_TYPE_CODE {get;set;}

           /// <summary>
           /// Desc:病历类型名称	   来至病历类型编码字典
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string EMR_TYPE_NAME {get;set;}

           /// <summary>
           /// Desc:原始病历类型编码
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string LGCY_TYPE_CODE {get;set;}

           /// <summary>
           /// Desc:原始病历类型名称
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string LGCY_TYPE_NAME {get;set;}

           /// <summary>
           /// Desc:原始病历子类型编码
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string LGCY_SUB_TYPE_CODE {get;set;}

           /// <summary>
           /// Desc:原始病历子类型名称
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string LGCY_SUB_TYPE_NAME {get;set;}

           /// <summary>
           /// Desc:纯文本病历内容
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string REC_CONTENT {get;set;}

           /// <summary>
           /// Desc:带格式病历内容
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string REC_CONTENT_FM {get;set;}

           /// <summary>
           /// Desc:1:文本;  2:HTML;  3:XML;  
           /// Default:
           /// Nullable:True
           /// </summary>           
           public int? REC_TYPE {get;set;}

           /// <summary>
           /// Desc:创建人编码
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string CREATOR_CODE {get;set;}

           /// <summary>
           /// Desc:创建病历的医师
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string CREATOR_NAME {get;set;}

           /// <summary>
           /// Desc:创建病历的时间 yyyy-mm-dd hh24:mi:ss
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? CREATE_DATE {get;set;}

           /// <summary>
           /// Desc:记录人编码
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string REC_PSN_CODE {get;set;}

           /// <summary>
           /// Desc:病历打印出来呈现在纸面上的医师姓名
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string REC_PSN_NAME {get;set;}

           /// <summary>
           /// Desc:病历打印出来呈现在纸面上的时间 yyyy-mm-dd hh24:mi:ss
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? REC_DATE {get;set;}

           /// <summary>
           /// Desc:记录人科室代码
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string REC_DEPT_CODE {get;set;}

           /// <summary>
           /// Desc:书写病历的医师所在的科室
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string REC_DEPT_NAME {get;set;}

           /// <summary>
           /// Desc:上级医师编码
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string PARENT_CODE {get;set;}

           /// <summary>
           /// Desc:上级医师姓名
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string PARENT_NAME {get;set;}

           /// <summary>
           /// Desc:主任医师编码
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string DIRECTOR_CODE {get;set;}

           /// <summary>
           /// Desc:主任医师姓名
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string DIRECTOR_NAME {get;set;}

           /// <summary>
           /// Desc:记录抽取时间，不需院方提供
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? UPD_DATE {get;set;}

    }
}
