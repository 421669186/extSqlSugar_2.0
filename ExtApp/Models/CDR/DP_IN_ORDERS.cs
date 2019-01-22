using System;
using System.Linq;
using System.Text;

namespace Models
{
    ///<summary>
    ///DP医生住院医嘱
    ///</summary>
    public partial class DP_IN_ORDERS
    {
           public DP_IN_ORDERS(){


           }
         public string HOSPITAL_TIME { get; set; }

           /// <summary>
           /// Desc:医嘱表的主键
           /// Default:
           /// Nullable:False
           /// </summary>           
        public string MO_ORDER_NO {get;set;}

           /// <summary>
           /// Desc:患者唯一标识
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string PATIENT_ID {get;set;}

           /// <summary>
           /// Desc:本次住院唯一标识
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string PATIENT_NO {get;set;}

           /// <summary>
           /// Desc:与检查、检验、手术关联
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string APPLY_NO {get;set;}

           /// <summary>
           /// Desc:医师下达医嘱的时间 yyyy-mm-dd hh24:mi:ss
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? MO_DATE {get;set;}

           /// <summary>
           /// Desc:医师要求医嘱开始执行的时间 yyyy-mm-dd hh24:mi:ss
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? DATE_BEGIN {get;set;}

           /// <summary>
           /// Desc:医师要求停止医嘱的时间 yyyy-mm-dd hh24:mi:ss
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? DATE_END {get;set;}

           /// <summary>
           /// Desc:1:药品;  2:检验;  3:检查;  4:手术;  9:其他;  
           /// Default:
           /// Nullable:True
           /// </summary>           
           public int? ORDER_TYPE_CODE {get;set;}

           /// <summary>
           /// Desc:1:西药;  2:抗感染药特殊;  3:抗感染药限制;  4:抗感染药非限制;  5:中成药;  6:中草药;  7:检查;  8:检验;  9:病理;  10:手术;  11:麻醉;  12:输血;  13:输氧;  16:护理;  17:营养膳食;  19:嘱托;  20:床位;  21:处置/治疗;  30:材料;  38:特殊药品;  
           /// Default:
           /// Nullable:True
           /// </summary>           
           public int? ORDER_ITEM_TYPE_CODE {get;set;}

           /// <summary>
           /// Desc:医嘱项目编码
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string ORDER_ITEM_CODE {get;set;}

           /// <summary>
           /// Desc:具体的医嘱项目
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string ORDER_ITEM_NAME {get;set;}

           /// <summary>
           /// Desc:1:长期;  0:临时;  
           /// Default:
           /// Nullable:True
           /// </summary>           
           public int? LONG_FLAG {get;set;}

           /// <summary>
           /// Desc:1:出院带药;  0:其他;  
           /// Default:
           /// Nullable:True
           /// </summary>           
           public int? OUT_DRUG_FLAG {get;set;}

           /// <summary>
           /// Desc:开立科室代码
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string DEPT_CODE {get;set;}

           /// <summary>
           /// Desc:开立医嘱的医师所在的科室
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string DEPT_NAME {get;set;}

           /// <summary>
           /// Desc:开立医嘱的医师
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string DOCTOR_CODE {get;set;}

           /// <summary>
           /// Desc:开立医嘱的医师
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string DOCTOR_NAME {get;set;}

           /// <summary>
           /// Desc:下达停止医嘱的医师
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string STOP_DOCTOR_NAME {get;set;}

           /// <summary>
           /// Desc:商品名称
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string ITEM_GOODS_NAME {get;set;}

           /// <summary>
           /// Desc:给药途径代码
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string GYTJ_CODE {get;set;}

           /// <summary>
           /// Desc:给药途径名称	   口服、肌肉注射等
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string GYTJ_NAME {get;set;}

           /// <summary>
           /// Desc:用法代码
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string USAGE_CODE {get;set;}

           /// <summary>
           /// Desc:用法名称   （给药途径的备注，包括餐前、餐后、空腹、领药、带药、发药、出院带药）
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string USAGE_NAME {get;set;}

           /// <summary>
           /// Desc:频次代码
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string FREQ_CODE {get;set;}

           /// <summary>
           /// Desc:多长时间一次
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string FREQ_NAME {get;set;}

           /// <summary>
           /// Desc:每次执行的用量
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? DOSE_ONCE {get;set;}

           /// <summary>
           /// Desc:每次剂量单位
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string DOSE_UNIT {get;set;}

           /// <summary>
           /// Desc:每天的总用量
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? QTY_TOT {get;set;}

           /// <summary>
           /// Desc:项目总量单位
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string QTY_TOT_UNIT {get;set;}

           /// <summary>
           /// Desc:用药天数
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string USE_DAYS {get;set;}

           /// <summary>
           /// Desc:中药剂数
           /// Default:
           /// Nullable:True
           /// </summary>           
           public int? CHN_MEDI_QTY {get;set;}

           /// <summary>
           /// Desc:1:经验性用药;  2:目标性用药;  3:预防性用药;  9:其他;  
           /// Default:
           /// Nullable:True
           /// </summary>           
           public int? USE_INTENDED_CODE {get;set;}

           /// <summary>
           /// Desc:执行科室代码
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string EXEC_DEPT_CODE {get;set;}

           /// <summary>
           /// Desc:实际执行医嘱的科室
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string EXEC_DEPT_NAME {get;set;}

           /// <summary>
           /// Desc:校对医嘱的护士
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string EXEC_PERSON {get;set;}

           /// <summary>
           /// Desc:校对医嘱的时间（护士站的转抄时间） yyyy-mm-dd hh24:mi:ss
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? EXEC_DATE {get;set;}

           /// <summary>
           /// Desc:医嘱(处方)状态的编码，与院方数据保持一致，如待执行、已领药、已审核等等
           /// Default:
           /// Nullable:True
           /// </summary>           
           public int? ORIG_ORDER_STATUS {get;set;}

           /// <summary>
           /// Desc:医师在开立医嘱时写在"备注"中的内容
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string DOC_REMARK {get;set;}

           /// <summary>
           /// Desc:记录抽取时间，不需院方提供
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? UPD_DATE {get;set;}

    }
}
