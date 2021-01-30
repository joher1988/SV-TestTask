using System;

namespace SV_TestTask.Common
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = true)]
    public class SearchEngineRelevanceScoreAttribute : Attribute
    {
        private readonly int _relevanceScore;
        private readonly string _transitiveField;

        public SearchEngineRelevanceScoreAttribute(int relevanceScore, string transitiveField = null)
        {
            _relevanceScore = relevanceScore;
            _transitiveField = transitiveField;
        }
    }
}