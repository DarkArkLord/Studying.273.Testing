using DArtTests;
using NUnit.Framework;

namespace DBaseSiteTestFramework
{
    [TestFixture(WebDriverType.Firefox)]
    [TestFixture(WebDriverType.Chrome)]
    public class BaseSiteTests
    {
        private readonly WebDriverType driverType;

        public BaseSiteTests(WebDriverType driverType)
        {
            this.driverType = driverType;
        }

        protected DarkWebDriver driver;

        [SetUp]
        protected void Setup()
        {
            driver = DarkWebDriver.Init(driverType);
            //driver.SetUrl("https://artnow.ru/");
        }

        [TearDown]
        protected void StopBrowser()
        {
            driver.Close();
        }
    }
}
