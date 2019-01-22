using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using HJ.Common.Trans;

namespace HJ.Common.Funcs
{
    public class IndexMethod
    {
        public static List<string> CutWord(string content, List<Match> coreMatch, List<Match> beforeMatch, List<Match> afterMatch, bool coreFirst, bool toLast, bool toFirst, bool withoutCore, bool withoutKey, int wordIndex, RegexOptions ro)
        {
            List<string> result = new List<string>();
            try
            {
                if (coreMatch != null && coreMatch.Count > 0)
                {
                    for (int i = 0; i < coreMatch.Count; i++)
                    {
                        Match beforeKey = null, afterKey = null;
                        string strCutL = null, strCutR = null;
                        string strCore = coreMatch[i].Value;
                        string strKeyLeft = string.Empty, strKeyRight = string.Empty;

                        strCutL = CutWord(content, coreMatch[i], beforeMatch, true, toFirst, wordIndex, ref strKeyLeft);
                        strCutR = CutWord(content, coreMatch[i], afterMatch, false, toLast, wordIndex, ref strKeyRight);

                        if ((beforeMatch != null && strCutL != null) || (afterMatch != null && strCutR != null))
                        {
                            if (coreFirst)
                            {
                                if (!string.IsNullOrEmpty(strCutL) && i != 0 && coreMatch[i - 1].Index >= coreMatch[i].Index - strCutL.Length)
                                {
                                    strCutL = strCutL.Substring(strCutL.Length - (coreMatch[i].Index - coreMatch[i - 1].Index - coreMatch[i - 1].Length));
                                    strKeyLeft = coreMatch[i - 1].Value;
                                }

                                if (!string.IsNullOrEmpty(strCutR) && i != coreMatch.Count - 1 && coreMatch[i + 1].Index + coreMatch[i + 1].Length <= coreMatch[i].Index + coreMatch[i].Length + strCutR.Length)
                                {
                                    strCutR = strCutR.Substring(0, coreMatch[i + 1].Index - coreMatch[i].Index - coreMatch[i].Length);
                                    strKeyRight = coreMatch[i + 1].Value;
                                }
                            }

                            if (withoutCore)
                                strCore = string.Empty;
                            if (withoutKey)
                                strKeyRight = strKeyLeft = string.Empty;
                            result.Add(strKeyLeft + strCutL + strCore + strCutR + strKeyRight);
                        }
                    }
                }
            }
            catch (Exception ex)
            { throw ex; }

            return result;
        }

        public static List<string> CutLength(string content, List<Match> coreMatch, int leftLen, int rightLen, bool coreFirst, bool toFirst, bool toLast, bool withoutCore, RegexOptions ro)
        {
            List<string> list = new List<string>();
            try
            {
                if (coreMatch != null && coreMatch.Count > 0)
                {
                    for (int i = 0; i < coreMatch.Count; i++)
                    {
                        string strCutL = CutLength(content, coreMatch[i], leftLen, true, toFirst);
                        string strCutR = CutLength(content, coreMatch[i], rightLen, false, toLast);

                        if ((leftLen > 0 && strCutL != null) || (rightLen > 0 && strCutR != null))
                        {
                            if (coreFirst)
                            {
                                if (!string.IsNullOrEmpty(strCutL) && i != 0 && coreMatch[i - 1].Index > coreMatch[i].Index - strCutL.Length)
                                    strCutL = strCutL.Substring(strCutL.Length - (coreMatch[i].Index - coreMatch[i - 1].Index));
                                if (!string.IsNullOrEmpty(strCutR) && i != coreMatch.Count - 1 && coreMatch[i + 1].Index + coreMatch[i + 1].Length < coreMatch[i].Index + coreMatch[i].Length + strCutR.Length)
                                    strCutR = strCutR.Substring(0, coreMatch[i + 1].Index + coreMatch[i + 1].Length - coreMatch[i].Index - coreMatch[i].Length);
                            }
                            if (withoutCore)
                                list.Add(strCutL + strCutR);
                            else
                                list.Add(strCutL + coreMatch[i].Value + strCutR);
                        }
                    }
                }
            }
            catch (Exception ex)
            { throw ex; }
            return list;
        }

