using Diploma.Core;
using NLog;
using NUnit.Allure.Attributes;
using OpenQA.Selenium;
using SeleniumTests.Diploma.PageObject;

namespace Diploma.PageObject
{
    public class ChoosePaymentPage : BasePage
    {

        private By ChoosePaymentMethod = By.XPath("//*[contains(text(),'payment method')]");
        private By BankTransferButton = By.ClassName("bankwire");

        private static Logger logger = LogManager.GetCurrentClassLogger();
        public const string url = "http://prestashop.qatestlab.com.ua/ru/order?multi-shipping=";

        public ChoosePaymentPage()
        {
            WaitHelper.WaitElement(driver, ChoosePaymentMethod);
        }

        [AllureStep]
        public override BasePage OpenPage()
        {
            logger.Info($"Navigate to url {url}");

            Browser.Instance.NavigateToUrl(url);
            return this;
        }

        [AllureStep]
        public ConfirmPaymentPage SelectBankTransfer()
        {
            logger.Info($"Сhoice of payment method via bank transfer");

            driver.FindElement(BankTransferButton).Click();
            return new ConfirmPaymentPage();
        }
    }
}
