using ApiPersonService.Data.VO;

namespace ApiPersonService.Business.Implementation;

public class FileBusinessImplementation : IFileBusiness
{
    private readonly string _basePath;
    private readonly IHttpContextAccessor _context;

    public FileBusinessImplementation(IHttpContextAccessor context)
    {
        _context = context;
        _basePath = Directory.GetCurrentDirectory() + "\\UploadDir\\";
    }

    public byte[] GetFile(string fileName)
    {
        throw new NotImplementedException();
    }
    
    public async Task<FileDetailVO> SaveFileToDiskAsync(IFormFile file)
    {
        var fileDetail = new FileDetailVO();
        var fileType = Path.GetExtension(file.FileName);
        var baseUrl = _context.HttpContext!.Request.Host;

        if (fileType.ToLower() == "pdf" || fileType.ToLower() == ".jpg" ||
            fileType.ToLower() == ".png" || fileType.ToLower() == ".jpeg")
        {
            var docName = Path.GetFileName(file.FileName);

            if (file is not null && file.Length > 0)
            {
                var destination = Path.Combine(_basePath, "", docName);
                fileDetail.DocumentName = docName;
                fileDetail.DocType = fileType;
                fileDetail.DocUrl = Path.Combine(baseUrl + "/api/file/v1/" + fileDetail.DocumentName);

                using var stream = new FileStream(destination, FileMode.Create);
                await file.CopyToAsync(stream);
            }
        }

        return fileDetail;
    }

    public async Task<List<FileDetailVO>> SaveFilesToDiskAsync(IList<IFormFile> files)
    {
        var fileList = new List<FileDetailVO>();

        foreach (var file in files)
        {
            fileList.Add(await SaveFileToDiskAsync(file));
        }

        return fileList;
    }
}