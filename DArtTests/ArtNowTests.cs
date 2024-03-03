using NUnit.Framework;
using NUnit.Framework.Interfaces;
using System.Threading.Tasks;

namespace DArtTests
{
    [TestFixture(2)]
    [TestFixture(5)]
    public class ArtNowTests
    {
        private readonly WebDriverType driverType;

        public ArtNowTests(WebDriverType driverType)
        {
            this.driverType = driverType;
            driver = null;
        }

        private DarkWebDriver driver;
        private int t;

        [SetUp]
        public void Setup()
        {
            t = q;
            //driver = DarkWebDriver.InitFirefox();
            //driver.SetUrl("https://artnow.ru/");
        }

        [Test]
        public void Test1()
        {
            Assert.Positive(t);
            //driver.FindByXPath("//*[@id=\"left_container\"]/div/ul[2]/li[15]/div/span").Click();
            //driver.FindByXPath("//*[@id=\"left_container\"]/div/ul[2]/li[8]/a").Click();
            //Task.Delay(1000).Wait();
        }

        [TearDown]
        public void StopBrowser()
        {
            //driver.Close();
        }
    }
}