using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using HJ.Common.Trans;

namespace HJ.Common.Funcs
{
    public class ChainAnalyzer
    {
        private List<OperateInfo> _operateList;

        public ChainAnalyzer(List<OperateInfo> opearteList)
        {
            _operateList = opearteList;
        }

        public Expression Analyze()
        {
            Expression headEx = new Expression();
            Expression tailEx = null;
            Unit current = null;
            List<Unit> unitList = new List<Unit>();
            string logicState = string.Empty;

            for (int i = 0; i < _operateList.Count; i++)
            {
                OperateInfo oi = _operateList[i];
                switch (oi.type)
                {
                    case "Unit":
                        current = new Unit(oi.name, oi.value);
                        if (tailEx == null)
                        {
                            headEx.units.Add(current);
                        }
                        else
                        {
                            tailEx.units.Add(current);
                        }
                        break;
                    case "Expression":
                        if (oi.name == "begingroup")
                        {
                            Unit unitTemp = unitList.Count > 0 ? unitList[unitList.Count - 1] : current;
                            tailEx = new Expression();
                            tailEx.units.Add(new Unit(unitTemp.name, unitTemp.value));

                            if (logicState == "and")
                            {
                                unitTemp.expression = new AndExpression(unitTemp.expression, tailEx);
                            }
                            else if (logicState == "or")
                            {
                                unitTemp.expression = new OrExpression(unitTemp.expression, tailEx);
                            }
                            else
                            {
                                current.expression = tailEx;
                                unitList.Add(current);
                            }
                        }
                        else if (oi.name == "endgroup")
                        {
                            if (!(_operateList.Count > i + 1 && _operateList[i + 1].name == "op"))
                            {
                                unitList.RemoveAt(unitList.Count - 1);
                            }

                            tailEx = null;
                            logicState = string.Empty;
                        }
                        break;
                    case "Property":
                        if (tailEx != null)
                            SetPropertyValue(tailEx, oi);
                        else
                            SetPropertyValue(headEx, oi);
                        break;
                    case "Logic":
                        logicState = oi.value.ToString();
                        break;
                }
            }
            return headEx;
        }

        private void SetPropertyValue(Expression ex, OperateInfo oi)
        {
            PropertyInfo pi = ex.GetType().GetProperty(oi.name);
            if (pi.PropertyType.Name == "Boolean")
            {
                pi.SetValue(ex, oi.value.ToBool(), null);
            }
            else if (pi.PropertyType.Name == "Int32")
            {
                pi.SetValue(ex, oi.value.ToInt(), null);

            }
        }
    }
}
