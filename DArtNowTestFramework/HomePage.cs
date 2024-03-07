using DArtTests;
using DBaseSiteTestFramework;
using NUnit.Allure.Attributes;

namespace DArtNowTestFramework
{
    public class HomePage : DBasePage
    {
        public HomePage(DarkWebDriver driver) : base(driver) { }

        [AllureStep("Open artnow.ru home page")]
        public void OpenPage()
        {
            driver.SetUrl("https://artnow.ru/");
        }

        [AllureStep("Open {text} from left menu")]
        public PaintingsListPage OpenListFromLeftMenu(string text)
        {
            driver.FindByText("Показать еще...").Click();
            driver.FindByText(text).Click();
            var page = new PaintingsListPage(driver);
            return page;
        }

        [AllureStep("Search {text}")]
        public SearchPage UseSearch(string text)
        {
            driver.FindByXPath("//*[@id=\"MainSearchForm\"]/div/div[1]/input[3]").SendKeys(text);
            driver.FindByXPath("//*[@id=\"MainSearchForm\"]/div/div[2]/button").Click();
            var page = new SearchPage(driver);
            return page;
        }

        [AllureStep("Click to not exists element")]
        public void ClickNotExistsElement()
        {
            driver.FindByXPath("/html/body/h1").Click();
        }
    }
}
