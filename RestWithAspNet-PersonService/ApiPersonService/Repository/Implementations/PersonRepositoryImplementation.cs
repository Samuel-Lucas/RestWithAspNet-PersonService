using ApiPersonService.Data;
using ApiPersonService.Model;

namespace ApiPersonService.Repository.Implementations;

public class PersonRepositoryImplementation : IPersonRepository
{
    private PersonDbContext _context;

    public PersonRepositoryImplementation(PersonDbContext context)
    {
        _context = context;
    }

    public List<Person> FindAll()
    {
        return _context.Persons.ToList();
    }

    public Person FindById(long id)
    {
        return _context.Persons.SingleOrDefault(p => p.Id == id)!;
    }

    public Person Create(Person person)
    {
        try
        {
            _context.Add(person);
            _context.SaveChanges();
            return person;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public Person Update(Person person)
    {
        var result = FindById(person.Id);
        try
        {
            _context.Entry(result).CurrentValues.SetValues(person);
            _context.SaveChanges();
            return person;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public void Delete(long id)
    {
        var result = FindById(id);
        try
        {
            _context.Persons.Remove(result);
            _context.SaveChanges();
        }
        catch (Exception)
        {
            throw;
        }
    }

    public bool Exists(long id)
    {
        return _context.Persons.Any(p => p.Id == id);
    }
}