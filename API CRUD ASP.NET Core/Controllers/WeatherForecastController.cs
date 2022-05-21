using Microsoft.AspNetCore.Mvc;

namespace API_CRUD_ASP.NET_Core.Controllers
{     ///<summary>
      /// Este controlador é usado para gerenciar os endpoints da classe &lt; WeatherForecast. 
      ///</summary>
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;
        ///<summary>
        /// Construtor do controlador
        ///</summary>
        public WeatherForecastController (ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }
        /// <summary>
        /// retorna 5 objetos do tipo WeatherForecast, com índices enumerados de 1 a 5
        /// </summary>
        /// <returns></returns>
        [HttpGet(Name = "GetWeatherForecast")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IEnumerable<WeatherForecast> Get ()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}