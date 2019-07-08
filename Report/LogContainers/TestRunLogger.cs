using System;
using System.Collections.Generic;
using System.Text;

namespace Report.LogContainers
{
    public class TestRunLogger
    {
        public List<FeatureLogger> _features = new List<FeatureLogger>();

        public string TestExecutionDate { get; set; }
        public string TestRunResult { get; set; }
        public string TestRunExecutionTime { get; set; }
        public int TestRunTotal { get; set; }
        public int TestRunFailed { get; set; }
        public int TestRunPassed { get; set; }
        public int TestRunInconclusive { get; set; }

        /// <summary>
        /// Add a new Feature inside the feature list in the overall Test Run logger
        /// </summary>
        /// <param name="feature"></param>
        public void AddFeature(FeatureLogger feature) => _features.Add(feature);
        public List<FeatureLogger> GetFeatures() => _features;
    }
}
