using Application.Services.People;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly IPeopleService peopleService;

        public PeopleController(IPeopleService peopleService)
        {
            this.peopleService = peopleService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PersonDto))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Get(int id)
        {
            var person = await peopleService.GetByIdAsync(id);

            if (person == null) return NoContent();

            return Ok(person);
        }

        [HttpGet("All")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<PersonDto>))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]

        public async Task<IActionResult> GetAll()
        {
            var list = await peopleService.GetAllAsync();
            if (!list.Any()) return NoContent();

            return Ok(list);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create([FromBody] PersonDto personDto)
        {
            var result = await peopleService.CreateAsync(personDto);

            if (result == 0) return StatusCode(500);

            return StatusCode(201,result);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<int>> Update([FromBody] PersonDto personDto)
        {
            var result = await peopleService.UpdateAsync(personDto);

            if (result == 0) return NotFound();

            return Ok(result);
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<int>> Delete(int id)
        {

            var result = await peopleService.DeleteAsync(id);

            if (result == 0) return NotFound();

            return Ok(result);
        }

    }
}
