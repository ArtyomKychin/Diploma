using Diploma.Core;
using NLog;
using NUnit.Allure.Attributes;
using OpenQA.Selenium;
using SeleniumTests.Diploma;
using SeleniumTests.Diploma.PageObject;

namespace Diploma.PageObject
{
    public class LoginPage : BasePage
    {
        private By UserMailInput = By.Id("email");
        private By PasswordInput = By.Id("passwd");
        private By ErrorMessage = By.XPath("//*[@class='alert alert-danger'][.//li[contains(text(),'Authentication failed')]]");
        private By SubmitLoginButtom = By.Id("SubmitLogin");
        private By LoginButtom = By.ClassName("login");

        public const string url = "http://prestashop.qatestlab.com.ua/ru/authentication?back=my-account";
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public LoginPage()
        {
            WaitHelper.WaitElement(driver, LoginButtom);
        }

        [AllureStep]
        public override LoginPage OpenPage()
        {
            logger.Info($"Navigate to URL {url}");

            Browser.Instance.NavigateToUrl(url);
            return this;
        }

        [AllureStep]
        public AccountPage LoginAsStandartUser()
        {
            logger.Info($"LoginAsStandartUser");

            var user = UserBuilder.GetStandandartUser();  
            TryToLogin(user);

            return new AccountPage();
        }

        [AllureStep]
        public AddressPage LoginAndGoToAdressPage()
        {
            var user = UserBuilder.GetStandandartUser();
            TryToLogin(user);

            return new AddressPage();
        }

        [AllureStep]
        public void TryToLogin(UserLoginModel user)
        {
            driver.FindElement(UserMailInput).SendKeys(user.Mail);
            driver.FindElement(PasswordInput).SendKeys(user.Password);
            driver.FindElement(SubmitLoginButtom).Click();
        }

        [AllureStep]
        public bool VerifyErrorMesage()
        {
            driver.FindElement(ErrorMessage);
            return false;
        }
    }
}
