using Diploma.Core;
using NLog;
using NUnit.Allure.Attributes;
using OpenQA.Selenium;
using SeleniumTests.Diploma.PageObject;


namespace Diploma.PageObject
{
    public class ConfirmPaymentPage : BasePage
    {
        private By ConfirmOrderButton = By.XPath("//*[@class='button btn btn-default button-medium']");

        public const string url = "http://prestashop.qatestlab.com.ua/ru/module/bankwire/payment";
        private static Logger logger = LogManager.GetCurrentClassLogger();

        
        public ConfirmPaymentPage()
        {
            WaitHelper.WaitElement(driver, ConfirmOrderButton);
        }

        [AllureStep]
        public override BasePage OpenPage()
        {
            logger.Info($"Navigate to url {url}");

            Browser.Instance.NavigateToUrl(url);
            return this;
        }

        [AllureStep]
        public CompletePage ConfirmOrder()
        {
            logger.Info("Confirmation of an order");

            driver.FindElement(ConfirmOrderButton).Click();
            return new CompletePage();
        }
    }
}
