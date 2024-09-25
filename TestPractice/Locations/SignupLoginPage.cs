using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using TestPractice.Configuration;

namespace TestPractice.Locations
{
    public class signupLoginPage
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        // Constructor to initialize the driver
        public signupLoginPage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));

        }

        // Page elements
        private IWebElement SignupNameField => driver.FindElement(By.XPath("//input[@name='name']"));
        private IWebElement SignupEmailField => driver.FindElement(By.XPath("//*[@id=\"form\"]/div/div/div[3]/div/form/input[3]"));
        private IWebElement LoginEmailField => driver.FindElement(By.XPath("//*[@id=\"form\"]/div/div/div[1]/div/form/input[2]"));
        private IWebElement LoginPasswordField => driver.FindElement(By.XPath("//*[@id=\"form\"]/div/div/div[1]/div/form/input[3]"));

        private IWebElement SignupButton => driver.FindElement(By.XPath("(//button[@type='submit'])[2]"));
        private IWebElement loginButton => driver.FindElement(By.XPath("//*[@id=\"form\"]/div/div/div[1]/div/form/button"));

        private IWebElement newUserSignUpText => driver.FindElement(By.XPath("//h2[contains(.,'New User Signup!')]"));

        private IWebElement incorrectEmailOrPassword => driver.FindElement(By.XPath("//*[contains(text(), 'Your email or password is incorrect!')]"));

        // Page methods

        //check New Sign Up Text
        public void CheckNewSignUpUserText()
        {
            try
            {
                Assert.That(newUserSignUpText.Displayed, Is.True, "newUserSignUpText is not displayed as expected.");
                Console.WriteLine("newUserSignUpText is visible.");
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("The newUserSignUpText element was not found.");
            }
            catch (WebDriverTimeoutException)
            {
                Console.WriteLine("newUserSignUpText timed out.");
            }
        }

        //check Your email or password is incorrect!
        public void CheckIncorrectEmailOrPassword()
        {
            try
            {
                Assert.That(incorrectEmailOrPassword.Displayed, Is.True, "incorrectEmailOrPassword is not displayed as expected.");
                Console.WriteLine("incorrectEmailOrPassword is visible.");
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("The incorrectEmailOrPassword element was not found.");
            }
            catch (WebDriverTimeoutException)
            {
                Console.WriteLine("newUserSignUpText timed out.");
            }
        }


        //Signup Name - Field and input
        public void ClickSignupNameField()
        {
            Assert.That(SignupNameField.Displayed, Is.True, "SignupNameField is not displayed.");
            wait.Until(ExpectedConditions.ElementToBeClickable(SignupNameField));
            SignupNameField.Click();
        }

        public void FillSignupNameField()
        {
            Assert.That(SignupNameField.Displayed, Is.True, "SignupNameField is not displayed.");
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//input[@name='name']")));
            SignupNameField.SendKeys("Test Test");
        }

        //Signup Email - Field and input

        public void ClickEmailField()
        {
            Assert.That(SignupEmailField.Displayed, Is.True, "SignupEmailField is not displayed.");
            wait.Until(ExpectedConditions.ElementToBeClickable(SignupEmailField));
            SignupEmailField.Click();
        }

        public void FillSignupEmailField()
        {
            globalTestVariables globalTestVariables = new globalTestVariables();
            Assert.That(SignupEmailField.Displayed, Is.True, "SignupEmailField is not displayed.");
            SignupEmailField.SendKeys(globalTestVariables.registrationUserEmail);
        }
        public void FillExistingSignupEmailField()
        {
            globalTestVariables globalTestVariables = new globalTestVariables();
            Assert.That(SignupEmailField.Displayed, Is.True, "SignupEmailField is not displayed.");
            SignupEmailField.SendKeys(globalTestVariables.loginUserEmail);
        }

        public void FillLoginEmailField_IncorrectInfo()
        {
            globalTestVariables globalTestVariables = new globalTestVariables();
            Assert.That(LoginEmailField.Displayed, Is.True, "LoginEmailField is not displayed.");
            LoginEmailField.SendKeys("xxxxx@email.com");
        }

        public void ClickLoginEmailField()
        {
            Assert.That(LoginEmailField.Displayed, Is.True, "LoginEmailField is not displayed.");
            wait.Until(ExpectedConditions.ElementToBeClickable(LoginEmailField));
            LoginEmailField.Click();
        }

        public void ClickLoginPasswordField()
        {
            Assert.That(LoginPasswordField.Displayed, Is.True, "LoginPasswordField is not displayed.");
            wait.Until(ExpectedConditions.ElementToBeClickable(LoginPasswordField));
            LoginPasswordField.Click();
        }

        public void FillLoginPasswordField_IncorrectInfo()
        {
            Assert.That(LoginPasswordField.Displayed, Is.True, "LoginPasswordField is not displayed.");
            LoginPasswordField.SendKeys("asdsad");
        }

        public void FillLoginField()
        {
            globalTestVariables globalTestVariables = new globalTestVariables();
            Assert.That(LoginEmailField.Displayed, Is.True, "LoginEmailField is not displayed.");
            wait.Until(ExpectedConditions.ElementToBeClickable(LoginEmailField));
            LoginEmailField.Click();
            LoginEmailField.SendKeys(globalTestVariables.loginUserEmail);
        }

        public void FillPasswordField()
        {
            globalTestVariables globalTestVariables = new globalTestVariables();
            Assert.That(LoginEmailField.Displayed, Is.True, "LoginEmailField is not displayed.");
            wait.Until(ExpectedConditions.ElementToBeClickable(LoginPasswordField));
            LoginPasswordField.Click();
            LoginPasswordField.SendKeys(globalTestVariables.loginUserPassword);
        }



        //Buttons
        public void SignupButtonClick()
        {
            Assert.That(SignupButton.Displayed, Is.True, "SignupButton is not displayed.");
            wait.Until(ExpectedConditions.ElementToBeClickable(SignupButton));
            SignupButton.Click();
        }

        public void loginButtonClick()
        {
            Assert.That(loginButton.Displayed, Is.True, "loginButton is not displayed.");
            wait.Until(ExpectedConditions.ElementToBeClickable(loginButton));
            loginButton.Click();

        }

        //Register Process
        public void fillSignUp()
        {
            CheckNewSignUpUserText();
            FillSignupNameField();
            FillSignupEmailField();
            SignupButtonClick();
        }

        // Login as a User
        public void loginExistingUser()
        {
            ClickLoginEmailField();
            FillLoginField();
            FillPasswordField();
            loginButtonClick();
        }

        // Login as a user with existing mail
        public void loginAsAUserWithExistingMail()
        {
            ClickSignupNameField();
            FillSignupNameField();
            ClickEmailField();
            FillExistingSignupEmailField();
            SignupButtonClick();
        }

        // Login as a user with incorrect info
        public void loginIncorrectInfoUser()
        {
            ClickLoginEmailField();
            FillLoginEmailField_IncorrectInfo();
            ClickLoginPasswordField();
            FillLoginPasswordField_IncorrectInfo();
            loginButtonClick();
            CheckIncorrectEmailOrPassword();
        }

    }
}
