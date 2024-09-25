using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestPractice.Configuration;

namespace TestPractice.Locations
{
    public class productDetailPage
    {
        private IWebDriver driver;
        private WebDriverWait wait;


        // Constructor to initialize the driver
        public productDetailPage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
        }

        // Page elements
        private IWebElement ProductName => driver.FindElement(By.XPath("/html/body/section/div/div/div[2]/div[2]/div[2]/div/h2"));
        private IWebElement Category => driver.FindElement(By.XPath("/html/body/section/div/div/div[2]/div[2]/div[2]/div/p[1]"));
        private IWebElement Price => driver.FindElement(By.XPath("/html/body/section/div/div/div[2]/div[2]/div[2]/div/span/span"));
        private IWebElement Availability => driver.FindElement(By.XPath("/html/body/section/div/div/div[2]/div[2]/div[2]/div/p[2]/b"));
        private IWebElement Condition => driver.FindElement(By.XPath("/html/body/section/div/div/div[2]/div[2]/div[2]/div/p[3]/b"));
        private IWebElement Brand => driver.FindElement(By.XPath("/html/body/section/div/div/div[2]/div[2]/div[2]/div/p[4]"));
        private IWebElement Quantity => driver.FindElement(By.XPath("//*[@id=\"quantity\"]"));
        private IWebElement AddToCartButton => driver.FindElement(By.XPath("/html/body/section/div/div/div[2]/div[2]/div[2]/div/span/button"));
        private IWebElement ViewCartButton => driver.FindElement(By.XPath("//*[@id=\"cartModal\"]/div/div/div[2]/p[2]/a/u"));
        private IWebElement WriteYourReviewSection => driver.FindElement(By.XPath("/html/body/section/div/div/div[2]/div[3]/div[1]/ul/li/a"));
        private IWebElement WriteYourReviewSectionName => driver.FindElement(By.XPath("//*[@id=\"name\"]"));
        private IWebElement WriteYourReviewSectionEmail => driver.FindElement(By.XPath("//*[@id=\"email\"]"));
        private IWebElement WriteYourReviewSectionAddReview => driver.FindElement(By.XPath("//*[@id=\"review\"]"));
        private IWebElement WriteYourReviewSectionSubmitButton => driver.FindElement(By.XPath("//*[@id=\"button-review\"]"));
        private IWebElement ThankYouForTheReviewPrompt => driver.FindElement(By.XPath("//*[@id=\"review-section\"]/div/div/span[contains(text(), \"Thank you for your review.\")]"));


        // Page methods
        public void VerifyIfProductElementsAreDisplayed()
        {
            var elementsToCheck = new List<IWebElement>
            {
                ProductName,
                Category,
                Price,
                Availability,
                Condition,
                Brand
            };

            foreach (var element in elementsToCheck)
            {
                if (element.Displayed)
                {
                    Assert.That(element.Text, Is.Not.Empty, $"{element.Text} is not displayed.");
                    Console.WriteLine($"{element.Text} is displayed.");
                }
                else
                {
                    Console.WriteLine($"{element.Text} is not displayed.");
                }
            }

        }
        public void increaseQuatityto4()
        {
            try
            {
                Assert.That(Quantity.Displayed, Is.True, "Quantity is not displayed as expected.");
                Console.WriteLine("Quantity is visible.");
                wait.Until(ExpectedConditions.ElementToBeClickable(Quantity));
                Quantity.Click();
                Console.WriteLine("Click on the Quantity was successful.");
                Quantity.Clear();
                Quantity.SendKeys("4");
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("The Quantity element was not found.");
            }
            catch (WebDriverTimeoutException)
            {
                Console.WriteLine("Quantity timed out.");
            }
        }
        public void clickAddToCartButton()
        {
            try
            {
                Assert.That(AddToCartButton.Displayed, Is.True, "AddToCartButton is not displayed as expected.");
                wait.Until(ExpectedConditions.ElementToBeClickable(AddToCartButton));
                AddToCartButton.Click();
                Console.WriteLine("Click on the AddToCartButton was successful.");
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("The AddToCartButton element was not found.");
            }
            catch (WebDriverTimeoutException)
            {
                Console.WriteLine("AddToCartButton timed out.");
            }
        }
        public void clickViewCartButton()
        {
            try
            {
                wait.Until(ExpectedConditions.ElementToBeClickable(ViewCartButton));
                Assert.That(ViewCartButton.Displayed, Is.True, "ViewCartButton is not displayed as expected.");
                ViewCartButton.Click();
                Console.WriteLine("Click on the ViewCartButton was successful.");
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("The ViewCartButton element was not found.");
            }
            catch (WebDriverTimeoutException)
            {
                Console.WriteLine("ViewCartButton timed out.");
            }
        }

        public void SubmitAReview()
        {
            globalTestVariables globalTestVariables = new globalTestVariables();

            try
            {
                Assert.That(WriteYourReviewSection.Displayed, Is.True, "WriteYourReviewSection is not displayed.");
                Assert.That(WriteYourReviewSectionName.Displayed, "WriteYourReviewSectionName is not displayed.");
                wait.Until(ExpectedConditions.ElementToBeClickable(WriteYourReviewSectionName));
                WriteYourReviewSectionName.Click();
                WriteYourReviewSectionName.SendKeys(globalTestVariables.userName);
                Console.WriteLine("WriteYourReviewSectionName == Filled.");
                Assert.That(WriteYourReviewSectionEmail.Displayed, Is.True, "WriteYourReviewSectionEmail is not displayed.");
                wait.Until(ExpectedConditions.ElementToBeClickable(WriteYourReviewSectionEmail));
                WriteYourReviewSectionEmail.Click();
                WriteYourReviewSectionEmail.SendKeys(globalTestVariables.loginUserEmail);
                Console.WriteLine("WriteYourReviewSectionEmail == Filled.");
                Assert.That(WriteYourReviewSectionAddReview.Displayed, Is.True, "WriteYourReviewSectionAddReview is not displayed.");
                wait.Until(ExpectedConditions.ElementToBeClickable(WriteYourReviewSectionAddReview));
                WriteYourReviewSectionAddReview.Click();
                WriteYourReviewSectionAddReview.SendKeys("Review Test"); 
                Console.WriteLine("WriteYourReviewSectionAddReview == Filled.");
                Assert.That(WriteYourReviewSectionSubmitButton.Displayed, Is.True, "WriteYourReviewSectionSubmitButton is not displayed.");
                wait.Until(ExpectedConditions.ElementToBeClickable(WriteYourReviewSectionSubmitButton));
                WriteYourReviewSectionSubmitButton.Click();
                Console.WriteLine("WriteYourReviewSectionSubmitButton == Clicked.");
                Assert.That(ThankYouForTheReviewPrompt.Displayed, Is.True, "ThankYouForTheReviewPrompt is not displayed.");
            }
            catch (NoSuchElementException)
            {
            }
            catch (WebDriverTimeoutException)
            {
            }
        }

    }
}
