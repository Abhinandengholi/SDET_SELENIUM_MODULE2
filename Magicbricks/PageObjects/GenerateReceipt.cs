using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magicbricks.PageObjects
{
    internal class GenerateReceipt

    {
        public IWebDriver driver;
        public GenerateReceipt(IWebDriver? driver)
        {
            this.driver = driver ?? throw new ArgumentException(nameof(driver));
            PageFactory.InitElements(driver, this);
        }
        [CacheLookup]
        [FindsBy(How = How.Id, Using = "rentAmount")]
        private IWebElement? RentAmount { get; set; }

        [CacheLookup]
        [FindsBy(How = How.Id, Using = "rentedPropertyAddress")]
        private IWebElement? PropertyAddress { get; set; }

        [CacheLookup]
        [FindsBy(How = How.Id, Using = "landlordName")]
        private IWebElement? LandOwnerName { get; set; }

        [CacheLookup]
        [FindsBy(How = How.Id, Using = "tenantName")]
        private IWebElement? Name { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id='email']")]
        private IWebElement? EmaiL { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id='tenantMobileNumber']")]
        private IWebElement? PhoneNumber { get; set; }
        
        [FindsBy(How = How.XPath, Using = "//input[@id='receiptStartDate']")]
        [CacheLookup]
        private IWebElement? Clickstrtdate { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id='receiptEndDate']")]
        private IWebElement? Clickenddate { get; set; }
        [FindsBy(How = How.XPath, Using = "(//span[@class='flatpickr-day '])[2]")]
        private IWebElement?   Selectstrtdate { get; set; }

        [FindsBy(How = How.XPath, Using = "(//span[@class='flatpickr-day '])[50]")]
        private IWebElement? Selectenddate { get; set; }
        [FindsBy(How = How.XPath, Using = "//label[@for='tnc-checkbox']")]
        private IWebElement? checkbx { get; set; }
        
        [FindsBy(How = How.XPath, Using = "//div[@class='mb-form__col text-right']//following::a[text()='Generate Rent Receipt Now']")]
        private IWebElement? generatecheckbx { get; set; }

        //Act
        public void Receiptdeatils(string fullname, string email, string phonenumber,string rentamount,string propaddress,string landownername )
        {
            RentAmount?.Click();
            RentAmount?.SendKeys(rentamount);
            PropertyAddress?.Click();
            PropertyAddress?.SendKeys(propaddress);
            LandOwnerName?.Click();
            LandOwnerName?.SendKeys(landownername);
            Clickstrtdate?.Click();
            Selectstrtdate?.Click();
            Clickenddate?.Click();
            Selectenddate?.Click();
            Name?.Click();
            Name?.SendKeys(fullname);
            PhoneNumber?.Click();
            PhoneNumber?.SendKeys(phonenumber);
            EmaiL?.Click();
            EmaiL?.SendKeys(email);
            checkbx?.Click();
            generatecheckbx?.Click();   

        }
    }
}
