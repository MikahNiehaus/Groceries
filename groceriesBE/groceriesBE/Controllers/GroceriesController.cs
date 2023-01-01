using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Xml.Linq;

namespace groceriesBE.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GroceriesController : ControllerBase
    {

        private static readonly string[] Food = new[]
        {
        "Meat", "Bread", "Chilly", "Apples"
            };
        private static readonly string[] Notes = new[]
        {
            "it tastes good", "it is ok", String.Empty,
        };

            private readonly ILogger<WeatherForecastController> _logger;

        public GroceriesController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetGreoceries")]
        public IEnumerable<Groceries> Get()
        {
            Random random = new Random();
            return Enumerable.Range(1, Food.Length).Select(index => new Groceries
            {
                Food = Food[Random.Shared.Next(Food.Length)],
                Amount = random.Next(1, 5),
                Notes = Notes[Random.Shared.Next(Notes.Length)]
            })
       .ToArray();

           
        }
    }
}

