using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeleniumCSharp.SeleniumObject;
using SeleniumCSharp.TestData;


namespace SeleniumCSharp.TestClasses
{
    class IncidentManagementTest
    {
        Stopwatch st = new Stopwatch();
        public void IncidentFlow()
        {
            // *********** Launch Browser *******************
            SeleniumActions.InitializeWebDriver();
            Assert.AreEqual(TestData.LoginPageTestData.HomePageTitle, SeleniumActions.getBrowserTitle(), "Title is NOT matched ");
            // *********** Switch to Frame  ******************
            st.Start();
            SeleniumActions.switchToFrame(PageObjects.LoginPage.frmNavFrame);
            // *********** Perform Login  ******************
            SeleniumActions.waitForElement(PageObjects.LoginPage.txtUserNameby);
            SeleniumActions.sendText(PageObjects.LoginPage.txtUserName, TestData.LoginPageTestData.UserName);
            SeleniumActions.sendText(PageObjects.LoginPage.txtPassword, TestData.LoginPageTestData.Password);
            SeleniumActions.waitClick(PageObjects.LoginPage.btnLogin);
            // ********* click on  Incidents  Page ***********************
            SeleniumActions.switchToDefaultFrame();
            SeleniumActions.switchToFrame(PageObjects.HomePage.frmNavFrame);
            SeleniumActions.waitForElement(PageObjects.HomePage.lnkUserInterface);
            SeleniumActions.switchToDefaultFrame();
            SeleniumActions.waitForElement(PageObjects.HomePage.lnkIncidentsBy);
            st.Stop();
            Trace.WriteLine($"took {st.ElapsedMilliseconds / 1000} seconds to launch browseload home page");
            SeleniumActions.waitClick(PageObjects.HomePage.lnkIncidents);
            SeleniumActions.switchToFrame(PageObjects.HomePage.frmNavFrame);
            SeleniumActions.waitClick(PageObjects.HomePage.btnNew);
            string dynatxt = SeleniumActions.getText(PageObjects.HomePage.txtIncNum);
            Trace.WriteLine("Dyna text:" + dynatxt);
            SeleniumActions.sendText(PageObjects.HomePage.txtShortDescription, TestData.HomePageTestData.IncidetnShotdesc);
            SeleniumActions.sendText(PageObjects.HomePage.txtLongDescription, TestData.HomePageTestData.IncidetnLongdesc);
            SeleniumActions.waitClick(PageObjects.HomePage.btnSubmit);
            PageObjects.HomePage.Dynatext = dynatxt;
            SeleniumActions.waitClick(PageObjects.HomePage.btnDynamicLinktext);
            SeleniumActions.selectDropdownValue(PageObjects.HomePage.ddIncState, TestData.HomePageTestData.IncidetnState);
            SeleniumActions.waitClick(PageObjects.HomePage.btnupdate);

            SeleniumActions.waitClick(PageObjects.HomePage.btnDynamicLinktext);
            Assert.AreEqual(TestData.HomePageTestData.IncidetnState, SeleniumActions.getDropdowntext(PageObjects.HomePage.ddIncState), "Incident state was mismathced");
            SeleniumActions.waitClick(PageObjects.HomePage.btndelete);
            SeleniumActions.takeScreenshot("IncidentEdit");
            SeleniumActions.waitForElement(PageObjects.HomePage.btndeleteConfirmOKBy);
            SeleniumActions.waitClick(PageObjects.HomePage.btndeleteConfirmOK);
            SeleniumActions.waitFirElemToInvisible(PageObjects.HomePage.btndeleteConfirmOKBy);

            SeleniumActions.switchToDefaultFrame();
            SeleniumActions.waitClick(PageObjects.HomePage.spnsysadmin);
            SeleniumActions.waitClick(PageObjects.HomePage.lnklogout);
            // *********** Dispose  ******************
            SeleniumActions.disposeDriver();

           
        }

    }
}
