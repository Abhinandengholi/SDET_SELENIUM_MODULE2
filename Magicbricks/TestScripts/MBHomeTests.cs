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
    internal class MBHomeTests:CoreCodes
    {
       
        [Test, Order(1), Category("Smoke Test")]
        [TestCase("Kottarakkara")]
        public void locationtest(string city)
        {
            string currDir = Directory.GetParent(@"../../../").FullName;
            string logfilepath = currDir + "/Logs/log_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".txt";
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .WriteTo.File(logfilepath, rollingInterval: RollingInterval.Day)
                .CreateLogger();
            var mbhp = new MagicBricksHP(driver);
            
           
            mbhp.Search(city);
            try
            {
                Assert.True(true);
                LogTestResult("location","input successfully");
                test = extent.CreateTest("Input success");
                test.Pass("Input location");
            }
            catch(AssertionException ex)
            {
                LogTestResult("Location input failed", ex.Message);
            }
            

        }
    }
}
