using System;

namespace SV_TestTask.Common.Models
{
    public class Lock
    {
        public Guid Id { get; set; }
        [SearchEngineRelevanceScore(8, nameof(Building.Name))]
        [SearchEngineRelevanceScore(5,nameof(Building.ShortCut))]
        [SearchEngineRelevanceScore(0, nameof(Building.Description))]
        public Guid BuildingId { get; set; }
        [SearchEngineRelevanceScore(10)]
        public string Name { get; set; }
        [SearchEngineRelevanceScore(3)]
        public LockType Type { get; set; }
        [SearchEngineRelevanceScore(8)]
        public string SerialNumber { get; set; }
        [SearchEngineRelevanceScore(6)]
        public string Floor { get; set; }
        [SearchEngineRelevanceScore(6)]
        public string RoomNumber { get; set; }
        [SearchEngineRelevanceScore(6)]
        public string Description { get; set; }
    }
}