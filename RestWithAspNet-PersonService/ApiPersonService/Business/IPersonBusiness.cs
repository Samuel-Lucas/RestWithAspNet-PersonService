using ApiPersonService.Data.VO;

namespace ApiPersonService.Business;

public interface IPersonBusiness
{
    PersonVO Create(PersonVO person);
    PersonVO FindById(long id);
    List<PersonVO> FindAll();
    List<PersonVO> FindByName(string firstName, string lastName);
    PersonVO Update(PersonVO person);
    Task<PersonVO> DisableAsync(long id);
    void Delete(long id);
}