using groceriesBE.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Xml.Linq;

namespace groceriesBE.Controllers
{
    [Route("api/groceries")]
    [ApiController]
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
        private readonly IDataRepository<Groceries> _dataRepository;
        public GroceriesController(IDataRepository<Groceries> dataRepository)
        {
            _dataRepository = dataRepository;
        }
        // GET: api/Groceries
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Groceries> groceries = _dataRepository.GetAll();
            return Ok(groceries);
        }
        // GET: api/Groceries/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(long id)
        {
            Groceries groceries = _dataRepository.Get(id);
            if (groceries == null)
            {
                return NotFound("The Groceries record couldn't be found.");
            }
            return Ok(groceries);
        }
        // POST: api/Groceries
        [HttpPost]
        public IActionResult Post([FromBody] Groceries groceries)
        {
            if (groceries == null)
            {
                return BadRequest("Groceries is null.");
            }
            _dataRepository.Add(groceries);
            return CreatedAtRoute(
                  "Get",
                  new { Id = groceries.GroceriesId },
                  groceries);
        }
        // PUT: api/Groceries/5
        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody] Groceries groceries)
        {
            if (groceries == null)
            {
                return BadRequest("Groceries is null.");
            }
            Groceries groceriesToUpdate = _dataRepository.Get(id);
            if (groceriesToUpdate == null)
            {
                return NotFound("The Groceries record couldn't be found.");
            }
            _dataRepository.Update(groceriesToUpdate, groceries);
            return NoContent();
        }
        // DELETE: api/Groceries/5
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            Groceries groceries = _dataRepository.Get(id);
            if (groceries == null)
            {
                return NotFound("The Groceries record couldn't be found.");
            }
            _dataRepository.Delete(groceries);
            return NoContent();
        }



        public GroceriesController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetGreoceriesTest")]
        public IEnumerable<Groceries> GetTest()
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

