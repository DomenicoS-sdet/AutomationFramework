using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using Drivers;
using Report.LogContainers;
using NUnit;

namespace FeatureFiles
{
    [Binding]
    public class BeforeAfterSteps
    {
        private TestRunLogger _logger;
        private FeatureLogger _featureLogger;
        private ScenarioLogger _scenarioLogger;
        private StepLogger _stepLogger;

        [BeforeTestRun]
        public void BeforeTestRun()
        {
            _logger = new TestRunLogger();
        }

        [BeforeFeature]
        public void BeforeFeature()
        {
            _featureLogger = new FeatureLogger();
            _featureLogger.FeatureTitle = FeatureContext.Current.FeatureInfo.Title;
            _logger.AddFeature(_featureLogger);

        }

        [BeforeScenario(Order =1)]
        public void BeforeScenario()
        {
            _scenarioLogger = new ScenarioLogger();
            _scenarioLogger.ScenarioTitle = ScenarioContext.Current.ScenarioInfo.Title;
            _featureLogger.AddScenario(_scenarioLogger);
        }

        [BeforeScenario(Order =2)]
        public void StartBrowser()
        {
            Browser.Open();
        }

        [BeforeStep]
        public void BeforeStep()
        {
            _stepLogger = new StepLogger();
            _stepLogger.StepTitle = ScenarioContext.Current.StepContext.StepInfo.Text;
            _scenarioLogger.AddStep(_stepLogger);
        }

        [AfterStep]
        public void AfterStep()
        {

        }

        [AfterScenario(Order = 1)]
        public void AfterScenario()
        {

        }

        [AfterScenario(Order =2)]
        public void CloseBrowser()
        {
            Browser.Close();
        }

        [AfterFeature]
        public void AfterFeature()
        {

        }

        [AfterTestRun]
        public void AfterTestRun()
        {

        }
    }
}
