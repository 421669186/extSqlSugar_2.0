using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace HJ.Common.Funcs
{
    public static class ImplFunc
    {
        #region lcy截取方法
        /// <summary>
        /// 只截取两个字符串之间的内容
        /// </summary>
        /// <param name="content">源字符串</param>
        /// <param name="Qian">前置词</param>
        /// <param name="Hou">后置词</param>
        /// <param name="reg_optionQ">前置词正则匹配选项</param>
        /// <param name="reg_optionH">后置词正则匹配选项</param>
        /// <returns>返回截取的字符串</returns>
        public static string CutStartAndEndNew(string content, string Qian, string Hou, RegexOptions reg_optionQ = RegexOptions.Compiled | RegexOptions.IgnoreCase, RegexOptions reg_optionH = RegexOptions.Compiled | RegexOptions.IgnoreCase)
        {
            string empty = string.Empty;
            string strCut = string.Empty;
            if (string.IsNullOrEmpty(content))
                return empty;
            if (!Regex.IsMatch(content, Qian, reg_optionQ))
                return empty;

            var matcheQian = Regex.Match(content, Qian, reg_optionQ);
            if (matcheQian.Index >= 0)
                strCut = content.Substring(matcheQian.Index);

            if (!Regex.IsMatch(strCut, Hou, reg_optionH))
                return empty;

            var matcheHou = Regex.Match(strCut, Hou, reg_optionH);

            if (matcheHou.Index > 0)
                strCut = strCut.Substring(0, matcheHou.Index);

            return strCut;
        }
        public static string CutStartAndOrEndNew2(string content, string Qian, string Hou, RegexOptions reg_optionQ = RegexOptions.Compiled | RegexOptions.IgnoreCase, RegexOptions reg_optionH = RegexOptions.Compiled | RegexOptions.IgnoreCase, bool blBefore = false)
        {
            string empty = string.Empty;
            if (string.IsNullOrEmpty(content))//判断源数据是否为空
                return empty;
            if (!Regex.IsMatch(content, Qian))//是否包含前置词
                return empty;

            var matcheQian = Regex.Match(content, Qian, reg_optionQ);
            if (matcheQian.Index >= 0)
                empty = content.Substring(matcheQian.Index);

            if (blBefore)
                return empty;

            empty = empty.Replace(matcheQian.Value, "");//去除前关键词

            var matcheHou = Regex.Match(empty, Hou, reg_optionH);

            if (matcheHou.Index > 0)
                empty = empty.Substring(0, matcheHou.Index);

            return empty;
        }
        #endregion
        #region 截取方法
        #region 截取核心词至（前后核心词）之间的语句,排空但不排除重复语句，切割成语句集合(CutYuJuHXC)
        /// <summary>
        /// 截取核心词至（前后核心词）之间的语句,排空但不排除重复语句，切割成语句集合
        /// </summary>
        /// <param name="strHx">核心词“以|隔开”</param>
        /// <param name="content">被提取内容</param>
        /// <param name="ro">是否区分大小写</param>
        /// <returns></returns>
        public static List<string> CutYuJuHXC(string strHx, string content, RegexOptions ro)
        {
            var result = new List<string>();
            //核心词
            var regHx = new Regex(strHx, ro);
            //一个核心词位置
            var HxPosition = -1;
            var hxMatchs = regHx.Matches(content); //检索关键词

            for (int i = 0; i < hxMatchs.Count; i++)
            {
                string strCut = "";
                string strCutL = "";
                string strCutR = "";
                HxPosition = hxMatchs[i].Index;//核心词的位置
                var HxPositionNext = -1;
                var hxLenth = hxMatchs[i].Length;
                var HxPositionForword = -1;
                var hxLenthForword = -1;
                if (i == 0)
                {
                    strCutL = content.Substring(0, HxPosition);
                    if (i != hxMatchs.Count - 1)//不是最后一个
                    {
                        HxPositionNext = hxMatchs[i + 1].Index;
                        strCutR = content.Substring(HxPosition + hxLenth, HxPositionNext - HxPosition - hxLenth);
                    }
                    else//是最后一个
                    {
                        strCutR = content.Substring(HxPosition + hxLenth);
                    }
                }
                else
                {
                    HxPositionForword = hxMatchs[i - 1].Index;
                    hxLenthForword = hxMatchs[i - 1].Length;
                    strCutL = content.Substring(HxPositionForword + hxLenthForword, HxPosition - HxPositionForword - hxLenthForword);

                    if (i != hxMatchs.Count - 1)//不是最后一个
                    {
                        HxPositionNext = hxMatchs[i + 1].Index;
                        strCutR = content.Substring(HxPosition + hxLenth, HxPositionNext - HxPosition - hxLenth);
                    }
                    else//是最后一个
                    {
                        strCutR = content.Substring(HxPosition + hxLenth);
                    }
                }
                strCut = strCutL + hxMatchs[i].Value + strCutR;//前字符串+核心词+后字符串
                if (!string.IsNullOrEmpty(strCut))
                    result.Add(strCut);
            }

            return result;
        }
        /// <summary>
        /// 截取核心词至（前后核心词）之间的语句,排空但不排除重复语句，切割成语句集合(默认区分大小写)
        /// </summary>
        /// <param name="strHx">核心词“以|隔开</param>
        /// <param name="content">被提取内容</param>
        /// <returns></returns>
        public static List<string> CutYuJuHXC(string strHx, string content)
        {
            return CutYuJuHXC(strHx, content, RegexOptions.None);
        }
        #endregion
        #region 截取核心词至(前置词和后置词)之间的切割成语句(前后置词优先\不排除重复语句)(CutYuJuHQHC)
        /// <summary>
        /// 截取核心词至(前置词和后置词)之间的切割成语句(前后置词优先\不排除重复语句)
        /// </summary>
        /// <param name="strHx">核心词“以|隔开”</param>
        ///<param name="strHxQ">前置词“以|隔开”</param> 
        /// <param name="strHxH">后置词“以|隔开”</param>
        /// <param name="content">被提取内容</param>
        /// <param name="ro">是否区分大小写</param>
        /// <returns></returns>
        public static string CutYuJuHQHC(string strHx, string strHxQ, string strHxH, string content, RegexOptions ro)
        {
            string str = "";
            //核心词
            var regHx = new Regex(strHx, ro);
            var regHxQ = new Regex(strHxQ, ro);
            var regHxH = new Regex(strHxH, ro);
            //一个核心词位置
            var HxPosition = -1;
            string strCut = "";
            string strCutL = "";
            string strCutR = "";
            var hxMatchs = regHx.Matches(content); //检索关键词
            HxPosition = hxMatchs[0].Index;//核心词的位置
            strCutL = content.Substring(0, HxPosition);
            strCutR = content.Substring(HxPosition, content.Length - HxPosition);

            var hxMatchsQ = regHxQ.Matches(strCutL); //检索关键词
            var hxMatchsH = regHxH.Matches(strCutR); //检索关键词
            if (hxMatchsQ.Count > 0)
            {
                strCutL = strCutL.Substring(hxMatchsQ[hxMatchsQ.Count - 1].Index, strCutL.Length - hxMatchsQ[hxMatchsQ.Count - 1].Index);
            }
            if (hxMatchsH.Count > 0)
            {
                strCutR = strCutR.Substring(0, hxMatchsH[0].Index + hxMatchsH[0].Value.Length);
            }
            str = strCutL + strCutR;

            return str;
        }
        /// <summary>
        /// 截取核心词至(前置词和后置词)之间的切割成语句(前后置词优先\不排除重复语句\默认区分大小写)
        /// </summary>
        /// <param name="strHx">核心词“以|隔开</param>
        /// <param name="strHxQ">前置词“以|隔开</param>
        /// <param name="strHxH">后置词“以|隔开</param>
        /// <param name="content">被提取内容</param>
        /// <returns></returns>
        public static string CutYuJuHQHC(string strHx, string strHxQ, string strHxH, string content)
        {
            return CutYuJuHQHC(strHx, strHxQ, strHxH, content, RegexOptions.None);
        }
        #endregion
        #region 截取核心词(至前置词及后置词)之间切割成语句集合(前后词优先\不排除重复)(CutYuJuHqhB)
        /// <summary>
        /// 截取核心词(至前置词及后置词)之间切割成语句集合(前后词优先\不排除重复)
        /// </summary>
        /// <param name="strHx">核心词“以|隔开”</param>
        ///<param name="strHxQ">前置词“以|隔开”</param> 
        /// <param name="strHxH">后置词“以|隔开”</param>
        /// <param name="content">被提取内容</param>
        /// <param name="ro">是否区分大小写</param>
        /// <returns></returns>
        public static List<string> CutYuJuHqhB(string strHx, string strHxQ, string strHxH, string content, RegexOptions ro)
        {
            var result = new List<string>();
            //核心词
            var regHx = new Regex(strHx, ro);
            var regHxQ = new Regex(strHxQ, ro);
            var regHxH = new Regex(strHxH, ro);
            //一个核心词位置
            var HxPosition = -1;
            var hxMatchs = regHx.Matches(content); //检索关键词

            for (int i = 0; i < hxMatchs.Count; i++)
            {
                HxPosition = hxMatchs[i].Index;//核心词的位置
                var hxLenth = hxMatchs[i].Length;
                string contentTempL = content.Substring(0, HxPosition);
                string contentTempR = content.Substring(HxPosition + hxLenth);
                var hxMatchsQ = regHxQ.Matches(contentTempL); //检索关键词
                var hxMatchsH = regHxH.Matches(contentTempR); //检索关键词
                string strCut = "";
                string strCutL = "";
                string strCutR = "";


                if (hxMatchsQ.Count > 0)
                {
                    strCutL = contentTempL.Substring(hxMatchsQ[hxMatchsQ.Count - 1].Index, contentTempL.Length - hxMatchsQ[hxMatchsQ.Count - 1].Index);
                }
                else
                {
                    strCutL = contentTempL;
                }
                if (hxMatchsH.Count > 0)
                {
                    strCutR = contentTempR.Substring(0, hxMatchsH[0].Index + hxMatchsH[0].Value.Length);
                }
                else
                {
                    strCutR = contentTempR;
                }
                strCut = strCutL + hxMatchs[i].Value + strCutR;//前字符串+核心词+后字符串
                if (!string.IsNullOrEmpty(strCut))
                    result.Add(strCut);
            }

            return result;
        }
        /// <summary>
        /// 截取核心词(至前置词及后置词)之间切割成语句集合(前后词优先\不排除重复)
        /// </summary>
        /// <param name="strHx">核心词“以|隔开”</param>
        ///<param name="strHxQ">前置词“以|隔开”</param> 
        /// <param name="strHxH">后置词“以|隔开”</param>
        /// <param name="content">被提取内容</param>
        /// <returns></returns>
        public static List<string> CutYuJuHqhB(string strHx, string strHxQ, string strHxH, string content)
        {
            return CutYuJuHqhB(strHx, strHxQ, strHxH, content, RegexOptions.None);
        }
        #endregion
        #region 截取核心词前后距离最近关键词之间的数据返回集合(核心词优先)(CutYuJuHQH)
        /// <summary>
        /// 截取核心词前后距离最近关键词之间的数据返回集合(核心词优先)
        /// </summary>
        /// <param name="strHx">核心词“以|隔开”</param>
        /// <param name="strHxQ">前置词“以|隔开”(标点需转义)@"\：|\。|\:|\."</param>
        /// <param name="strHxH">后置词“以|隔开”(标点需转义)@"\：|\。|\:|\."</param>
        /// <param name="content">被提取内容</param>
        /// <param name="ro">是否区分大小写</param>
        /// <returns></returns>
        public static List<string> CutYuJuHQH(string strHx, string strHxQ, string strHxH, string content, RegexOptions ro)
        {
            List<string> ReturnList = new List<string>();
            if (Regex.IsMatch(content, strHx, ro))
            {
                List<string> strCut = ImplFunc.CutYuJuHXC(strHx, content, ro);
                foreach (var item in strCut)
                {
                    string ctBiaoDian = ImplFunc.CutYuJuHQHC(strHx, strHxQ, strHxH, item, ro);
                    if (!string.IsNullOrEmpty(ctBiaoDian))
                    {
                        ReturnList.Add(ctBiaoDian);
                    }
                }
            }
            return ReturnList;
        }
        /// <summary>
        /// 截取核心词前后距离最近关键词之间的数据返回集合（核心词优先）
        /// </summary>
        /// <param name="strHx">核心词“以|隔开”</param>
        /// <param name="strHxQ">前置词“以|隔开”(标点需转义)@"\：|\。|\:|\."</param>
        /// <param name="strHxH">后置词“以|隔开”(标点需转义)@"\：|\。|\:|\."</param>
        /// <param name="content">被提取内容</param>
        /// <returns></returns>
        public static List<string> CutYuJuHQH(string strHx, string strHxQ, string strHxH, string content)
        {
            return CutYuJuHQH(strHx, strHxQ, strHxH, content, RegexOptions.None);
        }
        #endregion
        #region 截取核心词后距离最近的语句集和(CutYuJuHH)(以后置截取词为主)
        /// <summary>
        /// 截取核心词后距离最近的语句集和(以后置截取词为主)
        /// </summary>
        /// <param name="strHx">核心词 |</param>
        /// <param name="strHxH">后词 |</param>
        /// <param name="content">内容</param>
        /// <param name="ro">是否区分大小写</param>
        /// <returns></returns>
        public static List<string> CutYuJuHH(string strHx, string strHxH, string content, RegexOptions ro)
        {
            List<string> ReturnList = new List<string>();
            if (Regex.IsMatch(content, strHx, ro))
            {
                List<string> strCut = ImplFunc.CutYuJuHqhB(strHx, strHxH, strHxH, content);
                foreach (var item in strCut)
                {
                    string HeHou = item.Substring(Regex.Match(item, strHx, ro).Index);//街区核心词后的部分
                    if (!string.IsNullOrEmpty(HeHou))
                    {
                        ReturnList.Add(HeHou);
                    }
                }
            }
            return ReturnList;
        }
        #region 备份(以核心词为主)
        //public static List<string> CutYuJuHH(string strHx, string strHxH, string content, RegexOptions ro)
        //{
        //    List<string> ReturnList = new List<string>();
        //    if (Regex.IsMatch(content, strHx, ro))
        //    {
        //        List<string> strCut = EtlFunc.CutYuJu03(strHx, content, ro);//每条只有一个核心词
        //        foreach (var item in strCut)
        //        {
        //            string ctBiaoDian = EtlFunc.CutYuJu06(strHx, strHxH, strHxH, item, ro);//按核心词前后最近的的词分割
        //            string HeHou = ctBiaoDian.Substring(Regex.Match(ctBiaoDian, strHx, ro).Index);//街区核心词后的部分
        //            if (!string.IsNullOrEmpty(HeHou))
        //            {
        //                ReturnList.Add(HeHou);
        //            }
        //        }
        //    }
        //    return ReturnList;
        //} 
        #endregion
        /// <summary>
        /// 截取核心词后距离最近的语句集和
        /// </summary>
        /// <param name="strHx">核心词 |</param>
        /// <param name="strHxH">后词 |</param>
        /// <param name="content">内容</param>
        /// <returns></returns>
        public static List<string> CutYuJuHH(string strHx, string strHxH, string content)
        {
            return CutYuJuHH(strHx, strHxH, content, RegexOptions.None);
        }
        #endregion
        #region 截取核心词前距离最近的语句集和(CutYuJuHQ)
        /// <summary>
        /// 截取核心词前距离最近的语句集和
        /// </summary>
        /// <param name="strHx">核心词 |</param>
        /// <param name="strHxQ">前词 |</param>
        /// <param name="content"></param>
        /// /// <param name="ro">是否区分大小写</param>
        /// <returns></returns>
        public static List<string> CutYuJuHQ(string strHx, string strHxQ, string content, RegexOptions ro)
        {
            List<string> ReturnList = new List<string>();
            if (Regex.IsMatch(content, strHx, ro))
            {
                List<string> strCut = ImplFunc.CutYuJuHXC(strHx, content, ro);//每条只有一个核心词
                foreach (var item in strCut)
                {
                    string ctBiaoDian = ImplFunc.CutYuJuHQHC(strHx, strHxQ, strHxQ, item, ro);//按核心词前后最近的的词分割
                    string HeQian = ctBiaoDian.Substring(0, Regex.Match(ctBiaoDian, strHx, ro).Index);//截取核心词前的部分
                    if (!string.IsNullOrEmpty(HeQian))
                    {
                        ReturnList.Add(HeQian);
                    }
                }
            }
            return ReturnList;
        }
        /// <summary>
        /// 截取核心词前距离最近的语句集和
        /// </summary>
        /// <param name="strHx">核心词 |</param>
        /// <param name="strHxQ">前词 |</param>
        /// <param name="content"></param>
        /// <returns></returns>
        public static List<string> CutYuJuHQ(string strHx, string strHxQ, string content)
        {
            return CutYuJuHQ(strHx, strHxQ, content, RegexOptions.None);
        }
        #endregion
        #region 截取两个关键词之间的内容(第一个关键词找不到用下一个以此类推)(CutYuJuZhiJianHuo)
        /// <summary>
        /// 截取两个关键词之间的内容(第一个关键词找不到用下一个以此类推)
        /// </summary>
        /// <param name="content">内容</param>
        /// <param name="hxq">前关键词，并列关系用|分割</param>
        /// <param name="hxh">后关键词，并列关系用|分割</param>
        /// <param name="isZuihou">未找到后置词时是否截取到最后，true截取到最后</param>
        /// <returns></returns>
        public static string CutYuJuZhiJianHuo(string content, string hxq, string hxh, bool isZuihou)
        {
            string strResult = string.Empty;
            List<string> hxqList = null;
            List<string> hxhList = null;
            string qian = string.Empty;
            string hou = string.Empty;
            string contentNew = string.Empty;
            if (string.IsNullOrEmpty(content) || string.IsNullOrEmpty(hxq))
            {
                return strResult;
            }
            hxqList = hxq.Split('|').ToList();
            hxhList = hxh.Split('|').ToList();

            foreach (string item in hxqList)
            {
                if (content.Contains(item))
                {
                    qian = item;
                    break;
                }
            }
            if (!string.IsNullOrEmpty(qian))
            {
                contentNew = content.Substring(content.IndexOf(qian));
            }
            foreach (string item in hxhList)
            {
                if (contentNew.Contains(item))
                {
                    hou = item;
                    break;
                }
            }
            if (!string.IsNullOrEmpty(hou))
            {
                strResult = contentNew.Substring(0, contentNew.IndexOf(hou) + hou.Length);
            }
            else if (isZuihou == true)
            {
                strResult = contentNew;
            }
            return strResult;
        }
        #endregion
        #region 多个核心词中选择一个作为切割词截取切割词位置到最前或最后(CutYuJuHeQH)
        /// <summary>
        /// 多个核心词中选择一个作为切割词截取切割词位置到最前或最后
        /// </summary>
        /// <param name="content"></param>
        /// <param name="strCut">|</param>
        /// <param name="flag">1前2后</param>
        /// <returns></returns>
        public static string CutYuJuHeQH(string content, string strCut, int flag)
        {
            string strResult = string.Empty;
            List<string> cutList = null;
            string cutStr = string.Empty;
            cutList = strCut.Split('|').ToList();
            //确定切割词
            foreach (string item in cutList)
            {
                if (content.Contains(item))
                {
                    cutStr = item;
                    break;
                }
            }
            if (string.IsNullOrEmpty(cutStr))
            {
                return strResult;
            }
            //切割词前
            if (flag == 1)
            {
                strResult = content.Substring(0, content.IndexOf(cutStr) + cutStr.Length);
            }
            //切割词后
            else if (flag == 2)
            {
                strResult = content.Substring(content.IndexOf(cutStr));
            }

            return strResult;

        }
        #endregion
        #region 截取关键词后指定长度,长度不够截取到最后
        /// <summary>
        /// 截取关键词后指定长度,长度不够截取到最后
        /// </summary>
        /// <param name="content"></param>
        /// <param name="hxc"></param>
        /// <param name="len"></param>
        /// <param name="regexOptions"></param>
        /// <returns></returns>
        public static string CutYuJuHouLength(string content, string hxc, int len, RegexOptions regexOptions)
        {
            string cutStr = "";
            if (Regex.IsMatch(content, hxc, regexOptions))
            {
                Match mc = Regex.Match(content, hxc, regexOptions);
                cutStr = content.Substring(mc.Index);
                if (cutStr.Length > len)
                {
                    cutStr = cutStr.Substring(0, len + mc.Value.Length);
                }
            }
            return cutStr;
        }
        public static string CutYuJuHouLength(string content, string hxc, int len)
        {
            return CutYuJuHouLength(content, hxc, len, RegexOptions.IgnoreCase);
        }
        #endregion
        #region 将一段话按照核心词前或者后长度切割成语句集合(长度为主可跨越关键词)(CutYuJuL)
        /// <summary>
        /// 将一段话按照核心词前或者后长度切割成语句集合(长度为主可跨越关键词)
        /// </summary>
        /// <param name="strHx">核心词字符串“以|隔开”</param>
        /// <param name="content">被提取内容</param>
        /// <param name="blBefore">是否是核心词前</param>
        /// <param name="cutLength">截取核心词前后长度</param>
        /// <returns></returns>
        public static List<string> CutYuJuL(string strHx, string content, bool blBefore, int cutLength)
        {
            var result = new List<string>();
            //核心词
            var regHx = new Regex(strHx, RegexOptions.IgnoreCase);
            //一个核心词位置
            var HxPosition = -1;
            var hxMatchs = regHx.Matches(content); //检索关键词
            if (blBefore)
            {
                for (int i = 0; i < hxMatchs.Count; i++)
                {
                    string strCut = "";
                    HxPosition = hxMatchs[i].Index;
                    if (content.Substring(0, HxPosition).Length >= cutLength)
                    {
                        strCut = content.Substring(HxPosition - cutLength, cutLength);
                    }
                    else
                    {
                        strCut = content.Substring(0, HxPosition);
                    }
                    if (!string.IsNullOrEmpty(strCut) && !result.Contains(strCut))
                        result.Add(strCut);
                }
            }
            else
            {
                for (int i = 0; i < hxMatchs.Count; i++)
                {
                    string strCut = "";
                    HxPosition = hxMatchs[i].Index;
                    if (content.Substring(HxPosition + hxMatchs[i].Length).Length >= cutLength)
                    {
                        strCut = content.Substring(HxPosition + hxMatchs[i].Length, cutLength);
                    }
                    else
                    {
                        strCut = content.Substring(HxPosition + hxMatchs[i].Length);
                    }
                    if (!string.IsNullOrEmpty(strCut) && !result.Contains(strCut))
                        result.Add(strCut);
                }
            }
            return result;
        }
        #endregion
        #region 截取两个关键词之间的内容,不能包含多个截断词
        /// <summary>
        /// 截取两个关键词之间的内容,第二个关键词不存在则不截取
        /// </summary>
        /// <param name="content">内容</param>
        /// <param name="qian">前置词</param>
        /// <param name="hou">后置词</param>
        /// <param name="isZuiHou">不包含后置词是否截取到最后</param>
        /// <returns></returns>
        public static string CutYuJuOneToNext(string content, string qian, string hou, bool isZuiHou)
        {
            string strEnd = "";
            string strCutOne = "";

            if (!string.IsNullOrEmpty(content))
            {
                if (content.Contains(qian))
                {
                    strCutOne = content.Substring(content.IndexOf(qian) + qian.Length);
                }
                if (strCutOne.Contains(hou))
                {
                    strEnd = strCutOne.Substring(0, strCutOne.IndexOf(hou));
                }
                if (!strCutOne.Contains(hou) && isZuiHou == true)
                {
                    strEnd = strCutOne;
                }
            }
            return strEnd;
        }
        #endregion
        #region 截取两个词之间的一段话(前后可以包含多个词以首次出现的词作为截取次)
        /// <summary>
        /// 截取两个词之间的一段话(前后可以包含多个词以首次出现的词作为截取次)
        /// </summary>
        /// <param name="content">内容</param>
        /// <param name="qian">前置词 | 分开</param>
        /// <param name="hou">后置词 | 分开</param>
        /// <param name="isZuihou">false没有后置词不截取true无后置词截取到最后</param>
        /// <returns></returns>
        public static string CutYuJuFirstDict(string content, string qian, string hou, bool isZuihou)
        {
            string strCut = string.Empty;

            if (Regex.IsMatch(content, qian, RegexOptions.IgnoreCase) && Regex.IsMatch(content, hou, RegexOptions.IgnoreCase) && !string.IsNullOrEmpty(content) && isZuihou == false)
            {
                Match mcq = Regex.Match(content, qian);
                strCut = content.Substring(mcq.Index + mcq.Value.Length);
                Match mch = Regex.Match(strCut, hou);
                strCut = strCut.Substring(0, mch.Index);
            }
            else if (Regex.IsMatch(content, qian) && isZuihou == true && !string.IsNullOrEmpty(content))
            {
                Match mcq = Regex.Match(content, qian);
                strCut = content.Substring(mcq.Index);
            }
            return strCut;
        }
        #endregion
        #region 语句截取方法
        /// <summary>
        /// 将一段话用标点符号切割成语句集合
        /// </summary>
        /// <param name="content">文本</param>
        /// <returns></returns>
        public static List<string> CutYuJu(string content)
        {
            var list = content.Split(",.;?!，。；？！".ToCharArray()).ToList();
            var result = new List<string>();
            foreach (var s in list.Where(s => !string.IsNullOrEmpty(s) && !result.Contains(s)))
            {
                result.Add(s);
            }
            return result;
        }

        /// <summary>
        /// 将一段话用标点符号切割成语句集合
        /// </summary>
        /// <param name="content">文本</param>
        /// <param name="strSign">自定义标点</param>
        /// <returns></returns>
        public static List<string> CutYuJu(string content, string strSign)
        {
            string strCsign = ",.;?!，。；？！";
            if (strSign.Length > 0)
                strCsign = strCsign + strSign;
            var list = content.Split(strCsign.ToCharArray()).ToList();
            var result = new List<string>();
            foreach (var s in list.Where(s => !string.IsNullOrEmpty(s) && !result.Contains(s)))
            {
                result.Add(s);
            }
            return result;
        }

        /// <summary>
        /// 将一段话用标点符号切割成语句集合
        /// </summary>
        /// <param name="content">文本</param>
        /// <param name="strSign">自定义标点</param>
        /// <param name="blClear">是否覆盖初始标点</param>
        /// <returns></returns>
        public static List<string> CutYuJu(string content, string strSign, bool blClear)
        {
            string strCsign = ",.;?!，。；？！";

            if (strSign.Length > 0)
            {
                if (blClear)
                {
                    strCsign = strSign;
                }
                else
                    strCsign = strCsign + strSign;
            }
            var list = content.Split(strCsign.ToCharArray()).ToList();
            var result = new List<string>();
            foreach (var s in list.Where(s => !string.IsNullOrEmpty(s) && !result.Contains(s)))
            {
                result.Add(s);
            }
            return result;
        }

        /// <summary>
        /// 将一段话按照核心词前或者后长度切割成语句集合
        /// </summary>
        /// <param name="strHx">核心词字符串</param>
        /// <param name="content">被提取内容</param>
        /// <param name="blBefore">是否是核心词前</param>
        /// <param name="cutLength">截取核心词前后长度</param>
        /// <returns></returns>
        public static List<string> CutYuJu(string strHx, string content, bool blBefore, int cutLength)
        {
            content = ToDBC(content);
            var result = new List<string>();
            //核心词
            var regHx = new Regex(strHx, RegexOptions.IgnoreCase);
            //一个核心词位置
            var HxPosition = -1;
            var hxMatchs = regHx.Matches(content); //检索关键词
            if (blBefore)
            {
                for (int i = 0; i < hxMatchs.Count; i++)
                {
                    string strCut = "";
                    HxPosition = hxMatchs[i].Index;
                    if (content.Substring(0, HxPosition).Length >= cutLength)
                    {
                        strCut = content.Substring(HxPosition - cutLength, cutLength + hxMatchs[i].Length);
                    }
                    else
                    {
                        strCut = content.Substring(0, HxPosition + hxMatchs[i].Length);//字符串右端带核心词
                    }
                    var hxMatchsL = regHx.Matches(strCut.Substring(0, strCut.Length - hxMatchs[i].Length)); //检索前字符串是否有核心词
                    if (hxMatchsL.Count > 0)
                    {
                        strCut = strCut.Substring(hxMatchsL[hxMatchsL.Count - 1].Index + hxMatchsL[hxMatchsL.Count - 1].Length);
                    }
                    if (!string.IsNullOrEmpty(strCut) && !result.Contains(strCut))
                        result.Add(strCut);
                }
            }
            else
            {
                for (int i = 0; i < hxMatchs.Count; i++)
                {
                    string strCut = "";
                    HxPosition = hxMatchs[i].Index;
                    if (content.Substring(HxPosition + hxMatchs[i].Length).Length >= cutLength)
                    {
                        strCut = content.Substring(HxPosition, cutLength + hxMatchs[i].Length);//字符串左侧带核心词
                    }
                    else
                    {
                        strCut = content.Substring(HxPosition);
                    }
                    string strCutTemp = strCut.Substring(hxMatchs[i].Length);//不包含关键词
                    var hxMatchsR = regHx.Matches(strCutTemp); //重新检索核心词，排除多关键词之间的距离小于截取长度
                    if (hxMatchsR.Count > 0)//如果后字符串有关键词
                    {
                        strCut = strCut.Substring(0, hxMatchs[i].Length + hxMatchsR[0].Index);
                    }
                    if (!string.IsNullOrEmpty(strCut) && !result.Contains(strCut))
                        result.Add(strCut);
                }
            }
            return result;
        }


        /// <summary>
        /// 将一段话按照核心词前或者后长度切割成语句集合
        /// </summary>
        /// <param name="strHx">核心词字符串</param>
        /// <param name="content">被提取内容</param>
        /// <param name="blBefore">是否是核心词前</param>
        /// <param name="cutLength">截取核心词前后长度</param>
        /// <param name="blLength"></param>
        /// <returns></returns>
        public static List<string> CutYuJu(string strHx, string content, bool blBefore, int cutLength, bool blLength)
        {
            content = ToDBC(content);
            var result = new List<string>();
            //核心词
            var regHx = new Regex(strHx, RegexOptions.IgnoreCase);
            //一个核心词位置
            var HxPosition = -1;
            var hxMatchs = regHx.Matches(content); //检索关键词
            if (blBefore)
            {
                for (int i = 0; i < hxMatchs.Count; i++)
                {
                    string strCut = "";
                    HxPosition = hxMatchs[i].Index;
                    if (content.Substring(0, HxPosition).Length >= cutLength)
                    {
                        strCut = content.Substring(HxPosition - cutLength, cutLength + hxMatchs[i].Length);
                    }
                    else
                    {
                        strCut = content.Substring(0, HxPosition + hxMatchs[i].Length);//字符串右端带核心词
                    }
                    //var hxMatchsL = regHx.Matches(strCut.Substring(0, strCut.Length - hxMatchs[i].Length)); //检索前字符串是否有核心词
                    //if (hxMatchsL.Count > 0)
                    //{
                    //    strCut = strCut.Substring(hxMatchsL[hxMatchsL.Count - 1].Index + hxMatchsL[hxMatchsL.Count - 1].Length);
                    //}
                    if (!string.IsNullOrEmpty(strCut) && !result.Contains(strCut))
                        result.Add(strCut);
                }
            }
            else
            {
                for (int i = 0; i < hxMatchs.Count; i++)
                {
                    string strCut = "";
                    HxPosition = hxMatchs[i].Index;
                    if (content.Substring(HxPosition + hxMatchs[i].Length).Length >= cutLength)
                    {
                        strCut = content.Substring(HxPosition, cutLength + hxMatchs[i].Length);//字符串左侧带核心词
                    }
                    else
                    {
                        strCut = content.Substring(HxPosition);
                    }
                    //string strCutTemp = strCut.Substring(hxMatchs[i].Length);//不包含关键词
                    //var hxMatchsR = regHx.Matches(strCutTemp); //重新检索核心词，排除多关键词之间的距离小于截取长度
                    //if (hxMatchsR.Count > 0)//如果后字符串有关键词
                    //{
                    //    strCut = strCut.Substring(0, hxMatchs[i].Length + hxMatchsR[0].Index);
                    //}
                    if (!string.IsNullOrEmpty(strCut) && !result.Contains(strCut))
                        result.Add(strCut);
                }
            }
            return result;
        }

        /// <summary>
        /// 将一段话按照核心词前后长度切割成语句集合
        /// </summary>
        /// <param name="strHx">核心词</param>
        /// <param name="content">被提取内容</param>
        /// <param name="cutLlength">截取核心词前长度</param>
        /// <param name="cutRlength">截取核心词后长度</param>
        /// <returns></returns>
        public static List<string> CutYuJu(string strHx, string content, int cutLlength, int cutRlength)
        {
            content = ToDBC(content);
            var result = new List<string>();
            //核心词
            var regHx = new Regex(strHx, RegexOptions.IgnoreCase);
            //一个核心词位置
            var HxPosition = -1;
            var hxMatchs = regHx.Matches(content); //检索关键词
            if (cutLlength > 0 && cutRlength > 0)
            {
                for (int i = 0; i < hxMatchs.Count; i++)
                {
                    string strCut = "";
                    string strCutL = "";
                    string strCutR = "";
                    HxPosition = hxMatchs[i].Index;//核心词的位置
                    //核心词前字符串长度足够
                    if (content.Substring(0, HxPosition).Length >= cutLlength)
                    {
                        strCutL = content.Substring(HxPosition - cutLlength, cutLlength);
                    }
                    else  //核心词前字符串长度不足，从开始位置取
                    {
                        strCutL = content.Substring(0, HxPosition);
                    }
                    //核心词后字符串长度足够
                    if (content.Substring(HxPosition + hxMatchs[i].Length).Length >= cutRlength)
                    {
                        strCutR = content.Substring(HxPosition + hxMatchs[i].Length, cutRlength);
                    }
                    else//核心词后字符串长度不足，从核心词位置取到最后
                    {
                        strCutR = content.Substring(HxPosition + hxMatchs[i].Length);
                    }

                    var hxMatchsL = regHx.Matches(strCutL); //重新检索关键词，排除多关键词之间的距离小于截取长度
                    if (hxMatchsL.Count > 0)//如果前字符串有关键词
                    {
                        strCutL = strCutL.Substring(hxMatchsL[hxMatchsL.Count - 1].Index + hxMatchsL[hxMatchsL.Count - 1].Length);
                    }
                    var hxMatchsR = regHx.Matches(strCutR); //重新检索关键词，排除多关键词之间的距离小于截取长度
                    if (hxMatchsR.Count > 0)//如果后字符串有关键词
                    {
                        strCutR = strCutR.Substring(0, hxMatchsR[0].Index);
                    }
                    strCut = strCutL + hxMatchs[i].Value + strCutR;//前字符串+核心词+后字符串
                    if (!string.IsNullOrEmpty(strCut) && !result.Contains(strCut))
                        result.Add(strCut);
                }
            }
            return result;
        }
        #endregion
        #endregion

        #region 数据提取方法

        /// <summary>
        /// 获取时间(包括时分秒，不包括日期)
        /// </summary>
        /// <param name="strContent">文本</param>
        /// <returns></returns>
        public static List<string> GetTimeValues(string strContent)
        {
            List<string> strList = new List<string>();
            var regex =
                      new Regex(
                          @"(?<hour>\d{1,2})\s*[时点:：]\s*(?<fen>\d{1,2})?\s*[分:：]?\s*(?<miao>\d{1,2})?[秒]?",
                          RegexOptions.Singleline);
            var matchs = regex.Matches(strContent);
            foreach (Match match in matchs)
            {
                string shi = string.IsNullOrEmpty(match.Groups["hour"].Value) ? "00" : match.Groups["hour"].Value;
                string fen = string.IsNullOrEmpty(match.Groups["fen"].Value) ? "00" : match.Groups["fen"].Value;
                string miao = string.IsNullOrEmpty(match.Groups["miao"].Value) ? "00" : match.Groups["miao"].Value;
                strList.Add(ToDBC(shi + ":" + fen + ":" + miao));
            }
            return strList;
        }

        /// <summary>
        /// 获取日期时间（包括年月日时分秒）
        /// </summary>
        /// <param name="content">文本</param>
        /// <returns></returns>
        public static List<DateTime> GetDateTimeValues(string content)
        {
            var list = new List<DateTime>();
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
                    list.Add(Convert.ToDateTime(ToDBC(sb.ToString())));
                }
                catch (Exception ex)
                {
                    continue;
                }
            }
            return list;
        }

        /// <summary>
        /// 提取所有数值类型数据
        /// </summary>
        public static List<double> GetDoubleList(string content)
        {
            var regex = new Regex(@"\d+[.．]?\d*", RegexOptions.Singleline);
            var matchs = regex.Matches(content);
            var list = (from Match match in matchs select double.Parse(ToDBC(match.Groups[0].Value.ToString()))).ToList();
            return list;
        }

        #endregion

        #region 汉字转拼音
        #region 拼音码转化字典
        private static readonly Dictionary<int, string> CodeCollections = new Dictionary<int, string> {
 { -20319, "a" }, { -20317, "ai" }, { -20304, "an" }, { -20295, "ang" }, { -20292, "ao" }, { -20283, "ba" }, { -20265, "bai" }, 
{ -20257, "ban" }, { -20242, "bang" }, { -20230, "bao" }, { -20051, "bei" }, { -20036, "ben" }, { -20032, "beng" }, { -20026, "bi" }
, { -20002, "bian" }, { -19990, "biao" }, { -19986, "bie" }, { -19982, "bin" }, { -19976, "bing" }, { -19805, "bo" }, 
{ -19784, "bu" }, { -19775, "ca" }, { -19774, "cai" }, { -19763, "can" }, { -19756, "cang" }, { -19751, "cao" }, { -19746, "ce" },
 { -19741, "ceng" }, { -19739, "cha" }, { -19728, "chai" }, { -19725, "chan" }, { -19715, "chang" }, { -19540, "chao" }, 
{ -19531, "che" }, { -19525, "chen" }, { -19515, "cheng" }, { -19500, "chi" }, { -19484, "chong" }, { -19479, "chou" }, 
{ -19467, "chu" }, { -19289, "chuai" }, { -19288, "chuan" }, { -19281, "chuang" }, { -19275, "chui" }, { -19270, "chun" },
 { -19263, "chuo" }, { -19261, "ci" }, { -19249, "cong" }, { -19243, "cou" }, { -19242, "cu" }, { -19238, "cuan" }, 
{ -19235, "cui" }, { -19227, "cun" }, { -19224, "cuo" }, { -19218, "da" }, { -19212, "dai" }, { -19038, "dan" }, { -19023, "dang" },
 { -19018, "dao" }, { -19006, "de" }, { -19003, "deng" }, { -18996, "di" }, { -18977, "dian" }, { -18961, "diao" }, { -18952, "die" }
, { -18783, "ding" }, { -18774, "diu" }, { -18773, "dong" }, { -18763, "dou" }, { -18756, "du" }, { -18741, "duan" }, 
{ -18735, "dui" }, { -18731, "dun" }, { -18722, "duo" }, { -18710, "e" }, { -18697, "en" }, { -18696, "er" }, { -18526, "fa" },
 { -18518, "fan" }, { -18501, "fang" }, { -18490, "fei" }, { -18478, "fen" }, { -18463, "feng" }, { -18448, "fo" }, { -18447, "fou" }
, { -18446, "fu" }, { -18239, "ga" }, { -18237, "gai" }, { -18231, "gan" }, { -18220, "gang" }, { -18211, "gao" }, { -18201, "ge" },
 { -18184, "gei" }, { -18183, "gen" }, { -18181, "geng" }, { -18012, "gong" }, { -17997, "gou" }, { -17988, "gu" }, { -17970, "gua" }
, { -17964, "guai" }, { -17961, "guan" }, { -17950, "guang" }, { -17947, "gui" }, { -17931, "gun" }, { -17928, "guo" },
{ -17922, "ha" }, { -17759, "hai" }, { -17752, "han" }, { -17733, "hang" }, { -17730, "hao" }, { -17721, "he" }, { -17703, "hei" },
 { -17701, "hen" }, { -17697, "heng" }, { -17692, "hong" }, { -17683, "hou" }, { -17676, "hu" }, { -17496, "hua" }, 
{ -17487, "huai" }, { -17482, "huan" }, { -17468, "huang" }, { -17454, "hui" }, { -17433, "hun" }, { -17427, "huo" }, 
{ -17417, "ji" }, { -17202, "jia" }, { -17185, "jian" }, { -16983, "jiang" }, { -16970, "jiao" }, { -16942, "jie" }, 
{ -16915, "jin" }, { -16733, "jing" }, { -16708, "jiong" }, { -16706, "jiu" }, { -16689, "ju" }, { -16664, "juan" }, 
{ -16657, "jue" }, { -16647, "jun" }, { -16474, "ka" }, { -16470, "kai" }, { -16465, "kan" }, { -16459, "kang" }, { -16452, "kao" },
 { -16448, "ke" }, { -16433, "ken" }, { -16429, "keng" }, { -16427, "kong" }, { -16423, "kou" }, { -16419, "ku" }, { -16412, "kua" }
, { -16407, "kuai" }, { -16403, "kuan" }, { -16401, "kuang" }, { -16393, "kui" }, { -16220, "kun" }, { -16216, "kuo" }, 
{ -16212, "la" }, { -16205, "lai" }, { -16202, "lan" }, { -16187, "lang" }, { -16180, "lao" }, { -16171, "le" }, { -16169, "lei" }, 
{ -16158, "leng" }, { -16155, "li" }, { -15959, "lia" }, { -15958, "lian" }, { -15944, "liang" }, { -15933, "liao" }, 
{ -15920, "lie" }, { -15915, "lin" }, { -15903, "ling" }, { -15889, "liu" }, { -15878, "long" }, { -15707, "lou" }, { -15701, "lu" },
 { -15681, "lv" }, { -15667, "luan" }, { -15661, "lue" }, { -15659, "lun" }, { -15652, "luo" }, { -15640, "ma" }, { -15631, "mai" },
 { -15625, "man" }, { -15454, "mang" }, { -15448, "mao" }, { -15436, "me" }, { -15435, "mei" }, { -15419, "men" }, 
{ -15416, "meng" }, { -15408, "mi" }, { -15394, "mian" }, { -15385, "miao" }, { -15377, "mie" }, { -15375, "min" }, 
{ -15369, "ming" }, { -15363, "miu" }, { -15362, "mo" }, { -15183, "mou" }, { -15180, "mu" }, { -15165, "na" }, { -15158, "nai" }, 
{ -15153, "nan" }, { -15150, "nang" }, { -15149, "nao" }, { -15144, "ne" }, { -15143, "nei" }, { -15141, "nen" }, { -15140, "neng" }
, { -15139, "ni" }, { -15128, "nian" }, { -15121, "niang" }, { -15119, "niao" }, { -15117, "nie" }, { -15110, "nin" }, 
{ -15109, "ning" }, { -14941, "niu" }, { -14937, "nong" }, { -14933, "nu" }, { -14930, "nv" }, { -14929, "nuan" }, { -14928, "nue" }
, { -14926, "nuo" }, { -14922, "o" }, { -14921, "ou" }, { -14914, "pa" }, { -14908, "pai" }, { -14902, "pan" }, { -14894, "pang" },
 { -14889, "pao" }, { -14882, "pei" }, { -14873, "pen" }, { -14871, "peng" }, { -14857, "pi" }, { -14678, "pian" }, 
{ -14674, "piao" }, { -14670, "pie" }, { -14668, "pin" }, { -14663, "ping" }, { -14654, "po" }, { -14645, "pu" }, { -14630, "qi" },
 { -14594, "qia" }, { -14429, "qian" }, { -14407, "qiang" }, { -14399, "qiao" }, { -14384, "qie" }, { -14379, "qin" },
 { -14368, "qing" }, { -14355, "qiong" }, { -14353, "qiu" }, { -14345, "qu" }, { -14170, "quan" }, { -14159, "que" }, 
{ -14151, "qun" }, { -14149, "ran" }, { -14145, "rang" }, { -14140, "rao" }, { -14137, "re" }, { -14135, "ren" }, { -14125, "reng" }
, { -14123, "ri" }, { -14122, "rong" }, { -14112, "rou" }, { -14109, "ru" }, { -14099, "ruan" }, { -14097, "rui" }, { -14094, "run" }
, { -14092, "ruo" }, { -14090, "sa" }, { -14087, "sai" }, { -14083, "san" }, { -13917, "sang" }, { -13914, "sao" }, { -13910, "se" }
, { -13907, "sen" }, { -13906, "seng" }, { -13905, "sha" }, { -13896, "shai" }, { -13894, "shan" }, { -13878, "shang" }, 
{ -13870, "shao" }, { -13859, "she" }, { -13847, "shen" }, { -13831, "sheng" }, { -13658, "shi" }, { -13611, "shou" },
 { -13601, "shu" }, { -13406, "shua" }, { -13404, "shuai" }, { -13400, "shuan" }, { -13398, "shuang" }, { -13395, "shui" },
 { -13391, "shun" }, { -13387, "shuo" }, { -13383, "si" }, { -13367, "song" }, { -13359, "sou" }, { -13356, "su" }, 
{ -13343, "suan" }, { -13340, "sui" }, { -13329, "sun" }, { -13326, "suo" }, { -13318, "ta" }, { -13147, "tai" }, { -13138, "tan" },
 { -13120, "tang" }, { -13107, "tao" }, { -13096, "te" }, { -13095, "teng" }, { -13091, "ti" }, { -13076, "tian" }, 
{ -13068, "tiao" }, { -13063, "tie" }, { -13060, "ting" }, { -12888, "tong" }, { -12875, "tou" }, { -12871, "tu" }, 
{ -12860, "tuan" }, { -12858, "tui" }, { -12852, "tun" }, { -12849, "tuo" }, { -12838, "wa" }, { -12831, "wai" }, { -12829, "wan" }
, { -12812, "wang" }, { -12802, "wei" }, { -12607, "wen" }, { -12597, "weng" }, { -12594, "wo" }, { -12585, "wu" }, { -12556, "xi" }
, { -12359, "xia" }, { -12346, "xian" }, { -12320, "xiang" }, { -12300, "xiao" }, { -12120, "xie" }, { -12099, "xin" }, 
{ -12089, "xing" }, { -12074, "xiong" }, { -12067, "xiu" }, { -12058, "xu" }, { -12039, "xuan" }, { -11867, "xue" }, 
{ -11861, "xun" }, { -11847, "ya" }, { -11831, "yan" }, { -11798, "yang" }, { -11781, "yao" }, { -11604, "ye" }, { -11589, "yi" },
 { -11536, "yin" }, { -11358, "ying" }, { -11340, "yo" }, { -11339, "yong" }, { -11324, "you" }, { -11303, "yu" }, 
{ -11097, "yuan" }, { -11077, "yue" }, { -11067, "yun" }, { -11055, "za" }, { -11052, "zai" }, { -11045, "zan" },
 { -11041, "zang" }, { -11038, "zao" }, { -11024, "ze" }, { -11020, "zei" }, { -11019, "zen" }, { -11018, "zeng" }, 
{ -11014, "zha" }, { -10838, "zhai" }, { -10832, "zhan" }, { -10815, "zhang" }, { -10800, "zhao" }, { -10790, "zhe" }, 
{ -10780, "zhen" }, { -10764, "zheng" }, { -10587, "zhi" }, { -10544, "zhong" }, { -10533, "zhou" }, { -10519, "zhu" }, 
{ -10331, "zhua" }, { -10329, "zhuai" }, { -10328, "zhuan" }, { -10322, "zhuang" }, { -10315, "zhui" }, { -10309, "zhun" }, 
{ -10307, "zhuo" }, { -10296, "zi" }, { -10281, "zong" }, { -10274, "zou" }, { -10270, "zu" }, { -10262, "zuan" }, { -10260, "zui" }
, { -10256, "zun" }, { -10254, "zuo" } };
        #endregion
        /// <summary>
        /// 获取单个中文的首字母
        /// </summary>
        /// <param name="cnChar"></param>
        /// <returns></returns>
        private static string getSpell(string cnChar)
        {
            byte[] arrCN = Encoding.Default.GetBytes(cnChar);
            if (arrCN.Length > 1)
            {
                int area = (short)arrCN[0];
                int pos = (short)arrCN[1];
                int code = (area << 8) + pos;
                int[] areacode = { 45217, 45253, 45761, 46318, 46826, 47010, 47297, 47614, 48119, 48119, 49062, 49324, 49896, 50371, 50614, 50622, 50906, 51387, 51446, 52218, 52698, 52698, 52698, 52980, 53689, 54481 };

                for (int i = 0; i < 26; i++)
                {
                    int max = 55290;
                    if (i != 25)
                    {
                        max = areacode[i + 1];
                    }
                    if (areacode[i] <= code && code < max)
                    {
                        return Encoding.Default.GetString(new byte[] { (byte)(97 + i) });
                    }
                }
                return "*";
            }
            else return cnChar;
        }
        /// <summary>
        /// 汉字转拼音
        /// </summary>
        /// <param name="txt">需要转换的汉字</param>
        /// <returns>返回汉字对应的拼音</returns>
        public static string GetPinYin(string txt)
        {
            txt = txt.Trim();
            byte[] arr = new byte[2];   //每个汉字为2字节 
            StringBuilder result = new StringBuilder();//使用StringBuilder优化字符串连接
            int charCode = 0;
            int arr1 = 0;
            int arr2 = 0;
            char[] arrChar = txt.ToCharArray();
            for (int j = 0; j < arrChar.Length; j++)   //遍历输入的字符 
            {
                arr = System.Text.Encoding.Default.GetBytes(arrChar[j].ToString());//根据系统默认编码得到字节码 
                if (arr.Length == 1)//如果只有1字节说明该字符不是汉字，结束本次循环 
                {
                    result.Append(arrChar[j].ToString());
                    continue;

                }
                arr1 = (short)(arr[0]);   //取字节1 
                arr2 = (short)(arr[1]);   //取字节2 
                charCode = arr1 * 256 + arr2 - 65536;//计算汉字的编码 

                if (charCode > -10254 || charCode < -20319)  //如果不在汉字编码范围内则不改变 
                {
                    result.Append(arrChar[j]);
                }
                else
                {
                    //根据汉字编码范围查找对应的拼音并保存到结果中 
                    //由于charCode的键不一定存在，所以要找比他更小的键上一个键
                    if (!CodeCollections.ContainsKey(charCode))
                    {
                        for (int i = charCode; i <= 0; --i)
                        {
                            if (CodeCollections.ContainsKey(i))
                            {
                                result.Append(" " + CodeCollections[i] + " ");
                                break;
                            }
                        }
                    }
                    else
                    {
                        result.Append(" " + CodeCollections[charCode] + " ");
                    }
                }
            }
            return result.ToString();
        }
        #endregion

        #region 公共
        #region 提取时间
        public static DateTime GetDateTimeValuesDefine(string content)
        {
            DateTime datetime = new DateTime();
            // 2016年7 月21 日9 时45 分--13时30 分，共 3小时 45分   
            // 2016年6 月8 日16 时15 分--18时50 分，共 2小时 35分   
            // 2016年06月27日10 时45 分--12 时35分，共 1小时50 分
            Match match = new Regex(@"(?<year>\d{4})\s*[-/年.．／－]\s*(?<month>\d{1,2})\s*[-/月.．／－]\s*(?<day>\d{1,2})\s*日?", RegexOptions.Singleline).Match(content);

            try
            {
                string strdate = string.Format("{0}/{1}/{2}", match.Groups["year"].Value, match.Groups["month"].Value, match.Groups["day"].Value);
                datetime = Convert.ToDateTime(ToDBC(strdate.ToString()));
            }
            catch (Exception)
            {
                datetime = DateTime.MinValue;
                return datetime;
            }

            return datetime;

        }
        #endregion
        #region 返回时间差
        public static string DateDiff(DateTime DateTime1, DateTime DateTime2)
        {
            string dateDiff = null;
            try
            {
                TimeSpan ts1 = new TimeSpan(DateTime1.Ticks);
                TimeSpan ts2 = new TimeSpan(DateTime2.Ticks);
                TimeSpan ts = ts1.Subtract(ts2).Duration();
                string hours = ts.Hours.ToString(), minutes = ts.Minutes.ToString(), seconds = ts.Seconds.ToString();
                if (ts.Hours < 10)
                {
                    hours = "0" + ts.Hours.ToString();
                }
                if (ts.Minutes < 10)
                {
                    minutes = "0" + ts.Minutes.ToString();
                }
                if (ts.Seconds < 10)
                {
                    seconds = "0" + ts.Seconds.ToString();
                }
                dateDiff = hours + ":" + minutes + ":" + seconds;
            }
            catch
            {

            }
            return dateDiff;
        }
        #endregion

        /// <summary>
        /// 获取中文字符串的首字母
        /// </summary>
        /// <param name="strText"></param>
        /// <returns></returns>
        public static string GetChineseSpell(string strText)
        {
            int len = strText.Length;
            string myStr = "";
            for (int i = 0; i < len; i++)
            {
                myStr += getSpell(strText.Substring(i, 1));
            }
            return myStr;
        }

        /// <summary>
        /// 把患者号拼着成可以插入sql的字符串
        /// </summary>
        /// <param name="list">患者号集合</param>
        /// <returns></returns>
        public static string StringListToString(List<string> list)
        {
            StringBuilder sb = new StringBuilder(); ;
            foreach (string str2 in list)
            {
                if (sb.Length > 0)
                {
                    sb.Append(",'" + str2 + "'");
                }
                else
                {
                    sb.Append("'" + str2 + "'");
                }
            }
            return sb.ToString();
        }

        /// <summary>
        /// 根据GUID获取16位的唯一字符串  
        /// </summary>
        public static string GuidTo16String()
        {
            long i = 1;
            foreach (byte b in Guid.NewGuid().ToByteArray())
                i *= ((int)b + 1);
            return string.Format("{0:x}", i - DateTime.Now.Ticks);
        }

        /// <summary>
        /// 转全角的函数(SBC case)
        /// </summary>
        public static string ToSBC(string input)
        {
            //半角转全角：
            char[] c = input.ToCharArray();
            for (int i = 0; i < c.Length; i++)
            {
                if (c[i] == 32)
                {
                    c[i] = (char)12288;
                    continue;
                }
                if (c[i] < 127)
                    c[i] = (char)(c[i] + 65248);
            }
            return new string(c);
        }

        /// <summary>
        ///  转半角的函数(SBC case)
        /// </summary>
        public static string ToDBC(string input)
        {
            char[] c = input.ToCharArray();
            for (int i = 0; i < c.Length; i++)
            {
                if (c[i] == 12288)
                {
                    c[i] = (char)32;
                    continue;
                }
                if (c[i] > 65280 && c[i] < 65375)
                    c[i] = (char)(c[i] - 65248);
            }
            return new string(c);
        }
        #endregion
        
        #region 项目级通用方法
        /// <summary>
        /// 判断是否为结直肠癌
        /// </summary>
        /// <param name="content"></param>
        /// <returns>0不是结直肠癌1是结直肠癌2疑似结直肠癌</returns>
        public static int IsJieZhiChangAi(string content)
        {
            int flag = 0;
            string strFg = @"\d+、|：";
            List<string> lsStrCut = ImplFunc.CutYuJuHH("结肠|直肠", strFg, content);
            foreach (string str in lsStrCut)
            {
                if (Regex.IsMatch(str, @"恶性|恶变|癌|ca", RegexOptions.IgnoreCase))
                {
                    if (Regex.IsMatch(str, @"可能|？|待查|排除"))
                    {
                        flag = 2;
                        break;
                    }
                    else
                    {
                        flag = 1;
                        break;
                    }
                }
            }

            return flag;
        }
        /// <summary>
        /// 判断是否为结直肠癌根治术
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public static int IsJieZhiChangGZS(string content)
        {
            int flagGenZhiShu = 0;
            string operName = "";
            if (content.Contains("手术名称"))
            {
                operName = ImplFunc.CutYuJuZhiJianHuo(content, "手术名称", "手术者", true);
            }

            if (operName != "")
            {
                string strHx = @"直肠|结肠|Miles|Dixon|Hartman";
                string strFg = @"\+|\，|\,|\；|\;|\：|\:";
                List<string> lsStrCut = ImplFunc.CutYuJuHQH(strHx, strFg, strFg, operName, RegexOptions.IgnoreCase);
                foreach (string str in lsStrCut)
                {
                    if (Regex.IsMatch(str, @"Miles|Dixon|Hartman", RegexOptions.IgnoreCase))
                    {
                        flagGenZhiShu = 1;
                        break;
                    }
                    else
                    {
                        if (Regex.IsMatch(str, @"直肠|结肠"))
                        {
                            int index = Regex.Match(str, @"直肠|结肠").Index;
                            string strQian = str.Substring(0, index);
                            string strHou = str.Substring(index);
                            if (strQian.Contains("根治性") | strHou.Contains("根治"))
                            {
                                flagGenZhiShu = 1;
                                break;
                            }
                        }
                    }
                }
                //判断是否为疑似结直肠癌根治术
                if (flagGenZhiShu == 0)
                {
                    foreach (string str in lsStrCut)
                    {
                        if (!Regex.IsMatch(str, "息肉|肿块|肿物|姑息|局部|经肛") && Regex.IsMatch(str, "直肠|结肠"))
                        {
                            int index = Regex.Match(str, @"直肠|结肠").Index;
                            string strHou = str.Substring(index);
                            if (strHou.Contains("切除"))
                            {
                                flagGenZhiShu = 2;
                                break;
                            }
                        }
                    }
                }

            }
            return flagGenZhiShu;
        }
        /// <summary>
        /// 分期1判断
        /// </summary>
        /// <param name="content"></param>
        /// <returns>如果不为空则有临床分期</returns>
        public static string GetFenQi1(string content)
        {
            string strFenQi = "";
            Regex r = new Regex(@"T.{0,4}N.{0,3}M.", RegexOptions.IgnoreCase);
            if (r.IsMatch(content))
            {
                string strMatch = r.Match(content).Groups[0].Value;//匹配出来的字符串
                string strCut = content.Substring(0, r.Match(content).Index);
                MatchCollection mc = Regex.Matches(strCut, @"癌|ca|恶性", RegexOptions.IgnoreCase);
                //如果含癌进一步判断
                if (mc.Count > 0)
                {
                    int index = mc[mc.Count - 1].Index;
                    if (index > 20)
                    {
                        strCut = strCut.Substring(index - 20, 20);
                    }
                    else
                    {
                        strCut = strCut.Substring(0, index);
                    }
                    if (strCut.Contains("肠"))
                    {
                        strFenQi = strMatch;
                    }
                }
                else
                {
                    strFenQi = strMatch;
                }
            }

            return strFenQi;
        }
        /// <summary>
        /// 分期2判断
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public static string GetFenQi2(string content)
        {
            string strFenQi = "";
            Regex r = new Regex(@"[IⅠⅡⅢⅣ].{0,3}期");
            if (r.IsMatch(content))
            {
                string strMatch = r.Match(content).Groups[0].Value;
                string strCut = content.Substring(0, r.Match(content).Index);
                MatchCollection mc = Regex.Matches(strCut, @"癌|ca|恶性", RegexOptions.IgnoreCase);
                //如果含癌进一步判断
                if (mc.Count > 0)
                {
                    int index = mc[mc.Count - 1].Index;
                    if (index > 20)
                    {
                        strCut = strCut.Substring(index - 20, 20);
                    }
                    else
                    {
                        strCut = strCut.Substring(0, index);
                    }
                    if (strCut.Contains("肠"))
                    {
                        strFenQi = strMatch;
                    }
                }
            }
            return strFenQi;
        }

       

        #endregion
    }
}