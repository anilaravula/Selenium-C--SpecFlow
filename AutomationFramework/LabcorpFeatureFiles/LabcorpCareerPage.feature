Feature: LabcorpCareerPage

Search for QA Test Automation Developer position in Labcorp job listing

@Test
Scenario: Search for QA Test position in Labcorp Career builder
	Given I login to Labcorp home page
	When I click on careers link
	And Search for job position
	And Verify job title
	And Verify job location
	And Verify job id
	And Verify text is present
	Then Click on apply and go back to results
