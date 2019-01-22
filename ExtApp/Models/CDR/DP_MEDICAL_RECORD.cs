using System;
using System.Linq;
using System.Text;

namespace Models
{
    ///<summary>
    ///DP病案首页
    ///</summary>
    public partial class DP_MEDICAL_RECORD
    {
           public DP_MEDICAL_RECORD(){


           }
           /// <summary>
           /// Desc:本次住院唯一标识
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string PATIENT_NO {get;set;}

           /// <summary>
           /// Desc:患者唯一标识
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string PATIENT_ID {get;set;}

           /// <summary>
           /// Desc:本院就诊卡号;  社保卡号
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string CARD_NO {get;set;}

           /// <summary>
           /// Desc:在本院第几次住院
           /// Default:
           /// Nullable:True
           /// </summary>           
           public int? IN_TIMES {get;set;}

           /// <summary>
           /// Desc:医疗付款方式
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string PAY_WAY {get;set;}

           /// <summary>
           /// Desc:住院病案号
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string CASE_NO {get;set;}

           /// <summary>
           /// Desc:患者姓名
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string PATIENT_NAME {get;set;}

           /// <summary>
           /// Desc:身份证号
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string ID_NO {get;set;}

           /// <summary>
           /// Desc:1:男;  2:女;  9:未知;  
           /// Default:
           /// Nullable:True
           /// </summary>           
           public int? GENDER_CODE {get;set;}

           /// <summary>
           /// Desc:yyyy-mm-dd
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? BIRTH_DATE {get;set;}

           /// <summary>
           /// Desc:年龄
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string AGE {get;set;}

           /// <summary>
           /// Desc:婴儿年龄(月)
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string AGE_BABY_MON {get;set;}

           /// <summary>
           /// Desc:1:已婚;  2:未婚;  3:离婚;  4:丧偶;  9:其他;  
           /// Default:
           /// Nullable:True
           /// </summary>           
           public int? MARI_STAT_CODE {get;set;}

           /// <summary>
           /// Desc:职业
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string OCCUPATION {get;set;}

           /// <summary>
           /// Desc:出生省份
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string PROVINCE {get;set;}

           /// <summary>
           /// Desc:出生地市
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string CITY {get;set;}

           /// <summary>
           /// Desc:出生地县
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string COUNTY {get;set;}

           /// <summary>
           /// Desc:民族名称
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string NATION_NAME {get;set;}

           /// <summary>
           /// Desc:国籍
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string NATIONALITY {get;set;}

           /// <summary>
           /// Desc:yyyy-mm-dd hh24:mi:ss
           /// Default:
           /// Nullable:False
           /// </summary>           
           public DateTime IN_DATE {get;set;}

           /// <summary>
           /// Desc:入院病区名称
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string IN_AREA_NAME {get;set;}

           /// <summary>
           /// Desc:入院科室编码
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string IN_DEPT_CODE {get;set;}

           /// <summary>
           /// Desc:入院科室名称
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string IN_DEPT_NAME {get;set;}

           /// <summary>
           /// Desc:转科科室编码
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string TRANSFER_DEPT_CODE {get;set;}

           /// <summary>
           /// Desc:转科科室名称
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string TRANSFER_DEPT_NAME {get;set;}

           /// <summary>
           /// Desc:yyyy-mm-dd hh24:mi:ss
           /// Default:
           /// Nullable:False
           /// </summary>           
           public DateTime OUT_DATE {get;set;}

           /// <summary>
           /// Desc:出院病区名称
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string OUT_AREA_NAME {get;set;}

           /// <summary>
           /// Desc:出院科室编码
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string OUT_DEPT_CODE {get;set;}

           /// <summary>
           /// Desc:出院科室名称
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string OUT_DEPT_NAME {get;set;}

           /// <summary>
           /// Desc:实际住院天数
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string ACTUAL_IN_DAYS {get;set;}

           /// <summary>
           /// Desc:1:门诊;  2:急诊;  3:转科;  4:转院;  9:其他;  
           /// Default:
           /// Nullable:True
           /// </summary>           
           public int? IN_SOURCE_CODE {get;set;}

           /// <summary>
           /// Desc:门（急）诊诊断编码
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string OUTPAT_DIAG_CODE {get;set;}

           /// <summary>
           /// Desc:门（急）诊诊断名称
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string OUTPAT_DIAG_NAME {get;set;}

           /// <summary>
           /// Desc:入院诊断编码
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string IN_DIAG_CODE {get;set;}

           /// <summary>
           /// Desc:入院诊断名称
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string IN_DIAG_NAME {get;set;}

           /// <summary>
           /// Desc:yyyy-mm-dd 
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? IN_DIAG_DATE {get;set;}

           /// <summary>
           /// Desc:主要诊断编码
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string MAIN_DIAG_CODE {get;set;}

           /// <summary>
           /// Desc:主要诊断疾病描述
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string MAIN_DIAG_DESC {get;set;}

           /// <summary>
           /// Desc:主要诊断入院病情
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string MAIN_DIAG_IN_CONDITION {get;set;}

