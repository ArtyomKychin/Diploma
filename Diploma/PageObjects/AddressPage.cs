using Diploma.PageObject;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumTests.Diploma.PageObject;
using SeleniumTests.Diploma;
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

        public override BasePage OpenPage()
        {
            driver.Navigate().GoToUrl(url);
            return this;
        }

        public AddressInputPage UpdateCustomerAddress()
        {
            driver.FindElement(UpdateAddresseButton).Click();

            return new AddressInputPage();
        }

        public DeliveryMethodPage SkipOrUpdateAddressAndContinue()
        {
            driver.FindElement(ContinueButton).Click();

            return new DeliveryMethodPage();
        }

    }
}   