using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Register.Foundation
{
    class ConvertDate 
    {
        DateTime data;
        public ConvertDate(DateTime value)
        {
            data = value;
        }
        public string Date2String()
        {
            return data.ToString("d", CultureInfo.CreateSpecificCulture("de-DE"));
        }
    }
}
