using Magicbricks.PageObjects;
using Magicbricks.Utilities;
using OpenQA.Selenium;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magicbricks.TestScripts
{
    internal class LoginPageCheckTest:CoreCodes
    {
        [Test, Order(1), Category("Smoke Test")]
        public void Loginvalidtest()
        {
            var fluentwait = Waits(driver);
            driver.Navigate().GoToUrl("https://accounts.magicbricks.com/userauth/login");
            string currDir = Directory.GetParent(@"../../../").FullName;
            string logfilepath = currDir + "/Logs/log_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".txt";
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .WriteTo.File(logfilepath, rollingInterval: RollingInterval.Day)
                .CreateLogger();
            UserLogin userlog = new UserLogin(driver);
            Log.Information("Login started");
            Thread.Sleep(2000);
            try
            {
                fluentwait.Until(d => userlog);
                userlog.UserDetail("6544355457");
                IWebElement num = driver.FindElement(By.XPath("//div[@id='otpHeader']"));
                string? numtext = num.Text;
                TakeScreenshot();
                Assert.That(numtext, Does.Contain("3-digit verification "));
                LogTestResult("login passed", "login success");
                test = extent.CreateTest("login status-passed");
                test.Pass("Login successful");
            }
            catch (ArgumentException ex)
            {
                TakeScreenshot();
                LogTestResult("Login test failed", "login failed", ex.Message);
                test.Fail("Login test failed");

            }
        }
        [Test, Order(2), Category("Smoke Test")]
        public void LoginEmailTest()
        {
            var fluentwait = Waits(driver);
            driver.Navigate().GoToUrl("https://accounts.magicbricks.com/userauth/login");
            string currDir = Directory.GetParent(@"../../../").FullName;
            string logfilepath = currDir + "/Logs/log_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".txt";
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .WriteTo.File(logfilepath, rollingInterval: RollingInterval.Day)
                .CreateLogger();
            UserLogin userlog = new UserLogin(driver);
            Log.Information("Login started");
            Thread.Sleep(2000);
            try
            {
                fluentwait.Until(d => userlog);
                userlog.UserDetail("avgasdfgh");
                IWebElement num = driver.FindElement(By.XPath("//div[text()='Please enter a valid Email id.']"));
                string? numtext = num.Text;
                TakeScreenshot();
                Assert.That(numtext, Does.Contain("enter a valid"));
                LogTestResult("email details invalid", "email test success");
                test = extent.CreateTest("email test pass");
                test.Pass("email test passed");
            }
            catch (ArgumentException ex)
            {
                TakeScreenshot();
                LogTestResult("email test failed", "login failed", ex.Message);
                test.Fail("email test failed");

            }
        }
        [Test, Order(3), Category("Smoke Test")]
        public void LoginPhonenumberTest()
        {
            var fluentwait = Waits(driver);
            driver.Navigate().GoToUrl("https://accounts.magicbricks.com/userauth/login");
            string currDir = Directory.GetParent(@"../../../").FullName;
            string logfilepath = currDir + "/Logs/log_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".txt";
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .WriteTo.File(logfilepath, rollingInterval: RollingInterval.Day)
                .CreateLogger();
            UserLogin userlog = new UserLogin(driver);
            Log.Information("Login started");
            Thread.Sleep(2000);
            try
            {
                fluentwait.Until(d => userlog);
                userlog.UserDetail("65765");
                IWebElement num = driver.FindElement(By.Id("step1Error"));
                string? numtext = num.Text;
                TakeScreenshot();
                Assert.That(numtext, Does.Contain("should be of max. 15 digits.").Or.Contains("should be of min. 10 digits."));


                LogTestResult("phonenumber details invalid", "ph.number test success");
                test = extent.CreateTest("ph. number test pass");
                test.Pass("ph. number test passed");
            }
            catch (ArgumentException ex)
            {
                TakeScreenshot();
                LogTestResult("ph. number test failed", "login failed", ex.Message);
                test.Fail("ph. number  test failed");

            }

        }
    }
}
