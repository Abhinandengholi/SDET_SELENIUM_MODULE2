using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magicbricks.PageObjects
{
    internal class MagicBricksHP
    {
        IWebDriver driver;
        public MagicBricksHP(IWebDriver? driver)
        {
            this.driver = driver ?? throw new ArgumentException(nameof(driver));
            PageFactory.InitElements(driver, this);
        }
        //Arrange
        [FindsBy(How = How.XPath, Using = "//div[@class='mb-search__location__tag-wrap forFlexView']")]
        public IWebElement? Search { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[text()='Login']")]
        public IWebElement? Logindrop { get; }
        
        [FindsBy(How = How.XPath, Using = "//a[@class='mb-login__drop-cta']")]
        public IWebElement? LoginClick{ get; }


    }
}
