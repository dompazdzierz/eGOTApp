using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.ObjectModel;
using System.Threading;
using System.Linq;
using SeleniumExtras.WaitHelpers;
using System.Collections.Generic;

namespace eGOTSeleniumTests
{
    [TestClass]
    public class SectionPropositionTestClass
    {
        private IWebDriver driver;
        private string homeURL;
        private OpenQA.Selenium.Support.UI.WebDriverWait wait;

        [TestInitialize]
        public void InitTests()
        {
            homeURL = "http://localhost:3000/";
            var options = new ChromeOptions();
            options.AddExcludedArgument("enable-automation");
            options.AddAdditionalCapability("useAutomationExtension", false);
            options.AddArgument("--start-maximized");
            options.AddArgument("--ignore-certificate-errors");
            options.AddArgument("--disable-popup-blocking");
            options.AddArgument("--incognito");

            driver = new ChromeDriver(options)
            {
                Url = homeURL
            };

            wait = new OpenQA.Selenium.Support.UI.WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        [TestCleanup]
        public void CleanupTests()
        {
            driver.Dispose();
        }

        [TestMethod]
        public void SectionPropositionTest()
        {
            SectionPropositionTestHelper();
        }

        private void SectionPropositionTestHelper()
        {
            // Wejście do propozycji odcinków i czekanie aż zniknie loader.
            SafeClick(By.XPath("//div[@class='appheader--text-container']//following::i"));
            SafeClick(By.XPath("//div[text()='Zaproponuj odcinek']"));
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.ClassName("ui loading form")));

            // Wypełnienie dropdownów            
            var dropdownBaseXPath = "(//div[@role='combobox'])";

            for (int i = 1; i <= 3; i++)
            {
                var dropdownPath = dropdownBaseXPath + $"[{i}]";
                SafeClick(By.XPath(dropdownPath));
                SafeClick(By.XPath(dropdownPath + "/descendant::div[@role='option']"));
            }

            // Wypełnienie inputów
            var names = new List<string>() { "length", "elevationGain" };

            foreach(var name in names)
            {
                SafeClick(By.Name(name));
                FindElement(By.Name(name)).SendKeys("501");
            }

            // Zapis
            SafeClick(By.XPath("//button[text()='Zaproponuj odcinek']"));

            // Czekanie na pojawienie się prompta, który pojawia sie <=>
            // metoda kontrolera odpowiedzialna za dodanie propozycji odcinka zwróci Ok() (200)
            wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(
                By.XPath("//div[contains(text(), 'Pomyślnie zaproponowano odcinek')]")));

            Thread.Sleep(10000);

            SafeClick(By.XPath("//button[text()='Powrót']"));
        }

        private void SafeClick(By by)
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(by));
            driver.FindElement(by).Click();
        }

        private ReadOnlyCollection<IWebElement> FindElements(By by)
        {
            Thread.Sleep(1000);
            return driver.FindElements(by);
        }

        private IWebElement FindElement(By by)
        {
            wait.Until(ExpectedConditions.ElementExists(by));
            return driver.FindElement(by);
        }



    }
}
