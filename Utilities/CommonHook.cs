using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NunitCompetition.Page;

namespace NunitCompetition.Utilities
{
    public class CommonHook : CommonDriver
    {
        public static ExtentReports extent;
        public static ExtentTest test;
        public CommonHook()
        {
            extent = new AventStack.ExtentReports.ExtentReports();
            

        }



        [OneTimeSetUp]
        public void Initialize()
        {
            // Initialize ExtentReports
            ExtentHtmlReporter htmlReporter = new ExtentHtmlReporter("C:\\Users\\Shuch\\Desktop\\NunitCompetition\\ExtentReport\\index.html");
            extent.AttachReporter(htmlReporter);
            extent.AddSystemInfo("Environment", "QA");
            extent.AddSystemInfo("Tester", "Shuchi");
        }
       
        [OneTimeTearDown]
        public void TeardownReport()
        {
            extent.Flush();
            driver.Quit();
        }

    }
}
