using OpenQA.Selenium;
using UIAutomationTests.Hooks;

namespace UIAutomationTests.Pages
{
    public class JourneyResultsPage : BasePage
    {
        public JourneyResultsPage(BrowserContext context) : base(context)
        {
        }

        private IWebElement EditJourney => Context.Driver.FindElement(By.ClassName("edit-journey"));
        private IWebElement UpdateJourneyButton => Context.Driver.FindElement(By.Id("plan-journey-button"));
        private IWebElement ClearToLocation => Context.Driver.FindElement(By.XPath("//a[contains(text(),'Clear To location')]"));
        private IWebElement JourneyResultSummaryFrom =>
            Context.Driver.FindElement(By.ClassName("journey-result-summary"));
       public string ResultPageHeading => Context.Driver.FindElement(By.ClassName("jp-results-headline")).Text;
        public string InvalidJourneyResultMessage => Context.Driver.FindElement(By.CssSelector("ul.field-validation-errors>li")).Text;

        public string JourneyResultSummaryFromText => JourneyResultSummaryFrom.Text;

        public void UpdateJourneyDestination(string to)
        {
            EditJourneyResult(to);
        }
        
        private void EditJourneyResult(string to)
        {
            EditJourney.Click();
            ClearToLocation.Click();
            InputJourneyTo(to);
            UpdateJourneyButton.Click();
        }
    }
}
