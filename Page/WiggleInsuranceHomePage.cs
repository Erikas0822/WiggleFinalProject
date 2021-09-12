using OpenQA.Selenium;

namespace FinalAutomationProject.Page
{
    class WiggleInsuranceHomePage : BasePage
    {
        public IWebElement acceptSecondCookiesButton => Driver.FindElement(By.Id("cookie_action_close_header"));
        public IWebElement chooseYourCoverButton => Driver.FindElement(By.CssSelector("#home-page > div.swiper-container-home > div > div > div.col-md-6.col-12.home-banner-cta.text-right.order-md-first.order-last.pb-5 > button"));
        public IWebElement withEssentialsButton => Driver.FindElement(By.CssSelector("#home-page-get-quote > div.row.mt-md-5.mt-0.justify-content-center.home-cover-levels > div.col-md-4.home-cover-level-box > a.orange-link"));
        public WiggleInsuranceHomePage(IWebDriver webdriver) : base(webdriver) { }
        public void SecondCookieAccept()
        {
            acceptSecondCookiesButton.Click();
        }
        public void InscuranceButtonClick()
        {
            chooseYourCoverButton.Click();
        }
        public void EssentialButtonClick()
        {
            withEssentialsButton.Click();
        }
    }
}

