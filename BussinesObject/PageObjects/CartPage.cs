using Diploma.Core;
using NLog;
using NUnit.Allure.Attributes;
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
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public CartPage()
        {
            WaitHelper.WaitElement(driver, CartSummaryTitle);
        }

        [AllureStep]
        public override BasePage OpenPage()
        {
            logger.Info($"Navigate to url {url}");

            Browser.Instance.NavigateToUrl(url);
            return this;
        }

        [AllureStep]
        public AddressPage GoAdressPage()
        {
            logger.Info("Go to the address confirmation page");

            driver.FindElement(ChekOutButton).Click();
            return new AddressPage();
        }

        [AllureStep]
        public AuthenticationPage GoAuthenticationPage()
        {
            logger.Info("Go to the authentication page");

            driver.FindElement(ChekOutButton).Click();
            return new AuthenticationPage();
        }

        [AllureStep]
        public LoginPage GoToLoginPage()
        {
            logger.Info("Go to the authentication page");

            driver.FindElement(ChekOutButton).Click();
            return new LoginPage();
        }

        [AllureStep]
        public string GetActualProductQuantityOnCartIcon()
        {
            logger.Info("Requesting the current value of the number of products displayed on the cart icon");

            return driver.FindElement(CartQuantity).Text;
        }

        [AllureStep]
        public bool VeryfyEmptyCartMesage()
        {
            logger.Info("Checking if there are no items in the cart");

            driver.FindElement(CartEmptyMessage);
            return true;
        }
    }
}