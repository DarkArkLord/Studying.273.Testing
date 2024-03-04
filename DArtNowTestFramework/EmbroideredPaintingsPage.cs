using DArtTests;
using DBaseSiteTestFramework;
using OpenQA.Selenium;

namespace DArtNowTestFramework
{
    public class EmbroideredPaintingsPage : DBasePage
    {
        public EmbroideredPaintingsPage(DarkWebDriver driver) : base(driver) { }

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

        public PaintingPage OpenPictureByName(string text)
        {
            driver.FindByXPath($"//*[@id=\"sa_container\"]/div/a/div[contains(text()[2], '{text}')]").Click();
            var page = new PaintingPage(driver);
            return page;
        }
    }
}
