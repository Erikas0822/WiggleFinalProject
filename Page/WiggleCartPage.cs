using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace FinalAutomationProject.Page
{
    class WiggleCartPage : BasePage
    {
        public IWebElement dropDownList => Driver.FindElement(By.Id("ddlDestination"));
        public IWebElement shippingCondition => Driver.FindElement(By.CssSelector("#basket-banners-container > div"));
        public IWebElement shippingConditionResult => Driver.FindElement(By.CssSelector("#basket-delivery-destination > div > table > tbody > tr:nth-child(1) > td.options-cost"));
        public WiggleCartPage(IWebDriver webdriver) : base(webdriver) { }
        public void DropDownListSelect()
        {
            dropDownList.Click();
        }
        public void SelectFromDropDownText(string destinations)
        {
            IWebElement shipping = Driver.FindElement(By.Id("ddlDestination"));
            SelectElement select = new SelectElement(shipping);
            select.SelectByText(destinations);
        }
        public void VerifyAmountForFreeShipping(string price)
        {
            Assert.IsTrue(shippingCondition.Text.Contains(price),
                $"Result is wrong, was {shippingCondition.Text}, but expected to contain {price}");
        }
        public void VerifyFreeShipping()
        {
            Assert.AreEqual("Free", shippingConditionResult.Text, "Shipping for this item is free");
        }
    }
}
