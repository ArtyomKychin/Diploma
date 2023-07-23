using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumTests.Diploma.PageObject;
using SeleniumTests.Diploma;
using SeleniumTests.Diploma.PageObject;
using Diploma.Core;

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
        
        public AddressInputPage()
        {
            WaitHelper.WaitElement(driver, AddressPageTitle);
        }

        public override BasePage OpenPage()
        {
            driver.Navigate().GoToUrl(url);
            return this;
        }

        public AddressPage ContinueVsCustomerAddress()
        {
            var customer = UserBuilder.GetUserData();
            
            InputCustomerAddressAndSave(customer);

            return new AddressPage();
        }

        private void InputCustomerAddressAndSave(UserAddressModel customer)
        {
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

        }

        public void SelectCountry()
        {
            var select = new SelectElement(driver.FindElement(CountrySelect));
            select.SelectByValue("216");
        }

        public void SelectState()
        {
            var select = new SelectElement(driver.FindElement(StateSelect));
            select.SelectByValue("326");
        }

        public void SaveVsOutAddress()
        {
            driver.FindElement(SaveAndContinueButton).Click();
        }

    }
}