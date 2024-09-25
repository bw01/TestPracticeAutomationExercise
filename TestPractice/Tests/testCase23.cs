using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestPractice.Configuration;
using TestPractice.Locations;

namespace TestPractice.Tests
{
    public class testCase23
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
        // 5. Fill all details in Signup and create account
        // 6. Verify 'ACCOUNT CREATED!' and click 'Continue' button
        // 7. Verify 'Logged in as username' at top
        // 8. Add products to cart
        // 9. Click 'Cart' button
        // 10. Verify that cart page is displayed
        // 11. Click Proceed To Checkout
        // 12. Verify that the delivery address and the billing address is same address filled at the time registration of account
        // 13. Click 'Delete Account' button
        // 14. Verify 'ACCOUNT DELETED!' and click 'Continue' button


        [Test]
        public void testCase23Execution()
        {
            driver.Navigate().GoToUrl(globalTestVariables.environmentURL);
            Assert.That(driver.Title.Contains("Automation Exercise"), Is.True);

            homePage.clickConsentButton();
            homePage.CheckIfhomePageIsVisible();

            homePage.clickConsentButton();
            homePage.CheckIfhomePageIsVisible();
            homePage.ClickSignupLoginButton();

            signupLoginPage.fillSignUp();
            signupAccountInformation.registerAccount();

            homePage.ClickContinueButton();
            homePage.CheckIfLoggedinAsAnUserTextIsVisible();

            allProductsPage.SelectProductAndAddToCart("1");
            allProductsPage.ClickViewCartButton();
            Assert.That(driver.Url, Is.EqualTo("https://automationexercise.com/view_cart")); 

            cartPage.ClickProceedToCheckoutButton();
            checkoutPage.VerifyDeliveryAddressDetails();
            checkoutPage.VerifyBillingAddressDetails();

            homePage.ClickDeleteAccountButton();
            homePage.CheckIfAccountDeletedTextIsVisible();
        }
    }
}
