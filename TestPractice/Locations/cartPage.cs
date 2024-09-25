using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestPractice.Configuration;

namespace TestPractice.Locations
{
    public class cartPage
    {
        private IWebDriver driver;
        private WebDriverWait wait;


        // Constructor to initialize the driver
        public cartPage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
        }


        // Page elements
        private IWebElement ProceedToCheckout => driver.FindElement(By.XPath("//*[@id=\"do_action\"]/div[1]/div/div/a"));
        private IWebElement RegisterLoginButton => driver.FindElement(By.XPath("//*[@id=\"checkoutModal\"]/div/div/div[2]/p[2]/a/u\r\n"));
        private IWebElement ContinueOnCartButton => driver.FindElement(By.XPath("//*[@id=\"checkoutModal\"]/div/div/div[3]/button"));
        private IWebElement ViewCartButton => driver.FindElement(By.XPath("//*[@id=\"cartModal\"]/div/div/div[2]/p[2]/a/u"));
        private IWebElement DeleteQuantityButton => driver.FindElement(By.CssSelector(".cart_quantity_delete"));
        private IWebElement EmptyCart => driver.FindElement(By.XPath("//*[@id=\"empty_cart\"]"));




        // Page methods
        public void VerifyProductsInCart(int expectedCount)
        {
            var cartItems = driver.FindElements(By.CssSelector("#cart_info_table tbody tr"));

            try
            {
                if (cartItems.Count == expectedCount)
                {
                    Console.WriteLine("Verification successful: Number of cart items matches the expected count.");
                }
                else
                {
                    Console.WriteLine($"Verification failed: Found {cartItems.Count} items, but expected {expectedCount}.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred during verification: {ex.Message}");
            }
        }

        public List<string> GetProductNames()
        {
            var productNames = new List<IWebElement>(driver.FindElements(By.XPath("//td[contains(@class, 'cart_description')]//a")));

            foreach (var productName in productNames)
            {
                Console.WriteLine($"Name == {productName.Text}");
            }

            Assert.That(productNames, Is.Not.Empty, "Product names are empty - Probably the Cart is empty");

            return productNames.Select(element => element.TagName).ToList();

        }

        public List<string> GetProductPrice()
        {
            var productPrice = new List<IWebElement>(driver.FindElements(By.XPath("//td[contains(@class, 'cart_price')]/p")));

            foreach (var productPrices in productPrice)
            {
                Console.WriteLine($"Price == {productPrices.Text}");
            }

            Assert.That(productPrice, Is.Not.Empty, "Product price is empty - Probably the Cart is empty");

            return productPrice.Select(element => element.TagName).ToList();
        }
        public List<string> GetProductQuantity()
        {
            var productQuantity = new List<IWebElement>(driver.FindElements(By.XPath("//td[contains(@class, 'cart_quantity')]/button")));

            foreach (var productQuantity_ in productQuantity)
            {
                Console.WriteLine($"Quantity == {productQuantity_.Text}");
            }
            Assert.That(productQuantity, Is.Not.Empty, "Product Quantity is empty - Probably the Cart is empty");

            return productQuantity.Select(element => element.TagName).ToList();
        }
        public List<string> GetProductTotalPrice()
        {
            var productTotalPrice = new List<IWebElement>(driver.FindElements(By.XPath("//p[contains(@class, 'cart_total_price')]")));

            foreach (var productTotalPrice_ in productTotalPrice)
            {
                Console.WriteLine($"Total Price == {productTotalPrice_.Text}");
            }
            Assert.That(productTotalPrice, Is.Not.Empty, "Product Total Price is empty - Probably the Cart is empty");

            return productTotalPrice.Select(element => element.TagName).ToList();
        }
        public void ClickProceedToCheckoutButton()
        {
            try
            {
                Assert.That(ProceedToCheckout.Displayed, Is.True, "ProceedToCheckout is not displayed as expected.");
                wait.Until(ExpectedConditions.ElementToBeClickable(ProceedToCheckout));
                ProceedToCheckout.Click();
                Console.WriteLine("Click on the ProceedToCheckout was successful.");
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("The ProceedToCheckout element was not found.");
            }
            catch (WebDriverTimeoutException)
            {
                Console.WriteLine("ProceedToCheckout timed out.");
            }
        }
        public void ClickRegisterLoginButtonButton()
        {
            try
            {
                Assert.That(RegisterLoginButton.Displayed, Is.True, "RegisterLoginButton is not displayed as expected.");
                wait.Until(ExpectedConditions.ElementToBeClickable(RegisterLoginButton));
                RegisterLoginButton.Click();
                Console.WriteLine("Click on the RegisterLoginButton was successful.");
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("The RegisterLoginButton element was not found.");
            }
            catch (WebDriverTimeoutException)
            {
                Console.WriteLine("RegisterLoginButton timed out.");
            }
        }

        public void ClickContinueOnCartButton()
        {
            try
            {
                Assert.That(ContinueOnCartButton.Displayed, Is.True, "ContinueOnCartButton is not displayed as expected.");
                wait.Until(ExpectedConditions.ElementToBeClickable(ContinueOnCartButton));
                ContinueOnCartButton.Click();
                Console.WriteLine("Click on the ContinueOnCartButton was successful.");
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("The ContinueOnCartButton element was not found.");
            }
            catch (WebDriverTimeoutException)
            {
                Console.WriteLine("ContinueOnCartButton timed out.");
            }
        }

        public void ClickViewCartButton()
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
        public void ClickDeleteQuantityButton()
        {
            
            // Find all "Add to Cart" buttons by class name
            var DeleteQuantityButton = driver.FindElements(By.CssSelector(".cart_quantity_delete"));

            // Click each button
            foreach (var button in DeleteQuantityButton)
            {
                try
                {
                    Assert.That(button.Displayed, Is.True, ".cart_quantity_delete is not displayed as expected.");
                    wait.Until(ExpectedConditions.ElementToBeClickable(button));
                    button.Click();
                    Console.WriteLine("Clicked on .cart_quantity_delete.");
                }
                catch (NoSuchElementException)
                {
                    Console.WriteLine("The .cart_quantity_delete. element was not found.");
                }
                catch (WebDriverTimeoutException)
                {
                    Console.WriteLine(".cart_quantity_delete. timed out.");
                }
            }
        }

        public void CheckIfEmptyCartIsVisible()
        {
            try
            {
                wait.Until(ExpectedConditions.ElementToBeClickable(EmptyCart));
                Assert.That(EmptyCart.Displayed, Is.True, "EmptyCart is not displayed as expected.");
                Console.WriteLine("EmptyCart is visible.");
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("EmptyCart was not found.");
            }
            catch (WebDriverTimeoutException)
            {
                Console.WriteLine("EmptyCart timed out.");
            }
        }

    }
}
