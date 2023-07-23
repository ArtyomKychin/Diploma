using Diploma.Core;
using Diploma.PageObject;
using Diploma.Test;
using NUnit.Framework;
using OpenQA.Selenium;

namespace Diploma.Test
{
    internal class LogoutTest : PrestaShopBaseTest
    {
        [Test]
        [Description("LogoutTest")]

        public void LoginAndLogOut()
        {
            Browser.Instance.NavigateToUrl("http://prestashop.qatestlab.com.ua/ru/authentication?back=my-account");
            new LoginPage()
                .OpenPage()
                .LoginAsStandartUser()
                .GoToLogout();

            Assert.IsNotNull(Browser.Instance.Driver.FindElement(By.ClassName("login")));
        }
    }
}
