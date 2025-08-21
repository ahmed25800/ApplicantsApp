using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Application.Helpers
{
    public static class DateTimeHelper
    {
        public static string ToIsoString(this DateTime dateTime)
        {
            return dateTime.ToUniversalTime().ToString("o");
        }
    }
}
