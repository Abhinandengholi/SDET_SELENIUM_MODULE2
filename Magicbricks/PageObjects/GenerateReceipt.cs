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
        [FindsBy(How = How.Id, Using = "rentAmount")]
        public IWebElement? RentAmount { get; set; }


        [FindsBy(How = How.Id, Using = "rentedPropertyAddress")]
        public IWebElement? PropertyAddress { get; set; }


        [FindsBy(How = How.Id, Using = "landlordName")]
        public IWebElement? LandOwnerName { get; set; }

        [FindsBy(How = How.Id, Using = "tenantName")]
        public IWebElement? Name { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id='email']")]
        public IWebElement? EmaiL { get; set; }

        

        [FindsBy(How = How.XPath, Using = "//input[@id='tenantMobileNumber']")]
        public IWebElement? PhoneNumber { get; set; }
        
        [FindsBy(How = How.XPath, Using = "//input[@id='receiptStartDate']")]
        public IWebElement? Clickstrtdate { get; set; }



        [FindsBy(How = How.XPath, Using = "//input[@id='receiptEndDate']")]
        public IWebElement? Clickenddate { get; set; }
        [FindsBy(How = How.XPath, Using = "(//span[@class='flatpickr-day '])[2]")]
        public IWebElement?   Selectstrtdate { get; set; }



        [FindsBy(How = How.XPath, Using = "(//span[@class='flatpickr-day '])[50]")]
        public IWebElement? Selectenddate { get; set; }
        [FindsBy(How = How.XPath, Using = "//label[@for='tnc-checkbox']")]
        public IWebElement? checkbx { get; set; }
        
        [FindsBy(How = How.XPath, Using = "//div[@class='mb-form__col text-right']//following::a[text()='Generate Rent Receipt Now']")]
        public IWebElement? generatecheckbx { get; set; }
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
