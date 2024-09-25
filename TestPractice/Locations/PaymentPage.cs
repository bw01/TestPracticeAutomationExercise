using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestPractice.Configuration;

namespace TestPractice.Locations
{
    public class paymentPage
    {
        private IWebDriver driver;
        private WebDriverWait wait;
        private globalTestVariables globalTestVariables;


        // Constructor to initialize the driver
        public paymentPage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
        }

        // Page elements
        private IWebElement NameOnCard => driver.FindElement(By.XPath("/html/body/section/div/div[3]/div/div[2]/form/div[1]/div/input"));
        private IWebElement CardNumber => driver.FindElement(By.XPath("//*[@id=\"payment-form\"]/div[2]/div/input"));
        private IWebElement CVC => driver.FindElement(By.XPath("//*[@id=\"payment-form\"]/div[3]/div[1]/input"));
        private IWebElement ExpirationMonth => driver.FindElement(By.XPath("//*[@id=\"payment-form\"]/div[3]/div[2]/input"));
        private IWebElement ExpirationYear => driver.FindElement(By.XPath("//*[@id=\"payment-form\"]/div[3]/div[3]/input"));
        private IWebElement PayAndConfirmButton => driver.FindElement(By.XPath("//*[@id=\"submit\"]"));
        private IWebElement OrderPlacedSuccessfullyAlert => driver.FindElement(By.XPath("//p[contains(text(), 'Congratulations! Your order has been confirmed!')]")); //Unable to locate the element - the Xpath is correct
        private IWebElement downloadInvoiceButton => driver.FindElement(By.XPath("//*[@id=\"form\"]/div/div/div/a"));
        private IWebElement continueButton => driver.FindElement(By.XPath("//*[@id=\"form\"]/div/div/div/div/a"));


        // Page methods
        public void FillNameOnCard()
        {
            globalTestVariables = new globalTestVariables();   

            try
            {
                Assert.That(NameOnCard.Displayed, Is.True, "CardNumbNameOnCarder is not displayed as expected.");
                wait.Until(ExpectedConditions.ElementToBeClickable(NameOnCard));
                NameOnCard.SendKeys(globalTestVariables.nameOnCard);
                Console.WriteLine("Filling NameOnCard was successful.");
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("The NameOnCard element was not found.");
            }
            catch (WebDriverTimeoutException)
            {
                Console.WriteLine("NameOnCard element timed out.");
            }
        }
        public void FillCardNumber()
        {
            globalTestVariables = new globalTestVariables();

            try
            {
                Assert.That(CardNumber.Displayed, Is.True, "CardNumber is not displayed as expected.");
                wait.Until(ExpectedConditions.ElementToBeClickable(CardNumber));
                CardNumber.SendKeys(globalTestVariables.cardNumber);
                Console.WriteLine("Filling CardNumber was successful.");
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("The CardNumber element was not found.");
            }
            catch (WebDriverTimeoutException)
            {
                Console.WriteLine("CardNumber element timed out.");
            }
        }
        public void FillCVCNumber()
        {
            globalTestVariables = new globalTestVariables();

            try
            {
                Assert.That(CVC.Displayed, Is.True, "CVC is not displayed as expected.");
                wait.Until(ExpectedConditions.ElementToBeClickable(CVC));
                CVC.SendKeys(globalTestVariables.cvcNumber);
                Console.WriteLine("Filling CVC was successful.");
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("The CVC element was not found.");
            }
            catch (WebDriverTimeoutException)
            {
                Console.WriteLine("CVC element timed out.");
            }
        }
        public void FillExpirationMonth()
        {
            globalTestVariables = new globalTestVariables();

            try
            {
                Assert.That(ExpirationMonth.Displayed, Is.True, "ExpirationMonth is not displayed as expected.");
                wait.Until(ExpectedConditions.ElementToBeClickable(ExpirationMonth));
                ExpirationMonth.SendKeys(globalTestVariables.expirationMonth);
                Console.WriteLine("Filling ExpirationMonth was successful.");
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("The ExpirationMonth element was not found.");
            }
            catch (WebDriverTimeoutException)
            {
                Console.WriteLine("ExpirationMonth timed out.");
            }
        }
        public void FillExpirationYear()
        {
            globalTestVariables = new globalTestVariables();

            try
            {
                Assert.That(ExpirationYear.Displayed, Is.True, "ExpirationYear is not displayed as expected.");
                wait.Until(ExpectedConditions.ElementToBeClickable(ExpirationYear));
                ExpirationYear.SendKeys(globalTestVariables.expirationYear);
                Console.WriteLine("Filling ExpirationYear was successful.");
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("The ExpirationYear element was not found.");
            }
            catch (WebDriverTimeoutException)
            {
                Console.WriteLine("ExpirationYear timed out.");
            }
        }
        public void clickDownloadInvoiceButton()
        {
            try
            {
                wait.Until(ExpectedConditions.ElementToBeClickable(downloadInvoiceButton));
                Assert.That(downloadInvoiceButton.Displayed, Is.True, "downloadInvoiceButton is not displayed as expected.");
                downloadInvoiceButton.Click();
                Console.WriteLine("Filling downloadInvoiceButton was successful.");
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("The downloadInvoiceButton element was not found.");
            }
            catch (WebDriverTimeoutException)
            {
                Console.WriteLine("downloadInvoiceButton timed out.");
            }
        }
        public void clickContinueButton()
        {
            try
            {
                wait.Until(ExpectedConditions.ElementToBeClickable(continueButton));
                Assert.That(continueButton.Displayed, Is.True, "continueButton is not displayed as expected.");
                continueButton.Click();
                Console.WriteLine("Filling continueButton was successful.");
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("The continueButton element was not found.");
            }
            catch (WebDriverTimeoutException)
            {
                Console.WriteLine("continueButton timed out.");
            }
        }
        public void ClickPayAndConfirmButton()
        {
            try
            {
                Assert.That(PayAndConfirmButton.Displayed, Is.True, "PayAndConfirmButton is not displayed as expected.");
                wait.Until(ExpectedConditions.ElementToBeClickable(PayAndConfirmButton));
                PayAndConfirmButton.Click();
                Console.WriteLine("Filling PayAndConfirmButton was successful.");
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("The PayAndConfirmButton element was not found.");
            }
            catch (WebDriverTimeoutException)
            {
                Console.WriteLine("PayAndConfirmButton timed out.");
            }
        }
        public void fillCreditCardDetails()
        {
            FillNameOnCard();
            FillCardNumber();
            FillCVCNumber();
            FillExpirationMonth();
            FillExpirationYear();
            ClickPayAndConfirmButton();
            IsOrderPlacedSuccessfullyAlertVisible();
        }
        public void IsOrderPlacedSuccessfullyAlertVisible() //Unable to locate the element - the Xpath is correct
        {
            Assert.That(OrderPlacedSuccessfullyAlert.Displayed, Is.True, "The OrderPlacedSuccessfullyAlert message element should be displayed.");
            Console.WriteLine("OrderPlacedSuccessfullyAlert is visible.");
        }

        public void checkIfTheInvoiceWasDownloaded()
        {
            string downloadDirectory = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Downloads";
            string downloadedFile = Path.Combine(downloadDirectory, "invoice.txt");

            int attempts = 0;
            int maxAttemps = 5;

            while (attempts < maxAttemps)
            {
                Thread.Sleep(1000);
                attempts++;
            }
            
            Assert.That(File.Exists(downloadedFile), "Invoice download failed.");
            Console.WriteLine("invoice downloaded successfully.");
        }

}
}
