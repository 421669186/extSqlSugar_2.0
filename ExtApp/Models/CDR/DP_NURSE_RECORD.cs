using System;
using System.Linq;
using System.Text;

namespace Models
{
    ///<summary>
    ///DP护理记录
    ///</summary>
    public partial class DP_NURSE_RECORD
    {
           public DP_NURSE_RECORD(){


           }
           /// <summary>
           /// Desc:主键，可以是业务数据主键或者GUID
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string NUR_REC_ID {get;set;}

           /// <summary>
           /// Desc:本次住院唯一标识
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string PATIENT_NO {get;set;}

           /// <summary>
           /// Desc:患者唯一标识
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string PATIENT_ID {get;set;}

           /// <summary>
           /// Desc:1:基础护理;  2:特殊护理;  3:辩证施护;  9:其他;  
           /// Default:
           /// Nullable:True
           /// </summary>           
           public int? NURSE_TYPE_CODE {get;set;}

           /// <summary>
           /// Desc:1:体重（kg）;  2:体温(℃);  3:呼吸频率（次/min）;  4:脉率（次/min）;  5:收缩压（mmHg）;  6:舒张压（mmHg）;  7:血氧饱和度（%）;  8:血糖检测值（mmol/L）;  9:简要病情;  10:输液量;  11:小便量;  12:大便量;  
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string NURSE_ITEM_CODE {get;set;}

           /// <summary>
           /// Desc:项目值
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string ITEM_VALUES {get;set;}

           /// <summary>
           /// Desc:进行相关护理的时间 yyyy-mm-dd hh24:mi:ss
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? REC_DATE {get;set;}

           /// <summary>
           /// Desc:记录抽取时间，不需院方提供
           /// Default:
           /// Nullable:True
           /// </summary>           
           public DateTime? UPD_DATE {get;set;}

    }
}
