using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using TestFramework.Constants;
using TestFramework.Page.Base;

namespace TestFramework.Page
{
    public class ProductsPage : SearchBarPageBase<ProductsPage>
    {

        private string filterBrandCheckBox = "//*[@id='brand_list_left']/li[1]";
        private string firstProductBrand = "//*[@class='dtlist-inner-brand-name']/strong[1]";
        private string brandButton = "div[class='filterblock brand show']";

        public string firstProductPath = "//*[contains(@class, 'j-card-item')]";


        public ProductsPage(IWebDriver driver)
            : base(driver)
        {
            Url = PageUrl.Products;
        }

        public string ApplyFirstBrandFilter()
        {
            Thread.Sleep(3000);
            var filterButton = _driver.FindElement(By.CssSelector(this.brandButton));
            filterButton.Click();
            Thread.Sleep(3000);
            var brand = _driver.FindElement(By.XPath(this.filterBrandCheckBox));
            brand.Click();

            var splitedBrand = brand.Text.Split(" ");

            return String.Join(" ", splitedBrand.Take(splitedBrand.Length - 1).ToArray());
        }

        public string CheckFirstProductBrand()
        {
            Thread.Sleep(2000);
            var firstProduct = _driver.FindElement(By.XPath(this.firstProductBrand));
            return firstProduct.Text;
        }

        public ProductPage OpenProduct()
        {
            var productCard = _driver.FindElement(By.XPath(firstProductPath));
            productCard.Click();
            Thread.Sleep(500);

            return new ProductPage(_driver);
        }



    }
}
