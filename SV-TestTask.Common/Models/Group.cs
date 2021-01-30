using System;
using System.Collections;
using System.Collections.Generic;

namespace SV_TestTask.Common.Models
{
    public class Group
    {
        public Guid Id { get; set; }
        [SearchEngineRelevanceScore(9)]
        public string Name { get; set; }
        [SearchEngineRelevanceScore(5)]
        public string Description { get; set; }
        public IEnumerable<Medium> Media { get; set; }
    }
}