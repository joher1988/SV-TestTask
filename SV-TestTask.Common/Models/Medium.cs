using System;

namespace SV_TestTask.Common.Models
{
    public class Medium
    {
        public Guid Id { get; set; }
        public Guid GroupId { get; set; }
        public MediumType Type { get; set; }
        public string Owner { get; set; }
        public string SerialNumber { get; set; }
        public string Description { get; set; }
    }
}