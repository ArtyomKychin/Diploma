using Diploma.Core;
using Diploma.PageObject;
using NUnit.Allure.Attributes;
using NUnit.Framework;

namespace Diploma.Test
{
    internal class ProductQuantityIconTest : BaseTest
    {
        [Test(Description ="ProductQuantityIconTest")]
        [AllureSeverity(Allure.Commons.SeverityLevel.normal)]
        [AllureTag("Smoke")]
        [AllureOwner("Artyom.Kychin")]
        [Description("ProductQuantityIconTest")]
        [AllureTms("Azure")]
        [AllureIssue("Azure 420420")]
        [AllureLink("google.com")]
        
        public void GoCartProductQuantityTest()
        {
            Browser.Instance.NavigateToUrl("http://prestashop.qatestlab.com.ua/ru/");

            string expcetedPruductQuantity = "3";
            
            new HomePage()
                 .AddMoreProducts();

            var actualProductQuantityOnCartIcon = new CartPage().GetActualProductQuantityOnCartIcon();

            Assert.That(actualProductQuantityOnCartIcon, Is.EqualTo(expcetedPruductQuantity));
        }
    }
}
