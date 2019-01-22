using System;
using System.Linq;
using System.Text;

namespace Models
{
    ///<summary>
    ///DP职工所属科室字典
    ///</summary>
    public partial class DP_DICT_EMPLOYEE_DEPT
    {
           public DP_DICT_EMPLOYEE_DEPT(){


           }
           /// <summary>
           /// Desc:职工编码
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string EMP_CODE {get;set;}

           /// <summary>
           /// Desc:科室编码
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string DEPT_CODE {get;set;}

           /// <summary>
           /// Desc:上级科室编码
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string EMP_DEPT_CODE {get;set;}

           /// <summary>
           /// Desc:yyyy-mm-dd hh24:mi:ss
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? IN_DEPT_DATE {get;set;}

           /// <summary>
           /// Desc:yyyy-mm-dd hh24:mi:ss
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? OUT_DEPT_DATE {get;set;}

           /// <summary>
           /// Desc:记录抽取时间，不需院方提供
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? UPD_DATE {get;set;}

    }
}
