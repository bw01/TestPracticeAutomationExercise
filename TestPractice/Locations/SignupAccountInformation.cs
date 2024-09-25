using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestPractice.Configuration;

namespace TestPractice.Locations
{
    public class signupAccountInformation
    {
        private IWebDriver driver;
        private WebDriverWait wait;
        private globalTestVariables globalTestVariables;


        // Constructor to initialize the driver
        public signupAccountInformation(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
        }

        // Page elements

            //Account Information Section
        private IWebElement TitleMrButton => driver.FindElement(By.XPath("//input[@id='id_gender1']"));
        private IWebElement AccountInformationNameField => driver.FindElement(By.XPath("//input[@id='name']"));
        private IWebElement AccountInformationPasswordField => driver.FindElement(By.XPath("//input[@id='password']"));
        //private IWebElement AccountInformationDaysField => driver.FindElement(By.XPath("//select[@id='days']"));
        //private IWebElement AccountInformationMonthField => driver.FindElement(By.XPath("//select[@id='months']"));
        //private IWebElement AccountInformationYearField => driver.FindElement(By.XPath("//select[@id='years']"));
        private SelectElement AccountInformationDaysField => new SelectElement(driver.FindElement(By.XPath("//select[@id='days']")));
        private SelectElement AccountInformationMonthField => new SelectElement(driver.FindElement(By.XPath("//select[@id='months']")));
        private SelectElement AccountInformationYearField => new SelectElement(driver.FindElement(By.XPath("//select[@id='years']")));

        private IWebElement AccountInformationNewsletterButton => driver.FindElement(By.XPath("//label[contains(.,'Sign up for our newsletter!')]"));
        private IWebElement AccountInformationSpecialOffersButton => driver.FindElement(By.XPath("//input[@id='optin']"));

            //Address Information Section
        private IWebElement AddressInformationFirstName => driver.FindElement(By.XPath("//input[@id='first_name']"));

        private IWebElement AddressInformationLastName => driver.FindElement(By.XPath("//input[@id='last_name']"));

        private IWebElement AddressInformationCompany => driver.FindElement(By.XPath("//input[@id='company']"));

        private IWebElement AddressInformationAddress1 => driver.FindElement(By.XPath("//input[@id='address1']"));

        private IWebElement AddressInformationAddress2 => driver.FindElement(By.XPath("//input[@id='address2']"));

        private SelectElement AddressInformationCountry => new SelectElement(driver.FindElement(By.XPath("//select[@id='country']")));

        //private IWebElement AddressInformationCountry => driver.FindElement(By.XPath("//select[@id='country']"));

        private IWebElement AddressInformationState => driver.FindElement(By.XPath("//input[@id='state']"));

        private IWebElement AddressInformationCity => driver.FindElement(By.XPath("//input[@id='city']"));

        private IWebElement AddressInformationZipcode => driver.FindElement(By.XPath("//input[@id='zipcode']"));

        private IWebElement AddressInformationMobileNumber => driver.FindElement(By.XPath("//input[@id='mobile_number']"));

        private IWebElement AddressInformationAccountCreatedText => driver.FindElement(By.XPath("//*[@id=\"form\"]/div/div/div"));

        private IWebElement AddressInformationCreateAccountButton => driver.FindElement(By.XPath("//button[@type='submit']"));


        // Page methods

            //Account Information Section
            
        public void ClickTitleMrButton()
        {
            Assert.That(TitleMrButton.Displayed, Is.True, "TitleMrButton is not displayed as expected.");
            wait.Until(ExpectedConditions.ElementToBeClickable(TitleMrButton));
            TitleMrButton.Click();
        }

        public void FillAccountInformationNameField()
        {
            Assert.That(AccountInformationNameField.Displayed, Is.True, "AccountInformationNameField is not displayed as expected.");
            wait.Until(ExpectedConditions.ElementToBeClickable(AccountInformationNameField));
            AccountInformationNameField.Click();
            AccountInformationNameField.SendKeys("");
        }

