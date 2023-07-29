using Diploma.Core;
using NLog;
using NUnit.Allure.Attributes;
using OpenQA.Selenium;
using SeleniumTests.Diploma.PageObject;

namespace Diploma.PageObject
{
    public class PopUpCartPage : BasePage
    {
        private By ContinuePurchasesButton = By.XPath("//*[contains(@class,'exclusive-medium')]//i[contains(@class,'chevron')]");
        private By CheckoutButton = By.CssSelector("#layer_cart [href*='order']");

        public const string url = "http://prestashop.qatestlab.com.ua/en/";
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public PopUpCartPage()
        {
            WaitHelper.WaitElement(driver, CheckoutButton);
        }

        [AllureStep]
        public override BasePage OpenPage()
        {
            logger.Info($"Navigate to URL {url}");

            Browser.Instance.NavigateToUrl(url);
            return this;
        }
        public void ContinuePurchases()
        {
            logger.Info("Continue shopping selected");

            WaitHelper.WaitElementDisplayed(driver, ContinuePurchasesButton);
            driver.FindElement(ContinuePurchasesButton).Click();
        }

        public CartPage GoToCart()
        {
            logger.Info("Purchases completed went to cart");

            WaitHelper.WaitElementDisplayed(driver, CheckoutButton);
            driver.FindElement(CheckoutButton).Click();

            return new CartPage();
        }
    }
}
