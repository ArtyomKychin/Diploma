using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumTests.Diploma.PageObject;
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
        public const string FIRSTNAME = "Artur";
        public const string LASTNAME = "Dent";
        public const string ADDRESS = "The House in west england";
        public const string POSTALCODE = "00000";
        public const string CITY = "without a city";
        public const string MOBILEPHONE = "4200004242";
        public const string ADDRESSALIAS = "forward to the Wogans";

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
            var customer = new CustomerModel()
            {
                FirstName = FIRSTNAME,
                LastName = LASTNAME,
                PostalCode = POSTALCODE,
                Address = ADDRESS,
                City = CITY,
                MobilePhone = MOBILEPHONE,
                AddressAlias = ADDRESSALIAS,
            };

            InputCustomerAddressAndSave(customer);

            return new AddressPage();
        }

        private void InputCustomerAddressAndSave(CustomerModel customer)
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