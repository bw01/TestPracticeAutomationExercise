using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestPractice.Configuration;
using TestPractice.Locations;

namespace TestPractice.Tests
{
    public class testCase20
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
        // 3. Click on 'Products' button
        // 4. Verify user is navigated to ALL PRODUCTS page successfully
        // 5. Enter product name in search input and click search button
        // 6. Verify 'SEARCHED PRODUCTS' is visible
        // 7. Verify all the products related to search are visible
        // 8. Add those products to cart
        // 9. Click 'Cart' button and verify that products are visible in cart
        // 10. Click 'Signup / Login' button and submit login details
        // 11. Again, go to Cart page
        // 12. Verify that those products are visible in cart after login as well
        // 13. Remove all products that have been added
        // 14. Verify 'Cart is empty! Click here to buy products.' is visible


        [Test]
        public void testCase20Execution()
        {
            driver.Navigate().GoToUrl(globalTestVariables.environmentURL);
            Assert.That(driver.Title.Contains("Automation Exercise"), Is.True);

            homePage.clickConsentButton();
            homePage.CheckIfhomePageIsVisible();
            homePage.clickProductsButton();
            allProductsPage.SearchForAProduct();
            allProductsPage.AreAllRelatedProductsVisible();
            allProductsPage.ClickAllAddToCartButtons();
            homePage.ClickCartButton();
            Assert.That(driver.FindElement(By.CssSelector(".cart_description")).Displayed, "Products not visible in cart");
            homePage.ClickSignupLoginButton();
            homePage.ClickSignupLoginButton();

            signupLoginPage.loginExistingUser();

            homePage.CheckIfLoggedinAsAnUserTextIsVisible();
            homePage.ClickCartButton();
            Assert.That(driver.FindElement(By.CssSelector(".cart_description")).Displayed, "Products not visible in cart");
            cartPage.ClickDeleteQuantityButton();
        }
    }
}
