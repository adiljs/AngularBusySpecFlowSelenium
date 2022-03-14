using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace AngularBusyDemo_Specflow_Selenium.Factories
{
    public class InteractionFactory
    {
        private readonly IWebDriver _driver;
        public InteractionFactory(IWebDriver driver)
        {
            _driver = driver;
        }

        public void Navigate(string url)
        {
            _driver.Navigate().GoToUrl(url);
        }

        private IWebElement FindElement(By by)
        {
            return _driver.FindElement(by);
        }

        private WebDriverWait Wait(double seconds = 30)
        {
            return new WebDriverWait(_driver, TimeSpan.FromSeconds(seconds));
        }

        public void Click(By by)
        {
            FindElement(by).Click();
        }

        public void Clear(By by)
        {
            FindElement(by).Clear();
        }

        public void SendKeys(By by, string value)
        {
            FindElement(by).SendKeys(value);
        }

        public void SelectByText(By by, string value)
        {
            SelectElement templateUrl = new SelectElement(FindElement(by));
            templateUrl.SelectByText(value);
        }

        public bool Displayed(By by)
        {
            return FindElement(by).Displayed;
        }

        public string Text(By by)
        {
            return FindElement(by).Text;
        }

        public void WaitVisible(By by, double seconds = 30)
        {
            Wait(seconds).Until(ExpectedConditions.ElementIsVisible(by));
        }

        public void WaitClickable(By by, double seconds = 30)
        {
            Wait(seconds).Until(ExpectedConditions.ElementToBeClickable(by));
        }

    }
}
