using Lesson4EntityFramework.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lesson4EntityFramework.Controllers
{
    [ApiController]
    [Route("[controller]")]
    //http:host:1234/api/WeatherForecast
    public class WeatherForecastController : ControllerBase
    {
        private List<string> Summaries = new List<string>
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        //api/WeatherForecast
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Count)]
            })
            .ToArray();
        }

        [HttpGet("{name}")]
        //[Route("{name}")]
        //api/WeatherForecast/Cool
        public string GetByName([FromRoute] string name)
        {
            return Summaries.FirstOrDefault(w => w == name);
        }

        [HttpPost("{name}")]
        [Authorize(Roles ="Admin,User")]
        //[Route("{name}")]
        //api/WeatherForecast/Cool
        public string Create([FromRoute] string name)
        {
            Summaries.Add(name);
            return name;
        }

        [HttpPost]
        //[Route("{name}")]
        //api/WeatherForecast
        public string CreateUsingModel([FromBody] WeatherModel model)
        {
            Summaries.Add(model.Name);
            return model.Name;
        }

        [HttpDelete("{name}")]
        //[Route("{name}")]
        //api/WeatherForecast/Cool
        public void Delete([FromRoute] string name)
        {
            Summaries.Remove(name);
        }

        [HttpDelete]
        //[Route("{name}")]
        //api/WeatherForecast?name=Cool&otherName=Warm
        public void DeleteUsingQuery([FromQuery] string name,[FromQuery] string otherName)
        {
            Summaries.Remove(name);
        }
    }
}
