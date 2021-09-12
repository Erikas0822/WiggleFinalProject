using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace FinalAutomationProject.Page
{
    class WiggleInsuranceCalculatorPage : BasePage
    {
        public IWebElement bikeValueInput => Driver.FindElement(By.Id("bikeValue[1]"));
        public IWebElement typeListInput => Driver.FindElement(By.Id("bikeType[1]"));
        public IWebElement makeListInput => Driver.FindElement(By.Id("make[1]"));
        public IWebElement bikeModelInput => Driver.FindElement(By.Id("model[1]"));
        public IWebElement yearListInput => Driver.FindElement(By.Id("year[1]"));
        public IWebElement moveToElement => Driver.FindElement(By.CssSelector("#tab-1 > div.parentsection > div > div.childblock.ci-9 > div.quote-col-1.parts.pretty.p-default > div > label > div"));
        public IWebElement receiptLaterCheckBox => Driver.FindElement(By.Id("provideLater[1]"));
        public IWebElement calculateButton => Driver.FindElement(By.CssSelector("#instant_quote_form > div > div.quote-tab-container > div > div.button-with-margin > div.single-action > input"));
        public IWebElement verifyInscurancePrice => Driver.FindElement(By.CssSelector("#instant_quote_form > div > div.sidebar-page > div > div.pricetopblock > div.estimate-section > div.month.selected > div > div > div"));
        public WiggleInsuranceCalculatorPage(IWebDriver webdriver) : base(webdriver) { }

        public void AmmountForBike(string value)
        {
            bikeValueInput.SendKeys(value);
        }
        public void BikeTypeList(string type)
        {
            typeListInput.Click();
            typeListInput.SendKeys(type);

        }
        public void BikeBrandList(string make)
        {
            makeListInput.Click();
            makeListInput.SendKeys(make);
        }
        public void BikeModel(string model)
        {
            bikeModelInput.SendKeys(model);
        }
        public void BikeYearList(string year)
        {
            yearListInput.Click();
            yearListInput.SendKeys(year);
        }
        public void ReceiptLaterCheckBox()
        {
            Actions actions = new Actions(Driver);
            actions.MoveToElement(moveToElement);
            actions.Build().Perform();

            receiptLaterCheckBox.Click();
        }
        public void CalculateMyQuate()
        {
            calculateButton.Click();
        }
        public void VerifyMonthlyPayment(string payment)
        {
            GetWait().Until(ExpectedConditions.ElementIsVisible(By.CssSelector("#instant_quote_form > div > div.sidebar-page > div > div.pricetopblock > div.estimate-section > div.month.selected > div")));
            Assert.IsTrue(verifyInscurancePrice.Text.Contains(payment), "Monthly payment is wrong");
        }
    }
}
