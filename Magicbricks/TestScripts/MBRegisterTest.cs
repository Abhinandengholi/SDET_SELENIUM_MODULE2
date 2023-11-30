using Magicbricks.PageObjects;
using Magicbricks.Utilities;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magicbricks.TestScripts
{
 
     [TestFixture]
    internal class MBRegisterTest:CoreCodes
    {
        //Asserts


        [Test, Order(1), Category("Regression Test")]
        public void LoginTest()
        {
            var fluentwait = Waits(driver);
            string currDir = Directory.GetParent(@"../../../").FullName;
            string logfilepath = currDir + "/Logs/log_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".txt";
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .WriteTo.File(logfilepath, rollingInterval: RollingInterval.Day)
                .CreateLogger();
            MagicBricksHP mbhp = new(driver);
            Thread.Sleep(2000);
            //string? currDir = Directory.GetParent(@"../../../")?.FullName;
            string? excelFilePath = currDir + "/TestData/InputData.xlsx";
            string? sheetName = "Searchdata";

            List<SearchData> excelDataList = ExcelUtils.ReadSignUpExcelData(excelFilePath, sheetName);

            foreach (var excelData in excelDataList)
            {
                try
                {

                    string? fullname = excelData?.FullName;
                    string? email = excelData?.Email;
                    string? password = excelData?.Password;
                    string? phonenumber = excelData?.PhoneNumber;

                    Console.WriteLine($"FullName: {fullname}, Email: {email}, Phonenumber: {phonenumber}");
                    var register = fluentwait.Until(d => mbhp.Login());
                    List<string> lstWindow = driver.WindowHandles.ToList();
                    driver.SwitchTo().Window(lstWindow[1]);
                    TakeScreenshot();
                    Assert.That(driver.Url.Contains("login"));

                    LogTestResult("Registeration complete", "Register test success");
                    test = extent.CreateTest("success");
                    test.Pass("Register completed");
                    Console.WriteLine(driver.Url);
                    register.Regstr(fullname, email, password, phonenumber);

                }

                catch (ArgumentException ex)
                {
                    LogTestResult("Registeration test failed", ex.Message);
                }
            }
            //Log.CloseAndFlush();
        }
    }
}
