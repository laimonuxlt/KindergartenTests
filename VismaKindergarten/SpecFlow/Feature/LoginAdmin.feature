Feature: Login as Admin
	

Scenario: Log in selected admin
	Given login page  <adminLoginUrl> is displayed	
	When the user selects the <admin> as admin
	And the user clicks on login button
	Then the admin page <adminUrl> is displayed

	Examples:
	| adminLoginUrl                                                     | admin             | adminUrl                                                 |
	| https://manage.barnehage.testaws.visma.com/SeleniumTestAutomation | Laimonas Samalius | https://manage.barnehage.testaws.visma.com/children/list |