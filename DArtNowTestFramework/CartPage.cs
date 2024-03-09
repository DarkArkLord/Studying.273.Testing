using DArtTests;
using DBaseSiteTestFramework;
using NUnit.Allure.Attributes;
using System;
using System.Linq;

namespace DArtNowTestFramework
{
    /// <summary>
    /// Страницы корзины
    /// </summary>
    public class CartPage : DBasePage
    {
        public CartPage(DarkWebDriver driver) : base(driver) { }

        /// <summary>
        /// Получение цены первого элемента
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception">Если что-то пойдет не так</exception>
        [AllureStep("Get first element price in cart")]
        public int GetFirstItemPrice()
        {
            var element = driver.FindByXPath("/html/body/div[2]/div[2]/div[1]/div[1]/div[3]/div[5]/div[2]");
            var priceStr = element.Text.Split(" ").FirstOrDefault();
            if (priceStr is null || priceStr.Length < 1) throw new Exception("Не найден аттрибут цены");
            if (!int.TryParse(priceStr, out var price)) throw new Exception($"Цена не является корректным числом: {priceStr}");
            return price;
        }

        /// <summary>
        /// Удаление первого элемента из корзины
        /// </summary>
        [AllureStep("Try remove first element in cart")]
        public void RemoveFirstElement()
        {
            driver.FindByXPath("/html/body/div[2]/div[2]/div[1]/div[1]/div[2]").Click();
        }
    }
}
