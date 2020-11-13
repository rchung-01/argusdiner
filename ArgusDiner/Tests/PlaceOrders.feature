Feature: PlaceOrders
	In order to ensure customers are billed the correct total amount
	As a waiter
	I want to be able to calculate the correct number of order items 

@mytag
Scenario: Service charge is only applied to food items
	Given a new order
	When an order of 4 starters
	And an order of 4 mains
	And an order of 4 drinks
	And the order is placed
	Then the total bill is 62.80 gbp



Scenario Outline: Total bill amount is updated when more items are added to the order
	Given a new order 
	When an order of <noOfStarters> starters
	And an order of <noOfMains> mains
	And an order of <noOfDrinks> drinks
	And the order is placed
	Then the total bill is <amount> gbp

	Examples: 
	| noOfStarters | noOfMains | noOfDrinks | amount |
	| 1            | 2         | 0          | 21.60  | 
	| 1            | 4         | 0          | 38.40  |


Scenario Outline: Total bill amount is updated when items are removed from the order
	Given a new order 
	When an order of <noOfStarters> starters
	And an order of <noOfMains> mains
	And an order of <noOfDrinks> drinks
	And the order is placed
	Then the total bill is <amount> gbp

	Examples: 
	| noOfStarters | noOfMains | noOfDrinks | amount |
	| 4            | 4         | 4          | 62.80  |
	| 3            | 3         | 3          | 47.10  |