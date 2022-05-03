using OpenQA.Selenium;
using System;
using UIAutomationTests.Hooks;

namespace UIAutomationTests.Pages
{
    public class HomePage : BasePage
    {
        public HomePage(BrowserContext context) : base(context)
        {
        }
        
        private IWebElement AcceptAllCookiesButton => Context.Driver.FindElement(By.Id("CybotCookiebotDialogBodyLevelButtonLevelOptinAllowAll"));
        private IWebElement CookieDoneButton => Context.Driver.FindElement(By.XPath("//button[contains(@onclick,'endCookieProcess')]"));
        private IWebElement RecentTabLink => Context.Driver.FindElement(By.Id("jp-recent-tab-home"));
        public string InputFromFieldErrorMessage => Context.Driver.FindElement(By.Id("InputFrom-error")).Text;
        public string InputToFieldErrorMessage => Context.Driver.FindElement(By.Id("InputTo-error")).Text;
       
        public JourneyResultsPage PlanValidJourney(string start, string destination)
        {
            InputJourneyFrom(start);
            InputJourneyTo(destination);
            var resultPage = SubmitJourney();
            return resultPage;
        }

        public HomePage PlanJourneyWithoutLocations()
        {
            PlanJourneyButton.Click();
            return this;
        }

        public HomePage PlanInvalidJourney(string to, string from)
        {
            InputJourneyFrom(to, false);
            InputJourneyTo(from, false);
            PlanJourneyButton.Click();
            return this;
        }

        public JourneyResultsPage SubmitJourney()
        {
            PlanJourneyButton.Click();
            WebDriverWait.Until(_ => PageInReadyState);
            return new JourneyResultsPage(Context);
        }

        public HomePage NavigateToHomePage()
        {
            HomePageLink.Click();
            WebDriverWait.Until(_ => PageInReadyState);
            return this;
        } 
         
        public void AcceptCookies()
        {
            try
            {
                WebDriverWait.Until(_ => AcceptAllCookiesButton.Displayed);
                AcceptAllCookiesButton.Click();
                WebDriverWait.Until(_ => CookieDoneButton.Displayed);
                CookieDoneButton.Click();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void ClickRecentTab()
        {
            WebDriverWait.Until(_ => RecentTabLink.Displayed);
            RecentTabLink.Click();
        } 

        public string RecentlyPlannedJourneys()
        {
            var plannedJourney = Context.Driver.FindElement(By.Id("jp-recent-content-home-"));
            WebDriverWait.Until(_ => plannedJourney.Displayed);
            return plannedJourney.Text;
        }
    }
}
