using ApiPersonService.Hypermedia;
using ApiPersonService.Hypermedia.Abstract;

namespace ApiPersonService.Data.VO;

public class PersonVO : ISupportHypermedia
{
    public long Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Address { get; set; } = null!;
    public string Gender { get; set; } = null!;
    public bool Enabled { get; set; }
    public List<HyperMediaLink> Links { get; set; } = new List<HyperMediaLink>();
}