using Diploma.Core;
using NLog;
using NUnit.Allure.Attributes;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SeleniumTests.Diploma.PageObject;

namespace Diploma.PageObject
{
    public class HomePage : BasePage
    {
        private By InfoBlock = By.Id("cmsinfo_block");
        private By AddTShirts = By.XPath("//*[@class='product-container']//img[contains(@class,'replace-2x')][contains(@src,'tshirts')][1]");
        private By AddBlouse = By.XPath("//*[@class='product_img_link'][.//*[@title='Blouse']][1]");
        private By AddDress = By.XPath("//*[@class='product_img_link'][.//*[@title='Printed Dress']][1]");
        private By QuickAddTShirts = By.XPath("//*[@data-id-product='1'][1]");
        private By QuickAddBlouse = By.XPath("//*[@data-id-product='2'][1]");
        private By QuickAddDress = By.XPath("//*[@data-id-product='3'][1]");
        private By CartPage = By.XPath("//*[@title='View my shopping cart']");
        private By EnglishLanguage = By.XPath("//*[contains(text(),'English')]");
        private By LanguageSelector = By.XPath("//div[@id='languages-block-top']");
        private By Login = By.ClassName("login");

        private static Logger logger = LogManager.GetCurrentClassLogger();
        public const string url = "http://prestashop.qatestlab.com.ua/ru/";


        public override BasePage OpenPage()
        {
            logger.Info($"Navigate to url {url}");

            Browser.Instance.NavigateToUrl(url);
            return this;
        }

        public HomePage()
        {
            WaitHelper.WaitElement(driver, InfoBlock);
        }

        [AllureStep]
        public TshirtsPage BuyProductAndGoToCart()
        {
            logger.Info($"TShirts QuickView activated successfully");

            ActivateQuickViewTShirt();
            driver.FindElement(AddTShirts).Click();

            return new TshirtsPage();
        }

        [AllureStep]
        public void ActivateQuickViewTShirt()
        {
            logger.Info($"TShirts QuickView activated successfully");

            ActivateQuickView(AddTShirts);
        }

        [AllureStep]
        public void ActivateQuickViewBlouse()
        {
            logger.Info($"Blouse QuickView activated successfully");

            ActivateQuickView(AddBlouse);
        }

        [AllureStep]
        public void ActivateQuickViewDress()
        {
            logger.Info($"Dress QuickView activated successfully");

            ActivateQuickView(AddDress);
        }

        [AllureStep]
        public void ActivateQuickView(By product)
        {
            new Actions(driver)
                .MoveToElement(driver.FindElement(product))
                .Perform();
        }


        [AllureStep]
        public CartPage AddMoreProducts()//there will be refactoring
        {
            logger.Info($"All products added to cart successfully");

            ActivateQuickViewTShirt();
            driver.FindElement(QuickAddTShirts).Click();
            new PopUpCartPage().ContinuePurchases();

            ActivateQuickViewBlouse();
            driver.FindElement(QuickAddBlouse).Click();
            new PopUpCartPage().ContinuePurchases();

            ActivateQuickViewDress();
            driver.FindElement(QuickAddDress).Click();
            new PopUpCartPage().GoToCart();

            return new CartPage();
        }

        [AllureStep]
        public LoginPage GoToLogin()
        {
            logger.Info($"Navigated to the authentication page");

            driver.FindElement(Login).Click();
            return new LoginPage();
        }

        [AllureStep]
        public CartPage GoCartPage()
        {
            logger.Info($"Moved to cart");

            LangagueSelect();
            driver.FindElement(CartPage).Click();

            return new CartPage();
        }

        [AllureStep]
        public void LangagueSelect()
        {
            logger.Info($"Language selection done");

            driver.FindElement(LanguageSelector).Click();
            driver.FindElement(EnglishLanguage).Click();
        }
    }
}

