using System;
using System.Linq;
using System.Text;

namespace Models
{
    ///<summary>
    ///DP诊断字典
    ///</summary>
    public partial class DP_DICT_DIAG
    {
           public DP_DICT_DIAG(){


           }
           /// <summary>
           /// Desc:本院的诊断项目编码
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string DIAG_CODE {get;set;}

           /// <summary>
           /// Desc:ICD9或ICD10编码
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string DIAG_ICD {get;set;}

           /// <summary>
           /// Desc:诊断名称
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string DIAG_NAME {get;set;}

           /// <summary>
           /// Desc:记录抽取时间，不需院方提供
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? UPD_DATE {get;set;}

    }
}
