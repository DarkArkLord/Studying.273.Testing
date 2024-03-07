using DArtTests;
using DBaseSiteTestFramework;
using NUnit.Allure.Attributes;

namespace DArtNowTestFramework
{
    public class PaintingPage : DBasePage
    {
        public PaintingPage(DarkWebDriver driver) : base(driver) { }

        [AllureStep("Get style element text")]
        public string? GetStyleText()
        {
            return driver.FindByXPathSafe("//*[@id=\"main_container\"]/div[3]/div[2]/div[5]/a")?.Text;
        }
    }
}
