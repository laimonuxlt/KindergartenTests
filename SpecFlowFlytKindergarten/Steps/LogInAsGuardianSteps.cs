using System;
using TechTalk.SpecFlow;

namespace SpecFlowFlytKindergarten.Steps
{
    [Binding]
    public class LogInAsGuardianSteps : BasePage;


    {
        [Given(@"Log in page for guardian is displayed")]
        public void GivenLogInPageForGuardianIsDisplayed()
        {
            //ScenarioContext.Current.Pending();
        }
        
        [When(@"the user selects the guardian")]
        public void WhenTheUserSelectsTheGuardian(Table table)
        {
           // ScenarioContext.Current.Pending();
        }
        
        [When(@"the user clicks log in button")]
        public void WhenTheUserClicksLogInButton()
        {
            //ScenarioContext.Current.Pending();
        }
        
        [Then(@"the guardian site main page is displayed")]
        public void ThenTheGuardianSiteMainPageIsDisplayed()
        {
            //ScenarioContext.Current.Pending();
        }
    }
}
