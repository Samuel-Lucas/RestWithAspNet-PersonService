using ApiPersonService.Business;
using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using ApiPersonService.Data.VO;
using ApiPersonService.Hypermedia.Filters;
using Microsoft.AspNetCore.Authorization;

namespace ApiPersonService.Controllers;

[ApiVersion("1")]
[ApiController]
[Authorize("Bearer")]
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

    [HttpGet]
    [ProducesResponseType((200), Type = typeof(List<PersonVO>))]
    [ProducesResponseType((204))]
    [ProducesResponseType((400))]
    [ProducesResponseType((401))]
    [TypeFilter(typeof(HyperMediaFilter))]
    public IActionResult Get()
    {
        return Ok(_personService.FindAll());
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