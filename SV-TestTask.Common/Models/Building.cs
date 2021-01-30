using System;
using System.Buffers;
using System.Collections;
using System.Collections.Generic;

namespace SV_TestTask.Common.Models
{

    public class Building
    {
        public Guid Id { get; set; }
        [SearchEngineRelevanceScore(7)]
        public string ShortCut { get; set; }
        [SearchEngineRelevanceScore(9)]
        public string Name { get; set; }
        [SearchEngineRelevanceScore(5)]
        public string Description { get; set; }
        public IEnumerable<Lock> Locks { get; set; }
    }
}