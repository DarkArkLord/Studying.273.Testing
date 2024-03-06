using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;

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

        #region Finding
        private const int DefaultTimeoutMs = 5000;

        public IWebElement FindByXPath(string xpath, int timeoutMs = DefaultTimeoutMs)
            => FindWithWaiting(By.XPath(xpath), timeoutMs);

        public IWebElement FindByText(string element, int timeoutMs = DefaultTimeoutMs)
            => FindByXPath($"//*[contains(text(), '{element}')]", timeoutMs);

        private IWebElement FindWithWaiting(By by, int timeoutMs = DefaultTimeoutMs)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(timeoutMs));
            return wait.Until(drv => drv.FindElement(by));
        }

        public IWebElement? FindByXPathSafe(string xpath, int timeoutMs = DefaultTimeoutMs)
            => FindWithWaitingSafe(By.XPath(xpath), timeoutMs);

        private IWebElement? FindWithWaitingSafe(By by, int timeoutMs = DefaultTimeoutMs)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(timeoutMs));
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            return wait.Until(drv => drv.FindElement(by));
        }

        public void WaitForClick(IWebElement element, int timeoutMs = DefaultTimeoutMs)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(timeoutMs));
            wait.IgnoreExceptionTypes(typeof(ElementNotInteractableException));
            wait.Until(drv =>
            {
                element.Click();
                return true;
            });
        }
        #endregion

        public void SetUrl(string url) => driver.Url = url;

        public void Close() => driver.Close();
    }

    public enum WebDriverType
    {
        Firefox,
        Chrome,
    }
}
