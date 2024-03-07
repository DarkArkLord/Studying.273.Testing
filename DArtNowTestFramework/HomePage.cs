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

        public SearchPage UseSearch(string text)
        {
            driver.FindByXPath("//*[@id=\"MainSearchForm\"]/div/div[1]/input[3]").SendKeys(text);
            driver.FindByXPath("//*[@id=\"MainSearchForm\"]/div/div[2]/button").Click();
            var page = new SearchPage(driver);
            return page;
        }

        public void ClickAElement()
        {
            driver.FindByXPath("/html/body/h1").Click();
        }
    }
}
