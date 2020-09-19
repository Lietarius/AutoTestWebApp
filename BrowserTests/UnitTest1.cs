using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Opera;
using OpenQA.Selenium.Remote;

namespace BrowserTests
{
    [TestFixture("chrome", "84.0")]
    [TestFixture("firefox", "79.0")]
    public class Tests
    {
        
        
        string selenideURL = "http://selenoid:4444/wd/hub";
        
        private IWebDriver driver;

        DriverOptions opts { get; set; }
        
        public Tests(string browser, string version)
        {
            switch(browser)
            {
                case "chrome":
                    this.opts = new ChromeOptions()
                    {
                        BrowserVersion = version
                    };
                    break;
                case "firefox":
                    this.opts = new FirefoxOptions()
                    {
                        BrowserVersion = version
                    };
                    break;
                case "opera":
                    this.opts = new OperaOptions()
                    {
                        BrowserVersion = version
                    };
                    break;
                default:
                    throw new NotImplementedException($"Browser {browser} not supported");
            }    
        }
        
        [SetUp]
        public void Setup()
        {
            switch (this.opts)
            {
                case ChromeOptions chromeOptions:
                    chromeOptions.AddAdditionalCapability("enableVideo", true, true);
                    chromeOptions.AddAdditionalCapability("enableVNC", true, true);
                    // chromeOptions.AddAdditionalCapability("applicationContainers", new string[] { "nginx" }, true);
                    break;
                case FirefoxOptions firefoxOptions:
                    firefoxOptions.AddAdditionalCapability("enableVideo", true, true);
                    firefoxOptions.AddAdditionalCapability("enableVNC", true, true);
                    // firefoxOptions.AddAdditionalCapability("applicationContainers", new string[] { "nginx" }, true);
                    break;
            }
            this.driver = new RemoteWebDriver(new Uri(selenideURL), this.opts);
            this.driver.Manage().Window.Maximize();
            string s = this.driver.Title;
        }

        [Test]
        public void TestPageTitle()
        {
            driver.Navigate().GoToUrl("http://setsupport-beta.crystals.ru/");
            string title = driver.Title;
            
            StringAssert.Contains("Set Support",title);
        }
    }
}