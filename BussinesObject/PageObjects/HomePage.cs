using Diploma.Core;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SeleniumTests.Diploma.PageObject;
using System;

namespace Diploma.PageObject
{
    public class HomePage : BasePage
    {
        private By InfoBlock = By.Id("cmsinfo_block");
        private By AddTShirts = By.XPath("//h5[@itemprop='name'][.//a[@title='Faded Short Sleeve T-shirts']]");
        private By AddBlouse = By.XPath("//*[@class='product_img_link'][.//*[@title='Blouse']]");
        private By AddDress = By.XPath("//*[@class='product_img_link'][.//*[@title='Printed Dress']]");
        private By QuickAddTShirts = By.XPath("//*[@data-id-product='1']");
        private By QuickAddBlouse = By.XPath("//*[@data-id-product='2']");
        private By QuickAddDress = By.XPath("//*[@data-id-product='3']");
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


        public void ActivateQuickViewTShirt()//there will be refactoring/May be)
        {
            new Actions(driver)
                .MoveToElement(driver.FindElement(AddTShirts))
                .Perform();
        }
        public void ActivateQuickViewBlouse()//there will be refactoring
        {
            new Actions(driver)
                .MoveToElement(driver.FindElement(AddBlouse))
                .Perform();
        }
        public void ActivateQuickViewDress()//there will be refactoring
        {
            new Actions(driver)
                .MoveToElement(driver.FindElement(AddDress))
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

