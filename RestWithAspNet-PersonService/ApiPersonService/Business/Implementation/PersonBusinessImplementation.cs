using ApiPersonService.Data;
using ApiPersonService.Model;
using ApiPersonService.Repository;

namespace ApiPersonService.Business.Implementation;

public class PersonBusinessImplementation : IPersonBusiness
{
    private readonly IPersonRepository _personRepository;

    public PersonBusinessImplementation(IPersonRepository personRepository)
    {
        _personRepository = personRepository;
    }

    public List<Person> FindAll()
    {
        return _personRepository.FindAll();
    }

    public Person FindById(long id)
    {
        return _personRepository.FindById(id);
    }

    public Person Create(Person person)
    {
        return _personRepository.Create(person);
    }

    public Person Update(Person person)
    {
        if (!_personRepository.Exists(person.Id))
            return new Person();

        return _personRepository.Update(person);
    }

    public void Delete(long id)
    {
        if (!_personRepository.Exists(id))
            return;

        _personRepository.Delete(id);
    }
}