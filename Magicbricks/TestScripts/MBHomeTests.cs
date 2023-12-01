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
                TakeScreenshot();
                Assert.That(driver.Url.Contains("residential"));
                LogTestResult("location input test passed", "Location input passed");
                test = extent.CreateTest("Location nput test success");
                test.Pass("Location input test passed");
            }
            catch (AssertionException ex)
            {
                TakeScreenshot();
                LogTestResult("Location input test failed", "Location input test failed", ex.Message);
                test.Fail("Location input test failed");
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

                   
                LogTestResult("Post property test passed", "Post property test passed");
                test = extent.CreateTest("Post property test passed");
                test.Pass("Selling property test  passed");
            }
                catch (AssertionException ex)
                {
                    

                TakeScreenshot();
                LogTestResult("Post property failed", "Post property  test failed", ex.Message);
                test.Fail("Post property test failed");
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

                LogTestResult("Help supports test", "Help support test success");
                test = extent.CreateTest("Help supports test passed");
                test.Pass("Help support  passed");
            }
            catch (AssertionException ex)
            {
               
                TakeScreenshot();
                LogTestResult("Help support  failed", "Help support test failed", ex.Message);
                test.Fail("Help support test failed");
            }


        }
        [Test, Order(4), Category("Smoke Test")]
        public void CheckAllLinksStatusTest()
        {
            var fluentwait = Waits(driver);
            string currDir = Directory.GetParent(@"../../../").FullName;
            string logfilepath = currDir + "/Logs/log_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".txt";
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .WriteTo.File(logfilepath, rollingInterval: RollingInterval.Day)
                .CreateLogger();
            Log.Information("MagicBricks All Links tested");
            List<IWebElement> allLinks = driver.FindElements(By.TagName("a")).ToList();
            try
            {
                foreach (var link in allLinks)
                {
                    string url = link.GetAttribute("href");
                    if (url == null)
                    {
                        Console.WriteLine("URL is null");
                        continue;
                    }
                    else
                    {
                        bool isworking = CheckLinkStatus(url);
                        if (isworking)
                        {
                            Console.WriteLine(url + "is working");
                        }
                        else
                        {
                            Console.WriteLine(url + "is not working");
                        }
                    }
                }
                LogTestResult("MagicBricks All Links test", "MagicBricks All Links test success");
                test = extent.CreateTest("MagicBricks All Links test passed");
                test.Pass("MagicBricks All Linkstest passed");
            }
            catch (AssertionException ex)
            {
                TakeScreenshot();
                LogTestResult("MagicBricks All Links test failed", "MagicBricks All Links test failed", ex.Message);
                test.Fail("MagicBricks All Links test failed");
            }
        }
    }
}

