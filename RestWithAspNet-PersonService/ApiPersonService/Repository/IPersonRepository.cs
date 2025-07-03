using ApiPersonService.Model;
using ApiPersonService.Repository.Generic;

namespace ApiPersonService.Repository;

public interface IPersonRepository : IRepository<Person>
{
    Task<Person> DisableAsync(long id);
    List<Person> FindByName(string firstName, string lastName);
}