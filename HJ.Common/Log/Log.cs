using HJ.Common.Datas.Operate;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HJ.Common.Log
{
    public static class Log
    {
        private static string _iniPath = AppDomain.CurrentDomain.BaseDirectory + "Log.ini";
        private static string _logPath = AppDomain.CurrentDomain.BaseDirectory +"ErrorLog";
        private static string connectionString =
            IniProvider.INIGetStringValue(_iniPath, "LogConfig", "connectionString", @"")
            == null ? @""
            : IniProvider.INIGetStringValue(_iniPath, "LogConfig", "connectionString", @"");
        private static string sourceLibrary = IniProvider.INIGetStringValue(_iniPath, "targetLibrary", "sourceLibrary", "PDP");
        /// <summary>
        /// 异常日志
        /// </summary>
        /// <param name="ex"></param>
        [Obsolete("该函数已过时，请使用新函数WritLogToFile!!!", false)]
        public static void WriteLogToDB(Exception ex)
        {
            using (MSSQL ms = new MSSQL(connectionString))
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendFormat("INSERT INTO {0}_ERROR_LOG", sourceLibrary);
                sb.Append(@"([CLASS_NAME]
                            ,[FUNC_NAME]
                            ,[ERR_CONTENT]
                            ,[UPD_USER_ID]
                            ,[UPD_DATE])");
                sb.Append(" VALUES ");
                sb.AppendFormat("('{0}',", ex.Source);
                sb.AppendFormat("'{0}',", ex.TargetSite);
                sb.AppendFormat("'{0}',", ex.Message);
                sb.AppendFormat("'{0}',", sourceLibrary == "PDP" ? "PDP" : "ETS");
                sb.AppendFormat("'{0}')", DateTime.Now.ToString());
                ms.ExecuteCommand(sb.ToString());
            }
        }

        /// <summary>
        /// 异常日志
        /// 可获取DLL_NAME
        /// </summary>
        /// <param name="ex">异常信息</param>
        /// <param name="stackFrame">传参 new StackFrame(true)</param>
        [Obsolete("该函数已过时，请使用新函数WritLogToFile!!!", false)]
        public static void WriteLogToDB(Exception ex, StackFrame stackFrame)
        {
            StackTrace st = new StackTrace(stackFrame);
            StackFrame sf = st.GetFrame(0);
            using (MSSQL ms = new MSSQL(connectionString))
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendFormat("INSERT INTO {0}_ERROR_LOG", sourceLibrary);
                sb.Append(@"([CLASS_NAME]
                            ,[DLL_NAME]
                            ,[FUNC_NAME]
                            ,[ERR_CONTENT]
                            ,[UPD_USER_ID]
                            ,[UPD_DATE])");
                sb.Append(" VALUES ");
                sb.AppendFormat("('{0}',", ex.Source);
                sb.AppendFormat("'{0}',", sf.GetFileName());
                sb.AppendFormat("'{0}',", ex.TargetSite);
                sb.AppendFormat("'{0}',", ex.Message);
                sb.AppendFormat("'{0}',", sourceLibrary == "PDP" ? "PDP" : "ETS");
                sb.AppendFormat("'{0}')", DateTime.Now.ToString());
                ms.ExecuteCommand(sb.ToString());
            }
        }

        /// <summary>
        /// 异常日志
        /// </summary>
        /// <param name="ex"></param>
        [Obsolete("该函数已过时，请使用新函数WritLogToFile!!!", false)]
        public static void WriteLogToDB(Exception ex, StackFrame stackFrame, string patientNo)
        {
            using (MSSQL ms = new MSSQL(connectionString))
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendFormat("INSERT INTO {0}_ERROR_LOG", sourceLibrary);
                sb.Append(@"([CLASS_NAME]
                            ,[FUNC_NAME]
                            ,[ERR_CONTENT]
                            ,[SD_CPAT_NO]
                            ,[UPD_USER_ID]
                            ,[UPD_DATE])");
                sb.Append(" VALUES ");
                sb.AppendFormat("('{0}',", ex.Source);
                sb.AppendFormat("'{0}',", ex.TargetSite);
                sb.AppendFormat("'{0}',", ex.Message);
                sb.AppendFormat("'{0}',", patientNo);
                sb.AppendFormat("'{0}',", sourceLibrary == "PDP" ? "PDP" : "ETS");
                sb.AppendFormat("'{0}')", DateTime.Now.ToString());
                ms.ExecuteCommand(sb.ToString());
            }
        }

        /// <summary>
        /// 异常日志
        /// </summary>
        /// <param name="ex"></param>
        [Obsolete("该函数已过时，请使用新函数WritLogToFile!!!", false)]
        public static void WriteLogToDB(Exception ex, StackFrame stackFrame, string patientNo, string funcName)
        {
            using (MSSQL ms = new MSSQL(connectionString))
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendFormat("INSERT INTO {0}_ERROR_LOG", sourceLibrary);
                sb.Append(@"([CLASS_NAME]
                            ,[FUNC_NAME]
                            ,[ERR_CONTENT]
                            ,[SD_CPAT_NO]
                            ,[UPD_USER_ID]
                            ,[UPD_DATE])");
                sb.Append(" VALUES ");
                sb.AppendFormat("('{0}',", ex.Source);
                sb.AppendFormat("'{0}',", funcName);
                sb.AppendFormat("'{0}',", ex.Message);
                sb.AppendFormat("'{0}',", patientNo);
                sb.AppendFormat("'{0}',", sourceLibrary == "PDP" ? "PDP" : "ETS");
                sb.AppendFormat("'{0}')", DateTime.Now.ToString());
                ms.ExecuteCommand(sb.ToString());
            }
        }

        /// <summary>
        /// 异常日志
        /// </summary>
        /// <param name="ex"></param>
        [Obsolete("该函数已过时，请使用新函数WritLogToFile!!!", false)]
        public static void WriteLogToDB(Exception ex, StackFrame stackFrame, string patientNo, string funcName, string SD_ID)
        {
            using (MSSQL ms = new MSSQL(connectionString))
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendFormat("INSERT INTO {0}_ERROR_LOG", sourceLibrary);
                sb.Append(@"([SD_ID]
                            ,[CLASS_NAME]
                            ,[FUNC_NAME]
                            ,[ERR_CONTENT]
                            ,[SD_CPAT_NO]
                            ,[UPD_USER_ID]
                            ,[UPD_DATE])");
                sb.Append(" VALUES ");
                sb.AppendFormat("({0},", SD_ID);
                sb.AppendFormat("'{0}',", ex.Source);
                sb.AppendFormat("'{0}',", funcName);
                sb.AppendFormat("'{0}',", ex.Message);
                sb.AppendFormat("'{0}',", patientNo);
                sb.AppendFormat("'{0}',", sourceLibrary == "PDP" ? "PDP" : "ETS");
                sb.AppendFormat("'{0}')", DateTime.Now.ToString());
                ms.ExecuteCommand(sb.ToString());
            }
        }


        /// <summary>
        /// 执行日志
        /// </summary>
        /// <param name="SD_ID"></param>
        /// <param name="dateStart">执行开始时间</param>
        /// <param name="dateEnd">执行结束时间</param>
        /// <param name="stackFrame">new StackFrame(true)</param>
        [Obsolete("该函数已过时，请使用新函数WritLogToFile!!!", false)]
        public static void WriteExcuteLogToDB(int SD_ID, DateTime dateStart, DateTime dateEnd, StackFrame stackFrame)
        {
            StackTrace st = new StackTrace(stackFrame);
            StackFrame sf = st.GetFrame(0);
            if (string.IsNullOrWhiteSpace(connectionString))
                return;
            using (MSSQL ms = new MSSQL(connectionString))
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendFormat("INSERT INTO {0}_PROC_LOG", sourceLibrary);
                sb.Append(@"([SD_ID]
                            ,[PROC_CAT_CODE]
                            ,[PROC_CONTENT_ID]
                            ,[PROC_URL]
                            ,[START_TIME]
                            ,[END_TIME]
                            ,[UPD_USER_ID]
                            ,[UPD_DATE])");
                sb.Append(" VALUES ");
                sb.AppendFormat("('{0}',", SD_ID);
                sb.AppendFormat("'{0}',", 3);
                sb.AppendFormat("'{0}',", sf.GetMethod());
                sb.AppendFormat("'{0}',", sf.GetFileName());
                sb.AppendFormat("'{0}',", dateStart);
                sb.AppendFormat("'{0}',", dateEnd);
                sb.AppendFormat("'{0}',", sourceLibrary == "PDP" ? "PDP" : "ETS");
                sb.AppendFormat("'{0}')", DateTime.Now.ToString());
                ms.ExecuteCommand(sb.ToString());
            }
        }

        /// <summary>
        /// 获取当前DLL所在程序域目录/运行目录/ini文件允许存放目录
        /// </summary>
        /// <param name="stackFrame">new StackFrame(true)</param>
        /// <returns></returns>
        public static string GetDllFilePath(StackFrame stackFrame)
        {
            StackTrace st = new StackTrace(stackFrame);
            StackFrame sf = st.GetFrame(0);
            return sf.GetFileName();
        }

        /// <summary>
        /// 异常日志
        /// </summary>
        /// <param name="ex"></param>
        public static void WriteLogToFile(Exception ex)
        {
            ExceptionMessage em = new ExceptionMessage();
            em.Exception = ex;
            SecureQueue.Enqueue(em);
            WriterToTxt();
        }

        /// <summary>
        /// 异常日志
        /// </summary>
        /// <param name="ex"></param>
        /// <param name="stackFrame"></param>
        public static void WriteLogToFile(Exception ex, StackFrame stackFrame)
        {
            ExceptionMessage em = new ExceptionMessage();
            em.Exception = ex;
            StackTrace st = new StackTrace(stackFrame);
            em.StackFrame = st.GetFrame(0);
            SecureQueue.Enqueue(em);
            WriterToTxt();
        }

        /// <summary>
        /// 异常日志
        /// 不建议在循环内部try catch
        /// </summary>
        /// <param name="ex"></param>
        /// <param name="stackFrame"></param>
        /// <param name="FuncName"></param>
        /// <param name="SD_CPAT_NO"></param>
        public static void WriteLogToFile(Exception ex, StackFrame stackFrame,string FuncName)
        {
            ExceptionMessage em = new ExceptionMessage();
            em.Exception = ex;
            StackTrace st = new StackTrace(stackFrame);
            em.StackFrame = st.GetFrame(0);
            em.FuncName = FuncName;
            SecureQueue.Enqueue(em);
            WriterToTxt();
        }

        /// <summary>
        /// 异常日志
        /// 不建议在循环内部try catch
        /// 不使用的参数传""即可
        /// </summary>
        /// <param name="ex"></param>
        /// <param name="stackFrame"></param>
        /// <param name="FuncName"></param>
        /// <param name="SD_CODE"></param>
        /// <param name="SD_ITEM_CODE"></param>
        /// <param name="SD_EKPI_CODE"></param>
        /// <param name="SD_CPAT_NO"></param>
        public static void WriteLogToFile(Exception ex, StackFrame stackFrame, string FuncName, string SD_CODE = "", string SD_ITEM_CODE = "", string SD_EKPI_CODE = "", string SD_CPAT_NO = "")
        {
            try
            {
                ExceptionMessage em = new ExceptionMessage();
                em.Exception = ex;
                StackTrace st = new StackTrace(stackFrame);
                em.StackFrame = st.GetFrame(0);
                em.FuncName = FuncName;
                em.SD_CODE = SD_CODE;
                em.SD_ITEM_CODE = SD_ITEM_CODE;
                em.SD_EKPI_CODE = SD_EKPI_CODE;
                em.SD_CPAT_NO = SD_CPAT_NO;
                SecureQueue.Enqueue(em);
                WriterToTxt();
            }
            catch (Exception e)
            {
                throw;
            }
        }

        private static void WriteByteToFile(byte[] bytes)
        {
            try
            {
                if (!Directory.Exists(_logPath))
                {
                    Directory.CreateDirectory(_logPath);
                }
                FileStream fs = File.OpenWrite(_logPath + "\\" + System.DateTime.Now.Date.ToString("yyyy-MM-dd") + ".log");
                fs.Position = fs.Length;
                fs.Write(bytes, 0, bytes.Length);
                fs.Close();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static void WriterToTxt()
        {
            if (SecureQueue.Count > 0)
            {
                if (!Directory.Exists(_logPath))
                {
                    Directory.CreateDirectory(_logPath);
                }

                StringBuilder Builder = new StringBuilder();
                foreach (var em in SecureQueue)
                {
                    Builder.AppendFormat("<<<<<<<<<<<<<<<<<<<<<<<<<<<ErrorLog<<<<<<<<<<<<<<<<<<<<<<<<<<<<<\r\n");
                    Builder.AppendFormat("Time:{0} \r\n", DateTime.Now.ToString("HH:mm:ss"));
                    Builder.AppendFormat("FuncName:{0} \r\n", em.FuncName);
                    if (em.SD_CODE != "")
                    {
                        Builder.AppendFormat("SD_CODE:{0} \r\n", em.SD_CODE);
                    }
                    if (em.SD_ITEM_CODE != "")
                    {
                        Builder.AppendFormat("SD_ITEM_CODE:{0} \r\n", em.SD_ITEM_CODE);
                    }
                    if (em.SD_EKPI_CODE != "")
                    {
                        Builder.AppendFormat("SD_EKPI_CODE:{0} \r\n", em.SD_EKPI_CODE);
                    }
                    if (em.SD_CPAT_NO != "")
                    {
                        Builder.AppendFormat("SD_CPAT_NO:{0} \r\n", em.SD_CPAT_NO);
                    }
                    Builder.AppendFormat("Message:{0} \r\n", em.Exception.Message);
                    Builder.AppendFormat("InnerException:{0} \r\n", em.Exception.InnerException);
                    Builder.AppendFormat("StackTrace:{0} \r\n", em.Exception.StackTrace);
                    Builder.AppendFormat("Source:{0} \r\n", em.Exception.Source);
                    Builder.AppendFormat("TargetSite:{0} \r\n", em.Exception.TargetSite);
                    Builder.AppendFormat("FileName:{0} \r\n", em.StackFrame.GetFileName());
                    Builder.AppendFormat("LineNumber:{0} \r\n", em.StackFrame.GetFileLineNumber());
                    Builder.AppendFormat("ColumnNumber:{0} \r\n", em.StackFrame.GetFileColumnNumber());
                }
                byte[] bytes = Encoding.UTF8.GetBytes(Builder.ToString());

                FileStream fs = File.OpenWrite(_logPath + "\\" + DateTime.Now.Date.ToString("yyyy-MM-dd") + ".log");
                fs.Position = fs.Length;
                fs.Write(bytes, 0, bytes.Length);
                fs.Close();
            }
        }

        private static ConcurrentQueue<ExceptionMessage> SecureQueue = new ConcurrentQueue<ExceptionMessage>();
    }
}
