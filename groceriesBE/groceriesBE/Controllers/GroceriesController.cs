using groceriesBE.Repository;
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

        [HttpGet(Name = "GetGreoceriesTest")]
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

        [Route("api/groceriers")]
        [ApiController]
        public class GroceriersController : ControllerBase
        {
            private readonly IDataRepository<Groceriers> _dataRepository;
            public GroceriersController(IDataRepository<Groceriers> dataRepository)
            {
                _dataRepository = dataRepository;
            }
            // GET: api/Groceriers
            [HttpGet]
            public IActionResult Get()
            {
                IEnumerable<Groceriers> groceriers = _dataRepository.GetAll();
                return Ok(groceriers);
            }
            // GET: api/Groceriers/5
            [HttpGet("{id}", Name = "Get")]
            public IActionResult Get(long id)
            {
                Groceriers groceriers = _dataRepository.Get(id);
                if (groceriers == null)
                {
                    return NotFound("The Groceriers record couldn't be found.");
                }
                return Ok(groceriers);
            }
            // POST: api/Groceriers
            [HttpPost]
            public IActionResult Post([FromBody] Groceriers groceriers)
            {
                if (groceriers == null)
                {
                    return BadRequest("Groceriers is null.");
                }
                _dataRepository.Add(groceriers);
                return CreatedAtRoute(
                      "Get",
                      new { Id = groceriers.GroceriersId },
                      groceriers);
            }
            // PUT: api/Groceriers/5
            [HttpPut("{id}")]
            public IActionResult Put(long id, [FromBody] Groceriers groceriers)
            {
                if (groceriers == null)
                {
                    return BadRequest("Groceriers is null.");
                }
                Groceriers groceriersToUpdate = _dataRepository.Get(id);
                if (groceriersToUpdate == null)
                {
                    return NotFound("The Groceriers record couldn't be found.");
                }
                _dataRepository.Update(groceriersToUpdate, groceriers);
                return NoContent();
            }
            // DELETE: api/Groceriers/5
            [HttpDelete("{id}")]
            public IActionResult Delete(long id)
            {
                Groceriers groceriers = _dataRepository.Get(id);
                if (groceriers == null)
                {
                    return NotFound("The Groceriers record couldn't be found.");
                }
                _dataRepository.Delete(groceriers);
                return NoContent();
            }
        }
    }
}

