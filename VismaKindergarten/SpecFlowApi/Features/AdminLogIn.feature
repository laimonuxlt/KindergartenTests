Feature: Log in as Administrator
	


Scenario: Log in as existing Administrator
	Given the admin with <identityNumber>
	When a POST request is made to https://api.manage.barnehage.testaws.visma.com/localaccount/signin with 
	
	"""
	{
	"onBehalfOf": "SeleniumTestAutomation",
    "languageCode": "en-US",
    "identityNumber": "03101885525"
	}
	"""

	Then the response should contain Status "200" <ok>
	
	Examples:
	| identityNumber | ok |
	| 03101885525    | OK |