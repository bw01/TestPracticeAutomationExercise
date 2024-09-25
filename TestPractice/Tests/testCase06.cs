using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestPractice.Configuration;
using TestPractice.Locations;

namespace TestPractice.Tests
{
    public class testCase06
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
        // 4. Click on 'Contact Us' button
        // 5. Verify 'GET IN TOUCH' is visible
        // 6. Enter name, email, subject and message
        // 7. Upload file
        // 8. Click 'Submit' button
        // 9. Click OK button
        // 10. Verify success message 'Success! Your details have been submitted successfully.' is visible
        // 11. Click 'Home' button and verify that landed to home page successfully


        [Test]
        public void testCase6Execution()
        {
            string projectPath = AppDomain.CurrentDomain.BaseDirectory; // Gets the base directory of the project
            string filePath = Path.Combine(projectPath, "FilesFortestCases", "1.txt");

            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException($"The {filePath} was not found.");
            }
            else
            {
                Console.WriteLine($"The {filePath} was found.");
            }

            driver.Navigate().GoToUrl(globalTestVariables.environmentURL);
            Assert.That(driver.Title.Contains("Automation Exercise"), Is.True);


            homePage.clickConsentButton();
            homePage.clickContactUsButton();
            contactUsPage.isGetInTouchVisible();
            contactUsPage.fillForm("John Doe", "john.doe@example.com", "Subject", "This is a message.");
            contactUsPage.uploadFile(filePath);
            contactUsPage.clickSubmitButton();
            contactUsPage.acceptAlert();
            contactUsPage.isSuccessMessageVisible();
            contactUsPage.clickHomeButton();


            Assert.That(driver.Title.Contains("Automation Exercise"), Is.True);
        }
    }
}
