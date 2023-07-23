using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace Diploma.Core
{

    internal class Browser
    {
        private static Browser instance = null;
        private IWebDriver driver;
        public IWebDriver Driver { get { return driver; } }

        public static Browser Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Browser();
                }
                return instance;
            }
        }


        private Browser()
        {
            var isHeadless = bool.Parse(TestContext.Parameters.Get("Headless"));
            var wait = int.Parse(TestContext.Parameters.Get("ImplicityWait"));

            switch (TestContext.Parameters.Get("BrowserType"))
            {
                case "Chrome":
                    if (isHeadless)
                    {
                        ChromeOptions options = new ChromeOptions();
                        options.AddArgument("--headless");

                        driver = new ChromeDriver(options);
                    }
                    else
                    {
                        driver = new ChromeDriver();
                    }
                    break;
                case "FireFox":
                    driver = new FirefoxDriver();
                    break;
                case "Default":
                    driver = new ChromeDriver();
                    break;
            }

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(wait);
            driver.Manage().Window.Maximize();
        }

        public void NavigateToUrl(string url)
        {
            driver.Navigate().GoToUrl(url);
        }

        public void CloseBrowser()
        {
            driver?.Dispose();
            instance = null;
        }
    }

}
