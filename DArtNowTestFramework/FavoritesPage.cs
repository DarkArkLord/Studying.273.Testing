using DArtTests;
using DBaseSiteTestFramework;

namespace DArtNowTestFramework
{
    public class FavoritesPage : DBasePage
    {
        public FavoritesPage(DarkWebDriver driver) : base(driver) { }

        public string? GetFirstElementTitle()
        {
            return driver.FindByXPathSafe("//*[@id=\"sa_container\"]/div[2]/a[1]/div")?.Text;
        }

        public bool TryRemoveFirstElement()
        {
            var element = driver.FindByXPathSafe("//*[@id=\"sa_container\"]/div[2]/div[4]");
            if (element is null) return false;
            element.Click();
            return true;
        }
    }
}
