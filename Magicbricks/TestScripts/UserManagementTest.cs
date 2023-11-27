using Magicbricks.PageObjects;
using Magicbricks.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magicbricks.TestScripts
{
    [TestFixture]
    internal class UserManagementTest : CoreCodes
    {
        //Asserts

        [Test, Order(1), Category("Regression Test")]
        public void CreateAcccountTest()
        {
            var homepage = new MagicBricksHP(driver);

            var productpage = productlist.SelectProduct();
            Thread.Sleep(2000);
            List<string> lstWindow = driver.WindowHandles.ToList();
            foreach (var handle in lstWindow)
            {
                driver.SwitchTo().Window(handle);
            }
          


        }
    }
}
        

