using System;

namespace SV_TestTask.Common
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class SearchEngineOwnRelevanceScoreAttribute : Attribute
    {
        private readonly int _relevanceScore;
        private readonly string _transitiveField;

        public SearchEngineOwnRelevanceScoreAttribute(int relevanceScore, string transitiveField = null)
        {
            _relevanceScore = relevanceScore;
            _transitiveField = transitiveField;
        }
    }
}