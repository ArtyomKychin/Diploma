using OpenQA.Selenium;
using Diploma.Core;

namespace SeleniumTests.Diploma.PageObject
{
    public abstract class BasePage
    {
        protected IWebDriver driver;

        public BasePage()
        {
            driver = Browser.Instance.Driver;
        }

        public abstract BasePage OpenPage();
    }
}