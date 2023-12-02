using Magicbricks.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Magicbricks.PageObjects
{
    internal class SpecificProperty
    {
        IWebDriver driver;
        public SpecificProperty (IWebDriver? driver)
        {
            this.driver = driver ?? throw new ArgumentException(nameof(driver));
            PageFactory.InitElements(driver, this);
        }
        //Arrange
        [FindsBy(How = How.XPath, Using = "(//a[text()='Contact Owner'])[1]")]
        private IWebElement? Booksitevisit { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id='userName']")]
        private IWebElement? Name { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id='userEmail']")]
        private IWebElement? EmaiL { get; set; }
        [FindsBy(How = How.XPath, Using = "//input[@id='userMobile']")]
        private IWebElement? PhoneNumber{ get; set; }

        [FindsBy(How = How.XPath, Using = "//button[text()='Continue']")]
        private IWebElement? Continue { get; set; }
        //Act
        public void Booking(string fullname, string email, string phonenumber)
        {
            
            Thread.Sleep(5000);
            Booksitevisit?.Click();
            Thread.Sleep(3000);     
            Name?.SendKeys(fullname);
            EmaiL?.SendKeys(email);
            PhoneNumber?.SendKeys(phonenumber);
           Continue?.Click();

        }

    }
}
