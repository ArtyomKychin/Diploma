using Diploma.Core;
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


        public LoginPage()
        {
            WaitHelper.WaitElement(driver, LoginButtom);
        }

        public override LoginPage OpenPage()
        {
            driver.Navigate().GoToUrl(url);
            return this;
        }
        
        public AccountPage LoginAsStandartUser()
        {
            var user = UserBuilder.GetStandandartUser();  
            TryToLogin(user);

            return new AccountPage();
        }
        public AddressPage LoginAndGoToAdressPage()
        {
            var user = UserBuilder.GetStandandartUser();
            TryToLogin(user);

            return new AddressPage();
        }

        public void TryToLogin(UserLoginModel user)
        {
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
