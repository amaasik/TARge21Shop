using Nancy.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TARge21Shop.Core.Dto;
using TARge21Shop.Core.Dto.WeatherDtos;
using TARge21Shop.Core.ServiceInterface;

namespace TARge21Shop.ApplicationServices.Services
{
    public class WeatherForecastServices : IWeatherForecastServices
    {
        public async Task<WeatherResultDto> WeatherDetail(WeatherResultDto dto)
        {
            //tallinna kood 127964
            string apikey = "qtPfgAahJibfaWqT9zbupu8qaAxrvIZ2";
            var url = $"http://dataservice.accuweather.com/forecasts/v1/daily/1day/";

            

                using (WebClient client = new WebClient())
                {
                    string json = client.DownloadString(url);

                WeatherRootDto weatherInfo = (new JavaScriptSerializer()).Deserialize<WeatherRootDto>(json);

                dto.EffectiveDate= weatherInfo.Headline.EffectiveDate;
                dto.EffectiveEpochDate= weatherInfo.Headline.EffectiveEpochDate;
                dto.Severity= weatherInfo.Headline.Severity;
                dto.Text= weatherInfo.Headline.Text;
                dto.Category= weatherInfo.Headline.Category;
                dto.EndDate= weatherInfo.Headline.EndDate;
                dto.EndEpochDate= weatherInfo.Headline.EndEpochDate;

                dto.MobileLink= weatherInfo.Headline.MobileLink;
                dto.Link= weatherInfo.Headline.Link;

                dto.DailyForecastsDay= weatherInfo.DailyForecasts[0].Date ;
                dto.DailyForecastsEpochDate= weatherInfo.DailyForecasts[0].EpochDate ;

                dto.TempMinValue= weatherInfo.DailyForecasts[0].Temperature.Minimum.Value;
                    weatherInfo.DailyForecasts[0].Temperature.Minimum.Unit = dto.TempMinUnit;
                    weatherInfo.DailyForecasts[0].Temperature.Minimum.UnitType = dto.TempMinUnitType;

                    weatherInfo.DailyForecasts[0].Temperature.Maximum.Value = dto.TempMaxValue;
                    weatherInfo.DailyForecasts[0].Temperature.Maximum.Unit = dto.TempMaxUnit;
                    weatherInfo.DailyForecasts[0].Temperature.Maximum.UnitType = dto.TempMaxUnitType;

                    weatherInfo.DailyForecasts[0].Day.Icon = dto.DayIcon;
                    weatherInfo.DailyForecasts[0].Day.IconPhrase = dto.DayIconPhrase;
                    weatherInfo.DailyForecasts[0].Day.HasPrecipitation = dto.DayHasPrecipitation;
                    weatherInfo.DailyForecasts[0].Day.PrecipitationType = dto.DayPrecipitationType;
                    weatherInfo.DailyForecasts[0].Day.PrecipitationIntensity = dto.DayPrecipitationIntensity;

                    weatherInfo.DailyForecasts[0].Night.Icon = dto.NightIcon;
                    weatherInfo.DailyForecasts[0].Night.IconPhrase = dto.NightIconPhrase;
                    weatherInfo.DailyForecasts[0].Night.HasPrecipitation = dto.NightHasPrecipitation;
                    weatherInfo.DailyForecasts[0].Night.PrecipitationType = dto.NightPrecipitationType;
                    weatherInfo.DailyForecasts[0].Night.PrecipitationIntensity = dto.NightPrecipitationIntensity;

                }

                return dto;
        }
    }
}
