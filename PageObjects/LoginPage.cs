using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace SeleniumCSharp.PageObjects
{
    class LoginPage
    {

     //   public static IWebElement frmNavFrame { get { return SeleniumObject.SeleniumActions.getElement("Xpath", "//iframe[@id='gsft_main']", "navFrame"); } }
        public static By frmNavFrame { get { return SeleniumObject.SeleniumActions.geByLocator("Xpath", "//iframe[@id='gsft_main']", "navFrame"); } }
        
        public static IWebElement txtUserName { get { return SeleniumObject.SeleniumActions.getElement("Xpath", "//*[@id='user_name']", "User Name"); } }
        public static By txtUserNameby { get { return SeleniumObject.SeleniumActions.geByLocator("Xpath", "//*[@id='user_name']", "User Name"); } }
        public static IWebElement txtPassword { get { return SeleniumObject.SeleniumActions.getElement("Xpath", "//*[@id='user_password']", "Password"); } }
        public static IWebElement btnLogin { get { return SeleniumObject.SeleniumActions.getElement("Xpath", "//*[@id='sysverb_login']", "Login"); } }

    }
}
