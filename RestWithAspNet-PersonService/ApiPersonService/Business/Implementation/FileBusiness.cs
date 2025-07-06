using ApiPersonService.Data.VO;

namespace ApiPersonService.Business.Implementation;

public class FileBusiness : IFileBusiness
{
    private readonly string _basePath;
    private readonly IHttpContextAccessor _context;

    public FileBusiness(IHttpContextAccessor context)
    {
        _context = context;
        _basePath = Directory.GetCurrentDirectory() + "\\UploadDir\\";
    }

    public byte[] GetFile(string fileName)
    {
        throw new NotImplementedException();
    }

    public async Task<List<FileDetailVO>> SaveFilesToDisk(IList<IFormFile> file)
    {
        throw new NotImplementedException();
    }

    public async Task<FileDetailVO> SaveFileToDisk(IFormFile file)
    {
        throw new NotImplementedException();
    }
}