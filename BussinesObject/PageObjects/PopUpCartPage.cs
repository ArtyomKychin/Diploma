using Diploma.Core;
using OpenQA.Selenium;
using SeleniumTests.Diploma.PageObject;

namespace Diploma.PageObject
{
    public class PopUpCartPage : BasePage
    {
        private By ContinuePurchasesButton = By.XPath("//*[@class='continue btn btn-default button exclusive-medium']");
        private By ProductAddedSuccessfully = By.ClassName("icon-ok");
        private By CheckoutButton = By.XPath("//*[@class='btn btn-default button button-medium']");

        public const string url = "http://prestashop.qatestlab.com.ua/ru/";

        public PopUpCartPage()
        {
            WaitHelper.WaitElement(driver, ProductAddedSuccessfully);
        }

        public override BasePage OpenPage()
        {
            Browser.Instance.NavigateToUrl(url);
            return this;
        }
        public void ContinuePurchases()
        {
            driver.FindElement(ContinuePurchasesButton).Click();
        }

        public CartPage GoToCart()
        {
            driver.FindElement(CheckoutButton).Click();
            return new CartPage();
        }
    }
}
