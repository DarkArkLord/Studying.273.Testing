using DArtNowTestFramework;
using DBaseSiteTestFramework;
using NUnit.Framework;

namespace DArtTests
{
    public class ArtNowTests : DBaseSiteTests
    {
        public ArtNowTests(WebDriverType driverType) : base(driverType) { }

        [Test]
        public void TrainWayTest()
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
    }
}