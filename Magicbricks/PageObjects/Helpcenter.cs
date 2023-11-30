using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
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
        public Helpcenter(IWebDriver driver)
        {
            this.driver = driver??throw new ArgumentException(nameof(driver));
            PageFactory.InitElements(driver, this);
        }
        //Arrange
        [FindsBy(How = How.XPath, Using = "//label[text()='Agent']")]
        private IWebElement? UserType { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@class='btn__get-answer']")]
        private IWebElement? SelectGetAnswer { get; set; }

        [FindsBy(How = How.Id, Using = "searchContentDiv")]
        private IWebElement? TextField { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@class='home-search___submit']")]
        private IWebElement? Selectbutton { get; set; }
        //Act
        public void SelectingUser(string question)
        {
            UserType?.Click();
            SelectGetAnswer?.Click();
            TextField?.SendKeys(question);
            Selectbutton?.Click();
            
        }
        

    }
}
