using System;
using System.Linq;
using System.Text;

namespace Models
{
    ///<summary>
    ///DP检查检验项目字典
    ///</summary>
    public partial class DP_DICT_CHECKTEST
    {
           public DP_DICT_CHECKTEST(){


           }
           /// <summary>
           /// Desc:自动生成，不需客户提供
           /// Default:
           /// Nullable:False
           /// </summary>           
           public int DICT_ITEM_ID {get;set;}

           /// <summary>
           /// Desc:1:治疗项目;  2:检验项目;  3:检查项目;  
           /// Default:
           /// Nullable:True
           /// </summary>           
           public int? CHK_CAT_CODE {get;set;}

           /// <summary>
           /// Desc:套餐编码
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string ITEM_LIST_CODE {get;set;}

           /// <summary>
           /// Desc:本院自己制定的套餐名称
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string ITEM_LIST_NAME {get;set;}

           /// <summary>
           /// Desc:项目编码
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string ITEM_CODE {get;set;}

           /// <summary>
           /// Desc:具体的治疗、检查、检验项目
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string ITEM_NAME {get;set;}

           /// <summary>
           /// Desc:项目单位
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string ITEM_UNIT {get;set;}

           /// <summary>
           /// Desc:显示顺序
           /// Default:
           /// Nullable:True
           /// </summary>           
           public int? DISP_ORDER {get;set;}

           /// <summary>
           /// Desc:记录抽取时间，不需院方提供
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? UPD_DATE {get;set;}

    }
}
