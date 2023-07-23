using Diploma.PageObject;
using OpenQA.Selenium;
using SeleniumTests.Diploma.PageObject;
using SeleniumTests.Diploma.PageObject;


namespace Diploma.PageObject
{
    public class ConfirmPaymentPage : BasePage
    {
        private By ConfirmOrderButton = By.XPath("//*[@class='button btn btn-default button-medium']");

        public const string url = "http://prestashop.qatestlab.com.ua/ru/module/bankwire/payment";

        public ConfirmPaymentPage()
        {
            WaitHelper.WaitElement(driver, ConfirmOrderButton);
        }

        public override BasePage OpenPage()
        {
            driver.Navigate().GoToUrl(url);
            return this;
        }
        public CompletePage ConfirmOrder()
        {
            driver.FindElement(ConfirmOrderButton).Click();

            return new CompletePage();
        }

        //public CompletePage GoToFinish()
        //{
        //    driver.FindElement(ConfirmOrderButton).Click();
        //    return new CompletePage(driver);
        //}
    }
}
