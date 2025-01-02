using AventStack.ExtentReports;
using NunitCompetition.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Text.Json;

namespace NunitCompetition.Page
{
    public class EducationPage : CommonHook
    {
        public EducationPage()
        {
            Console.WriteLine("EducationPage instance created.");
        }
        public static void GoToTab(IWebDriver driver)
        {
            // Navigating to educaion Page
            IWebElement educationTab = driver.FindElement(By.XPath("//*/div/section[2]/div/div/div/div[3]/form/div[1]/a[3]"));
            educationTab.Click();
            Console.WriteLine("Education feature of Mars portal is Starting");
        }
        public static void DeleteAllElement()
        {

            //Deleting all the previous inputs

            try
            {
                while (true)
                {

                    IWebElement removeIconButton = driver.FindElement(By.XPath("//*/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[1]/tr/td[6]/span[2]/i"));
                    removeIconButton.Click();
                    Thread.Sleep(2000);
                }

            }

            catch (Exception ex)
            {
                // Assert.Pass("All the Educations has been removed");


            }
        }

        public static void FillEducationForm(string FilePath)
        {
            //Locate aad new button and click it
            Thread.Sleep(2000);
            IWebElement addNewButton = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/thead/tr/th[6]/div"));
            addNewButton.Click();
           
            try
            {

                Thread.Sleep(3000);
                string jsonString = File.ReadAllText(FilePath);
                Console.WriteLine(jsonString);

                // Parse the JSON string into a JsonDocument
                using (JsonDocument doc = JsonDocument.Parse(jsonString))
                {
                    Console.WriteLine("inside jason");
                    JsonElement root = doc.RootElement;

                    foreach (JsonElement item in root.EnumerateArray())
                    {
                        // Access individual properties of each object
                        string uni = item.GetProperty("university").GetString();
                        string deg = item.GetProperty("degree").GetString();
                        string coun = item.GetProperty("country").GetString();
                        string tit = item.GetProperty("title").GetString();
                        string yr = item.GetProperty("year").GetString();
                        InputAddEducation.InputEducation(uni, deg, coun, tit, yr);
                    }
                }
            }

            catch (Exception e)
            {
                Console.WriteLine("json file data is not entered" + e.ToString());
            }
        }

        public static void AddAssertion(string expectedText)
        {
                     try
                       {
                          
                           IWebElement languageRead = driver.FindElement(By.XPath("/html/body/div[1]/div"));
                          // string expectedText = "Education has been added";

                           if (languageRead.Text == expectedText)
                           {
                                 test.Log(Status.Info, expectedText);
                               //test.Log(Status.Info, "Add Education Passed");

                }
                           else
                           {
                               test.Log(Status.Fail, "Add Education failed");
                               // Capture and attach the screenshot
                               string screenshotPath = CaptureScreenshot(TestContext.CurrentContext.Test.Name);
                               test.AddScreenCaptureFromPath(screenshotPath);
                           }
                       }
                       catch (Exception ex)
                       {
                           // Log the failure
                           test.Log(Status.Fail, "Test failed: " + ex.Message);

                           // Capture and attach the screenshot
                           string screenshotPath = CaptureScreenshot(TestContext.CurrentContext.Test.Name);
                           test.AddScreenCaptureFromPath(screenshotPath);
                           throw;
                       } 

                   }
       
        private static string CaptureScreenshot(string testName)
                   {
                       try
                       {
                           string screenshotDir = Path.Combine(Directory.GetCurrentDirectory(), "Screenshots");
                           Directory.CreateDirectory(screenshotDir); // Ensure the directory exists

                           string screenshotPath = Path.Combine(screenshotDir, $"{testName}_{DateTime.Now:yyyyMMdd_HHmmss}.png");
                           Screenshot screenshot = ((ITakesScreenshot)driver).GetScreenshot();
                           screenshot.SaveAsFile(screenshotPath, ScreenshotImageFormat.Png);

                           return screenshotPath;
                       }
                       catch (Exception ex)
                       {
                           test.Log(Status.Error, "Failed to capture screenshot: " + ex.Message);
                           return null;
                       }
                   }

        //Locating and clicking the Level dropdown
        public static void Country(string country)
        {
            IWebElement levelDropdown = driver.FindElement(By.XPath("//*/div/div/div/div[3]/form/div[4]/div/div[2]/div/div/div[1]/div[2]/select"));
            levelDropdown.SendKeys(country);


        }
        public static void LocateEnterDegreeTextbox(string degree)
        {
            IWebElement languageTextbox = driver.FindElement(By.XPath("//*/div/div/div/div[3]/form/div[4]/div/div[2]/div/div/div[2]/div[2]/input"));
            languageTextbox.SendKeys(degree);
        }
        //Locating and sending input to University textbox
        public static void LocateEnterUniversityTextbox(string university)
        {
            IWebElement languageTextbox = driver.FindElement(By.XPath("//*/div/div/div/div[3]/form/div[4]/div/div[2]/div/div/div[1]/div[1]/input\r\n"));
            languageTextbox.SendKeys(university);
        }
        //Locating and clicking the Title dropdown
        public static void Title(string title)
        {
            IWebElement levelDropdown = driver.FindElement(By.XPath("//*/div/div/div/div[3]/form/div[4]/div/div[2]/div/div/div[2]/div[1]/select"));
            levelDropdown.SendKeys(title);

        }
        //Locating and clicking the Level dropdown
        public static void YearOption(string year)
        {
            IWebElement levelDropdown = driver.FindElement(By.XPath("//*/div/div/div/div[3]/form/div[4]/div/div[2]/div/div/div[2]/div[3]/select"));
            levelDropdown.SendKeys(year);

        }
        //Locating and clicking Add button
        public static void ClickAddButton()
        {

            IWebElement addButton = driver.FindElement(By.XPath("//*/div/div/div/div[3]/form/div[4]/div/div[2]/div/div/div[3]/div/input[1]"));
            addButton.Click();

        }



    }

}








