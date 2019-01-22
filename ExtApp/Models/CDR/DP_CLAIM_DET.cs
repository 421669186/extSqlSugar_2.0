using System;
using System.Linq;
using System.Text;

namespace Models
{
    ///<summary>
    ///DP结算明细记录
    ///</summary>
    public partial class DP_CLAIM_DET
    {
           public DP_CLAIM_DET(){


           }
           /// <summary>
           /// Desc:主键，可以是业务数据主键或者GUID
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string CLM_DET_ID {get;set;}

           /// <summary>
           /// Desc:与“结算主记录”进行关联
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string CLM_ID {get;set;}

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
           /// Desc:患者唯一标识
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string PATIENT_ID {get;set;}

           /// <summary>
           /// Desc:正负交易，0正交易，1负交易
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? CLM_TRANS_TYPE_CODE {get;set;}

           /// <summary>
           /// Desc:该项目的门诊交费时间或住院时记账时间 yyyy-mm-dd hh24:mi:ss
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? CHRG_DATE {get;set;}

           /// <summary>
           /// Desc:本次结算的时间，从主记录表冗余过来 yyyy-mm-dd hh24:mi:ss
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? CLM_DATE {get;set;}

           /// <summary>
           /// Desc:用于与医嘱关联（尽可能取）
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string MO_ORDER_NO {get;set;}

           /// <summary>
           /// Desc:用于与医嘱关联（尽可能取）
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string APPLY_NO {get;set;}

           /// <summary>
           /// Desc:收费项目类别代码
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string CHRG_ITEM_TYPE_CODE {get;set;}

           /// <summary>
           /// Desc:收费项目类别，如西药费、检查费、治疗费等等
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string CHRG_ITEM_TYPE_NAME {get;set;}

           /// <summary>
           /// Desc:医院类别代码
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string HOSP_CAT_CODE {get;set;}

           /// <summary>
           /// Desc:如综合医院、肿瘤专科医院等
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string HOSP_CAT_NAME {get;set;}

           /// <summary>
           /// Desc:是否药品，1是 0不是
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? IS_DRUG_FLAG {get;set;}

           /// <summary>
           /// Desc:是否非适应症用药，1是 0不是
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? ANTI_SYZ_FLAG {get;set;}

           /// <summary>
           /// Desc:该项目是否医保范围内，1是 0不是
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? IS_MI_FLAG {get;set;}

           /// <summary>
           /// Desc:组套项目代码
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string ITEM_LIST_CODE {get;set;}

           /// <summary>
           /// Desc:组套项目名称
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string ITEM_LIST_NAME {get;set;}

           /// <summary>
           /// Desc:项目代码
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string ITEM_CODE {get;set;}

           /// <summary>
           /// Desc:项目名称
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string ITEM_NAME {get;set;}

           /// <summary>
           /// Desc:规格
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string SPEC {get;set;}

           /// <summary>
           /// Desc:收费单位
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string CHRG_UNIT {get;set;}

           /// <summary>
           /// Desc:单价
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? UNIT_PRICE {get;set;}

           /// <summary>
           /// Desc:数量
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? CNT {get;set;}

           /// <summary>
           /// Desc:金额
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? AMT {get;set;}

           /// <summary>
           /// Desc:收费员代码
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string CHRG_USER {get;set;}

           /// <summary>
           /// Desc:记录抽取时间，不需院方提供
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? UPD_DATE {get;set;}

    }
}
