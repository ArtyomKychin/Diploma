using Diploma.Core;
using Diploma.PageObject;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumTests.Diploma;

namespace Diploma.Test
{
    internal class LoginTest : BaseTest
    {

        [Test]

        public void LoginStandartUser()
        {
            Browser.Instance.NavigateToUrl("http://prestashop.qatestlab.com.ua/ru/");

            new HomePage()
               .GoToLogin()
               .LoginAsStandartUser();

            Assert.IsNotNull(Browser.Instance.Driver.FindElement(By.ClassName("page-heading")));
        }

        [Test]
        public void LoginUnknownUser()
        {
            var user = UserBuilder.GetUnknownUser();
            Browser.Instance.NavigateToUrl("http://prestashop.qatestlab.com.ua/ru/authentication?back=my-account");

            new LoginPage()
                .OpenPage()
                .TryToLogin(user);

            new LoginPage().VerifyErrorMesage();
        }

    }
}
