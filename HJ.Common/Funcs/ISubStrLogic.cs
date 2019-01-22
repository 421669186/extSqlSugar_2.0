using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HJ.Common.Funcs
{
    public interface IBegin
    {
        /// <summary>
        /// 定义核心词
        /// </summary>
        /// <param name="coreWord">核心词</param>
        /// <returns></returns>
        ICoreWord coreWord(object coreWord);

        /// <summary>
        /// 包含某些字符
        /// </summary>
        /// <param name="words"></param>
        /// <returns></returns>
        IClude include(string words);

        /// <summary>
        /// 不包含某些字符
        /// </summary>
        /// <param name="words"></param>
        /// <returns></returns>
        IClude exclude(string words);
    }

    public interface ICoreWord
    {
        /// <summary>
        /// 一个组的开始标识
        /// </summary>
        /// <returns></returns>
        IBG bg { get; }

        /// <summary>
        /// 核心词之前
        /// </summary>
        /// <returns></returns>
        IDirect before { get; }

        /// <summary>
        /// 核心词之后
        /// </summary>
        /// <returns></returns>
        IDirect after { get; }

        /// <summary>
        /// 核心词之前且之后（用于前后置词一致或前后截取长度一致的情况）
        /// </summary>
        /// <returns></returns>
        IDirect both { get; }
    }

    public interface IBG
    {
        /// <summary>
        /// 核心词之前
        /// </summary>
        /// <returns></returns>
        IDirect before { get; }

        /// <summary>
        /// 核心词之后
        /// </summary>
        /// <returns></returns>
        IDirect after { get; }

        /// <summary>
        /// 核心词之前且之后（用于前后置词一致或前后截取长度一致的情况）
        /// </summary>
        /// <returns></returns>
        IDirect both { get; }
    }

    public interface IEG
    {
        /// <summary>
        /// 核心词之前
        /// </summary>
        /// <returns></returns>
        IDirect before { get; }

        /// <summary>
        /// 核心词之后
        /// </summary>
        /// <returns></returns>
        IDirect after { get; }

        /// <summary>
        /// 核心词之前且之后（用于前后置词一致或前后截取长度一致的情况）
        /// </summary>
        /// <returns></returns>
        IDirect both { get; }

        /// <summary>
        /// 逻辑结束标识符，执行并返回字符串集合
        /// </summary>
        /// <returns></returns>
        List<string> end { get; }

        /// <summary>
        /// 逻辑结束标识符，执行并返回第一条记录
        /// </summary>
        /// <returns></returns>
        string endStr { get; }

        List<Match> endMatch { get; }

        /// <summary>
        /// 逻辑结束标识符，执行并返回是否不为空
        /// </summary>
        /// <returns></returns>
        bool endBool { get; }

        int endInt { get; }
        double endDouble { get; }
        DateTime endDate { get; }

        /// <summary>
        /// 组之间“且”的关系
        /// </summary>
        /// <returns></returns>
        ILogic and { get; }

        /// <summary>
        /// 组之间“或”的关系
        /// </summary>
        /// <returns></returns>
        ILogic or { get; }
    }

    public interface IDirect
    {
        /// <summary>
        /// 定义前置关键词或后置关键词
        /// </summary>
        /// <param name="keyWord"></param>
        /// <returns></returns>
        IKeyWord keyWord(string keyWord);

        /// <summary>
        /// 定义前置关键词和后置关键词
        /// </summary>
        /// <param name="keyWord"></param>
        /// <returns></returns>
        IKeyWord keyWord(string beforeWord, string afterWord);

        /// <summary>
        /// 核心词往前或往后的截取长度
        /// </summary>
        /// <param name="len"></param>
        /// <returns></returns>
        ILength length(int len);

        ILength length(int beforeLen, int afterLen);

        IMix mix(int beforeLen, string afterWord);

        IMix mix(string beforeWord, int afterLen);

        /// <summary>
        /// 包含某些字符
        /// </summary>
        /// <param name="words"></param>
        /// <returns></returns>
        IClude include(string words);

        /// <summary>
        /// 不包含某些字符
        /// </summary>
        /// <param name="words"></param>
        /// <returns></returns>
        IClude exclude(string words);
    }

    public interface IKeyWord
    {
        /// <summary>
        /// 逻辑结束标识符，执行并返回字符串集合
        /// </summary>
        /// <returns></returns>
        List<string> end { get; }

        /// <summary>
        /// 逻辑结束标识符，执行并返回第一条记录
        /// </summary>
        /// <returns></returns>
        string endStr { get; }

        /// <summary>
        /// 逻辑结束标识符，执行并返回是否不为空
        /// </summary>
        /// <returns></returns>
        bool endBool { get; }

        List<Match> endMatch { get; }

        int endInt { get; }
        double endDouble { get; }
        DateTime endDate { get; }

        /// <summary>
        /// 包含某些字符
        /// </summary>
        /// <param name="words"></param>
        /// <returns></returns>
        IClude include(string words);

        /// <summary>
        /// 不包含某些字符
        /// </summary>
        /// <param name="words"></param>
        /// <returns></returns>
        IClude exclude(string words);

        /// <summary>
        /// 一个组的结束标识
        /// </summary>
        /// <returns></returns>
        IEG eg { get; }

        /// <summary>
        /// 一个组的结束标识
        /// </summary>
        /// <returns></returns>
        IBG bg { get; }

        /// <summary>
        /// 若无后置词或长度不够，截取到最后
        /// </summary>
        /// <returns></returns>
        IProperty toLast { get; }

        /// <summary>
        /// 若无前置词或长度不够，截取到开始
        /// </summary>
        /// <returns></returns>
        IProperty toFirst { get; }

        /// <summary>
        /// 从核心词截取至最近的第N个关键词
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        IProperty wordIndex(int index);

        /// <summary>
        /// 取删除截取的字符串之后的全部内容
        /// </summary>
        /// <returns></returns>
        //IProperty isReverse { get; }

        /// <summary>
        /// 截取至关键词时，核心词优先.
        /// </summary>
        /// <returns></returns>
        IProperty coreFirst { get; }

        /// <summary>
        /// 是否区分大小写或者其它
        /// </summary>
        /// <returns></returns>
        IProperty regexOp(RegexOptions op);

        /// <summary>
        /// 不包含核心词
        /// </summary>
        IProperty withoutCore { get; }

        /// <summary>
        /// 不包含关键词
        /// </summary>
        IProperty withoutKey { get; }

        IProperty ignoreCE { get; }
    }

    public interface ILength
    {
        /// <summary>
        /// 逻辑结束标识符，执行并返回字符串集合
        /// </summary>
        /// <returns></returns>
        List<string> end { get; }

        /// <summary>
        /// 逻辑结束标识符，执行并返回第一条记录
        /// </summary>
        /// <returns></returns>
        string endStr { get; }

        /// <summary>
        /// 逻辑结束标识符，执行并返回是否不为空
        /// </summary>
        /// <returns></returns>
        bool endBool { get; }

        int endInt { get; }
        double endDouble { get; }
        DateTime endDate { get; }

        /// <summary>
        /// 一个组的结束标识
        /// </summary>
        /// <returns></returns>
        IEG eg { get; }

        /// <summary>
        /// 包含某些字符
        /// </summary>
        /// <param name="words"></param>
        /// <returns></returns>
        IClude include(string words);

        /// <summary>
        /// 不包含某些字符
        /// </summary>
        /// <param name="words"></param>
        /// <returns></returns>
        IClude exclude(string words);

        /// <summary>
        /// 若无后置词或长度不够，截取到最后
        /// </summary>
        /// <returns></returns>
        IProperty toLast { get; }

        /// <summary>
        /// 若无前置词或长度不够，截取到开始
        /// </summary>
        /// <returns></returns>
        IProperty toFirst { get; }

        /// <summary>
        /// 截取至关键词时，核心词优先.
        /// </summary>
        /// <returns></returns>
        IProperty coreFirst { get; }

        /// <summary>
        /// 取删除截取的字符串之后的全部内容
        /// </summary>
        /// <returns></returns>
        //IProperty isReverse { get; }

        /// <summary>
        /// 是否区分大小写或者其它
        /// </summary>
        /// <returns></returns>
        IProperty regexOp(RegexOptions op);

        /// <summary>
        /// 不包含核心词
        /// </summary>
        IProperty withoutCore { get; }

        IProperty ignoreCE { get; }
    }

    public interface IMix
    {
        /// <summary>
        /// 逻辑结束标识符，执行并返回字符串集合
        /// </summary>
        /// <returns></returns>
        List<string> end { get; }

        /// <summary>
        /// 逻辑结束标识符，执行并返回第一条记录
        /// </summary>
        /// <returns></returns>
        string endStr { get; }

        /// <summary>
        /// 逻辑结束标识符，执行并返回是否不为空
        /// </summary>
        /// <returns></returns>
        bool endBool { get; }

        List<Match> endMatch { get; }

        int endInt { get; }
        double endDouble { get; }
        DateTime endDate { get; }

        /// <summary>
        /// 包含某些字符
        /// </summary>
        /// <param name="words"></param>
        /// <returns></returns>
        IClude include(string words);

        /// <summary>
        /// 不包含某些字符
        /// </summary>
        /// <param name="words"></param>
        /// <returns></returns>
        IClude exclude(string words);

        /// <summary>
        /// 一个组的结束标识
        /// </summary>
        /// <returns></returns>
        IEG eg { get; }

        /// <summary>
        /// 一个组的结束标识
        /// </summary>
        /// <returns></returns>
        IBG bg { get; }

        /// <summary>
        /// 若无后置词或长度不够，截取到最后
        /// </summary>
        /// <returns></returns>
        IProperty toLast { get; }

        /// <summary>
        /// 若无前置词或长度不够，截取到开始
        /// </summary>
        /// <returns></returns>
        IProperty toFirst { get; }

        /// <summary>
        /// 从核心词截取至最近的第N个关键词
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        IProperty wordIndex(int index);

        /// <summary>
        /// 取删除截取的字符串之后的全部内容
        /// </summary>
        /// <returns></returns>
        //IProperty isReverse { get; }

        /// <summary>
        /// 截取至关键词时，核心词优先.
        /// </summary>
        /// <returns></returns>
        IProperty coreFirst { get; }

        /// <summary>
        /// 是否区分大小写或者其它
        /// </summary>
        /// <returns></returns>
        IProperty regexOp(RegexOptions op);

        /// <summary>
        /// 不包含核心词
        /// </summary>
        IProperty withoutCore { get; }

        /// <summary>
        /// 不包含关键词
        /// </summary>
        IProperty withoutKey { get; }

        IProperty ignoreCE { get; }
    }

    public interface IClude
    {
        /// <summary>
        /// 一个组的结束标识
        /// </summary>
        /// <returns></returns>
        IEG eg { get; }

        /// <summary>
        /// 逻辑结束标识符，执行并返回字符串集合
        /// </summary>
        /// <returns></returns>
        List<string> end { get; }

        /// <summary>
        /// 逻辑结束标识符，执行并返回第一条记录
        /// </summary>
        /// <returns></returns>
        string endStr { get; }

        /// <summary>
        /// 逻辑结束标识符，执行并返回是否不为空
        /// </summary>
        /// <returns></returns>
        bool endBool { get; }

        int endInt { get; }
        double endDouble { get; }
        DateTime endDate { get; }

        List<Match> endMatch { get; }

        /// <summary>
        /// 包含某些字符
        /// </summary>
        /// <param name="words"></param>
        /// <returns></returns>
        IClude include(string words);

        /// <summary>
        /// 不包含某些字符
        /// </summary>
        /// <param name="words"></param>
        /// <returns></returns>
        IClude exclude(string words);

        /// <summary>
        /// 若无后置词或长度不够，截取到最后
        /// </summary>
        /// <returns></returns>
        IProperty toLast { get; }

        /// <summary>
        /// 若无前置词或长度不够，截取到开始
        /// </summary>
        /// <returns></returns>
        IProperty toFirst { get; }

        /// <summary>
        /// 从核心词截取至最近的第N个关键词
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        IProperty wordIndex(int index);

        /// <summary>
        /// 是否区分大小写或者其它
        /// </summary>
        /// <returns></returns>
        IProperty regexOp(RegexOptions op);

        IProperty ignoreCE { get; }
    }

    public interface IProperty
    {
        /// <summary>
        /// 一个组的结束标识
        /// </summary>
        /// <returns></returns>
        IEG eg { get; }

        /// <summary>
        /// 逻辑结束标识符，执行并返回字符串集合
        /// </summary>
        /// <returns></returns>
        List<string> end { get; }

        /// <summary>
        /// 逻辑结束标识符，执行并返回第一条记录
        /// </summary>
        /// <returns></returns>
        string endStr { get; }

        /// <summary>
        /// 逻辑结束标识符，执行并返回是否不为空
        /// </summary>
        /// <returns></returns>
        bool endBool { get; }

        List<Match> endMatch { get; }

        int endInt { get; }
        double endDouble { get; }
        DateTime endDate { get; }

        /// <summary>
        /// 若无后置词或长度不够，截取到最后
        /// </summary>
        /// <returns></returns>
        IProperty toLast { get; }

        /// <summary>
        /// 若无前置词或长度不够，截取到开始
        /// </summary>
        /// <returns></returns>
        IProperty toFirst { get; }

        /// <summary>
        /// 截取至关键词时，核心词优先.
        /// </summary>
        /// <returns></returns>
        IProperty coreFirst { get; }

        /// <summary>
        /// 是否区分大小写或者其它
        /// </summary>
        /// <returns></returns>
        IProperty regexOp(RegexOptions op);

        /// <summary>
        /// 不包含核心词
        /// </summary>
        IProperty withoutCore { get; }

        /// <summary>
        /// 不包含关键词
        /// </summary>
        IProperty withoutKey { get; }

        /// <summary>
        /// 从核心词截取至最近的第N个关键词
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        IProperty wordIndex(int index);


        IProperty ignoreCE { get; }
    }

    public interface ILogic
    {
        /// <summary>
        /// 一个组的开始标识
        /// </summary>
        /// <returns></returns>
        IBG bg { get; }
    }
}