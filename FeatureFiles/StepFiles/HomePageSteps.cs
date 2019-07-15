using Microsoft.VisualStudio.TestTools.UnitTesting;
using PageObjects.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using Utility.HelperObjects;

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

        [When(@"I fill the hotel search with the following data")]
        public void WhenIFillTheHotelSearchWithTheFollowingData(Table table)
        {
            HotelSearch hotelSearch = table.CreateInstance<HotelSearch>();
            Pages.HomePage.FillHotelSearchFields(hotelSearch);
        }

        [When(@"I click on the button Search")]
        public void WhenIClickOnTheButtonSearch()
        {
            Pages.HomePage.StartSearch();
        }


        [Then(@"The search button is available")]
        public void ThenTheSearchButtonIsAvailable()
        {
            Assert.IsTrue(Pages.HomePage.IsHomePageReady(), "The home page is not ready yet");
        }

    }
}
