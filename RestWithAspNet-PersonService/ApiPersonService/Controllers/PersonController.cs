using ApiPersonService.Business;
using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using ApiPersonService.Data.VO;
using ApiPersonService.Hypermedia.Filters;

namespace ApiPersonService.Controllers;

[ApiVersion("1")]
[ApiController]
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
    [TypeFilter(typeof(HyperMediaFilter))]
    public IActionResult Get()
    {
        return Ok(_personService.FindAll());
    }

    [HttpGet("{id}")]
    [TypeFilter(typeof(HyperMediaFilter))]
    public IActionResult Get(long id)
    {
        var person = _personService.FindById(id);
        if (person is null) return NotFound();
        return Ok(person);
    }

    [HttpPost]
    [TypeFilter(typeof(HyperMediaFilter))]
    public IActionResult Post([FromBody] PersonVO person)
    {
        if (person is null) return BadRequest();
        return Ok(_personService.Create(person));
    }

    [HttpPut]
    [TypeFilter(typeof(HyperMediaFilter))]
    public IActionResult Put([FromBody] PersonVO person)
    {
        if (person is null) return BadRequest();
        return Ok(_personService.Update(person));
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(long id)
    {
        _personService.Delete(id);
        return NoContent();
    }
}