using ApiPersonService.Model;

namespace ApiPersonService.Services.Implementation;

public class PersonServiceImplementation : IPersonService
{
    public Person Create(Person person)
    {
        return person;
    }

    public void Delete(long id)
    {
        
    }

    public List<Person> FindAll()
    {
        List<Person> persons = new List<Person>();
        for (int i = 0; i < 8; i++)
        {
            Person person = MockPerson(i);
            persons.Add(person);
        }
        
        return persons;
    }

    public Person FindById(long id)
    {
        return new Person
        {
            Id = 1,
            FirstName = "Samuel",
            LastName = "Lucas",
            Address = "Osasco - São Paulo - Brasil",
            Gender = "Male"
        };
    }

    public Person Update(Person person)
    {
        return person;
    }

    private Person MockPerson(int i)
    {
        return new Person
        {
            Id = i,
            FirstName = "Samuel",
            LastName = "Lucas",
            Address = "Osasco - São Paulo - Brasil",
            Gender = "Male"
        };
    }
}