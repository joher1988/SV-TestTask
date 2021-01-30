using System;

namespace SV_TestTask.Common.Models
{
    public class Medium:EntityBase
    {
        public Guid Id { get; set; }
        [SearchEngineTransitiveRelevanceScore(8, nameof(Group.Name))]
        [SearchEngineTransitiveRelevanceScore(6,nameof(Group.Description))]
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