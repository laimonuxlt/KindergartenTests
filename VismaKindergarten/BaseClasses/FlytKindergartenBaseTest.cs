using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using VismaKindergarten.Pages;
using VismaKindergarten.Pages.AdminPages;

namespace VismaKindergarten
{
    public class FlytKindergartenBaseTest : BaseTest
    {

        public LoginAdminPage loginPageAdmin;
        public MainGuardianPage guardianPage;
        public LoginGuardianPage loginPageGuardian;
        public ActivityLogTabPage activityLogTabPage;
        public DocumentationTabPage documentationTabPage;
        public DeviationsTabPage deviationsTabPage;


        [SetUp]
        public void SetUp()
        {
            loginPageAdmin = new LoginAdminPage(WebDriver);
            guardianPage = new MainGuardianPage(WebDriver);
            loginPageGuardian = new LoginGuardianPage(WebDriver);
            activityLogTabPage = new ActivityLogTabPage(WebDriver);
            documentationTabPage = new DocumentationTabPage(WebDriver);
            deviationsTabPage = new DeviationsTabPage(WebDriver);

        }

    }
}
