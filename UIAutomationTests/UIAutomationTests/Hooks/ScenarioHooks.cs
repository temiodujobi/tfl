using TechTalk.SpecFlow;

namespace UIAutomationTests.Hooks
{
    [Binding]
    public sealed class ScenarioHooks
    {
        [BeforeScenario]
        public static void BeforeScenario(BrowserContext browserContext)
        {
            browserContext.LaunchApplication();
        }

        [AfterScenario]
        public static void AfterScenario(BrowserContext browserContext)
        {
            browserContext.ShutDownApplication();
        }
    }
}
