using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumCSharp.PageObjects
{
    class LocalEdgeTest
    {
        public static String Dynatext = "";
        public static IWebElement btnModelFile { get { return SeleniumObject.SeleniumActions.getElement("Xpath", "//input[@id='loadFileXml']", "filedlg"); } }

        public static IWebElement fileControl { get { return SeleniumObject.SeleniumActions.getElement("Xpath", "//input[@type='file']", "filectrl"); } }

        public static IWebElement pconfm { get { return SeleniumObject.SeleniumActions.getElement("Xpath", "//*[@id='demo']", "ParaText"); } }
    }
}
