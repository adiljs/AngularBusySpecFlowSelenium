using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Text;

namespace AngularBusyDemo_Specflow_Selenium.Factories
{
    public class DriverFactory : LaunchSettingsFactory
    {
        public IWebDriver CreateDriver()
        {
            string browser = Environment.GetEnvironmentVariable("Browser" ?? "Chrome");
            return browser switch
            {
                "Chrome" => new ChromeDriver(),
                _ => throw new ArgumentException($"Browser not yet implemented: {browser}"),
            };
        }
    }
}
