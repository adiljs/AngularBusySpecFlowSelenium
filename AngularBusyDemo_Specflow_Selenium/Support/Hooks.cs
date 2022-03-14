using AngularBusyDemo_Specflow_Selenium.Factories;
using BoDi;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace AngularBusyDemo_Specflow_Selenium.Support
{
    [Binding]
    public class Hooks
    {
        private readonly IObjectContainer _objectContainer;
        private IWebDriver _driver;
        private InteractionFactory _actions;
        private static DriverFactory _driverFactory;

        public Hooks(IObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;
        }

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            
            _driverFactory = new DriverFactory();
            
        }

        [BeforeScenario(Order = 0)]
        public void BeforeScenario()
        {
            _driver = _driverFactory.CreateDriver();
            _actions = new InteractionFactory(_driver);
            _driver.Manage().Window.Maximize();
            //_objectContainer.RegisterInstanceAs(_driver);
            _objectContainer.RegisterInstanceAs(_actions);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            _driver?.Dispose();
        }
    }
}
