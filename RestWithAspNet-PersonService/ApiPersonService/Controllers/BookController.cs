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
    [ProducesResponseType((200), Type = typeof(List<BookVO>))]
    [ProducesResponseType((204))]
    [ProducesResponseType((400))]
    [ProducesResponseType((401))]
    [TypeFilter(typeof(HyperMediaFilter))]
    public IActionResult Get()
    {
        return Ok(_bookService.FindAll());
    }

    [HttpGet("{id}")]
    [ProducesResponseType((200), Type = typeof(BookVO))]
    [ProducesResponseType((204))]
    [ProducesResponseType((400))]
    [ProducesResponseType((401))]
    [TypeFilter(typeof(HyperMediaFilter))]
    public IActionResult Get(long id)
    {
        var book = _bookService.FindById(id);
        if (book is null) return NotFound();
        return Ok(book);
    }

    [HttpPost]
    [ProducesResponseType((200), Type = typeof(BookVO))]
    [ProducesResponseType((400))]
    [ProducesResponseType((401))]
    [TypeFilter(typeof(HyperMediaFilter))]
    public IActionResult Post([FromBody] BookVO book)
    {
        if (book is null) return BadRequest();
        return Ok(_bookService.Create(book));
    }

    [HttpPut]
    [ProducesResponseType((200), Type = typeof(BookVO))]
    [ProducesResponseType((400))]
    [ProducesResponseType((401))]
    [TypeFilter(typeof(HyperMediaFilter))]
    public IActionResult Put([FromBody] BookVO book)
    {
        if (book is null) return BadRequest();
        return Ok(_bookService.Update(book));
    }

    [HttpDelete("{id}")]
    [ProducesResponseType((204))]
    [ProducesResponseType((400))]
    [ProducesResponseType((401))]
    public IActionResult Delete(long id)
    {
        _bookService.Delete(id);
        return NoContent();
    }
}