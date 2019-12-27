using OpenQA.Selenium;
using System.Threading;
using TestFramework.Constants;
using TestFramework.Test.Base;
using TestFramework.Test.Models;

namespace TestFramework.Page
{
    public class LoginPage : PageBase
    {
        private const string _emailField = "//*[@id='Item_Login']";
        private const string _passwordField = "//*[@id='Item_Password']";
        private const string _submitButton = "//*[@id='signIn']";
        private const string _enterByPasswordButton = "//*[@class='c-link-in3-v1 j-s-show-pass-login']";

        public LoginPage(IWebDriver driver)
            : base(driver)
        {
            Url = PageUrl.Login;
        }

        public HomePage WriteCredentials(User user)
        {

            var loginButton = _driver.FindElement(By.XPath(_enterByPasswordButton));
            loginButton.Click();
            Thread.Sleep(500);

            var emailField = _driver.FindElement(By.XPath(_emailField));
            ScrollToElement(emailField);
            emailField.SendKeys(user.Email);

            var passwordField = _driver.FindElement(By.XPath(_passwordField));
            ScrollToElement(passwordField);
            passwordField.SendKeys(user.Password);

            var submitButton = _driver.FindElement(By.XPath(_submitButton));
            ScrollToElement(submitButton);
            submitButton.Click();

            Thread.Sleep(1000);
            return new HomePage(_driver);
        }

    }
}
