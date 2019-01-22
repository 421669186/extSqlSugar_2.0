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
        bool InsertDataToDb(DataTable dt,string strHospitalCode);
    }
}
