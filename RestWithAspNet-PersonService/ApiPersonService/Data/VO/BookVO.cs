using ApiPersonService.Hypermedia;
using ApiPersonService.Hypermedia.Abstract;

namespace ApiPersonService.Data.VO;

public class BookVO : ISupportHypermedia
{
    public long Id { get; set; }
    public string Title { get; set; } = null!;
    public string Author { get; set; } = null!;
    public decimal Price { get; set; }
    public DateTime LaunchDate { get; set; }
    public List<HyperMediaLink> Links { get; set; } = new List<HyperMediaLink>();
}