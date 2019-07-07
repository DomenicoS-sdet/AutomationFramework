using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using Drivers;
using Report.LogContainers;
using NUnit;
using Utility.Setup;
using System.Diagnostics;
using NUnit.Framework.Interfaces;
using NUnit.Framework;

namespace FeatureFiles
{
    [Binding]
    public class BeforeAfterSteps
    {
        private static TestRunLogger _logger;
        private static FeatureLogger _featureLogger;
        private static ScenarioLogger _scenarioLogger;
        private static StepLogger _stepLogger;
        private int _stepCounter = 0;

        private static Stopwatch _testRunDuration = new Stopwatch();
        private static Stopwatch _scenarioDuration = new Stopwatch();

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            _logger = new TestRunLogger();
            _testRunDuration.Start();

            //create folder for test results
            System.IO.Directory.CreateDirectory(Settings.ScreenshootPath);
        }

        [BeforeFeature]
        public static void BeforeFeature()
        {
            _featureLogger = new FeatureLogger();
            _featureLogger.FeatureTitle = FeatureContext.Current.FeatureInfo.Title;
            

        }

        [BeforeScenario(Order =1)]
        public void BeforeScenario()
        {
            _scenarioLogger = new ScenarioLogger();
            _scenarioLogger.ScenarioTitle = ScenarioContext.Current.ScenarioInfo.Title;
            _scenarioDuration.Start();
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
            _stepLogger.StepTitle = ScenarioStepContext.Current.StepInfo.StepDefinitionType + " " + ScenarioContext.Current.StepContext.StepInfo.Text;
            _stepCounter += 1;
        }

        [AfterStep]
        public void AfterStep()
        {
            var screenshotPath = $"{Settings.ScreenshootPath}\\{_stepCounter}_{Utility.Tools.GenerateRandomValue()}.jpg";
            _stepLogger.ScreenshotPath = Utility.Tools.TakeScreenshot(screenshotPath, Browser.browserSession);

            if (ScenarioContext.Current.TestError != null)
                _stepLogger.StepResult = "Failed";
            else
                _stepLogger.StepResult = "Passed";

            _scenarioLogger.AddStep(_stepLogger);
        }

        [AfterScenario(Order = 1)]
        public void AfterScenario()
        {
            _scenarioDuration.Stop();
            _scenarioLogger.ScenarioDuration = $"{_scenarioDuration.Elapsed.Hours}:{_scenarioDuration.Elapsed.Minutes}:{_scenarioDuration.Elapsed.Seconds}";

            //Save Scenario results based on the steps results
            if (_scenarioLogger.GetStepsList().Any(st => st.StepResult.Equals("Failed")))
            {
                _scenarioLogger.ScenarioResult = "Failed";
                _logger.TestRunFailed += 1;
            }
            else if (_scenarioLogger.GetStepsList().Any(st => st.StepResult.Equals("Inconclusive")))
            {
                _scenarioLogger.ScenarioResult = "Inconclusive";
                _logger.TestRunInconclusive += 1;
            }
            else
            {
                _scenarioLogger.ScenarioResult = "Passed";
                _logger.TestRunPassed += 1;
            }

            _featureLogger.AddScenario(_scenarioLogger);
        }

        [AfterScenario(Order =2)]
        public void CloseBrowser()
        {
            Browser.Close();
        }

        [AfterFeature]
        public static void AfterFeature()
        {
            _logger.AddFeature(_featureLogger);
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            _testRunDuration.Stop();
            _logger.TestRunExecutionTime = $"{_testRunDuration.Elapsed.Hours}:{_testRunDuration.Elapsed.Minutes}:{_testRunDuration.Elapsed.Seconds}";

            //calculate Test results count
            var scenarios = _logger.GetFeatures().Select(sc => sc.ReturnScenarios());
            _logger.TestRunTotal = scenarios.Count();

            //assign overall Test run results
            if (_logger.TestRunFailed > 0 || _logger.TestRunInconclusive > 0)
                _logger.TestRunResult = "Failed";
            else
                _logger.TestRunResult = "Passed";


            Report.ReportBuilder.SerialiseToJson(Settings.JsonPath, _logger);
        }
    }
}
