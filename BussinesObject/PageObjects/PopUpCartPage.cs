using Diploma.Core;
using OpenQA.Selenium;
using SeleniumTests.Diploma.PageObject;

namespace Diploma.PageObject
{
    public class PopUpCartPage : BasePage
    {
        private By ContinuePurchasesButton = By.XPath("//*[contains(@class,'exclusive-medium')]//i[contains(@class,'chevron')]");
        private By CheckoutButton = By.CssSelector("#layer_cart [href*='order']");

        public const string url = "http://prestashop.qatestlab.com.ua/en/";

        public PopUpCartPage()
        {
            WaitHelper.WaitElement(driver, CheckoutButton);
        }

        public override BasePage OpenPage()
        {
            Browser.Instance.NavigateToUrl(url);
            return this;
        }
        public void ContinuePurchases()
        {
            WaitHelper.WaitElementDisplayed(driver, ContinuePurchasesButton);
            driver.FindElement(ContinuePurchasesButton).Click();
        }

        public CartPage GoToCart()
        {
            WaitHelper.WaitElementDisplayed(driver, CheckoutButton);
            driver.FindElement(CheckoutButton).Click();

            return new CartPage();
        }
    }
}
