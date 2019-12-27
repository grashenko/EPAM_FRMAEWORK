using OpenQA.Selenium;
using System.Threading;
using TestFramework.Constants;
using TestFramework.Page.Base;

namespace TestFramework.Page
{
    public class HomePage : SearchBarPageBase<HomePage>
    {
        private const string _loginButton = "//*[@class='offline open user-menu-login j-main-login']";
        private const string _profileButton = "//*[@class='online user-menu-login']";

        public HomePage(IWebDriver driver)
            : base(driver)
        {
            Url = PageUrl.Home;
        }

        public HomePage GoTo()
        {
            _driver.Navigate().GoToUrl(Url);
            return this;
        }

        public LoginPage GoToLoginPage()
        {
            var loginButton = _driver.FindElement(By.XPath(_loginButton));
            loginButton.Click();
            Thread.Sleep(500);
            return new LoginPage(_driver);
        }

        public ProfilePage GoToProfilePage()
        {
            Thread.Sleep(1000);
            var profileButton = _driver.FindElement(By.XPath(_profileButton));
            Thread.Sleep(500);
            profileButton.Click();
            Thread.Sleep(1000);
            return new ProfilePage(_driver);
        }

        public ProductsPage GoToProdustsPage()
        {
            _driver.Navigate().GoToUrl(PageUrl.Products);
            Thread.Sleep(1000);
            return new ProductsPage(_driver);
        }
    }
}
