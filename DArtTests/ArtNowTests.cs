using DArtNowTestFramework;
using DBaseSiteTestFramework;
using NUnit.Framework;
using System.Threading.Tasks;

namespace DArtTests
{
    public class ArtNowTests : DBaseSiteTests
    {
        public ArtNowTests(WebDriverType driverType) : base(driverType) { }

        [Test]
        public void TrainWayExistsTest()
        {
            var home = new HomePage(driver);
            home.OpenPage();

            var paintings = home.OpenListFromLeftMenu("������� �������");
            paintings.OpenGenresMenu();
            paintings.AddGenreFilter("��������� ������");
            paintings.ApplyFilters();

            var trainWay = paintings.FindPictureByName("���������� ����");

            Assert.IsNotNull(trainWay);
        }

        [Test]
        public void TrainWayStyleTest()
        {
            var home = new HomePage(driver);
            home.OpenPage();

            var paintings = home.OpenListFromLeftMenu("������� �������");
            paintings.OpenGenresMenu();
            paintings.AddGenreFilter("��������� ������");
            paintings.ApplyFilters();

            var painting = paintings.OpenPictureByName("���������� ����");
            var style = painting.GetStyleElement();

            Assert.IsNotNull(style);
            Assert.IsNotNull(style?.Text);
            Assert.That(style?.Text, Is.EqualTo("�������"));
        }

        [Test]
        public void FavoritesTest()
        {
            var home = new HomePage(driver);
            home.OpenPage();

            var paintings = home.OpenListFromLeftMenu("�����");
            var addedName = paintings.AddFirstPictToFavoritesAndGetName();

            var favorites = paintings.OpenFavoritesPage();
            var favName = favorites.GetFirstElementTitle();

            favorites.TryRemoveFirstElement();
            //var noFavName = favorites.GetFirstElementTitle();

            Assert.IsNotNull(addedName);
            Assert.IsNotNull(favName);
            //Assert.IsNull(noFavName);

            Assert.That(favName, Is.EqualTo(addedName));
        }

        [Test]
        public void SearchTest()
        {
            var searchText = "�����";

            var home = new HomePage(driver);
            home.OpenPage();

            var search = home.UseSearch(searchText);
            var searchResultText = search.GetFirstElementName();

            Assert.IsNotNull(searchResultText);
            Assert.IsNotEmpty(searchResultText);
            StringAssert.Contains(searchText, searchResultText);
        }

        [Test]
        public void BasketTest()
        {
            var home = new HomePage(driver);
            home.OpenPage();

            var paintings = home.OpenListFromLeftMenu("��������� ���������");
            paintings.AddAvailabilityFilter("� �������");
            paintings.ApplyFilters();
            var itemPrice = paintings.GetFirstItemPrice();
            paintings.AddFirstItemToBasket();

            var basket = paintings.OpenBasketPageAfterAddToBasket();
            var basketItemPrice = basket.GetFirstItemPrice();
            basket.RemoveFirstElement();

            Assert.That(basketItemPrice, Is.EqualTo(itemPrice));
        }
    }
}