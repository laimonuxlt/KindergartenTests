Feature: Login As Guardian


Scenario: Log in selected guardian
	Given  Log in page 'https://barnehage.testaws.visma.com/SeleniumTestAutomation' is displayed	
	When the user selects 'Laimonas Samalius'  as guardian 
	And the user clicks log in button
	Then the guardian site main page is displayed
	Then the logged guardian name 'Laimonas Samalius' is displayed

