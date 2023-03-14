using Microsoft.AspNetCore.Mvc;
using TARge21Shop.ApplicationServices.Services;
using TARge21Shop.Core.Dto.WeatherDtos;
using TARge21Shop.Core.ServiceInterface;
using TARge21Shop.Models.Weather;

namespace TARge21Shop.Controllers
{
    public class WeatherForecastsController : Controller
    {
        private readonly IWeatherForecastsServices _weatherForecastServices;

        public WeatherForecastsController
            (
                IWeatherForecastsServices weatherForecastServices
            )
        {
            _weatherForecastServices = weatherForecastServices;
        }

        public IActionResult Index()
        {
            WeatherViewModel vm = new WeatherViewModel();

            return View(vm);
        }

        [HttpPost]
        public IActionResult ShowWeather()
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("City", "WeatherForecasts");
            }

            return View();
        }

        [HttpGet]
        public IActionResult City()
        {
            WeatherResultDto dto = new();

            _weatherForecastServices.WeatherDetail(dto);

            WeatherViewModel vm = new();

            vm.Date = dto.EffectiveDate;
            vm.EpochDate = dto.EffectiveEpochDate;
            vm.Severity = dto.Severity;
            vm.Text = dto.Text;
            vm.MobileLink = dto.MobileLink;
            vm.Link = dto.Link;
            vm.Category = dto.Category;

            vm.TempMinValue = dto.TempMinValue;
            vm.TempMinUnit = dto.TempMinUnit;
            vm.TempMinUnitType = dto.TempMinUnitType;

            vm.TempMaxValue = dto.TempMaxValue;
            vm.TempMaxUnit = dto.TempMaxUnit;
            vm.TempMaxUnitType = dto.TempMaxUnitType;

            vm.DayIcon = dto.DayIcon;
            vm.DayIconPhrase = dto.DayIconPhrase;
            vm.DayHasPercipitation = dto.DayHasPercipitation;
            vm.DayPrecipitationType = dto.DayPrecipitationType;
            vm.DayPrecipitationIntensity = dto.DayPrecipitationIntensity;

            vm.NightIcon = dto.NightIcon;
            vm.NightIconPhrase = dto.NightIconPhrase;
            vm.NightHasPrecipitation = dto.NightHasPrecipitation;
            vm.NightPrecipitationType = dto.NightPrecipitationType;
            vm.NightPrecipitationIntensity = dto.NightPrecipitationIntensity;


            return View(vm);
        }
        [HttpPost]
        public IActionResult ShowWeatherOpen()
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("CityOpen", "WeatherForecasts");
            }

            return View();
        }
        [HttpGet]
        public IActionResult CityOpen()
        {
            OpenWeatherResultDto dto = new OpenWeatherResultDto();
            OpenWeatherViewModel vm = new OpenWeatherViewModel();

            _weatherForecastServices.OpenWeatherDetail(dto);

            vm.Name = dto.Name;
            vm.Weathers = new List<OpenWeatherViewModel.Weather>();
            vm.Weathers.Add(new OpenWeatherViewModel.Weather());
            vm.Weathers[0].Description = dto.Description;

            vm.Mains = new OpenWeatherViewModel.Main();
            vm.Mains.Temp = dto.Temp;
            vm.Mains.Feels_like = dto.Feels_like;
            vm.Mains.Pressure = dto.Pressure;
            vm.Mains.Humidity = dto.Humidity;

            vm.Winds = new OpenWeatherViewModel.Wind();
            vm.Winds.Speed = dto.Speed;

            return View(vm);
        }
        }
}