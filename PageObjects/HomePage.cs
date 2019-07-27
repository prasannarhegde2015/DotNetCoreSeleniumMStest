using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace SeleniumCSharp.PageObjects
{
    class HomePage
    {

     //   public static IWebElement frmNavFrame { get { return SeleniumObject.SeleniumActions.getElement("Xpath", "//iframe[@id='gsft_main']", "navFrame"); } }
        public static String Dynatext = "";
        public static By frmNavFrame { get { return SeleniumObject.SeleniumActions.geByLocator("Xpath", "//iframe[@id='gsft_main']", "navFrame"); } }

        public static By lnkUserInterface { get { return SeleniumObject.SeleniumActions.geByLocator("Xpath", "//h2[contains(text(),'User Interface')]", "User Interface Link"); } }
       // public static By lnkUserInterface { get { return SeleniumObject.SeleniumActions.geByLocator("Linktext", "User Interface", "User Interface Link"); } }
        public static By lnkIncidentsBy { get { return SeleniumObject.SeleniumActions.geByLocator("Xpath", "//div[text()='Incidents']", "Incidents Link"); } }
        public static IWebElement lnkIncidents { get { return SeleniumObject.SeleniumActions.getElement("Xpath", "//div[text()='Incidents']", "Incidents Link"); } }
        public static IWebElement btnNew { get { return SeleniumObject.SeleniumActions.getElement("Xpath", "//button[@id='sysverb_new']", "New Incident Button"); } }
        public static IWebElement txtIncNum { get { return SeleniumObject.SeleniumActions.getElement("Xpath", "//input[@id='incident.number']", "Incident Number Textbox"); } }
        public static IWebElement txtShortDescription { get { return SeleniumObject.SeleniumActions.getElement("Xpath", "//input[@id='incident.short_description']", "Short Desc Text Box"); } }
        public static IWebElement txtLongDescription { get { return SeleniumObject.SeleniumActions.getElement("Xpath", "//textarea[@id='incident.comments']", "Long Desc "); } }
        public static IWebElement btnSubmit { get { return SeleniumObject.SeleniumActions.getElement("Xpath", "(//button[@id='sysverb_insert'])[1]", "Submit Button "); } }

        public static IWebElement btnDynamicLinktext { get { return SeleniumObject.SeleniumActions.getElement("Xpath", "//a[text()='"+Dynatext+"']", "Dynamic Link Text"); } }
        public static IWebElement ddIncState { get { return SeleniumObject.SeleniumActions.getElement("Xpath", "//select[@id='incident.state']", "Incident state dropdown"); } }
        public static IWebElement btnupdate { get { return SeleniumObject.SeleniumActions.getElement("Xpath", "(//button[@id='sysverb_update'])[1]", "Update Button"); } }
        public static IWebElement btndelete { get { return SeleniumObject.SeleniumActions.getElement("Xpath", "(//button[@id='sysverb_delete'])[1]", "Delete Button"); } }
        public static By  btndeleteConfirmOKBy { get { return SeleniumObject.SeleniumActions.geByLocator("Xpath", "//button[@id='ok_button']", "Confirm Delete Button"); } }
        public static IWebElement btndeleteConfirmOK { get { return SeleniumObject.SeleniumActions.getElement("Xpath", "//button[@id='ok_button']", "Confirm Delete Button"); } }
        public static IWebElement spnsysadmin { get { return SeleniumObject.SeleniumActions.getElement("Xpath", "//span[text()='System Administrator']", "Sys Admin Link"); } }
        public static IWebElement lnklogout { get { return SeleniumObject.SeleniumActions.getElement("Xpath", "//a[text()='Logout']", "Logout Link"); } }


    }
}