        public void FillAccountInformationPasswordField()
        {
            globalTestVariables globalTestVariables = new globalTestVariables();

            Assert.That(AccountInformationPasswordField.Displayed, Is.True, "AccountInformationPasswordField is not displayed as expected.");
            wait.Until(ExpectedConditions.ElementToBeClickable(AccountInformationPasswordField));
            AccountInformationPasswordField.Click();
            AccountInformationPasswordField.SendKeys(globalTestVariables.userPassword); //add configuration
        }

        public void FillAccountInformationDaysField()
        {
            Assert.That(driver.FindElement(By.XPath("//select[@id='days']")).Displayed, Is.True, "//select[@id='days'] is not displayed as expected.");
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//select[@id='days']")));
            AccountInformationDaysField.SelectByText("1");            
        }

        public void FillAccountInformationMonthField()
        {
            Assert.That(driver.FindElement(By.XPath("//select[@id='months']")).Displayed, Is.True, "//select[@id='months'] is not displayed as expected.");
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//select[@id='months']")));
            AccountInformationMonthField.SelectByText("January");
        }

        public void FillAccountInformationYearField()
        {
            Assert.That(driver.FindElement(By.XPath("//select[@id='years']")).Displayed, Is.True, "//select[@id='years'] is not displayed as expected.");
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//select[@id='years']")));
            AccountInformationYearField.SelectByText("1990");
        }

        public void ClickAccountInformationNewsletterButton()
        {
            Assert.That(AccountInformationNewsletterButton.Displayed, Is.True, "AccountInformationNewsletterButton is not displayed as expected.");
            wait.Until(ExpectedConditions.ElementToBeClickable(AccountInformationNewsletterButton));
            AccountInformationNewsletterButton.Click();
        }

        public void ClickAccountInformationSpecialOffersButton()
        {
            Assert.That(AccountInformationSpecialOffersButton.Displayed, Is.True, "AccountInformationSpecialOffersButton is not displayed as expected.");
            wait.Until(ExpectedConditions.ElementToBeClickable(AccountInformationSpecialOffersButton));
            AccountInformationSpecialOffersButton.Click();
        }

            //Address Information Section

        public void FillAddressInformationFirstName()
        {
            globalTestVariables globalTestVariables = new globalTestVariables();
           
            Assert.That(AddressInformationFirstName.Displayed, Is.True, "AddressInformationFirstName is not displayed as expected.");
            wait.Until(ExpectedConditions.ElementToBeClickable(AddressInformationFirstName));
            AddressInformationFirstName.Click();
            AddressInformationFirstName.SendKeys(globalTestVariables.userFirstName);
        }

        public void FillAddressInformationLastName()
        {
            globalTestVariables globalTestVariables = new globalTestVariables();

            Assert.That(AddressInformationLastName.Displayed, Is.True, "AddressInformationLastName is not displayed as expected.");
            wait.Until(ExpectedConditions.ElementToBeClickable(AddressInformationLastName));
            AddressInformationLastName.Click();
            AddressInformationLastName.SendKeys(globalTestVariables.userLastName);
        }

        public void FillAddressInformationCompany()
        {
            globalTestVariables globalTestVariables = new globalTestVariables();
            
            Assert.That(AddressInformationCompany.Displayed, Is.True, "AddressInformationCompany is not displayed as expected.");
            wait.Until(ExpectedConditions.ElementToBeClickable(AddressInformationCompany));
            AddressInformationCompany.Click();
            AddressInformationCompany.SendKeys(globalTestVariables.userCompany);
        }

        public void FillAddressInformationAddress1()
        {
            globalTestVariables globalTestVariables = new globalTestVariables();

            Assert.That(AddressInformationAddress1.Displayed, Is.True, "AddressInformationAddress1 is not displayed as expected.");
            wait.Until(ExpectedConditions.ElementToBeClickable(AddressInformationAddress1));
            AddressInformationAddress1.Click();
            AddressInformationAddress1.SendKeys(globalTestVariables.userAddress);
        }
        public void FillAddressInformationAddress2()
        {
            globalTestVariables globalTestVariables = new globalTestVariables();

            Assert.That(AddressInformationAddress2.Displayed, Is.True, "AddressInformationAddress2 is not displayed as expected.");
            wait.Until(ExpectedConditions.ElementToBeClickable(AddressInformationAddress2));
            AddressInformationAddress2.Click();
            AddressInformationAddress2.SendKeys(globalTestVariables.userAddress2);
        }

