using Diploma.Core;
using OpenQA.Selenium;
using SeleniumTests.Diploma.PageObject;

namespace Diploma.PageObject
{
    public class CartPage : BasePage
    {
        private By CartSummaryTitle = By.XPath("//*[contains(text(),'Shopping-cart summary')]");
        private By ChekOutButton = By.XPath("//p[@class='cart_navigation clearfix']//a[@title='Proceed to checkout']");
        private By CartQuantity = By.XPath("//span[@class='ajax_cart_quantity']");
        private By CartEmptyMessage = By.XPath("//p[@class='alert alert-warning']");

        public const string url = "http://prestashop.qatestlab.com.ua/ru/order";

        public CartPage()
        {
            WaitHelper.WaitElement(driver, CartSummaryTitle);
        }

        public override BasePage OpenPage()
        {
            Browser.Instance.NavigateToUrl(url);
            return this;
        }

        public AddressPage GoAdressPage()
        {
            driver.FindElement(ChekOutButton).Click();
            return new AddressPage();
        }

        public AuthenticationPage GoAuthenticationPage()
        {
            driver.FindElement(ChekOutButton).Click();
            return new AuthenticationPage();
        }

        public LoginPage GoToLoginPage()
        {
            driver.FindElement(ChekOutButton).Click();
            return new LoginPage();
        }

        public string GetActualProductQuantityOnCartIcon()
        {
            return driver.FindElement(CartQuantity).Text;
        }

        public bool VeryfyEmptyCartMesage()
        {
            driver.FindElement(CartEmptyMessage);
            return true;
        }
    }
}