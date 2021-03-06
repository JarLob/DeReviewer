using System.Collections.Generic;
using DeReviewer.Analysis;

namespace DeReviewer
{
    public class PatternGroup
    {
        public PatternGroup(string name, List<PatternInfo> patterns)
        {
            Name = name;
            Patterns = patterns;
        }

        public string Name { get; }
        public List<PatternInfo> Patterns { get; }
    }
}