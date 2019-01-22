using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HJ.Common.Funcs
{
    /// <summary>
    /// 逻辑模型
    /// </summary>
    public class LogicTemplate
    {
        public static string coreWord = "coreword";
        public static string CutToWords = "coreword-direction-keyword";
        public static string CutToDiffWords = "coreword-direction-beforeword-afterword";
        public static string CutToLen = "coreword-direction-length";
        public static string CutToDiffLenth = "coreword-direction-beforelength-afterlength";
        public static string CutClude = "coreword-direction-clude";
        public static string CutToLenClude = "coreword-direction-length-clude";
        public static string CutToWordClude = "coreword-direction-keyword-clude";
        public static string CutToMix = "coreword-direction-beforelength-afterword";
        public static string CutToMixT = "coreword-direction-beforeword-afterlength";
    }
}
