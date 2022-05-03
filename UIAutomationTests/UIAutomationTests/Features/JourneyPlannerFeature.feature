@JourneyPlanner
Feature: JourneyPlannerFeature

Scenario: 1. Plan a valid journey
	Given user is on the TfL home page
	When user plans a journey from 'Welling' to 'London Bridge'
	Then user should be presented with the Journey Results
		| From    | To            |
		| Welling | London Bridge |

Scenario: 2. Invalid Journey
	Given user is on the TfL home page
	When user plans an invalid journey
	Then user should be presented with the Journey Results page with an error message

Scenario: 3. Display error messages when no locations are entered
	Given user is on the TfL home page
	When user tries to plan a journey without locations
	Then user should be presented with required fields error messages
	| From                        | To                        |
	| The From field is required. | The To field is required. |

Scenario: 4. Edit a journey
	Given user is on the TfL home page
	And user plans a journey from 'Welling' to 'London Bridge'
	When user changes the destination to 'London Victoria'
	Then user should be presented with the Journey Results
		| From    | To              |
		| Welling | London Victoria |

Scenario: 5. Check recently planned journeys
	Given user is on the TfL home page
	And user plans a journey from 'Welling' to 'London Bridge'
	And user is presented with the Journey Results
		| From    | To            |
		| Welling | London Bridge |
	When user checks the recent planned journeys
	Then user should be presented with recently planned journeys
		| From    | To            |
		| Welling | London Bridge |
