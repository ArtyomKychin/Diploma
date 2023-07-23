using Diploma.Core;
using OpenQA.Selenium;
using SeleniumTests.Diploma.PageObject;

namespace Diploma.PageObject
{
    public class DeliveryMethodPage : BasePage
    {
        private By ContinueToProceed = By.Name("processCarrier");
        private By AgreeCheckBox = By.Id("uniform-cgv");
        private By StepShiping = By.XPath("//*[@class='step_current four']");

        public const string url = "http://prestashop.qatestlab.com.ua/ru/order";

        public DeliveryMethodPage()
        {
            WaitHelper.WaitElement(driver, StepShiping);
        }

        public override BasePage OpenPage()
        {
            Browser.Instance.NavigateToUrl(url);
            return this;
        }

        public DeliveryMethodPage DontAgreeTermsOfServicesCheckBox()
        {
            driver.FindElement(ContinueToProceed).Click();
            return this;
        }

        public ChoosePaymentPage ContinueAfterConfirmDeliveryMetod()
        {
            driver.FindElement(AgreeCheckBox).Click();
            driver.FindElement(ContinueToProceed).Click();
            return new ChoosePaymentPage();
        }
    }
}