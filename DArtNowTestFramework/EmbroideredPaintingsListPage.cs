using DArtTests;
using DBaseSiteTestFramework;
using OpenQA.Selenium;

namespace DArtNowTestFramework
{
    public class EmbroideredPaintingsListPage : DBasePage
    {
        public EmbroideredPaintingsListPage(DarkWebDriver driver) : base(driver) { }

        public void OpenGenresMenu()
        {
            driver.FindByXPath("//*[@id=\"genrebox\"]//span[contains(text(), 'Показать все')]").Click();
        }

        public void AddGenreFilter(string genre)
        {
            driver.FindByXPath($"//*[@id=\"genrebox\"]/div/label[contains(text(), '{genre}')]").Click();
        }

        public void ApplyFilters()
        {
            driver.FindByXPath("//*[@id=\"FitersForm\"]//button[contains(text(), 'Применить')]").Click();
        }

        public IWebElement? FindPictureByName(string text)
        {
            return driver.FindByXPathSafe($"//*[@id=\"sa_container\"]/div/a/div[contains(text()[2], '{text}')]");
        }

        public EmbroideredPaintingPage OpenPictureByName(string text)
        {
            driver.FindByXPath($"//*[@id=\"sa_container\"]/div/a/div[contains(text()[2], '{text}')]").Click();
            var page = new EmbroideredPaintingPage(driver);
            return page;
        }
    }
}
