using System;

namespace SV_TestTask.Common.Models
{
    public class Medium:EntityBase
    {
        public Guid Id { get; set; }
        [SearchEngineRelevanceScore(8, nameof(Group.Name))]
        [SearchEngineRelevanceScore(6,nameof(Group.Description))]
        public Guid GroupId { get; set; }
        [SearchEngineRelevanceScore(3)]
        public MediumType Type { get; set; }
        [SearchEngineRelevanceScore(10)]
        public string Owner { get; set; }
        [SearchEngineRelevanceScore(8)]
        public string SerialNumber { get; set; }
        [SearchEngineRelevanceScore(6)]
        public string Description { get; set; }
    }
}