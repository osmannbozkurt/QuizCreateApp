using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Helpers
{
   public class NumberHelper
    {
        public static string numberFormat(decimal number)
        {
            return String.Format("{0:N2}", number);
        }
        public static decimal stringToDecimal(string strNumber)
        {
            decimal returnValue;
            var decimalSeperator = System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator;
            var price = strNumber.Replace(",", decimalSeperator).Replace(".", decimalSeperator);
            returnValue = decimal.Parse(price);

            return returnValue;
        }
        public static string calPercentBetweenNumber(decimal newvalue, decimal oldvalue)
        {

            if (oldvalue == 0)
            {
                if (newvalue > 0)
                {
                    return "99.00";
                }
                return "0";
            }
            var rate = ((newvalue - oldvalue) * 100) / oldvalue;

            return String.Format("{0:0.00}", rate);
        }
    }
}
