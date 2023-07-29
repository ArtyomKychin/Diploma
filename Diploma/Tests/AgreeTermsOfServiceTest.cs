using Diploma.Core;
using Diploma.PageObject;
using Diploma.Test;
using NUnit.Framework;
using OpenQA.Selenium;

namespace Diploma.Test
{
    internal class AgreeTermsOfServiceTest : BaseTest
    {
        [Test]
        [Description("AgreeTermsOfServiceTest")]

        public void GoAgreeTermsOfServiceTest()
        {
            Browser.Instance.NavigateToUrl("http://prestashop.qatestlab.com.ua/ru/");

            new HomePage()
               .GoToLogin()
               .LoginAsStandartUser()
               .GoToHomePage()
               .BuyProductAndGoToCart()
               .GoPopUpCartPageFromTSirtPage()
               .GoToCart()
               .GoAdressPage()
               .SkipOrUpdateAddressAndContinue()
               .DontAgreeTermsOfServicesCheckBox();

            Assert.IsNotNull(Browser.Instance.Driver.FindElement(By.ClassName("fancybox-error")));
        }
    }
}
