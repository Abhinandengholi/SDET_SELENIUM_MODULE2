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
    internal class MBSearchTest : CoreCodes
    {
        //Asserts

        [Test, Order(1), Category("Regression Test")]
        public void SearchTest()
        {
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

                string? scity = excelData?.CitySelection;
                string? fullname = excelData?.FullName;
                string? email = excelData?.Email;
                string? phonenumber = excelData?.PhoneNumber;

                Console.WriteLine($"CitySelection: {scity}");
                Console.WriteLine($"FullName: {fullname}, Email: {email}, Phonenumber: {phonenumber}");


                var property = mbhp.Search(scity);
                var specificproperty = property.SelectedProp();

                List<string> lstWindow = driver.WindowHandles.ToList();
                driver.SwitchTo().Window(lstWindow[1]);
                Console.WriteLine(driver.Url);
                specificproperty.Booking(fullname, email, phonenumber);
                // Assert.That(""."")

            }
        }

        
    }



        
    
}
        

