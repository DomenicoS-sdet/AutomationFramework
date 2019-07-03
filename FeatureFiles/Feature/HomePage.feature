Feature: HomePage
	

@HomePageTest
Scenario: Navigate to the Home Page
	Given I Navigate to the home page
	When I am on the home page
	Then The search button is available
