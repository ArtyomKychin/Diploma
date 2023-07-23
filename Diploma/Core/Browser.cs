using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

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
            bool isHeadless = true;//for headless on - true

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

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
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
