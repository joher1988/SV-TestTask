using System;

namespace SV_TestTask.Common.Models
{
    public class Lock: EntityBase
    {
        public Guid Id { get; set; }
        [SearchEngineTransitiveRelevanceScore(8, nameof(Building.Name))]
        [SearchEngineTransitiveRelevanceScore(5,nameof(Building.ShortCut))]
        [SearchEngineTransitiveRelevanceScore(0, nameof(Building.Description))]
        public Guid BuildingId { get; set; }
        [SearchEngineOwnRelevanceScore(10)]
        public string Name { get; set; }
        [SearchEngineOwnRelevanceScore(3)]
        public LockType Type { get; set; }
        [SearchEngineOwnRelevanceScore(8)]
        public string SerialNumber { get; set; }
        [SearchEngineOwnRelevanceScore(6)]
        public string Floor { get; set; }
        [SearchEngineOwnRelevanceScore(6)]
        public string RoomNumber { get; set; }
        [SearchEngineOwnRelevanceScore(6)]
        public string Description { get; set; }
    }
}