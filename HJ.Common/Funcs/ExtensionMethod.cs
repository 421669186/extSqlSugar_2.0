﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Linq;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace HJ.Common.Funcs
{
    public static class ExtensionMethod
    {
        #region 截取方法
        /// <summary>
        /// 返回字符串截取的操作类
        /// </summary>
        /// <param name="content"></param>
        /// <param name="coreWord"></param>
        /// <returns></returns>
        public static ICoreWord CoreWord(this string content, string coreWord)
        {
            UnitFuns manager = new UnitFuns(new List<string> { content });
            manager.coreWord(coreWord);
            return manager;
        }

        public static ICoreWord CoreWord(this string content, List<Match> coreWord)
        {
            UnitFuns manager = new UnitFuns(new List<string> { content });
            manager.coreWord(coreWord);
            return manager;
        }

        public static ICoreWord CoreWord(this string content, List<string> coreWord)
        {
            UnitFuns manager = new UnitFuns(new List<string> { content });
            for (int i = 0; i < coreWord.Count; i++)
            {
                if (content.Include(coreWord[i]))
                {
                    manager.coreWord(coreWord[i]);
                    break;
                }
            }
            return manager;
        }

        /// <summary>
        /// 返回字符串截取的操作类
        /// </summary>
        /// <param name="contentList"></param>
        /// <param name="coreWord"></param>
        /// <returns></returns>
        public static ICoreWord CoreWord(this List<string> contentList, string coreWord)
        {
            UnitFuns manager = new UnitFuns(contentList);
            manager.coreWord(coreWord);
            return manager;
        }

        /// <summary>
        /// 包含
        /// </summary>
        /// <param name="content"></param>
        /// <param name="words"></param>
        /// <returns></returns>
        public static bool Include(this string content, string words)
        {
            return new RegexMethod(content).Include(words);
        }

        /// <summary>
        /// 不包含
        /// </summary>
        /// <param name="content"></param>
        /// <param name="words"></param>
        /// <returns></returns>
        public static bool Exclude(this string content, string words)
        {
            return new RegexMethod(content).Exclude(words);
        }

        /// <summary>
        /// 包含
        /// </summary>
        /// <param name="content"></param>
        /// <param name="words"></param>
        /// <returns></returns>
        public static List<string> Include(this List<string> content, string words)
        {
            var list = from str in content where new RegexMethod(str).Include(words) select str;
            return list.ToList<string>();
        }

        /// <summary>
        /// 不包含
        /// </summary>
        /// <param name="content"></param>
        /// <param name="words"></param>
        /// <returns></returns>
        public static List<string> Exclude(this List<string> content, string words)
        {
            var list = from str in content where new RegexMethod(str).Exclude(words) select str;
            return list.ToList<string>();
        }

        /// <summary>
        /// 返回正则表达式的操作类
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public static IRegexMethod UseReg(this string content)
        {
            return new RegexMethod(content);
        }

        /// <summary>
        /// 返回中文处理的操作类
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public static ChineseSrtExtension UseCHS(this  string content)
        {
            return new ChineseSrtExtension(content);
        }
        #endregion

        #region 时间格式转换
        /// <summary>
        /// 获取格式化字符串，带时分秒，格式："yyyy-MM-dd HH:mm:ss"
        /// </summary>
        /// <param name="dateTime">日期</param>
        /// <param name="isRemoveSecond">是否移除秒</param>
        public static string ToDateTimeString(this DateTime dateTime, bool isRemoveSecond = false)
        {
            if (isRemoveSecond)
                return dateTime.ToString("yyyy-MM-dd HH:mm");
            return dateTime.ToString("yyyy-MM-dd HH:mm:ss");
        }

        /// <summary>
        /// 获取格式化字符串，不带时分秒，格式："yyyy-MM-dd"
        /// </summary>
        /// <param name="dateTime">日期</param>
        public static string ToDateString(this DateTime dateTime)
        {
            return dateTime.ToString("yyyy-MM-dd");
        }

        /// <summary>
        /// 获取格式化字符串，不带时分秒，格式："yyyy年MM月dd日"
        /// </summary>
        /// <param name="dateTime">日期</param>
        public static string ToChineseDateString(this DateTime dateTime)
        {
            return string.Format("{0}年{1}月{2}日", dateTime.Year, dateTime.Month, dateTime.Day);
        }

        /// <summary>
        /// 获取格式化字符串，带时分秒，格式："yyyy年MM月dd日 HH时mm分"
        /// </summary>
        /// <param name="dateTime">日期</param>
        /// <param name="isRemoveSecond">是否移除秒</param>
        public static string ToChineseDateTimeString(this DateTime dateTime, bool isRemoveSecond = false)
        {
            StringBuilder result = new StringBuilder();
            result.AppendFormat("{0}年{1}月{2}日", dateTime.Year, dateTime.Month, dateTime.Day);
            result.AppendFormat(" {0}时{1}分", dateTime.Hour, dateTime.Minute);
            if (isRemoveSecond == false)
                result.AppendFormat("{0}秒", dateTime.Second);
            return result.ToString();
        }
        #endregion

        // 利用二进制序列化和反序列实现
        public static T DeepCopy<T>(this T obj)
        {
            object retval;
            using (MemoryStream ms = new MemoryStream())
            {
                BinaryFormatter bf = new BinaryFormatter();
                // 序列化成流
                bf.Serialize(ms, obj);
                ms.Seek(0, SeekOrigin.Begin);
                // 反序列化成对象
                retval = bf.Deserialize(ms);
                ms.Close();
            }

            return (T)retval;
        }
    }

    public class ChineseSrtExtension
    {
        string content;//文本
        public ChineseSrtExtension(string str)
        { content = str; }

        /// <summary>
        /// 转全角的函数(SBC case)
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public string ToSBC()
        {
            //半角转全角：
            char[] c = content.ToCharArray();
            for (int i = 0; i < c.Length; i++)
            {
                if (c[i] == 32) //半角空格
                {
                    c[i] = (char)12288; //全角空格
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
        /// <param name="content">输入</param>
        /// <returns></returns>
        public string ToDBC()
        {
            char[] c = content.ToCharArray();
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
        /// 中文数字转阿拉伯数字
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public int ToIntFromCN()
        {
            char[] chnNum = { '零', '一', '二', '三', '四', '五', '六', '七', '八', '九' };
            Dictionary<char, int> dict = new Dictionary<char, int>();
            for (int i = 0; i < chnNum.Length; i++)
                dict.Add(chnNum[i], i);
            dict.Add('十', 10);
            dict.Add('百', 100);
            dict.Add('千', 1000);
            dict.Add('万', 10000);

            content = Regex.Replace(content, "零", "");

            int value = 0;
            int sectionNum = 0;
            for (int i = 0; i < content.Length; i++)
            {
                int v = dict[content[i]];
                if (v == 10 || v == 100 || v == 1000 || v == 10000)
                {//如果数值是权位则相乘
                    sectionNum = v * sectionNum;
                    value = value + sectionNum;
                }
                else if (i == content.Length - 1)
                {
                    value = value + v;
                }
                else
                {
                    sectionNum = v;
                }
            }
            return value;
        }

        /// <summary>
        /// 罗马数字转数值
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        public int ToIntFromRoman()
        {
            if (content.Length < 1) return 0;
            int result = 0;
            int current = 0;
            int pre = singleRomanToInt(content[0]);
            int temp = pre;
            for (int i = 1; i < content.Length; i++)
            {
                current = singleRomanToInt(content[i]);
                if (current == pre)
                    temp += current;
                else if (current > pre)
                {
                    temp = current - temp;
                }
                else if (current < pre)
                {
                    result += temp;
                    temp = current;
                }
                pre = current;
            }
            result += temp;
            return result;

        }

        public int singleRomanToInt(char c)
        {
            switch (c)
            {
                case 'I':
                    return 1;
                case 'V':
                    return 5;
                case 'X':
                    return 10;
                case 'L':
                    return 50;
                case 'C':
                    return 100;
                case 'D':
                    return 500;
                case 'M':
                    return 1000;
                default:
                    return 0;
            }
        }

        #region 拼音码转化字典
        private readonly Dictionary<int, string> CodeCollections = new Dictionary<int, string> {
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
        /// 汉字转拼音
        /// </summary>
        /// <param name="txt">需要转换的汉字</param>
        /// <returns>返回汉字对应的拼音</returns>
        public string GetPinYin()
        {
            content = content.Trim();
            byte[] arr = new byte[2];   //每个汉字为2字节 
            StringBuilder result = new StringBuilder();//使用StringBuilder优化字符串连接
            int charCode = 0;
            int arr1 = 0;
            int arr2 = 0;
            char[] arrChar = content.ToCharArray();
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
        public string GetChineseSpell()
        {
            int len = content.Length;
            string myStr = "";
            for (int i = 0; i < len; i++)
            {
                myStr += getSpell(content.Substring(i, 1));
            }
            return myStr;
        }

        /// <summary>
        /// 获取单个中文的首字母
        /// </summary>
        /// <param name="cnChar"></param>
        /// <returns></returns>
        private string getSpell(string cnChar)
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
        /// 获取文本中所有中文字符
        /// </summary>
        /// <returns></returns>
        public string GetCHS()
        {
            return Regex.Replace(content, "[^\u4e00-\u9fa5]", ""); ;
        }
    }
}
