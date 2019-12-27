using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using OpenQA.Selenium;
using System.Linq;
using TestFramework.Driver;
using TestFramework.Environment;
using TestFramework.Page;
using TestFramework.Test.Base;
using TestFramework.Test.Services;

namespace TestFramework.Test.Tests
{
    [TestFixture]
    public class ProductTests : TestBase
    {
        private IWebDriver _driver;
        private IConfiguration _configuration;

        [SetUp]
        public void Setup()
        {
            _configuration = Settings.GetConfiguration();
            _driver = DriverController.Driver(Settings.Browser);
            _driver.Manage().Window.Maximize();
        }

        [TearDown]
        public void CloseBrowser()
        {
            DriverController.CloseBrowser();
        }

        [Test]
        public void SearchTest()
        {
            Test(() =>
            {
                var product = ProductCreator.CreateProduct(_configuration);
                var homePage = new HomePage(_driver);
                var productName = homePage
                    .GoTo()
                    .GoToProdustsPage()
                    .SearchProduct(product.Search)
                    .OpenProduct()
                    .GetTitle();

                Assert.IsTrue(productName.Contains(product.Search));
            });
        }

        [Test]
        public void BrandFilterTest()
        {
            Test(() =>
            {
                var product = ProductCreator.CreateProduct(_configuration);
                var homePage = new HomePage(_driver);
                var productsPage = homePage
                    .GoTo()
                    .GoToProdustsPage();

                var firstBrandName = productsPage.ApplyFirstBrandFilter();
                var firstProductName = productsPage.CheckFirstProductBrand();

                Assert.IsTrue(firstProductName.Contains(firstBrandName));
            });
        }

        [Test]
        public void ProductsCountInCart()
        {
            Test(() =>
            {
                var product = ProductCreator.CreateProduct(_configuration);
                var homePage = new HomePage(_driver);
                var productsCount = homePage
                    .GoTo()
                    .GoToProdustsPage()
                    .SearchProduct(product.AddToCart)
                    .OpenProduct()
                    .AddToCart()
                    .GoToCartPage()
                    .AddCount(product.CountInCart)
                    .CheckCountInCart();

                Assert.IsTrue(productsCount == product.CountInCart);
            });
        }

        [Test]
        public void AddToCartTest()
        {
            Test(() =>
            {
                var product = ProductCreator.CreateProduct(_configuration);
                var homePage = new HomePage(_driver);
                var productTitle = homePage
                    .GoTo()
                    .GoToProdustsPage()
                    .SearchProduct(product.AddToCart)
                    .OpenProduct()
                    .AddToCart()
                    .GoToCartPage()
                    .GetTitle();

                Assert.IsTrue(productTitle.ToLower().Contains(product.AddToCart.ToLower()));
            });
        }

        [Test]
        public void ClearCartTest()
        {
            Test(() =>
            {
                var product = ProductCreator.CreateProduct(_configuration);
                var homePage = new HomePage(_driver);
                var isCartEmpty = homePage
                    .GoTo()
                    .GoToProdustsPage()
                    .SearchProduct(product.AddToCart)
                    .OpenProduct()
                    .AddToCart()
                    .GoToCartPage()
                    .ClearAll()
                    .IsCartEmpty();

                Assert.IsTrue(isCartEmpty);
            });
        }
    }
}
