﻿using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace DArtTests
{
    public class DarkWebDriver
    {
        private IWebDriver driver;
        public IWebDriver Driver => driver;

        #region Initialization
        public DarkWebDriver(IWebDriver driver)
        {
            this.driver = driver;
        }

        public static DarkWebDriver Init<TDriver>()
            where TDriver : IWebDriver, new()
        {
            IWebDriver driver = new TDriver();
            DarkWebDriver result = new DarkWebDriver(driver);
            return result;
        }

        public static DarkWebDriver InitFirefox() => Init<FirefoxDriver>();
        public static DarkWebDriver InitChrome() => Init<ChromeDriver>();

        public static DarkWebDriver Init(WebDriverType type)
        {
            switch (type)
            {
                case WebDriverType.Firefox: return InitFirefox();
                case WebDriverType.Chrome: return InitChrome();
                default: throw new ArgumentException(nameof(type));
            }
        }
        #endregion

        public IWebElement FindByXPath(string xpath)
            => driver.FindElement(By.XPath(xpath));

        public IWebElement FindByCssSelector(string selector)
            => driver.FindElement(By.CssSelector(selector));

        public void SetUrl(string url) => driver.Url = url;

        public void Close() => driver.Close();
    }

    public enum WebDriverType
    {
        Firefox,
        Chrome,
    }
}
