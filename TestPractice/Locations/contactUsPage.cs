using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace TestPractice.Locations
{
    public class contactUsPage
    {
        private IWebDriver driver;
        private WebDriverWait wait;


        // Constructor to initialize the driver
        public contactUsPage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
        }

            // Page elements
        private IWebElement contactName => driver.FindElement(By.Name("name"));  
        private IWebElement contactEmail => driver.FindElement(By.Name("email"));
        private IWebElement contactSubject => driver.FindElement(By.Name("subject"));
        private IWebElement contactMessage => driver.FindElement(By.Name("message"));
        private IWebElement contactUploadFile => driver.FindElement(By.Name("upload_file"));
        private IWebElement contactGetInTouch => driver.FindElement(By.XPath("//*[@id='contact-page']/div[2]/div[1]/div/h2"));
        private IWebElement contactHomeButton => driver.FindElement(By.XPath("//*[@id=\"form-section\"]/a"));
        private IWebElement contactSubmitButton => driver.FindElement(By.XPath("//*[@id=\"contact-us-form\"]/div[6]/input"));

        private IWebElement successMessageElement => driver.FindElement(By.CssSelector(".alert-success"));



        // Page methods
        public void isGetInTouchVisible()
        {
            try
            {
                Assert.That(contactGetInTouch.Displayed, Is.True, "contactGetInTouch is not displayed as expected.");
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("The contactGetInTouch element was not found.");
            }
            catch (WebDriverTimeoutException)
            {
                Console.WriteLine("contactGetInTouch timed out.");
            }
        }


        public void fillForm(string name, string email, string subject, string message)
        {
            var nameInput = contactName;
            var emailInput = contactEmail;
            var subjectInput = contactSubject;
            var messageInput = contactMessage;

            wait.Until(ExpectedConditions.ElementToBeClickable(contactName));
            nameInput.SendKeys(name);
            wait.Until(ExpectedConditions.ElementToBeClickable(contactEmail));
            emailInput.SendKeys(email);
            wait.Until(ExpectedConditions.ElementToBeClickable(contactSubject));
            subjectInput.SendKeys(subject);
            wait.Until(ExpectedConditions.ElementToBeClickable(contactMessage));
            messageInput.SendKeys(message);
        }
        public void uploadFile(string filePath)
        {
            contactUploadFile.SendKeys(filePath);
        }

        public void acceptAlert()
        {
            driver.SwitchTo().Alert().Accept();
        }

        public void isSuccessMessageVisible()
        {
            try
            {
                Assert.That(successMessageElement.Displayed, Is.True, "successMessageElement is not displayed as expected.");
                Console.WriteLine("The successMessageElement is visible.");
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("The contactGetInTouch element was not found.");
            }
            catch (WebDriverTimeoutException)
            {
                Console.WriteLine("contactGetInTouch timed out.");
            }
        }

        public void clickSubmitButton()
        {
            try
            {
                Assert.That(contactSubmitButton.Displayed, Is.True, "contactSubmitButton is not displayed as expected.");
                wait.Until(ExpectedConditions.ElementToBeClickable(contactSubmitButton));
                contactSubmitButton.Click();
                Console.WriteLine("contactSubmitButton == clicked.");
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("The contactGetInTouch element was not found.");
            }
            catch (WebDriverTimeoutException)
            {
                Console.WriteLine("contactGetInTouch timed out.");
            }
        }
        public void clickHomeButton()
        {
            try
            {
                Assert.That(contactHomeButton.Displayed, Is.True, "contactHomeButton is not displayed as expected.");
                wait.Until(ExpectedConditions.ElementToBeClickable(contactHomeButton));
                contactHomeButton.Click();
                Console.WriteLine("contactHomeButton == clicked.");
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("The contactHomeButton element was not found.");
            }
            catch (WebDriverTimeoutException)
            {
                Console.WriteLine("contactHomeButton timed out.");
            }
        }
    }
}
