using DArtTests;
using DBaseSiteTestFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DArtNowTestFramework
{
    public class BasketPage : DBasePage
    {
        public BasketPage(DarkWebDriver driver) : base(driver) { }

        public int GetFirstItemPrice()
        {
            var element = driver.FindByXPath("/html/body/div[2]/div[2]/div[1]/div[1]/div[3]/div[5]/div[2]");
            var priceStr = element.Text.Split(" ").FirstOrDefault();
            if (priceStr is null || priceStr.Length < 1) throw new Exception("Не найден аттрибут цены");
            if (!int.TryParse(priceStr, out var price)) throw new Exception($"Цена не является корректным числом: {priceStr}");
            return price;
        }

        public void RemoveFirstElement()
        {
            driver.FindByXPath("/html/body/div[2]/div[2]/div[1]/div[1]/div[2]").Click();
        }
    }
}
