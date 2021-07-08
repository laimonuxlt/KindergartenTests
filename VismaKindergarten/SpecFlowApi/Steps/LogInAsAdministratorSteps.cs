using NUnit.Framework;
using RestSharp;
using System;
using TechTalk.SpecFlow;

namespace VismaKindergarten.SpecFlowApi.Steps
{
    [Binding]
    public class LogInAsAdministratorSteps
    {
        private string resourse = "/localaccount/signin";
        private string baseUrl = "https://api.barnehage.testaws.visma.com";

        
        [Given(@"the admin with (.*)")]
        public void GivenTheAdminWith(string p0)
        {
            //ScenarioContext.Current.Pending();

            

        }
        
        [When(@"a POST request is made to https://api\.manage\.barnehage\.testaws\.visma\.com/localaccount/signin with")]
        public void WhenAPOSTRequestIsMadeToHttpsApi_Manage_Barnehage_Testaws_Visma_ComLocalaccountSigninWith(string multilineText)
        {
            //ScenarioContext.Current.Pending();

            
        }
        
        [Then(@"the response should contain Status (.*)")]
        public void ThenTheResponseShouldContainStatus(int p0)
        {
            //ScenarioContext.Current.Pending();
           
        }
    }
}
