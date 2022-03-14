Feature: AngularBusyTest
	Angular developer wants to tests different set of busy loading indicators

@mytag
Scenario Outline: User testing busy loading indicators
	Given a user wants to test busy loading indicators
	And the user wants to add a delay of <time> ms
	And the user wants the test to display <message> while waiting
	And the user wants to see <template> busy indicator animation
	When the user tries to test busy indicator with provided message
	Then the system displays <message> to the user

	Examples:
		| time | message        | template             |
		| 1000 | Please Wait... | Standard             |
		| 3000 | Waiting        | custom-template.html |
#
#