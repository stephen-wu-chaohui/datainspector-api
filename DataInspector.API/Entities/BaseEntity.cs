using System;

namespace DataInspector.API.Entities
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime LastUpdated { get; set; }
        public bool Deleted { get; set; }
    }
}
