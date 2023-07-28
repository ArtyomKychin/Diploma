using Diploma.Core;
using NUnit.Allure.Attributes;
using OpenQA.Selenium;
using SeleniumTests.Diploma.PageObject;

namespace Diploma.PageObject
{
    public class AddressPage : BasePage
    {
        private By AddressPageTitle = By.CssSelector("h1:first-child");
        private By ContinueButton = By.XPath("//*[@name='processAddress']");
        private By UpdateAddresseButton = By.XPath("//*[@class='address_update']//a[@title='Update']");

        public const string url = "http://prestashop.qatestlab.com.ua/ru/address";

        public AddressPage()
        {
            WaitHelper.WaitElement(driver, AddressPageTitle);
        }

        [AllureStep]
        public override BasePage OpenPage()
        {
            Browser.Instance.NavigateToUrl(url);
            return this;
        }

        [AllureStep]
        public AddressInputPage UpdateCustomerAddress()
        {
            driver.FindElement(UpdateAddresseButton).Click();
            return new AddressInputPage();
        }

        [AllureStep]
        public DeliveryMethodPage SkipOrUpdateAddressAndContinue()
        {
            driver.FindElement(ContinueButton).Click();
            return new DeliveryMethodPage();
        }
    }
}   