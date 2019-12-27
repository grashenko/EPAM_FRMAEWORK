using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System.Threading;
using TestFramework.Constants;
using TestFramework.Test.Base;

namespace TestFramework.Page
{
    public class ProductPage : PageBase
    {
        private const string _addToWishButton = "//*[@class='to-poned j-postpone j-prevent-double-click']";

        public const string _addToCartButtonPath = "//*[@class='cart-btn-wrap']/button[1]";
        public const string _firstSizeButton = "//*[@class='j-size-list size-list j-smart-overflow-instance']/label[1]";
        public const string _firstProductInCartPath = "//*[@class='basket-list-items']/div[1]/div[1]/div[1]/a[1]/span[2]";
        private const string _goToCartButton = "//*[@class='user-menu-item cart-informer']";

        private const string _getTitle = "//*[@class='brand-and-name j-product-title']";


        public ProductPage(IWebDriver driver)
            : base(driver)
        {
            Url = PageUrl.Products;
        }

        public ProductPage AddToWishlist()
        {
            _driver.FindElement(By.XPath(_firstSizeButton)).Click();
            Thread.Sleep(1000);

            var addToWishButton = _driver.FindElement(By.XPath(_addToWishButton));
            addToWishButton.Click();

            return this;
        }
        public ProductPage AddToCart()
        {
            _driver.FindElement(By.XPath(_firstSizeButton)).Click();
            Thread.Sleep(1000);

            _driver.FindElement(By.XPath(_addToCartButtonPath)).Click();
            Thread.Sleep(1000);

            return this;
        }

        public CartPage GoToCartPage()
        {
            var goToCatrButton = _driver.FindElement(By.XPath(_goToCartButton));
            goToCatrButton.Click();

            return new CartPage(_driver);
        }

        public string GetTitle() 
        {
            var title = _driver.FindElement(By.XPath(_getTitle));
            return title.Text;            
        }
    }
}
