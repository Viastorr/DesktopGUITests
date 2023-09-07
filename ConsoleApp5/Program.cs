using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using System;

namespace CalculatorTest
{
    class Program
    {

            static void Main(string[] args)
            {
                // Konfiguruj połączenie z aplikacją Kalkulator
                AppiumOptions appiumOptions = new AppiumOptions();
                appiumOptions.AddAdditionalCapability("app", "Microsoft.WindowsCalculator_8wekyb3d8bbwe!App");
                WindowsDriver<WindowsElement> driver = new WindowsDriver<WindowsElement>(new Uri("http://127.0.0.1:4723"), appiumOptions);

                // Poczekaj na uruchomienie aplikacji
                System.Threading.Thread.Sleep(TimeSpan.FromSeconds(2));

                try
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

                    // Pobierz wynik z kalkulatora i wyświetl go
                    string result = resultText.Text.Replace("Display is", "").Trim();
                    Console.WriteLine("Wynik: " + result);
                }
                finally
                {
                    // Zamknij połączenie z aplikacją
                    driver.Quit();
                }
            }
        }
    }
