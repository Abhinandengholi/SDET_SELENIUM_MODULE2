using Magicbricks.PageObjects;
using Magicbricks.Utilities;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Magicbricks.TestScripts
{
   
    [TestFixture]
    internal class MBLoginTest : CoreCodes
    {
        //Asserts


        [Test, Order(1), Category("Regression Test")]
        public void UserLoginTest()
        {
            var fluentwait = Waits(driver);
            string currDir = Directory.GetParent(@"../../../").FullName;
            string logfilepath = currDir + "/Logs/log_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".txt";
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .WriteTo.File(logfilepath, rollingInterval: RollingInterval.Day)
                .CreateLogger();
           
            Thread.Sleep(2000);
            //string? currDir = Directory.GetParent(@"../../../")?.FullName;
            string? excelFilePath = currDir + "/TestData/InputData.xlsx";
            string? sheetName = "Searchdata";
            try
            {
                List<SearchData> excelDataList = ExcelUtils.ReadSignUpExcelData(excelFilePath, sheetName);

                foreach (var excelData in excelDataList)
                {


                    string? email = excelData?.Email;

                    string? phonenumber = excelData?.PhoneNumber;


                    Console.WriteLine($"Email: {email}");

                    MagicBricksHP mbhp = new(driver);
                    var userlogin =fluentwait.Until(d=> mbhp.UserLog());
                    List<string> lstWindow = driver.WindowHandles.ToList();
                    driver.SwitchTo().Window(lstWindow[1]);

                    TakeScreenshot();
                    Assert.That(driver.Url.Contains("login"));

                    LogTestResult("login success", "login test success");
                    test = extent.CreateTest("success");
                    test.Pass("login completed");

                    userlogin.UserDetail(email);
                }

            }
            catch (ArgumentException ex)
            {
                LogTestResult("login test failed", ex.Message);
            }


                // Assert.That(""."")

            }




            //Log.CloseAndFlush();

        }
    }
