using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestPractice.Configuration;

namespace TestPractice.Locations
{
    public class allProductsPage
    {
        private IWebDriver driver;
        private WebDriverWait wait;


        // Constructor to initialize the driver
        public allProductsPage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
        }

        // Page elements
        private IWebElement ViewProductLink => driver.FindElement(By.XPath("/html/body/section[2]/div/div/div[2]/div/div[2]/div/div[2]/ul/li/a"));
        private IWebElement SearchProduct => driver.FindElement(By.Id("search_product"));
        private IWebElement SubmitSearchButton => driver.FindElement(By.XPath("//*[@id=\"submit_search\"]"));
        public IWebElement SearchedProductsText => driver.FindElement(By.XPath("/html/body/section[2]/div/div/div[2]/div/h2"));
        private IWebElement ContinueShoppingButton => driver.FindElement(By.XPath("//*[@id=\"cartModal\"]/div/div/div[3]/button"));
        private IWebElement ViewCartButton => driver.FindElement(By.XPath("//*[@id=\"cartModal\"]/div/div/div[2]/p[2]/a/u"));
        private IWebElement BrandsSection => driver.FindElement(By.CssSelector("body > section:nth-child(3) > div > div > div.col-sm-3 > div > div.brands_products"));
        private IWebElement BrandsSectionPolo => driver.FindElement(By.XPath("/html/body/section[2]/div/div/div[1]/div/div[2]/div/ul/li[1]/a"));
        private IWebElement BrandsSectionMadame => driver.FindElement(By.XPath("/html/body/section/div/div[2]/div[1]/div/div[2]/div/ul/li[3]/a"));


        // Page methods
        public void ClickOnFirstProduct()
        {
            try
            {
                wait.Until(ExpectedConditions.ElementToBeClickable(ViewProductLink));
                ViewProductLink.Click();
                Console.WriteLine("Click on the ViewProductLink was successful.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to click on the first product due to error: {ex.Message}");
            }
        }

        public void SearchForAProduct()
        {
            globalTestVariables globalTestVariables = new globalTestVariables();
            try
            {
                wait.Until(ExpectedConditions.ElementToBeClickable(SearchProduct));
                SearchProduct.Click();
                SearchProduct.SendKeys(globalTestVariables.productName);
                wait.Until(ExpectedConditions.ElementToBeClickable(SubmitSearchButton));
                SubmitSearchButton.Click();
                Assert.That(driver.FindElement(By.XPath("/html/body/section[2]/div/div/div[2]/div/h2[text() = 'Searched Products']")).Displayed, Is.True, "Searched Products is not visible.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"SearchProduct not found: {ex.Message}");
            }
        }

        public void CheckIfSearchedProductsText()
        {
            try
            {
                if (SearchedProductsText.Displayed)
                {
                    Assert.That(SearchedProductsText.Displayed, Is.True, "SearchedProductsText text is not visible.");
                    Console.WriteLine("The SearchedProductsText text is visible.");
                }
                else
                {
                    Console.WriteLine("The SearchedProductsText text is not visible.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
        public void AreAllRelatedProductsVisible()
        {
            try
            {
                var products = driver.FindElements(By.XPath("//div[contains(@class, 'single-products')]")).Count;
                Assert.That(products, Is.GreaterThan(0), "No products found related to search"); 
                Console.WriteLine($"{products} products are displayed.");

            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

        }
        public void SelectProductAndAddToCart(string productID)
        {
            var addToCartButton = driver.FindElements(By.CssSelector("[data-product-id].add-to-cart"));
            foreach (var button in addToCartButton)
            {
                if (button.GetAttribute("data-product-id") == productID)
                {
                    button.Click();
                    break; 
                }
            }
        }
        public void ClickAllAddToCartButtons()
        {
            
            // Find all "Add to Cart" buttons by class name
            var addToCartButtons = driver.FindElements(By.CssSelector(".btn.btn-default.add-to-cart"));
            var continueShoppingButton = driver.FindElement(By.CssSelector("#cartModal > div > div > div.modal-footer > button"));

            // Click each button
            foreach (var button in addToCartButtons)
            {
                try
                {
                    if (button.Displayed)
                    {
                        wait.Until(ExpectedConditions.ElementToBeClickable(button));
                        button.Click();
                        Console.WriteLine("Clicked on addToCartButtons.");
                        wait.Until(ExpectedConditions.ElementToBeClickable(continueShoppingButton));
                        continueShoppingButton.Click();
                        Thread.Sleep(500);
                    }


                }
                catch (NoSuchElementException)
                {
                    Console.WriteLine("The addToCartButtons element was not found.");
                }
                catch (WebDriverTimeoutException)
                {
                    Console.WriteLine("addToCartButtons timed out.");
                }
            }
        }
        public void ClickViewCartButton()
        {
            try
            {
                wait.Until(ExpectedConditions.ElementToBeClickable(ViewCartButton));
                ViewCartButton.Click();
                Console.WriteLine("Click on the ViewCartButton was successful.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to click on ViewCartButton due to error: {ex.Message}");
            }
        }
        public void ClickContinueShoppingButton()
        {
            try
            {
                wait.Until(ExpectedConditions.ElementToBeClickable(ContinueShoppingButton));
                ContinueShoppingButton.Click();
                Console.WriteLine("Click on the ContinueShoppingButton was successful.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to click on ContinueShoppingButton due to error: {ex.Message}");
            }
        }
        public void BrandsSectionIsVisible()
        {
            try
            {
                Assert.That(BrandsSection.Displayed, Is.True, "Brands section is not displayed as expected.");
                Console.WriteLine("Click on the BrandsSection was successful.");
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("The BrandsSection element was not found.");
            }
            catch (WebDriverTimeoutException)
            {
                Console.WriteLine("BrandsSection timed out.");
            }
        }
        public void ClickBrandsSectionPolo()
        {
            try
            {
                Assert.That(BrandsSectionPolo.Displayed, Is.True, "BrandsSectionPolo is not displayed as expected.");
                wait.Until(ExpectedConditions.ElementToBeClickable(BrandsSectionPolo));
                BrandsSectionPolo.Click();
                Console.WriteLine("Click on the BrandsSectionPolo was successful.");
                Assert.That(driver.Title.Contains("Polo Products"), Is.True, "Polo Products is not displayed as expected.");

            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("The BrandsSection element was not found.");
            }
            catch (WebDriverTimeoutException)
            {
                Console.WriteLine("BrandsSection timed out.");
            }
        }
        public void ClickBrandsSectionMadame()
        {
            try
            {
                Assert.That(BrandsSectionMadame.Displayed, Is.True, "BrandsSectionMadame is not displayed as expected.");
                wait.Until(ExpectedConditions.ElementToBeClickable(BrandsSectionMadame));
                BrandsSectionMadame.Click();
                Console.WriteLine("Click on the BrandsSectionMadame was successful.");
                Assert.That(driver.Title.Contains("Madame Products"), Is.True, "Madame Products is not displayed as expected.");

            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("The BrandsSection element was not found.");
            }
            catch (WebDriverTimeoutException)
            {
                Console.WriteLine("BrandsSection timed out.");
            }
        }
    }
}
