using DArtNowTestFramework;
using DBaseSiteTestFramework;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using System.Threading.Tasks;

namespace DArtTests
{
    public class ArtNowTests : DBaseSiteTests
    {
        public ArtNowTests(WebDriverType driverType) : base(driverType) { }

        [Test]
        public void Test1()
        {
            var home = new HomePage(driver);
            home.OpenPage();
            home.OpenLeftMenu();
            home.OpenElementByText("Вышитые картины");

            Task.Delay(1000).Wait();
        }
    }
}