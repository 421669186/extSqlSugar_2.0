using System;
using System.Linq;
using System.Text;

namespace Models
{
    ///<summary>
    ///不需客户提供
    ///</summary>
    public partial class DP_DICT_MASTER
    {
           public DP_DICT_MASTER(){


           }
           /// <summary>
           /// Desc:字典类别代码
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string DP_CLASS_CODE {get;set;}

           /// <summary>
           /// Desc:字典类别名称
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string DP_CLASS_NAME {get;set;}

           /// <summary>
           /// Desc:顺序号
           /// Default:
           /// Nullable:True
           /// </summary>           
           public int? ORDER_NO {get;set;}

           /// <summary>
           /// Desc:备注
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string MEMO {get;set;}

    }
}
