Feature: ActivityLogTabPageTests
	
Background: 
Given the user is logged in as guardian
Given the user clicked  Admisions tab
Given the user clicked For approval tab

Scenario: the Documentation Tab is diplayed
	Given the user selected the child from the list	
	When  the user selects the child from the list
	Then the Documentation tab is diplayed

Scenario: The Documention tab is displaying correct information
	Given the user selected the child
	When the documentation tab is displayed
	Then child's full name is displayed
	Then child's day of birth is displayed
	Then cilds's full address is displyed
	Then applicant's full name is dispalyed
	Then applicant's full address is diplayed

Scenario: deviation are solved
	Given the user is at Deviations tab
	And deviations to be solved are displayed
	When  the user clicks not resolved deviation's resolve button 
	Then  the deviation gets resolved 

Scenario: events are registerd in Activity log tab
	Given the user is at Activity log tab
	And the user clicked Documentatio tab
	When the user clics Activity tab
	Then Documentaion tab visit is diplayed


