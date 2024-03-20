using DArtNowTestFramework;
using DBaseSiteTestFramework;
using NUnit.Allure.Attributes;
using NUnit.Framework;

namespace DArtTests
{
    public class ArtNowTests : DBaseSiteTests
    {
        public ArtNowTests(WebDriverType driverType) : base(driverType) { }

        /// <summary>
        /// Проверка существования картины "Трамвайный путь"
        /// </summary>
        [Test]
        [AllureName("Check Train Way exists")]
        public void TrainWayExistsTest()
        {
            var home = new HomePage(driver);
            home.OpenPage();

            var paintings = home.OpenListFromLeftMenu("Вышитые картины");
            paintings.OpenGenresMenu();
            paintings.AddGenreFilter("Городской пейзаж");
            paintings.ApplyFilters();

            var trainWay = paintings.FindPictureByName("Трамвайный путь");

            Assert.IsNotNull(trainWay);
        }

        /// <summary>
        /// Проверка стиля картины "Трамвайный путь"
        /// </summary>
        [Test]
        [AllureName("Check Train Way style")]
        public void TrainWayStyleTest()
        {
            var home = new HomePage(driver);
            home.OpenPage();

            var paintings = home.OpenListFromLeftMenu("Вышитые картины");
            paintings.OpenGenresMenu();
            paintings.AddGenreFilter("Городской пейзаж");
            paintings.ApplyFilters();

            var painting = paintings.OpenPictureByName("Трамвайный путь");
            var style = painting.GetStyleText();

            Assert.IsNotNull(style);
            Assert.That(style, Is.EqualTo("Реализм"));
        }

        /// <summary>
        /// Проверка избранного
        /// </summary>
        [Test]
        [AllureName("Check favorirtes")]
        public void FavoritesTest()
        {
            var home = new HomePage(driver);
            home.OpenPage();

            var paintings = home.OpenListFromLeftMenu("Батик");
            var addedName = paintings.GetFirstPictName();
            paintings.AddFirstPictToFavorites();

            var favorites = paintings.OpenFavoritesPage();
            var favName = favorites.GetFirstElementTitle();

            favorites.TryRemoveFirstElement();
            //var noFavName = favorites.GetFirstElementTitle();

            Assert.IsNotNull(addedName);
            Assert.IsNotNull(favName);
            //Assert.IsNull(noFavName);

            var normalizedFavName = favName.Replace("\r\n", " ");

            Assert.That(normalizedFavName, Is.EqualTo(addedName));
        }

        /// <summary>
        /// Проверка поиска
        /// </summary>
        [Test]
        [AllureName("Check search")]
        public void SearchTest()
        {
            var searchText = "Жираф";

            var home = new HomePage(driver);
            home.OpenPage();

            var search = home.UseSearch(searchText);
            var searchResultText = search.GetFirstElementName();

            Assert.IsNotNull(searchResultText);
            Assert.IsNotEmpty(searchResultText);
            StringAssert.Contains(searchText, searchResultText);
        }

        /// <summary>
        /// Проверка корзины
        /// </summary>
        [Test]
        [AllureName("Check Cart")]
        public void CartTest()
        {
            var home = new HomePage(driver);
            home.OpenPage();

            var paintings = home.OpenListFromLeftMenu("Ювелирное искусство");
            paintings.AddAvailabilityFilter("В наличии");
            paintings.ApplyFilters();
            var itemPrice = paintings.GetFirstItemPrice();
            paintings.AddFirstItemToCart();

            var basket = paintings.OpenCartPageAfterAddToCart();
            var basketItemPrice = basket.GetFirstItemPrice();
            basket.RemoveFirstElement();

            Assert.That(basketItemPrice, Is.EqualTo(itemPrice));
        }

        /// <summary>
        /// Приверка создания скриншота при падении теста
        /// </summary>
        [Test]
        [AllureName("Always fail")]
        public void AlwaysFailTest()
        {
            var home = new HomePage(driver);
            home.OpenPage();
            home.ClickNotExistsElement();

            Assert.IsNotNull(null);
        }
    }
}