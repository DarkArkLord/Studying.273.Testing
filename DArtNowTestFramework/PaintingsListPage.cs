using DArtTests;
using DBaseSiteTestFramework;
using OpenQA.Selenium;
using System.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace DArtNowTestFramework
{
    public class PaintingsListPage : DBasePage
    {
        public PaintingsListPage(DarkWebDriver driver) : base(driver) { }

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

        public string AddFirstPictToFavoritesAndGetName()
        {
            driver.FindByXPath("//*[@id=\"sa_container\"]/div[2]/div[4]").Click();
            var element = driver.FindByXPath("//*[@id=\"sa_container\"]/div[2]/a[1]/div");
            return element.Text;
        }

        public FavoritesPage OpenFavoritesPage()
        {
            driver.FindByXPath("/html/body/div[1]/span[6]/img").Click();
            var page = new FavoritesPage(driver);
            return page;
        }
    }
}
