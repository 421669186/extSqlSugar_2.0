using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using HJ.Common.Trans;

namespace HJ.Common.Funcs
{
    [Serializable]
    public class Expression : IExpression
    {
        public List<Unit> units { get; set; }
        public bool coreFirst { get; set; }
        public bool toLast { get; set; }
        public bool toFirst { get; set; }
        public bool withoutCore { get; set; }
        public bool withoutKey { get; set; }
        public int wordIndex { get; set; }
        public bool isGetMatch { get; set; }
        public bool ignoreCE { get; set; }
        public RegexOptions ro { get; set; }

        public Expression()
        {
            units = new List<Unit>();
            ro = RegexOptions.IgnoreCase | RegexOptions.Singleline;
            wordIndex = 1;
            coreFirst = false;
            toLast = false;
            toFirst = false;
            withoutCore = false;
            withoutKey = false;
            isGetMatch = false;
            ignoreCE = false;
        }

        public List<T> interpret<T>(string content)
        {
            if (string.IsNullOrEmpty(content))
                return new List<T>();

            List<string> list = new List<string>();
            List<Match> matches = new List<Match>();
            List<string> include = new List<string>(), exclude = new List<string>();

            units.ForEach(unit =>
            {
                if (unit.expression != null)
                {
                    unit.value = unit.expression.interpret<Match>(content);
                }
                else if (Regex.IsMatch(unit.name, "word") && unit.value is string)
                {
                    if (unit.value.ToString().Trim() == string.Empty)
                        unit.value = new List<Match>();
                    else
                    {
                        string tempStr = IgnoreCEP(unit.value.ToString());
                        unit.value = ToList(Regex.Matches(content, tempStr, ro));
                    }
                }
            });

            string template = GetTemplate(units);

            if (template == LogicTemplate.coreWord)
            {
                if ((units[0].value as List<Match>).Count > 0)
                {
                    if (isGetMatch)
                        matches = units[0].value as List<Match>;
                    else
                        list.Add(content);
                }
            }
            else if (template == LogicTemplate.CutToWords)
            {
                List<Match> beforeKey = null, afterKey = null;
                switch (units[1].value.ToString())
                {
                    case "before":
                        beforeKey = units[2].value as List<Match>;
                        break;
                    case "after":
                        afterKey = units[2].value as List<Match>;
                        break;
                    case "both":
                        beforeKey = afterKey = units[2].value as List<Match>;
                        break;
                }
                if (isGetMatch)
                {
                    if (units[1].value.ToString() == "before")
                        matches = IndexMethod.GetKeyMatches(units[0].value as List<Match>, beforeKey, wordIndex, true);
                    else if (units[1].value.ToString() == "after")
                        matches = IndexMethod.GetKeyMatches(units[0].value as List<Match>, afterKey, wordIndex, false);
                }
                else
                {
                    list = IndexMethod.CutWord(content, units[0].value as List<Match>, beforeKey, afterKey, coreFirst, toLast, toFirst, withoutCore, withoutKey, wordIndex, ro);
                }
            }
            else if (template == LogicTemplate.CutToDiffWords)
            {
                List<Match> beforeKey = units[2].value as List<Match>;
                List<Match> afterKey = units[3].value as List<Match>;
                list = IndexMethod.CutWord(content, units[0].value as List<Match>, beforeKey, afterKey, coreFirst, toLast, toFirst, withoutCore, withoutKey, wordIndex, ro);
            }
            else if (template == LogicTemplate.CutToLen)
            {
                int leftLen = 0, rightLen = 0;
                switch (units[1].value.ToString())
                {
                    case "before":
                        leftLen = units[2].value.ToInt();
                        break;
                    case "after":
                        rightLen = units[2].value.ToInt();
                        break;
                    case "both":
                        leftLen = rightLen = units[2].value.ToInt();
                        break;
                }
                list = IndexMethod.CutLength(content, units[0].value as List<Match>, leftLen, rightLen, coreFirst, toFirst, toLast, withoutCore, ro);
            }
            else if (template == LogicTemplate.CutToDiffLenth)
            {
                list = IndexMethod.CutLength(content, units[0].value as List<Match>, units[2].value.ToInt(), units[3].value.ToInt(), coreFirst, toFirst, toLast, withoutCore, ro);
            }
            else if (template == LogicTemplate.CutClude)
            {
                GenerateCludeWord(2, include, exclude);
                List<Match> keyMatches = new List<Match>();
                if (units[1].value.ToString() == "before")
                    keyMatches = ToList(Regex.Matches(content, "^", ro));
                else
                    keyMatches = ToList(Regex.Matches(content, "$", ro));

                if (isGetMatch && include != null && include.Count == 1)
                    matches = IndexMethod.GetIncludeMatches(content, units[0].value as List<Match>, (units[1].value.ToString() == "before"), keyMatches, include[0], wordIndex, ro);
                else
                    matches = IndexMethod.IsConditionWord(content, units[0].value as List<Match>, (units[1].value.ToString() == "before"), keyMatches, include, exclude, wordIndex, toFirst, toLast, ro);
            }
            else if (template == LogicTemplate.CutToLenClude)
            {
                GenerateCludeWord(3, include, exclude);

                if (isGetMatch && include != null && include.Count == 1)
                    matches = IndexMethod.GetIncludeMatches(content, units[0].value as List<Match>, (units[1].value.ToString() == "before"), units[2].value, include[0], wordIndex, ro);
                else
                    matches = IndexMethod.IsConditionLength(content, units[0].value as List<Match>, (units[1].value.ToString() == "before"), units[2].value.ToInt(), include, exclude, toFirst, toLast, ro);
            }
            else if (template == LogicTemplate.CutToWordClude)
            {
                GenerateCludeWord(3, include, exclude);

                if (isGetMatch && include != null && include.Count == 1)
                    matches = IndexMethod.GetIncludeMatches(content, units[0].value as List<Match>, (units[1].value.ToString() == "before"), units[2].value, include[0], wordIndex, ro);
                else
                    matches = IndexMethod.IsConditionWord(content, units[0].value as List<Match>, (units[1].value.ToString() == "before"), units[2].value as List<Match>, include, exclude, wordIndex, toFirst, toLast, ro);
            }
            else if (template == LogicTemplate.CutToMix)
            {
                list = IndexMethod.CutMix(content, units[0].value as List<Match>, units[2].value.ToInt(), units[3].value as List<Match>, coreFirst, toFirst, toLast, withoutCore, withoutKey, wordIndex, false, ro);
            }
            else if (template == LogicTemplate.CutToMixT)
            {
                list = IndexMethod.CutMix(content, units[0].value as List<Match>, units[3].value.ToInt(), units[2].value as List<Match>, coreFirst, toFirst, toLast, withoutCore, withoutKey, wordIndex, true, ro);
            }

            Type type = typeof(T);
            if (matches != null && matches.Count > 0)
            {
                if (type.Name == "String")
                    list.Add(content);
                else if (type.Name == "Match")
                    return matches.Cast<T>().ToList<T>();
            }

            if (type.Name == "String")
                return list.Cast<T>().ToList<T>();
            else
                return new List<T>();
        }

