using System;
using System.Linq;
using System.Text;

namespace Models
{
    ///<summary>
    ///DP院内职工字典
    ///</summary>
    public partial class DP_DICT_EMPLOYEE
    {
           public DP_DICT_EMPLOYEE(){


           }
           /// <summary>
           /// Desc:院内职工编码
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string EMP_CODE {get;set;}

           /// <summary>
           /// Desc:职工姓名
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string EMP_NAME {get;set;}

           /// <summary>
           /// Desc:职工登录其他应用系统时使用的用户名
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string EMP_UID {get;set;}

           /// <summary>
           /// Desc:职工登录密码
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string EMP_PWD {get;set;}

           /// <summary>
           /// Desc:yyyy-mm-dd
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? BIRTH_DATE {get;set;}

           /// <summary>
           /// Desc:职工手机号
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string PHONE {get;set;}

           /// <summary>
           /// Desc:职称
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string TITLE {get;set;}

           /// <summary>
           /// Desc:记录抽取时间，不需院方提供
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? UPD_DATE {get;set;}

    }
}
