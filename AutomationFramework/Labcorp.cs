using AutomationFramework.Data;
using NUnit.Framework;
using OpenQA.Selenium;

namespace AutomationFramework
{
    public class Labcorp
    {
        public static void LabCorp()
        {
            GoToLabcorpHomePage();
            ClickOnCareersLink();
            SearchForJobPosition();
            VerifyJobTitleLocationAndId();
            VerifyTextIsPresent();
            ClickOnApplyAndGoBackToResults();
        }

        public static void GoToLabcorpHomePage()
        {    
            Driver.Initialize();
            Driver.GoTo();
        }

        public static void ClickOnCareersLink()
        {
            Driver.Instance.FindElement(By.LinkText(PageConstants.LabcorpCareerSearchConstantPage.CareersLink)).Click();

            Driver.Instance.SwitchTo().Window(Driver.Instance.WindowHandles[1]);
        }

        public static void SearchForJobPosition()
        {
            var searchBox = Driver.Instance.FindElement(By.XPath(PageConstants.LabcorpCareerSearchConstantPage.SearchBoxForJobTitleOrLocation));
            searchBox.Click();
            searchBox.Clear();
            searchBox.SendKeys(LabcorpCareerData.JobRole + Keys.Enter);

            Driver.Instance.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            Driver.Instance.FindElement(By.XPath(PageConstants.LabcorpCareerSearchConstantPage.ClickOnSubmitButton)).Click();

            Driver.Instance.FindElement(By.XPath(PageConstants.LabcorpCareerSearchConstantPage.ClickOnJobTitle)).Click();
        }

        public static void VerifyJobTitleLocationAndId()
        {
            //Job Title
            Assert.True(Driver.IsTextPresentWithinElement(Driver.Instance.FindElement(By.XPath(PageConstants.LabcorpCareerSearchConstantPage.VerifyJobTitle)), LabcorpCareerData.JobRole));

            //Job Location
            Assert.True(Driver.IsTextPresentOnEntirePage(LabcorpCareerData.Location));

            //Job Id
            var jobId = Driver.Instance.FindElement(By.XPath(PageConstants.LabcorpCareerSearchConstantPage.VerifyJobId)).Text;
            Assert.AreEqual(LabcorpCareerData.JobId, jobId);
        }

        public static void VerifyTextIsPresent()
        {
            Assert.True(Driver.IsTextPresentOnEntirePage(LabcorpCareerData.RightCandidateText));

            Assert.True(Driver.IsTextPresentWithinElement(Driver.Instance.FindElement(By.XPath("//ul[2]/li[2]/p")), LabcorpCareerData.TestPlanText));

            Assert.True(Driver.IsTextPresentWithinElement(Driver.Instance.FindElement(By.XPath("//ul[4]/li[3]/p")), LabcorpCareerData.YearOfExperienceText));
        }

        public static void ClickOnApplyAndGoBackToResults()
        {
            Driver.Instance.FindElement(By.XPath(PageConstants.LabcorpCareerSearchConstantPage.ClickOnApply)).Click();

            Driver.Instance.SwitchTo().Window(Driver.Instance.WindowHandles[1]);

            Driver.ScrollIntoView(By.XPath(PageConstants.LabcorpCareerSearchConstantPage.GoBackToResults));

            Driver.Instance.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);

            Driver.Instance.FindElement(By.XPath(PageConstants.LabcorpCareerSearchConstantPage.GoBackToResults)).Click();
        }
    }
}
