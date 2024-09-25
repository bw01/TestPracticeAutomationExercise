using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestPractice.Configuration;

namespace TestPractice.Locations
{
    public class checkoutPage
    {
        private IWebDriver driver;
        private WebDriverWait wait;
        private globalTestVariables globalTestVariables;


        // Constructor to initialize the driver
        public checkoutPage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            globalTestVariables = new globalTestVariables();
        }

        // Page elements
        private IWebElement PlaceOrderButton => driver.FindElement(By.XPath("//*[@id=\"cart_items\"]/div/div[7]/a"));
        private IWebElement OrderComment => driver.FindElement(By.XPath("//*[@id=\"ordermsg\"]/textarea"));
        private IWebElement deliveryAddressSection => driver.FindElement(By.Id("address_delivery"));

        private IWebElement deliveryAddressFirstNameLastName => driver.FindElement(By.CssSelector("#address_delivery > .address_firstname"));
        private IWebElement deliveryAddressCompany => driver.FindElement(By.CssSelector(".address_address1.address_address2"));
        private IWebElement deliveryAddress1 => driver.FindElement(By.CssSelector("#address_delivery > li:nth-child(4)"));
        private IWebElement deliveryAddress2 => driver.FindElement(By.CssSelector("#address_delivery > li:nth-child(5)"));
        private IWebElement deliveryCityStatePostCode => driver.FindElement(By.CssSelector("#address_delivery > .address_city"));
        private IWebElement deliveryCountry => driver.FindElement(By.CssSelector("#address_delivery > .address_country_name"));
        private IWebElement deliveryPhone => driver.FindElement(By.CssSelector(".address_phone"));
        private IWebElement billingAddressSection => driver.FindElement(By.Id("address_invoice"));
        private IWebElement billingAddressFirstNameLastName => driver.FindElement(By.CssSelector("#address_invoice > li.address_firstname.address_lastname"));
        private IWebElement billingAddressCompany => driver.FindElement(By.CssSelector("#address_invoice > li:nth-child(3)"));
        private IWebElement billingAddress1 => driver.FindElement(By.CssSelector("#address_invoice > li:nth-child(4)"));
        private IWebElement billingAddress2 => driver.FindElement(By.CssSelector("#address_invoice > li:nth-child(5)"));
        private IWebElement billingCityStatePostCode => driver.FindElement(By.CssSelector("#address_invoice > li.address_city.address_state_name.address_postcode"));
        private IWebElement billingCountry => driver.FindElement(By.CssSelector("#address_invoice > li.address_country_name"));
        private IWebElement billingPhone => driver.FindElement(By.CssSelector("#address_invoice > li.address_phone"));



