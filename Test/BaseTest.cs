using FinalAutomationProject.Drivers;
using FinalAutomationProject.Page;
using FinalAutomationProject.Tools;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;

namespace FinalAutomationProject.Test
{
    class BaseTest
    {
        public static IWebDriver driver;
        public static WiggleHomePage _wiggleHomePage;
        public static WiggleCartPage _wiggleCartPage;
        public static WiggleInsuranceCalculatorPage _wiggleInsuranceCalculatorPage;
        public static WiggleSearchResultPage _wiggleSearchResultPage;
        public static WiggleInsuranceHomePage _wiggleInsuranceHomePage;


        [OneTimeSetUp]
        public static void OneTimeSetUp()
        {
            driver = CustomDrivers.GetChromeDriver();

            _wiggleHomePage = new WiggleHomePage(driver);
            _wiggleCartPage = new WiggleCartPage(driver);
            _wiggleInsuranceHomePage = new WiggleInsuranceHomePage(driver);
            _wiggleInsuranceCalculatorPage = new WiggleInsuranceCalculatorPage(driver);
            _wiggleSearchResultPage = new WiggleSearchResultPage(driver);
        }
        [TearDown]
        public static void TakeScreenShot()
        {
            if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
                MyScreenshot.MakeScreenShot(driver);
        }
        [OneTimeTearDown]
        public static void OneTimeTearDown()
        {
            driver.Quit();
        }
    }
}

