using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumCSharp.TestData
{
   public static class TestData
    {

        public static string UserName { get { return "admin"; } }
        public static string Password { get { return "ServiceNow97bd916$"; } }
        
    }

   public static class LoginPageTestData
    {
        public static string HomePageTitle { get { return "ServiceNow"; } }
        public static string UserName { get { return "admin"; } }
        public static string Password { get { return "ServiceNow97bd916$"; } }

    }

   public static class HomePageTestData
    {

       public static string IncidetnShotdesc { get { return "Selenium C# for Angular"; } }
       public static string IncidetnLongdesc { get { return "Selenium C# for Angular Large Text Long description by LTI"; } }
       public static string IncidetnState { get { return "In Progress"; } }
    }
}
