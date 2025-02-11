using ApiPersonService.Data;
using ApiPersonService.Model.Base;
using Microsoft.EntityFrameworkCore;

namespace ApiPersonService.Repository.Generic;

public class GenericRepository<T> : IRepository<T> where T : BaseEntity
{
    private AppDbContext _context;
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
    {
        return dataset.Any(p => p.Id == id);
    }
}