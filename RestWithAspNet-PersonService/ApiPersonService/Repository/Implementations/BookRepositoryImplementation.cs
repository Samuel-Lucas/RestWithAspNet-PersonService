using ApiPersonService.Data;
using ApiPersonService.Model;

namespace ApiPersonService.Repository.Implementations;

public class BookRepositoryImplementation : IBookRepository
{
    private AppDbContext _context;

    public BookRepositoryImplementation(AppDbContext context)
    {
        _context = context;
    }

    public List<Book> FindAll()
    {
        return _context.Books.ToList();
    }

    public Book FindById(long id)
    {
        return _context.Books.SingleOrDefault(p => p.Id == id)!;
    }

    public Book Create(Book book)
    {
        try
        {
            _context.Add(book);
            _context.SaveChanges();
            return book;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public Book Update(Book book)
    {
        var result = FindById(book.Id);
        try
        {
            _context.Entry(result).CurrentValues.SetValues(book);
            _context.SaveChanges();
            return book;
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
            _context.Books.Remove(result);
            _context.SaveChanges();
        }
        catch (Exception)
        {
            throw;
        }
    }

    public bool Exists(long id)
    {
        return _context.Books.Any(p => p.Id == id);
    }
}