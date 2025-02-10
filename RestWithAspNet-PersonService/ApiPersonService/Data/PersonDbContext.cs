using ApiPersonService.Model;
using Microsoft.EntityFrameworkCore;

namespace ApiPersonService.Data;

public class PersonDbContext : DbContext
{
    public PersonDbContext(DbContextOptions<PersonDbContext> options) : base(options)
    { }

    public DbSet<Person> Persons { get; set; }
}