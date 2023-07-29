using Allure.Commons;
using Diploma.Core;
using NLog;
using NUnit.Allure.Attributes;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumTests.Diploma;
using SeleniumTests.Diploma.PageObject;

namespace Diploma.PageObject
{
    public class AddressInputPage : BasePage
    {
        private By AddressPageTitle = By.XPath("//*[@class='info-title']");
        private By FirstNameInput = By.Id("firstname");
        private By LastNameInput = By.Id("lastname");
        private By AddressInput = By.Id("address1");
        private By PostalCodeInput = By.Id("postcode");
        private By CityInput = By.Id("city");
        private By CountrySelect = By.XPath("//*[@id='id_country']");
        private By MobilePhoneInput = By.Id("phone_mobile");
        private By AddresAlias = By.XPath("//*[@id='alias']");
        private By StateSelect = By.XPath("//*[@id='id_state']");
        private By SaveAndContinueButton = By.Id("submitAddress");

        public const string url = "http://prestashop.qatestlab.com.ua/ru/address";
        private static Logger logger = LogManager.GetCurrentClassLogger();
        //private AllureLifecycle? allure;

        public AddressInputPage()
        {
            WaitHelper.WaitElement(driver, AddressPageTitle);
        }

        [AllureStep]
        public override BasePage OpenPage()
        {
            logger.Info($"Navigate to url {url}");

            Browser.Instance.NavigateToUrl(url);
            return this;
        }

        [AllureStep]
        public AddressPage ContinueVsCustomerAddress()
        {
            logger.Info($"Address and buyer data entered successfully");
            var customer = UserBuilder.GetUserData();

            InputCustomerAddressAndSave(customer);
            return new AddressPage();
        }

        [AllureStep]
        private void InputCustomerAddressAndSave(UserAddressModel customer)
        {
            logger.Info($"Input User Addres data");
            
            driver.FindElement(FirstNameInput).SendKeys(customer.FirstName);
            driver.FindElement(LastNameInput).SendKeys(customer.LastName);
            driver.FindElement(PostalCodeInput).SendKeys(customer.PostalCode);
            driver.FindElement(AddressInput).SendKeys(customer.Address);
            driver.FindElement(CityInput).SendKeys(customer.City);
            driver.FindElement(MobilePhoneInput).SendKeys(customer.MobilePhone);
            driver.FindElement(AddresAlias).SendKeys(customer.AddressAlias);
            SelectCountry();
            SelectState();
            driver.FindElement(SaveAndContinueButton).Click();

            //Screenshot screenshot = ((ITakesScreenshot)Browser.Instance.Driver).GetScreenshot();
            //byte[] bytes = screenshot.AsByteArray;
            //allure.AddAttachment("Screenshot", "image/png", bytes);
        }

        [AllureStep]
        public void SelectCountry()
        {
            var select = new SelectElement(driver.FindElement(CountrySelect));
            select.SelectByValue("216");
        }

        [AllureStep]
        public void SelectState()
        {
            var select = new SelectElement(driver.FindElement(StateSelect));
            select.SelectByValue("326");
        }

        [AllureStep]
        public void SaveVsOutAddress()
        {
            logger.Info($"Attempt to save address data without entering");

            driver.FindElement(SaveAndContinueButton).Click();
        }
    }
}