using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestPractice.Configuration;
using TestPractice.Locations;

namespace TestPractice.Tests
{
    public class testCase14
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
        // 4. Add products to cart
        // 5. Click 'Cart' button
        // 6. Verify that cart page is displayed
        // 7. Click Proceed To Checkout
        // 8. Click 'Register / Login' button
        // 9. Fill all details in Signup and create account
        // 10. Verify 'ACCOUNT CREATED!' and click 'Continue' button
        // 11. Verify 'Logged in as username' at top
        // 12. Click 'Cart' button
        // 13. Click 'Proceed To Checkout' button
        // 14. Verify Address Details and Review Your Order
        // 15. Enter description in comment text area and click 'Place Order'
        // 16. Enter payment details: Name on Card, Card Number, CVC, Expiration date
        // 17. Click 'Pay and Confirm Order' button
        // 18. Verify success message 'Congratulations! Your order has been confirmed!'
        // 19. Click 'Delete Account' button
        // 20. Verify 'ACCOUNT DELETED!' and click 'Continue' button


        [Test]
        public void testCase14Execution()
        {
            driver.Navigate().GoToUrl(globalTestVariables.environmentURL);
            Assert.That(driver.Title.Contains("Automation Exercise"), Is.True);

            homePage.clickConsentButton();
            homePage.CheckIfhomePageIsVisible();
            allProductsPage.ClickOnFirstProduct();
            productDetailPage.clickAddToCartButton();
            cartPage.ClickViewCartButton();
            cartPage.ClickProceedToCheckoutButton();
            cartPage.ClickRegisterLoginButtonButton();

            signupLoginPage.fillSignUp();
            signupAccountInformation.registerAccount();

            homePage.ClickContinueButton();
            homePage.CheckIfLoggedinAsAnUserTextIsVisible();
            homePage.ClickCartButton();
            cartPage.ClickProceedToCheckoutButton();
            checkoutPage.VerifyDeliveryAddressDetails();
            checkoutPage.VerifyBillingAddressDetails();
            checkoutPage.VerifyOrder();
            checkoutPage.AddOrderComment();
            checkoutPage.ClickPlaceOrderButtonButton();
            
            paymentPage.fillCreditCardDetails();
            paymentPage.clickContinueButton();

            homePage.ClickDeleteAccountButton();
            homePage.CheckIfAccountDeletedTextIsVisible();
            homePage.ClickContinueButton();

        }
    }
}
