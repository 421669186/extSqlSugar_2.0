using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HJ.Common.Funcs
{
    [Serializable]
    public class AndExpression : IExpression
    {
        IExpression ex1;
        IExpression ex2;

        public AndExpression(IExpression expre1, IExpression expre2)
        {
            ex1 = expre1;
            ex2 = expre2;
        }

        public List<T> interpret<T>(string content)
        {
            List<Match> list1 = ex1.interpret<Match>(content);
            List<Match> list2 = ex2.interpret<Match>(content);
            return list1.Where(t => list2.Select(t1 => t1.Index == t.Index).Count() > 0).Cast<T>().ToList<T>();
        }
    }
}
