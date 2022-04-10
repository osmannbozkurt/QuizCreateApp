using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Core.Logger
{
    public class FileLogger : ILogger
    {
        private string sLogFormat;
        private string sErrorTime;
        public FileLogger()
        {
            sLogFormat = DateTime.Now.ToShortDateString().ToString() + " " + DateTime.Now.ToLongTimeString().ToString();

            string sYear = DateTime.Now.Year.ToString();
            string sMonth = DateTime.Now.Month.ToString();
            string sDay = DateTime.Now.Day.ToString();
            sErrorTime = sYear + sMonth + sDay;
        }
        public void ErrorLog(string errorMessage)
        {
            try
            {

                Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + ("/App_Error/"));
                using (StreamWriter sw = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + ("/App_Error/") + sErrorTime + "_Errors.txt", true))
                {

                    sw.WriteLine("------------- " + sLogFormat + " -------------");
                    sw.WriteLine("------------- " + sLogFormat + " ---" + errorMessage + " -------------");
                    sw.WriteLine("------------- " + sLogFormat + " -------------");
                    sw.WriteLine("");
                    sw.Flush();
                    sw.Close();
                }



            }
            catch (Exception)
            {
            }
        }

        public void Log(string log)
        {
            throw new NotImplementedException();
        }
    }
}
