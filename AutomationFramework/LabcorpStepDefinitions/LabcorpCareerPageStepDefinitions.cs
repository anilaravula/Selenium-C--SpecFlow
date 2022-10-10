using AutomationFramework.Data;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace AutomationFramework.LabcorpStepDefinitions
{
    [Binding]
    public class LabcorpCareerPageStepDefinitions
    {
        [Given(@"I login to Labcorp home page")]
        public void GivenILoginToLabcorpHomePage()
        {
            Driver.Initialize();

            Driver.GoTo();
        }

        [When(@"I click on careers link")]
        public void WhenIClickOnCareersLink()
        {
            Driver.Instance.FindElement(By.LinkText(PageConstants.LabcorpCareerSearchConstantPage.CareersLink)).Click();

            Driver.Instance.SwitchTo().Window(Driver.Instance.WindowHandles[1]);
        }

        [When(@"Search for job position")]
        public void WhenSearchForJobPosition()
        {
            var searchBox = Driver.Instance.FindElement(By.XPath(PageConstants.LabcorpCareerSearchConstantPage.SearchBoxForJobTitleOrLocation));
            searchBox.Click();
            searchBox.Clear();
            searchBox.SendKeys(LabcorpCareerData.JobRole + Keys.Enter);

            Driver.Instance.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            Driver.Instance.FindElement(By.XPath(PageConstants.LabcorpCareerSearchConstantPage.ClickOnSubmitButton)).Click();

            Driver.Instance.FindElement(By.XPath(PageConstants.LabcorpCareerSearchConstantPage.ClickOnJobTitle)).Click();
        }

        [When(@"Verify job title")]
        public void WhenVerifyJobTitle()
        {
            Assert.True(Driver.IsTextPresentWithinElement(Driver.Instance.FindElement(By.XPath(PageConstants.LabcorpCareerSearchConstantPage.VerifyJobTitle)), LabcorpCareerData.JobRole));
        }

        [When(@"Verify job location")]
        public void WhenVerifyJobLocation()
        {
            Assert.True(Driver.IsTextPresentOnEntirePage(LabcorpCareerData.Location));
        }

        [When(@"Verify job id")]
        public void WhenVerifyJobId()
        {
            var jobId = Driver.Instance.FindElement(By.XPath(PageConstants.LabcorpCareerSearchConstantPage.VerifyJobId)).Text;
            Assert.AreEqual(LabcorpCareerData.JobId, jobId);
        }

        [When(@"Verify text is present")]
        public void WhenVerifyTextIsPresent()
        {
            Assert.True(Driver.IsTextPresentOnEntirePage(LabcorpCareerData.RightCandidateText));

            Assert.True(Driver.IsTextPresentWithinElement(Driver.Instance.FindElement(By.XPath("//ul[2]/li[2]/p")), LabcorpCareerData.TestPlanText));

            Assert.True(Driver.IsTextPresentWithinElement(Driver.Instance.FindElement(By.XPath("//ul[4]/li[3]/p")), LabcorpCareerData.YearOfExperienceText));
        }

        [Then(@"Click on apply and go back to results")]
        public void ThenClickOnApplyAndGoBackToResults()
        {
            Driver.Instance.FindElement(By.XPath(PageConstants.LabcorpCareerSearchConstantPage.ClickOnApply)).Click();

            Driver.Instance.SwitchTo().Window(Driver.Instance.WindowHandles[1]);

            Driver.ScrollIntoView(By.XPath(PageConstants.LabcorpCareerSearchConstantPage.VerifyJobId));

            Driver.Instance.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);

            Driver.Instance.FindElement(By.XPath(PageConstants.LabcorpCareerSearchConstantPage.GoBackToResults)).Click();
        }
    }
}
