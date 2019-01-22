using System;
using System.Linq;
using System.Text;

namespace Models
{
    ///<summary>
    ///DP微生物检验结果
    ///</summary>
    public partial class DP_TEST_RESULT_GERM
    {
           public DP_TEST_RESULT_GERM(){


           }
           /// <summary>
           /// Desc:主键，可以是业务数据主键或者GUID
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string GERM_ID {get;set;}

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
           /// Desc:有菌生长、无菌生长
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string CULTURE_RESULT {get;set;}

           /// <summary>
           /// Desc:细菌编码
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string GERM_CODE {get;set;}

           /// <summary>
           /// Desc:细菌名称
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string GERM_NAME {get;set;}

           /// <summary>
           /// Desc:抗生素编码
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string ANTI_CODE {get;set;}

           /// <summary>
           /// Desc:抗生素名称
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string ANTI_NAME {get;set;}

           /// <summary>
           /// Desc:最小抑菌浓度（MIC）
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string NUM_RESULT {get;set;}

           /// <summary>
           /// Desc:敏感S/中敏I/耐药R
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string LETTER_RESULT {get;set;}

           /// <summary>
           /// Desc:记录抽取时间，不需院方提供
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? UPD_DATE {get;set;}

    }
}
