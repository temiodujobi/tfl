using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using UIAutomationTests.Hooks;
using OpenQA.Selenium.Support.Extensions;

namespace UIAutomationTests.Pages
{
    public class BasePage
    {
        public BrowserContext Context;

        public BasePage(BrowserContext context)
        {
            Context = context;
        }

        protected IWebElement StartField => Context.Driver.FindElement(By.Id("InputFrom"));
        protected IWebElement DestinationField => Context.Driver.FindElement(By.Id("InputTo"));
        protected IWebElement StartFieldDataSet => Context.Driver.FindElement(By.Id("InputFrom-dropdown"));
        protected IWebElement DestinationFieldDataSet => Context.Driver.FindElement(By.Id("InputTo-dropdown"));
        protected IWebElement HomePageLink => Context.Driver.FindElement(By.ClassName("tfl-name"));
        protected IWebElement PlanJourneyButton => Context.Driver.FindElement(By.Id("plan-journey-button"));

        public string PageTitleText => Context.Driver.Title;

        public WebDriverWait WebDriverWait => new(Context.Driver, TimeSpan.FromSeconds(60));

        protected void InputJourneyFrom(string start, bool waitForSearchResult = true)
        {
            StartField.SendKeys(start);
            if (!waitForSearchResult) return;
            WebDriverWait.Until(_ => StartFieldDataSet.Displayed);
            StartField.SendKeys(Keys.ArrowDown);
            StartField.SendKeys(Keys.Enter);
        }
        protected void InputJourneyTo(string destination, bool waitForSearchResult = true)
        {
            DestinationField.SendKeys(destination);
            if (!waitForSearchResult) return;
            WebDriverWait.Until(_ => DestinationFieldDataSet.Displayed);
            DestinationField.SendKeys(Keys.ArrowDown);
            DestinationField.SendKeys(Keys.Enter);
            DestinationField.SendKeys(Keys.Tab);
        }

        public bool PageInReadyState
        {
            get
            {
                try
                {
                    return Context.Driver.ExecuteJavaScript<string>("return document.readyState").Equals("complete");
                }
                catch (Exception)
                {
                    return true;
                }
            }
        }
    }
}
