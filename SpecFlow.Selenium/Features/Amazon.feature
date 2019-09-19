Feature: Demo
		As a User,
		I can find information about libraries this demo uses

@C001
Scenario: Amazon Search - Open Product
	Given I am on "http://www.amazon.com"
	And I search for "Samsung Galaxy S9" 
	And select "Samsung Galaxy S9" in the search results
	When I enter the product and add it
	Then I create account
