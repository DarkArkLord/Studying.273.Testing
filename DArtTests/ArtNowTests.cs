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
            embroideredPaintings.AddGenreFilter("Городской пейзаж");
            embroideredPaintings.ApplyFilters();

            var trainWay = embroideredPaintings.FindPictureByName("Трамвайный путь");

            Assert.IsNotNull(trainWay);
        }

        [Test]
        public void TrainWayStyleTest()
        {
            var home = new HomePage(driver);
            home.OpenPage();

            var embPaintingsList = home.OpenEmbroideredPaintingsPage();
            embPaintingsList.OpenGenresMenu();
            embPaintingsList.AddGenreFilter("Городской пейзаж");
            embPaintingsList.ApplyFilters();

            var embPainting = embPaintingsList.OpenPictureByName("Трамвайный путь");
            var style = embPainting.GetStyleElement();

            Assert.IsNotNull(style);
            Assert.IsNotNull(style?.Text);
            Assert.That(style?.Text, Is.EqualTo("Реализм"));
        }
    }
}