using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Magicbricks.PageObjects
{
    internal class Register
    {
        IWebDriver driver;
        public Register(IWebDriver? driver)
        {
            this.driver = driver ?? throw new ArgumentException(nameof(driver));
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//input[@id='ubiusertype2']")]
        private IWebElement? Checkbox { get; set; }

        [CacheLookup]
        [FindsBy(How = How.Id, Using = "ubifname")]
        private IWebElement? Name { get; set; }

        [CacheLookup]
        [FindsBy(How = How.Id, Using = "ubiemail")]
        private IWebElement? EmaiL { get; set; }
        
        [CacheLookup]
        [FindsBy(How = How.Id, Using = "ubipass")]
        private IWebElement? Password { get; set; }

        [CacheLookup]
        [FindsBy(How = How.Id, Using = "ubimobile1")]
        private IWebElement? PhoneNumber { get; set; }


        [FindsBy(How = How.XPath, Using = "//label[contains(text(),'I agree to Magicbricks')]")]
        private IWebElement? AgreeCheckbox { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[@class='mui-btn mui-btn--primary']")]
        private IWebElement? SignupButton { get; set; }
        public void Regstr(string fullname, string email,string password, string phonenumber)
        {
            Thread.Sleep(3000);
            Checkbox?.Click();
            Name?.SendKeys(fullname);
            EmaiL?.SendKeys(email);
            Password?.SendKeys(password);
            PhoneNumber?.SendKeys(phonenumber);
            AgreeCheckbox?.Click();
            Thread.Sleep(3000);
            SignupButton?.Click();
        }
    }
}
