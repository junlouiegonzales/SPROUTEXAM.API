using SPROUTEXAM.Domain.Enums;

namespace SPROUTEXAM.Domain.Entities
{
    public class Weather : BaseEntity
    {
        public WeatherType Type { get; set; }
        public int Temperature { get; set; }
        public string Wind { get; set; }
        public string Precipitation { get; set; }
        public string Summary { get; set; }
    }
}