using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.ObjectModel;
using System.Threading;

namespace eGOTSeleniumTests
{
    [TestClass]
    public class UnitTest1
    {
        private IWebDriver driver;
        private string homeURL;
        private WebDriverWait wait;

        [TestInitialize]
        public void initTests()
        {
            homeURL = "http://localhost:3000/";
            var options = new ChromeOptions();
            options.AddExcludedArgument("enable-automation");
            options.AddAdditionalCapability("useAutomationExtension", false);
            options.AddArgument("--start-maximized");
            options.AddArgument("--ignore-certificate-errors");
            options.AddArgument("--disable-popup-blocking");
            options.AddArgument("--incognito");


            driver = new ChromeDriver(options);
            driver.Url = homeURL;

            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        [TestMethod]
        public void TripVerificationTest()
        {
            SafeClick(By.XPath("//div[@class='appheader--text-container']//following::i"));
            SafeClick(By.TagName("//div[text()='Niezweryfikowane wycieczki']"));
            Assert.AreEqual(1, FindElements("//*[text()='Niezweryfikowane wycieczki'][@class='content'])").);
            Thread.Sleep(10000);
            Assert.AreEqual("XD", "XD");
            
        }

        [TestCleanup]
        public void cleanupTests()
        {
            driver.Dispose();
        }

        private void SafeClick(By by)
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(by));
            driver.FindElement(by).Click();
        }

        private ReadOnlyCollection<IWebElement> FindElements(By by)
        {
            wait.Until(ExpectedConditions.ElementExists(by));
            return driver.FindElements(by);
        }


    }
}
