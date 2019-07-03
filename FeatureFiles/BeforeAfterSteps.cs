using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using Drivers;

namespace FeatureFiles
{
    [Binding]
    public class BeforeAfterSteps
    {
        [BeforeScenario]
        public void StartBrowser()
        {
            Browser.Open();
        }

        [AfterScenario]
        public void CloseBrowser()
        {
            Browser.Close();
        }
    }
}
