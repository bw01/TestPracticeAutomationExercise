using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestPractice.Configuration;
using TestPractice.Locations;

namespace TestPractice.Tests
{
    public class testCase22
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
        private checkoutPage checkoutPage;
        private paymentPage paymentPage;

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
            checkoutPage = new checkoutPage(driver);
            paymentPage = new paymentPage(driver);
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
        // 3. Scroll to bottom of page
        // 4. Verify 'RECOMMENDED ITEMS' are visible
        // 5. Click on 'Add To Cart' on Recommended product
        // 6. Click on 'View Cart' button
        // 7. Verify that product is displayed in cart page


        [Test]
        public void testCase22Execution()
        {
            driver.Navigate().GoToUrl(globalTestVariables.environmentURL);
            Assert.That(driver.Title.Contains("Automation Exercise"), Is.True);

            homePage.clickConsentButton();
            homePage.CheckIfhomePageIsVisible();

            homePage.scrollToRecommendedItemsSection();
            allProductsPage.SelectProductAndAddToCart("1");
            allProductsPage.ClickViewCartButton();
            Assert.That(driver.FindElement(By.XPath("//*[@id=\"product-1\"]")).Displayed, "No products are present.");
            Console.WriteLine("Added product is present in the Cart.");
        }
    }
}