        public static List<string> CutMix(string content, List<Match> coreMatch, int len, List<Match> word, bool coreFirst, bool toFirst, bool toLast, bool withoutCore, bool withoutKey, int keyIndex, bool isTransfer, RegexOptions ro)
        {
            List<string> list = new List<string>();
            try
            {
                if (coreMatch != null && coreMatch.Count > 0)
                {
                    for (int i = 0; i < coreMatch.Count; i++)
                    {
                        string strCutL = null, strCutR = null;
                        string strCore = coreMatch[i].Value;
                        string strKeyLeft = string.Empty, strKeyRight = string.Empty;
                        if (!isTransfer)
                        {
                            strCutL = CutLength(content, coreMatch[i], len, true, toFirst);
                            strCutR = CutWord(content, coreMatch[i], word, false, toLast, keyIndex, ref strKeyRight);
                        }
                        else
                        {
                            strCutL = CutWord(content, coreMatch[i], word, true, toFirst, keyIndex, ref strKeyLeft);
                            strCutR = CutLength(content, coreMatch[i], len, false, toLast); ;
                        }

                        if (strCutL != null && strCutR != null)
                        {
                            if (coreFirst)
                            {
                                if (!string.IsNullOrEmpty(strCutL) && i != 0 && coreMatch[i - 1].Index > coreMatch[i].Index - strCutL.Length)
                                {
                                    strCutL = strCutL.Substring(strCutL.Length - (coreMatch[i].Index - coreMatch[i - 1].Index - coreMatch[i - 1].Length));
                                    strKeyLeft = coreMatch[i - 1].Value;
                                }
                                if (!string.IsNullOrEmpty(strCutR) && i != coreMatch.Count - 1 && coreMatch[i + 1].Index + coreMatch[i + 1].Length < coreMatch[i].Index + coreMatch[i].Length + strCutR.Length)
                                {
                                    strCutR = strCutR.Substring(0, coreMatch[i + 1].Index - coreMatch[i].Index - coreMatch[i].Length);
                                    strKeyRight = coreMatch[i + 1].Value;
                                }
                            }

                            if (withoutCore)
                                strCore = string.Empty;
                            if (withoutKey)
                                strKeyRight = strKeyLeft = string.Empty;
                            list.Add(strKeyLeft + strCutL + strCore + strCutR + strKeyRight);
                        }
                    }
                }
            }
            catch (Exception ex)
            { throw ex; }
            return list;
        }

        public static List<Match> IsConditionWord(string content, List<Match> coreMatch, bool isBefore, List<Match> keyWordMath, List<string> contain, List<string> exclude, int keyIndex, bool toFirst, bool toLast, RegexOptions ro)
        {
            List<Match> matchResult = new List<Match>();
            if (coreMatch != null && coreMatch.Count > 0)
            {
                for (int i = 0; i < coreMatch.Count; i++)
                {
                    string strKey = string.Empty;
                    string strCut = CutWord(content, coreMatch[i], keyWordMath, isBefore, isBefore ? toFirst : toLast, keyIndex, ref strKey);

                    if (ValuateStr(strCut, contain, exclude, ro))
                    {
                        matchResult.Add(coreMatch[i]);
                    }
                }
            }
            return matchResult;
        }

        public static List<Match> IsConditionLength(string content, List<Match> coreMatch, bool isBefore, int length, List<string> contain, List<string> exclude, bool toFirst, bool toLast, RegexOptions ro)
        {
            List<Match> matchResult = new List<Match>();
            if (coreMatch != null && coreMatch.Count > 0)
            {
                for (int i = 0; i < coreMatch.Count; i++)
                {
                    string strCut = CutLength(content, coreMatch[i], length, isBefore, isBefore ? toFirst : toLast);
                    if (ValuateStr(strCut, contain, exclude, ro))
                        matchResult.Add(coreMatch[i]);
                }
            }
            return matchResult;
        }

        public static List<Match> GetKeyMatches(List<Match> coreMatch, List<Match> keyMatch, int keyIndex, bool isbefore)
        {
            List<Match> matchResult = new List<Match>();
            if (coreMatch != null && coreMatch.Count > 0)
            {
                for (int i = 0; i < coreMatch.Count; i++)
                {
                    Match key = keyMatch == null ? null : GetNearKey(coreMatch[i], isbefore, keyMatch, keyIndex);
                    if (key != null && !matchResult.Contains(key))
                        matchResult.Add(key);
                }
            }
            return matchResult;
        }

