using System;
using System.Collections.Generic;
using System.Text;

namespace Report.LogContainers
{
    public class FeatureLogger
    {
        public List<ScenarioLogger> _scenarios = new List<ScenarioLogger>();
        public string FeatureTitle { get; set; }

        /// <summary>
        /// Add a new Scenario inside the Scenario List in the Feature logger
        /// </summary>
        /// <param name="scenarioLogger"></param>
        public void AddScenario(ScenarioLogger scenarioLogger) => _scenarios.Add(scenarioLogger);
        public List<ScenarioLogger> ReturnScenarios() => _scenarios;
    }
}
