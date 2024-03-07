using DArtTests;
using DBaseSiteTestFramework;
using NUnit.Allure.Attributes;

namespace DArtNowTestFramework
{
    public class SearchPage : DBasePage
    {
        public SearchPage(DarkWebDriver driver) : base(driver) { }

        [AllureStep("Get first element name in search")]
        public string? GetFirstElementName()
        {
            return driver.FindByXPathSafe("//*[@id=\"sa_container\"]/div[2]/a[1]/div")?.Text;
        }
    }
}
