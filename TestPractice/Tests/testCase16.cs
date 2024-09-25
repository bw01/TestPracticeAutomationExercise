using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestPractice.Configuration;
using TestPractice.Locations;

namespace TestPractice.Tests
{
    public class testCase16
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
        // 3. Verify that home page is visible successfully
        // 4. Click 'Signup / Login' button
        // 5. Fill email, password and click 'Login' button
        // 6. Verify 'Logged in as username' at top
        // 7. Add products to cart
        // 8. Click 'Cart' button
        // 9. Verify that cart page is displayed
        // 10. Click Proceed To Checkout
        // 11. Verify Address Details and Review Your Order
        // 12. Enter description in comment text area and click 'Place Order'
        // 13. Enter payment details: Name on Card, Card Number, CVC, Expiration date
        // 14. Click 'Pay and Confirm Order' button
        // 15. Verify success message 'Congratulations! Your order has been confirmed!'


        [Test]
        public void testCase16Execution()
        {
            driver.Navigate().GoToUrl(globalTestVariables.environmentURL);
            Assert.That(driver.Title.Contains("Automation Exercise"), Is.True);

            homePage.clickConsentButton();
            homePage.CheckIfhomePageIsVisible();
            homePage.ClickSignupLoginButton();

            signupLoginPage.loginExistingUser();

            homePage.ClickContinueButton();
            homePage.CheckIfLoggedinAsAnUserTextIsVisible();
            allProductsPage.ClickOnFirstProduct();
            productDetailPage.clickAddToCartButton();
            cartPage.ClickViewCartButton();
            cartPage.ClickProceedToCheckoutButton();
            checkoutPage.VerifyLoggedInUserBillingAddressDetails();
            checkoutPage.VerifyOrder();
            checkoutPage.AddOrderComment();
            checkoutPage.ClickPlaceOrderButtonButton();

            paymentPage.fillCreditCardDetails();
        }
    }
}
