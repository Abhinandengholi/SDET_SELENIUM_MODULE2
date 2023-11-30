using Magicbricks.Utilities;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magicbricks.PageObjects
{
    internal class Property
    {
        IWebDriver driver;
        public Property(IWebDriver? driver)
        {
            this.driver = driver ?? throw new ArgumentException(nameof(driver));
            PageFactory.InitElements(driver, this);
        }
        
        [FindsBy(How = How.XPath, Using = "//div[@class='mb-srp__list'][6]")]
        private IWebElement? SelectProperty { get; set; }

        public SpecificProperty SelectedProp()
        {
            
            CoreCodes.ScrollIntoView(driver,SelectProperty);
            Thread.Sleep(3000);
            SelectProperty?.Click();
            return new SpecificProperty(driver);
        }
    }
}

