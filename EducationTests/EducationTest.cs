using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using NunitCompetition.Utilities;
using NUnit.Framework;
using NunitCompetition.Page;
using OpenQA.Selenium;
using System.Numerics;

namespace NunitCompetition.EducationTests
{

    [TestFixture]


    public class Tests : CommonHook

    {
        string expectedText;
        public Tests()
        {
            Console.WriteLine("Tests class instance created.");
        }


        [OneTimeSetUp]
        public void EducationTest()
        {
            extent.CreateTest("Tests for Education Feature");
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

            // Initialize WebDriver and navigate                                                                // Initialize WebDriver and navigate                                                                 // Initialize WebDriver and navigate                                                               // Initialize WebDriver
            NunitCompetition.Utilities.WebDriverManager.InitializeDriver();
            Login.LoginActions();
            EducationPage.GoToTab(driver);
            EducationPage.DeleteAllElement();
        }


        [Test, Order(1), Description("This test validates behavior of Education feature for valid inputs in all fields.")]
        public void TestCase001()
        {
            expectedText= "Education has been added";
            const string FilePath = @"C:\Users\Shuch\Desktop\NunitCompetition\Utilities\EducationTestCases\TestCase001.json"; //@"C:\Users\Shuch\Desktop\NunitCompetition\Utilities\EducationTestCases\TestCase001.json";
            EducationPage.FillEducationForm(FilePath);
            Thread.Sleep(4000);
            EducationPage.AddAssertion(expectedText);


        }

        [Test, Order(2), Description("This test validates behavior of Education feature for no input in year field")]
        public void TestCase002()
        {
            expectedText = "Please enter all the fields"; 
            const string FilePath = @"C:\Users\Shuch\Desktop\NunitCompetition\Utilities\EducationTestCases\TestCase002.json";
            EducationPage.FillEducationForm(FilePath);
            Thread.Sleep(4000);
            EducationPage.AddAssertion(expectedText);
        }

        [Test, Order(3), Description("This test validates behavior of Education feature for long university input with speacial characters")]
        public void TestCase003()
        {
            expectedText = "Education has been added";
            const string FilePath = @"C:\Users\Shuch\Desktop\NunitCompetition\Utilities\EducationTestCases\TestCase003.json";
            EducationPage.FillEducationForm(FilePath);
            Thread.Sleep(4000);
            EducationPage.AddAssertion(expectedText);
        }

        [Test, Order(4), Description("This test validates behavior of Education feature for long degree input with speacial characters")]
        public void TestCase004()
        {
            expectedText = "Education has been added";
            const string FilePath = @"C:\Users\Shuch\Desktop\NunitCompetition\Utilities\EducationTestCases\TestCase004.json";
            EducationPage.FillEducationForm(FilePath);
            Thread.Sleep(4000);
            EducationPage.AddAssertion(expectedText);
        }

        [Test, Order(5), Description("This test validates behavior of Education feature for no input in country field")]
        public void TestCase005()
        {
            expectedText = "Please enter all the fields";
            const string FilePath = @"C:\Users\Shuch\Desktop\NunitCompetition\Utilities\EducationTestCases\TestCase005.json";
            EducationPage.FillEducationForm(FilePath);
            Thread.Sleep(4000);
            EducationPage.AddAssertion(expectedText);
        }

        [Test, Order(6), Description("This test validates behavior of Education feature for space as input in degree field")]
        public void TestCase006()
        {
            expectedText = "Education information was invalid";
            const string FilePath = @"C:\Users\Shuch\Desktop\NunitCompetition\Utilities\EducationTestCases\TestCase006.json";
            EducationPage.FillEducationForm(FilePath);
            Thread.Sleep(4000);
            EducationPage.AddAssertion(expectedText);
        }

        [Test, Order(7), Description("This test validates behavior of Education feature for no input title field")]
        public void TestCase007()
        {
            expectedText = "Please enter all the fields";
            const string FilePath = @"C:\Users\Shuch\Desktop\NunitCompetition\Utilities\EducationTestCases\TestCase007.json";
            EducationPage.FillEducationForm(FilePath);
            Thread.Sleep(4000);
            EducationPage.AddAssertion(expectedText);
        }
        [Test, Order(8), Description("This test validates behavior of Education feature for space as input in university field.")]
        public void TestCase008()
        {
            expectedText = "Education information was invalid";
            const string FilePath = @"C:\Users\Shuch\Desktop\NunitCompetition\Utilities\EducationTestCases\TestCase008.json";
            EducationPage.FillEducationForm(FilePath);
            Thread.Sleep(4000);
            EducationPage.AddAssertion(expectedText);
        }

        [Test, Order(9), Description("This test validates behavior of Education feature for no input in university field.")]
        public void TestCase009()
        {
            expectedText = "Please enter all the fields";
            const string FilePath = @"C:\Users\Shuch\Desktop\NunitCompetition\Utilities\EducationTestCases\TestCase009.json";
            EducationPage.FillEducationForm(FilePath);
            Thread.Sleep(4000);
            EducationPage.AddAssertion(expectedText);
        }

        [Test, Order(10), Description("This test validates behavior of Education feature for no inputs in degree field")]
        public void TestCase010()
        {
            expectedText = "Education information was invalid";
            const string FilePath = @"C:\Users\Shuch\Desktop\NunitCompetition\Utilities\invalidinputs.json";
            EducationPage.FillEducationForm(FilePath);
            Thread.Sleep(4000);
            EducationPage.AddAssertion(expectedText);
        }

        [Test, Order(11), Description("This test validates behavior of Education feature for duplicate education entries.")]
        [TestCase(@"C:\Users\Shuch\Desktop\NunitCompetition\Utilities\EducationTestCases\TestCase011.json")]
        public void TestCase011(string jsonFilePath)
        {
            // Expected validation message for duplicate entries
            expectedText = "This information is already exist.";

            // First attempt to add the entry
            EducationPage.FillEducationForm(jsonFilePath);
            //Thread.Sleep(4000);
           // EducationPage.AddAssertion("Education has been added"); // Assert successful addition

            // Second attempt to add the same entry
            EducationPage.FillEducationForm(jsonFilePath);
            Thread.Sleep(1000);
            EducationPage.AddAssertion(expectedText); // Assert duplicate entry message
        }

       

        [TearDown]

        public void Cleanup()
        {
            // Perform cleanup after each test
            Console.WriteLine("Test cleanup executed.");
            EducationPage.DeleteAllElement();

            //Close the browser 
            driver.Quit();
        }
    }
}
