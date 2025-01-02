
using AventStack.ExtentReports;
using NunitCompetition.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Runtime.ConstrainedExecution;
using System.Text.Json;

namespace NunitCompetition.Page
{
    public class CertificatePage : CommonHook
    {
        public static void GoToTab(IWebDriver driver)
        {
            // Navigating to Certificate tab
            IWebElement CertificateTab = driver.FindElement(By.XPath("//*/div/section[2]/div/div/div/div[3]/form/div[1]/a[4]"));
            CertificateTab.Click();
            Console.WriteLine("Certificate feature of Mars portal is Starting");
        }
        public static void DeleteAllElement(IWebDriver driver)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2));

                while (true)
                {
                    try
                    {
                        // Wait until the remove icon button is clickable
                        IWebElement removeIconButton = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody/tr/td[4]/span[2]/i")));

                        // Click the remove button
                        removeIconButton.Click();

                        // Optionally, wait for the page to update after removal
                        Thread.Sleep(2000); // This can be replaced with an explicit wait if needed
                    }
                    catch (NoSuchElementException)
                    {
                        // If no more remove buttons are found, exit the loop
                        Console.WriteLine("All the Certificates have been removed");
                        break;
                    }
                    catch (ElementNotInteractableException)
                    {
                        // Handle the case where the button is found but not interactable
                        Console.WriteLine("Button found but not interactable");
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                // Catch any other general exceptions and log them
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

      

        public static void FillCertificateForm(string FilePath)
        {
            //Locate aad new button and click it

            IWebElement addNewButton = driver.FindElement(By.XPath("//*/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/thead/tr/th[4]/div"));
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
                        string cert = item.GetProperty("certificate").GetString();
                        string from = item.GetProperty("from").GetString();
                        string yr = item.GetProperty("year").GetString();
                        InputAddCertificate.InputCertificate(cert, from, yr);
                    }
                }
            }

            catch (Exception e)
            {
                Console.WriteLine("json file data is not entered" + e.ToString());
            }
        }

        public static void CertAssertion(string expectedText)
        {
            try
            {

                IWebElement languageRead = driver.FindElement(By.XPath("/html/body/div[1]/div"));
                
                if (languageRead.Text.Contains(expectedText))
                {
                    test.Log(Status.Info, expectedText);
                }
                

            
                else
                {
                    test.Log(Status.Fail, "Add Certificate failed");
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
       
        public static void Certificate(string cert)
        {
            IWebElement languageTextbox = driver.FindElement(By.XPath("//*/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/div/div[1]/div/input"));
        languageTextbox.SendKeys(cert);
        }
        public static void From(string from)
        {
            IWebElement languageTextbox = driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/div/div[2]/div[1]/input"));
            languageTextbox.SendKeys(from);
        }
        
        //Locating and clicking the Level dropdown
        public static void Year(string year)
        {
            IWebElement levelDropdown = driver.FindElement(By.Name("certificationYear"));
            levelDropdown.SendKeys(year);

        }
        //Locating and clicking Add button
        public static void ClickAddButton()
        {

            IWebElement addButton = driver.FindElement(By.XPath("//*/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/div/div[3]/input[1]"));
            addButton.Click();

        }



    }

}


