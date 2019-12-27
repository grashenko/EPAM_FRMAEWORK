using OpenQA.Selenium;
using System;
using System.Threading;
using TestFramework.Test.Base;

namespace TestFramework.Page
{
    public class CartPage : PageBase
    {
        private const string _removeAll = "//*[contains(@class,'j-basket-item-del')]";
        private const string _priceHover = "//*[@class='item-in-basket']";

        private const string _emptyCart = "//*[@class='i-empty-basket']/h3[1]";

        public const string _firstProductInCartPath = "//*[@class='basket-list-items']/div[1]/div[1]/div[1]/a[1]/span[2]";

        public const string _plusButton = "//*[@class='plus']";

        public const string _countCart = "//*[contains(@class,'in_tb')]";

        public CartPage(IWebDriver driver)
            : base(driver)
        { }

        public string GetTitle()
        {
            var productTitle = _driver.FindElement(By.XPath(_firstProductInCartPath));
            return productTitle.Text;
        }

        public CartPage ClearAll()
        {
            var priceHover = _driver.FindElement(By.XPath(_priceHover));
            priceHover.Click();

            Thread.Sleep(1000);

            var clearAllButton = _driver.FindElement(By.XPath(_removeAll));
            clearAllButton.Click();

            Thread.Sleep(5000);
            return this;
        }

        public CartPage AddCount(int count) 
        {
            var plusButton = _driver.FindElement(By.XPath(_plusButton));

            for (int i = 0; i < count - 1; i++) 
            {
                plusButton.Click();
                Thread.Sleep(100);
            }

            return this;
        }

        public int CheckCountInCart() 
        {
            var countField = _driver.FindElement(By.XPath(_countCart));
            var count = Convert.ToInt32(countField.GetAttribute("value"));
            return count;
        }
        public bool IsCartEmpty()
        {
            var emptyCartLabel = _driver.FindElement(By.XPath(_emptyCart));
            return emptyCartLabel.Text == "В вашей корзине пока ничего нет";
        }

        public string CheckProduct()
        {
            string productTitle = _driver.FindElement(By.XPath(_firstProductInCartPath)).Text;
            return productTitle;
        }

        public void GoToPage()
        {
            _driver.Navigate().GoToUrl("https://lk.wildberries.by/basket");
        }
    }
}
