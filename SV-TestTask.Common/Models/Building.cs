using System;
using System.Buffers;
using System.Collections;
using System.Collections.Generic;

namespace SV_TestTask.Common.Models
{

    public class Building:EntityBase
    {
        [SearchEngineOwnRelevanceScore(7)]
        public string ShortCut { get; set; }
        [SearchEngineOwnRelevanceScore(9)]
        public string Name { get; set; }
        [SearchEngineOwnRelevanceScore(5)]
        public string Description { get; set; }
    }
}