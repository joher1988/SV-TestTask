using System;

namespace SV_TestTask.Common.Models
{
    public class Medium:EntityBase
    {
        [SearchEngineTransitiveRelevanceScore(8, nameof(Group.Name), typeof(Group))]
        [SearchEngineTransitiveRelevanceScore(6,nameof(Group.Description), typeof(Group))]
        public Guid GroupId { get; set; }
        [SearchEngineOwnRelevanceScore(3)]
        public MediumType Type { get; set; }
        [SearchEngineOwnRelevanceScore(10)]
        public string Owner { get; set; }
        [SearchEngineOwnRelevanceScore(8)]
        public string SerialNumber { get; set; }
        [SearchEngineOwnRelevanceScore(6)]
        public string Description { get; set; }
    }
}