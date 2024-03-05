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

        public PaintingsListPage OpenListFromLeftMenu(string text)
        {
            driver.FindByText("Показать еще...").Click();
            driver.FindByText(text).Click();
            var page = new PaintingsListPage(driver);
            return page;
        }
    }
}
