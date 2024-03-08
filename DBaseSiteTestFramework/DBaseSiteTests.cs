using Allure.Net.Commons;
using DArtTests;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using System;

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
            if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
            {
                MakeScreenshot();
            }

            driver.Close();
        }

        protected void MakeScreenshot()
        {
            var screenshot = ((ITakesScreenshot)driver.Driver).GetScreenshot();
            var dateText = DateTime.Now.ToString("dd-mm-yyyy-HH-mm-ss");
            var fileName = $"{TestContext.CurrentContext.Test.MethodName}_screenshot_{dateText}.png";
            var path = $"{AllureLifecycle.Instance.ResultsDirectory}\\{fileName}";

            screenshot.SaveAsFile(path);
            TestContext.AddTestAttachment(path);
            AllureApi.AddAttachment(fileName, "image/png", path);
        }
    }
}
