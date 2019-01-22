using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExtApp
{
    public class DataBase
    {
        /// <summary>
        /// CDR库DB
        /// </summary>
        public static SqlSugarClient db = GetInstance();
        /// <summary>
        /// UT库DB
        /// </summary>
        public static SqlSugarClient dbUT = GetInstanceUT();
        /// <summary>
        /// 本地库DB
        /// </summary>
        public static SqlSugarClient dbBD = GetInstanceBD();

        #region CDR库连接
        /// <summary>
        /// CDR库连接
        /// </summary>
        /// <returns></returns>
        public static SqlSugarClient GetInstance()
        {
            SqlSugarClient db = new SqlSugarClient(new ConnectionConfig() { ConnectionString = Config.ConnectionString, DbType = DbType.SqlServer, IsAutoCloseConnection = true });
            db.Ado.IsEnableLogEvent = true;
            //db.Ado.LogEventStarting = (sql, pars) =>
            //{
            //    Console.WriteLine(sql + "\r\n" + db.Utilities.SerializeObject(pars));
            //    Console.WriteLine();
            //};
            return db;
        }
        #endregion
        #region UT库连接
        /// <summary>
        /// UT库连接
        /// </summary>
        /// <returns></returns>
        public static SqlSugarClient GetInstanceUT()
        {
            SqlSugarClient db = new SqlSugarClient(new ConnectionConfig() { ConnectionString = Config.ConnectionStringUT, DbType = DbType.SqlServer, IsAutoCloseConnection = true });
            db.Ado.IsEnableLogEvent = true;
            //db.Ado.LogEventStarting = (sql, pars) =>
            //{
            //    Console.WriteLine(sql + "\r\n" + db.Utilities.SerializeObject(pars));
            //    Console.WriteLine();
            //};
            return db;
        }
        #endregion
        #region 本地库连接
        /// <summary>
        /// UT库连接
        /// </summary>
        /// <returns></returns>
        public static SqlSugarClient GetInstanceBD()
        {
            SqlSugarClient db = new SqlSugarClient(new ConnectionConfig() { ConnectionString = Config.ConnectionStringBD, DbType = DbType.SqlServer, IsAutoCloseConnection = true });
            db.Ado.IsEnableLogEvent = true;
            //db.Ado.LogEventStarting = (sql, pars) =>
            //{
            //    Console.WriteLine(sql + "\r\n" + db.Utilities.SerializeObject(pars));
            //    Console.WriteLine();
            //};
            return db;
        }
        #endregion

        //1.将库里面所有表都生成实体类文件
        //db.DbFirst.CreateClassFile("c:\\Demo\\1");

        /// <summary>
        /// 根据列名创建DataTable
        /// </summary>
        /// <param name="column">c1,c2,c3....</param>
        /// <param name="tableName">表名可空</param>
        /// <returns></returns>
        public static System.Data.DataTable CreateDataTable(string column,string tableName="")
        {
            System.Data.DataTable dt = new System.Data.DataTable(tableName);
            List<string> lsColumn = column.Split(',').ToList();
            foreach (var item in lsColumn)
            {
                dt.Columns.Add(item);
            }

            return dt;
        }
        /// <summary>
        /// 创建指定列数的DataTable
        /// </summary>
        /// <param name="columnNum"></param>
        /// <param name="tableName"></param>
        /// <returns>列名默认Comumn1，2，3...</returns>
        public static System.Data.DataTable CreateDataTable(int columnNum, string tableName = "")
        {
            System.Data.DataTable dt = new System.Data.DataTable(tableName);

            for (int i = 0; i < columnNum; i++)
            {
                dt.Columns.Add();
            }

            return dt;
        }
    }
}
