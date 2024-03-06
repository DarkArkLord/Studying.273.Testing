using DArtTests;
using DBaseSiteTestFramework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DArtNowTestFramework
{
    public class SearchPage : DBasePage
    {
        public SearchPage(DarkWebDriver driver) : base(driver) { }

        public string? GetFirstElementName()
        {
            return driver.FindByXPathSafe("//*[@id=\"sa_container\"]/div[2]/a[1]/div")?.Text;
        }
    }
}
