using Diploma.Core;
using Diploma.PageObject;
using NUnit.Framework;

namespace Diploma.Test
{
    internal class ProductQuantityIconTest : BaseTest
    {
        [Test]
        [Description("ProductQuantityIconTest")]

        public void GoCartProductQuantityTest()
        {
            Browser.Instance.NavigateToUrl("http://prestashop.qatestlab.com.ua/ru/");

            string expcetedPruductQuantity = "4";
            
            new HomePage()
                 .AddMoreProducts();

            var actualProductQuantityOnCartIcon = new CartPage().GetActualProductQuantityOnCartIcon();

            Assert.That(actualProductQuantityOnCartIcon, Is.EqualTo(expcetedPruductQuantity));
        }
    }
}
