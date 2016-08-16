using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Register.ViewModels
{
    
    class w
    {
        public byte code { get; set; }
        public string name { get; set; }

        public w(byte _code, string _name)
        {
            code = _code;
            name = _name;
        }

        public static List<w> WList()
        {
            List<w> list = new List<w>();
            list.Add(new w(1,"мужской"));
            list.Add(new w(2, "женский"));
            return list;
        }
    }
}
