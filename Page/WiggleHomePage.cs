using OpenQA.Selenium;

namespace FinalAutomationProject.Page
{
    class WiggleHomePage : BasePage
    {
        private const string AddressUrl = "https://www.wiggle.co.uk/";
        public IWebElement acceptCookiesButton => Driver.FindElement(By.Id("truste-consent-button"));
        public IWebElement searchWindow => Driver.FindElement(By.Id("rs"));
        public IWebElement searchButton => Driver.FindElement(By.CssSelector("#search > div > button > i"));
        public WiggleHomePage(IWebDriver webdriver) : base(webdriver) { }
        public void NavigateToPage()
        {
            if (Driver.Url != AddressUrl)
            {
                Driver.Url = AddressUrl;
            }

        }
        public void AcceptCookies()
        {
            acceptCookiesButton.Click();
        }
        public void SearchField(string input)
        {
            searchWindow.SendKeys(input);
            searchButton.Click();
        }
    }
}
