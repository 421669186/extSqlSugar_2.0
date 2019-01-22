using System;
using System.IO;
using System.Text;
using System.Linq;
using System.Data;
using System.Reflection;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;

namespace HJ.Common.Trans
{
    public static partial class TransType
    {
        public static List<TSource> ToList<TSource>(this DataTable dataTable) where TSource : new()
        {
            var dataList = new List<TSource>();

            const BindingFlags flags = BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic;
            var objFieldNames = (from PropertyInfo aProp in typeof(TSource).GetProperties(flags)
                                 select new { Name = aProp.Name, Type = Nullable.GetUnderlyingType(aProp.PropertyType) ?? aProp.PropertyType }).ToList();

            var tblFieldNames = (from DataColumn aHeader in dataTable.Columns
                                 select new { Name = aHeader.ColumnName, Type = aHeader.DataType }).ToList();

            var commonFields = objFieldNames.Intersect(tblFieldNames).ToList();

            foreach (DataRow dataRow in dataTable.AsEnumerable().ToList())
            {
                var aTSource = new TSource();
                foreach (var aField in commonFields)
                {
                    PropertyInfo propertyInfos = aTSource.GetType().GetProperty(aField.Name);
                    var value = (dataRow[aField.Name] == DBNull.Value) ? null : dataRow[aField.Name];
                    propertyInfos.SetValue(aTSource, value, null);
                }
                dataList.Add(aTSource);
            }
            return dataList;
        }

        public static DataTable ToTable<TSource>(this List<TSource> source)
        {
            DataTable dataTable = new DataTable(typeof(TSource).Name);
            PropertyInfo[] props = typeof(TSource).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (PropertyInfo prop in props)
            {
                dataTable.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ??
                    prop.PropertyType);
            }

            foreach (TSource item in source)
            {
                var values = new object[props.Length];
                for (int i = 0; i < props.Length; i++)
                {
                    values[i] = props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }
            return dataTable;
        }

        public static string ToBinary(this object source)
        {
            MemoryStream ms = new MemoryStream();
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(ms, source);
            byte[] data = ms.ToArray(); ms.Close();
            return Encoding.Default.GetString(data);
        }

        public static object ToObject(this string source)
        {
            MemoryStream ms = new MemoryStream();
            byte[] data = Encoding.Default.GetBytes(source);
            ms.Write(data, 0, data.Length);
            BinaryFormatter formatter = new BinaryFormatter();
            object objects = formatter.Deserialize(ms); ms.Close();
            return objects;
        }

        public static List<string> StringToList(this string source)
        {
            List<string> result = new List<string>();
            var lsResult =
                source.Replace("(", "").Replace(")", "").Replace("'", "").Split(',').AsEnumerable();
            foreach (string value in lsResult)
            {
                result.Add(value);
            }
            return result;
        }

        [Obsolete("Please use the new method TryToString to complete the assembly operation!", false)]
        public static string ListToString(this List<string> source)
        {
            StringBuilder sb = new StringBuilder("");
            sb.Append("('',");
            source.ForEach(str => { sb.Append("'" + str + "'" + ","); });
            return sb.ToString().Substring(0, sb.ToString().Length - 1) + ")";
        }

        [Obsolete("Please use the new method TryToString to complete the assembly operation!", false)]
        public static string ListToString(this List<int> source)
        {
            StringBuilder sb = new StringBuilder("");
            sb.Append("('',");
            source.ForEach(str => { sb.Append(str + ","); });
            return sb.ToString().Substring(0, sb.ToString().Length - 1) + ")";
        }

        public static string TryToString<T>(this IEnumerable<T> source)
        {
            if (null == source && 0 == source.Count())
            {
                throw new ArgumentNullException("Unable to provide conversion operations for empty or non data cases!");
            }
            string body = string.Join("','", source);
            return new StringBuilder("('" + body + "')").ToString();
        }

        #region 数值转换
        /// <summary>
        /// 转换为整型
        /// </summary>
        /// <param name="data">数据</param>
        public static int ToInt(this object data)
        {
            if (data == null)
                return 0;
            int result;
            var success = int.TryParse(data.ToString(), out result);
            if (success)
                return result;
            try
            {
                return Convert.ToInt32(ToDouble(data, 0));
            }
            catch (Exception)
            {
                return 0;
            }
        }

        /// <summary>
        /// 转换为可空整型
        /// </summary>
        /// <param name="data">数据</param>
        public static int? ToIntOrNull(this object data)
        {
            if (data == null)
                return null;
            int result;
            bool isValid = int.TryParse(data.ToString(), out result);
            if (isValid)
                return result;
            return null;
        }

        /// <summary>
        /// 转换为双精度浮点数
        /// </summary>
        /// <param name="data">数据</param>
        public static double ToDouble(this object data)
        {
            if (data == null)
                return 0;
            double result;
            return double.TryParse(data.ToString(), out result) ? result : 0;
        }

        /// <summary>
        /// 转换为双精度浮点数,并按指定的小数位4舍5入
        /// </summary>
        /// <param name="data">数据</param>
        /// <param name="digits">小数位数</param>
        public static double ToDouble(this object data, int digits)
        {
            return Math.Round(ToDouble(data), digits);
        }

