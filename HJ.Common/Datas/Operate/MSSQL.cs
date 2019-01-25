using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using HJ.Common.Trans;
using System.Threading.Tasks;

namespace HJ.Common.Datas.Operate
{
    public class MSSQL : IDisposable
    {
        private SqlConnection con = null;
        private string connection = string.Empty;

        public MSSQL(string strConnection)
        {
            this.connection = strConnection;
        }

        private SqlConnection _con
        {
            get
            {
                if (con == null)
                {
                    con = new SqlConnection(connection);
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
            SqlCommand cmm = new SqlCommand(sql, _con);
            return cmm.ExecuteScalar().ToString();
        }

        /// <summary>
        /// 第一行第一列的值
        /// </summary>
        public string ExecuteScalar(string sql, SqlParameter[] sp)
        {
            SqlCommand cmm = new SqlCommand(sql, _con);
            cmm.Parameters.AddRange(sp);
            return cmm.ExecuteScalar().ToString();
        }

        /// <summary>
        /// 第一行第一列的值
        /// </summary>
        public string ExecuteScalar(string proname, SqlParameter[] sp, CommandType t)
        {
            SqlCommand cmm = new SqlCommand(proname, _con);
            cmm.CommandType = t;
            cmm.Parameters.AddRange(sp);
            return cmm.ExecuteScalar().ToString();
        }

        /// <summary>
        /// 数据表
        /// </summary>
        public DataTable ExecuteDataTable(string sql)
        {
            //SqlCommand cmm = new SqlCommand(sql, _con);
            //SqlDataAdapter sdp = new SqlDataAdapter(cmm);
            //DataTable dt = new DataTable();
            //sdp.Fill(dt);
            
            using (SqlCommand cmm = new SqlCommand(sql, _con))
            {
                SqlDataAdapter sdp = new SqlDataAdapter(cmm);
                DataTable dt = new DataTable();
                sdp.Fill(dt);
                return dt;
            }
        }

        /// <summary>
        /// 数据表
        /// </summary>
        public DataTable ExecuteDataTable(string sql, SqlParameter[] sp)
        {
            SqlCommand cmm = new SqlCommand(sql, _con);
            cmm.Parameters.AddRange(sp);
            SqlDataAdapter sdp = new SqlDataAdapter(cmm);
            DataTable dt = new DataTable();
            sdp.Fill(dt);
            return dt;
        }

        /// <summary>
        /// 数据表
        /// </summary>
        public DataTable ExecuteDataTable(string proname, SqlParameter[] sp, CommandType t)
        {
            SqlCommand cmm = new SqlCommand(proname, _con);
            cmm.CommandType = t;
            cmm.Parameters.AddRange(sp);
            SqlDataAdapter sdp = new SqlDataAdapter(cmm);
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
            SqlCommand cmm = new SqlCommand(sql, _con);
            SqlTransaction tran = _con.BeginTransaction();
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
        public int ExecuteCommand(string sql, SqlParameter[] sp)
        {
            int numrow = 0;
            SqlCommand cmm = new SqlCommand(sql, _con);
            SqlTransaction tran = _con.BeginTransaction();
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
        public int ExecuteCommand(string proname, SqlParameter[] sp, CommandType t)
        {
            int numrow = 0;
            SqlCommand cmm = new SqlCommand(proname, _con);
            SqlTransaction tran = _con.BeginTransaction();
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

        /// <summary>
        /// 支持部分映射
        /// 批量插入
        /// </summary>
        public void BatchExecuteCommand(string tablename, DataTable table)
        {
            using (SqlBulkCopy sbc = new SqlBulkCopy(connection))
            {
                sbc.DestinationTableName = tablename;
                for (int i = 0; i < table.Columns.Count; i++)
                {
                    sbc.ColumnMappings.Add(table.Columns[i].ColumnName, table.Columns[i].ColumnName);
                }
                //sbc.ColumnMappings.Add("医院编码", "HOSPITAL_CODE");
                //sbc.ColumnMappings.Add("病种编码", "DISEASE_CODE");
                //sbc.ColumnMappings.Add("数据项编码", "SD_ITEM_CODE");
                //sbc.ColumnMappings.Add("PN", "PATIENT_NO");
                //sbc.ColumnMappings.Add("值", "ITEM_VALUE");
                //sbc.ColumnMappings.Add("医学负责人", "MEDICAL_NAME");
                //sbc.ColumnMappings.Add("计算机负责人", "COMPUTER_NAME");
                //sbc.ColumnMappings.Add("备注", "MEMO");

                sbc.WriteToServer(table);
            }
        }

        /// <summary>
        /// 执行结果
        /// 不带事务
        /// </summary>
        public int ExecuteCommandNoTran(string proname, SqlParameter[] sp, CommandType t)
        {
            int numrow = 0;
            SqlCommand cmm = new SqlCommand(proname, _con);
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
            using (SqlBulkCopy sbc = new SqlBulkCopy(connection))
            {
                sbc.DestinationTableName = tablename;
                sbc.WriteToServer(table);
            }
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        public DataTable ExecuteDataTable(string sql, int curpage, int pagesize)
        {
            SqlCommand cmm = new SqlCommand(sql, _con);
            SqlDataAdapter sdp = new SqlDataAdapter(cmm);
            DataTable dt = new DataTable();
            sdp.Fill((curpage - 1) * pagesize, pagesize, dt);
            return dt;
        }

        /// <summary>
        /// 并行执行查询
        /// </summary>
        //public DataTable ParallelExecuteDataTable<T>(string sql, List<T> where)
        //{
        //    DataTable tables = new DataTable();
        //    if (null == where && 0 == where.Count)
        //    {
        //        throw new ArgumentOutOfRangeException("A conditional bucket is an empty reference or a number of zero");
        //    }

        //    if (100 > where.Count)
        //    {
        //        string sqlBody = string.Format("{0} {1}", sql, where.TryToWhere());
        //        return ExecuteDataTable(sqlBody);
        //    }

        //    else
        //    {
        //        var batchValue = where.TryToBatchValue();
        //        Parallel.ForEach(batchValue, values => {
        //            string sqlBody = string.Format("{0} {1}", sql, values);
        //            DataTable table = ExecuteDataTable(sqlBody);
        //            tables.Merge(table, true);
        //        });
        //    }
        //    return tables;
        //}

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
    }
}