           /// <summary>
           /// Desc:主要诊断出院情况
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string MAIN_DIAG_OUT_CONDITION {get;set;}

           /// <summary>
           /// Desc:多个诊断使用双引号封闭，逗号分隔，如：“D65”,“D66”
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string OTHER_DIAG_CODE {get;set;}

           /// <summary>
           /// Desc:多个诊断使用双引号封闭，逗号分隔，如：“肺炎”,“腹膜炎”
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string OTHER_DIAG_NAME {get;set;}

           /// <summary>
           /// Desc:损伤中毒诊断编码
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string POISN_DIAG_CODE {get;set;}

           /// <summary>
           /// Desc:损伤中毒诊断名称
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string POISN_DIAG_NAME {get;set;}

           /// <summary>
           /// Desc:病理诊断编码
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string PATHOLOGY_DIAG_CODE {get;set;}

           /// <summary>
           /// Desc:病理诊断名称
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string PATHOLOGY_DIAG_NAME {get;set;}

           /// <summary>
           /// Desc:病理号
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string PATHOLOGY_NO {get;set;}

           /// <summary>
           /// Desc:病理诊断编码2
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string PATHOLOGY_DIAG_CODE2 {get;set;}

           /// <summary>
           /// Desc:病理诊断名称2
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string PATHOLOGY_DIAG_NAME2 {get;set;}

           /// <summary>
           /// Desc:病理号2
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string PATHOLOGY_NO2 {get;set;}

           /// <summary>
           /// Desc:病理诊断编码3
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string PATHOLOGY_DIAG_CODE3 {get;set;}

           /// <summary>
           /// Desc:病理诊断名称3
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string PATHOLOGY_DIAG_NAME3 {get;set;}

           /// <summary>
           /// Desc:病理号3
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string PATHOLOGY_NO3 {get;set;}

           /// <summary>
           /// Desc:过敏源
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string ALLERGY {get;set;}

           /// <summary>
           /// Desc:过敏药物名称
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string ALLERGY_DRUG_NAME {get;set;}

           /// <summary>
           /// Desc:抢救次数
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string RESCUE_TIMES {get;set;}

           /// <summary>
           /// Desc:抢救成功次数
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string RESCUE_SUCCESS_TIMES {get;set;}

           /// <summary>
           /// Desc:科主任姓名
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string DEPT_DIRECTOR_NAME {get;set;}

           /// <summary>
           /// Desc:主任医师姓名
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string DIRECTOR_NAME {get;set;}

           /// <summary>
           /// Desc:主治医师编码
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string ATTENDING_DOCTOR_CODE {get;set;}

           /// <summary>
           /// Desc:主治医师姓名
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string ATTENDING_DOCTOR_NAME {get;set;}

           /// <summary>
           /// Desc:住院医师姓名
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string IN_HOS_DOCTOR_NAME {get;set;}

           /// <summary>
           /// Desc:责任护士姓名
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string RESPONSIBLE_NURSE {get;set;}

           /// <summary>
           /// Desc:特级护理天数
           /// Default:
           /// Nullable:True
           /// </summary>           
           public int? SPECIAL_NURSING_DAYS {get;set;}

           /// <summary>
           /// Desc:一级护理天数
           /// Default:
           /// Nullable:True
           /// </summary>           
           public int? NURSING_DAYS_I {get;set;}

           /// <summary>
           /// Desc:二级护理天数
           /// Default:
           /// Nullable:True
           /// </summary>           
           public int? NURSING_DAYS_II {get;set;}

           /// <summary>
           /// Desc:三级护理天数
           /// Default:
           /// Nullable:True
           /// </summary>           
           public int? NURSING_DAYS_III {get;set;}

           /// <summary>
           /// Desc:重症监护室名称
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string ICU_NAME {get;set;}

           /// <summary>
           /// Desc:yyyy-mm-dd hh24:mi:ss
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? ICU_IN_DATE {get;set;}

           /// <summary>
           /// Desc:yyyy-mm-dd hh24:mi:ss
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? ICU_OUT_DATE {get;set;}

           /// <summary>
           /// Desc:重症监护室名称2
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string ICU_NAME2 {get;set;}

           /// <summary>
           /// Desc:yyyy-mm-dd hh24:mi:ss
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? ICU_IN_DATE2 {get;set;}

           /// <summary>
           /// Desc:yyyy-mm-dd hh24:mi:ss
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? ICU_OUT_DATE2 {get;set;}

           /// <summary>
           /// Desc:重症监护室名称3
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string ICU_NAME3 {get;set;}

           /// <summary>
           /// Desc:yyyy-mm-dd hh24:mi:ss
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? ICU_IN_DATE3 {get;set;}

           /// <summary>
           /// Desc:yyyy-mm-dd hh24:mi:ss
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? ICU_OUT_DATE3 {get;set;}

           /// <summary>
           /// Desc:1:A型;  2:B型;  3:O型;  4:AB型;  9:不详;  
           /// Default:
           /// Nullable:True
           /// </summary>           
           public int? ABO_BLOOD_CODE {get;set;}

