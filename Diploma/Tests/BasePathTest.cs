using Diploma.Core;
using Diploma.PageObject;
using NUnit.Framework;
using OpenQA.Selenium;

namespace Diploma.Test
{
    internal class BasePathTest : PrestaShopBaseTest
    {

        [Test]
        [Description("BasePathTest")]

        public void GoBasePath()
        {
            Browser.Instance.NavigateToUrl("http://prestashop.qatestlab.com.ua/ru/");

            new HomePage()                
               .GoToLogin()
               .LoginAsStandartUser()
               .GoToHomePage()
               .BuyProductAndGoToCart()
               .GoPopUpCartPageFromQuickViewPage()
               .GoToCart()
               .GoAdressPage()
               .SkipOrUpdateAddressAndContinue()
               .ContinueAfterConfirmDeliveryMetod()
               .SelectBankTransfer()
               .ConfirmOrder();

            Assert.IsNotNull(Browser.Instance.Driver.FindElement(By.XPath("//*[@title='Back to orders']")));
        }
    }
}
