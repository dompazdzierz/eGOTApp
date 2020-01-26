using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.ObjectModel;
using System.Threading;
using System.Linq;
using SeleniumExtras.WaitHelpers;

namespace eGOTSeleniumTests
{
    [TestClass]
    public class TripVerificationTestClass
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
        public void TripPositiveVerificationTest()
        {
            TripVerficationHelper("ZatwierdŸ", "Gratulacje, bardzo ³adna wycieczka! :D");
        }

        [TestMethod]
        public void TripNegativeVerificationTest()
        {
            TripVerficationHelper("Odrzuæ", "Niewystarczaj¹ce dowody przebycia wycieczki");
        }


        private void TripVerficationHelper(string decisionButtonText, string commentText)
        {
            SafeClick(By.XPath("//div[@class='appheader--text-container']//following::i"));
            SafeClick(By.XPath("//div[text()='Niezweryfikowane wycieczki']"));

            // Sprawdzenie, czy tytu³ strony to niezweryfikowane wycieczki
            Assert.AreEqual(1, FindElements(By.XPath("//*[text()='Niezweryfikowane wycieczki'][@class='content']")).Count);

            // Upewnienie siê, ¿e s¹ jakiekolwiek wycieczki do zweryfikowania
            if (FindElements(By.XPath("(//td[1])[1]")).Count > 0)
            {
                // Zapamiêtanie nazwy usuwanego odcinka
                var nameOfTripToDelete = FindElement(By.XPath("(//td[1])[1]")).Text;

                SafeClick(By.XPath("(//td/button)[1]"));
                SafeClick(By.Id("right-btn"));

                var source = FindElement(By.XPath("(//*[@class='three wide column']/button)[2]/img")).GetAttribute("src");
                SafeClick(By.XPath("(//*[@class='three wide column']/button)[2]"));

                var mainPhotoSource = FindElement(By.XPath("//*[@class='ten wide column']/img")).GetAttribute("src");

                // Sprawdzenie, czy dzia³a prze³¹czanie zdjêæ
                Assert.AreEqual(source, mainPhotoSource);

                SafeClick(By.Id("right-btn"));

                // Wype³nienie komentarza
                SafeClick(By.TagName("textarea"));
                FindElement(By.TagName("textarea")).SendKeys(commentText);

                // Powrót do niezweryfikowanych wycieczek
                SafeClick(By.XPath($"//button[text()='{decisionButtonText}']"));
                SafeClick(By.XPath("//button[text()='Kontynuuj']"));

                Thread.Sleep(1000);
                driver.Navigate().Refresh();
                Thread.Sleep(1000);

                // Sprawdzenie czy, wycieczka zosta³a usuniêta z listy niezweryfikowanych
                var trips = FindElements(By.XPath("//td[1]"));
                Assert.AreEqual(0, trips.Where(x => x.Text == nameOfTripToDelete).Count());
            }
        }

        private void SafeClick(By by)
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(by));
            driver.FindElement(by).Click();
        }

        private ReadOnlyCollection<IWebElement> FindElements(By by)
        {
            return driver.FindElements(by);
        }

        private IWebElement FindElement(By by)
        {
            wait.Until(ExpectedConditions.ElementExists(by));
            return driver.FindElement(by);
        }



    }
}
