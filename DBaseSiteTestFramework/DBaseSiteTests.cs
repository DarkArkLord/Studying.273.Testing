using DArtTests;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;

namespace DBaseSiteTestFramework
{
    [AllureNUnit]
    [TestFixture(WebDriverType.Firefox, Category = "Firefox Tests")]
    [AllureSuite("Firefox Tests")]
    [TestFixture(WebDriverType.Chrome, Category = "Chrome Tests")]
    [AllureSuite("Chrome Tests")]
    public class DBaseSiteTests
    {
        private readonly WebDriverType driverType;

        public DBaseSiteTests(WebDriverType driverType)
        {
            this.driverType = driverType;
        }

        protected DarkWebDriver driver;

        [SetUp]
        [AllureStep("Setup web driver")]
        protected void Setup()
        {
            driver = DarkWebDriver.Init(driverType);
        }

        [TearDown]
        [AllureStep("Close web driver")]
        protected void StopBrowser()
        {
            driver.Close();
        }
    }
}
