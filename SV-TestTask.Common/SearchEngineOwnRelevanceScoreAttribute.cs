using System;

namespace SV_TestTask.Common
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class SearchEngineOwnRelevanceScoreAttribute : Attribute
    {
        public int RelevanceScore { get; }
        public SearchEngineOwnRelevanceScoreAttribute(int relevanceScore)
        {
            RelevanceScore = relevanceScore;
        }
    }
}