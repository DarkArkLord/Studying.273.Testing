using DArtTests;
using NUnit.Allure.Core;
using NUnit.Framework;

namespace DBaseSiteTestFramework
{
    [TestFixture(WebDriverType.Firefox)]
    [TestFixture(WebDriverType.Chrome)]
    [AllureNUnit]
    public class DBaseSiteTests
    {
        private readonly WebDriverType driverType;

        public DBaseSiteTests(WebDriverType driverType)
        {
            this.driverType = driverType;
        }

        protected DarkWebDriver driver;

        [SetUp]
        protected void Setup()
        {
            driver = DarkWebDriver.Init(driverType);
        }

        [TearDown]
        protected void StopBrowser()
        {
            driver.Close();
        }
    }
}
