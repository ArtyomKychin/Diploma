using Diploma.Core;
using NLog;
using NUnit.Allure.Attributes;
using OpenQA.Selenium;
using SeleniumTests.Diploma.PageObject;

namespace Diploma.PageObject
{
    public class TshirtsPage : BasePage
    {
        private By AddToCartButton = By.XPath("//*[@class='box-cart-bottom']//button[@type='submit']");
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public const string url = "http://prestashop.qatestlab.com.ua/ru/tshirts/1-faded-short-sleeve-tshirts.html";
        public TshirtsPage()
        {
            WaitHelper.WaitElement(driver, AddToCartButton);
        }

        [AllureStep]
        public override BasePage OpenPage()
        {
            logger.Info($"Navigate to URL {url}");

            Browser.Instance.NavigateToUrl(url);
            return this; ;
        }

        [AllureStep]
        public PopUpCartPage GoPopUpCartPageFromTSirtPage()
        {
            logger.Info("A confirmation window was called and the transition to the basket");

            driver.FindElement(AddToCartButton).Click();
            return new PopUpCartPage();
        }
    }
}
