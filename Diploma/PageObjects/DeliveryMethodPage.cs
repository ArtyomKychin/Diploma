using Diploma.PageObject;
using OpenQA.Selenium;
using SeleniumTests.Diploma.PageObject;
using SeleniumTests.Diploma.PageObject;

namespace Diploma.PageObject
{
    public class DeliveryMethodPage : BasePage
    {
        private By ContinueToProceed = By.Name("processCarrier");
        private By AgreeCheckBox = By.Id("uniform-cgv");
        private By StepShiping = By.XPath("//*[@class='step_current four']");

        public DeliveryMethodPage()
        {
            WaitHelper.WaitElement(driver, StepShiping);
        }

        public override BasePage OpenPage()
        {
            throw new NotImplementedException();
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