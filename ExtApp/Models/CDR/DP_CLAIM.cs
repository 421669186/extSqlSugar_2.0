using System;
using System.Linq;
using System.Text;

namespace Models
{
    ///<summary>
    ///DP结算主记录
    ///</summary>
    public partial class DP_CLAIM
    {
           public DP_CLAIM(){


           }
           /// <summary>
           /// Desc:本次结算的唯一标识，一次住院可能会多次结算
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
           public string CLM_TRANS_TYPE_CODE {get;set;}

           /// <summary>
           /// Desc:收费类别代码（取自源系统）	   城镇职工、城镇居民、新型农村合作医疗、贫困救助、商业医疗保险、全公费、全自费 等的编码
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string CHARGE_TYPE_CODE {get;set;}

           /// <summary>
           /// Desc:收费类别名称（取自源系统）	   城镇职工、城镇居民、新型农村合作医疗、贫困救助、商业医疗保险、全公费、全自费 等
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string CHARGE_TYPE_NAME {get;set;}

           /// <summary>
           /// Desc:进行业务结算（收费）的时间 yyyy-mm-dd hh24:mi:ss
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? CLM_DATE {get;set;}

           /// <summary>
           /// Desc:患者在院期间总共花费的费用
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? TOT_AMT {get;set;}

           /// <summary>
           /// Desc:所有在医保范围内的项目的总金额
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? MI_SCOPE {get;set;}

           /// <summary>
           /// Desc:医保范围内的项目，需要个人自付的金额
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? SELF_PAY {get;set;}

           /// <summary>
           /// Desc:本次医保结算时所对应的基本医疗保险的起付线，根据不同地区不同级别的医院会有不同
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? DEDUC {get;set;}

           /// <summary>
           /// Desc:本次医保结算时超出基本医疗保险封顶线的金额
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? OVER_AMT {get;set;}

           /// <summary>
           /// Desc:在治疗期间的总自费金额
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? OUT_POCK {get;set;}

           /// <summary>
           /// Desc:医保报销了的金额
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? MI_PAY {get;set;}

           /// <summary>
           /// Desc:患者实际应该支付的金额=总金额-医保支付金额-医保个账支付金额
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? ACT_SELF_PAY {get;set;}

           /// <summary>
           /// Desc:医保个人账户支付的金额
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? P_ACCT_PAY {get;set;}

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
