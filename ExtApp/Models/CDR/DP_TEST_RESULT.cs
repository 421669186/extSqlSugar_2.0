using System;
using System.Linq;
using System.Text;

namespace Models
{
    ///<summary>
    ///DP检验结果
    ///</summary>
    public partial class DP_TEST_RESULT
    {
           public DP_TEST_RESULT(){


           }
           /// <summary>
           /// Desc:主键，可以是业务数据主键或者GUID
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string RESULT_ID {get;set;}

           /// <summary>
           /// Desc:与检验记录表中的样本号关联
           /// Default:
           /// Nullable:True
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
           /// Desc:检验项目编码，对应检验记录表或项目字典表的检验项目编码或套餐编码
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string TEST_ITEM_CODE {get;set;}

           /// <summary>
           /// Desc:结果项目编码
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string RESULT_ITEM_CODE {get;set;}

           /// <summary>
           /// Desc:结果项目名称
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string RESULT_ITEM_NAME {get;set;}

           /// <summary>
           /// Desc:结果值
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string RESULT_VALUE {get;set;}

           /// <summary>
           /// Desc:结果单位
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string RESULT_UNIT {get;set;}

           /// <summary>
           /// Desc:参考范围
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string REF_RANGE {get;set;}

           /// <summary>
           /// Desc:与"参考范围"是并列的关系
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string MIN_RANGE {get;set;}

           /// <summary>
           /// Desc:与"参考范围"是并列的关系
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string MAX_RANGE {get;set;}

           /// <summary>
           /// Desc:结果状态	   正常、偏高、偏低
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string RESULT_STATUS {get;set;}

           /// <summary>
           /// Desc:检验方法代码
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string TEST_METHOD_CODE {get;set;}

           /// <summary>
           /// Desc:如化学发光法、仪器法、速率法等
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string TEST_METHOD_NAME {get;set;}

           /// <summary>
           /// Desc:记录抽取时间，不需院方提供
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? UPD_DATE {get;set;}

    }
}
