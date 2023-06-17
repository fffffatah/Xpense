Feature: Category
	As a user
	I want to be able to add expense categories

Scenario: Add Expense Category - Successful Request
	Given an expense category request with name "Food"
	When I send a POST request to "Category/add/category"
	Then the response status should be OK
	
Scenario: Add Expense Category - Invalid Request
	Given an expense category request with name ""
	When I send a POST request to "Category/add/category"
	Then the response status should be BadRequest

Scenario Outline: Add Expense Category - Validation Errors
	Given an expense category request with name "<Name>"
	When I send a POST request to "Category/add/category"
	Then the response status should be BadRequest

	Examples:
		  | Name        |
		  | "Groceries" |
		  | "Transport" |