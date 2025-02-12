using ApiPersonService.Data.Converter.Contract;
using ApiPersonService.Data.VO;
using ApiPersonService.Model;

namespace ApiPersonService.Data.Converter.Implementation;

public class PersonConverter : IParser<PersonVO, Person>, IParser<Person, PersonVO>
{
    public Person Parse(PersonVO origin)
    {
        if (origin is null) return null!;
        return new Person
        {
            Id = origin.Id,
            FirstName = origin.FirstName,
            LastName = origin.LastName,
            Address = origin.Address,
            Gender = origin.Gender
        };
    }

    public PersonVO Parse(Person origin)
    {
        if (origin is null) return null!;
        return new PersonVO
        {
            Id = origin.Id,
            FirstName = origin.FirstName,
            LastName = origin.LastName,
            Address = origin.Address,
            Gender = origin.Gender
        };
    }

    public List<Person> Parse(List<PersonVO> origin)
    {
        if (origin is null) return null!;
        return origin.Select(item => Parse(item)).ToList();
    }

    public List<PersonVO> Parse(List<Person> origin)
    {
        if (origin is null) return null!;
        return origin.Select(item => Parse(item)).ToList();
    }
}