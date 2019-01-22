using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace ExtApp
{
    public class Config
    {
        public static string ConnectionString = ConfigurationManager.AppSettings["ConnectionString"];

        public static string ConnectionStringUT = ConfigurationManager.AppSettings["ConnectionStringUT"];

        public static string ConnectionStringBD = ConfigurationManager.AppSettings["ConnectionStringBD"];
    }
}
