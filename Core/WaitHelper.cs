﻿using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;

namespace Diploma
{
    public class WaitHelper
    {
        public static void WaitElement(IWebDriver driver, By by, int time = 10)
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(time)).Until(element => element.FindElement(by));
        }

        public static void WaitElementWithTitle(IWebDriver driver, By by, string text, int time = 10)
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(time)).Until(element => element.FindElement(by).Text.ToLower() == text.ToLower());
        }

        public static void WaitElements(IWebDriver driver, By by, int count, int time = 10)
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(time)).Until(element => element.FindElements(by).Count == count);
        }

        public static void WaitElementDisplayed(IWebDriver driver, By by, int time = 10)
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(time)).Until(element => element.FindElement(by).Displayed);
        }

    }
}