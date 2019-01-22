using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HJ.Common.Funcs
{
    public class RegexMethod : IRegexMethod
    {
        string content;//文本
        RegexOptions roDefault = RegexOptions.IgnoreCase | RegexOptions.Singleline;

        public RegexMethod() { }

        public RegexMethod(string str)
        {
            if (string.IsNullOrEmpty(str))
                content = string.Empty;
            else
                content = str;
        }

        /// <summary>
        /// 包含
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        public bool Include(string keyWord)
        {
            return Include(keyWord, roDefault);
        }
        /// <summary>
        /// 包含
        /// </summary>
        /// <param name="keyWord"></param>
        /// <returns></returns>
        public bool Include(string keyWord, RegexOptions ro)
        {
            return keyWord == null ? false : Regex.IsMatch(content, keyWord, ro);
        }

        /// <summary>
        /// 同时包含
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        public bool Include(string coreWord, string keyWord, RegexOptions ro)
        {
            return Regex.IsMatch(content, "^(?=.*" + coreWord + ")(?=.*?" + keyWord + ").*", ro);
        }

        /// <summary>
        /// 同时包含
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        public bool Include(string coreWord, string keyWord)
        {
            return Include(coreWord, keyWord, roDefault);
        }

        /// <summary>
        /// 不包含
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        public bool Exclude(string keyWord)
        {
            return Exclude(keyWord, roDefault);
        }

        public bool Exclude(string keyWord, RegexOptions ro)
        {
            return keyWord == null ? false : !Regex.IsMatch(content, keyWord, ro);
        }

        /// <summary>
        /// 包含且排除
        /// </summary>
        /// <param name="exclude">排除词</param>
        /// <param name="contain">包含词</param>
        /// <returns></returns>
        public bool InExclude(string exclude, string contain)
        {
            return InExclude(exclude, contain, roDefault);
        }

        /// <summary>
        /// 包含且排除
        /// </summary>
        /// <param name="exclude">排除次</param>
        /// <param name="contain">包含词</param>
        /// <param name="ro">是否区分大小写</param>
        /// <returns></returns>
        public bool InExclude(string includeWord, string excludeWord, RegexOptions ro)
        {
            return Regex.IsMatch(content, "^((?!" + excludeWord + ").)*" + includeWord + "((?!" + excludeWord + ").)*$", ro);
        }



        /// <summary>
        /// 核心词之前是否包含某关键词
        /// </summary>
        /// <param name="keyWord">前置词</param>
        /// <param name="coreWord">核心词</param>
        /// <returns></returns>
        public bool BeforeInclude(string coreWord, string keyWord)
        {
            return BeforeInclude(coreWord, keyWord, roDefault);
        }

        /// <summary>
        /// 核心词之前是否包含某关键词
        /// </summary>
        /// <param name="keyWord">前置词</param>
        /// <param name="coreWord">核心词</param>
        /// <param name="ro">是否区分大小写</param>
        /// <returns></returns>
        public bool BeforeInclude(string coreWord, string keyWord, RegexOptions ro)
        {
            return Regex.IsMatch(content, "^(?!" + coreWord + ").*(" + keyWord + "(?:(?!" + keyWord + ").)*" + coreWord + ").*", ro);
        }

        /// <summary>
        /// 核心词之前是否排除某关键词
        /// </summary>
        /// <param name="keyWord">前置词</param>
        /// <param name="coreWord">核心词</param>
        /// <returns></returns>
        public bool BeforeExclude(string coreWord, string keyWord)
        {
            return BeforeExclude(coreWord, keyWord, roDefault);
        }

        /// <summary>
        /// 核心词之前是否排除某关键词
        /// </summary>
        /// <param name="keyWord">前置词</param>
        /// <param name="coreWord">核心词</param>
        /// <param name="ro">是否区分大小写</param>
        /// <returns></returns>
        public bool BeforeExclude(string coreWord, string keyWord, RegexOptions ro)
        {
            return Regex.IsMatch(content, "(?!.*" + keyWord + ")^.*?(" + coreWord + ")", ro);
        }

        /// <summary>
        /// 判断后包含
        /// </summary>
        /// <param name="coreWord">核心词</param>
        /// <param name="keyWord">后置词</param>
        /// <returns></returns>
        public bool AfterInclude(string coreWord, string keyWord)
        {
            return AfterInclude(coreWord, keyWord, roDefault);
        }

        /// <summary>
        /// 判断后包含
        /// </summary>
        /// <param name="coreWord">核心词</param>
        /// <param name="keyWord">后置词</param>
        /// <param name="ro">是否区分大小写</param>
        /// <returns></returns>
        public bool AfterInclude(string coreWord, string keyWord, RegexOptions ro)
        {
            return Regex.IsMatch(content, "(" + coreWord + ").*?(" + keyWord + ")", ro);
        }

        /// <summary>
        /// 判断后不包含
        /// </summary>
        /// <param name="coreWord">核心词</param>
        /// <param name="keyWord">后置词</param>
        /// <returns></returns>
        public bool AfterExclude(string coreWord, string keyWord)
        {
            return AfterExclude(coreWord, keyWord, roDefault);
        }

        /// <summary>
        /// 判断后不包含
        /// </summary>
        /// <param name="coreWord">核心词</param>
        /// <param name="keyWord">后置词</param>
        /// <param name="ro">是否区分大小写</param>
        /// <returns></returns>
        public bool AfterExclude(string coreWord, string keyWord, RegexOptions ro)
        {
            return Regex.IsMatch(content, "(?!.*" + keyWord + ")" + coreWord + ".*(?!" + keyWord + ")", ro);
        }

        /// <summary>
        /// 核心词之前是否为某关键词
        /// </summary>
        /// <param name="coreWord">核心词</param>
        /// <param name="keyWord">关键词</param>
        /// <param name="ro">是否区分大小写</param>
        /// <returns></returns>
        public bool BeforeIs(string coreWord, string keyWord, RegexOptions ro)
        {
            return Regex.IsMatch(content, "(?<=" + keyWord + ")(" + coreWord + ")", ro);
        }
        /// <summary>
        /// 核心词之前是否为某关键词
        /// </summary>
        /// <param name="coreWord">核心词</param>
        /// <param name="keyWord">关键词</param>
        /// <returns></returns>
        public bool BeforeIs(string coreWord, string keyWord)
        {
            return BeforeIs(coreWord, keyWord, roDefault);
        }

        /// <summary>
        /// 核心词之前是否不为某关键词
        /// </summary>
        /// <param name="coreWord">核心词</param>
        /// <param name="keyWord">关键词</param>
        /// <param name="ro">是否区分大小写</param>
        /// <returns></returns>
        public bool BeforeIsnot(string coreWord, string keyWord, RegexOptions ro)
        {
            return Regex.IsMatch(content, "(?<!" + keyWord + ")(" + coreWord + ")", ro);
        }
        /// <summary>
        /// 核心词之前是否不为某关键词
        /// </summary>
        /// <param name="coreWord">核心词</param>
        /// <param name="keyWord">关键词</param>
        /// <returns></returns>
        public bool BeforeIsnot(string coreWord, string keyWord)
        {
            return BeforeIsnot(coreWord, keyWord, roDefault);
        }



        /// <summary>
        /// 核心词之后是否为某关键词
        /// </summary>
        /// <param name="coreWord">核心词</param>
        /// <param name="keyWord">关键词</param>
        /// <param name="ro">是否区分大小写</param>
        /// <returns></returns>
        public bool AfterIs(string coreWord, string keyWord, RegexOptions ro)
        {
            return Regex.IsMatch(content, "(" + coreWord + ")(?=" + keyWord + ")", ro);
        }

        /// <summary>
        /// 核心词之后是否为某关键词
        /// </summary>
        /// <param name="coreWord">核心词</param>
        /// <param name="keyWord">关键词</param>
        /// <returns></returns>
        public bool AfterIs(string coreWord, string keyWord)
        {
            return AfterIs(coreWord, keyWord, roDefault);
        }

        /// <summary>
        /// 核心词之后是否不为某关键词
        /// </summary>
        /// <param name="coreWord">核心词</param>
        /// <param name="keyWord">关键词</param>
        /// <param name="ro">是否区分大小写</param>
        /// <returns></returns>
        public bool AfterIsnot(string coreWord, string keyWord, RegexOptions ro)
        {
            return Regex.IsMatch(content, "(" + coreWord + ")(?!" + keyWord + ")", ro);
        }

        /// <summary>
        /// 核心词之后是否不为某关键词
        /// </summary>
        /// <param name="coreWord"></param>
        /// <param name="keyWord"></param>
        /// <returns></returns>
        public bool AfterIsnot(string coreWord, string keyWord)
        {
            return AfterIsnot(coreWord, keyWord, roDefault);
        }

        /// <summary>
        /// 核心词向前截取到关键词
        /// </summary>
        /// <param name="beforeWord">前置词</param>
        /// <param name="coreWord">核心词</param>
        /// <param name="ro">是否区分大小写</param>
        /// <returns></returns>
        public string CutBeforeWord(string coreWord, string keyWord, RegexOptions ro)
        {
            return Regex.Match(content, "(" + keyWord + ")(?:.(?!" + keyWord + "))*(" + coreWord + ")", ro).Value;
        }

        /// <summary>
        /// 核心词向前截取到关键词
        /// </summary>
        /// <param name="beforeWord">前置词</param>
        /// <param name="coreWord">核心词</param>
        /// <returns></returns>
        public string CutBeforeWord(string coreWord, string keyWord)
        {
            return CutBeforeWord(coreWord, keyWord, roDefault);
        }

        /// <summary>
        /// 核心词向后截取到关键词
        /// </summary>
        /// <param name="coreWord">核心词</param>
        /// <param name="afterWord">后置词</param>
        /// <param name="ro">是否区分大小写</param>
        /// <returns></returns>
        public string CutAfterWord(string coreWord, string keyWord, RegexOptions ro)
        {
            return Regex.Match(content, "(?<=" + coreWord + ").*?(?=" + keyWord + ")", ro).Value;
        }

        /// <summary>
        /// 核心词向后截取到关键词
        /// </summary>
        /// <param name="coreWord">核心词</param>
        /// <param name="afterWord">后置词</param>
        /// <returns></returns>
        public string CutAfterWord(string coreWord, string keyWord)
        {
            return CutAfterWord(coreWord, keyWord, roDefault);
        }



        /// <summary>
        /// 截取核心词前后最近的关键词
        /// </summary>
        ///  <param name="Qzc">是否需要保留前置词 false不保留 true 保留前置词</param>
        /// <param name="end">是否截取到最前最后</param>
        /// <param name="beforeWord">前置词</param>
        /// <param name="coreWord">核心词</param>
        /// <param name="afterWord">后置词</param>
        /// <returns></returns>
        public string CutBeforeAfterWord(string coreWord, string beforeWord, string afterWord)
        {
            return CutBeforeAfterWord(coreWord, beforeWord, afterWord, roDefault);
        }

        /// <summary>
        /// 核心词前后最近的关键词
        /// </summary>
        /// <param name="beforeWord">前置词</param>
        /// <param name="coreWord">核心词</param>
        /// <param name="afterWord">后置词</param>
        /// <param name="ro">是否区分大小写</param>
        /// <returns></returns>
        public string CutBeforeAfterWord(string coreWord, string beforeWord, string afterWord, RegexOptions ro)
        {
            #region MyRegion
            //||afterWord!=null||beforeWord!=string.Empty||afterWord!=string.Empty
            //if (beforeWord != null)
            //{
            //    str1 = Regex.Match(content, "(" + beforeWord + ")[^" + beforeWord + "]*(?<!" + beforeWord + ")(" + coreWord + ").*?(" + afterWord + ")", ro).Value;
            //}
            //return str1;
            //if (beforeWord != null||beforeWord!=string.Empty||afterWord!=null||afterWord!=string.Empty)
            //{
            //    str1 = Regex.Match(content, "(" + beforeWord + ")[^" + beforeWord + "]*(?<!" + beforeWord + ")(" + coreWord + ").*?(" + afterWord + ")", ro).Value;

            //}
            //return str1; 
            #endregion
            return beforeWord == string.Empty || beforeWord == null ? null : Regex.Match(content, "(" + beforeWord + ")[^" + beforeWord + "]*(?<!" + beforeWord + ")(" + coreWord + ").*?(" + afterWord + ")", ro).Value;

        }

        /// <summary>
        /// 核心词向前截取N个字符
        /// </summary>
        /// <param name="coreWord">核心词</param>
        /// <param name="length">截取长度</param>
        /// <returns></returns>
        public string CutBeforeLength(string coreWord, int length)
        {
            return CutBeforeLength(coreWord, length, roDefault);
        }

        /// <summary>
        /// 核心词向前截取n个字符
        /// </summary>
        /// <param name="coreWord">核心词</param>
        /// <param name="length">截取长度</param>
        /// <param name="ro">是否区分大小写</param>
        /// <returns></returns>
        public string CutBeforeLength(string coreWord, int len, RegexOptions ro)
        {
            return Regex.Match(content, "(.{0," + len.ToString() + "}(" + coreWord + "))", ro).Value;
        }

        /// <summary>
        ///  核心词想后截取n个字符
        /// </summary>
        /// <param name="coreWord">核心词</param>
        /// <param name="length">截取长度</param>
        /// <returns></returns>
        public string CutAfterLength(string coreWord, int length)
        {
            return CutAfterLength(coreWord, length, roDefault);
        }

        /// <summary>
        ///  核心词向后截取n个字符
        /// </summary>
        /// <param name="coreWord">核心词</param>
        /// <param name="length">截取长度</param>
        /// <param name="ro">是否区大小写</param>
        /// <returns></returns>
        public string CutAfterLength(string coreWord, int len, RegexOptions ro)
        {
            return Regex.Match(content, "(" + coreWord + ")(.{0," + len.ToString() + "})", ro).Value;
        }

        /// <summary>
        /// 核心词向前后各截取n个字符
        /// </summary>
        /// <param name="coreWord"></param>
        /// <param name="beforeLength"></param>
        /// <param name="afterLength"></param>
        /// <returns></returns>
        public string CutBeforeAfterLength(string coreWord, int beforeLength, int afterLength)
        {
            return CutBeforeAfterLength(coreWord, beforeLength, afterLength, roDefault);
        }

        /// <summary>
        /// 核心词向前后各截取n个字符
        /// </summary>
        /// <param name="coreWord">核心词</param>
        /// <param name="beforeLength"></param>
        /// <param name="afterLength"></param>
        /// <param name="ro">是否区大小写</param>
        /// <returns></returns>
        public string CutBeforeAfterLength(string coreWord, int beforeLength, int afterLength, RegexOptions ro)
        {
            return Regex.Match(content, ".{0," + beforeLength.ToString() + "}(" + coreWord + ")(.{0," + afterLength.ToString() + "})", ro).Value;
        }

        /// <summary>
        /// 提取文本中的数值
        /// </summary>
        /// <param name="ro">是否区分大小写</param>
        /// <returns></returns>
        public string GetNumber(RegexOptions ro)
        {
            MatchCollection matchs = Regex.Matches(content, @"\d+[.．]?\d*", ro);
            var list = (from Match match in matchs select double.Parse(match.Value.ToString())).ToList();
            return list != null && list.Count > 0 ? list[0].ToString() : string.Empty;
        }

        /// <summary>
        /// 提取文本中的数值
        /// </summary>
        /// <returns></returns>
        public string GetNumber()
        {
            return GetNumber(roDefault);
        }

        /// <summary>
        /// 提取所有数值类型数据
        /// </summary>
        /// <param name="content">文本</param>
        /// <returns></returns>
        public List<string> GetNumberList()
        {
            var regex = new Regex(@"\d+[.．]?\d*", RegexOptions.Singleline);
            var matchs = Regex.Matches(content, @"\d+[.．]?\d*", roDefault);
            var list = (from Match match in matchs select match.Value).ToList();
            return list;
        }

        /// <summary>
        /// 提取文本中的带格式的数值（数字格式为×××|***|XXX|xxx ）
        /// <param name="ro">是否区分大小写</param>
        /// </summary>
        /// <returns></returns>
        public string GetNumber(char[] splitChar, RegexOptions ro)
        {
            StringBuilder regexStr = new StringBuilder();
            for (int i = 0; i < splitChar.Length; i++)
            {
                regexStr.Append("\\d+[.．]?\\d*\\" + splitChar[i].ToString());
            }
            regexStr.Append("\\d+[.．]?\\d*");
            return Regex.Match(content, regexStr.ToString(), ro).Value;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="splitChar"></param>
        /// <returns></returns>
        public string GetNumber(char[] splitChar)
        {
            return GetNumber(splitChar, roDefault);
        }

        /// <summary>
        /// 提取文本中的阿拉伯数字，罗马数字，中文数字
        /// </summary>
        /// <returns></returns>
        public string GetAllNumber()
        {
            return Regex.Match(content, "[\\d一二三四五六七八九十两IVXLCDM]+").Value;
        }

        /// <summary>
        /// 提取关键词前最近的数字
        /// </summary>
        /// <param name="coreWord">核心词</param>
        /// <param name="ro">是否区分大小写</param>
        /// <returns></returns>
        public string GetBeforeNumber(string coreWord, RegexOptions ro)
        {
            Match match = Regex.Match(content, "(?<number>\\d+[.．]?\\d*)[^\\d]*?(" + coreWord + ")", ro);
            return match.Groups["number"] != null ? match.Groups["number"].Value : string.Empty;
        }

        /// <summary>
        /// 提取关键词前最近的数字
        /// </summary>
        /// <param name="coreWord">核心词</param>
        /// <returns></returns>1
        public string GetBeforeNumber(string coreWord)
        {
            return GetBeforeNumber(coreWord, roDefault);
        }

        /// <summary>
        /// 提取关键词后最近的数字
        /// </summary>
        /// <param name="coreWord">核心词</param>
        /// <param name="ro">是否区分大小写</param>
        /// <returns></returns>1
        public string GetAfterNumber(string coreWord, RegexOptions ro)
        {
            Match match = Regex.Match(content, "(" + coreWord + ").*?(?<number>\\d+[.．]?\\d*)", ro);
            return match.Groups["number"] != null ? match.Groups["number"].Value : string.Empty;
        }

        /// <summary>
        /// 提取关键词后最近的数字
        /// </summary>
        /// <param name="coreWord">核心词</param>
        /// <returns></returns>1
        public string GetAfterNumber(string coreWord)
        {
            return GetAfterNumber(coreWord, roDefault);
        }


        /// <summary>
        ///  提取文本中的日期字符串
        /// </summary>
        /// <param name="content">截取的内容</param>
        /// <param name="ro">是否区分大小写</param>
        /// <returns></returns>
        public string GetDate(RegexOptions ro)
        {
            string temp = string.Empty;
            Match match = Regex.Match(content, @"(?<year>\d{4})[-/年.．／－\s]\s*(?<month>\d{1,2})[-/月.．／－\s]\s*(?<day>\d{1,2})日?", ro);
            if (!string.IsNullOrEmpty(match.Value))
            {
                temp = string.Format("{0}/{1}/{2}", match.Groups["year"].Value, match.Groups["month"].Value, match.Groups["day"].Value);
            }
            return temp;
        }

        /// <summary>
        ///  提取文本中的日期字符串
        /// </summary>
        /// <param name="content">截取的内容</param>
        /// <returns></returns>
        public string GetDate()
        {
            return GetDate(roDefault);
        }

        /// <summary>
        /// 获取时间(包括时分秒，不包括日期)
        /// </summary>
        /// <param name="strContent">文本</param>
        /// <returns></returns>
        public List<string> GetTime()
        {
            List<string> strList = new List<string>();
            var regex =
                      new Regex(
                          @"(?<hour>\d{1,2})\s*[时点:：]\s*(?<fen>\d{1,2})?\s*[分:：]?\s*(?<miao>\d{1,2})?[秒]?",
                          RegexOptions.Singleline);
            var matchs = regex.Matches(content);
            foreach (Match match in matchs)
            {
                string shi = string.IsNullOrEmpty(match.Groups["hour"].Value) ? "00" : match.Groups["hour"].Value;
                string fen = string.IsNullOrEmpty(match.Groups["fen"].Value) ? "00" : match.Groups["fen"].Value;
                string miao = string.IsNullOrEmpty(match.Groups["miao"].Value) ? "00" : match.Groups["miao"].Value;
                strList.Add((shi + ":" + fen + ":" + miao).UseCHS().ToDBC());
            }
            return strList;
        }

        /// <summary>
        /// 获取日期时间（包括年月日时分秒）
        /// </summary>
        /// <param name="content">文本</param>
        /// <returns></returns>
        public List<string> GetDateTime()
        {
            var list = new List<string>();
            var regex =
            new Regex(
                @"(?<year>\d{4})[-/年.．／－\s]\s*(?<month>\d{1,2})[-/月.．／－\s]\s*(?<day>\d{1,2})日?([\r\n\s]*(?<hour>\d{1,2})?[时点:：](?<fen>\d{1,2})?[分:：]?(?<miao>\d{1,2})?[秒]?)?",
                RegexOptions.Singleline);
            var matchs = regex.Matches(content);
            foreach (Match match in matchs)
            {
                try
                {
                    var sb = new StringBuilder();
                    string shi = string.IsNullOrEmpty(match.Groups["hour"].Value) ? "00" : match.Groups["hour"].Value;
                    string fen = string.IsNullOrEmpty(match.Groups["fen"].Value) ? "00" : match.Groups["fen"].Value;
                    string miao = string.IsNullOrEmpty(match.Groups["miao"].Value) ? "00" : match.Groups["miao"].Value;
                    sb.AppendFormat("{0}/{1}/{2} {3}:{4}:{5}",
                        match.Groups["year"].Value, match.Groups["month"].Value, match.Groups["day"].Value, shi, fen, miao);
                    list.Add((sb.ToString()).UseCHS().ToDBC());
                }
                catch (Exception ex)
                {
                    continue;
                }
            }
            return list;
        }

        /// <summary>
        /// 使用分割词分割文本
        /// </summary>
        /// <param name="splitWord">分割词</param>
        /// <param name="ro">是否区分大小写</param>
        /// <returns></returns>
        public List<string> Split(string splitWord, RegexOptions ro)
        {
            return splitWord == null ? null : Regex.Split(content, splitWord, ro).ToList<string>();
        }

        /// <summary>
        /// 使用分割词分割文本
        /// </summary>
        /// <param name="splitWord">分割词</param>
        /// <returns></returns>
        public List<string> Split(string splitWord)
        {
            return Split(splitWord, roDefault);
        }

        /// <summary>
        /// 按标点符号分割文本（,.;?!，。；？！）
        /// <param name="ro">是否区分大小写</param>
        /// </summary>
        /// <returns></returns>
        public List<string> SplitByPunc(RegexOptions ro)
        {
            return Split(@",|\.|\;|\?|\!|，|。|；|？|！", ro);
        }

        /// <summary>
        /// 按标点符号分割文本（,.;?!，。；？！）
        /// </summary>
        /// <returns></returns>
        public List<string> SplitByPunc()
        {
            return SplitByPunc(roDefault);
        }


        /// <summary>
        /// 使用指定的替换字符串替换与正则表达式模式匹配的所有字符串
        /// </summary>
        /// <param name="regStr">正则表达式</param>
        /// <param name="newWord">替换字符串</param>
        /// <param name="ro">是否区分大小写</param>
        /// <returns></returns>
        public string Replace(string regStr, string replacement, RegexOptions ro)
        {
            return regStr == null ? null : Regex.Replace(content, regStr, replacement, ro);
        }

        /// <summary>
        /// 使用指定的替换字符串替换与正则表达式模式匹配的所有字符串
        /// </summary>
        /// <param name="regStr">正则表达式</param>
        /// <param name="newWord">替换字符串</param>
        /// <param name="ro">是否区分大小写</param>
        /// <returns></returns>
        public string Replace(string regStr, string replacement)
        {
            return Replace(regStr, replacement, roDefault);
        }

        /// <summary>
        /// 将正则表达式模式匹配的所有字符串替换为空
        /// </summary>
        /// <param name="Regstr">正则表达式</param>
        /// <returns></returns>
        public string Replace(string regStr)
        {
            return Replace(regStr, string.Empty, roDefault);
        }

        /// <summary>
        /// 将正则表达式模式匹配的所有字符串替换为空
        /// </summary>
        /// <param name="Regstr">正则表达式</param>
        /// <returns></returns>
        public string Replace(string regStr, RegexOptions ro)
        {
            return Replace(regStr, string.Empty, ro);
        }

        /// <summary>
        /// 是否找到匹配项
        /// </summary>
        /// <param name="pattern">要匹配的字符串</param>
        /// <param name="ro">是否区分大小写</param>
        /// <returns></returns>
        public bool IsMatch(string pattern, RegexOptions ro)
        {
            return pattern == null ? false : Regex.IsMatch(content, pattern, ro);
        }
        /// <summary>
        /// 是否找到匹配项
        /// </summary>
        /// <param name="pattern"></param>
        /// <returns></returns>
        public bool IsMatch(string pattern)
        {
            return IsMatch(pattern, roDefault);

        }
        /// <summary>
        /// 返回正则表达式的第一个匹配项
        /// </summary>
        /// <param name="pattern">要匹配的字符串</param>
        /// <param name="ro">是否区分大小写</param>
        /// <returns></returns>
        public string Match(string pattern, RegexOptions ro)
        {
            return pattern == null ? null : Regex.Match(content, pattern, ro).Value;
        }

        /// <summary>
        /// 返回正则表达式的第一个匹配项
        /// </summary>
        /// <param name="pattern">要匹配的字符串</param>
        /// <returns></returns>
        public string Match(string pattern)
        {
            return Match(pattern, roDefault);
        }

        /// <summary>
        /// 返回正则表达式的所有匹配项
        /// </summary>
        /// <param name="pattern">要匹配的字符串</param>
        /// <param name="ro">是否区分大小写</param>
        /// <returns></returns>
        public MatchCollection Matches(string pattern, RegexOptions ro)
        {
            return pattern == null ? null : Regex.Matches(content, pattern, ro);
        }

        /// <summary>
        /// 返回正则表达式的所有匹配项
        /// </summary>
        /// <param name="pattern">要匹配的字符串</param>
        /// <returns></returns>
        public MatchCollection Matches(string pattern)
        {
            return Matches(pattern, roDefault);
        }
    }
}
