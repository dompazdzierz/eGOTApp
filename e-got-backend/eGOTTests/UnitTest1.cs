using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Threading;

namespace eGOTTests
{
    [TestClass]
    public class UnitTest1
    {
        private IWebDriver driver;
        private string homeURL;

        [TestInitialize]
        public void initTests()
        {
            homeURL = "http://localhost:3000/";
            driver = new ChromeDriver();
            driver.Url = homeURL;
        }   

        [TestMethod]
        public void TestMethod1()
        {
            Thread.Sleep(10000);
            Assert.IsTrue(false);
        }

        [TestCleanup]
        public void cleanupTests()
        {
            driver.Dispose();
        }
    }
}
