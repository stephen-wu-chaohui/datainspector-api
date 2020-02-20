using System.ComponentModel.DataAnnotations.Schema;

namespace DataInspector.API.Entities
{
    public class Sensor : BaseEntity
    {
        [ForeignKey("Site")]
        public int SiteId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}
