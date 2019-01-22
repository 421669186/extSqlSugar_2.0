using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ETL_EXAM.EtlExamDataItemLogic
{
    public class FuncComm
    {

        //public static List<string> CutH(string content,string key,string Reg)
        //{
        //    List<string> strList = new List<string>();
        //    if (Regex.IsMatch(content,key))
        //    {
        //                    Regex reg = new Regex(Reg);
        //    var Hx = reg.Matches(content);
        //    if (Hx.Count>0)
        //    {
        //        foreach (var hxc in Hx)
        //        {
        //            int indexKey=content.IndexOf(key);
        //            int indexHx = content.IndexOf(hxc.ToString());
        //            string cut = content.Substring(indexKey,indexHx-indexKey);
        //            strList.Add(cut);
        //        }
        //    }
        //    }
        //    else
        //    {
                
        //    }
        //}
        #region 截取核心词（前和后）之间的语句,排空但不排除重复语句，切割成语句集合(CutYuJu03)
        /// <summary>
        /// 截取核心词（前和后）之间的语句,排空但不排除重复语句，切割成语句集合
        /// </summary>
        /// <param name="strHx">核心词“以|隔开”</param>
        /// <param name="content">被提取内容</param>
        /// <param name="ro">是否区分大小写</param>
        /// <returns></returns>
        public static List<string> CutYuJu03(string strHx, string content, RegexOptions ro)
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
        /// 截取核心词（前和后）之间的语句,排空但不排除重复语句，切割成语句集合(默认区分大小写)
        /// </summary>
        /// <param name="strHx">核心词“以|隔开</param>
        /// <param name="content">被提取内容</param>
        /// <returns></returns>
        public static List<string> CutYuJu03(string strHx, string content)
        {
            return CutYuJu03(strHx, content, RegexOptions.None);
        }
        #endregion
        #region 截取核心词（前和后）之间的语句,排空但不排除重复语句，切割成语句集合(CutYuJu06)
        /// <summary>
        /// 截取核心词（前和后）之间的语句,排空但不排除重复语句，切割成语句集合
        /// </summary>
        /// <param name="strHx">核心词“以|隔开”</param>
        ///<param name="strHxQ">前置词“以|隔开”</param> 
        /// <param name="strHxH">后置词“以|隔开”</param>
        /// <param name="content">被提取内容</param>
        /// <param name="ro">是否区分大小写</param>
        /// <returns></returns>
        public static string CutYuJu06(string strHx, string strHxQ, string strHxH, string content, RegexOptions ro)
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
        /// 截取核心词（前和后）之间的语句,排空但不排除重复语句，切割成语句集合（默认关键词区分大小写）
        /// </summary>
        /// <param name="strHx">核心词“以|隔开</param>
        /// <param name="strHxQ">前置词“以|隔开</param>
        /// <param name="strHxH">后置词“以|隔开</param>
        /// <param name="content">被提取内容</param>
        /// <returns></returns>
        public static string CutYuJu06(string strHx, string strHxQ, string strHxH, string content)
        {
            return CutYuJu06(strHx, strHxQ, strHxH, content, RegexOptions.None);
        }
        #endregion
        #region 截取核心词后距离最近的语句集和(CutYuJuHH)
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
                List<string> strCut = FuncComm.CutYuJuHqhB(strHx, strHxH, strHxH, content);
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
        /// <summary>
        /// 截取关键词后最近的语句集合（不区分大小写）
        /// </summary>
        /// <param name="strHx"></param>
        /// <param name="strHxH"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        public static List<string> CutYuJuHH(string strHx, string strHxH, string content)
        {
            return CutYuJuHH(strHx, strHxH, content, RegexOptions.IgnoreCase);
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
                List<string> strCut = FuncComm.CutYuJu03(strHx, content, ro);//每条只有一个核心词
                foreach (var item in strCut)
                {
                    string ctBiaoDian = FuncComm.CutYuJu06(strHx, strHxQ, strHxQ, item, ro);//按核心词前后最近的的词分割
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
        #region 截取核心词（至前置词及后置词）之间的语句,排空但不排除重复语句，切割成语句集合 切割词优先(CutYuJuHqhB)
        /// <summary>
        /// 截取核心词（至前置词及后置词）之间的语句,排空但不排除重复语句，切割成语句集合（切割词优先）
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
        /// 截取核心词（至前置词及后置词）之间的语句,排空但不排除重复语句，切割成语句集合（切割词优先）
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
        #region 截取核心词前后距离最近关键词之间的数据返回集合(CutYuJuHQH)（核心词优先）
        /// <summary>
        /// 截取核心词前后距离最近关键词之间的数据返回集合（核心词优先）
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
                List<string> strCut = FuncComm.CutYuJu03(strHx, content, ro);
                foreach (var item in strCut)
                {
                    string ctBiaoDian = FuncComm.CutYuJu06(strHx, strHxQ, strHxH, item, ro);
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
        #region 截取两个关键词间的内容
        /// <summary>
        /// 截取两个关键词间的内容
        /// </summary>
        /// <param name="keyQ">前关键词</param>
        /// <param name="keyH">后关键词，可以正则</param>
        /// <param name="content">要截取的内容</param>
        /// <returns>截取出的内容，返回string</returns>
        public static string CutBetween(string keyQ, string keyH, string content)
        {
            string cut = "";
            Regex reg = new Regex(keyH);
            var Hx = reg.Matches(content);
            if (Hx.Count > 0)
            {
                foreach (var hx in Hx)
                {
                    int indexQ = content.IndexOf(keyQ);
                    int indexH = content.IndexOf(hx.ToString());
                    cut = content.Substring(indexQ, indexH - indexQ);
                }
            }
            return cut;
        }
        #endregion
        #region 多个切割词中选择一个作为切割词/// 截取切割词位置到最前或最后(CutYuJuHeQH)
        /// <summary>
        /// 多个切割词中选择一个作为切割词
        /// 截取切割词位置到最前或最后(包含切割词)
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
                //strResult = content.Substring(0, content.IndexOf(cutStr) + cutStr.Length);//含关键词
                strResult = content.Substring(0, content.IndexOf(cutStr));//不含关键词
            }
            //切割词后
            else if (flag == 2)
            {

                strResult = content.Substring(content.IndexOf(cutStr));
            }

            return strResult;

        }
        #endregion
        #region 截取关键词后指定长度，长度不够截取到最后
        /// <summary>
        /// 截取关键词后指定长度，长度不够截取到最后
        /// </summary>
        /// <param name="content"></param>
        /// <param name="hxc"></param>
        /// <param name="len"></param>
        /// <returns></returns>
        public static string CutYuJuHouLength(string content, string hxc, int len)
        {
            string cutStr = "";
            if (content.Contains(hxc))
            {
                int index = content.IndexOf(hxc);
                cutStr = content.Substring(content.IndexOf(hxc));
                if (cutStr.Length > len)
                {
                    cutStr = cutStr.Substring(0, len + hxc.Length);
                }
            }
            return cutStr;
        }
        /// <summary>
        /// 截取关键词后指定长度，返回list集合,长度不过截取到最后
        /// </summary>
        /// <param name="content">截取内容</param>
        /// <param name="hxc">核心词</param>
        /// <param name="len">要截取的长度</param>
        /// <returns></returns>
        public static List<string> CutYuJuHouLengthls(string content, string hxc, int len)
        {
            List<string> lsres = new List<string>();
            var reg = new Regex(hxc);
            var hx = reg.Matches(content);
            if (hx.Count>0)
            {
                for (int i = 0; i < hx.Count; i++)
                {
                    string cutStr = "";
                    cutStr = content.Substring(content.IndexOf(hx[i].ToString()));
                    if (cutStr.Length>len)
                    {
                        cutStr = content.Substring(content.IndexOf(hx[i].ToString()),len);
                    }
                    lsres.Add(cutStr);
                }
            }
            return lsres;
        }
        #endregion
        #region 截取两个关键词之间的内容（第一个关键词找不到用下一个以此类推）(CutYuJuZhiJianHuo)
        /// <summary>
        /// 截取两个关键词之间的内容（第一个关键词找不到用下一个以此类推）
        /// </summary>
        /// <param name="content">内容</param>
        /// <param name="hxq">前关键词，并列关系用|分割</param>
        /// <param name="hxh">后关键词，并列关系用|分割</param>
        /// <param name="isZuihou">未找到后置词时是否截取到最后，true截取到最后</param>
        /// /// <param name="isContain">返回结果是否包含前后关键词</param>
        /// <returns></returns>
        public static string CutYuJuZhiJianHuo(string content, string hxq, string hxh, bool isZuihou, bool isContain)
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
                if (isContain)
                {
                    contentNew = content.Substring(content.IndexOf(qian));
                }
                else
                {
                    contentNew = content.Substring(content.IndexOf(qian) + qian.Length);
                }
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
                if (isContain)
                {
                    strResult = contentNew.Substring(0, contentNew.IndexOf(hou) + hou.Length);
                }
                else
                {
                    strResult = contentNew.Substring(0, contentNew.IndexOf(hou));
                }

            }
            else if (isZuihou == true)
            {
                strResult = contentNew;
            }
            return strResult;
        }
        /// <summary>
        /// 截取两个关键词之间的内容（返回结果包含前后关键词）
        /// </summary>
        /// <param name="content"></param>
        /// <param name="hxq">前关键词，并列关系用|分割</param>
        /// <param name="hxh">后关键词，并列关系用|分割</param>
        /// <param name="isZuihou">未找到后置词时是否截取到最后，true截取到最后</param>
        /// <returns></returns>
        public static string CutYuJuZhiJianHuo(string content, string hxq, string hxh, bool isZuihou)
        {
            return CutYuJuZhiJianHuo(content, hxq, hxh, isZuihou, true);
        }
        #endregion
        #region 转全角、半角的函数
        /// <summary>
        /// 转全角的函数(SBC case)
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
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
        /// <param name="input">输入</param>
        /// <returns></returns>
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
        
    }
}
