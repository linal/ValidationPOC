using System;
using System.Drawing.Imaging;
using Xunit;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace ValidationPoc.SeleniumTests
{
    public class BasicTests
    {
        [Fact]
        public void CanLoadWebPageTest()
        {
            // add the directory containing chromedriver.exe to PATH
            var driver = new ChromeDriver();

            var baseURL = "http://localhost:6917/";
            try
            {
                driver.Navigate().GoToUrl(baseURL + "/");
                driver.FindElement(By.Id("Name")).Clear();
                driver.FindElement(By.Id("Name")).SendKeys("Test");
                new SelectElement(driver.FindElement(By.Id("Color"))).SelectByText("Red");
                driver.FindElement(By.CssSelector("option[value=\"Red\"]")).Click();
                driver.FindElement(By.CssSelector("input.btn")).Click();
                var element = driver.FindElement(By.Name("PreviousNames[0].FirstName"), 3);
                element.Clear();
                driver.FindElement(By.Name("PreviousNames[0].FirstName")).SendKeys("ONe");
                driver.FindElement(By.Name("PreviousNames[0].Surname")).Clear();
                driver.FindElement(By.Name("PreviousNames[0].Surname")).SendKeys("Two");
                var screenshot = driver.GetScreenshot();
                screenshot.SaveAsFile("screenshot.png", ImageFormat.Png);
                driver.FindElement(By.CssSelector("input.btn.btn-success")).Click();
            }
            catch (Exception)
            {
                Screenshot screenshot = driver.GetScreenshot();
                screenshot.SaveAsFile("screenshot-error.png", ImageFormat.Png);
                throw;
            }
            driver.Quit();
        }
    }
}