        private string IgnoreCEP(string strTemp)
        {
            if (ignoreCE)
            {
                string strCHS = strTemp.UseReg().Match(@"\p{P}+(\|\p{P}+)+");

                Dictionary<char, char> charDict = new Dictionary<char, char>();
                charDict.Add(';', '；');
                charDict.Add(',', '，');
                charDict.Add('.', '。');
                charDict.Add(':', '：');
                charDict.Add('?', '？');

                char[] listcharrr = strCHS.ToCharArray();
                string strwfc = string.Empty;
                for (int i = 0; i < listcharrr.Length; i++)
                {
                    char c = listcharrr[i];
                    strwfc += c;
                    if (charDict.ContainsKey(c))
                    {
                        strwfc += "|" + charDict[c].ToString();
                    }
                }

                return strTemp.UseReg().Replace(@"\p{P}+(\|\p{P}+)+", strwfc);
            }
            return strTemp;
        }

        private void GenerateCludeWord(int index, List<string> include, List<string> exclude)
        {
            for (int i = index; i < units.Count; i++)
            {
                if (units[i].value != null)
                {
                    if (units[i].name == "include")
                        include.Add(units[i].value.ToString());
                    else if (units[i].name == "exclude")
                        exclude.Add(units[i].value.ToString());
                }
            }
        }

        protected List<Match> ToList(MatchCollection matchList)
        {
            List<Match> list = new List<Match>();
            foreach (Match match in matchList)
            {
                list.Add(match);
            }
            return list;
        }

        private string GetTemplate(List<Unit> units)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < units.Count; i++)
            {
                if (units[i].name.Contains("clude"))
                {
                    sb.Append("clude-");
                    break;
                }
                else
                    sb.Append(units[i].name + "-");
            }
            return sb.Remove(sb.Length - 1, 1).ToString();
        }
    }
}
