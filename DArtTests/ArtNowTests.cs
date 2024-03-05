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

            var paintings = home.OpenListFromLeftMenu("Вышитые картины");
            paintings.OpenGenresMenu();
            paintings.AddGenreFilter("Городской пейзаж");
            paintings.ApplyFilters();

            var trainWay = paintings.FindPictureByName("Трамвайный путь");

            Assert.IsNotNull(trainWay);
        }

        [Test]
        public void TrainWayStyleTest()
        {
            var home = new HomePage(driver);
            home.OpenPage();

            var paintings = home.OpenListFromLeftMenu("Вышитые картины");
            paintings.OpenGenresMenu();
            paintings.AddGenreFilter("Городской пейзаж");
            paintings.ApplyFilters();

            var painting = paintings.OpenPictureByName("Трамвайный путь");
            var style = painting.GetStyleElement();

            Assert.IsNotNull(style);
            Assert.IsNotNull(style?.Text);
            Assert.That(style?.Text, Is.EqualTo("Реализм"));
        }
    }
}