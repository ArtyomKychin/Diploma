using Diploma.Core;
using OpenQA.Selenium;
using SeleniumTests.Diploma.PageObject;

namespace Diploma.PageObject
{
    public class AccountPage : BasePage
    {
        private By AccountHeader = By.ClassName("page-heading");
        private By HomePageHeader = By.Id("header_logo");
        private By LogoutButton = By.ClassName("logout");
        private By AddressButton = By.XPath("//*[@title='Addresses']");

        public const string url = "http://prestashop.qatestlab.com.ua/ru/my-account";

        public AccountPage()
        {
            WaitHelper.WaitElement(driver, AccountHeader);
        }

        public override BasePage OpenPage()
        {
            Browser.Instance.NavigateToUrl(url);
            return this;
        }
        public HomePage GoToHomePage()
        {
            driver.FindElement(HomePageHeader).Click();
            return new HomePage();
        }

        public AccountPage GoToLogout()
        {
            driver.FindElement(LogoutButton).Click();
            return new AccountPage();
        }

        public AddressPage GoToAddressPage()
        {
            driver.FindElement(AddressButton).Click();
            return new AddressPage();
        }
    }
}