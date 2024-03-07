using DArtTests;
using DBaseSiteTestFramework;
using NUnit.Allure.Attributes;

namespace DArtNowTestFramework
{
    public class FavoritesPage : DBasePage
    {
        public FavoritesPage(DarkWebDriver driver) : base(driver) { }

        [AllureStep("Get first element name in favorites")]
        public string? GetFirstElementTitle()
        {
            return driver.FindByXPathSafe("//*[@id=\"sa_container\"]/div[2]/a[1]/div")?.Text;
        }

        [AllureStep("Try remove first element in favorites")]
        public bool TryRemoveFirstElement()
        {
            var element = driver.FindByXPathSafe("//*[@id=\"sa_container\"]/div[2]/div[4]");
            if (element is null) return false;
            element.Click();
            return true;
        }
    }
}
