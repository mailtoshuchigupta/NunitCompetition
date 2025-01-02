using OpenQA.Selenium;

namespace NunitCompetition.Utilities
{
    public class Login : CommonDriver
    {
        public static void LoginActions()
        {
          

            //Identify Sign in button and click
            IWebElement signinButton = driver.FindElement(By.XPath("//*[@id=\"home\"]/div/div/div[1]/div/a"));
            signinButton.Click();
            Wait.WaitForClickable(driver, "XPath", "//*[@id=\"home\"]/div/div/div[1]/div/a", 3);

            //Identify Email address textbox and enter valid email
            IWebElement emailTextbox = driver.FindElement(By.Name("email"));
            emailTextbox.SendKeys("mailtoshuchigupta@gmail.com");

            //Identify Password textbox and enter valid password
            IWebElement passwordTextbox = driver.FindElement(By.Name("password"));
            passwordTextbox.SendKeys("w123elcome");

            //Identify Login button and click
            IWebElement loginButton = driver.FindElement(By.XPath("/html/body/div[2]/div/div/div[1]/div/div[4]/button"));
            loginButton.Click();
            Thread.Sleep(3000);

        }
    }
}
