using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;

namespace DArtTests
{
    /// <summary>
    /// Обертка над IWebDriver
    /// </summary>
    public class DarkWebDriver
    {
        private IWebDriver driver;
        public IWebDriver Driver => driver;

        #region Initialization
        public DarkWebDriver(IWebDriver driver)
        {
            this.driver = driver;
        }

        /// <summary>
        /// Инициализация обертки по типу драйвера
        /// </summary>
        /// <typeparam name="TDriver">Тип драйвера для обертки</typeparam>
        /// <returns></returns>
        public static DarkWebDriver Init<TDriver>()
            where TDriver : IWebDriver, new()
        {
            IWebDriver driver = new TDriver();
            DarkWebDriver result = new DarkWebDriver(driver);
            return result;
        }

        /// <summary>
        /// Инициализация обертки для Firefox
        /// </summary>
        /// <returns></returns>
        public static DarkWebDriver InitFirefox() => Init<FirefoxDriver>();

        /// <summary>
        /// Инициализация обертки для Chrome
        /// </summary>
        /// <returns></returns>
        public static DarkWebDriver InitChrome() => Init<ChromeDriver>();

        /// <summary>
        /// Инициализация обертки по значению WebDriverType
        /// </summary>
        /// <param name="type">Тип браузера</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">Если некорректный тип</exception>
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
        /// <summary>
        /// Стандартная задержка для ожидания элемента при загрузке страницы
        /// </summary>
        private const int DefaultTimeoutMs = 5000;

        /// <summary>
        /// Поиск элемента по XPath
        /// </summary>
        /// <param name="xpath">Параметр XPath</param>
        /// <param name="timeoutMs">Задержка для ожидания поиска</param>
        /// <returns></returns>
        public IWebElement FindByXPath(string xpath, int timeoutMs = DefaultTimeoutMs)
            => WaitForFinding(By.XPath(xpath), timeoutMs);

        /// <summary>
        /// Поиск элемента по тексту
        /// </summary>
        /// <param name="xpath">Параметр текста</param>
        /// <param name="timeoutMs">Задержка для ожидания поиска</param>
        /// <returns></returns>
        public IWebElement FindByText(string element, int timeoutMs = DefaultTimeoutMs)
            => FindByXPath($"//*[contains(text(), '{element}')]", timeoutMs);

        /// <summary>
        /// Безопасный поиск элемента по XPath
        /// </summary>
        /// <param name="xpath">Параметр XPath</param>
        /// <param name="timeoutMs">Задержка для ожидания поиска</param>
        /// <returns></returns>
        public IWebElement? FindByXPathSafe(string xpath, int timeoutMs = DefaultTimeoutMs)
            => WaitForFindingSafe(By.XPath(xpath), timeoutMs);
        #endregion

        #region Waiting
        /// <summary>
        /// Поиск с ожиданием
        /// </summary>
        /// <param name="by">Параметр поиска</param>
        /// <param name="timeoutMs">Задержка для ожидания</param>
        /// <returns></returns>
        private IWebElement WaitForFinding(By by, int timeoutMs = DefaultTimeoutMs)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(timeoutMs));
            return wait.Until(drv => drv.FindElement(by));
        }

        /// <summary>
        /// Безопасный поиск с ожиданием
        /// </summary>
        /// <param name="by">Параметр поиска</param>
        /// <param name="timeoutMs">Задержка для ожидания</param>
        /// <returns></returns>
        private IWebElement? WaitForFindingSafe(By by, int timeoutMs = DefaultTimeoutMs)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(timeoutMs));
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            return wait.Until(drv => drv.FindElement(by));
        }

        /// <summary>
        /// Ожидание доступности эелемента для клика
        /// </summary>
        /// <param name="element">Элемент ожидающий клика</param>
        /// <param name="timeoutMs">Задержка для ожидания</param>
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

        /// <summary>
        /// Переход по ссылке
        /// </summary>
        /// <param name="url">Ссылка</param>
        public void SetUrl(string url) => driver.Url = url;

        /// <summary>
        /// Закрытие двайвера
        /// </summary>
        public void Close() => driver.Close();
    }

    public enum WebDriverType
    {
        Firefox,
        Chrome,
    }
}
