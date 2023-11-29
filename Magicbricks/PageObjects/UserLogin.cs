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

        [FindsBy(How = How.XPath, Using = "//input[@class='m-login__input' and @id='emailOrMobile']")]
        public IWebElement? Emailormobfield { get; set; }

        [FindsBy(How = How.Id, Using = "btnStep1")]
        public IWebElement? ClickNext { get; set; }
        public void UserDetail(string email)
        {
            Thread.Sleep(3000);
            Emailormobfield?.Click();
            Emailormobfield?.SendKeys(email);
            ClickNext?.Click();
        }
    }
        

}
