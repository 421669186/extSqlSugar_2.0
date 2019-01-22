/* ==============================================================================
* 功能描述：通用静态方法类  
* 创 建 者：WU
* 创建日期：2016/10/28 10:56:16
* ==============================================================================*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HJSSD.EtlCommon;
using System.Text.RegularExpressions;
using System.Data;
using System.Reflection;
using System.Collections;
using System.Web.Script.Serialization;


namespace CommonHelper
{
    /// <summary>
    /// 通用静态方法类
    /// </summary>
    public static class CommonFunc
    {
        #region --------------------------------------类型编码---------------------------------------------
        public const string RuYuanJiLu = "21601";//入院记录
        public const string RuYuanJiLu24 = "216616";//24小时入院记录
        public const string ShouShuXiangGuanJiLu = "31600";//手术相关记录
        public const string SouCiBingChengJiLu = "31601";//首次病程记录 
        public const string RiChangBingChengJiLu = "31602";//日常病程记录
        public const string ShangJiYiShiChaFangJiLu = "31603"; //上级医师查房记录
        public const string YiNanBingLiTaoLunJiLu = "31604";//疑难病例讨论记录
        public const string JieDuanXiaoJie = "31607";//阶段小结
        public const string HuiZenJiLu = "31609";//会诊记录
        public const string ShuQianXiaoJie = "31610";//术前小结
        public const string ShuQianTaoLun = "31611";//术前讨论记录
        public const string ShouShuJiLu = "31613";//手术记录
        public const string ShuHouShouCiBingChengJiLu = "31615";//术后首次病程记录
        public const string ZhuanRuJiLu = "41601";//转入记录
        public const string ZhuanChuJiLu = "41602";//转出记录
        public const string ZhuanKeXiaoJie = "51601";//转科小结
        public const string ChuYuanJiLu = "61601";//出院记录
        public const string SiWangJiLu = "71601";//死亡记录
        public const string HuLiJiLu = "81601";//护理记录
        public const string PingGuXiangMu = "91601";//评估项目
        public const string QiangJiuJiLu = "91602";//抢救记录

        public const string DianZiWeiJingJianCha = "7054";//电子胃镜检查
        public const string DianZiWeiJingZhiLiao = "7096";//电子胃镜治疗
        public const string JingNeiJingNiXingYiDanGuanZhaoYing = "7131";//经内镜逆行胰胆管造影
        public const string DianZiChangJingJianCha = "7051";//电子肠镜检查
        public const string DianZiChangJingZhiLiao = "7095";//电子肠镜治疗
        public const string XiaoChangJingJianCha = "7128";//小肠镜检查
        public const string BingLiXiBaoXueBaoGao = "7097";//病理细胞学报告



        #endregion

        #region --------------------------------------匹配字典---------------------------------------------
        #region 匹配关键词字典返回itemcode
        /// <summary>
        /// 匹配关键词字典返回itemcode
        /// </summary>
        /// <param name="itemCode"></param>
        /// <param name="recordcontentStr"></param>
        /// <returns></returns>
        public static string GetItemCode(string _mSdCode, string itemCode, string recordcontentStr)
        {
            string itemcode = string.Empty;
            try
            {
                string str = EtlFunc.GetDataItem(_mSdCode, itemCode, recordcontentStr);
                string[] strArr = str.Split('|');
                if (strArr.Length > 0)
                {
                    for (int i = 0; i < strArr.Length; i++)
                    {
                        if (strArr[i].Split('#').Length == 3 && strArr[i].Split('#')[1] == "1")
                        {
                            itemcode = strArr[i].Split('#')[2];
                            break;
                        }
                    }
                }
            }
            catch (Exception)
            {
                itemcode = string.Empty;
            }
            return itemcode;
        }
        #endregion
        #region 判断一段话中是否包含某一关键词
        /// <summary>
        /// 判断一段话中是否包含某一关键词
        /// </summary>
        /// <param name="strContent"></param>
        /// <param name="dict"></param>
        /// <returns></returns>
        public static bool ContentIsContain(string strContent, string dict)
        {
            bool b = false;
            if (strContent.Contains(dict))
            {
                b = true;
            }
            return b;
        }
        #endregion
        #region 判断文本是否符合关键词条件
        /// <summary>
        /// 判断文本是否符合关键词条件
        /// </summary>
        /// /// <param name="_mSdCode">病种代码</param>
        /// <param name="itemCode">关键词代码</param>
        /// <param name="recordcontentStr">提取文本</param>
        /// <returns>符合返回true，否则返回false</returns>
        public static bool isTrue(string _mSdCode, string itemCode, string recordcontentStr)
        {

            bool isTrue = false;
            try
            {
                string str = EtlFunc.GetDataItem(_mSdCode, itemCode, recordcontentStr);
                string[] strArr = str.Split('|');
                if (strArr.Length > 0)
                {
                    for (int i = 0; i < strArr.Length; i++)
                    {
                        if (strArr[i].Split('#').Length == 3 && strArr[i].Split('#')[1] == "1")
                        {
                            isTrue = true;
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                isTrue = false;
            }
            return isTrue;
        }

        /// <summary>
        /// 判断文本是否符合关键词条件（自定义分割标点）
        /// </summary>
        /// /// <param name="_mSdCode">病种代码</param>
        /// <param name="itemCode">关键词代码</param>
        /// /// <param name="biaoDian">自定义分割标点</param>
        /// <param name="recordcontentStr">提取文本</param>
        /// <returns>符合返回true，否则返回false</returns>
        public static bool isTrue(string _mSdCode, string itemCode, string biaoDian, string recordcontentStr)
        {

            bool isTrue = false;
            try
            {
                string str = EtlFunc.GetDataItem(_mSdCode, itemCode, biaoDian, recordcontentStr);
                string[] strArr = str.Split('|');
                if (strArr.Length > 0)
                {
                    for (int i = 0; i < strArr.Length; i++)
                    {
                        if (strArr[i].Split('#').Length == 3 && strArr[i].Split('#')[1] == "1")
                        {
                            isTrue = true;
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                isTrue = false;
            }
            return isTrue;
        }
        #endregion
        #region 判断关键词是否存在  例如：A|B &&C|D && E|F
        public static bool isTrueByKeyWord(string _mSdCode, string itemCode, string recordcontentStr)
        {

            bool isTrue = false;
            try
            {
                string str = EtlFunc.GetKeyWordItem(_mSdCode, itemCode, recordcontentStr);
                string[] strArr = str.Split('|');
                if (strArr.Length > 0)
                {
                    for (int i = 0; i < strArr.Length; i++)
                    {
                        if (strArr[i].Split('#').Length == 3 && strArr[i].Split('#')[1] == "1")
                        {
                            isTrue = true;
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                isTrue = false;
            }
            return isTrue;
        }
        #endregion
        #endregion

        #region --------------------------------------截取方法---------------------------------------------
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
                List<string> strCut = CommonFunc.CutYuJu03(strHx, content, ro);
                foreach (var item in strCut)
                {
                    string ctBiaoDian = CommonFunc.CutYuJu06(strHx, strHxQ, strHxH, item, ro);
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
                List<string> strCut = CommonFunc.CutYuJuHqhB(strHx, strHxH, strHxH, content);
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
        //        List<string> strCut = CommonFunc.CutYuJu03(strHx, content, ro);//每条只有一个核心词
        //        foreach (var item in strCut)
        //        {
        //            string ctBiaoDian = CommonFunc.CutYuJu06(strHx, strHxH, strHxH, item, ro);//按核心词前后最近的的词分割
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
                List<string> strCut = CommonFunc.CutYuJu03(strHx, content, ro);//每条只有一个核心词
                foreach (var item in strCut)
                {
                    string ctBiaoDian = CommonFunc.CutYuJu06(strHx, strHxQ, strHxQ, item, ro);//按核心词前后最近的的词分割
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
        #region 截取两个关键词之间的内容（第一个关键词找不到用下一个以此类推）(CutYuJuZhiJianHuo)
        /// <summary>
        /// 截取两个关键词之间的内容（第一个关键词找不到用下一个以此类推）
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
        #region 多个切割词中选择一个作为切割词/// 截取切割词位置到最前或最后(CutYuJuHeQH)
        /// <summary>
        /// 多个切割词中选择一个作为切割词
        /// 截取切割词位置到最前或最后
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
        #region 截取关键词后指定长度，长度不够截取到最后
        /// <summary>
        /// 截取关键词后指定长度，长度不够截取到最后
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
        #region 将一段话按照核心词前或者后长度切割成语句集合（长度为主可跨越关键词）(CutYuJuL)
        /// <summary>
        /// 将一段话按照核心词前或者后长度切割成语句集合
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
        /// 截取两个关键词之间的内容，第二个关键词不存在则不截取
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
        #region 截取两个词之间的一段话（前后可以包含多个词以首次出现的词作为截取次）
        /// <summary>
        /// 截取两个词之间的一段话（前后可以包含多个词以首次出现的词作为截取次）
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
        #endregion

        #region --------------------------------------字符串操作方法---------------------------------------
        #region 把字符串按照分隔符转换成List<string>集合
        /// <summary>
        /// 把字符串按照分隔符转换成 List
        /// </summary>
        /// <param name="str">源字符串</param>
        /// <param name="speater">分隔符</param>
        /// <param name="toLower">是否转换为小写</param>
        /// <returns></returns>
        public static List<string> GetStrList(string str, char speater, bool toLower)
        {
            List<string> list = new List<string>();
            string[] ss = str.Split(speater);
            foreach (string s in ss)
            {
                if (!string.IsNullOrEmpty(s) && s != speater.ToString())
                {
                    string strVal = s;
                    if (toLower)
                    {
                        strVal = s.ToLower();
                    }
                    list.Add(strVal);
                }
            }
            return list;
        }

        /// <summary>
        /// 把字符串按照分隔符转换成 List
        /// </summary>
        /// <param name="str">源字符串</param>
        /// <param name="speater">分隔符</param>
        /// <param name="toLower">是否转换为小写</param>
        /// <returns></returns>
        public static List<string> GetStrList(string str, char speater)
        {
            return GetStrList(str, speater, false);
        }
        #endregion
        #region 在一个字符串中找出一个特定串所有出现的位置
        /// <summary>
        /// 在一个字符串中找出一个特定串所有出现的位置
        /// </summary>
        /// <param name="str">文本内容</param>
        /// <param name="substr">查找内容</param>
        /// <param name="StartPos">开始位置</param>
        /// <returns></returns>
        public static int[] GetSubStrCountInStr(String str, String substr, int StartPos)
        {
            int foundPos = -1;
            int count = 0;
            List<int> foundItems = new List<int>();

            do
            {
                foundPos = str.IndexOf(substr, StartPos);
                if (foundPos > -1)
                {
                    StartPos = foundPos + 1;
                    count++;
                    foundItems.Add(foundPos);
                }
            } while (foundPos > -1 && StartPos < str.Length);

            return ((int[])foundItems.ToArray());
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
        #endregion

        #region --------------------------------------数据类型转换-----------------------------------------
        #region 将泛类型集合List类转换成DataTable
        /// <summary>
        /// 将泛类型集合List类转换成DataTable
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entitys"></param>
        /// <returns></returns>
        public static DataTable ListToDataTable<T>(List<T> entitys)
        {
            //检查实体集合不能为空
            if (entitys == null || entitys.Count < 1)
            {
                throw new Exception("需转换的集合为空");
            }
            //取出第一个实体的所有Propertie
            Type entityType = entitys[0].GetType();
            PropertyInfo[] entityProperties = entityType.GetProperties();

            //生成DataTable的structure
            //生产代码中，应将生成的DataTable结构Cache起来，此处略
            DataTable dt = new DataTable();
            for (int i = 0; i < entityProperties.Length; i++)
            {
                //dt.Columns.Add(entityProperties[i].Name, entityProperties[i].PropertyType);
                dt.Columns.Add(entityProperties[i].Name);
            }
            //将所有entity添加到DataTable中
            foreach (object entity in entitys)
            {
                //检查所有的的实体都为同一类型
                if (entity.GetType() != entityType)
                {
                    throw new Exception("要转换的集合元素类型不一致");
                }
                object[] entityValues = new object[entityProperties.Length];
                for (int i = 0; i < entityProperties.Length; i++)
                {
                    entityValues[i] = entityProperties[i].GetValue(entity, null);
                }
                dt.Rows.Add(entityValues);
            }
            return dt;
        }
        #endregion
        #region 利用反射将DataTable转换为List<T>对象
        /// <summary> 
        /// 利用反射将DataTable转换为List<T>对象
        /// </summary> 
        /// <param name="dt">DataTable 对象</param> 
        /// <returns>List<T>集合</returns> 
        public static List<T> DataTableToList<T>(DataTable dt) where T : class,new()
        {
            // 定义集合 
            List<T> ts = new List<T>();
            //定义一个临时变量 
            string tempName = string.Empty;
            //遍历DataTable中所有的数据行 
            foreach (DataRow dr in dt.Rows)
            {
                T t = new T();
                // 获得此模型的公共属性 
                PropertyInfo[] propertys = t.GetType().GetProperties();
                //遍历该对象的所有属性 
                foreach (PropertyInfo pi in propertys)
                {
                    tempName = pi.Name;//将属性名称赋值给临时变量 
                    //检查DataTable是否包含此列（列名==对象的属性名）  
                    if (dt.Columns.Contains(tempName))
                    {
                        //取值 
                        object value = dr[tempName];
                        //如果非空，则赋给对象的属性 
                        if (value != DBNull.Value)
                        {
                            pi.SetValue(t, value, null);
                        }
                    }
                }
                //对象添加到泛型集合中 
                ts.Add(t);
            }
            return ts;
        }
        #endregion
        #region Json 字符串 转换为 DataTable数据集合
        /// <summary>
        /// Json 字符串 转换为 DataTable数据集合
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public static DataTable ToDataTable(this string json)
        {
            DataTable dataTable = new DataTable();  //实例化
            DataTable result;
            try
            {
                JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
                javaScriptSerializer.MaxJsonLength = Int32.MaxValue; //取得最大数值
                ArrayList arrayList = javaScriptSerializer.Deserialize<ArrayList>(json);
                if (arrayList.Count > 0)
                {
                    foreach (Dictionary<string, object> dictionary in arrayList)
                    {
                        if (dictionary.Keys.Count<string>() == 0)
                        {
                            result = dataTable;
                            return result;
                        }
                        if (dataTable.Columns.Count == 0)
                        {
                            foreach (string current in dictionary.Keys)
                            {
                                dataTable.Columns.Add(current, dictionary[current].GetType());
                            }
                        }
                        DataRow dataRow = dataTable.NewRow();
                        foreach (string current in dictionary.Keys)
                        {
                            dataRow[current] = dictionary[current];
                        }

                        dataTable.Rows.Add(dataRow); //循环添加行到DataTable中
                    }
                }
            }
            catch
            {
            }
            result = dataTable;
            return result;
        }
        #endregion
        //#region DataTable 转换为Json 字符串
        ///// <summary>
        ///// DataTable 对象 转换为Json 字符串
        ///// </summary>
        ///// <param name="dt"></param>
        ///// <returns></returns>
        //public static string ToJson(this DataTable dt)
        //{
        //    JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
        //    javaScriptSerializer.MaxJsonLength = Int32.MaxValue; //取得最大数值
        //    ArrayList arrayList = new ArrayList();
        //    foreach (DataRow dataRow in dt.Rows)
        //    {
        //        Dictionary<string, object> dictionary = new Dictionary<string, object>();  //实例化一个参数集合
        //        foreach (DataColumn dataColumn in dt.Columns)
        //        {
        //            dictionary.Add(dataColumn.ColumnName, dataRow[dataColumn.ColumnName].ToStr());
        //        }
        //        arrayList.Add(dictionary); //ArrayList集合中添加键值
        //    }

        //    return javaScriptSerializer.Serialize(arrayList);  //返回一个json字符串
        //}
        //#endregion
        //#region 转换为string字符串类型
        ///// <summary>
        /////  转换为string字符串类型
        ///// </summary>
        ///// <param name="s">获取需要转换的值</param>
        ///// <param name="format">需要格式化的位数</param>
        ///// <returns>返回一个新的字符串</returns>
        //public static string ToStr(this object s, string format = "")
        //{
        //    string result = "";
        //    try
        //    {
        //        if (format == "")
        //        {
        //            result = s.ToString();
        //        }
        //        else
        //        {
        //            result = string.Format("{0:" + format + "}", s);
        //        }
        //    }
        //    catch
        //    {
        //    }
        //    return result;
        //}
        //#endregion

        //#region 拓展方法（数值、日期、布尔、字符串）类型转换
        //#region 数值转换
        ///// <summary>
        ///// 转换为整型
        ///// </summary>
        ///// <param name="data">数据</param>
        //public static int ToInt(this object data)
        //{
        //    if (data == null)
        //        return 0;
        //    int result;
        //    var success = int.TryParse(data.ToString(), out result);
        //    if (success)
        //        return result;
        //    try
        //    {
        //        return Convert.ToInt32(ToDouble(data, 0));
        //    }
        //    catch (Exception)
        //    {
        //        return 0;
        //    }
        //}

        ///// <summary>
        ///// 转换为可空整型
        ///// </summary>
        ///// <param name="data">数据</param>
        //public static int? ToIntOrNull(this object data)
        //{
        //    if (data == null)
        //        return null;
        //    int result;
        //    bool isValid = int.TryParse(data.ToString(), out result);
        //    if (isValid)
        //        return result;
        //    return null;
        //}

        ///// <summary>
        ///// 转换为双精度浮点数
        ///// </summary>
        ///// <param name="data">数据</param>
        //public static double ToDouble(this object data)
        //{
        //    if (data == null)
        //        return 0;
        //    double result;
        //    return double.TryParse(data.ToString(), out result) ? result : 0;
        //}

        ///// <summary>
        ///// 转换为双精度浮点数,并按指定的小数位4舍5入
        ///// </summary>
        ///// <param name="data">数据</param>
        ///// <param name="digits">小数位数</param>
        //public static double ToDouble(this object data, int digits)
        //{
        //    return Math.Round(ToDouble(data), digits);
        //}

        ///// <summary>
        ///// 转换为可空双精度浮点数
        ///// </summary>
        ///// <param name="data">数据</param>
        //public static double? ToDoubleOrNull(this object data)
        //{
        //    if (data == null)
        //        return null;
        //    double result;
        //    bool isValid = double.TryParse(data.ToString(), out result);
        //    if (isValid)
        //        return result;
        //    return null;
        //}

        ///// <summary>
        ///// 转换为高精度浮点数
        ///// </summary>
        ///// <param name="data">数据</param>
        //public static decimal ToDecimal(this object data)
        //{
        //    if (data == null)
        //        return 0;
        //    decimal result;
        //    return decimal.TryParse(data.ToString(), out result) ? result : 0;
        //}

        ///// <summary>
        ///// 转换为高精度浮点数,并按指定的小数位4舍5入
        ///// </summary>
        ///// <param name="data">数据</param>
        ///// <param name="digits">小数位数</param>
        //public static decimal ToDecimal(this  object data, int digits)
        //{
        //    return Math.Round(ToDecimal(data), digits);
        //}

        ///// <summary>
        ///// 转换为可空高精度浮点数
        ///// </summary>
        ///// <param name="data">数据</param>
        //public static decimal? ToDecimalOrNull(this  object data)
        //{
        //    if (data == null)
        //        return null;
        //    decimal result;
        //    bool isValid = decimal.TryParse(data.ToString(), out result);
        //    if (isValid)
        //        return result;
        //    return null;
        //}

        ///// <summary>
        ///// 转换为可空高精度浮点数,并按指定的小数位4舍5入
        ///// </summary>
        ///// <param name="data">数据</param>
        ///// <param name="digits">小数位数</param>
        //public static decimal? ToDecimalOrNull(this object data, int digits)
        //{
        //    var result = ToDecimalOrNull(data);
        //    if (result == null)
        //        return null;
        //    return Math.Round(result.Value, digits);
        //}

        //#endregion
        //#region 日期转换
        ///// <summary>
        ///// 转换为日期
        ///// </summary>
        ///// <param name="data">数据</param>
        //public static DateTime ToDate(this object data)
        //{
        //    if (data == null)
        //        return DateTime.MinValue;
        //    DateTime result;
        //    return DateTime.TryParse(data.ToString(), out result) ? result : DateTime.MinValue;
        //}

        ///// <summary>
        ///// 转换为可空日期
        ///// </summary>
        ///// <param name="data">数据</param>
        //public static DateTime? ToDateOrNull(this object data)
        //{
        //    if (data == null)
        //        return null;
        //    DateTime result;
        //    bool isValid = DateTime.TryParse(data.ToString(), out result);
        //    if (isValid)
        //        return result;
        //    return null;
        //}

        //#endregion
        //#region 布尔转换
        ///// <summary>
        ///// 转换为布尔值
        ///// </summary>
        ///// <param name="data">数据</param>
        //public static bool ToBool(this object data)
        //{
        //    if (data == null)
        //        return false;
        //    bool? value = GetBool(data);
        //    if (value != null)
        //        return value.Value;
        //    bool result;
        //    return bool.TryParse(data.ToString(), out result) && result;
        //}

        ///// <summary>
        ///// 获取布尔值
        ///// </summary>
        //private static bool? GetBool(this object data)
        //{
        //    switch (data.ToString().Trim().ToLower())
        //    {
        //        case "0":
        //            return false;
        //        case "1":
        //            return true;
        //        case "是":
        //            return true;
        //        case "否":
        //            return false;
        //        case "yes":
        //            return true;
        //        case "no":
        //            return false;
        //        default:
        //            return null;
        //    }
        //}

        ///// <summary>
        ///// 转换为可空布尔值
        ///// </summary>
        ///// <param name="data">数据</param>
        //public static bool? ToBoolOrNull(this object data)
        //{
        //    if (data == null)
        //        return null;
        //    bool? value = GetBool(data);
        //    if (value != null)
        //        return value.Value;
        //    bool result;
        //    bool isValid = bool.TryParse(data.ToString(), out result);
        //    if (isValid)
        //        return result;
        //    return null;
        //}

        //#endregion
        //#region 字符串转换
        ///// <summary>
        ///// 转换为字符串
        ///// </summary>
        ///// <param name="data">数据</param>
        //public static string ToString(this object data)
        //{
        //    return data == null ? string.Empty : data.ToString().Trim();
        //}
        //#endregion
        //#endregion
        //#region 扩展方法（时间格式转换）
        ///// <summary>
        ///// 获取格式化字符串，带时分秒，格式："yyyy-MM-dd HH:mm:ss"
        ///// </summary>
        ///// <param name="dateTime">日期</param>
        ///// <param name="isRemoveSecond">是否移除秒</param>
        //public static string ToDateTimeString(this DateTime dateTime, bool isRemoveSecond = false)
        //{
        //    if (isRemoveSecond)
        //        return dateTime.ToString("yyyy-MM-dd HH:mm");
        //    return dateTime.ToString("yyyy-MM-dd HH:mm:ss");
        //}
        ///// <summary>
        ///// 获取格式化字符串，不带时分秒，格式："yyyy-MM-dd"
        ///// </summary>
        ///// <param name="dateTime">日期</param>
        //public static string ToDateString(this DateTime dateTime)
        //{
        //    return dateTime.ToString("yyyy-MM-dd");
        //}
        ///// <summary>
        ///// 获取格式化字符串，不带时分秒，格式："yyyy-MM-dd"
        ///// </summary>
        ///// <param name="dateTime">日期</param>
        //public static string ToDateString()
        //{
        //    return DateTime.Now.ToString("yyyy-MM-dd");
        //}
        ///// <summary>
        ///// 获取格式化字符串，不带时分秒，格式："yyyy年MM月dd日"
        ///// </summary>
        ///// <param name="dateTime">日期</param>
        //public static string ToChineseDateString(this DateTime dateTime)
        //{
        //    return string.Format("{0}年{1}月{2}日", dateTime.Year, dateTime.Month, dateTime.Day);
        //}
        ///// <summary>
        ///// 获取格式化字符串，带时分秒，格式："yyyy年MM月dd日 HH时mm分"
        ///// </summary>
        ///// <param name="dateTime">日期</param>
        ///// <param name="isRemoveSecond">是否移除秒</param>
        //public static string ToChineseDateTimeString(this DateTime dateTime, bool isRemoveSecond = false)
        //{
        //    StringBuilder result = new StringBuilder();
        //    result.AppendFormat("{0}年{1}月{2}日", dateTime.Year, dateTime.Month, dateTime.Day);
        //    result.AppendFormat(" {0}时{1}分", dateTime.Hour, dateTime.Minute);
        //    if (isRemoveSecond == false)
        //        result.AppendFormat("{0}秒", dateTime.Second);
        //    return result.ToString();
        //}
        //#endregion
        
        #endregion

        #region --------------------------------------其他方法---------------------------------------------
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
        #region ORACLE 语句中，IN 超过1000个的解决方法
        public static string GetSqlIn(string sql, List<string> list, string colName)
        {
            string rtnSql = string.Empty;
            StringBuilder sb = new StringBuilder();
            sb.Append(sql);
            if (list == null)
            {
                rtnSql = sql;
            }
            int maxCount = 900;//每组最大个数
            if (list.Count < maxCount)
            {
                string strList = EtlFunc.StringListToString(list);
                sb.AppendFormat(" AND {0} IN({1})", colName, strList);
                rtnSql = sb.ToString();
            }
            else
            {
                int j = maxCount;
                sb.Append(" AND (");
                for (int i = 0; i < list.Count; i += maxCount)
                {
                    List<string> cList = new List<string>();
                    cList = list.Take(j).Skip(i).ToList();
                    j += maxCount;
                    string strList = EtlFunc.StringListToString(cList);
                    sb.AppendFormat(" {0} IN({1}) OR ", colName, strList);
                }
                rtnSql = sb.ToString().Substring(0, sb.ToString().Length - 3);
                rtnSql = rtnSql + ")";
            }

            return rtnSql;
        }
        #endregion
        #region 判断是否满足关键词前后n个字符包含或排除(IsPanDuanItem)
        /// <summary>
        /// 判断是否满足关键词前后n个字符包含或排除
        /// </summary>
        /// <param name="content">判断内容</param>
        /// <param name="hxc">核心词</param>
        /// <param name="pdc">判断词</param>
        /// <param name="isQian">true前false后</param>
        /// <param name="lenth">前后多长</param>
        /// <param name="isBaoHan">true包含false排除</param>
        /// <returns></returns>
        public static bool IsPanDuanItem(string content, string hxc, string pdc, bool isQian, int lenth, bool isBaoHan)
        {
            bool isOk = false;
            List<string> cutLists = EtlFunc.CutYuJu(hxc, content, isQian, lenth);
            foreach (string item in cutLists)
            {
                if (isBaoHan == true)//包含词
                {
                    if (Regex.IsMatch(item, pdc))
                    {
                        isOk = true;
                        break;
                    }
                }
                else if (isBaoHan == false)//排除词
                {
                    if (!Regex.IsMatch(item, pdc))
                    {
                        isOk = true;
                        break;
                    }
                }
            }
            return isOk;
        }
        #endregion
        #region 判断是否满足关键词前后n个字符包含或排除（长度为主可跨越关键词）(IsPanDuanItem2)
        /// <summary>
        /// 判断是否满足关键词前后n个字符包含或排除（长度为主可跨越关键词）
        /// </summary>
        /// <param name="content">判断内容</param>
        /// <param name="hxc">核心词</param>
        /// <param name="pdc">判断词</param>
        /// <param name="isQian">true前false后</param>
        /// <param name="lenth">前后多长</param>
        /// <param name="isBaoHan">true包含false排除</param>
        /// <returns></returns>
        public static bool IsPanDuanItem2(string content, string hxc, string pdc, bool isQian, int lenth, bool isBaoHan)
        {
            bool isOk = false;
            List<string> cutLists = CommonFunc.CutYuJuL(hxc, content, isQian, lenth);
            foreach (string item in cutLists)
            {
                if (isBaoHan == true)//包含词
                {
                    if (Regex.IsMatch(item, pdc, RegexOptions.IgnoreCase))
                    {
                        isOk = true;
                        break;
                    }
                }
                else if (isBaoHan == false)//排除词
                {
                    if (!Regex.IsMatch(item, pdc, RegexOptions.IgnoreCase))
                    {
                        isOk = true;
                        break;
                    }
                }
            }
            return isOk;
        }
        #endregion
        #endregion

        
    }
}
