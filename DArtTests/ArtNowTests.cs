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
        /// �������� ������������� ������� "���������� ����"
        /// </summary>
        [Test]
        [AllureName("Check Train Way exists")]
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

        /// <summary>
        /// �������� ����� ������� "���������� ����"
        /// </summary>
        [Test]
        [AllureName("Check Train Way style")]
        public void TrainWayStyleTest()
        {
            var home = new HomePage(driver);
            home.OpenPage();

            var paintings = home.OpenListFromLeftMenu("������� �������");
            paintings.OpenGenresMenu();
            paintings.AddGenreFilter("��������� ������");
            paintings.ApplyFilters();

            var painting = paintings.OpenPictureByName("���������� ����");
            var style = painting.GetStyleText();

            Assert.IsNotNull(style);
            Assert.That(style, Is.EqualTo("�������"));
        }

        /// <summary>
        /// �������� ����������
        /// </summary>
        [Test]
        [AllureName("Check favorirtes")]
        public void FavoritesTest()
        {
            var home = new HomePage(driver);
            home.OpenPage();

            var paintings = home.OpenListFromLeftMenu("�����");
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
        /// �������� ������
        /// </summary>
        [Test]
        [AllureName("Check search")]
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

        /// <summary>
        /// �������� �������
        /// </summary>
        [Test]
        [AllureName("Check Cart")]
        public void CartTest()
        {
            var home = new HomePage(driver);
            home.OpenPage();

            var paintings = home.OpenListFromLeftMenu("��������� ���������");
            paintings.AddAvailabilityFilter("� �������");
            paintings.ApplyFilters();
            var itemPrice = paintings.GetFirstItemPrice();
            paintings.AddFirstItemToCart();

            var basket = paintings.OpenCartPageAfterAddToCart();
            var basketItemPrice = basket.GetFirstItemPrice();
            basket.RemoveFirstElement();

            Assert.That(basketItemPrice, Is.EqualTo(itemPrice));
        }

        /// <summary>
        /// �������� �������� ��������� ��� ������� �����
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