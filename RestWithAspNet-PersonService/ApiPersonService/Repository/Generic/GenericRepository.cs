using ApiPersonService.Data;
using ApiPersonService.Model.Base;
using Microsoft.EntityFrameworkCore;

namespace ApiPersonService.Repository.Generic;

public class GenericRepository<T> : IRepository<T> where T : BaseEntity
{
    protected AppDbContext _context;
    private DbSet<T> dataset;

    public GenericRepository(AppDbContext context)
    {
        _context = context;
        dataset = _context.Set<T>();
    }

    public List<T> FindAll()
    {
        return dataset.ToList();
    }

    public T FindById(long id)
    {
        return dataset.SingleOrDefault(p => p.Id == id)!;
    }

    public T Create(T item)
    {
        try
        {
            dataset.Add(item);
            _context.SaveChanges();
            return item;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public T Update(T item)
    {
        var result = FindById(item.Id);
        try
        {
            dataset.Entry(result).CurrentValues.SetValues(item);
            _context.SaveChanges();
            return item;
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
            dataset.Remove(result);
            _context.SaveChanges();
        }
        catch (Exception)
        {
            throw;
        }
    }

    public bool Exists(long id)
        => dataset.Any(p => p.Id == id);

    public List<T> FindWithPagedSearch(string query)
        => dataset.FromSqlRaw<T>(query).ToList();

    public int GetCount(string query)
    {
        var result = "";
        using (var connection = _context.Database.GetDbConnection())
        {
            connection.Open();
            using (var command = connection.CreateCommand())
            {
                command.CommandText = query;
                result = command.ExecuteScalar()!.ToString();
            }
        }
        return int.Parse(result!);
    }
}