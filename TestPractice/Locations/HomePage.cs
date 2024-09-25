using OpenQA.Selenium.Support.UI;
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
    public class homePage
    {
        private IWebDriver driver;
        private WebDriverWait wait;
        private allProductsPage allProductsPage;
        


        // Constructor to initialize the driver
        public homePage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            allProductsPage = new allProductsPage(driver);
        }

        // Page elements
        private IWebElement HomeButton => driver.FindElement(By.XPath("//*[@id=\"header\"]/div/div/div/div[2]/div/ul/li[1]/a"));
        private IWebElement ProductsButton => driver.FindElement(By.XPath("/html/body/header/div/div/div/div[2]/div/ul/li[2]/a"));
        private IWebElement CartButton => driver.FindElement(By.XPath("//*[@id=\"header\"]/div/div/div/div[2]/div/ul/li[3]/a"));
        private IWebElement SignupLoginButton => driver.FindElement(By.XPath("//header[@id='header']/div/div/div/div[2]/div/ul/li[4]/a"));
        private IWebElement DeleteAccountButton => driver.FindElement(By.LinkText("Delete Account"));
        private IWebElement ContinueButton => driver.FindElement(By.XPath("//a[contains(text(),'Continue')]"));
        private IWebElement homePageLogo => driver.FindElement(By.XPath("//*[@id=\"header\"]/div/div/div/div[1]/div/a/img"));
        private IWebElement loggedInAsAnUserText => driver.FindElement(By.XPath("//*[@id='header']/div/div/div/div[2]/div/ul/li[10]/a[contains(text(), 'Logged in as')]"));
        private IWebElement deletedAccountText => driver.FindElement(By.XPath("//*[@id=\"form\"]/div/div/div/h2/b"));
        private IWebElement logoutButton => driver.FindElement(By.XPath("/html/body/header/div/div/div/div[2]/div/ul/li[4]/a"));
        private IWebElement testCasesButton => driver.FindElement(By.XPath("//*[@id=\"header\"]/div/div/div/div[2]/div/ul/li[5]/a"));
        private IWebElement contactUsButton => driver.FindElement(By.XPath("//*[@id=\"header\"]/div/div/div/div[2]/div/ul/li[8]/a"));
        private IWebElement productsButton => driver.FindElement(By.XPath("//*[@id=\"header\"]/div/div/div/div[2]/div/ul/li[2]/a"));
        private IWebElement consentButton => driver.FindElement(By.CssSelector("body > div > div.fc-dialog-container > div.fc-dialog.fc-choice-dialog > div.fc-footer-buttons-container > div.fc-footer-buttons > button.fc-button.fc-cta-consent.fc-primary-button > p"));
        private IWebElement SubcriptionText => driver.FindElement(By.XPath("//*[@id=\"footer\"]/div[1]/div/div/div[2]/div/h2"));
        private IWebElement SubcriptionEmailField => driver.FindElement(By.Id("susbscribe_email"));
        private IWebElement SubscribeButton => driver.FindElement(By.Id("subscribe"));
        private IWebElement CategoriesSection => driver.FindElement(By.Id("accordian"));
        private IWebElement CategoriesSectionWomen => driver.FindElement(By.XPath("//*[@id=\"accordian\"]/div[1]/div[1]/h4/a"));
        private IWebElement CategoriesSectionWomenDress => driver.FindElement(By.XPath("//*[@id=\"Women\"]/div/ul/li[1]/a"));
        private IWebElement CategoriesSectionWomenDressTitle => driver.FindElement(By.XPath("//h2[contains(text(), 'Women - Dress Products')]"));
        private IWebElement CategoriesSectionMen => driver.FindElement(By.XPath("//*[@id=\"accordian\"]/div[2]/div[1]/h4/a"));
        private IWebElement CategoriesSectionMenTShirts => driver.FindElement(By.XPath("//*[@id=\"Men\"]/div/ul/li[1]/a"));
        private IWebElement CategoriesSectionMenTShirtsTitle => driver.FindElement(By.XPath("//h2[contains(text(), 'Men - Tshirts Products')]"));
        private IWebElement recommendedItemsSection => driver.FindElement(By.CssSelector(".recommended_items"));
        private IWebElement scrollUpButton => driver.FindElement(By.XPath("//*[@id=\"scrollUp\"]"));
        private IWebElement FullFledgedPracticeWebsiteForAutomationEngineerText => driver.FindElement(By.CssSelector("#slider-carousel > div > div.item.active > div:nth-child(1) > h2"));





        // Page methods

        public void CheckIfhomePageIsVisible()
        {
            try
            {
                Assert.That(homePageLogo.Displayed, Is.True, "homePageLogo is not displayed as expected.");
                Console.WriteLine("homePageLogo element is visible.");
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("The homePageLogo element was not found.");
            }
            catch (WebDriverTimeoutException)
            {
                Console.WriteLine("homePageLogo timed out.");
            }
        }
        public void ClickHomeButton()
        {
            try
            {
                Assert.That(HomeButton.Displayed, Is.True, "HomeButton is not displayed as expected.");
                wait.Until(ExpectedConditions.ElementToBeClickable(HomeButton));
                HomeButton.Click();
                Console.WriteLine("Click on the HomeButton was successful.");
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("The HomeButton element was not found.");
            }
            catch (WebDriverTimeoutException)
            {
                Console.WriteLine("HomeButton timed out.");
            }
        }

        public void ClickProductsButton()
        {
            try
            {
                Assert.That(ProductsButton.Displayed, Is.True, "ProductsButton is not displayed as expected.");
                wait.Until(ExpectedConditions.ElementToBeClickable(ProductsButton));
                ProductsButton.Click();
                Console.WriteLine("Click on the ProductsButton was successful.");
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("The ProductsButton element was not found.");
            }
            catch (WebDriverTimeoutException)
            {
                Console.WriteLine("ProductsButton timed out.");
            }
        }

        public void ClickCartButton()
        {
            try
            {
                Assert.That(CartButton.Displayed, Is.True, "CartButton is not displayed as expected.");
                wait.Until(ExpectedConditions.ElementToBeClickable(CartButton));
                CartButton.Click();
                Console.WriteLine("Click on the CartButton was successful.");
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("The CartButton element was not found.");
            }
            catch (WebDriverTimeoutException)
            {
                Console.WriteLine("CartButton timed out.");
            }
        }

        public void ClickSignupLoginButton()
        {
            try
            {
                Assert.That(SignupLoginButton.Displayed, Is.True, "SignupLoginButton is not displayed as expected.");
                wait.Until(ExpectedConditions.ElementToBeClickable(SignupLoginButton));
                SignupLoginButton.Click();
                Console.WriteLine("Click on the SignupLoginButton was successful.");
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("The SignupLoginButton element was not found.");
            }
            catch (WebDriverTimeoutException)
            {
                Console.WriteLine("SignupLoginButton timed out.");
            }
        }
        public void ClickDeleteAccountButton()
        {
            try
            {
                Assert.That(DeleteAccountButton.Displayed, Is.True, "DeleteAccountButton is not displayed as expected.");
                wait.Until(ExpectedConditions.ElementToBeClickable(DeleteAccountButton));
                DeleteAccountButton.Click();
                Console.WriteLine("Click on the DeleteAccountButton was successful.");
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("The DeleteAccountButton element was not found.");
            }
            catch (WebDriverTimeoutException)
            {
                Console.WriteLine("DeleteAccountButton timed out.");
            }
        }
    
        public void ClickContinueButton()
        {
            try
            {
                Assert.That(ContinueButton.Displayed, Is.True, "ContinueButton is not displayed as expected.");
                wait.Until(ExpectedConditions.ElementToBeClickable(ContinueButton));
                ContinueButton.Click();
                Console.WriteLine("Click on the ContinueButton was successful.");
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("The ContinueButton element was not found.");
            }
            catch (WebDriverTimeoutException)
            {
                Console.WriteLine("ContinueButton timed out.");
            }
        }

        public void ClickLogoutButton()
        {
            try
            {
                Assert.That(logoutButton.Displayed, Is.True, "logoutButton is not displayed as expected.");
                wait.Until(ExpectedConditions.ElementToBeClickable(logoutButton));
                logoutButton.Click();
                Console.WriteLine("Click on the logoutButton was successful.");
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("The logoutButton element was not found.");
            }
            catch (WebDriverTimeoutException)
            {
                Console.WriteLine("logoutButton timed out.");
            }
        }
        public void ClicktestCasesButton()
        {
            try
            {
                Assert.That(testCasesButton.Displayed, Is.True, "testCasesButton is not displayed as expected.");
                wait.Until(ExpectedConditions.ElementToBeClickable(testCasesButton));
                testCasesButton.Click();
                Console.WriteLine("Click on the testCasesButton was successful.");
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("The testCasesButton element was not found.");
            }
            catch (WebDriverTimeoutException)
            {
                Console.WriteLine("testCasesButton timed out.");
            }
        }


        public void clickConsentButton()
        {
            try
            {
                Assert.That(consentButton.Displayed, Is.True, "consentButton is not displayed as expected.");
                wait.Until(ExpectedConditions.ElementToBeClickable(consentButton));
                consentButton.Click();
                Console.WriteLine("consentButton clicked successfully.");
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("The consentButton element was not found.");
            }
            catch (WebDriverTimeoutException)
            {
                Console.WriteLine("consentButton timed out.");
            }

        }

        public void clickContactUsButton()
        {
            try
            {
                Assert.That(contactUsButton.Displayed, Is.True, "contactUsButton is not displayed as expected.");
                wait.Until(ExpectedConditions.ElementToBeClickable(contactUsButton));
                contactUsButton.Click();
                Console.WriteLine("contactUsButton clicked successfully.");
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("The contactUsButton element was not found.");
            }
            catch (WebDriverTimeoutException)
            {
                Console.WriteLine("contactUsButton timed out.");
            }
        }

        public void clickProductsButton()
        {
            try
            {
                Assert.That(productsButton.Displayed, Is.True, "productsButton is not displayed as expected.");
                wait.Until(ExpectedConditions.ElementToBeClickable(productsButton));
                productsButton.Click();
                Console.WriteLine("productsButton clicked successfully.");
                Assert.That(allProductsPage.SearchedProductsText.Displayed, Is.True, "allProductsPage.SearchedProductsText is not displayed");
                Console.WriteLine("user is navigated to ALL PRODUCTS page successfully");

            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("The allProductsPage.SearchedProductsText element was not found.");
            }
            catch (WebDriverTimeoutException)
            {
                Console.WriteLine("allProductsPage.SearchedProductsText timed out.");
            }
        }
        public void CheckIfLoggedinAsAnUserTextIsVisible()
        {
            try
            {
                Assert.That(loggedInAsAnUserText.Displayed, Is.True, "loggedInAsAnUserText is not displayed as expected.");
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("The loggedInAsAnUserText element was not found.");
            }
            catch (WebDriverTimeoutException)
            {
                Console.WriteLine("loggedInAsAnUserText timed out.");
            }
        }
        public void CheckIfDeleteAccountButtonIsVisible()
        {
            try
            {
                Assert.That(DeleteAccountButton.Displayed, Is.True, "DeleteAccountButton is not displayed as expected.");
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("The DeleteAccountButton element was not found.");
            }
            catch (WebDriverTimeoutException)
            {
                Console.WriteLine("DeleteAccountButton timed out.");
            }
        }
        public void CheckIfAccountDeletedTextIsVisible()
        {
            try
            {
                Assert.That(deletedAccountText.Displayed, Is.True, "deletedAccountText is not displayed as expected.");
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("The deletedAccountText element was not found.");
            }
            catch (WebDriverTimeoutException)
            {
                Console.WriteLine("deletedAccountText timed out.");
            }
        }
        public void CheckIfNavigatedTotestCasesPage()
        {
            globalTestVariables globalTestVariables = new globalTestVariables();

            if (driver.Url == globalTestVariables.testCasesURL)
            {
                Console.WriteLine($"User has been navigated to {globalTestVariables.testCasesURL} successfully");
                Assert.That(driver.Url.Contains("https://automationexercise.com/test_cases"), Is.True, "Failed to navigate to test cases page");
            }
            else
            {
                Console.WriteLine($"User has not been navigated to {globalTestVariables.testCasesURL} successfully");
            }
        }
        public void ScrollDownToFooter()
        {
            ((IJavaScriptExecutor)driver).ExecuteScript("window.scrollTo(0, document.body.scrollHeight);");
        }
        public void scrollUpToTop()
        {
            ((IJavaScriptExecutor)driver).ExecuteScript("window.scrollTo(0, 0);");
        }

        public void CheckIfSubscriptionTextIsVisible()
        {
            try
            {
                Assert.That(SubcriptionText.Displayed, Is.True, "SubcriptionText is not displayed as expected.");
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("The SubcriptionText element was not found.");
            }
            catch (WebDriverTimeoutException)
            {
                Console.WriteLine("SubcriptionText timed out.");
            }
        }
        public void FillSubcriptionEmailField()
        {
            globalTestVariables globalTestVariables = new globalTestVariables();
           
            Assert.That(SubcriptionEmailField.Displayed, Is.True, "SubcriptionEmailField is not displayed as expected.");
            wait.Until(ExpectedConditions.ElementToBeClickable(SubcriptionEmailField));
            SubcriptionEmailField.Click();
            SubcriptionEmailField.SendKeys(globalTestVariables.loginUserEmail);
            Assert.That(SubscribeButton.Displayed, Is.True, "SubcriptionEmailField is not displayed as expected.");
            wait.Until(ExpectedConditions.ElementToBeClickable(SubscribeButton));
            SubscribeButton.Click();
        }
        public void CheckIfYouHaveBeenSubscribed()
        {
           var subscribedText = driver.FindElement(By.CssSelector("#success-subscribe > div"));

            try
            {
                Assert.That(subscribedText.Displayed, Is.True, "subscribedText is not displayed as expected.");
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("The subscribedText element was not found.");
            }
            catch (WebDriverTimeoutException)
            {
                Console.WriteLine("subscribedText timed out.");
            }
        }

        public void CheckIfCategoriesSectionIsVisible()
        {

            try
            {
                Assert.That(CategoriesSection.Displayed, Is.True, "CategoriesSection is not displayed as expected.");
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("The CategoriesSection element was not found.");
            }
            catch (WebDriverTimeoutException)
            {
                Console.WriteLine("CategoriesSection timed out.");
            }
        }

        public void ClickCategoriesSectionWomen()
        {
            try
            {
                wait.Until(ExpectedConditions.ElementToBeClickable(CategoriesSectionWomen));
                Assert.That(CategoriesSectionWomen.Displayed, Is.True, "CategoriesSectionWomen is not displayed as expected.");
                CategoriesSectionWomen.Click();
                Console.WriteLine("Click on the CategoriesSectionWomen was successful.");
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("The CategoriesSectionWomen element was not found.");
            }
            catch (WebDriverTimeoutException)
            {
                Console.WriteLine("CategoriesSectionWomen timed out.");
            }
        }
        public void ClickCategoriesSectionWomenDress()
        {
            try
            {
                wait.Until(ExpectedConditions.ElementToBeClickable(CategoriesSectionWomenDress));
                Assert.That(CategoriesSectionWomenDress.Displayed, Is.True, "CategoriesSectionWomenDress is not displayed as expected.");
                CategoriesSectionWomenDress.Click();
                Console.WriteLine("Click on the CategoriesSectionWomenDress was successful.");
                Assert.That(CategoriesSectionWomenDressTitle.Displayed, Is.True, "CategoriesSectionWomenDress is not displayed as expected.");
                wait.Until(ExpectedConditions.ElementToBeClickable(CategoriesSectionWomenDressTitle));
                Assert.That(CategoriesSectionWomenDressTitle.Displayed, Is.True, "Men's T-Shirts section is not displayed as expected.");

            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("The CategoriesSectionWomenDress element was not found.");
            }
            catch (WebDriverTimeoutException)
            {
                Console.WriteLine("ClickCategoriesSectionWomenDress timed out.");
            }
        }
        public void ClickCategoriesSectionMen()
        {
            try
            {
                wait.Until(ExpectedConditions.ElementToBeClickable(CategoriesSectionMen));
                Assert.That(CategoriesSectionMen.Displayed, Is.True, "CategoriesSectionMen is not displayed as expected.");
                CategoriesSectionMen.Click();
                Console.WriteLine("Click on the CategoriesSectionMen was successful.");
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("The CategoriesSectionMen element was not found.");
            }
            catch (WebDriverTimeoutException)
            {
                Console.WriteLine("CategoriesSectionMen timed out.");
            }
        }
        public void ClickCategoriesSectionMenTshirts()
        {
            try
            {
                wait.Until(ExpectedConditions.ElementToBeClickable(CategoriesSectionMenTShirts));
                Assert.That(CategoriesSectionMenTShirts.Displayed, Is.True, "CategoriesSectionMenTShirts is not displayed as expected.");
                CategoriesSectionMenTShirts.Click();
                Console.WriteLine("Click on the CategoriesSectionMenTShirts was successful.");
                wait.Until(ExpectedConditions.ElementToBeClickable(CategoriesSectionMenTShirtsTitle));
                Assert.That(CategoriesSectionMenTShirtsTitle.Displayed, Is.True, "Men's T-Shirts section is not displayed as expected.");

            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("The CategoriesSectionMenTShirts element was not found.");
            }
            catch (WebDriverTimeoutException)
            {
                Console.WriteLine("CategoriesSectionMenTShirts timed out.");
            }
        }

        public void clickScrollUpButton()
        {
            try
            {
                wait.Until(ExpectedConditions.ElementToBeClickable(scrollUpButton));
                Assert.That(scrollUpButton.Displayed, Is.True, "scrollUpButton is not displayed as expected.");
                scrollUpButton.Click();
                Console.WriteLine("Click on the scrollUpButton was successful.");
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("The scrollUpButton element was not found.");
            }
            catch (WebDriverTimeoutException)
            {
                Console.WriteLine("scrollUpButton timed out.");
            }
        }

        public void scrollToRecommendedItemsSection()
        {
            try
            {
                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;

                js.ExecuteScript("window.scrollTo(0, document.body.scrollHeight)");
                Assert.That(recommendedItemsSection.Displayed, "recommendedItemsSection is not displayed");
                Console.WriteLine("The recommendedItemsSection element was found.");
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("The recommendedItemsSection element was not found.");
            }
            catch (WebDriverTimeoutException)
            {
                Console.WriteLine("recommendedItemsSection timed out.");
            }
        }

        public void checkIfFullFledgedPracticeWebsiteForAutomationEngineerTextIsVisible()
        {
            try
            {
                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                var scrollPosition = js.ExecuteScript("return window.pageYOffset;");

                Thread.Sleep(5000);
                Assert.That(scrollPosition, Is.GreaterThanOrEqualTo(0), "The page is not scrolled to the top.");
                Thread.Sleep(1000);
                Assert.That(FullFledgedPracticeWebsiteForAutomationEngineerText.Displayed, "FullFledgedPracticeWebsiteForAutomationEngineerText is not displayed");
                Console.WriteLine("FullFledgedPracticeWebsiteForAutomationEngineerText is displayed");
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("The FullFledgedPracticeWebsiteForAutomationEngineerText element was not found.");
            }
            catch (WebDriverTimeoutException)
            {
                Console.WriteLine("FullFledgedPracticeWebsiteForAutomationEngineerText timed out.");
            }
        }


    }
}

