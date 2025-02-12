using ApiPersonService.Data.Converter.Contract;
using ApiPersonService.Data.VO;
using ApiPersonService.Model;

namespace ApiPersonService.Data.Converter.Implementation;

public class BookConverter : IParser<BookVO, Book>, IParser<Book, BookVO>
{
    public Book Parse(BookVO origin)
    {
        if (origin is null) return null!;
        return new Book
        {
            Id = origin.Id,
            Title = origin.Title,
            Author = origin.Author,
            Price = origin.Price,
            LaunchDate = origin.LaunchDate
        };
    }

    public BookVO Parse(Book origin)
    {
        if (origin is null) return null!;
        return new BookVO
        {
            Id = origin.Id,
            Title = origin.Title,
            Author = origin.Author,
            Price = origin.Price,
            LaunchDate = origin.LaunchDate
        };
    }

    public List<Book> Parse(List<BookVO> origin)
    {
        if (origin is null) return null!;
        return origin.Select(item => Parse(item)).ToList();
    }

    public List<BookVO> Parse(List<Book> origin)
    {
        if (origin is null) return null!;
        return origin.Select(item => Parse(item)).ToList();
    }
}