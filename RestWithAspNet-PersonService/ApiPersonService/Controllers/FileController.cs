using ApiPersonService.Business;
using ApiPersonService.Data.VO;
using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiPersonService.Controllers;

[ApiVersion("1")]
[ApiController]
[Authorize("Bearer")]
[Route("api/[controller]/v{version:apiVersion}")]
public class FileController : Controller
{
    private readonly ILogger<FileController> _logger;
    private readonly IFileBusiness _fileBusiness;

    public FileController(ILogger<FileController> logger, IFileBusiness fileBusiness)
    {
        _logger = logger;
        _fileBusiness = fileBusiness;
    }

    [HttpGet("DownloadFile/{fileName}")]
    [ProducesResponseType((200), Type = typeof(byte[]))]
    [ProducesResponseType((204))]
    [ProducesResponseType((400))]
    [ProducesResponseType((401))]
    [Produces("application/octet-stream")]
    public async Task<IActionResult> GetFileAsync(string fileName)
    {
        byte[] buffer = _fileBusiness.GetFile(fileName);

        if (buffer != null)
        {
            HttpContext.Response.ContentType = $"application/{Path.GetExtension(fileName).Replace(".", "")}";
            HttpContext.Response.Headers.Add("content-length", buffer.Length.ToString());
            await HttpContext.Response.Body.WriteAsync(buffer, 0, buffer.Length);
        }

        return new ContentResult();
    }

    [HttpPost("UpLoadFile")]
    [ProducesResponseType((200), Type = typeof(FileDetailVO))]
    [ProducesResponseType((400))]
    [ProducesResponseType((401))]
    [Produces("application/json")]
    public async Task<IActionResult> UploadOneFile([FromForm] IFormFile file)
    {
        var detail = await _fileBusiness.SaveFileToDiskAsync(file);
        return Ok(detail);
    }

    [HttpPost("UpLoadMultipleFile")]
    [ProducesResponseType((200), Type = typeof(List<FileDetailVO>))]
    [ProducesResponseType((400))]
    [ProducesResponseType((401))]
    [Produces("application/json")]
    public async Task<IActionResult> UploadManyFiles([FromForm] List<IFormFile> files)
    {
        var details = await _fileBusiness.SaveFilesToDiskAsync(files);
        return Ok(details);
    }
}