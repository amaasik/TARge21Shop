namespace TARge21Shop.Core.Dto.WeatherDtos
{
    public class WeaterRootDto
    {
        public HeadlineDto Headline { get; set; }
        public List<DailyForecastsDto> DailyForecasts { get; set; }
    }
}
