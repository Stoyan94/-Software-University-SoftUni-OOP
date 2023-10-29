using System;
using System.Globalization;

namespace LogForU.Core.Utils
{
    public static class DateTimeValidator
    {
        public static bool ValidateDateime(string dateTime)
        {
            if (DateTime.TryParseExact(dateTime
                , "M/dd/yyyy h:mm:ss tt"
                , CultureInfo.InvariantCulture
                , DateTimeStyles.None
                , out DateTime result))
            {

                return true;
            }

            return false;
        }
    }
}
