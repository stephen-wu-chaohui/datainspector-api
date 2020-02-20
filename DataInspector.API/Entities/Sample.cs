using System.ComponentModel.DataAnnotations.Schema;

namespace DataInspector.API.Entities
{
    public class Sample : BaseEntity
    {
        [ForeignKey("Sensor")]
        public int SensorId { get; set; }

        public double Value { get; set; }

        public int SampleTime { get; set; }
    }
}
