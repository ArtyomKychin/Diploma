using Diploma.Core;
using Diploma.PageObject;
using Diploma.Test;
using NUnit.Framework;

namespace Diploma.Test
{
    internal class EmptyCartTest : PrestaShopBaseTest
    {
        [Test]
        [Description("EmptyCartTest")]

        public void GoEmptyCartTest()
        {
            Browser.Instance.NavigateToUrl("http://prestashop.qatestlab.com.ua/ru/");

            new HomePage()
                .GoCartPage()
                .VeryfyEmptyCartMesage();
        }
    }
}
