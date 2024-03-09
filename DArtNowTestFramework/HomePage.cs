using DArtTests;
using DBaseSiteTestFramework;
using NUnit.Allure.Attributes;

namespace DArtNowTestFramework
{
    /// <summary>
    /// Домашняя страница сайта
    /// </summary>
    public class HomePage : DBasePage
    {
        public HomePage(DarkWebDriver driver) : base(driver) { }

        /// <summary>
        /// Открытие домашней страницы
        /// </summary>
        [AllureStep("Open artnow.ru home page")]
        public void OpenPage()
        {
            driver.SetUrl("https://artnow.ru/");
        }

        /// <summary>
        /// Открытие элемента из левого меню
        /// </summary>
        /// <param name="text">Текст элемента меню</param>
        /// <returns></returns>
        [AllureStep("Open {text} from left menu")]
        public PaintingsListPage OpenListFromLeftMenu(string text)
        {
            driver.FindByXPathSafe("//*[@id=\"left_container\"]/div/ul[2]/li[15]/div/span")?.Click();
            driver.FindByText(text).Click();
            var page = new PaintingsListPage(driver);
            return page;
        }

        /// <summary>
        /// Поиск по тексту
        /// </summary>
        /// <param name="text">Техт</param>
        /// <returns></returns>
        [AllureStep("Search {text}")]
        public SearchPage UseSearch(string text)
        {
            driver.FindByXPath("//*[@id=\"MainSearchForm\"]/div/div[1]/input[3]").SendKeys(text);
            driver.FindByXPath("//*[@id=\"MainSearchForm\"]/div/div[2]/button").Click();
            var page = new SearchPage(driver);
            return page;
        }

        /// <summary>
        /// Слик по несуществующему элементу для всегда падающего теста
        /// </summary>
        [AllureStep("Click to not exists element")]
        public void ClickNotExistsElement()
        {
            driver.FindByXPath("/html/body/h1").Click();
        }
    }
}
