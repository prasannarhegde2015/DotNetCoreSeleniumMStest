using System;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using Microsoft.Extensions.Configuration;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace SeleniumCSharp.SeleniumObject
{
    static class SeleniumActions
    {
        //This Class will call all Selenium Core Actions:
       private static IWebDriver driver;
       private static WebDriverWait wait;
       internal const string dtlValidLocators = "Valid locators are id ,name ,content and attribute";
       public static string elemdesc = String.Empty;
       public static string loglevel = String.Empty;
       public static int sectimeout = 0;
	   public  static IConfigurationBuilder builder;
       public static IConfiguration config;
       public   static  string starturl = String.Empty;
        public   static string timeout = String.Empty;
        public static   string browser = String.Empty;
	
       
        public static  void InitializeWebDriver()
        {
          builder =  new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory()+"\\..\\..\\..")
                .AddJsonFile("appsettings.json");
          config = builder.Build();
            Stopwatch st = new Stopwatch();
            Console.WriteLine($" value of timeout read : {timeout}");
            starturl = config["starturl"];
             timeout = config["timeout"];
             browser = config["browser"];
			loglevel =  config["loglevel"];
            sectimeout = Int32.Parse(timeout);

            switch (browser.ToLower())
            {
                case "chrome":
                    {
                        st.Start();
                        driver = new ChromeDriver();
                        st.Stop();
                        Trace.WriteLine($"took {st.ElapsedMilliseconds/1000} seconds to launch browser");
                        st.Reset();
                        st.Start();
                        driver.Navigate().GoToUrl(starturl);
                        driver.Manage().Window.Maximize();
                        st.Stop();
                        Trace.WriteLine($"took {st.ElapsedMilliseconds / 1000} seconds to load star Page ");
                        Trace.WriteLine("Launched browser with url: " + starturl);
                        wait = new WebDriverWait(driver, TimeSpan.FromSeconds(sectimeout));
                        break;
                    }
                case "ie" :

                    {
                        var options = new InternetExplorerOptions();
                        options.IntroduceInstabilityByIgnoringProtectedModeSettings = true;
                        driver = new InternetExplorerDriver(options);
                        driver.Navigate().GoToUrl(starturl);
                        driver.Manage().Window.Maximize();
                        Trace.WriteLine("Launched browser with url: " + starturl);
                        wait = new WebDriverWait(driver, TimeSpan.FromSeconds(sectimeout));
                        break;
                    }
                case "edge":
                    {

                        driver = new EdgeDriver(@"E:\Prasanna\C#Tutorial\Selenium\");
                        driver.Navigate().GoToUrl(starturl);
                        driver.Manage().Window.Maximize();
                        Trace.WriteLine("Launched browser with url: " + starturl);
                        wait = new WebDriverWait(driver, TimeSpan.FromSeconds(sectimeout));
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
            

        }

        public static string getBrowserTitle()
        {
            return driver.Title;
        }
        public static void waitClick(IWebElement elem)
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(elem));
            elem.Click();
            Trace.WriteLine("Clicked Element " + elemdesc);
        }

        public static void waitFirElemToInvisible(By elem)
        {
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(elem));
            
           
        }

        public static void switchToFrame(By elem)
        {
            
            wait.Until(ExpectedConditions.FrameToBeAvailableAndSwitchToIt(elem));
            Trace.WriteLine("Swithced to Frame " + elemdesc);
        }

        public static void switchToDefaultFrame()
        {

            driver.SwitchTo().DefaultContent();
            Trace.WriteLine("Switched to default Content");
        }

        public static void waitClick(IWebElement elem, string desc)
        {
            Thread.Sleep(1000);
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(elem));
            elem.Click();
            Trace.WriteLine("Clicked Element " + desc);
        }

        public static  void UploadFile(IWebElement elem, string path)
        {
            var allowsDetection = driver as IAllowsFileDetection;
            if (allowsDetection != null)
            {
                allowsDetection.FileDetector = new LocalFileDetector();
            }
            string jsscript = "arguments[0].style.visibility = 'visible'; arguments[0].style.height = '1px'; arguments[0].style.width = '1px';  arguments[0].style.opacity = 1";
            ((IJavaScriptExecutor)driver).ExecuteScript(jsscript, elem);
            elem.SendKeys(path);
            Thread.Sleep(1000);
        }
        public static void sendText(IWebElement elem, string text)
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(elem));
            elem.Click();
            elem.Clear();
            elem.SendKeys(text);
            Trace.WriteLine(string.Format("Entered Text {0} on Elelment: {1}", text, elemdesc));
        }

        public static string getText(IWebElement elem)
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(elem));
            return elem.GetAttribute("value");
            
        }

        public static string getInnerText(IWebElement elem)
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(elem));
            return elem.Text;

        }


        public static void selectDropdownValue(IWebElement elem,string ddvalue)
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(elem));
            SelectElement sel = new SelectElement(elem);
            sel.SelectByText(ddvalue);
            Trace.WriteLine(string.Format("Selected Text {0} on dropdown: {1}", ddvalue, elemdesc));
          

        }

        public static string getDropdowntext(IWebElement elem)
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(elem));
            SelectElement sel = new SelectElement(elem);
            return sel.SelectedOption.Text;
        }

        public static void takeScreenshot(string desc)
    {

        Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
        string screenshot = ss.AsBase64EncodedString;
        byte[] screenshotAsByteArray = ss.AsByteArray;
        string stamp = System.DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss");
        stamp = stamp.Replace("-", "");
        stamp = stamp.Replace(":", "");
        stamp = stamp.Replace(" ", "");
        string strtimestamp = "Image" + stamp + ".png";
        string imgpath = Path.Combine(config["Screenshotdirectory"], desc+strtimestamp);
        ss.SaveAsFile(imgpath, ScreenshotImageFormat.Png);
          
    }

        public static void waitForElement(By elem)
        {

            wait.Until(ExpectedConditions.ElementExists(elem));
            Trace.WriteLine("Dynamicallay waited for Element " + elemdesc);
        }

        public static bool isElemPresent(By elem)
        {
            try
            {
                driver.FindElement(elem);
                return true;
            }
            catch (NoSuchElementException noel)
            {
                Trace.WriteLine("Caught No Such Element Exception: ");
                if (loglevel.Equals("2"))
                {
                    Trace.WriteLine("error " + noel);
                }
                return false;
            }
            catch (StaleElementReferenceException stl)
            {
                Trace.WriteLine("Caught Stale Element Reference Exception: ");
                if (loglevel.Equals("2"))
                {
                    Trace.WriteLine("error " + stl);
                    Thread.Sleep(1000);
                }
                return false;
            }
            catch (Exception otherex)
            {

                if (loglevel.Equals("2"))
                {
                    Trace.WriteLine("error " + otherex);
                }
                return false;
            }
           
        }

        public static bool isStale(By elem)
        {
            try
            {
                driver.FindElement(elem);
                return false;
            }
            catch (StaleElementReferenceException stl)
            {
                Trace.WriteLine("Caught Stale Element Ref Exception: "+stl);
                Thread.Sleep(1000);
				return true;
            }
                


        }

        public static IWebElement getElement(string searchBy, string searchValue ,string desc)
        {
            IWebElement ctl = null;
            elemdesc = desc;
            Trace.WriteLine(string.Format("For Control Control using searchby as {0} and searchvalue as {1}", searchBy, searchValue));
            #region SearchCrieria
            try
            {

                switch (searchBy.ToLower())
                {
                    case "id":
                        {
                            Trace.WriteLine("Looking for Element: " + desc);
                            ctl = driver.FindElement(By.Id(searchValue));
                            Trace.WriteLine("Found Element: " + desc);
                            break;
                        }

                    case "name":
                        {
                            ctl = driver.FindElement(By.Name(searchValue));
                            break;
                        }
                    case "xpath":
                        {
                            Trace.WriteLine("Looking for Element: " + desc);
                            ctl = driver.FindElement(By.XPath(searchValue));
                            Trace.WriteLine("Found Element: " + desc);
                            break;
                        }
                    case "tagname":
                        {
                            ctl = driver.FindElement(By.TagName(searchValue));
                            break;
                        }
                    default:
                        {
                            Trace.WriteLine("Not Valid Locator: " + dtlValidLocators);
                            break;
                        }


                }
            }
            catch (Exception e)
            {

                Trace.WriteLine(string.Format("Unable to Find HTMLinputContril Type using {0},{1}", searchBy, searchValue));
                throw e;
            }
            #endregion
            return ctl;
        }

        public static By geByLocator(string searchBy, string searchValue, string desc)
        {
            By ctl = null;
            elemdesc = desc;
            if (loglevel.Equals("2"))
            {
                Trace.WriteLine(string.Format("For Control Control using searchby as {0} and searchvalue as {1}", searchBy, searchValue));
            }
            #region SearchCrieria
            try
            {

                switch (searchBy.ToLower())
                {
                    case "id":
                        {
                            Trace.WriteLine("Looking for Element: " + desc);
                            ctl = By.Id(searchValue);
                            break;
                        }

                    case "name":
                        {
                            ctl = By.Name(searchValue);
                            break;
                        }
                    case "xpath":
                        {
                            Trace.WriteLine("Looking for Element: By Xpath : for " + desc);
                            ctl = By.XPath(searchValue);
                            break;
                        }
                    case "tagname":
                        {
                            ctl = By.Id(searchValue);
                            break;
                        }
                    case "linktext":
                        {
                            ctl = By.LinkText(searchValue);
                            break;
                        }
                    default:
                        {
                            Trace.WriteLine("Not Valid Locator: " + dtlValidLocators);
                            break;
                        }


                }
            }
            catch (Exception e)
            {

                Trace.WriteLine(string.Format("Unable to Find HTMLinputContril Type using {0},{1}", searchBy, searchValue));
                throw e;
            }
            #endregion
            return ctl;
        }

        public static void  disposeDriver()
        {
            driver.Close();
            driver.Quit();

        }
    }
}
