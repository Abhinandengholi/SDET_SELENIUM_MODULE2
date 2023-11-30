using Magicbricks.PageObjects;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Magicbricks.Utilities;

namespace Magicbricks.TestScripts
{
    internal class HelpCenterTest : CoreCodes
    {
        [Test, Category("Regression Test")]

        public void HelpCntrTest()
        {
            var fluentwait = Waits(driver);
            string currDir = Directory.GetParent(@"../../../").FullName;
            string logfilepath = currDir + "/Logs/log_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".txt";
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .WriteTo.File(logfilepath, rollingInterval: RollingInterval.Day)
                .CreateLogger();
            //string? currDir = Directory.GetParent(@"../../../")?.FullName;
            string? excelFilePath = currDir + "/TestData/InputData.xlsx";
            string? sheetName = "Searchdata";

            List<SearchData> excelDataList = ExcelUtils.ReadSignUpExcelData(excelFilePath, sheetName);

            foreach (var excelData in excelDataList)
            {
                try
                {
                    string? question = excelData?.QuestionInput;
                    Console.WriteLine($"QuestionIn: {question}");
                    var mbhp = new MagicBricksHP(driver);
                    IWebElement service = driver.FindElement(By.XPath("//a[text()='Help']"));
                    Actions actions = new Actions(driver);
                    actions.MoveToElement(service).Build().Perform();
                    var helpcntr = fluentwait.Until(d => mbhp.Helpclick());
                    List<string> lstWindow = driver.WindowHandles.ToList();
                    driver.SwitchTo().Window(lstWindow[1]);
                    TakeScreenshot();
                    helpcntr.SelectingUser(question);
                    List<string> lstWindow1 = driver.WindowHandles.ToList();
                    driver.SwitchTo().Window(lstWindow1[2]);
                    TakeScreenshot();
                    Assert.That(driver.Url.Contains("category-content-detail"));

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
}
    

