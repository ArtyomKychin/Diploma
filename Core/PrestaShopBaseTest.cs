using Allure.Commons;
using Diploma.Core;
using NUnit.Allure.Core;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Diagnostics.CodeAnalysis;

namespace Diploma.Test
{
    [AllureNUnit]
    //[Parallelizable(ParallelScope.All)]
    public class PrestaShopBaseTest
    {
        private AllureLifecycle allure;

        [SetUp]

        public void Setup()
        {
            allure = AllureLifecycle.Instance;
        }

        [TearDown]
        public void TearDown()
        {
            Browser.Instance.CloseBrowser();

            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            {
                Screenshot screenshot = ((ITakesScreenshot)Browser.Instance.Driver).GetScreenshot();
                byte[] bytes = screenshot.AsByteArray;
                allure.AddAttachment("Screenshot", "image/png", bytes);
            }
        }
    }
}
