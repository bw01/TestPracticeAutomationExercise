using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestPractice.Configuration;
using TestPractice.Locations;

namespace TestPractice.Tests
{
    public class testCase08
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
        // 4. Click on 'Products' button
        // 5. Verify user is navigated to ALL PRODUCTS page successfully
        // 6. The products list is visible
        // 7. Click on 'View Product' of first product
        // 8. User is landed to product detail page
        // 9. Verify that detail detail is visible: product name, category, price, availability, condition, brand


        [Test]
        public void testCase8Execution()
        {
            driver.Navigate().GoToUrl(globalTestVariables.environmentURL);
            Assert.That(driver.Title.Contains("Automation Exercise"), Is.True);

            homePage.clickConsentButton();
            homePage.clickProductsButton();
            allProductsPage.ClickOnFirstProduct();
            productDetailPage.VerifyIfProductElementsAreDisplayed();

        }
    }
}
