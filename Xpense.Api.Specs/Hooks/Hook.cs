using Xpense.Api.Specs.Infrastructure;

namespace Xpense.Api.Specs.Hooks
{
    [Binding]
    public class Hooks
    {
        private static TestContext _testContext;

        [BeforeScenario]
        public void BeforeScenario()
        {
            _testContext = new TestContext();
        }

        [AfterScenario]
        public void AfterScenario()
        {
            _testContext.Dispose();
            _testContext = null;
        }
    }
}