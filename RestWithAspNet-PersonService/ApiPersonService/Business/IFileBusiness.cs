using ApiPersonService.Data.VO;

namespace ApiPersonService.Business;

public interface IFileBusiness
{
    public byte[] GetFile(string fileName);
    public Task<FileDetailVO> SaveFileToDiskAsync(IFormFile file);
    public Task<List<FileDetailVO>> SaveFilesToDiskAsync(IList<IFormFile> file);
}