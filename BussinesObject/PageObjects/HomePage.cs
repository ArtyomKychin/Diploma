using Diploma.Core;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SeleniumTests.Diploma.PageObject;
using System.Net.Http.Headers;

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

        
        public override BasePage OpenPage()
        {
            Browser.Instance.NavigateToUrl("http://prestashop.qatestlab.com.ua/ru/");
            return this;
        }

        public HomePage()
        {
            WaitHelper.WaitElement(driver, InfoBlock);
        }


        public TshirtsPage BuyProductAndGoToCart()
        {
            ActivateQuickViewTShirt();
            driver.FindElement(AddTShirts).Click();

            return new TshirtsPage();
        }
        public void ActivateQuickViewTShirt()
        {
            ActivateQuickView(AddTShirts);
        }

        public void ActivateQuickViewBlouse()
        {
            ActivateQuickView(AddBlouse);
        }

        public void ActivateQuickViewDress()
        {
            ActivateQuickView(AddDress);
        }

        public void ActivateQuickView(By product)
        {
            new Actions(driver)
                .MoveToElement(driver.FindElement(product))
                .Perform();
        }


        public CartPage AddMoreProducts()//there will be refactoring
        {
            
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

        public LoginPage GoToLogin()
        {
            driver.FindElement(Login).Click();
            return new LoginPage();
        }

        public CartPage GoCartPage()
        {
            LangagueSelect();
            driver.FindElement(CartPage).Click();

            return new CartPage();
        }

        public void LangagueSelect()
        {
            driver.FindElement(LanguageSelector).Click();
            driver.FindElement(EnglishLanguage).Click();
        }
    }
}

