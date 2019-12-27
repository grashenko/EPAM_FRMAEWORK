using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using OpenQA.Selenium;
using TestFramework.Driver;
using TestFramework.Environment;
using TestFramework.Page;
using TestFramework.Test.Base;
using TestFramework.Test.Services;

namespace TestFramework.Test.Tests
{
    [TestFixture]
    public class UserTests : TestBase
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
        public void LoginTest()
        {
            Test(() =>
            {
                var user = UserCreator.CreateUser(_configuration);
                var homePage = new HomePage(_driver);
                var userEmail = homePage
                    .GoTo()
                    .GoToLoginPage()
                    .WriteCredentials(user)
                    .GoToProfilePage()
                    .GetLoggedUser();
                Assert.AreEqual(user.Email, userEmail);
            });
        }

        [Test]
        public void ChangeAddressTest()
        {
            Test(() =>
            {
                var user = UserCreator.CreateUser(_configuration);
                var homePage = new HomePage(_driver);
                var userAddress = homePage
                    .GoTo()
                    .GoToLoginPage()
                    .WriteCredentials(user)
                    .GoToProfilePage()
                    .ChangeAddress(user.AddressChange, user.Appartement)
                    .GetUserAddress();


                Assert.AreEqual(user.Address, userAddress);
            });
        }
    }
}
