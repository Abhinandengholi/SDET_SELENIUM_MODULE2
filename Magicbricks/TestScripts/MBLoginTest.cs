﻿using Magicbricks.PageObjects;
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
            
            string? excelFilePath = currDir + "/TestData/InputData.xlsx";
            string? sheetName = "Searchdata";
            
                List<SearchData> excelDataList = ExcelUtils.ReadSignUpExcelData(excelFilePath, sheetName);

            foreach (var excelData in excelDataList)
            {
                try
                {
                    string? email = excelData?.Email;
                    string? phonenumber = excelData?.PhoneNumber;
                    Console.WriteLine($"Email: {email}");
                    MagicBricksHP mbhp = new(driver);
                    var userlogin = fluentwait.Until(d => mbhp.UserLog());
                    List<string> lstWindow = driver.WindowHandles.ToList();
                    driver.SwitchTo().Window(lstWindow[1]);
                    userlogin.UserDetail(email);
                    TakeScreenshot();
                    Assert.That(driver.Url.Contains("login"));
                    LogTestResult("login success", "login test success");
                    test = extent.CreateTest("success");
                    test.Pass("login completed");
                   
                }


                catch (AssertionException ex)
                {

                    TakeScreenshot();
                    LogTestResult("login test failed", "login test failed", ex.Message);
                    test.Fail("login test failed");
                }
            }
        }
    }
    
}










