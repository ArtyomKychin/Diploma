using Diploma.Core;
using NLog;
using NUnit.Allure.Attributes;
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
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public AccountPage()
        {
            WaitHelper.WaitElement(driver, AccountHeader);
        }

        [AllureStep]
        public override BasePage OpenPage()
        {
            logger.Info($"Navigate to url {url}");

            Browser.Instance.NavigateToUrl(url);
            return this;
        }

        [AllureStep]
        public HomePage GoToHomePage()
        {
            logger.Info($"Moved to homepage");

            driver.FindElement(HomePageHeader).Click();
            return new HomePage();
        }

        [AllureStep]
        public AccountPage GoToLogout()
        {
            logger.Info($"Sign out of account");

            driver.FindElement(LogoutButton).Click();
            return new AccountPage();
        }

        [AllureStep]
        public AddressPage GoToAddressPage()
        {
            logger.Info($"Moved to the page for confirming/editing the address");

            driver.FindElement(AddressButton).Click();
            return new AddressPage();
        }
    }
}