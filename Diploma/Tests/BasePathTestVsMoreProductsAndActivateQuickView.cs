using Diploma.Core;
using Diploma.PageObject;
using NUnit.Framework;
using OpenQA.Selenium;

namespace Diploma.Test
{
    internal class BasePathTestVsMoreProductsAndActivateQuickView : BaseTest
    {

        [Test]
        [Description("BasePathTest")]
        [Retry(5)]

        public void GoBasePathTestVsMoreProductsAndActivateQuickViewBasePath()
        {
            Browser.Instance.NavigateToUrl("http://prestashop.qatestlab.com.ua/en/");

            new HomePage()
                .AddMoreProducts()
                .GoAuthenticationPage()
                .LoginAndGoToAdressPage()
                .UpdateCustomerAddress()
                .ContinueVsCustomerAddress()
                .SkipOrUpdateAddressAndContinue()
                .ContinueAfterConfirmDeliveryMetod()
                .SelectBankTransfer()
                .ConfirmOrder();

            Assert.IsNotNull(Browser.Instance.Driver.FindElement(By.XPath("//*[@title='Back to orders']")));
        }
    }
}
