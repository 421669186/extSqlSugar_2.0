using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using HJ.Common.Trans;

namespace HJ.Common.Funcs
{
    public class UnitFuns : IBegin, IBG, ICoreWord, IEG, IDirect, IKeyWord, ILength, IProperty, ILogic, IClude, IMix
    {
        private List<OperateInfo> operateList = new List<OperateInfo>();
        private List<string> strList;

        public UnitFuns(List<string> list)
        {
            strList = list;
        }

        /// <summary>
        /// 一个组的开始标识
        /// </summary>
        /// <returns></returns>
        public IBG bg
        {
            get
            {
                operateList.Add(new OperateInfo("begingroup", null, "Expression"));
                return this;
            }
        }

        /// <summary>
        /// 一个组的结束标识
        /// </summary>
        /// <returns></returns>
        public IEG eg
        {
            get
            {
                operateList.Add(new OperateInfo("endgroup", null, "Expression"));
                return this;
            }
        }

        /// <summary>
        /// 组之间“且”的关系
        /// </summary>
        /// <returns></returns>
        public ILogic and
        {
            get
            {
                operateList.Add(new OperateInfo("op", "and", "Logic"));
                return this;
            }
        }

        /// <summary>
        /// 组之间“或”的关系
        /// </summary>
        /// <returns></returns>
        public ILogic or
        {
            get
            {
                operateList.Add(new OperateInfo("op", "or", "Logic"));
                return this;
            }
        }

        /// <summary>
        /// 定义核心词
        /// </summary>
        /// <param name="coreWord">核心词</param>
        /// <returns></returns>
        public ICoreWord coreWord(object coreWord)
        {
            operateList.Add(new OperateInfo("coreword", coreWord, "Unit"));
            return this;
        }

        /// <summary>
        /// 核心词之前
        /// </summary>
        /// <returns></returns>
        public IDirect before
        {
            get
            {
                operateList.Add(new OperateInfo("direction", "before", "Unit"));
                return this;
            }
        }

        /// <summary>
        /// 核心词之后
        /// </summary>
        /// <returns></returns>
        public IDirect after
        {
            get
            {
                operateList.Add(new OperateInfo("direction", "after", "Unit"));
                return this;
            }
        }

        /// <summary>
        /// 核心词之前且之后（用于前后置词一致或前后截取长度一致的情况）
        /// </summary>
        /// <returns></returns>
        public IDirect both
        {
            get
            {
                operateList.Add(new OperateInfo("direction", "both", "Unit"));
                return this;
            }
        }

        /// <summary>
        /// 定义前置关键词或后置关键词
        /// </summary>
        /// <param name="keyWord"></param>
        /// <returns></returns>
        public IKeyWord keyWord(string keyWord)
        {
            operateList.Add(new OperateInfo("keyword", keyWord, "Unit"));
            return this;
        }

        /// <summary>
        /// 定义前置关键词或后置关键词
        /// </summary>
        /// <param name="keyWord"></param>
        /// <returns></returns>
        public IKeyWord keyWord(string beforeWord, string afterWord)
        {
            operateList.Add(new OperateInfo("beforeword", beforeWord, "Unit"));
            operateList.Add(new OperateInfo("afterword", afterWord, "Unit"));
            return this;
        }

        /// <summary>
        /// 核心词往前或往后的截取长度
        /// </summary>
        /// <param name="len"></param>
        /// <returns></returns>
        public ILength length(int len)
        {
            operateList.Add(new OperateInfo("length", len.ToString(), "Unit"));
            return this;
        }

        /// <summary>
        /// 核心词往前或往后的截取长度
        /// </summary>
        /// <param name="len"></param>
        /// <returns></returns>
        public ILength length(int beforeLen, int afterLen)
        {
            operateList.Add(new OperateInfo("beforelength", beforeLen, "Unit"));
            operateList.Add(new OperateInfo("afterlength", afterLen, "Unit"));
            return this;
        }

        public IMix mix(int beforeLen, string afterWord)
        {
            operateList.Add(new OperateInfo("beforelength", beforeLen, "Unit"));
            operateList.Add(new OperateInfo("afterword", afterWord, "Unit"));
            return this;
        }

        public IMix mix(string beforeWord, int afterLen)
        {
            operateList.Add(new OperateInfo("beforeword", beforeWord, "Unit"));
            operateList.Add(new OperateInfo("afterlength", afterLen, "Unit"));
            return this;
        }

