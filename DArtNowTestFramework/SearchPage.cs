using DArtTests;
using DBaseSiteTestFramework;
using NUnit.Allure.Attributes;

namespace DArtNowTestFramework
{
    /// <summary>
    /// Страница поиска
    /// </summary>
    public class SearchPage : DBasePage
    {
        public SearchPage(DarkWebDriver driver) : base(driver) { }

        /// <summary>
        /// Получить название первого элемента в поиске
        /// </summary>
        /// <returns></returns>
        [AllureStep("Get first element name in search")]
        public string? GetFirstElementName()
        {
            return driver.FindByXPathSafe("//*[@id=\"sa_container\"]/div[2]/a[1]/div")?.Text;
        }
    }
}
