using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
/**
 * Checkrecord 实体类
 * 2016/10/28 9:33:41  Hua Ju
 */


namespace Model
{
    /// <summary>
    ///
    /// <summary>

    public class Checkrecord
    {
        public string ClinicCode { get; set; }
        public string Patientid { get; set; }
        public string Patientno { get; set; }
        public string Caseno { get; set; }
        public string InTimes { get; set; }
        public string Name { get; set; }
        public string Sex { get; set; }
        public string Age { get; set; }
        public DateTime Birthdate { get; set; }
        public string Bedno { get; set; }
        public string Systemcode { get; set; }
        public string PatientResource { get; set; }
        public string ApplyNo { get; set; }
        public string ApplyDeptcode { get; set; }
        public string ApplyDeptname { get; set; }
        public string Execute_Dept_Code { get; set; }
        public string Execute_Dept_Name { get; set; }
        public DateTime ApplyTime { get; set; }
        public string Check_Type { get; set; }
        public string Check_Body_Name { get; set; }
        public string Check_Result_Type { get; set; }
        public string Check_Item_Code { get; set; }
        public string Check_Item_Name { get; set; }
        public DateTime Checkdate { get; set; }
        public string Report_Objective { get; set; }
        public string Report_Subjective { get; set; }
        public DateTime Receivedatetime { get; set; }
        public DateTime Resultdatetime { get; set; }
        public DateTime Reportdatetime { get; set; }
        public string Resultvalue { get; set; }
        public string Report_Result { get; set; }
        public string Reportdoctor { get; set; }
    }
}
