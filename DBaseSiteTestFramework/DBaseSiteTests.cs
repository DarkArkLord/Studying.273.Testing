using Allure.Net.Commons;
using DArtTests;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using System;

[assembly: LevelOfParallelism(2)] // Установка количества процессов
namespace DBaseSiteTestFramework
{
    /// <summary>
    /// Базовый класс для тестов
    /// </summary>
    [Parallelizable(ParallelScope.Fixtures)] // Параллелизм по Fixtures
    [AllureNUnit] // Для использования Allure
    [TestFixture(WebDriverType.Firefox, Category = "Firefox Tests")] // Запуск тестов с Firefox драйвером
    [AllureSuite("Firefox Tests")] // Категория Allure с Firefox драйвером
    [TestFixture(WebDriverType.Chrome, Category = "Chrome Tests")] // Запуск тестов с Chrome драйвером
    [AllureSuite("Chrome Tests")] // Категория Allure с Chrome драйвером
    public class DBaseSiteTests
    {
        private readonly WebDriverType driverType;

        public DBaseSiteTests(WebDriverType driverType)
        {
            this.driverType = driverType;
        }

        protected DarkWebDriver driver;

        /// <summary>
        /// Действия перед запуском каждого теста
        /// </summary>
        [SetUp]
        [AllureStep("Setup web driver")]
        protected void Setup()
        {
            driver = DarkWebDriver.Init(driverType);
        }

        /// <summary>
        /// Действия после запуска каждого теста
        /// </summary>
        [TearDown]
        [AllureStep("Close web driver")]
        protected void StopBrowser()
        {
            // Если тест завершился неудачно - сделать скриншот и приложить
            if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
            {
                MakeScreenshot();
            }

            driver.Close();
        }

        /// <summary>
        /// Создание скриншота
        /// </summary>
        protected void MakeScreenshot()
        {
            var screenshot = ((ITakesScreenshot)driver.Driver).GetScreenshot();
            var dateText = DateTime.Now.ToString("dd-mm-yyyy-HH-mm-ss-fff");
            var fileName = $"{TestContext.CurrentContext.Test.MethodName}_screenshot_{dateText}.png";
            var path = $"{AllureLifecycle.Instance.ResultsDirectory}\\{fileName}";

            screenshot.SaveAsFile(path);
            TestContext.AddTestAttachment(path);
            AllureApi.AddAttachment(fileName, "image/png", path);
        }
    }
}
