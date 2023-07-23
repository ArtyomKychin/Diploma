using Diploma.Core;
using Diploma.PageObject;
using Diploma.Test;
using NUnit.Framework;
using OpenQA.Selenium;

namespace Prestashop.Test
{
    internal class AgreeTermsOfServiceTest : PrestaShopBaseTest
    {
        [Test]
        [Description("AgreeTermsOfServiceTest")]

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
               .DontAgreeTermsOfServicesCheckBox();

            Assert.IsNotNull(Browser.Instance.Driver.FindElement(By.ClassName("fancybox-error")));
        }
    }
}
