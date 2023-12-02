using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magicbricks.PageObjects
{
    internal class UserLogin
    {

        IWebDriver driver;
        public UserLogin(IWebDriver? driver)
        {
            this.driver = driver ?? throw new ArgumentException(nameof(driver));
            PageFactory.InitElements(driver, this);
        }
        //Arrange
        [FindsBy(How = How.XPath, Using = "//input[@class='m-login__input' and @id='emailOrMobile']")]
        private IWebElement? Emailormobfield { get; set; }

        [CacheLookup]
        [FindsBy(How = How.Id, Using = "btnStep1")]
        private IWebElement? ClickNext { get; set; }
        //Act
        public void UserDetail(string email)
        {
           
            Emailormobfield?.Click();
            Emailormobfield?.SendKeys(email);
            ClickNext?.Click();
        }
    }
        

}
