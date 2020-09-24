Feature: DingTest
	In order to check automated tests 

@NegativeTest
Scenario: Test Paypal sandbox with empty password
	Given The a browser like 'Chrome' Go to the PayPal Signin Page
	And Write the username as <Username>
	When I click next button
	And Write the password as <Password>
	When I click login
	Then Then the <ErrorMessage> is displayed

	Examples:
		| Username       | Password | ErrorMessage         |
		| jose@yahoo.com |          | Password is required |

@NegativeTest
Scenario: Test Paypal sandbox with wrong password
	Given The a browser like 'Chrome' Go to the PayPal Signin Page
	And Write the username as <Username>
	When I click next button
	And Write the password as <Password>
	When I click login
	Then The Bad Password Error <WrongPasswordError> is displayed

	Examples:
		| Username        | Password    | WrongPasswordError                                        |
		| jose1@yahoo.com | badpassword | Some of your information isn't correct. Please try again. |

@NegativeTest
Scenario: Test Paypal sandbox with wrong phone number
	Given The a browser like 'Chrome' Go to the PayPal Signin Page
	And Write the username as <Username>
	When I click next button
	Then The Bad Number Error <WrongPhoneNumber> is displayed

	Examples:
		| Username | WrongPhoneNumber                                                                     |
		| 11111111 | You haven’t confirmed your mobile number yet. Please use your email address for now. |