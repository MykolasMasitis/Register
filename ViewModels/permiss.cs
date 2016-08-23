using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Register.ViewModels
{

    class permiss
    {
        public byte code { get; set; }
        public string name { get; set; }

        public permiss(byte _code, string _name)
        {
            code = _code;
            name = _name;
        }

        public static List<permiss> PermissList()
        {
            List<permiss> list = new List<permiss>();
            list.Add(new permiss(0, "Выберите документ"));
            list.Add(new permiss(11, "Вид на жительство"));
            list.Add(new permiss(23, "Разрешение на временное проживание"));
            list.Add(new permiss(25, "Свидетельство о предоставлении временного убежища"));
            return list;
        }
    }
}
