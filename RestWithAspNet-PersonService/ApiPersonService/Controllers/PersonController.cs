using ApiPersonService.Business;
using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using ApiPersonService.Data.VO;
using ApiPersonService.Hypermedia.Filters;
using Microsoft.AspNetCore.Authorization;

namespace ApiPersonService.Controllers;

[ApiVersion("1")]
[ApiController]
// [Authorize("Bearer")]
[Route("api/[controller]/v{version:apiVersion}")]
public class PersonController : ControllerBase
{
    private readonly ILogger<PersonController> _logger;
    private IPersonBusiness _personService;

    public PersonController(ILogger<PersonController> logger, IPersonBusiness personService)
    {
        _logger = logger;
        _personService = personService;
    }

    [HttpGet("{sortDirection}/{pageSize}/{page}")]
    [ProducesResponseType((200), Type = typeof(List<PersonVO>))]
    [ProducesResponseType((204))]
    [ProducesResponseType((400))]
    [ProducesResponseType((401))]
    [TypeFilter(typeof(HyperMediaFilter))]
    public IActionResult Get(
        [FromQuery] string? name,
        string sortDirection,
        int pageSize,
        int page
    )
    {
        return Ok(_personService.FindWithPagedSearch(name!, sortDirection, pageSize, page));
    }

    [HttpGet("{id}")]
    [ProducesResponseType((200), Type = typeof(PersonVO))]
    [ProducesResponseType((204))]
    [ProducesResponseType((400))]
    [ProducesResponseType((401))]
    [TypeFilter(typeof(HyperMediaFilter))]
    public IActionResult Get(long id)
    {
        var person = _personService.FindById(id);
        if (person is null) return NotFound();
        return Ok(person);
    }

    [HttpGet("findPersonByName")]
    [ProducesResponseType((200), Type = typeof(PersonVO))]
    [ProducesResponseType((204))]
    [ProducesResponseType((400))]
    [ProducesResponseType((401))]
    [TypeFilter(typeof(HyperMediaFilter))]
    public IActionResult Get([FromQuery] string? firstName, [FromQuery] string? lastName)
    {
        var person = _personService.FindByName(firstName!, lastName!);
        if (person is null) return NotFound();
        return Ok(person);
    }

    [HttpPost]
    [ProducesResponseType((200), Type = typeof(PersonVO))]
    [ProducesResponseType((400))]
    [ProducesResponseType((401))]
    [TypeFilter(typeof(HyperMediaFilter))]
    public IActionResult Post([FromBody] PersonVO person)
    {
        if (person is null) return BadRequest();
        return Ok(_personService.Create(person));
    }

    [HttpPut]
    [ProducesResponseType((200), Type = typeof(PersonVO))]
    [ProducesResponseType((400))]
    [ProducesResponseType((401))]
    [TypeFilter(typeof(HyperMediaFilter))]
    public IActionResult Put([FromBody] PersonVO person)
    {
        if (person is null) return BadRequest();
        return Ok(_personService.Update(person));
    }

    [HttpPatch("{id}")]
    [ProducesResponseType((200), Type = typeof(PersonVO))]
    [ProducesResponseType((204))]
    [ProducesResponseType((400))]
    [ProducesResponseType((401))]
    [TypeFilter(typeof(HyperMediaFilter))]
    public IActionResult Patch(long id)
    {
        var person = _personService.DisableAsync(id);
        return Ok(person);
    }

    [HttpDelete("{id}")]
    [ProducesResponseType((204))]
    [ProducesResponseType((400))]
    [ProducesResponseType((401))]
    public IActionResult Delete(long id)
    {
        _personService.Delete(id);
        return NoContent();
    }
}