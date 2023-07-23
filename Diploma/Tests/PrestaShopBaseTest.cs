using Diploma.Core;
using NUnit.Framework;

namespace Diploma.Test
{
    public class PrestaShopBaseTest
    {

        [SetUp]

        public void Setup()
        {

        }

        [TearDown]
        public void TearDown()
        {
            Browser.Instance.CloseBrowser();
        }
    }
}
