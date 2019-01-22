using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace HJSSD.EtlCommon
{
    public static class EtlSysPub
    {
        #region 私有方法

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
        /// 转全角的函数(SBC case)
        /// </summary>
        /// <param name="input">任意字符串</param>
        /// <returns>全角字符串</returns>
        ///<remarks>
        ///全角空格为12288，半角空格为32
        ///其他字符半角(33-126)与全角(65281-65374)的对应关系是：均相差65248
        ///</remarks>        
        private static string ToSBC(string input)
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
        /// 转半角的函数(DBC case)
        /// </summary>
        /// <param name="input">任意字符串</param>
        /// <returns>半角字符串</returns>
        ///<remarks>
        ///全角空格为12288，半角空格为32
        ///其他字符半角(33-126)与全角(65281-65374)的对应关系是：均相差65248
        ///</remarks>
        private static string ToDBC(string input)
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

        /// <summary>
        /// 处理转义字符
        /// </summary>
        /// <param name="strOldString">需要转换的字符串</param>
        /// <returns>转换好的字符串</returns>
        private static string TransferString(string strOldString)
        {
            string strKeyWord = strOldString;
            if (strKeyWord.Contains("("))
            {
                strKeyWord = strKeyWord.Replace("(", @"\(");
            }
            if (strKeyWord.Contains(")"))
            {
                strKeyWord = strKeyWord.Replace(")", @"\)");
            }
            if (strKeyWord.Contains("+"))
            {
                strKeyWord = strKeyWord.Replace("+", @"\+");
            }
            if (strKeyWord.Contains("?"))
            {
                strKeyWord = strKeyWord.Replace("?", @"\?");
            }
            return strKeyWord;
        }

        #endregion

        #region 文本切割公共方法

        /// <summary>
        /// 将一段文本按照标点符号（,.;?!，。；？！）切割成文本列表
        /// </summary>
        /// <param name="content">待切割文本</param>
        /// <returns>文本列表</returns>
        public static List<string> CutContent(string content)
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
        /// 将一段文本按照标点符号（,.;?!，。；？！）切割成文本列表，且可以自定义标点符号
        /// </summary>
        /// <param name="content">待切割文本</param>
        /// <param name="strSign">自定义标点符号</param>
        /// <param name="blClear">是否清除初始化标点符号</param>
        /// <returns>文本列表</returns>
        public static List<string> CutContent(string content, string strSign, bool blClear)
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
        /// 将一段文本按照核心词左或右长度切割成文本列表
        /// </summary>
        /// <param name="strHx">核心词（核心词1|核心词2|核心词3|...）</param>
        /// <param name="content">待切割文本</param>
        /// <param name="blBefore">是否截取核心词左边文本</param>
        /// <param name="cutLength">截取长度</param>
        /// <returns>文本列表</returns>
        public static List<string> CutContent(string strHx, string content, bool blLeft, int cutLength)
        {
            content = ToDBC(content);
            var result = new List<string>();
            //核心词
            var regHx = new Regex(strHx, RegexOptions.IgnoreCase);
            //一个核心词位置
            var HxPosition = -1;
            var hxMatchs = regHx.Matches(content); //检索关键词
            if (blLeft)
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
        /// 将一段文本按照核心词左右长度切割成文本列表
        /// </summary>
        /// <param name="strHx">核心词（核心词1|核心词2|核心词3|...）</param>
        /// <param name="content">待切割文本</param>
        /// <param name="cutLlength">核心词左截取长度</param>
        /// <param name="cutRlength">核心词右截取长度</param>
        /// <returns>文本列表</returns>
        public static List<string> CutContent(string strHx, string content, int cutLlength, int cutRlength)
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

        /// <summary>
        /// 获取两个关键词之间的字符串（包含关键词）
        /// </summary>
        /// <param name="strLeft">前关键词</param>
        /// <param name="strRight">后关键词</param>
        /// <param name="strContent">提取文本</param>
        /// <returns></returns>
        public static string GetMiddleSubString(string strLeft, string strRight, string strContent)
        {
            strContent = ToDBC(strContent);
            string strResult = "";
            //没有截取词不截取
            if (string.IsNullOrEmpty(strLeft) && string.IsNullOrEmpty(strRight))
            {
                strResult = strContent;
            }
            //从截取词到最后（包含截取词）
            if (!string.IsNullOrEmpty(strLeft) && string.IsNullOrEmpty(strRight))
            {
                int leftPosition = strContent.IndexOf(strLeft);
                if (leftPosition >= 0)
                    strResult = strContent.Substring(leftPosition);
                //strResult = strContent.Substring(leftPosition + strLeft.Length);
            }
            //从开始截取到截取词（包含截取词）
            if (string.IsNullOrEmpty(strLeft) && !string.IsNullOrEmpty(strRight))
            {
                int rightPosition = strContent.IndexOf(strRight);
                if (rightPosition >= 0)
                    strResult = strContent.Substring(0, rightPosition + strRight.Length);
                //strResult = strContent.Substring(0, rightPosition);
            }
            //截取两个截取词之间的字符串（包含截取词）
            if (!string.IsNullOrEmpty(strLeft) && !string.IsNullOrEmpty(strRight))
            {
                int leftPosition = strContent.IndexOf(strLeft);
                int rightPosition = strContent.IndexOf(strRight);
                if (leftPosition >= 0 && rightPosition >= 0)
                {
                    strResult = strContent.Substring(leftPosition);
                    //strResult = strContent.Substring(leftPosition + strLeft.Length);
                    int rightPositionTemp = strResult.IndexOf(strRight);
                    if (rightPositionTemp < 0)
                    {
                        strResult = "";
                    }
                    else
                    {
                        strResult = strResult.Substring(0, rightPositionTemp + strRight.Length);
                        //strResult = strResult.Substring(0, rightPosition);
                    }
                }

                //int leftPosition = strContent.IndexOf(strLeft);
                //if (leftPosition >= 0)
                //    strResult = strContent.Substring(leftPosition);
                ////strResult = strContent.Substring(leftPosition + strLeft.Length);
                //int rightPosition = strResult.IndexOf(strRight);
                //if (rightPosition >= 0)
                //    strResult = strResult.Substring(0, rightPosition + strRight.Length);
                ////strResult = strResult.Substring(0, rightPosition);
            }
            return strResult;
        }

        #endregion

        #region 数据提取公共方法

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
        /// <param name="content">文本</param>
        /// <returns></returns>
        public static List<double> GetDoubleList(string content)
        {
            var regex = new Regex(@"\d+[.．]?\d*", RegexOptions.Singleline);
            var matchs = regex.Matches(content);
            var list = (from Match match in matchs select double.Parse(ToDBC(match.Groups[0].Value.ToString()))).ToList();
            return list;
        }

        #endregion

        #region 其他公共方法

        /// <summary>
        /// 正则表达式执行方法
        /// </summary>
        /// <param name="strRegular">正则表达式</param>
        /// <param name="strContent">待匹配文本</param>
        /// <returns></returns>
        public static MatchCollection ExecuteRegular(string strRegular, string strContent)
        {
            var regex = new System.Text.RegularExpressions.Regex(strRegular, RegexOptions.Singleline);
            var matchs = regex.Matches(strContent);
            //foreach (Match match in matchs)
            //{

            //}
            return matchs;
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
        /// <returns></returns>
        public static string GuidTo16String()
        {
            long i = 1;
            foreach (byte b in Guid.NewGuid().ToByteArray())
                i *= ((int)b + 1);
            return string.Format("{0:x}", i - DateTime.Now.Ticks);
        }

        #endregion

        #region 截取方法
        #region 截取核心词至(前后核心词)之间的语句，切割成语句集合(默认不区分大小写)(CutContentHXC)
        /// <summary>
        /// 截取核心词至(前后核心词)之间的语句，切割成语句集合(默认不区分大小写)
        /// </summary>
        /// <param name="hxc">核心词“以|隔开”</param>
        /// <param name="content">被提取内容</param>
        /// <param name="ro">是否区分大小写</param>
        /// <returns></returns>
        public static List<string> CutContentHXC(string hxc, string content, RegexOptions ro)
        {
            var result = new List<string>();
            //核心词
            var regHx = new Regex(hxc, ro);
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
        /// 截取核心词至(前后核心词)之间的语句，切割成语句集合(默认不区分大小写)
        /// </summary>
        /// <param name="hxc">核心词“以|隔开</param>
        /// <param name="content">被提取内容</param>
        /// <returns></returns>
        public static List<string> CutContentHXC(string hxc, string content)
        {
            return CutContentHXC(hxc, content, RegexOptions.IgnoreCase);
        }
        #endregion
        #region 截取核心词(至前置词及后置词)之间的内容(返回一条语句\默认不区分大小写)(CutContentHQHStr)
        /// <summary>
        /// 截取核心词(至前置词及后置词)之间的内容(返回一条语句\默认不区分大小写)
        /// </summary>
        /// <param name="hxc">核心词“以|隔开”</param>
        ///<param name="qian">前置词“以|隔开”</param> 
        /// <param name="hou">后置词“以|隔开”</param>
        /// <param name="content">被提取内容</param>
        /// <param name="ro">是否区分大小写</param>
        /// <returns></returns>
        public static string CutContentHQHStr(string hxc, string qian, string hou, string content, RegexOptions ro)
        {
            string str = "";
            //核心词
            var regHx = new Regex(hxc, ro);
            var regHxQ = new Regex(qian, ro);
            var regHxH = new Regex(hou, ro);
            //一个核心词位置
            var HxPosition = -1;
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
        /// 截取核心词(至前置词及后置词)之间的内容(返回一条语句\默认不区分大小写)
        /// </summary>
        /// <param name="hxc">核心词“以|隔开</param>
        /// <param name="qian">前置词“以|隔开</param>
        /// <param name="hou">后置词“以|隔开</param>
        /// <param name="content">被提取内容</param>
        /// <returns></returns>
        public static string CutContentHQHStr(string hxc, string qian, string hou, string content)
        {
            return CutContentHQHStr(hxc, qian, hou, content, RegexOptions.IgnoreCase);
        }
        #endregion
        #region 截取核心词(至前后置词)之间的内容(返回集合\前后词优先\默认不区分大小写)(CutContentHQHList)
        /// <summary>
        /// 截取核心词(至前后置词)之间的内容(返回集合\前后词优先\默认不区分大小写)
        /// </summary>
        /// <param name="hxc">核心词“以|隔开”</param>
        ///<param name="qian">前置词“以|隔开”</param> 
        /// <param name="hou">后置词“以|隔开”</param>
        /// <param name="content">被提取内容</param>
        /// <param name="ro">是否区分大小写</param>
        /// <returns></returns>
        public static List<string> CutContentHQHList(string hxc, string qian, string hou, string content, RegexOptions ro)
        {
            var result = new List<string>();
            //核心词
            var regHx = new Regex(hxc, ro);
            var regHxQ = new Regex(qian, ro);
            var regHxH = new Regex(hou, ro);
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
        /// 截取核心词(至前后置词)之间的内容(返回集合\前后词优先\默认不区分大小写)
        /// </summary>
        /// <param name="hxc">核心词“以|隔开”</param>
        ///<param name="qian">前置词“以|隔开”</param> 
        /// <param name="hou">后置词“以|隔开”</param>
        /// <param name="content">被提取内容</param>
        /// <returns></returns>
        public static List<string> CutContentHQHList(string hxc, string qian, string hou, string content)
        {
            return CutContentHQHList(hxc, qian, hou, content, RegexOptions.IgnoreCase);
        }
        #endregion
        #region 截取核心词前后距离最近关键词之间的数据返回集合(核心词优先)(CutContentHQHNear)
        /// <summary>
        /// 截取核心词前后距离最近关键词之间的数据返回集合(核心词优先)
        /// </summary>
        /// <param name="hxc">核心词“以|隔开”</param>
        /// <param name="qian">前置词“以|隔开”(标点需转义)@"\：|\。|\:|\."</param>
        /// <param name="hou">后置词“以|隔开”(标点需转义)@"\：|\。|\:|\."</param>
        /// <param name="content">被提取内容</param>
        /// <param name="ro">是否区分大小写</param>
        /// <returns></returns>
        public static List<string> CutContentHQHNear(string hxc, string qian, string hou, string content, RegexOptions ro)
        {
            List<string> ReturnList = new List<string>();
            if (Regex.IsMatch(content, hxc, ro))
            {
                List<string> strCut = EtlSysPub.CutContentHXC(hxc, content, ro);
                foreach (var item in strCut)
                {
                    string ctBiaoDian = EtlSysPub.CutContentHQHStr(hxc, qian, hou, item, ro);
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
        /// <param name="hxc">核心词“以|隔开”</param>
        /// <param name="qian">前置词“以|隔开”(标点需转义)@"\：|\。|\:|\."</param>
        /// <param name="hou">后置词“以|隔开”(标点需转义)@"\：|\。|\:|\."</param>
        /// <param name="content">被提取内容</param>
        /// <returns></returns>
        public static List<string> CutContentHQHNear(string hxc, string qian, string hou, string content)
        {
            return CutContentHQHNear(hxc, qian, hou, content, RegexOptions.IgnoreCase);
        }
        #endregion
        #region 截取核心词后距离最近的语句集和(以后置截取词为主)(CutContentHH)
        /// <summary>
        /// 截取核心词后距离最近的语句集和(以后置截取词为主)
        /// </summary>
        /// <param name="hxc">核心词 |</param>
        /// <param name="hou">后词 |</param>
        /// <param name="content">内容</param>
        /// <param name="ro">是否区分大小写</param>
        /// <returns></returns>
        public static List<string> CutContentHH(string hxc, string hou, string content, RegexOptions ro)
        {
            List<string> ReturnList = new List<string>();
            if (Regex.IsMatch(content, hxc, ro))
            {
                List<string> strCut = EtlSysPub.CutContentHQHList(hxc, hou, hou, content);
                foreach (var item in strCut)
                {
                    string HeHou = item.Substring(Regex.Match(item, hxc, ro).Index);//街区核心词后的部分
                    if (!string.IsNullOrEmpty(HeHou))
                    {
                        ReturnList.Add(HeHou);
                    }
                }
            }
            return ReturnList;
        }
        /// <summary>
        /// 截取核心词后距离最近的语句集和
        /// </summary>
        /// <param name="hxc">核心词 |</param>
        /// <param name="hou">后词 |</param>
        /// <param name="content">内容</param>
        /// <returns></returns>
        public static List<string> CutContentHH(string hxc, string hou, string content)
        {
            return CutContentHH(hxc, hou, content, RegexOptions.IgnoreCase);
        }
        #endregion
        #region 截取核心词前距离最近的语句集和(CutContentHQ)
        /// <summary>
        /// 截取核心词前距离最近的语句集和
        /// </summary>
        /// <param name="hxc">核心词 |</param>
        /// <param name="qian">前词 |</param>
        /// <param name="content"></param>
        /// /// <param name="ro">是否区分大小写</param>
        /// <returns></returns>
        public static List<string> CutContentHQ(string hxc, string qian, string content, RegexOptions ro)
        {
            List<string> ReturnList = new List<string>();
            if (Regex.IsMatch(content, hxc, ro))
            {
                List<string> strCut = EtlSysPub.CutContentHXC(hxc, content, ro);//每条只有一个核心词
                foreach (var item in strCut)
                {
                    string ctBiaoDian = EtlSysPub.CutContentHQHStr(hxc, qian, qian, item, ro);//按核心词前后最近的的词分割
                    string HeQian = ctBiaoDian.Substring(0, Regex.Match(ctBiaoDian, hxc, ro).Index);//截取核心词前的部分
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
        /// <param name="hxc">核心词 |</param>
        /// <param name="qian">前词 |</param>
        /// <param name="content"></param>
        /// <returns></returns>
        public static List<string> CutContentHQ(string hxc, string qian, string content)
        {
            return CutContentHQ(hxc, qian, content, RegexOptions.IgnoreCase);
        }
        #endregion
        #region 截取关键词后指定长度,长度不够截取到最后(CutContentHLength)
        /// <summary>
        /// 截取关键词后指定长度,长度不够截取到最后(CutYuJuHouLength)
        /// </summary>
        /// <param name="content"></param>
        /// <param name="hxc"></param>
        /// <param name="len"></param>
        /// <param name="ro"></param>
        /// <returns></returns>
        public static string CutContentHLength(string content, string hxc, int len, RegexOptions ro)
        {
            string cutStr = "";
            if (Regex.IsMatch(content, hxc, ro))
            {
                Match mc = Regex.Match(content, hxc, ro);
                cutStr = content.Substring(mc.Index);
                if (cutStr.Length > len)
                {
                    cutStr = cutStr.Substring(0, len + mc.Value.Length);
                }
            }
            return cutStr;
        }
        public static string CutContentHLength(string content, string hxc, int len)
        {
            return CutContentHLength(content, hxc, len, RegexOptions.IgnoreCase);
        }
        #endregion
        #region 将一段话按照核心词前或者后长度切割成语句集合(长度为主可跨越核心词)(CutContentLength)
        /// <summary>
        /// 将一段话按照核心词前或者后长度切割成语句集合(长度为主可跨越核心词)
        /// </summary>
        /// <param name="hxc">核心词字符串“以|隔开”</param>
        /// <param name="content">被提取内容</param>
        /// <param name="isBefore">是否是核心词前</param>
        /// <param name="cutLength">截取核心词前后长度</param>
        /// <returns></returns>
        public static List<string> CutContentLength(string hxc, string content, bool isBefore, int cutLength)
        {
            var result = new List<string>();
            //核心词
            var regHx = new Regex(hxc, RegexOptions.IgnoreCase);
            //一个核心词位置
            var HxPosition = -1;
            var hxMatchs = regHx.Matches(content); //检索关键词
            if (isBefore)
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
        #region 多个核心词中选择一个作为切割词截取切割词位置到最前或最后(CutContentQHMost)
        /// <summary>
        /// 多个核心词中选择一个作为切割词截取切割词位置到最前或最后
        /// </summary>
        /// <param name="content"></param>
        /// <param name="hxc">|</param>
        /// <param name="flag">1前2后</param>
        /// <returns></returns>
        public static string CutContentQHMost(string content, string hxc, int flag)
        {
            string strResult = string.Empty;
            List<string> cutList = null;
            string cutStr = string.Empty;
            cutList = hxc.Split('|').ToList();
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
        #region 截取两个关键词之间的内容,前后词不能包含多个截断词(CutContentBetween)
        /// <summary>
        /// 截取两个关键词之间的内容,前后词不能包含多个截断词
        /// </summary>
        /// <param name="content">内容</param>
        /// <param name="qian">前置词</param>
        /// <param name="hou">后置词</param>
        /// <param name="isLast">不包含后置词是否截取到最后</param>
        /// <returns></returns>
        public static string CutContentBetween(string content, string qian, string hou, bool isLast)
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
                if (!strCutOne.Contains(hou) && isLast == true)
                {
                    strEnd = strCutOne;
                }
            }
            return strEnd;
        }
        #endregion
      #region 截取两个关键词之间的内容(第一个关键词找不到用下一个以此类推,截取内容包含截取词)(CutContentBetweenOrder)
        /// <summary>
        /// 截取两个关键词之间的内容(第一个关键词找不到用下一个以此类推,截取内容包含截取词)
        /// </summary>
        /// <param name="content">内容</param>
        /// <param name="qian">前关键词，并列关系用|分割</param>
        /// <param name="hou">后关键词，并列关系用|分割</param>
        /// <param name="isLast">未找到后置词时是否截取到最后，true截取到最后</param>
        /// <returns></returns>
        public static string CutContentBetweenOrder(string content, string qian, string hou, bool isLast)
        {
            string strResult = string.Empty;
            List<string> hxqList = null;
            List<string> hxhList = null;
            string qianC = string.Empty;
            string houC = string.Empty;
            string contentNew = string.Empty;
            if (string.IsNullOrEmpty(content) || string.IsNullOrEmpty(qian))
            {
                return strResult;
            }
            hxqList = qian.Split('|').ToList();
            hxhList = hou.Split('|').ToList();

            foreach (string item in hxqList)
            {
                if (content.Contains(item))
                {
                    qianC = item;
                    break;
                }
            }
            if (!string.IsNullOrEmpty(qianC))
            {
                contentNew = content.Substring(content.IndexOf(qianC));
            }
            foreach (string item in hxhList)
            {
                if (contentNew.Contains(item))
                {
                    houC = item;
                    break;
                }
            }
            if (!string.IsNullOrEmpty(houC))
            {
                strResult = contentNew.Substring(0, contentNew.IndexOf(houC) + houC.Length);
            }
            else if (isLast == true)
            {
                strResult = contentNew;
            }
            return strResult;
        }
        #endregion
        #region 截取两个词之间的一段话(前后可以包含多个词以首次出现的词作为截取词,截取内容不包含截取词)(CutContentBetweenFirst)
        /// <summary>
        /// 截取两个词之间的一段话(前后可以包含多个词以首次出现的词作为截取词,截取内容不包含截取词)
        /// </summary>
        /// <param name="content">内容</param>
        /// <param name="qian">前置词 | 分开</param>
        /// <param name="hou">后置词 | 分开</param>
        /// <param name="isLast">false没有后置词不截取true无后置词截取到最后</param>
        /// <returns></returns>
        public static string CutContentBetweenFirst(string content, string qian, string hou, bool isLast)
        {
            string strResult = string.Empty;
            string strCut = string.Empty;
            if (string.IsNullOrEmpty(content))
            {
                return strResult;
            }

            bool isQ = Regex.IsMatch(content, qian, RegexOptions.IgnoreCase);

            if (isQ)
            {
                Match mcq = Regex.Match(content, qian, RegexOptions.IgnoreCase);
                strCut = content.Substring(mcq.Index + mcq.Value.Length);
                //判断是否包含后置词
                bool isH = Regex.IsMatch(strCut, hou, RegexOptions.IgnoreCase);
                if (isH)
                {
                    Match mch = Regex.Match(strCut, hou, RegexOptions.IgnoreCase);
                    strResult = strCut.Substring(0, mch.Index);
                }
                else if (isLast)
                {
                    strResult = strCut;
                }

            }

            return strResult;
        }
        #endregion
        #endregion


        #region 将DataTable转换为List<T>对象
        /// <summary> 
        /// 将DataTable转换为List<T>对象
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

        #region 将泛类型集合List类转换成DataTable
        /// <summary>
        /// 将泛类型集合List类转换成DataTable
        /// </summary>
        /// <typeparam name="T">实体类</typeparam>
        /// <param name="entitys">需要转换的实体集合</param>
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

        #region 从一段话中获取首次出现的数字(整数小数)
        /// <summary>
        /// 从一段话中获取首次出现的数字(整数小数)
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public static string GetNumberFromString(string content)
        {
            string value = Regex.Match(content, @"\d+(\.\d+)?").Value;
            return value;
        } 
        #endregion

        
       
        
    }
}
