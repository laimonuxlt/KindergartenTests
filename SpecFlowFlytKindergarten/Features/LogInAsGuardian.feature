Feature: Log In as Guardian
	Simple calculator for adding two numbers

@mytag
Scenario: Log in selected guardian
	Given  Log in page for guardian is displayed	
	When the user selects the guardian
		| guardian			|
		| Laimonas Samalius	|
	And the user clicks log in button
	Then the guardian site main page is displayed