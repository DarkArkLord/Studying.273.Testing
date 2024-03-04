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

            var embroideredPaintings = home.OpenEmbroideredPaintingsPage();
            embroideredPaintings.OpenGenresMenu();
            embroideredPaintings.AddGenreFilter("��������� ������");
            embroideredPaintings.ApplyFilters();

            var trainWay = embroideredPaintings.FindPictureByName("���������� ����");

            Assert.IsNotNull(trainWay);
        }

        [Test]
        public void TrainWayStyleTest()
        {
            var home = new HomePage(driver);
            home.OpenPage();

            var embPaintingsList = home.OpenEmbroideredPaintingsPage();
            embPaintingsList.OpenGenresMenu();
            embPaintingsList.AddGenreFilter("��������� ������");
            embPaintingsList.ApplyFilters();

            var embPainting = embPaintingsList.OpenPictureByName("���������� ����");
            var style = embPainting.GetStyleElement();

            Assert.IsNotNull(style);
            Assert.IsNotNull(style?.Text);
            Assert.That(style?.Text, Is.EqualTo("�������"));
        }
    }
}