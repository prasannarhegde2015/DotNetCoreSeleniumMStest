using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeleniumCSharp.TestClasses;
using System.Threading.Tasks;

[assembly: Parallelize(Workers = 0, Scope = ExecutionScope.MethodLevel)]


namespace SeleniumCSharp
{
    /// <summary>
    /// UI Automation Test Suite.
    /// </summary>
    [TestClass]
    public class TestSuite
    {
        public TestSuite()
        {
        }
        IncidentManagementTest IncMgmt = new IncidentManagementTest();
        EdgeTest edgtest = new EdgeTest();
        [Ignore]
        [TestCategory("Smoke"), TestMethod]
        public void ServiceNowIncidentTest()
        {
        
            Task task1 = Task.Factory.StartNew(() => IncMgmt.IncidentFlow());
            Task task2 = Task.Factory.StartNew(() => IncMgmt.IncidentFlow());
            Task task3 = Task.Factory.StartNew(() => IncMgmt.IncidentFlow());
            Task.WaitAll(task1, task2, task3);
        }
        [TestMethod]
      
        public void ServiceNowIncidentTest2()
        {

            IncMgmt.IncidentFlow();           
        }
        [TestCategory("Smoke"), TestMethod]
        public void ServiceNowIncidentTest3()
        {

            IncMgmt.IncidentFlow();
        }
        [Ignore]
        [TestMethod]
        public void TestAutoit()
        {
            edgtest.edgeflow();
        }
        #region Additional test attributes

        // You can use the following additional attributes as you write your tests:

        ////Use TestInitialize to run code before running each test 
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{        
        //    // To generate code for this test, select "Generate Code for Coded UI Test" from the shortcut menu and select one of the menu items.
        //    // For more information on generated code, see http://go.microsoft.com/fwlink/?LinkId=179463
        //}

        ////Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{        
        //    // To generate code for this test, select "Generate Code for Coded UI Test" from the shortcut menu and select one of the menu items.
        //    // For more information on generated code, see http://go.microsoft.com/fwlink/?LinkId=179463
        //}

        #endregion

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }
        private TestContext testContextInstance;
    }
}
