using System;
using System.Collections;
using System.Collections.Generic;

namespace SV_TestTask.Common.Models
{
    public class Group: EntityBase
    {
        [SearchEngineOwnRelevanceScore(9)]
        public string Name { get; set; }
        [SearchEngineOwnRelevanceScore(5)]
        public string Description { get; set; }
    }
}