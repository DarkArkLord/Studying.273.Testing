using DArtTests;
using DBaseSiteTestFramework;
using OpenQA.Selenium;

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

        public void AddAvailabilityFilter(string availability)
        {
            driver.FindByXPath($"//*[@id=\"salebox\"]/div/label[contains(text(), '{availability}')]").Click();
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
            var element = driver.FindByXPath($"//*[@id=\"sa_container\"]/div/a/div[contains(text()[2], '{text}')]");
            driver.WaitForClick(element);
            var page = new PaintingPage(driver);
            return page;
        }

        public void AddFirstPictToFavorites()
        {
            driver.FindByXPath("//*[@id=\"sa_container\"]/div[2]/div[4]").Click();
        }

        public string GetFirstPictName()
        {
            var element = driver.FindByXPath("//*[@id=\"sa_container\"]/div[2]/a[1]/div");
            return element.Text;
        }

        public FavoritesPage OpenFavoritesPage()
        {
            driver.FindByXPath("/html/body/div[1]/span[6]/img").Click();
            var page = new FavoritesPage(driver);
            return page;
        }

        public int GetFirstItemPrice()
        {
            var element = driver.FindByXPath("//*[@id=\"sa_container\"]/div[2]/div[2]/meta[2]");
            var priceStr = element.GetAttribute("content");
            if (priceStr is null || priceStr.Length < 1) throw new System.Exception("Не найдено свойства цены");
            if (!int.TryParse(priceStr, out var price)) throw new System.Exception($"Цена не является корректным числом: {priceStr}");
            return price;
        }

        public void AddFirstItemToCart()
        {
            driver.FindByXPath("//*[@id=\"sa_container\"]/div[2]/a[2]/div").Click();
        }

        public BasketPage OpenCartPageAfterAddToBasket()
        {
            driver.FindByXPath("//*[@id=\"cmodal\"]/div/p/button[1]").Click();
            var page = new BasketPage(driver);
            return page;
        }
    }
}
