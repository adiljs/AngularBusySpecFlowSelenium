using AngularBusyDemo_Specflow_Selenium.Factories;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace AngularBusyDemo_Specflow_Selenium.Pages
{
    public class AngularBusyPage
    {
        private readonly InteractionFactory _actions;
        public AngularBusyPage(InteractionFactory actions)
        {
            _actions = actions;
        }

        public By TextDelayInput => By.Id("delayInput");
        public By TextDurationInput => By.Id("durationInput");
        public By TextMessageInput => By.Id("message");
        public By CheckboxBackdrop => By.ClassName("checkbox");
        public By DropDownTemplateUrl => By.Id("template");
        public By ButtonDemo => By.XPath("//button[text()='Demo']");
        public By SpinnerBusyMessage(string message) => By.XPath($"//div[@class='cg-busy-default-text ng-binding'] | //div[@class='ng-binding'][text()='{message}']");

        public void SetDuration(string duration = "1000")
        {
            _actions.Clear(TextDurationInput);
            _actions.SendKeys(TextDurationInput, duration);
        }

        public void SetMessage(string message)
        {
            _actions.Clear(TextMessageInput);
            _actions.SendKeys(TextMessageInput, message);
        }

        public void SetTemplateUrl(string template)
        {
            _actions.SelectByText(DropDownTemplateUrl, template);
        }

        public void Demo() => _actions.Click(ButtonDemo);

        public bool IsBusyMessageDisplayed(string message = "Waiting")
        {
            _actions.WaitVisible(SpinnerBusyMessage(message));
            return _actions.Displayed(SpinnerBusyMessage(message));
        }

        public string GetMessage(string message = "Waiting") => _actions.Text(SpinnerBusyMessage(message));

    }
}
