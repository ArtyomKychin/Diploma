using Diploma.Core;
using Diploma.PageObject;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumTests.Diploma;

namespace Diploma.Test
{
    internal class LoginTest : PrestaShopBaseTest
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
            var user = new UserLoginModel()
            {
                Mail = "Test@test.com",
                Password = "password"
            };

            var page = new LoginPage();

            page.OpenPage()
                .TryToLogin(user);

            page.VerifyErrorMesage();
        }

    }
}
