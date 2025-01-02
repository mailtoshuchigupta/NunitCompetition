using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using NunitCompetition.Utilities;
using NUnit.Framework;
using NunitCompetition.Page;
using OpenQA.Selenium;

namespace NunitCompetition.CertificateTests
{

    [TestFixture]
    public class Tests : CommonHook
    {
        public Tests()
        {
            Console.WriteLine("Tests class instance created.");
        }
        [OneTimeSetUp]
        public void EducationTest()
        {
            extent.CreateTest("Tests for Certificate Feature");
        }

        [SetUp]
        public void Setup()
        {
            
            // Create the directory for screenshots
            Directory.CreateDirectory("Screenshots");

            // Use the test context or JSON file information for the test name
            string testName = TestContext.CurrentContext.Test.Name; // Default test name
            string testDescription = TestContext.CurrentContext.Test.Properties.Get("Description") as string;

            // Extract test name from JSON file if applicable (optional improvement)
            if (TestContext.CurrentContext.Test.Arguments.Length > 0 && TestContext.CurrentContext.Test.Arguments[0] is string jsonFilePath)
            {
                testName = Path.GetFileNameWithoutExtension(jsonFilePath); // Use JSON file name as test name
            }

            // Log the test name and description in the Extent Report
            test = extent.CreateTest(testName, testDescription);
            


            // Initialize WebDriver
            NunitCompetition.Utilities.WebDriverManager.InitializeDriver();
            Login.LoginActions();
            CertificatePage.GoToTab(driver);
            CertificatePage.DeleteAllElement(driver);

        }


        [Test, Order(1), Description("This test validates behavior of Certificate feature for valid input in all fields")]
        public void TestCase001()
        {
            string expectedText = "has been added";
            const string FilePath = @"C:\Users\Shuch\Desktop\NunitCompetition\Utilities\CertificateTestCases\TestCase001.json"; //@"C:\Users\Shuch\Desktop\NunitCompetition\Utilities\EducationTestCases\TestCase001.json";
            CertificatePage.FillCertificateForm(FilePath);
            Thread.Sleep(4000);
            CertificatePage.CertAssertion(expectedText);


        }

        [Test, Order(2), Description("This test validates behavior  of Certificate feature for  long input in Certificate field")]
        public void TestCase002()
        {
            string expectedText = "has been added";
            const string FilePath = @"C:\Users\Shuch\Desktop\NunitCompetition\Utilities\CertificateTestCases\TestCase002.json";
            CertificatePage.FillCertificateForm(FilePath);
            Thread.Sleep(4000);
            CertificatePage.CertAssertion(expectedText);
        }

        [Test, Order(3), Description("This test validates behavior  of Certificate feature for  long input in From field")]
        public void TestCase003()
        {
            string expectedText = "has been added";
            const string FilePath = @"C:\Users\Shuch\Desktop\NunitCompetition\Utilities\CertificateTestCases\TestCase003.json";
            CertificatePage.FillCertificateForm(FilePath);
            Thread.Sleep(4000);
            CertificatePage.CertAssertion(expectedText);
        }

        [Test, Order(4), Description("This test validates behavior  of Certificate feature  for  space as input in certificate field")]
        public void TestCase004()
        {
            string expectedText = "has not been added";
            const string FilePath = @"C:\Users\Shuch\Desktop\NunitCompetition\Utilities\CertificateTestCases\TestCase004.json";
            CertificatePage.FillCertificateForm(FilePath);
            Thread.Sleep(4000);
            CertificatePage.CertAssertion(expectedText);
        }

        [Test, Order(5), Description("This test validates behavior  of Certificate feature for  space as input in From field")]
        public void TestCase005()
        {
            string expectedText = "has not been added";
            const string FilePath = @"C:\Users\Shuch\Desktop\NunitCompetition\Utilities\CertificateTestCases\TestCase005.json";
            CertificatePage.FillCertificateForm(FilePath);
            Thread.Sleep(4000);
            CertificatePage.CertAssertion(expectedText);
        }

        [Test, Order(6), Description("This test validates behavior of Certificate feature for  no input in year field")]
        public void TestCase006()
        {
            string expectedText ="Please enter Certification Name, Certification From and Certification Year";
            const string FilePath = @"C:\Users\Shuch\Desktop\NunitCompetition\Utilities\CertificateTestCases\TestCase006.json";
            CertificatePage.FillCertificateForm(FilePath);
            Thread.Sleep(4000);
            CertificatePage.CertAssertion(expectedText);
        }

        [Test, Order(7), Description("This test validates behavior  of Certificate feature for  no input in certificate field")]
        public void TestCase007()
        {
            string expectedText = "Please enter Certification Name, Certification From and Certification Year";
            const string FilePath = @"C:\Users\Shuch\Desktop\NunitCompetition\Utilities\CertificateTestCases\TestCase007.json";
            CertificatePage.FillCertificateForm(FilePath);
            Thread.Sleep(4000);
            CertificatePage.CertAssertion(expectedText);
        }
        [Test, Order(8), Description("This test validates behavior  of Certificate feature for  no input in From field.")]
        public void TestCase008()
        {
            string expectedText = "Please enter Certification Name, Certification From and Certification Year";

            const string FilePath = @"C:\Users\Shuch\Desktop\NunitCompetition\Utilities\CertificateTestCases\TestCase008.json";
            CertificatePage.FillCertificateForm(FilePath);
            Thread.Sleep(4000);
            CertificatePage.CertAssertion(expectedText);
        }

        [Test, Order(9), Description("This test validates behavior  of Certificate feature for duplicate certigficate entries.")]
        [TestCase(@"C:\Users\Shuch\Desktop\NunitCompetition\Utilities\CertificateTestCases\TestCase009.json")]
        public void TestCase009(string jsonFilePath)
        {
            // Expected validation message for duplicate entries
            string expectedText = "This information is already exist.";

            // First attempt to add the entry
            CertificatePage.FillCertificateForm(jsonFilePath);
            Thread.Sleep(2000);

            // Second attempt to add the same entry
            CertificatePage.FillCertificateForm(jsonFilePath);
            Thread.Sleep(1000);
            CertificatePage.CertAssertion(expectedText); // Assert duplicate entry message
        }



        [TearDown]

        public void Cleanup()
        {
            // Perform cleanup after each test
            Console.WriteLine("Test cleanup executed.");
            CertificatePage.DeleteAllElement(driver);

            //Close the browser 
            driver.Quit();
        }

    }
}
