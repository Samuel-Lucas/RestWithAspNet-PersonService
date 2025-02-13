using ApiPersonService.Business;
using ApiPersonService.Data.VO;
using ApiPersonService.Hypermedia.Filters;
using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace ApiPersonService.Controllers;

[ApiVersion("1")]
[ApiController]
[Route("api/[controller]/v{version:apiVersion}")]
public class BookController : ControllerBase
{
    private readonly ILogger<BookController> _logger;
    private IBookBusiness _bookService;

    public BookController(ILogger<BookController> logger, IBookBusiness bookService)
    {
        _logger = logger;
        _bookService = bookService;
    }

    [HttpGet]
    [TypeFilter(typeof(HyperMediaFilter))]
    public IActionResult Get()
    {
        return Ok(_bookService.FindAll());
    }

    [HttpGet("{id}")]
    [TypeFilter(typeof(HyperMediaFilter))]
    public IActionResult Get(long id)
    {
        var book = _bookService.FindById(id);
        if (book is null) return NotFound();
        return Ok(book);
    }

    [HttpPost]
    [TypeFilter(typeof(HyperMediaFilter))]
    public IActionResult Post([FromBody] BookVO book)
    {
        if (book is null) return BadRequest();
        return Ok(_bookService.Create(book));
    }

    [HttpPut]
    [TypeFilter(typeof(HyperMediaFilter))]
    public IActionResult Put([FromBody] BookVO book)
    {
        if (book is null) return BadRequest();
        return Ok(_bookService.Update(book));
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(long id)
    {
        _bookService.Delete(id);
        return NoContent();
    }
}