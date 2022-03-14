using AngularBusyDemo_Specflow_Selenium.Factories;
using AngularBusyDemo_Specflow_Selenium.Pages;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using Xunit;

namespace AngularBusyDemo_Specflow_Selenium.Steps
{
    [Binding]
    public class AngularBusySteps
    {
        private readonly InteractionFactory _actions;
        private readonly AngularBusyPage _page;

        public AngularBusySteps(InteractionFactory actions)
        {

            _actions = actions;
            _page = new AngularBusyPage(actions);
        }

        [Given(@"a user wants to test busy loading indicators")]
        public void GivenAUserWantsToTestBusyLoadingIndicators()
        {
            _actions.Navigate("http://cgross.github.io/angular-busy/demo/"); ;
        }

        [Given(@"the user wants to add a delay of (.*) ms")]
        public void GivenTheUserWantsToAddADelayOfMs(int delay)
        {
            _page.SetDuration(delay.ToString());
        }

        [Given(@"the user wants the test to display (.*) while waiting")]
        public void GivenTheUserWantsTheTestToDisplayKittenWhileWaiting(string message)
        {
            _page.SetMessage(message);
        }

        [Given(@"the user wants to see (.*) busy indicator animation")]
        public void GivenTheUserWantsToSeeStandardBusyIndicatorAnimation(string template)
        {
            _page.SetTemplateUrl(template);
        }

        [When(@"the user tries to test busy indicator with provided message")]
        public void WhenTheUserTriesToTestBusyIndicatorWithProvidedMessage()
        {
            _page.Demo();
        }

        [Then(@"the system displays (.*) to the user")]
        public void ThenTheSystemDisplaysKittenMessageToTheUser(string message)
        {
            Assert.True(_page.IsBusyMessageDisplayed(message));
            Assert.Equal(message, _page.GetMessage(message));  
        }




    }
}
