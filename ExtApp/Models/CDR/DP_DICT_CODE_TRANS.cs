using System;
using System.Linq;
using System.Text;

namespace Models
{
    ///<summary>
    ///不需客户提供
    ///</summary>
    public partial class DP_DICT_CODE_TRANS
    {
           public DP_DICT_CODE_TRANS(){


           }
           /// <summary>
           /// Desc:原始字典类别
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string ORIG_CLASS_CODE {get;set;}

           /// <summary>
           /// Desc:原始项目代码
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string ORIG_ITEM_CODE {get;set;}

           /// <summary>
           /// Desc:原始项目名称
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string ORIG_ITEM_NAME {get;set;}

           /// <summary>
           /// Desc:转换后类别代码
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string DP_CLASS_CODE {get;set;}

           /// <summary>
           /// Desc:转换后项目代码
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string DP_ITEM_CODE {get;set;}

           /// <summary>
           /// Desc:转换后项目名称
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string DP_ITEM_NAME {get;set;}

           /// <summary>
           /// Desc:备注
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string MEMO {get;set;}

    }
}
