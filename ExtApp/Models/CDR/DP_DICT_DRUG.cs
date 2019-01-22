using System;
using System.Linq;
using System.Text;

namespace Models
{
    ///<summary>
    ///DP药品字典
    ///</summary>
    public partial class DP_DICT_DRUG
    {
           public DP_DICT_DRUG(){


           }
           /// <summary>
           /// Desc:医嘱表中使用的源系统的药品编码
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string DRUG_CODE {get;set;}

           /// <summary>
           /// Desc:医院自己起的名字
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string DRUG_NAME {get;set;}

           /// <summary>
           /// Desc:如：阿司匹林肠溶片、阿司匹林片
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string GENERIC_NAME {get;set;}

           /// <summary>
           /// Desc:如：拜阿司匹灵
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string GOODS_NAME {get;set;}

           /// <summary>
           /// Desc:学名、别名、英文名称
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string OTHER_NAME {get;set;}

           /// <summary>
           /// Desc:药品类别名称	   如： 西药， 中成药，中草药，其他
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string CATEGORY {get;set;}

           /// <summary>
           /// Desc:药品性质名称	   如： 普通药物，麻醉药，毒性药品
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string QUALITY {get;set;}

           /// <summary>
           /// Desc:片剂、胶囊等
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string DOSAGE {get;set;}

           /// <summary>
           /// Desc:一般指制剂规格，如50mg/片
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string SPECS {get;set;}

           /// <summary>
           /// Desc:最小制剂单位，如片
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string MIN_UNIT {get;set;}

           /// <summary>
           /// Desc:如7片/板、2板/盒
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string PACK_SPECS {get;set;}

           /// <summary>
           /// Desc:如盒、袋
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string PACK_UNIT {get;set;}

           /// <summary>
           /// Desc:用法名称	   餐前、餐后、空腹等
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string USAGE_NAME {get;set;}

           /// <summary>
           /// Desc:如：一天4次
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string FREQ_NAME {get;set;}

           /// <summary>
           /// Desc:基本剂量的数值（如5mg）
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? BASE_DOSE {get;set;}

           /// <summary>
           /// Desc:基本剂量单位
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string BASE_DOSE_UNIT {get;set;}

           /// <summary>
           /// Desc:0 非处方药	   1 处方药
           /// Default:
           /// Nullable:True
           /// </summary>           
           public int? OCT_FLAG {get;set;}

           /// <summary>
           /// Desc:产地名称
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string PRODUCING_AREA {get;set;}

           /// <summary>
           /// Desc:生产厂家名称
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string PRODUCER_NAME {get;set;}

           /// <summary>
           /// Desc:记录抽取时间，不需院方提供
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? UPD_DATE {get;set;}

    }
}
