﻿using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Serilog;
using OpenQA.Selenium.Support.UI;

namespace Magicbricks.Utilities
{
    internal class CoreCodes
    {
        Dictionary<string, string>? properties;
        public IWebDriver driver;
        public ExtentReports extent;
        ExtentSparkReporter sparkReporter;
        public ExtentTest test;
        public void ReadConfigSettings()
        {
            string currDir = Directory.GetParent(@"../../../").FullName;//getting the current directory
            properties = new Dictionary<string, string>();//declaring  the dictionary
            string filename = currDir + "/ConfigSettings/config.properties";//taking the file from wworking directory
            string[] lines = File.ReadAllLines(filename);
            foreach (string line in lines)//for getting file data even if there are whitespace
            {
                if (!string.IsNullOrWhiteSpace(line) && line.Contains("="))
                {
                    string[] parts = line.Split('=');
                    string key = parts[0].Trim();
                    string value = parts[1].Trim();
                    properties[key] = value;
                }
            }
        }
        [OneTimeSetUp]
        public void InitializeBrowser()
        {
            string currDir = Directory.GetParent(@"../../../").FullName;
            extent = new ExtentReports();
            sparkReporter = new ExtentSparkReporter(currDir + "/ExtentReports/extent-report"
                + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".html");

            extent.AttachReporter(sparkReporter);

            ReadConfigSettings();
            if (properties["browser"].ToLower() == "chrome")
            {
                driver = new ChromeDriver();
            }
            else if (properties["browser"].ToLower() == "edge")
            {
                driver = new EdgeDriver();
            }
            driver.Url = properties["baseUrl"];
            driver.Manage().Window.Maximize();
        }

        public bool CheckLinkStatus(string url)
        {
            try
            {
                var request = (System.Net.HttpWebRequest)
                    System.Net.WebRequest.Create(url);
                request.Method = "HEAD";
                using (var response = request.GetResponse())
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
        [OneTimeTearDown]
        public void Cleanup()
        {
            extent.Flush();
            driver.Quit();
            Log.CloseAndFlush();
        }
        public void TakeScreenshot()
        {
            ITakesScreenshot its = (ITakesScreenshot)driver;
            Screenshot screenshot = its.GetScreenshot();
            string currDir = Directory.GetParent(@"../../../").FullName;
            string filepath = currDir + "/Screenshot/screenshot_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".png";
            screenshot.SaveAsFile(filepath);
            Console.WriteLine("Taken ss");
        }
        public static void ScrollIntoView(IWebDriver driver, IWebElement element)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollIntoView(true);", element);
        }
        protected void LogTestResult(string testName, string result, string errorMessage = null)
        {
            Log.Information(result);
            test = extent.CreateTest(testName);
            if (errorMessage == null)
            {
                Log.Information(testName + "passed");
                test.Pass(result);
            }
            else
            {
                Log.Error($"Test failed for{testName}.\n Exception: \n{errorMessage}");
                test.Fail(result);
            }
        }
        public static DefaultWait<IWebDriver> Waits(IWebDriver driver)
        {
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(5);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(100);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentWait.Message = "element not found";
            return fluentWait;
        }
    }


}


