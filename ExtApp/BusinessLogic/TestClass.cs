using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HJ.Common.Funcs;
using System.Text.RegularExpressions;
using SqlSugar;
using Models;
using HJ.Common.Trans;

namespace ExtApp.BusinessLogic
{
    /// <summary>
    /// 测试类
    /// </summary>
    public class TestClass : DataBase
    {
        public void Run()
        {
            GetEntity();
            run();
        }
        /// <summary>
        /// 生成实体类 
        /// </summary>
        public void GetEntity()
        {
            db.DbFirst.CreateClassFile(@"F:\项目文件\医院项目\Model");
        }
        public void cut()
        {
            
        }

        public void datebase()
        {
            string vv = Regex.Match("sdfsda防止adsfas抗ddsfgfsadf感染sadfasd", "(抗|控制|院内|防治).*?感染(?!性)").Value;
            string ss = @"ＡＰＡＣＨＥII评分47分。AUTARDVT评分7分。辅助检查：";
            string sss = Regex.Match("dsfas34mladfa", @"\d+(?=ml)", RegexOptions.IgnoreCase).Value;
            string s= ss.UseCHS().ToDBC();
            List<DbColumnInfo> columnInfo = new List<DbColumnInfo>() {
                new DbColumnInfo { DbColumnName = "one", DataType = "varchar(MAX)" },
                new DbColumnInfo { DbColumnName = "two", DataType = "varchar" }
            };

            var dt = CreateDataTable("1,2,3,4,5,6,7,8","name");
            var dt2 = CreateDataTable(5, "name1");

            var DBM = dbBD.DbMaintenance;
            bool b = DBM.IsAnyTable("ceshi3");
            DBM.CreateTable("ceshi2", columnInfo);

        }
        public void run()
        {
            
            
        }


    }
}
