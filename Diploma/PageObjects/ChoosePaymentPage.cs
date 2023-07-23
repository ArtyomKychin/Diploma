using OpenQA.Selenium;
using SeleniumTests.Diploma.PageObject;
using SeleniumTests.Diploma.PageObject;

namespace Diploma.PageObject
{
    public class ChoosePaymentPage : BasePage
    {

        private By ChoosePaymentMethod = By.XPath("//*[contains(text(),'payment method')]");
        private By BankTransferButton = By.ClassName("bankwire");


        public const string url = "http://prestashop.qatestlab.com.ua/ru/order?multi-shipping=";


        public ChoosePaymentPage()
        {
            WaitHelper.WaitElement(driver, ChoosePaymentMethod);
        }

        public override BasePage OpenPage()
        {
            driver.Navigate().GoToUrl(url);
            return this;
        }
        public ConfirmPaymentPage SelectBankTransfer()
        {
            driver.FindElement(BankTransferButton).Click();

            return new ConfirmPaymentPage();
        }
    }
}
