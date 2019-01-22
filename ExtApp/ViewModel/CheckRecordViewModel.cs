using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class CheckRecordViewModel
    {
        //public string Patientno { get; set; }
        //public string ApplyNo { get; set; }
        //public DateTime Checkdate { get; set; }
        //public string Checkitemname { get; set; }
        //public string cutKeGuan { get; set; }

        public string EXECUTEDEPTCODE { get; set; }
        public string EXECUTEDEPTNAME { get; set; }
        public string CHECKTYPE { get; set; }
        public string CHECKBODYNAME { get; set; }
        public string CHECKRESULTTYPE { get; set; }
        public string CHECKITEMCODE { get; set; }
        public string CHECKITEMNAME { get; set; }

        public string Reportresultkeguan { get; set; }
        public string Reportresultzhuguan { get; set; }
        public string Reportresult { get; set; }
        public string CUT { get; set; }
    }
}
