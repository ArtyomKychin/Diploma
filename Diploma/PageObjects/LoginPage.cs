using Diploma.PageObject;
using OpenQA.Selenium;
using SeleniumTests.Diploma.PageObject;
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

        public const string STADART_USER_MAIL = "adduser@mail.ru";
        public const string STADART_USER_PASSWORD = "psw_psw";

        public LoginPage()
        {
        }

        public override LoginPage OpenPage()
        {
            driver.Navigate().GoToUrl(url);
            return this;
        }

        public AccountPage LoginAsStandartUser()
        {
            var user = new UserLoginModel()
            {
                Mail = STADART_USER_MAIL,
                Password = STADART_USER_PASSWORD
            };

            TryToLogin(user);

            return new AccountPage();
        }
        public AddressPage LoginAndGoToAdressPage()
        {
            var user = new UserLoginModel()
            {
                Mail = STADART_USER_MAIL,
                Password = STADART_USER_PASSWORD
            };

            TryToLogin(user);

            return new AddressPage();
        }

        public void TryToLogin(UserLoginModel user)
        {
            driver.FindElement(LoginButtom).Click();
            driver.FindElement(UserMailInput).SendKeys(user.Mail);
            driver.FindElement(PasswordInput).SendKeys(user.Password);
            driver.FindElement(SubmitLoginButtom).Click();
        }



        internal bool VerifyErrorMesage()
        {
            driver.FindElement(ErrorMessage);
            return false;
        }
    }
}
