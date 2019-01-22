using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HJ.Common.Funcs
{
    public interface IRegexMethod
    {
        /// <summary>
        /// 是否包含某关键词
        /// </summary>
        /// <param name="keyWord"></param>
        /// <returns></returns>
        bool Include(string keyWord);

        /// <summary>
        /// 是否包含关键词
        /// </summary>
        /// <param name="keyWord"></param>
        /// <param name="ro"></param>
        /// <returns></returns>
        bool Include(string keyWord, RegexOptions ro);

        /// <summary>
        /// 同时包含核心词和关键词
        /// </summary>
        /// <param name="kcoreWord">核心词</param>
        /// <param name="keyWord">关键词</param>
        /// <returns></returns>
        bool Include(string coreWord, string keyWord);

        /// <summary>
        /// 是否排除某关键词
        /// </summary>
        /// <param name="keyWord"></param>
        /// <returns></returns>
        bool Exclude(string keyWord);

        bool Exclude(string keyWord, RegexOptions ro);

        /// <summary>
        /// 包含且排除
        /// </summary>
        /// <param name="exclude">排除次</param>
        /// <param name="contain">包含词</param>
        /// <param name="ro">是否区分大小写</param>
        /// <returns></returns>
        bool InExclude(string includeWord, string excludeWord, RegexOptions ro);

        /// <summary>
        /// 是否包含某关键词且排除某关键词
        /// </summary>
        /// <param name="includeWord"></param>
        /// <param name="excludeWord"></param>
        /// <returns></returns>
        bool InExclude(string includeWord, string excludeWord);

        /// <summary>
        /// 核心词之前是否包含某关键词
        /// </summary>
        /// <param name="coreWord"></param>
        /// <param name="keyWord"></param>
        /// <returns></returns>
        bool BeforeInclude(string coreWord, string keyWord);

        /// <summary>
        /// 核心词之前是否包含某关键词
        /// </summary>
        /// <param name="keyWord">前置词</param>
        /// <param name="coreWord">核心词</param>
        /// <param name="ro">是否区分大小写</param>
        /// <returns></returns>
        bool BeforeInclude(string coreWord, string keyWord, RegexOptions ro);

        /// <summary>
        /// 核心词之前是否排除某关键词
        /// </summary>
        /// <param name="coreWord"></param>
        /// <param name="keyWord"></param>
        /// <returns></returns>
        bool BeforeExclude(string coreWord, string keyWord);

        /// <summary>
        /// 核心词之后是否包含某关键词
        /// </summary>
        /// <param name="coreWord"></param>
        /// <param name="keyWord"></param>
        /// <returns></returns>
        bool AfterInclude(string coreWord, string keyWord);

        /// <summary>
        /// 判断后包含
        /// </summary>
        /// <param name="coreWord">核心词</param>
        /// <param name="keyWord">后置词</param>
        /// <param name="ro">是否区分大小写</param>
        /// <returns></returns>
        bool AfterInclude(string coreWord, string keyWord, RegexOptions ro);

        /// <summary>
        /// 判断后不包含
        /// </summary>
        /// <param name="coreWord">核心词</param>
        /// <param name="keyWord">后置词</param>
        /// <param name="ro">是否区分大小写</param>
        /// <returns></returns>
        bool AfterExclude(string coreWord, string keyWord, RegexOptions ro);

        /// <summary>
        /// 判断后不包含
        /// </summary>
        /// <param name="coreWord"></param>
        /// <param name="keyWord"></param>
        /// <returns></returns>
        bool AfterExclude(string coreWord, string keyWord);

        /// <summary>
        /// 核心词之前是否为某关键词
        /// </summary>
        /// <param name="coreWord">核心词</param>
        /// <param name="keyWord">关键词</param>
        /// <param name="ro">是否区分大小写</param>
        /// <returns></returns>
        bool BeforeIs(string coreWord, string keyWord, RegexOptions ro);

        /// <summary>
        /// 核心词之前是否为某关键词
        /// </summary>
        /// <param name="coreWord">核心词</param>
        /// <param name="keyWord">关键词</param>
        /// <returns></returns>
        bool BeforeIs(string coreWord, string keyWord);

        /// <summary>
        /// 核心词之前是否不为某关键词
        /// </summary>
        /// <param name="coreWord">核心词</param>
        /// <param name="keyWord">关键词</param>
        /// <param name="ro">是否区分大小写</param>
        /// <returns></returns>
        bool BeforeIsnot(string coreWord, string keyWord, RegexOptions ro);

        /// <summary>
        /// 核心词之前是否不为某关键词
        /// </summary>
        /// <param name="coreWord">核心词</param>
        /// <param name="keyWord">关键词</param>
        /// <returns></returns>
        bool BeforeIsnot(string coreWord, string keyWord);

        /// <summary>
        /// 核心词之后是否为某关键词
        /// </summary>
        /// <param name="coreWord">核心词</param>
        /// <param name="keyWord">关键词</param>
        /// <param name="ro">是否区分大小写</param>
        /// <returns></returns>
        bool AfterIs(string coreWord, string keyWord, RegexOptions ro);

        /// <summary>
        /// 核心词之后是否为某关键词
        /// </summary>
        /// <param name="coreWord"></param>
        /// <param name="keyWord"></param>
        /// <returns></returns>
        bool AfterIs(string coreWord, string keyWord);

        /// <summary>
        /// 核心词之后是否不为某关键词
        /// </summary>
        /// <param name="coreWord">核心词</param>
        /// <param name="keyWord">关键词</param>
        /// <param name="ro">是否区分大小写</param>
        /// <returns></returns>
        bool AfterIsnot(string coreWord, string keyWord, RegexOptions ro);
        /// <summary>
        /// 核心词之后是否不为某关键词
        /// </summary>
        /// <param name="coreWord"></param>
        /// <param name="keyWord"></param>
        /// <returns></returns>
        bool AfterIsnot(string coreWord, string keyWord);

        /// <summary>
        /// 核心词向前截取到关键词
        /// </summary>
        /// <param name="beforeWord">前置词</param>
        /// <param name="coreWord">核心词</param>
        /// <param name="ro">是否区分大小写</param>
        /// <returns></returns>
        string CutBeforeWord(string coreWord, string keyWord, RegexOptions ro);

        /// <summary>
        /// 截取核心词到之前最近的关键词
        /// </summary>
        /// <param name="coreWord">核心词</param>
        /// <param name="keyWord">关键词</param>
        /// <returns></returns>
        string CutBeforeWord(string coreWord, string keyWord);

        /// <summary>
        /// 核心词向后截取到关键词
        /// </summary>
        /// <param name="coreWord">核心词</param>
        /// <param name="afterWord">后置词</param>
        /// <param name="ro">是否区分大小写</param>
        /// <returns></returns>
        string CutAfterWord(string coreWord, string keyWord, RegexOptions ro);

        /// <summary>
        /// 截取核心词到之后最近的关键词
        /// </summary>
        /// <param name="coreWord">核心词</param>
        /// <param name="keyWord">关键词</param>
        /// <returns></returns>
        string CutAfterWord(string coreWord, string keyWord);

        /// <summary>
        /// 核心词前后最近的关键词
        /// </summary>
        /// <param name="beforeWord">前置词</param>
        /// <param name="coreWord">核心词</param>
        /// <param name="afterWord">后置词</param>
        /// <param name="ro">是否区分大小写</param>
        /// <returns></returns>
        string CutBeforeAfterWord(string coreWord, string beforeWord, string afterWord, RegexOptions ro);

        /// <summary>
        /// 核心词向前后截取至最近的关键词
        /// </summary>
        /// <param name="coreWord"></param>
        /// <param name="keyWord"></param>
        /// <returns></returns>
        string CutBeforeAfterWord(string coreWord, string beforeWord, string afterWord);

        /// <summary>
        /// 核心词向前截取n个字符
        /// </summary>
        /// <param name="coreWord">核心词</param>
        /// <param name="length">截取长度</param>
        /// <param name="ro">是否区分大小写</param>
        /// <returns></returns>
        string CutBeforeLength(string coreWord, int len, RegexOptions ro);

        /// <summary>
        /// 核心词向前截取的n个字符
        /// </summary>
        /// <param name="coreWord"></param>
        /// <param name="keyWord"></param>
        /// <returns></returns>
        string CutBeforeLength(string coreWord, int len);

        /// <summary>
        ///  核心词向后截取n个字符
        /// </summary>
        /// <param name="coreWord">核心词</param>
        /// <param name="length">截取长度</param>
        /// <param name="ro">是否区大小写</param>
        /// <returns></returns>
        string CutAfterLength(string coreWord, int len, RegexOptions ro);

        /// <summary>
        /// 核心词向后截取的n个字符
        /// </summary>
        /// <param name="coreWord"></param>
        /// <param name="keyWord"></param>
        /// <returns></returns>
        string CutAfterLength(string coreWord, int len);

        /// <summary>
        /// 核心词向前后各截取n个字符
        /// </summary>
        /// <param name="coreWord">核心词</param>
        /// <param name="beforeLength"></param>
        /// <param name="afterLength"></param>
        /// <param name="ro">是否区大小写</param>
        /// <returns></returns>
        string CutBeforeAfterLength(string coreWord, int beforeLength, int afterLength, RegexOptions ro);

        /// <summary>
        /// 核心词向前后截取长度
        /// </summary>
        /// <param name="coreWord"></param>
        /// <param name="keyWord"></param>
        /// <returns></returns>
        string CutBeforeAfterLength(string coreWord, int beforeLength, int afterLength);

        /// <summary>
        /// 提取文本中的数值
        /// </summary>
        /// <param name="ro">是否区分大小写</param>
        /// <returns></returns>
        string GetNumber(RegexOptions ro);

        /// <summary>
        /// 提取文本中的数值
        /// </summary>
        /// <returns></returns>
        string GetNumber();

        /// <summary>
        /// 提取文本中的带格式的数值（数字格式为×××|***|XXX|xxx ）
        /// <param name="ro">是否区分大小写</param>
        /// </summary>
        /// <returns></returns>
        string GetNumber(char[] splitChar, RegexOptions ro);

        /// <summary>
        /// 提取文本中的数值
        /// </summary>
        /// <returns></returns>
        string GetNumber(char[] splitChar);

        /// <summary>
        /// 提取关键词前最近的数字
        /// </summary>
        /// <param name="coreWord">核心词</param>
        /// <param name="ro">是否区分大小写</param>
        /// <returns></returns>
        string GetBeforeNumber(string coreWord, RegexOptions ro);

        /// <summary>
        /// 提取核心词前最近的数字
        /// </summary>
        /// <param name="coreWord"></param>
        /// <returns></returns>
        string GetBeforeNumber(string coreWord);

        /// <summary>
        /// 提取关键词后最近的数字
        /// </summary>
        /// <param name="coreWord">核心词</param>
        /// <param name="ro">是否区分大小写</param>
        /// <returns></returns>1
        string GetAfterNumber(string coreWord, RegexOptions ro);

        /// <summary>
        /// 提取核心词后最近的数字
        /// </summary>
        /// <param name="coreWord"></param>
        /// <returns></returns>
        string GetAfterNumber(string coreWord);

        /// <summary>
        ///  提取文本中的日期字符串
        /// </summary>
        /// <param name="content">截取的内容</param>
        /// <param name="ro">是否区分大小写</param>
        /// <returns></returns>
        string GetDate(RegexOptions ro);

        /// <summary>
        /// 提取文本中的日期
        /// </summary>
        /// <returns></returns>
        string GetDate();

        List<string> GetTime();

        List<string> GetDateTime();

        /// <summary>
        /// 使用分割词分割文本
        /// </summary>
        /// <param name="splitWord">分割词</param>
        /// <param name="ro">是否区分大小写</param>
        /// <returns></returns>
        List<string> Split(string splitWord, RegexOptions ro);

        /// <summary>
        /// 使用分割词分割文本
        /// </summary>
        /// <param name="splitWord">分割词</param>
        /// <returns></returns>
        List<string> Split(string splitWord);

        /// <summary>
        /// 按标点符号分割文本（,.;?!，。；？！）
        /// <param name="ro">是否区分大小写</param>
        /// </summary>
        /// <returns></returns>
        List<string> SplitByPunc(RegexOptions ro);

        /// <summary>
        /// 按标点符号分割文本（,.;?!，。；？！）
        /// </summary>
        /// <returns></returns>
        List<string> SplitByPunc();

        /// <summary>
        /// 使用指定的替换字符串替换与正则表达式模式匹配的所有字符串
        /// </summary>
        /// <param name="regStr">正则表达式</param>
        /// <param name="newWord">替换字符串</param>
        /// <param name="ro">是否区分大小写</param>
        /// <returns></returns>
        string Replace(string regStr, string replacement, RegexOptions ro);

        /// <summary>
        /// 使用指定的替换字符串替换与正则表达式模式匹配的所有字符串
        /// </summary>
        /// <param name="regStr">正则表达式</param>
        /// <param name="newWord">替换字符串</param>
        /// <param name="ro">是否区分大小写</param>
        /// <returns></returns>
        string Replace(string regStr, string replacement);

        /// <summary>
        /// 将正则表达式模式匹配的所有字符串替换为空
        /// </summary>
        /// <param name="Regstr">正则表达式</param>
        /// <returns></returns>
        string Replace(string regStr);

        /// <summary>
        /// 是否找到匹配项
        /// </summary>
        /// <param name="pattern">要匹配的字符串</param>
        /// <param name="ro">是否区分大小写</param>
        /// <returns></returns>
        bool IsMatch(string pattern, RegexOptions ro);

        /// <summary>
        /// 是否找到匹配项
        /// </summary>
        /// <param name="pattern">要匹配的字符串</param>
        /// <returns></returns>
        bool IsMatch(string pattern);

        /// <summary>
        /// 返回正则表达式的第一个匹配项
        /// </summary>
        /// <param name="pattern">要匹配的字符串</param>
        /// <param name="ro">是否区分大小写</param>
        /// <returns></returns>
        string Match(string pattern, RegexOptions ro);

        /// <summary>
        /// 返回正则表达式的第一个匹配项
        /// </summary>
        /// <param name="pattern">要匹配的字符串</param>
        /// <returns></returns>
        string Match(string pattern);

        /// <summary>
        /// 返回正则表达式的所有匹配项
        /// </summary>
        /// <param name="pattern">要匹配的字符串</param>
        /// <param name="ro">是否区分大小写</param>
        /// <returns></returns>
        MatchCollection Matches(string pattern, RegexOptions ro);

        /// <summary>
        /// 返回正则表达式的所有匹配项
        /// </summary>
        /// <param name="pattern">要匹配的字符串</param>
        /// <returns></returns>
        MatchCollection Matches(string pattern);

        List<string> GetNumberList();
    }
}
