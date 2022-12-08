using SPROUTEXAM.Domain.Enums;

namespace SPROUTEXAM.Application.WeatherForecast.Models
{
    public class WeatherModel
    {
        public WeatherType Type { get; set; }
        public int Temperature { get; set; }
        public string Wind { get; set; }
        public string Precipitation { get; set; }
    }
}