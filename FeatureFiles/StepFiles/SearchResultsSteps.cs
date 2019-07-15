
using NUnit.Framework;
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
    public class SearchResultsSteps
    {
        [Then(@"a list of hotels is returned")]
        public void ThenAListOfHotelsIsReturned()
        {
            Assert.IsTrue(Pages.SearchResultsPage.IsListOfResultsReturned(), "No result returned by the search");
        }

    }
}
