using System;
using System.Linq;
using System.Text;

namespace Models
{
    ///<summary>
    ///包含门诊开出的所有单据、处方、检查检验申请等
    ///</summary>
    public partial class DP_OUT_RECIPE
    {
        public DP_OUT_RECIPE()
        {


        }
        public string IN_PATIENT_NO { get; set; }
        public string HOSPITAL_TIME { get; set; }
        /// <summary>
        /// Desc:主键，可以是业务数据主键或者GUID
        /// Default:
        /// Nullable:False
        /// </summary>           
        public string RECIPE_ID { get; set; }

        /// <summary>
        /// Desc:患者唯一标识
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string PATIENT_ID { get; set; }

        /// <summary>
        /// Desc:本次就诊唯一标识
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string PATIENT_NO { get; set; }

        /// <summary>
        /// Desc:医嘱流水号
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string RECIPE_NO { get; set; }

        /// <summary>
        /// Desc:与检查、检验、手术关联
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string APPLY_NO { get; set; }

        /// <summary>
        /// Desc:医师下达医嘱的时间 yyyy-mm-dd hh24:mi:ss
        /// Default:
        /// Nullable:True
        /// </summary>           
        public DateTime? RECIPE_DATE { get; set; }

        /// <summary>
        /// Desc:1:药品;  2:检验;  3:检查;  4:手术;  9:其他;  
        /// Default:
        /// Nullable:True
        /// </summary>           
        public int? RECIPE_TYPE_CODE { get; set; }

        /// <summary>
        /// Desc:1:西药;  2:抗感染药特殊;  3:抗感染药限制;  4:抗感染药非限制;  5:中成药;  6:中草药;  7:检查;  8:检验;  9:病理;  10:手术;  11:麻醉;  12:输血;  13:输氧;  16:护理;  17:营养膳食;  19:嘱托;  20:床位;  21:处置/治疗;  30:材料;  38:特殊药品;  
        /// Default:
        /// Nullable:True
        /// </summary>           
        public int? ORDER_ITEM_TYPE_CODE { get; set; }

        /// <summary>
        /// Desc:项目编码
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string ITEM_CODE { get; set; }

        /// <summary>
        /// Desc:医嘱内容
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string ITEM_NAME { get; set; }

        /// <summary>
        /// Desc:开单科室代码
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string DEPT_CODE { get; set; }

        /// <summary>
        /// Desc:开单医师所在的科室
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string DEPT_NAME { get; set; }

        /// <summary>
        /// Desc:开方医师编码
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string DOCTOR_CODE { get; set; }

        /// <summary>
        /// Desc:开方医师姓名
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string DOCTOR_NAME { get; set; }

        /// <summary>
        /// Desc:商品名称
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string ITEM_GOODS_NAME { get; set; }

        /// <summary>
        /// Desc:给药途径编码
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string GYTJ_CODE { get; set; }

        /// <summary>
        /// Desc:给药途径名称	   口服、肌肉注射等
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string GYTJ_NAME { get; set; }

        /// <summary>
        /// Desc:用法代码
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string USAGE_CODE { get; set; }

        /// <summary>
        /// Desc:用法名称	   餐前、餐后、空腹等
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string USAGE_NAME { get; set; }

        /// <summary>
        /// Desc:频次代码
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string FREQ_CODE { get; set; }

        /// <summary>
        /// Desc:多长时间一次
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string FREQ_NAME { get; set; }

        /// <summary>
        /// Desc:每次执行的用量
        /// Default:
        /// Nullable:True
        /// </summary>           
        public decimal? DOSE_ONCE { get; set; }

        /// <summary>
        /// Desc:每次剂量单位
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string DOSE_UNIT { get; set; }

        /// <summary>
        /// Desc:	   
        /// Default:
        /// Nullable:True
        /// </summary>           
        public decimal? QTY_TOT { get; set; }

        /// <summary>
        /// Desc:总数量单位
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string QTY_TOT_UNIT { get; set; }

        /// <summary>
        /// Desc:用药天数
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string USE_DAYS { get; set; }

        /// <summary>
        /// Desc:执行科室代码
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string EXEC_DEPT_CODE { get; set; }

        /// <summary>
        /// Desc:实际执行医嘱的科室
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string EXEC_DEPT_NAME { get; set; }

        /// <summary>
        /// Desc:yyyy-mm-dd hh24:mi:ss
        /// Default:
        /// Nullable:True
        /// </summary>           
        public DateTime? EXEC_DATE { get; set; }

        /// <summary>
        /// Desc:医嘱(处方)状态的编码，与院方数据保持一致，如待执行、已领药、已审核等等
        /// Default:
        /// Nullable:True
        /// </summary>           
        public int? ORIG_ORDER_STATUS { get; set; }

        /// <summary>
        /// Desc:医师在开立医嘱时写在"备注"中的内容
        /// Default:
        /// Nullable:True
        /// </summary>           
        public string DOC_REMARK { get; set; }

        /// <summary>
        /// Desc:记录抽取时间，不需院方提供
        /// Default:
        /// Nullable:True
        /// </summary>           
        public DateTime? UPD_DATE { get; set; }

    }
}
