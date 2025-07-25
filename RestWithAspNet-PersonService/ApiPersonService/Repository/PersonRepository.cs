using ApiPersonService.Data;
using ApiPersonService.Model;
using ApiPersonService.Repository.Generic;
using Microsoft.EntityFrameworkCore;

namespace ApiPersonService.Repository;

public class PersonRepository : GenericRepository<Person>, IPersonRepository
{
    public PersonRepository(AppDbContext context) : base (context) { }

    public async Task<Person> DisableAsync(long id)
    {
        if (!await _context.Persons.AnyAsync(p => p.Id.Equals(id)))
            return null!;

        var user = _context.Persons.SingleOrDefault(p => p.Id.Equals(id));

        if (user != null)
        {
            user.Enabled = false;
            try
            {
                _context.Entry(user).CurrentValues.SetValues(user);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception($"Erro ao desativar usuário, mensagem do erro: {e.Message} | {e.InnerException}");
            }
        }

        return user!;
    }

    public List<Person> FindByName(string firstName, string lastName)
    {
        if (!string.IsNullOrWhiteSpace(firstName) && !string.IsNullOrWhiteSpace(lastName))
        {
            return _context.Persons.Where(p => p.FirstName.Contains(firstName) && p.LastName.Contains(lastName)).ToList();
        }
        else if (string.IsNullOrWhiteSpace(firstName) && !string.IsNullOrWhiteSpace(lastName))
        {
            return _context.Persons.Where(p => p.LastName.Contains(lastName)).ToList();
        }
        else if (!string.IsNullOrWhiteSpace(firstName) && string.IsNullOrWhiteSpace(lastName))
        {
            return _context.Persons.Where(p => p.FirstName.Contains(firstName)).ToList();
        }

        return null!;
    }
}