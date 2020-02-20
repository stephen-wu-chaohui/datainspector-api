using System.ComponentModel.DataAnnotations.Schema;

namespace DataInspector.API.Entities
{
    public class Site : BaseEntity
    {
        [ForeignKey("Project")]
        public int ProjectId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}
