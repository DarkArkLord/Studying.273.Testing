using DArtTests;
using DBaseSiteTestFramework;

namespace DArtNowTestFramework
{
    public class HomePage : DBasePage
    {
        public HomePage(DarkWebDriver driver) : base(driver) { }

        public void OpenPage()
        {
            driver.SetUrl("https://artnow.ru/");
        }

        public EmbroideredPaintingsListPage OpenEmbroideredPaintingsPage()
        {
            driver.FindByText("Показать еще...").Click();
            driver.FindByText("Вышитые картины").Click();
            var page = new EmbroideredPaintingsListPage(driver);
            return page;
        }
    }
}
