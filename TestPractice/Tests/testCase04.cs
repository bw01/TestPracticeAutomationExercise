using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestPractice.Configuration;
using TestPractice.Locations;

namespace TestPractice.Tests
{
    public class testCase04
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
        // 5. Verify 'Login to your account' is visible
        // 6. Enter correct email address and password
        // 7. Click 'login' button
        // 8. Verify that 'Logged in as username' is visible
        // 9. Click 'Logout' button
        // 10. Verify that user is navigated to login page


        [Test]
        public void testCase4Execution()
        {
            driver.Navigate().GoToUrl(globalTestVariables.environmentURL);
            Assert.That(driver.Title.Contains("Automation Exercise"),Is.True);

            homePage.clickConsentButton();
            homePage.CheckIfhomePageIsVisible();
            homePage.ClickSignupLoginButton();

            Assert.That(driver.PageSource.Contains("Login to your account"));

            signupLoginPage.loginExistingUser();

            Assert.That(driver.PageSource.Contains("Logged in as"));

            homePage.ClickLogoutButton();

            Assert.That(driver.Url, Is.EqualTo("https://automationexercise.com/login"));
            Console.WriteLine("https://automationexercise.com/login - is visible");
        }
    }
}
