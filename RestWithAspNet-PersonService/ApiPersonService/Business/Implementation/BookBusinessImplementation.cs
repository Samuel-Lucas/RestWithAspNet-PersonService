using ApiPersonService.Model;
using ApiPersonService.Repository.Generic;

namespace ApiPersonService.Business.Implementation;

public class BookBusinessImplementation : IBookBusiness
{
    private readonly IRepository<Book> _bookRepository;

    public BookBusinessImplementation(IRepository<Book> bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public List<Book> FindAll()
    {
        return _bookRepository.FindAll();
    }

    public Book FindById(long id)
    {
        return _bookRepository.FindById(id);
    }

    public Book Create(Book book)
    {
        return _bookRepository.Create(book);
    }

    public Book Update(Book book)
    {
        if (!_bookRepository.Exists(book.Id))
            return new Book();

        return _bookRepository.Update(book);
    }

    public void Delete(long id)
    {
        if (!_bookRepository.Exists(id))
            return;

        _bookRepository.Delete(id);
    }
}