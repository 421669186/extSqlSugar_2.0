using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using HJ.Common.Trans;
using Oracle.ManagedDataAccess.Client;
using System.Collections;

namespace HJ.Common.Datas.Oracle
{
    public class OracleMSSQL:IDisposable
    {
        private OracleConnection con = null;
        private string connection = string.Empty;

        public OracleMSSQL(string strConnection)
        {
            this.connection = strConnection;
        }

        private OracleConnection _con
        {
            get
            {
                if (con == null)
                {
                    con = new OracleConnection(connection);
                    con.Open();
                }
                else if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                else if (con.State == ConnectionState.Broken)
                {
                    con.Close();
                    con.Open();
                }
                return con;
            }
        }

        /// <summary>
        /// 第一行第一列的值
        /// </summary>
        public string ExecuteScalar(string sql)
        {
            OracleCommand cmm = new OracleCommand(sql, _con);
            return cmm.ExecuteScalar().ToString();
        }

        /// <summary>
        /// 第一行第一列的值
        /// </summary>
        public string ExecuteScalar(string sql, OracleParameter[] sp)
        {
            OracleCommand cmm = new OracleCommand(sql, _con);
            cmm.Parameters.AddRange(sp);
            return cmm.ExecuteScalar().ToString();
        }

        /// <summary>
        /// 第一行第一列的值
        /// </summary>
        public string ExecuteScalar(string proname, OracleParameter[] sp, CommandType t)
        {
            OracleCommand cmm = new OracleCommand(proname, _con);
            cmm.CommandType = t;
            cmm.Parameters.AddRange(sp);
            return cmm.ExecuteScalar().ToString();
        }

        /// <summary>
        /// 数据表
        /// </summary>
        public DataTable ExecuteDataTable(string sql)
        {
            OracleCommand cmm = new OracleCommand(sql, _con);
            OracleDataAdapter sdp = new OracleDataAdapter(cmm);
            DataTable dt = new DataTable();
            sdp.Fill(dt);
            return dt;
        }

        /// <summary>
        /// 数据表
        /// </summary>
        public DataTable ExecuteDataTable(string sql, OracleParameter[] sp)
        {
            OracleCommand cmm = new OracleCommand(sql, _con);
            cmm.Parameters.AddRange(sp);
            OracleDataAdapter sdp = new OracleDataAdapter(cmm);
            DataTable dt = new DataTable();
            sdp.Fill(dt);
            return dt;
        }

        /// <summary>
        /// 数据表
        /// </summary>
        public DataTable ExecuteDataTable(string proname, OracleParameter[] sp, CommandType t)
        {
            OracleCommand cmm = new OracleCommand(proname, _con);
            cmm.CommandType = t;
            cmm.Parameters.AddRange(sp);
            OracleDataAdapter sdp = new OracleDataAdapter(cmm);
            DataTable dt = new DataTable();
            sdp.Fill(dt);
            return dt;
        }

        /// <summary>
        /// 执行结果
        /// </summary>
        public int ExecuteCommand(string sql)
        {
            int numrow = 0;
            OracleCommand cmm = new OracleCommand(sql, _con);
            OracleTransaction tran = _con.BeginTransaction();
            cmm.Transaction = tran;
            try
            {
                numrow = cmm.ExecuteNonQuery();
                tran.Commit();
            }
            catch (Exception e)
            {
                tran.Rollback();
                throw (e);
            }
            return numrow;
        }

        /// <summary>
        /// 执行结果
        /// </summary>
        public int ExecuteCommand(string sql, OracleParameter[] sp)
        {
            int numrow = 0;
            OracleCommand cmm = new OracleCommand(sql, _con);
            OracleTransaction tran = _con.BeginTransaction();
            cmm.Transaction = tran;
            cmm.Parameters.AddRange(sp);
            try
            {
                numrow = cmm.ExecuteNonQuery();
                tran.Commit();
            }
            catch (Exception e)
            {
                tran.Rollback();
                throw (e);
            }
            return numrow;
        }

