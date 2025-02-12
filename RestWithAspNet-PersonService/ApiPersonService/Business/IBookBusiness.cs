using ApiPersonService.Data.VO;

namespace ApiPersonService.Business;

public interface IBookBusiness
{
    BookVO Create(BookVO book);
    BookVO FindById(long id);
    List<BookVO> FindAll();
    BookVO Update(BookVO book);
    void Delete(long id);
}