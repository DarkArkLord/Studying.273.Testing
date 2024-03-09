using DArtTests;
using DBaseSiteTestFramework;
using NUnit.Allure.Attributes;
using OpenQA.Selenium;

namespace DArtNowTestFramework
{
    /// <summary>
    /// Страница списка картин
    /// </summary>
    public class PaintingsListPage : DBasePage
    {
        public PaintingsListPage(DarkWebDriver driver) : base(driver) { }

        /// <summary>
        /// Развернуть меню жанров
        /// </summary>
        [AllureStep("Open genres menu")]
        public void OpenGenresMenu()
        {
            driver.FindByXPathSafe("//*[@id=\"genrebox\"]//span[contains(text(), 'Показать все')]")?.Click();
        }

        /// <summary>
        /// Добавить фильтр жанра
        /// </summary>
        /// <param name="genre">Жанр</param>
        [AllureStep("Add genre filter {genre}")]
        public void AddGenreFilter(string genre)
        {
            driver.FindByXPath($"//*[@id=\"genrebox\"]/div/label[contains(text(), '{genre}')]").Click();
        }

        /// <summary>
        /// Добавить фильтр наличия
        /// </summary>
        /// <param name="availability">Наличие</param>
        [AllureStep("Add availability filter {availability}")]
        public void AddAvailabilityFilter(string availability)
        {
            driver.FindByXPath($"//*[@id=\"salebox\"]/div/label[contains(text(), '{availability}')]").Click();
        }

        /// <summary>
        /// Применить фильтры
        /// </summary>
        [AllureStep("Apply filters")]
        public void ApplyFilters()
        {
            driver.FindByXPath("//*[@id=\"FitersForm\"]//button[contains(text(), 'Применить')]").Click();
        }

        /// <summary>
        /// Поиск картины по названию
        /// </summary>
        /// <param name="text">Название</param>
        /// <returns></returns>
        [AllureStep("Find picture element with text {text}")]
        public IWebElement? FindPictureByName(string text)
        {
            return driver.FindByXPathSafe($"//*[@id=\"sa_container\"]/div/a/div[contains(text()[2], '{text}')]");
        }

        /// <summary>
        /// Открыть картину по названию
        /// </summary>
        /// <param name="text">Название</param>
        /// <returns></returns>
        [AllureStep("Open picture {text}")]
        public PaintingPage OpenPictureByName(string text)
        {
            var element = driver.FindByXPath($"//*[@id=\"sa_container\"]/div/a/div[contains(text()[2], '{text}')]");
            driver.WaitForClick(element);
            var page = new PaintingPage(driver);
            return page;
        }

        /// <summary>
        /// Добавить первую картину в списке в избранное
        /// </summary>
        [AllureStep("Add first picture to favorites")]
        public void AddFirstPictToFavorites()
        {
            driver.FindByXPath("//*[@id=\"sa_container\"]/div[2]/div[4]").Click();
        }

        /// <summary>
        /// Получить название первой картины в списке
        /// </summary>
        /// <returns></returns>
        [AllureStep("Get first picture name")]
        public string GetFirstPictName()
        {
            var element = driver.FindByXPath("//*[@id=\"sa_container\"]/div[2]/a[1]/div");
            return element.Text;
        }

        /// <summary>
        /// Открыть страницу избранного
        /// </summary>
        /// <returns></returns>
        [AllureStep("Open favorites page")]
        public FavoritesPage OpenFavoritesPage()
        {
            driver.FindByXPath("/html/body/div[1]/span[6]/img").Click();
            var page = new FavoritesPage(driver);
            return page;
        }

        /// <summary>
        /// Поцучить цену первой картины в списке
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.Exception">Если что-то пойдет не так</exception>
        [AllureStep("Get first picture price")]
        public int GetFirstItemPrice()
        {
            var element = driver.FindByXPath("//*[@id=\"sa_container\"]/div[2]/div[2]/meta[2]");
            var priceStr = element.GetAttribute("content");
            if (priceStr is null || priceStr.Length < 1) throw new System.Exception("Не найдено свойства цены");
            if (!int.TryParse(priceStr, out var price)) throw new System.Exception($"Цена не является корректным числом: {priceStr}");
            return price;
        }

        /// <summary>
        /// Добавить первую картину в списке в корзину
        /// </summary>
        [AllureStep("Add first picture to cart")]
        public void AddFirstItemToCart()
        {
            driver.FindByXPath("//*[@id=\"sa_container\"]/div[2]/a[2]/div").Click();
        }

        /// <summary>
        /// Открыть корзину после добавления элемента
        /// </summary>
        /// <returns></returns>
        [AllureStep("Open cart after add picture to cart")]
        public CartPage OpenCartPageAfterAddToCart()
        {
            driver.FindByXPath("//*[@id=\"cmodal\"]/div/p/button[1]").Click();
            var page = new CartPage(driver);
            return page;
        }
    }
}