        /// <summary>
        /// 执行结果
        /// </summary>
        public int ExecuteCommand(string proname, OracleParameter[] sp, CommandType t)
        {
            int numrow = 0;
            OracleCommand cmm = new OracleCommand(proname, _con);
            OracleTransaction tran = _con.BeginTransaction();
            cmm.CommandType = t;
            cmm.Transaction = tran;
            cmm.Parameters.AddRange(sp);
            try
            {
                numrow = cmm.ExecuteNonQuery();
                tran.Commit();
            }
            catch (Exception e)
            {
                tran.Rollback();
                throw (e);
            }
            return numrow;
        }

        ///// <summary>
        ///// 批量插入
        ///// </summary>
        //public void BatchExecuteCommand(string tablename, DataTable table)
        //{
        //    using (SqlBulkCopy sbc = new SqlBulkCopy(connection))
        //    {
        //        sbc.DestinationTableName = tablename;
        //        for (int i = 0; i < table.Columns.Count; i++)
        //        {
        //            sbc.ColumnMappings.Add(table.Columns[i].ColumnName, table.Columns[i].ColumnName);
        //        }
        //        sbc.WriteToServer(table);
        //    }
        //}

        /// <summary>
        /// 执行结果
        /// 不带事务
        /// </summary>
        public int ExecuteCommandNoTran(string proname, OracleParameter[] sp, CommandType t)
        {
            int numrow = 0;
            OracleCommand cmm = new OracleCommand(proname, _con);
            cmm.CommandTimeout = 0;
            cmm.CommandType = t;
            cmm.Parameters.AddRange(sp);
            try
            {
                numrow = cmm.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw (e);
            }
            return numrow;
        }

