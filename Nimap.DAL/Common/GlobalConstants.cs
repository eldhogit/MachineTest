using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Nimap.DAL.Common
{
    public static class GlobalConstants
    {
        public static string ConnectionString = "Data source=DESKTOP-R9QOUTA\\SQLEXPRESS; database= Nimap; integrated security=SSPI";
        //public static string ConnectionString = "Data source=DESKTOP-ghmhgmhgm\\SQLEXPRESS; database= Nimap; integrated security=SSPI";
        public static string AppPath = HttpContext.Current.Server.MapPath("~/").ToString();
        public const string DataFolder = "App_Data";
    }
}