        public void FillAddressInformationCountry()
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//select[@id='country']")));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//select[@id='country']")));
            AddressInformationCountry.SelectByText("United States");
        }

        public void FillAddressInformationState()
        {
            globalTestVariables globalTestVariables = new globalTestVariables();

            Assert.That(AddressInformationState.Displayed, Is.True, "AddressInformationState is not displayed as expected.");
            wait.Until(ExpectedConditions.ElementToBeClickable(AddressInformationState));
            AddressInformationState.Click();
            AddressInformationState.SendKeys(globalTestVariables.userState);
        }
        public void FillAddressInformationCity()
        {
            globalTestVariables globalTestVariables = new globalTestVariables();

            Assert.That(AddressInformationCity.Displayed, Is.True, "AddressInformationCity is not displayed as expected.");
            wait.Until(ExpectedConditions.ElementToBeClickable(AddressInformationCity));
            AddressInformationCity.Click();
            AddressInformationCity.SendKeys(globalTestVariables.userCity);
        }
        public void FillAddressInformationZipcode()
        {
            globalTestVariables globalTestVariables = new globalTestVariables();

            Assert.That(AddressInformationZipcode.Displayed, Is.True, "AddressInformationZipcode is not displayed as expected.");
            wait.Until(ExpectedConditions.ElementToBeClickable(AddressInformationZipcode));
            AddressInformationZipcode.Click();
            AddressInformationZipcode.SendKeys(globalTestVariables.userZipcode);
        }
        public void FillAddressInformationMobileNumber()
        {
            globalTestVariables globalTestVariables = new globalTestVariables();

            Assert.That(AddressInformationMobileNumber.Displayed, Is.True, "AddressInformationMobileNumber is not displayed as expected.");
            wait.Until(ExpectedConditions.ElementToBeClickable(AddressInformationMobileNumber));
            AddressInformationMobileNumber.Click();
            AddressInformationMobileNumber.SendKeys(globalTestVariables.userMobileNumber);
        }

        public void CheckAccountCreatedIsVisible()
        {
            try
            {
                Assert.That(AddressInformationAccountCreatedText.Displayed, Is.True, "AddressInformationAccountCreatedText is not displayed as expected.");
                Console.WriteLine("AddressInformationAccountCreatedText is visible.");
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("The AddressInformationAccountCreatedText element was not found.");
            }
            catch (WebDriverTimeoutException)
            {
                Console.WriteLine("AddressInformationAccountCreatedText timed out.");
            }
        }
        public void ClickAddressInformationCreateAccountButton()
        {
            Assert.That(AddressInformationCreateAccountButton.Displayed, Is.True, "AddressInformationCreateAccountButton is not displayed as expected.");
            wait.Until(ExpectedConditions.ElementToBeClickable(AddressInformationCreateAccountButton));
            AddressInformationCreateAccountButton.Click();
        }
        public void registerAccount()
        {
            ClickTitleMrButton();
            FillAccountInformationNameField();
            FillAccountInformationPasswordField();
            FillAccountInformationDaysField();
            FillAccountInformationMonthField();
            FillAccountInformationYearField();
            ClickAccountInformationNewsletterButton();
            ClickAccountInformationSpecialOffersButton();
            FillAddressInformationFirstName();
            FillAddressInformationLastName();
            FillAddressInformationCompany();
            FillAddressInformationAddress1();
            FillAddressInformationAddress2();
            FillAddressInformationCountry();
            FillAddressInformationState();
            FillAddressInformationCity();
            FillAddressInformationZipcode();
            FillAddressInformationMobileNumber();
            ClickAddressInformationCreateAccountButton();
            CheckAccountCreatedIsVisible();
        }

    }
}
