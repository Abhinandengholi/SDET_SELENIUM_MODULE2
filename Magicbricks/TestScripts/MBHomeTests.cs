using Magicbricks.PageObjects;
using Magicbricks.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magicbricks.TestScripts
{
    [TestFixture]
    internal class MBHomeTests:CoreCodes
    {

        [Test, Order(1), Category("Smoke Test")]

        public void locationtest()
        {
            var fluentwait = Waits(driver);
            string currDir = Directory.GetParent(@"../../../").FullName;
            string logfilepath = currDir + "/Logs/log_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".txt";
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .WriteTo.File(logfilepath, rollingInterval: RollingInterval.Day)
                .CreateLogger();
            try
            {
                var mbhp = new MagicBricksHP(driver);
                mbhp.Locationcheck();
                Assert.That(driver.Url.Contains("residential"));
                LogTestResult("location", "input successfully");
                test = extent.CreateTest("Input success");
                test.Pass("Input location");
            }
            catch (AssertionException ex)
            {
                LogTestResult("Location input failed", ex.Message);
            }
        }

            [Test, Order(2), Category("Smoke Test")]

            public void Postpropertytest()
            {
                var fluentwait = Waits(driver);
                string currDir = Directory.GetParent(@"../../../").FullName;
                string logfilepath = currDir + "/Logs/log_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".txt";
                Log.Logger = new LoggerConfiguration()
                    .WriteTo.Console()
                    .WriteTo.File(logfilepath, rollingInterval: RollingInterval.Day)
                    .CreateLogger();
                try
                {
                    var mbhp = new MagicBricksHP(driver);

                    IWebElement service = driver.FindElement(By.XPath("//li[@class='js-menu-container'][2]"));
                    Actions actions = new Actions(driver);
                    actions.MoveToElement(service).Build().Perform();

                    fluentwait.Until(d => mbhp);
                    mbhp.SellProp();
                    List<string> lstWindow = driver.WindowHandles.ToList();
                    driver.SwitchTo().Window(lstWindow[1]);
                    TakeScreenshot();
                    Assert.That(driver.Title.Contains("Post Free Property Ads"));

                    LogTestResult("Property posting", "Post property success");
                    test = extent.CreateTest("success");
                    test.Pass("Selling property completed");
                }
                catch (AssertionException ex)
                {
                    LogTestResult("Post property  test failed", ex.Message);
                }


            }

        [Test, Order(3), Category("Smoke Test")]

        public void Helpsupporttest()
        {
            var fluentwait = Waits(driver);
            string currDir = Directory.GetParent(@"../../../").FullName;
            string logfilepath = currDir + "/Logs/log_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".txt";
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .WriteTo.File(logfilepath, rollingInterval: RollingInterval.Day)
                .CreateLogger();
            try
            {
                var mbhp = new MagicBricksHP(driver);

                IWebElement service = driver.FindElement(By.XPath("//a[text()='Help']"));
                Actions actions = new Actions(driver);
                actions.MoveToElement(service).Build().Perform();

                fluentwait.Until(d => mbhp);
                mbhp.Helpclick();
                List<string> lstWindow = driver.WindowHandles.ToList();
                driver.SwitchTo().Window(lstWindow[1]);
                TakeScreenshot();
                Assert.That(driver.Url.Contains("help"));

                LogTestResult("help", "help support success");
                test = extent.CreateTest("success");
                test.Pass("help support completed");
            }
            catch (AssertionException ex)
            {
                LogTestResult("help support  test failed", ex.Message);
            }


        }

    }
}
