using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestPractice.Configuration;
using TestPractice.Locations;

namespace TestPractice.Tests
{
    public  class testCase13
    {
        IWebDriver driver;
        WebDriverWait wait;
        private globalTestVariables globalTestVariables;
        private homePage homePage;
        private signupLoginPage signupLoginPage;
        private signupAccountInformation signupAccountInformation;
        private contactUsPage contactUsPage;
        private allProductsPage allProductsPage;
        private productDetailPage productDetailPage;
        private cartPage cartPage;

        [SetUp]
        public void Setup()
        {
            string projectPath = AppDomain.CurrentDomain.BaseDirectory;
           //Was needed when the website displayed ads string extensionPath = Path.Combine(projectPath, "AdBlock", "uBlock Origin 1.58.0.0.crx");
            ChromeOptions chromeOptions = new ChromeOptions();
            //Was needed when the website displayed ads chromeOptions.AddExtension(extensionPath);
            chromeOptions.AddArgument("--disable-search-engine-choice-screen");


            driver = new ChromeDriver(chromeOptions);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            globalTestVariables = new globalTestVariables();
            homePage = new homePage(driver);
            signupLoginPage = new signupLoginPage(driver);
            signupAccountInformation = new signupAccountInformation(driver);
            contactUsPage = new contactUsPage(driver);
            allProductsPage = new allProductsPage(driver);
            productDetailPage = new productDetailPage(driver);
            cartPage = new cartPage(driver);
        }

        [TearDown]
        public void TearDown()
        {
            driver.Dispose();
            driver.Quit();
        }

        // Steps
        // 1. Launch browser
        // 2. Navigate to url 'http://automationexercise.com'
        // 3. Verify that home page is visible successfully
        // 4. Click 'View Product' for any product on home page
        // 5. Verify product detail is opened
        // 6. Increase quantity to 4
        // 7. Click 'Add to cart' button
        // 8. Click 'View Cart' button
        // 9. Verify that product is displayed in cart page with exact quantity


        [Test]
        public void testCase13Execution()
        {
            driver.Navigate().GoToUrl(globalTestVariables.environmentURL);
            Assert.That(driver.Title.Contains("Automation Exercise"), Is.True);

            homePage.clickConsentButton();
            homePage.ClickProductsButton();
            allProductsPage.ClickOnFirstProduct();
            productDetailPage.increaseQuatityto4();
            productDetailPage.clickAddToCartButton();
            productDetailPage.clickViewCartButton();
            cartPage.GetProductQuantity();
           
        }
    }
}
