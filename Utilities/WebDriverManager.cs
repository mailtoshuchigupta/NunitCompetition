using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NunitCompetition.Utilities
{
   
public  class WebDriverManager : CommonDriver
    {
        
        public static IWebDriver GetDriver()
        {
            if (driver == null)
            {
                InitializeDriver();
            }
            return driver;
        }

        // Method to initialize the ChromeDriver, maximize the window, and navigate to the URL
        public static void InitializeDriver()
        {
            // Set Chrome options (optional, e.g., to run headless or with specific arguments)
            ChromeOptions options = new ChromeOptions();

            // Initialize ChromeDriver
            driver = new ChromeDriver(options);

            // Maximize the window
            driver.Manage().Window.Maximize();

            // Navigate to the specified URL
            driver.Navigate().GoToUrl("http://localhost:5000/");

            // Sleep for 3 seconds (3000 milliseconds)
            Thread.Sleep(3000);  // Pausing the execution for 3 seconds
        }

        // Method to quit the driver and clean up resources
        public static void QuitDriver()
        {
            driver?.Quit();
            driver = null;
        }
    }


  }
    


