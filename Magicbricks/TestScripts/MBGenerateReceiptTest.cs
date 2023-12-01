using Magicbricks.PageObjects;
using Magicbricks.Utilities;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Serilog;

namespace Magicbricks.TestScripts
{
    [TestFixture]
    internal class MBGnerateReceipt : CoreCodes
    {
        [Test, Order(1), Category("Regression Test")]
        public void GeneratereceiptTest()
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

                    string? fullname = excelData?.FullName;
                    string? email = excelData?.Email;
                    string? phonenumber = excelData?.PhoneNumber;
                    string? rentamount = excelData?.RentAmount;
                    string? propaddress = excelData?.PropertyAddress;
                    string? landownername = excelData?.LandOwnerName;


                    Console.WriteLine($"FullName: {fullname}, Email: {email}, Phonenumber: {phonenumber},RentAmount: {rentamount}, PropertyAddress: {propaddress}, LandOwnerName: {landownername}");
                    var mbhp = new MagicBricksHP(driver);
                    IWebElement service = driver.FindElement(By.XPath("//li[@class='js-menu-container'][5]"));
                    Actions actions = new Actions(driver);
                    actions.MoveToElement(service).Build().Perform();
                    var genreceipt = fluentwait.Until(d => mbhp.SelectService());

                    List<string> lstWindow = driver.WindowHandles.ToList();
                    driver.SwitchTo().Window(lstWindow[1]);
                    genreceipt.Receiptdeatils(fullname, email, phonenumber, rentamount, propaddress, landownername);

                    TakeScreenshot();
                    Assert.That(driver.Url.Contains("propertyservices"));

                    LogTestResult("generate success", "generate receipt test success");
                    test = extent.CreateTest("success");
                    test.Pass("receipt generation completed");

                }


                catch (ArgumentException ex)
                {
                    TakeScreenshot();
                    LogTestResult("Geneate receipt test failed", "Geneate receipt test failed", ex.Message);
                    test.Fail("Geneate receipt test failed");
                }
            }
        }
        //Log.CloseAndFlush();

    }
}



