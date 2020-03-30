using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nimap.DAL.Common
{
    public static class HelperMethods
    {
        private static string ExceptionLogFile = "Error.log";
        public static string WriteErrorLog(string Message)
        {
            string msg = string.Empty;
            try
            {
                string CurDateTime = DateTime.Now.ToString();
                string ExceptionLnToPrint = CurDateTime + " | " + Message + Environment.NewLine;

                //File.AppendAllText("D:\\Users\\Eldho\\Practise\\TextFiles" + "\\" + ExceptionLogFile, ExceptionLnToPrint, System.Text.Encoding.Unicode);
                File.AppendAllText(GlobalConstants.AppPath + "\\" + ExceptionLogFile, ExceptionLnToPrint, System.Text.Encoding.Unicode);
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return msg;
        }
    }
}