        /// <summary>
        /// 转换为可空双精度浮点数
        /// </summary>
        /// <param name="data">数据</param>
        public static double? ToDoubleOrNull(this object data)
        {
            if (data == null)
                return null;
            double result;
            bool isValid = double.TryParse(data.ToString(), out result);
            if (isValid)
                return result;
            return null;
        }

        /// <summary>
        /// 转换为高精度浮点数
        /// </summary>
        /// <param name="data">数据</param>
        public static decimal ToDecimal(this object data)
        {
            if (data == null)
                return 0;
            decimal result;
            return decimal.TryParse(data.ToString(), out result) ? result : 0;
        }

        /// <summary>
        /// 转换为高精度浮点数,并按指定的小数位4舍5入
        /// </summary>
        /// <param name="data">数据</param>
        /// <param name="digits">小数位数</param>
        public static decimal ToDecimal(this  object data, int digits)
        {
            return Math.Round(ToDecimal(data), digits);
        }

        /// <summary>
        /// 转换为可空高精度浮点数
        /// </summary>
        /// <param name="data">数据</param>
        public static decimal? ToDecimalOrNull(this  object data)
        {
            if (data == null)
                return null;
            decimal result;
            bool isValid = decimal.TryParse(data.ToString(), out result);
            if (isValid)
                return result;
            return null;
        }

        /// <summary>
        /// 转换为可空高精度浮点数,并按指定的小数位4舍5入
        /// </summary>
        /// <param name="data">数据</param>
        /// <param name="digits">小数位数</param>
        public static decimal? ToDecimalOrNull(this object data, int digits)
        {
            var result = ToDecimalOrNull(data);
            if (result == null)
                return null;
            return Math.Round(result.Value, digits);
        }
        #endregion

        /// <summary>
        /// 转换为日期
        /// </summary>
        /// <param name="data">数据</param>
        public static DateTime ToDate(this object data)
        {
            if (data == null)
                return DateTime.MinValue;
            DateTime result;
            return DateTime.TryParse(data.ToString(), out result) ? result : DateTime.MinValue;
        }

        /// <summary>
        /// 转换为可空日期
        /// </summary>
        /// <param name="data">数据</param>
        public static DateTime? ToDateOrNull(this object data)
        {
            if (data == null)
                return null;
            DateTime result;
            bool isValid = DateTime.TryParse(data.ToString(), out result);
            if (isValid)
                return result;
            return null;
        }

        /// <summary>
        /// 转换为可空布尔值
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static Boolean? ToBool(this object data)
        {
            if (data == null)
                return null;

            bool flag;
            if (bool.TryParse(data.ToString(), out flag))
                return flag;
            else
                return null;
        }

        /// <summary>
        /// 转换为字符串
        /// </summary>
        /// <param name="data">数据</param>
        public static string ToStringOrEmpty(this object data)
        {
            return data == null ? string.Empty : data.ToString().Trim();
        }

        public static IEnumerable<TSource> DistinctBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {

            HashSet<TKey> seenKeys = new HashSet<TKey>();

            foreach (TSource element in source)
            {

                if (seenKeys.Add(keySelector(element)))
                {

                    yield return element;
                }
            }
        }

        /// <summary>
        /// 获取链表针对处理器数*2 所划分的条数
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static int ReserveN<T>(this IEnumerable<T> source)
        {
            var processCount = Environment.ProcessorCount;
            return source.Count() / (processCount * 2);
        }

        /// <summary>
        /// 判断链表非空
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static bool IsNotNull<T>(this IEnumerable<T> source)
        {
            return null != source && 0 < source.Count() ? true : false;
        }

        /// <summary>
        /// 转换为（'',''）格式
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="wheres"></param>
        /// <returns></returns>
        public static string TryToWhere<T>(this IEnumerable<T> wheres)
        {
            return new
                   StringBuilder("('" + string.Join("','", wheres) + "')").ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="bucket"></param>
        /// <returns></returns>
        public static List<string> TryToBatchValue<T>(this List<T> bucket)
        {
            var proce = bucket.ReserveN();
            var batch = bucket.Count / proce;
            var mores = bucket.Count % proce;
            var sizes = mores == 0
                      ? batch : batch + 1;

            var temps = new List<string>();

            for (int i = 0; i < sizes; i++)
            {
                if (i == sizes - 1 && bucket.Take(mores).IsNotNull())
                {
                    temps.Add(bucket.Take(mores).TryToWhere());
                }   
                else
                {
                    temps.Add(bucket.Take(proce).TryToWhere());
                    bucket.RemoveRange(0, proce);
                }
            }
            return temps;
        }

        /// <summary>
        /// 计算字符串在大文本中出现次数
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public static int MatchedTimes(this string content,string word)
        {
            if (null == content || "" == content|| null == word || "" == word)
            {
                return 0;
            }
            else
            {
                var number1 = content.Length;
                var number2 = content.Replace(word, word.Substring(1, word.Length - 1)).Length;
                var result = number1 - number2;
                return result;
            }
        }
    }
}