

namespace AutomationFramework.PageConstants
{
    public class LabcorpCareerSearchConstantPage
    {
        public const string CareersLink = "Careers";
        public const string SearchBoxForJobTitleOrLocation = "//input[@type='text' and @id = 'typehead']";
        public const string ClickOnSubmitButton = "//button[@type = 'submit']";
        public const string ClickOnJobTitle = "//a[@data-ph-at-job-title-text = 'QA Test Automation Developer']";
        public const string VerifyJobTitle = "//div/h1[@class = 'job-title']";
        public const string VerifyJobLocation = "//span[2]/span[@class = 'au-target job-location']";
        public const string VerifyJobId = "//span/span[@class = 'au-target jobId']";
        public const string ClickOnApply = "(//a[@ph-tevent='apply_click'])[2]";
        public const string GoBackToResults = "//a[@class = 'phs-back-search-results au-target']";
    }
}
