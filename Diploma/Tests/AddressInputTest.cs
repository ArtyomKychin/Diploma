using Diploma.Core;
using Diploma.PageObject;
using NUnit.Framework;
using OpenQA.Selenium;

namespace Diploma.Test
{
    internal class AddressInputTest : PrestaShopBaseTest
    {
        [Test]
        [Description("AddressInputTest")]
         
        public void GoAddressInputTest()
        {
            Browser.Instance.NavigateToUrl("http://prestashop.qatestlab.com.ua/ru/authentication?back=my-account");
            new LoginPage()
               .OpenPage()
               .LoginAsStandartUser()
               .GoToAddressPage()
               .UpdateCustomerAddress()
               .ContinueVsCustomerAddress();


            Assert.IsNotNull(Browser.Instance.Driver.FindElement(By.XPath("//*[@class='page-heading']")));
        }

        [Test]
        [Description("AddressValidationTest")]

        public void GoAddressValidationTest()
        {
            Browser.Instance.NavigateToUrl("http://prestashop.qatestlab.com.ua/ru/authentication?back=my-account");
            new LoginPage()
               .OpenPage()
               .LoginAsStandartUser()
               .GoToAddressPage()
               .UpdateCustomerAddress()
               .SaveVsOutAddress();


            Assert.IsNotNull(Browser.Instance.Driver.FindElement(By.XPath("//*[@class='alert alert-danger']")));
        }
    }
}
