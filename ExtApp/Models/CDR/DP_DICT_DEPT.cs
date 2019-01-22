using System;
using System.Linq;
using System.Text;

namespace Models
{
    ///<summary>
    ///DP科室字典
    ///</summary>
    public partial class DP_DICT_DEPT
    {
           public DP_DICT_DEPT(){


           }
           /// <summary>
           /// Desc:科室编码
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string DEPT_CODE {get;set;}

           /// <summary>
           /// Desc:科室名称
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string DEPT_NAME {get;set;}

           /// <summary>
           /// Desc:上级科室编码
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string PARENT_DEPT_CODE {get;set;}

           /// <summary>
           /// Desc:记录抽取时间，不需院方提供
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? UPD_DATE {get;set;}

    }
}