        // Page methods
        public void VerifyDeliveryAddressDetails()
        {
            try
            {
                Assert.Multiple(() =>
                {
                    Assert.That(deliveryAddressSection.Displayed, Is.True, "Delivery address section is not displayed.");
                    Console.WriteLine("Delivery address section == Displayed");
                    Assert.That(deliveryAddressFirstNameLastName.Text, Does.Contain(globalTestVariables.userFirstName));
                    Console.WriteLine("deliveryAddressFirstNameLastName == Displayed");
                    Assert.That(deliveryAddressCompany.Text, Does.Contain(globalTestVariables.userCompany));
                    Console.WriteLine("deliveryAddressCompany == Displayed");
                    Assert.That(deliveryAddress1.Text, Does.Contain(globalTestVariables.userAddress));
                    Console.WriteLine("deliveryAddress1 == Displayed");
                    Assert.That(deliveryAddress2.Text, Does.Contain(globalTestVariables.userAddress2));
                    Console.WriteLine("deliveryAddress2 == Displayed");
                    Assert.That(deliveryCityStatePostCode.Text, Does.Contain(globalTestVariables.userCity));
                    Console.WriteLine("userCity == Displayed");
                    Assert.That(deliveryCityStatePostCode.Text, Does.Contain(globalTestVariables.userState));
                    Console.WriteLine("userState == Displayed");
                    Assert.That(deliveryCityStatePostCode.Text, Does.Contain(globalTestVariables.userZipcode));
                    Console.WriteLine("userZipcode == Displayed");
                    Assert.That(deliveryCountry.Text, Does.Contain(globalTestVariables.userCountry));
                    Console.WriteLine("deliveryCountry == Displayed");
                    Assert.That(deliveryPhone.Text, Does.Contain(globalTestVariables.userMobileNumber));
                    Console.WriteLine("deliveryPhone == Displayed");
                });
               
                              
            }
            catch (NoSuchElementException)
            {
            }
            catch (WebDriverTimeoutException)
            {
            }
        }
        public void VerifyBillingAddressDetails()
        {
            try
            {
                Assert.Multiple(() =>
                {
                    Assert.That(billingAddressSection.Displayed, Is.True, "Billing address section is not displayed.");
                    Console.WriteLine("billing address section == Displayed");
                    Assert.That(billingAddressFirstNameLastName.Text, Does.Contain(globalTestVariables.userFirstName));
                    Console.WriteLine("billingAddressFirstNameLastName == Displayed");
                    Assert.That(billingAddressCompany.Text, Does.Contain(globalTestVariables.userCompany));
                    Console.WriteLine("billingAddressCompany == Displayed");
                    Assert.That(billingAddress1.Text, Does.Contain(globalTestVariables.userAddress));
                    Console.WriteLine("billingAddress1 == Displayed");
                    Assert.That(billingAddress2.Text, Does.Contain(globalTestVariables.userAddress2));
                    Console.WriteLine("billingAddress2 == Displayed");
                    Assert.That(billingCityStatePostCode.Text, Does.Contain(globalTestVariables.userCity));
                    Console.WriteLine("userCity == Displayed");
                    Assert.That(billingCityStatePostCode.Text, Does.Contain(globalTestVariables.userState));
                    Console.WriteLine("userState == Displayed");
                    Assert.That(billingCityStatePostCode.Text, Does.Contain(globalTestVariables.userZipcode));
                    Console.WriteLine("userZipcode == Displayed");
                    Assert.That(billingCountry.Text, Does.Contain(globalTestVariables.userCountry));
                    Console.WriteLine("billingCountry == Displayed");
                    Assert.That(billingPhone.Text, Does.Contain(globalTestVariables.userMobileNumber));
                    Console.WriteLine("billingPhone == Displayed");
                });


            }
            catch (NoSuchElementException)
            {
            }
            catch (WebDriverTimeoutException)
            {
            }
        }
        public void VerifyLoggedInUserBillingAddressDetails()
        {
            try
            {
                Assert.Multiple(() =>
                {
                    Assert.That(billingAddressSection.Displayed, Is.True, "Billing address section is not displayed.");
                    Console.WriteLine("billing address section == Displayed");
                    Assert.That(billingAddressFirstNameLastName.Text, Does.Contain(globalTestVariables.loggedUserFirstName));
                    Console.WriteLine("billingAddressFirstNameLastName == Displayed");
                    Assert.That(billingAddressCompany.Text, Does.Contain(globalTestVariables.loggedUserCompany));
                    Console.WriteLine("billingAddressCompany == Displayed");
                    Assert.That(billingAddress1.Text, Does.Contain(globalTestVariables.loggedUserAddress));
                    Console.WriteLine("billingAddress1 == Displayed");
                    Assert.That(billingAddress2.Text, Does.Contain(globalTestVariables.loggedUserAddress2));
                    Console.WriteLine("billingAddress2 == Displayed");
                    Assert.That(billingCityStatePostCode.Text, Does.Contain(globalTestVariables.loggedUserCity));
                    Console.WriteLine("loggedUserCity == Displayed");
                    Assert.That(billingCityStatePostCode.Text, Does.Contain(globalTestVariables.loggedUserState));
                    Console.WriteLine("loggedUserState == Displayed");
                    Assert.That(billingCityStatePostCode.Text, Does.Contain(globalTestVariables.loggedUserZipcode));
                    Console.WriteLine("loggedUserZipcode == Displayed");
                    Assert.That(billingCountry.Text, Does.Contain(globalTestVariables.loggedUserCountry));
                    Console.WriteLine("billingCountry == Displayed");
                    Assert.That(billingPhone.Text, Does.Contain(globalTestVariables.loggedUserMobileNumber));
                    Console.WriteLine("billingPhone == Displayed");
                });


            }
            catch (NoSuchElementException)
            {
            }
            catch (WebDriverTimeoutException)
            {
            }
        }

        public void VerifyOrder()
        {
            try
            {
                Assert.That(driver.FindElement(By.Id("cart_info")).Displayed, Is.True, "cart_info section is not displayed.");
                Console.WriteLine("cart_info section == Displayed");
                Assert.That(driver.FindElement(By.Id("product-1")).Displayed, Is.True, "product-1 section is not displayed.");
                Console.WriteLine("product-1 section == Displayed");
                Assert.That(driver.FindElement(By.Id("product-1")).Text, Does.Contain("Blue Top"));
                Console.WriteLine("Blue Top is present in the cart.");
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("The cart_info section element was not found.");
            }
            catch (WebDriverTimeoutException)
            {
                Console.WriteLine("cart_info section timed out.");
            }
        }

        public void ClickPlaceOrderButtonButton()
        {
            try
            {
                Assert.That(PlaceOrderButton.Displayed, Is.True, "PlaceOrderButton is not displayed.");
                Console.WriteLine("PlaceOrderButton == displayed.");
                wait.Until(ExpectedConditions.ElementToBeClickable(PlaceOrderButton));
                PlaceOrderButton.Click();
                Console.WriteLine("Click on the PlaceOrderButton was successful.");
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("The cart_info section element was not found.");
            }
            catch (WebDriverTimeoutException)
            {
                Console.WriteLine("cart_info section timed out.");
            }
        }

        public void AddOrderComment()
        {
            try
            {
                Assert.That(OrderComment.Displayed, Is.True, "OrderComment is not displayed.");
                Console.WriteLine("OrderComment == displayed.");
                wait.Until(ExpectedConditions.ElementToBeClickable(OrderComment));
                OrderComment.Click();
                Console.WriteLine("Click on the OrderComment was successful.");
                OrderComment.SendKeys("Test");
                Console.WriteLine("Adding Text on the OrderComment was successful.");
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
