using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FinalAutomationProject.Page
{
    class WiggleSearchResultPage : BasePage
    {
        IReadOnlyCollection<IWebElement> searchResults => Driver.FindElements(By.CssSelector(".bem-product-thumb--grid"));
        public IWebElement addToBasket => Driver.FindElement(By.Id("quickBuyButton"));
        public IWebElement headerElement => Driver.FindElement(By.CssSelector("body > div.wiggle-dialog.bem-dialogue > div > div > div > div.bem-add-to-basket-popup-body > div.bem-add-to-basket-warning.hidden-xs > div > div > div > h2"));
        public IWebElement messageElement => Driver.FindElement(By.CssSelector("body > div.wiggle-dialog.bem-dialogue > div > div > div > div.bem-add-to-basket-popup-body > div.bem-add-to-basket-warning.hidden-xs > div > div > div > p"));
        public IWebElement newItemButton => Driver.FindElement(By.CssSelector("body > div.bem-navigation-menu > div > div > ul > li:nth-child(1) > a"));
        public IWebElement verifyAlertMessage => Driver.FindElement(By.Id("compare-confirm"));
        public IWebElement searchWindow => Driver.FindElement(By.Id("rs"));
        public IWebElement searchButton => Driver.FindElement(By.CssSelector("#search > div > button > i"));
        public IWebElement genderSelectButton => Driver.FindElement(By.CssSelector("#hr-search-guided-navigation > div.plp-refinements__holder.plp-refinements__section--gender.js-plp-refinements-holder-active > button"));
        public IWebElement boysSelect => Driver.FindElement(By.CssSelector("#content-Gender > ul > li:nth-child(1) > a"));
        public IWebElement resultsByGender => Driver.FindElement(By.CssSelector("#search-results > div:nth-child(1) > div > a.bem-product-thumb__name--grid"));
        IReadOnlyCollection<IWebElement> searchResult => Driver.FindElements(By.CssSelector(".bem-product-thumb--grid"));
        public IWebElement quantityImput => Driver.FindElement(By.CssSelector("#quickBuyBox > form > div.bem-sku-selector__basket-controls > div:nth-child(1) > div.col-xs-12.col-md-5 > div > text > input"));
        public IWebElement messageElements => Driver.FindElement(By.XPath("//div[@id='quickBuyBox']/form/div[3]/div[5]/span/span"));
        IReadOnlyCollection<IWebElement> results => Driver.FindElements(By.CssSelector(".bem-product-thumb--grid"));
        public IWebElement viewBasketLink => Driver.FindElement(By.Id("view-basket"));
        public IWebElement quantityButton => Driver.FindElement(By.CssSelector("#quickBuyBox > form > div.bem-sku-selector__basket-controls > div:nth-child(1) > div.col-xs-12.col-md-5 > div > button.bem-sku-selector__quantity-btn.js-qty-plus-control"));
        public IWebElement itemAddToBasketButton => Driver.FindElement(By.CssSelector("#quickBuyButton"));
        public IWebElement stockButton => Driver.FindElement(By.CssSelector("#hr-property-filters > button"));
        public IWebElement inStockNowCheckBox => Driver.FindElement(By.CssSelector("#hr-property-filters > div > ul > li > a > span > label"));
        public IWebElement sortButton => Driver.FindElement(By.CssSelector("#hr-sort > button"));
        public IWebElement lowToHighButton => Driver.FindElement(By.CssSelector("#hr-sort > div > ul > li:nth-child(2) > a > span > div > label"));
        IReadOnlyCollection<IWebElement> sportWatchResults => Driver.FindElements(By.CssSelector(".bem-product-thumb--grid"));
        IReadOnlyCollection<IWebElement> colorSelectList => Driver.FindElements(By.CssSelector("#quickBuyBox > form > div.bem-sku-selector > div.bem-sku-selector__option.sku-items-parent.qa-colour-select"));
        public IWebElement colorSelectButton => Driver.FindElement(By.CssSelector("#quickBuyBox > form > div.bem-sku-selector > div.bem-sku-selector__option.sku-items-parent.qa-colour-select > a"));
        public IWebElement highToLowButton => Driver.FindElement(By.CssSelector("#hr-sort > button"));
        public IWebElement highToLowSelect => Driver.FindElement(By.CssSelector("#hr-sort > div > ul > li:nth-child(3) > a > span > div"));
        public IWebElement ToBasketButton => Driver.FindElement(By.CssSelector("#quickBuyButton"));
        public WiggleSearchResultPage(IWebDriver webdriver) : base(webdriver) { }
        public void NewItems()
        {
            newItemButton.Click();
        }
        public void SportTrainerSelect()
        {
            IWebElement firstResultElement = searchResults.ElementAt(1);
            firstResultElement.Click();
            addToBasket.Click();
        }
        public void SelectRandomCheckBoxes()
        {
            Actions actions = new Actions(Driver);
            actions.SendKeys(Keys.PageDown);
            actions.SendKeys(Keys.PageDown);
            actions.Build().Perform();

            for (int i = 0; i < 5; i++)
            {
                List<IWebElement> elements = new List<IWebElement>(Driver.FindElements(By.ClassName("bem-compare-product__checkbox")));
                Random random = new Random();
                int num = random.Next(0, elements.Count);

                if (!elements[num].Selected)
                    elements[num].Click();
            }
            GetWait().Until(ExpectedConditions.ElementExists(By.CssSelector("#compare-confirm > p:nth-child(2)")));
        }
        public void SearchFieldInput()
        {
            searchWindow.SendKeys("Giro");
            searchButton.Click();
        }
        public void SelectGender()
        {
            genderSelectButton.Click();
        }
        public void SelectByBoys()
        {
            boysSelect.Click();
        }
        public void ItemSelect()
        {
            IWebElement firstResultElement = searchResult.ElementAt(1);
            firstResultElement.Click();
        }
        public void EnterQuantity(string number)
        {
            quantityImput.Clear();
            quantityImput.SendKeys(number);
        }
        public void StockFilterSelect()
        {
            stockButton.Click();
            inStockNowCheckBox.Click();
        }
        public void SortFilterSelect()
        {
            sortButton.Click();
            //GetWait().Until(ExpectedConditions.ElementIsVisible(By.CssSelector("#hr-sort > button"))); //Čia tik dėl Error: Stale element
            lowToHighButton.Click();
        }
        public void SelectItemByIndex()
        {
            IWebElement firstResultElement = results.ElementAt(1);
            firstResultElement.Click();

        }
        public void MultiplyQuantityByTwo()
        {
            quantityButton.Click();
        }
        public void AddToCart()
        {
            itemAddToBasketButton.Click();
        }
        public void ViewFullBasket()
        {
            viewBasketLink.Click();
        }
        public void HightToLowPress()
        {
            highToLowButton.Click();
        }

        public void SelectHighToLow()
        {
            highToLowSelect.Click();
        }

        public void SelectSportWatch()
        {
            IWebElement firstResultElement = sportWatchResults.ElementAt(0);
            firstResultElement.Click();
        }
        public void AddToCartByColor()
        {
            colorSelectButton.Click();
            IWebElement firstResultElement = colorSelectList.ElementAt(0);
            firstResultElement.Click();
            ToBasketButton.Click();
        }
        public void VerifyFourItemsCanBeComparedMessage()
        {
            Assert.IsTrue(verifyAlertMessage.Text.Contains("Only 4 products can be compared at once"), "Only 4 items can be compared.");
        }
        public void VerifyBulkyItemsResult()
        {
            Assert.AreEqual("Bulky Items", headerElement.Text, "Not Bulky Items");
            Assert.AreEqual("Your basket contains a bulky item. Shipping fees may apply, and shipping service may vary from standard.", messageElement.Text, "Message didn`t show up");
        }
        public void VerifyGenderResult()
        {
            GetWait().Until(ExpectedConditions.ElementExists(By.CssSelector("#breadcrumbs > li:nth-child(2) > a")));
            Assert.IsTrue(resultsByGender.Text.Contains("Kids"),
            $"Result is wrong, was {resultsByGender.Text}, but expected to contain 'Kids'");
        }
        public void VerifyItemQuantityResult()
        {
            Assert.AreEqual("Only 100 in stock. We don't have enough stock to complete your order", messageElements.Text, "Only 100 in stock");
        }
    }
}
