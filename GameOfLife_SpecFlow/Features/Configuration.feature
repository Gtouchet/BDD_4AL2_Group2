Feature: Configuration

@WorldLength
Scenario: Create a randomly generated world
	Given the world's height is 5
	And the world's width is 3
	When initializing the engine
	Then the world's length should be 15