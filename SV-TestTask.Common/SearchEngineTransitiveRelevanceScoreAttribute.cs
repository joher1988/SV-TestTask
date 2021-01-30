using System;

namespace SV_TestTask.Common
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public class SearchEngineTransitiveRelevanceScoreAttribute : SearchEngineOwnRelevanceScoreAttribute
    {
        public string TransitivePropertyName { get; }
        public Type TransitivePropertyType { get; }

        public SearchEngineTransitiveRelevanceScoreAttribute(int relevanceScore, string transitivePropertyName, Type transitivePropertyType):base(relevanceScore)
        {
            TransitivePropertyName = transitivePropertyName;
            TransitivePropertyType = transitivePropertyType;
        }
    }
}