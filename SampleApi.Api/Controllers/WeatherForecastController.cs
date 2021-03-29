using System;
using System.Threading.Tasks;
using CMS.Framwork.Application.ControllerTypes;
using CMS.Framwork.Data.Framwork;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SampleApi.Data;

namespace SampleApi.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : BaseController<Class1>
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private static ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger) : base(beforCreate: BeforCreateWeather, onCreate: onCreateWeather)
        {
            _logger = logger;

        }

        private static Class1 BeforCreateWeather(Class1 inputClass1)
        {
            _logger.Log(LogLevel.Debug, "BeforCreate");
            inputClass1.dateOfBirth = "this is a test";
            return inputClass1;
        }

        private static Class1 onCreateWeather(Class1 inputClass1)
        {
            _logger.Log(LogLevel.Debug, "onCreate");
            inputClass1.name = "mason";
            return inputClass1;
        }


        [HttpGet]
        public async Task<ActionResult<ResponseResource<Class1>>> Get()
        {
            var rng = new Random();

            var test = new Class1() { name = "gfhdsakg", age = 21, dateOfBirth = "yes" };
            
            var ttt =  await base.Create(test);

            return ttt;

        }
    }
}