        /// <summary>
        /// 批量插入
        /// </summary>
        public void ExecuteCommand(string tablename, DataTable table)
        {
            table.TableName = tablename;
            foreach (DataRow dr in table.Rows)
            {
                Insert(tablename, rHash(dr));
            }
            //OracleDataAdapter sdp = new OracleDataAdapter();
            //sdp.Update(table);
            
            //using (SqlBulkCopy sbc = new SqlBulkCopy(connection))
            //{
            //    sbc.DestinationTableName = tablename;
            //    sbc.WriteToServer(table);
            //}
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        public DataTable ExecuteDataTable(string sql, int curpage, int pagesize)
        {
            OracleCommand cmm = new OracleCommand(sql, _con);
            OracleDataAdapter sdp = new OracleDataAdapter(cmm);
            DataTable dt = new DataTable();
            sdp.Fill((curpage - 1) * pagesize, pagesize, dt);
            return dt;
        }

        /// <summary>
        /// 并行执行查询...
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        public DataTable ParallelExecuteDataTable<T>(string sql, List<T> where)
        {
            DataTable tables = new DataTable();
            if (null == where && 0 == where.Count)
            {
                throw new ArgumentOutOfRangeException("A conditional bucket is an empty reference or a number of zero");
            }

            if (100 > where.Count)
            {
                string sqlBody = string.Format("{0} {1}", sql, where.TryToWhere());
                return ExecuteDataTable(sqlBody);
            }

            else
            {
                var batchValue = where.TryToBatchValue();
                Parallel.ForEach(batchValue, values => {
                    string sqlBody = string.Format("{0} {1}", sql, values);
                    DataTable table = ExecuteDataTable(sqlBody);
                    tables.Merge(table, true);
                });
            }
            return tables;
        }

        /// <summary>
        /// 释放连接对象
        /// </summary>
        public void Dispose()
        {
            if (_con != null)
            {
                _con.Close();
                _con.Dispose();
            }
            GC.Collect();
        }


        private static Hashtable rHash(DataRow dr)
        {
            Hashtable hash = new Hashtable();
            for (int i = 0; i < dr.Table.Columns.Count; i++)
            {
                hash.Add(dr.Table.Columns[i].ColumnName, dr[i].ToString());
            }
            return hash;
        }

        private int Insert(string TableName, Hashtable ht)
        {
            OracleParameter[] Parms = new OracleParameter[ht.Count];
            IDictionaryEnumerator et = ht.GetEnumerator();
            DataTable dt = GetTabType(TableName);
            OracleDbType otype;
            int size = 0;
            int i = 0;
            while (et.MoveNext()) // 作哈希表循环
            {
                GetoType(et.Key.ToString().ToUpper(), dt, out otype, out size);
                OracleParameter op = MakeParam(":" + et.Key.ToString(), otype, size, et.Value.ToString());
                Parms[i] = op; // 添加SqlParameter对象
                i = i + 1;
            }
            string str_Sql = GetInsertSqlbyHt(TableName, ht); // 获得插入sql语句
            int val = ExecuteCommand(str_Sql, Parms);
            return val;
        }

        /// 根据哈稀表及表名自动生成相应insert语句 
        /// 要插入的表名
        /// 哈稀表
        /// 返回sql语句
        private static string GetInsertSqlbyHt(string TableName, Hashtable ht)
        {
            string str_Sql = "";
            int i = 0;
            int ht_Count = ht.Count; // 哈希表个数
            IDictionaryEnumerator myEnumerator = ht.GetEnumerator();
            string before = "";
            string behide = "";
            while (myEnumerator.MoveNext())
            {
                if (i == 0)
                {
                    before = "(" + myEnumerator.Key;
                }
                else if (i + 1 == ht_Count)
                {
                    before = before + "," + myEnumerator.Key + ")";
                }
                else
                {
                    before = before + "," + myEnumerator.Key;
                }
                i = i + 1;
            }
            behide = " Values" + before.Replace(",", ",:").Replace("(", "(:");
            str_Sql = "Insert into " + TableName + before + behide;
            return str_Sql;
        }

        /// 
        /// 生成oracle参数
        /// 字段名
        /// 数据类型
        /// 数据大小
        /// 值
        private static OracleParameter MakeParam(string ParamName, OracleDbType otype, int size, Object Value)
        {
            OracleParameter para = new OracleParameter(ParamName, Value);
            para.OracleDbType = otype;
            para.Size = size;
            return para;
        }

        private static void GetoType(string key, DataTable dt, out OracleDbType otype, out int size)
        {
            DataView dv = dt.DefaultView;
            dv.RowFilter = "column_name='" + key + "'";
            string fType = dv[0]["data_type"].ToString().ToUpper();
            switch (fType)
            {
                case "DATE":
                    otype = OracleDbType.Date;
                    size = int.Parse(dv[0]["data_length"].ToString());
                    break;
                case "CHAR":
                    otype = OracleDbType.Char;
                    size = int.Parse(dv[0]["data_length"].ToString());
                    break;
                case "LONG":
                    otype = OracleDbType.Double;
                    size = int.Parse(dv[0]["data_length"].ToString());
                    break;
                case "NVARCHAR2":
                    otype = OracleDbType.Char;
                    size = int.Parse(dv[0]["data_length"].ToString());
                    break;
                case "VARCHAR2":
                    otype = OracleDbType.Char;
                    size = int.Parse(dv[0]["data_length"].ToString());
                    break;
                default:
                    otype = OracleDbType.Char;
                    size = 100;
                    break;
            }
        }

        private System.Data.DataTable GetTabType(string tabnale)
        {
            string sql = "select column_name,data_type,data_length from all_tab_columns where table_name='" + tabnale.ToUpper() + "'";
            return (ReturnDataSet(sql, "dv")).Tables[0];
        }

        /// 执行SQL语句，返回数据到DataSet中
        /// sql语句
        /// 自定义返回的DataSet表名
        /// 返回DataSet
        private DataSet ReturnDataSet(string sql, string DataSetName)
        {
            DataSet dataSet = new DataSet();
            OracleDataAdapter OraDA = new OracleDataAdapter(sql, _con);
            OraDA.Fill(dataSet, DataSetName);
            return dataSet;
        }
    }
}
