using System;

namespace SV_TestTask.Common
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public class SearchEngineTransitiveRelevanceScoreAttribute : Attribute
    {
        private readonly int _relevanceScore;
        private readonly string _transitivePropertyName;

        public SearchEngineTransitiveRelevanceScoreAttribute(int relevanceScore, string transitivePropertyName)
        {
            _relevanceScore = relevanceScore;
            _transitivePropertyName = transitivePropertyName;
        }
    }
}