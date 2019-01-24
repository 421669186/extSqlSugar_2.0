using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtApp
{
    interface IImplement
    {
        DataTable GetDataTable();
        List<DataTable> GetDataTableList();
        Tuple<bool, string> InsertDataToDb(DataTable dt, string strHospitalCode, string strDiseaseCode);
        List<DataTable> GetInitData();
    }
}
