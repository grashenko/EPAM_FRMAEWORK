using OpenQA.Selenium;
using System.Threading;
using TestFramework.Constants;
using TestFramework.Test.Base;

namespace TestFramework.Page
{
    public class ProfilePage : PageBase
    {
        private const string _nameField = "//*[@class='non-icon right']/div[1]";

        private const string _wishlistButton = "//*[@class='poned-widget']";

        private const string _submitButton = "//*[@class='added-addres-save j-submit']";

        private const string _profileTabButton = "//*[contains(@class, 'item-profile')]/a[1]";

        private const string _userAdressChange = "//*[@class='user-address-cont']/ul[1]/li[1]/span[1]/a[1]";

        private const string _adressInput = "//*[@class='ymaps-2-1-75-searchbox-input__input']";

        private const string _apartamentInput = "//*[@class='added-addres-field added-addres-half valid']";

        private const string _searchButton = "//*[@class='ymaps-2-1-75-searchbox__button-cell']";

        private const string _userAddress = "//*[@class='user-address-cont']/ul[1]/li[1]/label[1]";


        public ProfilePage(IWebDriver driver)
            : base(driver)
        {
            Url = PageUrl.Profile;
        }

        public string GetLoggedUser()
        {
            var nameField = _driver.FindElement(By.XPath(_nameField));
            var name = nameField.Text.Remove(0, 7);
            return name;
        }

        public WishlisthPage GoToWishlistPage()
        {
            var wishlistButton = _driver.FindElement(By.XPath(_wishlistButton));
            wishlistButton.Click();
            Thread.Sleep(1000);
            return new WishlisthPage(_driver);
        }

        public ProfilePage ChangeAddress(string address, string appartament)
        {
            var profileButton = _driver.FindElement(By.XPath(_profileTabButton));
            profileButton.Click();
            Thread.Sleep(1000);

            var userAdressChangeButton = _driver.FindElement(By.XPath(_userAdressChange));
            userAdressChangeButton.Click();
            Thread.Sleep(1000);

            var adressInput = _driver.FindElement(By.XPath(_adressInput));
            ScrollToElement(adressInput);
            adressInput.SendKeys(address);
            Thread.Sleep(1000);

            var searchButton = _driver.FindElement(By.XPath(_searchButton));
            searchButton.Click();
            Thread.Sleep(1000);

            var apartamentInput = _driver.FindElement(By.XPath(_apartamentInput));
            ScrollToElement(apartamentInput);
            apartamentInput.SendKeys(appartament);
            Thread.Sleep(1000);

            var submitButton = _driver.FindElement(By.XPath(_submitButton));
            submitButton.Click();
            Thread.Sleep(1000);

            return this;
        }

        public string GetUserAddress() 
        {
            var profileButton = _driver.FindElement(By.XPath(_profileTabButton));
            profileButton.Click();
            Thread.Sleep(1000);

            var userAddressElement = _driver.FindElement(By.XPath(_userAddress));
            var userAddress = userAddressElement.Text;
            return userAddress;
        }
    }
}
