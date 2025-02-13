using ApiPersonService.Hypermedia.Abstract;

namespace ApiPersonService.Hypermedia.Filters;

public class HyperMediaFilterOptions
{
    public List<IResponseEnricher> ContentResponseEnricherList { get; set; } = new List<IResponseEnricher>();
}