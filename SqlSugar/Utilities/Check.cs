using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace SqlSugar
{
    public class Check
    {
        public static void ThrowNotSupportedException(string message)
        {
            message = message.IsNullOrEmpty() ? new NotSupportedException().Message : message;
            throw new UtilExceptions("SqlSugarException.NotSupportedException：" + message);
        }

        public static void ConnectionConfig(ConnectionConfig config)
        {
            if (config == null || config.ConnectionString.IsNullOrEmpty() || config.DbType.IsNullOrEmpty())
            {
                throw new UtilExceptions("SqlSugarException.ArgumentNullException：" + ErrorMessage.ConnectionConfigIsNull);
            }
        }

        public static void ArgumentNullException(object checkObj, string message)
        {
            if (checkObj == null)
                throw new UtilExceptions("SqlSugarException.ArgumentNullException：" + message);
        }

        public static void ArgumentNullException(object [] checkObj, string message)
        {
            if (checkObj == null|| checkObj.Length==0)
                throw new UtilExceptions("SqlSugarException.ArgumentNullException：" + message);
        }

        public static void Exception(bool isException, string message, params string[] args)
        {
            if (isException)
                throw new UtilExceptions(string.Format(message, args));
        }
    }
}
