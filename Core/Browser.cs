using Core;
using Core.Configuration;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace Diploma.Core

{
    //public class Browser
    //{
    //    private static readonly ThreadLocal<Browser> BrowserInstances = new();
    //    public static Browser Instance => GetBrowser();
    //    private IWebDriver driver;
    //    public IWebDriver? Driver { get { return driver; } }

    //    private static Browser GetBrowser()
    //    {
    //        return BrowserInstances.Value ?? (BrowserInstances.Value = new Browser());
    //    }

    //    private Browser()
    //    {
    //        driver = AppConfiguration.Browser.Type.ToLower() switch
    //        {
    //            "chrome" => DriverFactory.GetChromeDriver(),
    //            "firefox" => DriverFactory.GetFirefoxDriver(),
    //            _ => DriverFactory.GetChromeDriver()
    //        };

    //        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(AppConfiguration.Browser.TimeOut);
    //        driver.Manage().Window.Maximize();
    //    }

    //    public void NavigateToUrl(string url)
    //    {
    //        driver.Navigate().GoToUrl(url);
    //    }

    //    public void CloseBrowser()
    //    {
    //        driver?.Dispose();
    //        BrowserInstances.Value = null;
    //    }
    //}
}







public class Browser
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