        /// <summary>
        /// 包含某些字符
        /// </summary>
        /// <param name="words"></param>
        /// <returns></returns>
        public IClude include(string words)
        {
            operateList.Add(new OperateInfo("include", words, "Unit"));
            return this;
        }

        /// <summary>
        /// 不包含某些字符
        /// </summary>
        /// <param name="words"></param>
        /// <returns></returns>
        public IClude exclude(string words)
        {
            operateList.Add(new OperateInfo("exclude", words, "Unit"));
            return this;
        }

        /// <summary>
        /// 是否区分大小写或者其它
        /// </summary>
        /// <returns></returns>
        public IProperty regexOp(RegexOptions op)
        {
            operateList.Add(new OperateInfo("ro", op, "Property"));
            return this;
        }

        /// <summary>
        /// 若无后置词或长度不够，截取到最后
        /// </summary>
        /// <returns></returns>
        public IProperty toLast
        {
            get
            {
                operateList.Add(new OperateInfo("toLast", "true", "Property"));
                return this;
            }
        }

        /// <summary>
        /// 若无前置词或长度不够，截取到开始
        /// </summary>
        /// <returns></returns>
        public IProperty toFirst
        {
            get
            {
                operateList.Add(new OperateInfo("toFirst", "true", "Property"));
                return this;
            }
        }

        public IProperty withoutCore
        {
            get
            {
                operateList.Add(new OperateInfo("withoutCore", "true", "Property"));
                return this;
            }
        }

        public IProperty withoutKey
        {
            get
            {
                operateList.Add(new OperateInfo("withoutKey", "true", "Property"));
                return this;
            }
        }

        /// <summary>
        /// 截取至关键词时，核心词优先.
        /// </summary>
        /// <returns></returns>
        public IProperty coreFirst
        {
            get
            {
                operateList.Add(new OperateInfo("coreFirst", "true", "Property"));
                return this;
            }
        }

        /// <summary>
        /// 从核心词截取至最近的第N个关键词
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public IProperty wordIndex(int index)
        {
            operateList.Add(new OperateInfo("wordIndex", index.ToString(), "Property"));
            return this;
        }

        public IProperty ignoreCE
        {
            get
            {
                operateList.Add(new OperateInfo("ignoreCE", "true", "Property"));
                return this;
            }
        }

        /// <summary>
        /// 逻辑结束标识符，执行并返回字符串集合
        /// </summary>
        /// <returns></returns>
        public List<string> end
        {
            get
            {
                ChainAnalyzer ca = new ChainAnalyzer(operateList);
                Expression ex = ca.Analyze();
                List<string> result = new List<string>();
                strList.ForEach(content => result.AddRange(ex.DeepCopy<Expression>().interpret<string>(content)));
                return result;
            }
        }

        public List<Match> endMatch
        {
            get
            {
                ChainAnalyzer ca = new ChainAnalyzer(operateList);
                Expression ex = ca.Analyze();
                ex.isGetMatch = true;
                List<Match> result = new List<Match>();
                strList.ForEach(content => result.AddRange(ex.DeepCopy<Expression>().interpret<Match>(content)));
                return result;
            }
        }

        /// <summary>
        /// 逻辑结束标识符，执行并返回第一条记录
        /// </summary>
        /// <returns></returns>
        public string endStr
        {
            get
            {
                List<string> list = end;
                if (list != null && list.Count > 0)
                    return list[0];
                else
                    return string.Empty;
            }
        }

        /// <summary>
        /// 逻辑结束标识符，执行并返回是否不为空
        /// </summary>
        /// <returns></returns>
        public bool endBool
        {
            get
            {
                bool flag = false;
                List<string> list = end;
                if (list != null)
                    flag = list.Count > 0;
                return flag;
            }
        }

        public int endInt
        {
            get
            {
                List<string> list = end;
                if (list != null && list.Count > 0)
                    return list[0].UseReg().GetNumber().ToInt();
                else
                    return -1;
            }
        }

        public double endDouble
        {
            get
            {
                List<string> list = end;
                if (list != null && list.Count > 0)
                    return list[0].UseReg().GetNumber().ToDouble();
                else
                    return -1;
            }
        }

        public DateTime endDate
        {
            get
            {
                List<string> list = end;
                if (list != null && list.Count > 0)
                    return list[0].UseReg().GetDate().ToDate();
                else
                    return DateTime.MinValue;
            }
        }
    }
}
