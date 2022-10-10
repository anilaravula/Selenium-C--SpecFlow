using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace AutomationFramework
{
    [SetUpFixture]
    public class Driver
    {
        public static IWebDriver Instance { get; set; }

        public static string BaseUrl { get; set; } = "https://www.labcorp.com/";

        [OneTimeSetUp]
        public static void Initialize()
        {
            if (Instance != null)
            {
                return;
            }

            InitializeChromeDriver();
        }

        private static void InitializeChromeDriver()
        {
            Instance = new ChromeDriver();

            Instance.Manage().Window.Maximize();

            SetImplicitWait(5);
        }

        [OneTimeTearDown]
        public static void Close()
        {
            if (Instance != null)
            {
                Instance.Quit();
                Instance = null;
            }
        }

        public static void GoTo()
        {
            if(Instance == null)
            {
                throw new NullReferenceException();
            }
            Instance.Navigate().GoToUrl(BaseUrl);

            Console.WriteLine($"Navigated to : {Instance.Url}");
        }

        public static bool IsTextPresentWithinElement(IWebElement element, string textToFind)
        {
            if (element != null && element.Text.Contains(textToFind))
                return true;
            return false;
        }

        public static bool IsTextPresentOnEntirePage(string text)
        {
            var element = Instance.FindElement(By.TagName("html"));

            if (element.Displayed && element.Text.Contains(text))
                return true;
            return false;
        }

        public static void ScrollIntoView(By bBy)
        {
            var e = Instance.FindElement(bBy);
            ((IJavaScriptExecutor)Instance).ExecuteScript("arguments[0].scrollIntoView(true);", e);
        }

        public static void WaitExplicitly(TimeSpan timeSpan)
        {
            Thread.Sleep((int)(timeSpan.TotalSeconds * 1000));
        }

        public static void SetImplicitWait(int seconds)
        {
            Instance.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(seconds);
        }
    }
}