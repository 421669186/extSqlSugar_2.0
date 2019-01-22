using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HJ.Common.Funcs
{
    /// <summary>
    /// 链式表达式的顺序记录
    /// </summary>
    public class OperateInfo
    {
        public string name { get; set; }
        public object value { get; set; }
        public string type { get; set; }

        public OperateInfo(string name, object value, string type)
        {
            this.name = name;
            this.value = value;
            this.type = type;
        }
    }
}
