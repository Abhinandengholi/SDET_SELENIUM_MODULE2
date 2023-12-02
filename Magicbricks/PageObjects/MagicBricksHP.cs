using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Magicbricks.Utilities;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace Magicbricks.PageObjects
{
    internal class MagicBricksHP
    {
        public IWebDriver driver;
        public MagicBricksHP(IWebDriver? driver)
        {
            this.driver = driver ?? throw new ArgumentException(nameof(driver));
            PageFactory.InitElements(driver, this);
        }
        //Arrange
        [FindsBy(How = How.XPath, Using = "//input[@class='mb-search__input']")]
        private IWebElement? LocationInput { get; set; }


        [FindsBy(How = How.XPath, Using = "//span[@id='buy_proertyTypeDefault']")]
        private IWebElement? proprtyselct { get; set; }

        [FindsBy(How = How.XPath, Using = "//label[@id='10002_10003_10021_10022']")]
        private IWebElement? flatSelect { get; set; }


        [FindsBy(How = How.XPath, Using = "//span[@id='rent_budget_lbl']")]
        private IWebElement? Budgetselct { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[text()='₹10 Lac']")]
        private IWebElement? SpecifyBudget { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@id='maxBhkIndex_10']")]
        private IWebElement? SpecifyBudget1 { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='mb-search__btn']")]
        private IWebElement? SearchButton { get; set; }


        [FindsBy(How = How.XPath, Using = "//a[text()='Login']")]
        private IWebElement? Logindrop { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[@class='mb-login__drop-cta' and contains(text(),'Login')]")]
        private IWebElement? Loginclick { get; set; }

        [FindsBy(How = How.LinkText, Using = "Sign Up")]
        private IWebElement? SignUp { get; set; }
        [FindsBy(How = How.XPath, Using = "//li[@class='js-menu-container'][4]")]
        private IWebElement? PropertyService { get; set; }
        [FindsBy(How = How.XPath, Using = "//a[text()='Generate Rent Receipt']")]
        private IWebElement? Rentreceipt { get; set; }
       
        [FindsBy(How = How.XPath, Using = "//a[text()='Post Property']")]
        private IWebElement? PostPropertyclick { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[text()='Chennai']//preceding::ul[@class='city-drop-link-group']")]
        private IWebElement? Specificlocationclick { get; set; }
      
        [FindsBy(How = How.XPath, Using = "//div[@class='mb-header__main__city js-menu-container']")]
        private IWebElement? Locationclick { get; set; }
       
        [FindsBy(How = How.XPath, Using = "//div[@class='drop-call']//following::a[text()='Help Center']")]
        private IWebElement? Helpcenter { get; set; }

        [FindsBy(How = How.XPath, Using = "//li[@class='js-menu-container']//following::a[text()='Help']")]
        private IWebElement? Help { get; set; }

        //Act
        public Property Search(string scity)
        {
            LocationInput?.Click();

            IWebElement close = driver.FindElement(By.ClassName("mb-search__tag-close"));
            close?.Click();
            LocationInput?.SendKeys(scity);
            Thread.Sleep(2000);
            IWebElement cityclick = driver.FindElement(By.XPath("//span[contains(text(),'kottarakkara')]"));
            cityclick.Click();
            Thread.Sleep(3000);
            proprtyselct?.Click();
            flatSelect?.Click();
            Budgetselct?.Click();
            SpecifyBudget?.Click();
            SpecifyBudget1?.Click();
            SearchButton?.Click();
            return new Property(driver);
        }
        public Register Login()
        {
            Logindrop?.Click();
            Thread.Sleep(3000);
            SignUp?.Click();
            return new Register(driver);
        }
        public UserLogin UserLog()
        {
            Logindrop?.Click();
            Loginclick?.Click();
            return new UserLogin(driver);

        }
        public GenerateReceipt SelectService()
        {
            //PropertyService?.Click();
            Rentreceipt?.Click();

            return new GenerateReceipt(driver);

        }
        public void SellProp()
        {
            PostPropertyclick?.Click();

        }
        public void Locationcheck()
        {
            
            Locationclick?.Click();
            Specificlocationclick?.Click();
            
        }
        
        
        public Helpcenter  Helpclick()
        {
            Help?.Click();
            Helpcenter?.Click();
            return new Helpcenter(driver);
        }
    }
       

}

