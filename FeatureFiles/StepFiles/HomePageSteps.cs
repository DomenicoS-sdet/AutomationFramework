using Microsoft.VisualStudio.TestTools.UnitTesting;
using PageObjects.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace FeatureFiles.StepFiles
{
    [Binding]
    public class HomePageSteps
    {
        [Given(@"I Navigate to the home page")]
        public void GivenINavigateToTheHomePage()
        {
            Pages.HomePage.Goto();
        }

        [When(@"I am on the home page")]
        public void WhenIAmOnTheHomePage()
        {
            Assert.IsTrue(Pages.HomePage.IsAt());
        }

        [Then(@"The search button is available")]
        public void ThenTheSearchButtonIsAvailable()
        {
            Assert.IsTrue(Pages.HomePage.IsHomePageReady(), "The home page is not ready yet");
        }

    }
}
