using NLog;
using NUnit.Allure.Attributes;
using OpenQA.Selenium;
using SeleniumTests.Diploma.PageObject;

namespace Diploma.PageObject
{
    public class CompletePage : BasePage
    {
        private By BackToOrdersButton = By.XPath("//*[@title='Back to orders']");
        public const string url = "http://prestashop.qatestlab.com.ua/ru";

        private static Logger logger = LogManager.GetCurrentClassLogger();


        public CompletePage()
        {
            WaitHelper.WaitElement(driver, BackToOrdersButton);
        }

        [AllureStep]
        public override BasePage OpenPage()
        {
            logger.Info($"Navigate to url {url}");

            driver.Navigate().GoToUrl(url);
            return this;
        }

        [AllureStep]
        public HomePage BackHome()
        {
            logger.Info("Return to home page");

            driver.FindElement(BackToOrdersButton).Click();
            return new HomePage();
        }
    }
}
