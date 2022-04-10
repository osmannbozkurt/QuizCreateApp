using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Core.Utilities.Helpers
{
    public class DateHelper
    {
        public static string getMonthName(DateTime date)
        {

            string fullMonthName = date.ToString("MMM", CultureInfo.CreateSpecificCulture("tr"));
            return fullMonthName;
        }
        public static string getDayName(DateTime date)
        {
            return date.ToString("dddd");
        }

        public static DateTime getDateFromFormatted(string date)
        {
            
            return DateTime.Parse(date);
        }
    }
}
