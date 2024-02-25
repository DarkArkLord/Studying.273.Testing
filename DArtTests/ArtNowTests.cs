using NUnit.Framework;
using NUnit.Framework.Interfaces;
using System.Threading.Tasks;

namespace DArtTests
{
    public class ArtNowTests
    {
        private DarkWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = DarkWebDriver.InitFirefox();
            driver.SetUrl("https://artnow.ru/");
        }

        [Test]
        public void Test1()
        {
            driver.FindByXPath("//*[@id=\"left_container\"]/div/ul[2]/li[15]/div/span").Click();
            driver.FindByXPath("//*[@id=\"left_container\"]/div/ul[2]/li[8]/a").Click();
            Task.Delay(1000).Wait();
        }

        [TearDown]
        public void StopBrowser()
        {
            driver.Close();
        }
    }
}