using Diploma.PageObject;
using OpenQA.Selenium;
using SeleniumTests.Diploma.PageObject;
using SeleniumTests.Diploma.PageObject;

namespace Diploma.PageObject
{
    public class TshirtsPage : BasePage
    {
        private By AddToCartButton = By.XPath("//*[@class='box-cart-bottom']//button[@type='submit']");


        public const string url = "http://prestashop.qatestlab.com.ua/ru/tshirts/1-faded-short-sleeve-tshirts.html";
        public TshirtsPage()
        {
            WaitHelper.WaitElement(driver, AddToCartButton);
        }

        public override BasePage OpenPage()
        {
            driver.Navigate().GoToUrl(url);
            return this; ;
        }

        public PopUpCartPage GoPopUpCartPageFromQuickViewPage()
        {
            driver.FindElement(AddToCartButton).Click();

            return new PopUpCartPage();
        }
    }
}
