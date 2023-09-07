using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using System;
using Xunit;

namespace CalculatorTest.Tests
{
    public class CalculatorAppiumTests : IDisposable
    {
        private WindowsDriver<WindowsElement> driver;

        public CalculatorAppiumTests()
        {
            // Konfiguruj połączenie z aplikacją Kalkulator
            AppiumOptions appiumOptions = new AppiumOptions();
            appiumOptions.AddAdditionalCapability("app", "Microsoft.WindowsCalculator_8wekyb3d8bbwe!App");
            driver = new WindowsDriver<WindowsElement>(new Uri("http://127.0.0.1:4723"), appiumOptions);
            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(2));
        }

        [Fact]
        public void MultiplyNumbers_ShouldReturnExpectedResult()
        {
            // Znajdź elementy przycisków kalkulatora 
            WindowsElement buttonOne = driver.FindElementByAccessibilityId("num7Button");
            WindowsElement buttonMultiply = driver.FindElementByAccessibilityId("multiplyButton");
            WindowsElement buttonTwo = driver.FindElementByAccessibilityId("num4Button");
            WindowsElement buttonEquals = driver.FindElementByAccessibilityId("equalButton");
            WindowsElement resultText = driver.FindElementByAccessibilityId("CalculatorResults");

            // Kliknij przyciski kalkulatora
            buttonOne.Click();
            buttonMultiply.Click();
            buttonTwo.Click();
            buttonEquals.Click();

            // Pobierz wynik z kalkulatora
            string result = resultText.Text.Replace("Display is", "").Trim();

            // Porównaj oczekiwany wynik z faktycznym wynikiem
            Assert.Equal("28", result);
        }

        public void Dispose()
        {
            // Zamknij połączenie z aplikacją
            driver.Quit();
        }
    }
}
