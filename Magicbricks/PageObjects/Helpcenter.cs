using Magicbricks.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magicbricks.PageObjects
{
    internal class Helpcenter
    {
        IWebDriver? driver;
        //DefaultWait<IWebDriver> wait;
        public Helpcenter(IWebDriver driver)
        {
            this.driver = driver??throw new ArgumentException(nameof(driver));
            PageFactory.InitElements(driver, this);
            //wait = new DefaultWait<IWebDriver>(driver);
            //wait.PollingInterval = TimeSpan.FromMilliseconds(100);
            //wait.Timeout = TimeSpan.FromSeconds(100);
            //wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
        }
        //Arrange
       
        [FindsBy(How = How.XPath, Using = "//input[@id='searchContentInput']")]
        private IWebElement? TextField { get; set; }
       
      
        [FindsBy(How = How.XPath, Using = "//a[@id='userPersonaPopupCloseAnchor']")]
        private IWebElement? Exitclick { get; set; }
        [FindsBy(How = How.XPath, Using = "(//li[@class='ui-menu-item']//child::div[contains(text(),'How')])[position()=1]")]
        private IWebElement? Selectqstn { get; set; }
        
        //Act
        public void SelectingUser(string question)
        {
            
            Exitclick?.Click();
            TextField?.Click();           
            TextField?.SendKeys(question);
           
            TextField?.Click();
            Thread.Sleep(2000);
            
           
            Selectqstn?.Click();     
            
            
        }
        

    }
}