        public static List<Match> GetIncludeMatches(string content, List<Match> coreMatch, bool isBefore, object objValue, string include, int wordIndex, RegexOptions ro)
        {
            List<Match> matchResult = new List<Match>();
            if (coreMatch != null && coreMatch.Count > 0 && !string.IsNullOrEmpty(include))
            {
                MatchCollection mc = Regex.Matches(content, include, ro);
                for (int i = 0; i < coreMatch.Count; i++)
                {
                    string strCut = string.Empty;
                    Match match = coreMatch[i];
                    int index;
                    if (Int32.TryParse(objValue.ToString(), out index))
                        strCut = CutLength(content, match, objValue.ToInt(), isBefore, false);
                    else if (objValue is List<Match>)
                    {
                        string strKey = string.Empty;
                        strCut = CutWord(content, match, objValue as List<Match>, isBefore, false, wordIndex, ref strKey);
                    }

                    if (!string.IsNullOrEmpty(strCut))
                    {
                        if (isBefore)
                        {
                            for (int j = 0; j < mc.Count; j++)
                            {
                                if (mc[j].Index <= match.Index - mc[j].Length && mc[j].Index >= match.Index - strCut.Length && !matchResult.Contains(mc[j]))
                                    matchResult.Add(mc[j]);
                            }
                        }
                        else
                        {
                            for (int j = 0; j < mc.Count; j++)
                            {
                                if (mc[j].Index >= match.Index + match.Length && mc[j].Index <= match.Index + match.Length + strCut.Length - mc[j].Length && !matchResult.Contains(mc[j]))
                                    matchResult.Add(mc[j]);
                            }
                        }
                    }
                }
            }
            return matchResult;
        }

        private static string CutLength(string content, Match coreMatch, int length, bool isbefore, bool toFirstorLast)
        {
            string strCut = null;
            if (isbefore)
            {
                if (length > 0 && coreMatch.Index >= length)
                {
                    strCut = content.Substring(coreMatch.Index - length, length);
                }
                else if (toFirstorLast)
                {
                    strCut = content.Substring(0, coreMatch.Index);
                }
            }
            else
            {
                if (length > 0 && coreMatch.Index + coreMatch.Length + length <= content.Length)
                {
                    strCut = content.Substring(coreMatch.Index + coreMatch.Length, length);
                }
                else if (toFirstorLast)
                {
                    strCut = content.Substring(coreMatch.Index + coreMatch.Length);
                }
            }
            return strCut;
        }

        private static string CutWord(string content, Match coreMatch, List<Match> keyMatches, bool isbefore, bool toFirstorLast, int keyIndex, ref string strKey)
        {
            string strCut = null;
            if (keyMatches != null)
            {
                Match keyMatch = GetNearKey(coreMatch, isbefore, keyMatches, keyIndex);
                if (keyMatch == null && toFirstorLast)
                {
                    if (isbefore)
                        keyMatch = Regex.Match(content, "^");
                    else
                        keyMatch = Regex.Match(content, "$");
                }

                if (keyMatch != null)
                {
                    if (isbefore)
                    {
                        strCut = content.Substring(keyMatch.Index + keyMatch.Length, coreMatch.Index - keyMatch.Index - keyMatch.Length);
                    }
                    else
                    {
                        strCut = content.Substring(coreMatch.Index + coreMatch.Length, keyMatch.Index - coreMatch.Index - coreMatch.Length);
                    }
                    strKey = keyMatch.Value;
                }
            }
            return strCut;
        }

        private static Match GetNearKey(Match match, bool isBefore, List<Match> keyWordMath, int keyIndex)
        {
            int index = -1;
            if (isBefore)
            {
                for (int j = keyWordMath.Count - 1; j > -1; j--)
                {
                    Match keyMatch = keyWordMath[j];
                    if (keyMatch.Index < match.Index)
                    {
                        if (keyIndex == 1)
                        {
                            index = j;
                            break;
                        }
                        else
                            keyIndex--;
                    }
                }
            }
            else
            {
                for (int j = 0; j < keyWordMath.Count; j++)
                {
                    Match keyMatch = keyWordMath[j];

                    if (keyMatch.Index >= match.Index + match.Length)
                    {
                        if (keyIndex == 1)
                        {
                            index = j;
                            break;
                        }
                        else
                        {
                            keyIndex--;
                        }
                    }
                }
            }

            if (index != -1)
                return keyWordMath[index];
            else
                return null;
        }

        private static bool ValuateStr(string cutStr, List<string> contain, List<string> exclude, RegexOptions ro)
        {
            bool flag = false;
            if (cutStr != null)
            {
                if (contain.Count > 0 && exclude.Count > 0)
                    flag = RegexMatch(cutStr, contain, true, ro) && RegexMatch(cutStr, exclude, false, ro);
                else if (contain.Count > 0)
                    flag = RegexMatch(cutStr, contain, true, ro);
                else if (exclude.Count > 0)
                    flag = RegexMatch(cutStr, exclude, false, ro);
            }
            return flag;
        }

        private static bool RegexMatch(string content, List<string> pattern, bool isContain, RegexOptions ro)
        {
            bool flag = false;
            for (int i = 0; i < pattern.Count; i++)
            {
                if (isContain)
                    flag = content.UseReg().Include(pattern[i], ro);
                else
                    flag = content.UseReg().Exclude(pattern[i], ro);
                if (!flag)
                    break;
            }
            return flag;
        }
    }
}
