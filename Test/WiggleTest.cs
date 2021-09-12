using NUnit.Framework;

namespace FinalAutomationProject.Test
{
    class WiggleTest : BaseTest
    {
        [Test]
        public static void SearchItemsByGender()
        {
            _wiggleHomePage.NavigateToPage();
            _wiggleHomePage.AcceptCookies();
            _wiggleSearchResultPage.SearchFieldInput();
            _wiggleSearchResultPage.SelectGender();
            _wiggleSearchResultPage.SelectByBoys();
            _wiggleSearchResultPage.VerifyGenderResult();
        }
        [TestCase("Saris trainer", TestName = "Select bulky item, verify message")]
        public static void BulkyItemMessageCheck(string text)
        {
            _wiggleHomePage.NavigateToPage();
            _wiggleHomePage.AcceptCookies();
            _wiggleHomePage.SearchField(text);
            _wiggleSearchResultPage.SportTrainerSelect();
            _wiggleSearchResultPage.VerifyBulkyItemsResult();
        }
        [TestCase("Goggles", "200", TestName = "Select item, enter 200, verify item quantity")]
        public static void ItemQuantityVerification(string text, string number)
        {
            _wiggleHomePage.NavigateToPage();
            _wiggleHomePage.AcceptCookies();
            _wiggleHomePage.SearchField(text);
            _wiggleSearchResultPage.ItemSelect();
            _wiggleSearchResultPage.EnterQuantity(number);
            _wiggleSearchResultPage.VerifyItemQuantityResult();
        }
        [Test]
        public static void CompareMoreThan4ItemsAlertMessage()
        {
            _wiggleHomePage.NavigateToPage();
            _wiggleHomePage.AcceptCookies();
            _wiggleSearchResultPage.NewItems();
            _wiggleSearchResultPage.SelectRandomCheckBoxes();
            _wiggleSearchResultPage.VerifyFourItemsCanBeComparedMessage();
        }
        [TestCase("Polar watch", "Belgium", TestName = "Selected Suunto watch is available for free shipping")]
        public static void ShippingIsFree(string brand, string destination)
        {
            _wiggleHomePage.NavigateToPage();
            _wiggleHomePage.AcceptCookies();
            _wiggleHomePage.SearchField(brand);
            _wiggleSearchResultPage.HightToLowPress();
            _wiggleSearchResultPage.SelectHighToLow();
            _wiggleSearchResultPage.SelectSportWatch();
            _wiggleSearchResultPage.AddToCartByColor();
            _wiggleSearchResultPage.ViewFullBasket();
            _wiggleCartPage.SelectFromDropDownText(destination);
            _wiggleCartPage.VerifyFreeShipping();
        }

        [TestCase("Muc-Off lube", "Latvia", TestName = "Item not valid for free shipping, message is displayed")]
        public static void NotFreeShipping(string text, string destination)
        {
            _wiggleHomePage.NavigateToPage();
            _wiggleHomePage.AcceptCookies();
            _wiggleHomePage.SearchField(text);
            _wiggleSearchResultPage.StockFilterSelect();
            _wiggleSearchResultPage.SortFilterSelect();
            _wiggleSearchResultPage.SelectItemByIndex();
            _wiggleSearchResultPage.MultiplyQuantityByTwo();
            _wiggleSearchResultPage.AddToCart();
            _wiggleSearchResultPage.ViewFullBasket();
            _wiggleCartPage.SelectFromDropDownText(destination);
            _wiggleCartPage.VerifyAmountForFreeShipping("€48.68");

        }
        [TestCase("Insurance", "2500", "Road Bike", "Vitus", "Vitesse", "2021", "16.37", TestName = "Bike value 2500 pounds, Road Bike, Model Vitus - Vitesse, Monthly payment £ 16,37.")]
        public static void InsuranceCalculator(string text, string price, string type, string make, string model, string year, string payment)
        {
            _wiggleHomePage.NavigateToPage();
            _wiggleHomePage.AcceptCookies();
            _wiggleHomePage.SearchField(text);
            _wiggleInsuranceHomePage.SecondCookieAccept();
            _wiggleInsuranceHomePage.InscuranceButtonClick();
            _wiggleInsuranceHomePage.EssentialButtonClick();
            _wiggleInsuranceCalculatorPage.AmmountForBike(price);
            _wiggleInsuranceCalculatorPage.BikeTypeList(type);
            _wiggleInsuranceCalculatorPage.BikeBrandList(make);
            _wiggleInsuranceCalculatorPage.BikeModel(model);
            _wiggleInsuranceCalculatorPage.BikeYearList(year);
            _wiggleInsuranceCalculatorPage.ReceiptLaterCheckBox();
            _wiggleInsuranceCalculatorPage.CalculateMyQuate();
            _wiggleInsuranceCalculatorPage.VerifyMonthlyPayment(payment);
        }
    }
}

