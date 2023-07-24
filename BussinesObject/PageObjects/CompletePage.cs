using OpenQA.Selenium;
using SeleniumTests.Diploma.PageObject;

namespace Diploma.PageObject
{
    public class CompletePage : BasePage
    {
        private By BackToOrdersButton = By.XPath("//*[@title='Back to orders']");
        public const string url = "http://prestashop.qatestlab.com.ua/ru";

        public CompletePage()
        {
            WaitHelper.WaitElement(driver, BackToOrdersButton);
        }

        public override BasePage OpenPage()
        {
            driver.Navigate().GoToUrl(url);
            return this;
        }

        public HomePage BackHome()
        {
            driver.FindElement(BackToOrdersButton).Click();
            return new HomePage();
        }

    }
}
