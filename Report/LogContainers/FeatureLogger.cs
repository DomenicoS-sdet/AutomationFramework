using System;
using System.Collections.Generic;
using System.Text;

namespace Report.LogContainers
{
    public class FeatureLogger
    {
        private List<ScenarioLogger> _scenarios = new List<ScenarioLogger>();
        public string FeatureTitle { get; set; }

        public void AddScenario(ScenarioLogger scenarioLogger) => _scenarios.Add(scenarioLogger);
        public List<ScenarioLogger> ReturnScenarios() => _scenarios;
    }
}
