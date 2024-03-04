using DArtTests;
using DBaseSiteTestFramework;
using OpenQA.Selenium;

namespace DArtNowTestFramework
{
    public class PaintingPage : DBasePage
    {
        public PaintingPage(DarkWebDriver driver) : base(driver) { }

        public IWebElement? GetStyleElement()
        {
            return driver.FindByXPathSafe("//*[@id=\"main_container\"]/div[3]/div[2]/div[5]/a");
        }
    }
}
