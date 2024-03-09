using DArtTests;
using DBaseSiteTestFramework;
using NUnit.Allure.Attributes;

namespace DArtNowTestFramework
{
    /// <summary>
    /// Страница картины
    /// </summary>
    public class PaintingPage : DBasePage
    {
        public PaintingPage(DarkWebDriver driver) : base(driver) { }

        /// <summary>
        /// Получить текст стиля картины
        /// </summary>
        /// <returns></returns>
        [AllureStep("Get style element text")]
        public string? GetStyleText()
        {
            return driver.FindByXPathSafe("//*[@id=\"main_container\"]/div[3]/div[2]/div[5]/a")?.Text;
        }
    }
}
