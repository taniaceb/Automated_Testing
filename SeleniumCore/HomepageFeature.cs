using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.IO;
using System.Reflection;

namespace SeleniumCore
{
    [TestClass]
    public class HomepageFeature
    {

        IWebDriver _driver;
        [TestMethod]
        public void ShouldBeAbleToLogin()
        {
           

            var outPutDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
             _driver = new ChromeDriver(outPutDirectory);
            _driver.Navigate().GoToUrl("https://www.saucedemo.com/");

           // IWebElement loginButton = _driver.FindElement(By.ClassName("login-button"));

           var loginButtonLocator = By.ClassName("btn_action");
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(loginButtonLocator));

            IWebElement userNameField = _driver.FindElement(By.Id("user-name"));
            IWebElement passwordField = _driver.FindElement(By.Id("password"));
            IWebElement loginButton = _driver.FindElement(loginButtonLocator);

            userNameField.SendKeys("standard_user");
            passwordField.SendKeys("secret_sauce");
            loginButton.Click();
          //  var wait1 = new WebDriverWait(_driver, TimeSpan.FromSeconds(50));
          //  wait1.Until(ExpectedConditions.ElementIsVisible(By.ClassName("product_label")));

            Assert.IsTrue(_driver.Url.Contains("inventory.html"));
        }

        [TestCleanup]
        public void CleanUp()
        {
            _driver.Quit();
        }
    }
}
