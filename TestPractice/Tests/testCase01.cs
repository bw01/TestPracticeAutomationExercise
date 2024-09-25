using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using TestPractice.Locations;
using TestPractice.Configuration;

namespace TestPractice.Tests
{
    public class testCase01

    {
        IWebDriver driver;
        WebDriverWait wait;
        private globalTestVariables globalTestVariables;
        private homePage homePage;
        private signupLoginPage signupLoginPage;
        private signupAccountInformation signupAccountInformation;
        private contactUsPage contactUsPage;

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
        // 4. Click on 'Signup / Login' button
        // 5. Verify 'New User Signup!' is visible
        // 6. Enter name and email address
        // 7. Click 'Signup' button
        // 8. Verify that 'ENTER ACCOUNT INFORMATION' is visible
        // 9. Fill details: Title, Name, Email, Password, Date of birth
        // 10. Select checkbox 'Sign up for our newsletter!'
        // 11. Select checkbox 'Receive special offers from our partners!'
        // 12. Fill details: First name, Last name, Company, Address, Address2, Country, State, City, Zipcode, Mobile Number
        // 13. Click 'Create Account' button
        // 14. Verify that 'ACCOUNT CREATED!' is visible
        // 15. Click 'Continue' button
        // 16. Verify that 'Logged in as username' is visible
        // 17. Click 'Delete Account' button
        // 18. Verify that 'ACCOUNT DELETED!' is visible and click 'Continue' button


        [Test]
        public void testCase1Execution()
        {
            driver.Navigate().GoToUrl(globalTestVariables.environmentURL);
            Assert.That(driver.Title.Contains("Automation Exercise"), Is.True);

            homePage.clickConsentButton();
            homePage.CheckIfhomePageIsVisible();
            homePage.ClickSignupLoginButton();

            signupLoginPage.fillSignUp();
            signupAccountInformation.registerAccount();

            homePage.ClickContinueButton();
            homePage.CheckIfLoggedinAsAnUserTextIsVisible();
            homePage.CheckIfDeleteAccountButtonIsVisible();
            homePage.ClickDeleteAccountButton();
            homePage.CheckIfAccountDeletedTextIsVisible();
            homePage.ClickContinueButton();
        }

    }
}
