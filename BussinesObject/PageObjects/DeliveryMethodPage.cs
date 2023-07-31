using Diploma.Core;
using NLog;
using NUnit.Allure.Attributes;
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
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public DeliveryMethodPage()
        {
            WaitHelper.WaitElement(driver, StepShiping);
        }

        [AllureStep]
        public override BasePage OpenPage()
        {
            Browser.Instance.NavigateToUrl(url);
            return this;
        }

        [AllureStep]
        public DeliveryMethodPage DontAgreeTermsOfServicesCheckBox()
        {

            logger.Info("Attempting to execute a transition without confirming the condition");

            driver.FindElement(ContinueToProceed).Click();
            return this;
        }

        [AllureStep]
        public ChoosePaymentPage ContinueAfterConfirmDeliveryMetod()
        {
            logger.Info("Conditions accepted and delivery method selected");

            driver.FindElement(AgreeCheckBox).Click();
            driver.FindElement(ContinueToProceed).Click();
            return new ChoosePaymentPage();
        }
    }
}