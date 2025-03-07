using ApiPersonService.Data.Converter.Implementation;
using ApiPersonService.Data.VO;
using ApiPersonService.Model;
using ApiPersonService.Repository.Generic;

namespace ApiPersonService.Business.Implementation;

public class PersonBusinessImplementation : IPersonBusiness
{
    private readonly IRepository<Person> _personRepository;
    private readonly PersonConverter _converter;

    public PersonBusinessImplementation(IRepository<Person> personRepository)
    {
        _personRepository = personRepository;
        _converter = new PersonConverter();
    }

    public List<PersonVO> FindAll()
    {
        return _converter.Parse(_personRepository.FindAll());
    }

    public PersonVO FindById(long id)
    {
        return _converter.Parse(_personRepository.FindById(id));
    }

    public PersonVO Create(PersonVO person)
    {
        var personEntity = _converter.Parse(person);
        personEntity = _personRepository.Create(personEntity);
        return _converter.Parse(personEntity);
    }

    public PersonVO Update(PersonVO person)
    {
        if (!_personRepository.Exists(person.Id))
            return new PersonVO();

        var personEntity = _converter.Parse(person);
        personEntity = _personRepository.Update(personEntity);
        return _converter.Parse(personEntity);
    }

    public void Delete(long id)
    {
        if (!_personRepository.Exists(id))
            return;

        _personRepository.Delete(id);
    }
}