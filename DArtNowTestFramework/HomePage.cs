using DArtTests;
using DBaseSiteTestFramework;
using static System.Net.Mime.MediaTypeNames;

namespace DArtNowTestFramework
{
    public class HomePage : DBasePage
    {
        public HomePage(DarkWebDriver driver) : base(driver) { }

        public void OpenPage()
        {
            driver.SetUrl("https://artnow.ru/");
        }

        public void OpenLeftMenu()
        {
            driver.FindByXPath("//*[@id=\"left_container\"]/div/ul[2]/li[15]/div/span").Click();
        }

        public void OpenElementByText(string element)
        {
            driver.FindByXPath($"//*[contains(text(), '{element}')]").Click();
        }
    }
}
