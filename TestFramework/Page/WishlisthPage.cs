using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;
using TestFramework.Constants;
using TestFramework.Test.Base;
using TestFramework.Test.Models;

namespace TestFramework.Page
{
    public class WishlisthPage : PageBase
    {
        private const string _createButton = "//*[@class='j-create-group btn-create']";
        private const string _titleField = "//*[@id='Name']";
        private const string _submitButton = "//*[@class='j-save-group c-btn-main save']";

        private const string _productTitle = "//*[@class='title j-product-popup']";

        private const string _deleteButton = "//*[@class='j-delete-group btn-delete']";

        private const string _wishlistTitle = "//*[@class='poned_button']/button[1]/span[1]";

        private const string _acceptDelete = "//*[@class='alert-popup-close yes']";

        private const string _firstGroup = "//*[@class='poned_button']/button[1]";


        public WishlisthPage(IWebDriver driver)
            : base(driver)
        {
            Url = PageUrl.Wishlihst;
        }

        public WishlisthPage CreateWishlist(Wishlist wishlist)
        {
            var createButton = _driver.FindElement(By.XPath(_createButton));
            createButton.Click();

            var titleField = _driver.FindElement(By.XPath(_titleField));
            titleField.SendKeys(wishlist.Title);

            var submitButton = _driver.FindElement(By.XPath(_submitButton));
            submitButton.Click();

            return this;
        }

        public WishlisthPage RemoveWishlist()
        {
            var firstGroup = _driver.FindElement(By.XPath(_firstGroup));
            firstGroup.Click();
            Thread.Sleep(1000);

            var deleteButton = _driver.FindElement(By.XPath(_deleteButton));
            deleteButton.Click();
            Thread.Sleep(1000);

            var acceptDelete = _driver.FindElement(By.XPath(_acceptDelete));
            acceptDelete.Click();

            return this;
        }

        public string GetWishlistTitle()
        {
            var wishlistTitle = _driver.FindElement(By.XPath(_wishlistTitle));
            return wishlistTitle.Text;
        }

        public int CountWishlists()
        {
            var wishlists = _driver.FindElements(By.XPath(_wishlistTitle));
            return wishlists.Count;
        }

        public string GetWishedProduct()
        {
            var productFiled = _driver.FindElement(By.XPath(_productTitle));
            var phoneTitle = productFiled.GetAttribute("title");
            return phoneTitle;
        }
    }
}
