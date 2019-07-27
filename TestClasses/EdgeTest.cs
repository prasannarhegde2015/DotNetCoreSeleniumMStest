using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeleniumCSharp.SeleniumObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SeleniumCSharp.TestClasses
{
    class EdgeTest
    {

        public void edgeflow()
        {
            SeleniumActions.InitializeWebDriver();
            Assert.AreEqual("EDGE File Dialog test with selenium", SeleniumActions.getBrowserTitle(), "Title is NOT matched ");
          
            Thread.Sleep(1000);
            //UIAutomation.WinSendText("Open", "File name:", );
            //UIAutomation.WinClickButton("Open", "Open","");
            //System.Windows.Forms.SendKeys.SendWait(@"E:\log1.txt");
            //System.Windows.Forms.SendKeys.SendWait("{Enter}");
            //  SeleniumActions.waitClick(PageObjects.LocalEdgeTest.btnModelFile);
            string txtbeforeuplaod = SeleniumActions.getInnerText(PageObjects.LocalEdgeTest.pconfm);
            Thread.Sleep(1000);
            Assert.AreEqual("Select one or more files.", txtbeforeuplaod,"Before upload mismatch");

            SeleniumActions.UploadFile(PageObjects.LocalEdgeTest.fileControl, @"E:\log1.txt");
            string txtafgteruplaod = SeleniumActions.getInnerText(PageObjects.LocalEdgeTest.pconfm);
            StringAssert.Contains(txtafgteruplaod, "name: log1.txt", "After upload mismatch");
            // *********** Switch to Frame  ******************
        }
    }
}
