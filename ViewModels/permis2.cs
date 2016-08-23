using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Register.ViewModels
{

    class permis2
    {
        public byte code { get; set; }
        public string name { get; set; }

        public permis2(byte _code, string _name)
        {
            code = _code;
            name = _name;
        }

        public static List<permis2> Permis2List()
        {
            List<permis2> list = new List<permis2>();
            list.Add(new permis2(0, "Выберите документ"));
            list.Add(new permis2(11, "Вид на жительство"));
            list.Add(new permis2(23, "Разрешение на временное проживание"));
            list.Add(new permis2(25, "Свидетельство о предоставлении временного убежища"));
            return list;
        }
    }
}
