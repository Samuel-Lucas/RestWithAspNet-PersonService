using ApiPersonService.Data.VO;
using ApiPersonService.Hypermedia.utils;

namespace ApiPersonService.Business;

public interface IPersonBusiness
{
    PersonVO Create(PersonVO person);
    PersonVO FindById(long id);
    List<PersonVO> FindAll();
    PagedSearchVO<PersonVO> FindWithPagedSearch(string name, string sortDirection, int pageSize, int page);
    List<PersonVO> FindByName(string firstName, string lastName);
    PersonVO Update(PersonVO person);
    Task<PersonVO> DisableAsync(long id);
    void Delete(long id);
}