           /// <summary>
           /// Desc:1:阴性;  2:阳性;  3:不详;  4:未查;  
           /// Default:
           /// Nullable:True
           /// </summary>           
           public int? RH_BLOOD_CODE {get;set;}

           /// <summary>
           /// Desc:输血反应
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string TRANSFUSION_REACTION {get;set;}

           /// <summary>
           /// Desc:红细胞
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string RED_BLOOD_DELL {get;set;}

           /// <summary>
           /// Desc:血小板
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string PLATELET {get;set;}

           /// <summary>
           /// Desc:血浆
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string PLASMA {get;set;}

           /// <summary>
           /// Desc:全血
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string WHOLE_BLOOD {get;set;}

           /// <summary>
           /// Desc:自体回收
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string SELF_BLOOD_RETURN {get;set;}

           /// <summary>
           /// Desc:新生儿入院体重
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string BABY_IN_WEIGHT {get;set;}

           /// <summary>
           /// Desc:新生儿出生体重
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string BABY_BIRTH_WEIGHT {get;set;}

           /// <summary>
           /// Desc:新生儿出生体重2
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string BABY_BIRTH_WEIGHT2 {get;set;}

           /// <summary>
           /// Desc:新生儿出生体重3
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string BABY_BIRTH_WEIGHT3 {get;set;}

           /// <summary>
           /// Desc:1:医嘱离院;  2:医嘱转院;  3:医嘱转社区卫生服务机构/乡镇卫生院;  4:非医嘱离院;  5:死亡;  9:其他;  
           /// Default:
           /// Nullable:True
           /// </summary>           
           public int? OUT_WAY_CODE {get;set;}

           /// <summary>
           /// Desc:住院总费用
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? TOTAL_FEE {get;set;}

           /// <summary>
           /// Desc:自付金额
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? OWN_TOTAL_FEE {get;set;}

           /// <summary>
           /// Desc:一般医疗服务费
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? SERVICE_FEE {get;set;}

           /// <summary>
           /// Desc:一般治疗操作费
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? ORDINARY_TREAT_FEE {get;set;}

           /// <summary>
           /// Desc:护理费
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? NURSING_FEE {get;set;}

           /// <summary>
           /// Desc:综合医疗服务类其他费
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? ZHYLFWLQT_FEE {get;set;}

           /// <summary>
           /// Desc:病理诊断费
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? PATHOLOGY_DIAG_FEE {get;set;}

           /// <summary>
           /// Desc:实验室诊断费
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? TEST_FEE {get;set;}

           /// <summary>
           /// Desc:影像学诊断费
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? CHECK_FEE {get;set;}

           /// <summary>
           /// Desc:临床诊断项目费
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? CLINICAL_DIAG_FEE {get;set;}

           /// <summary>
           /// Desc:非手术治疗项目费
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? TREAT_WITHOUT_OP_FEE {get;set;}

           /// <summary>
           /// Desc:临床物理治疗费
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? PHYSICS_TREAT_FEE {get;set;}

           /// <summary>
           /// Desc:手术治疗费
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? OP_TREAT_FEE {get;set;}

           /// <summary>
           /// Desc:麻醉费
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? ANESTHESIA_FEE {get;set;}

           /// <summary>
           /// Desc:手术费
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? OP_FEE {get;set;}

           /// <summary>
           /// Desc:康复费
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? RECOVERY_FEE {get;set;}

           /// <summary>
           /// Desc:中医治疗费
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? CN_MEDICINE_TREAT_FEE {get;set;}

           /// <summary>
           /// Desc:西药费
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? WEST_MEDICINE_FEE {get;set;}

           /// <summary>
           /// Desc:抗菌药物费用
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? ANTIBACTERIALS_FEE {get;set;}

           /// <summary>
           /// Desc:中成药费
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? CN_PATENT_MEDICINE_FEE {get;set;}

           /// <summary>
           /// Desc:中草药费
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? CN_HERBAL_MEDICINE_FEE {get;set;}

           /// <summary>
           /// Desc:血费
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? BLOOD_FEE {get;set;}

           /// <summary>
           /// Desc:白蛋白类制品费
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? BDBLZP_FEE {get;set;}

           /// <summary>
           /// Desc:球蛋白类制品费
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? QDBLZP_FEE {get;set;}

           /// <summary>
           /// Desc:凝血因子类制品费
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? NXYZLZP_FEE {get;set;}

           /// <summary>
           /// Desc:细胞因子类制品费
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? XBYZLZP_FEE {get;set;}

           /// <summary>
           /// Desc:检查用一次性医用材料费
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? CHECK_MATERIAL_FEE {get;set;}

           /// <summary>
           /// Desc:治疗用一次性医用材料费
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? TREAT_MATERIAL_FEE {get;set;}

           /// <summary>
           /// Desc:其他费
           /// Default:
           /// Nullable:True
           /// </summary>           
           public decimal? OTHER_FEE {get;set;}

           /// <summary>
           /// Desc:记录抽取时间，不需院方提供
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? UPD_DATE {get;set;}

    }
}
