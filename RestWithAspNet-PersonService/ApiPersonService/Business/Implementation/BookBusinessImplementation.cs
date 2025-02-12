using ApiPersonService.Data.Converter.Implementation;
using ApiPersonService.Data.VO;
using ApiPersonService.Model;
using ApiPersonService.Repository.Generic;

namespace ApiPersonService.Business.Implementation;

public class BookBusinessImplementation : IBookBusiness
{
    private readonly IRepository<Book> _bookRepository;
    private readonly BookConverter _converter;

    public BookBusinessImplementation(IRepository<Book> bookRepository)
    {
        _bookRepository = bookRepository;
        _converter = new BookConverter();
    }

    public List<BookVO> FindAll()
    {
        return _converter.Parse(_bookRepository.FindAll());
    }

    public BookVO FindById(long id)
    {
        return _converter.Parse(_bookRepository.FindById(id));
    }

    public BookVO Create(BookVO book)
    {
        var bookEntity = _converter.Parse(book);
        bookEntity = _bookRepository.Create(bookEntity);
        return _converter.Parse(bookEntity);
    }

    public BookVO Update(BookVO book)
    {
        if (!_bookRepository.Exists(book.Id))
            return new BookVO();

        var bookEntity = _converter.Parse(book);
        bookEntity = _bookRepository.Update(bookEntity);
        return _converter.Parse(bookEntity);
    }

    public void Delete(long id)
    {
        if (!_bookRepository.Exists(id))
            return;

        _bookRepository.Delete(id);
    }
}