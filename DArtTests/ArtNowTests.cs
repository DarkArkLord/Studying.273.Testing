using DArtNowTestFramework;
using DBaseSiteTestFramework;
using NUnit.Framework;

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
    }
}