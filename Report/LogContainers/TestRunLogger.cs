using System;
using System.Collections.Generic;
using System.Text;

namespace Report.LogContainers
{
    public class TestRunLogger
    {
        private List<FeatureLogger> _features = new List<FeatureLogger>();

        public string TestRunResult { get; set; }
        public string TestRunExecutionTime { get; set; }

        public void AddFeature(FeatureLogger feature) => _features.Add(feature);
        public List<FeatureLogger> GetFeatures() => _features;
    }
}
