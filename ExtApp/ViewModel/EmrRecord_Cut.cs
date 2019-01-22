using System;
using System.Linq;
using System.Text;

namespace Models
{
    ///<summary>
    ///
    ///</summary>
    public partial class EmrRecord_Cut
    {
           public EmrRecord_Cut(){
            
           }
          

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string PATIENTNO {get;set;}
        
         
           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:True
           /// </summary>           
           public string SEGMENTCODE {get;set;}

           public string cut { get; set; }
    }
}
