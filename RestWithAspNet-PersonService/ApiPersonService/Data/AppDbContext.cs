using ApiPersonService.Model;
using Microsoft.EntityFrameworkCore;

namespace ApiPersonService.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    { }

    public DbSet<Person> Persons { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<User> Users { get; set; }
}