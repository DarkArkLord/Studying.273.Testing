using DArtTests;

namespace DBaseSiteTestFramework
{
    /// <summary>
    /// Базовый класс страницы
    /// </summary>
    public class DBasePage
    {
        protected DarkWebDriver driver;

        public DBasePage(DarkWebDriver driver)
        {
            this.driver = driver;
        }
    }
}
