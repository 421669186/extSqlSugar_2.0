using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HJ.Common.Funcs
{
    [Serializable]
    public class Unit
    {
        public Unit()
        {
        }

        public Unit(string name, object value)
            : this(name, value, null)
        {
        }

        public Unit(string name, object value, IExpression ex)
        {
            this.name = name;
            this.value = value;
            this.expression = ex;
        }

        public string name { get; set; }
        public object value { get; set; }
        public IExpression expression { get; set; }
    }
}
