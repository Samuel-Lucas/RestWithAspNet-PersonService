using ApiPersonService.Hypermedia.Abstract;

namespace ApiPersonService.Hypermedia.utils;

public class PagedSearchVO<T> where T : ISupportHypermedia
{
    public int CurrentPage { get; set; }
    public int PageSize { get; set; }
    public int TotalResults { get; set; }
    public string SortFields { get; set; } = null!;
    public string SortDirections { get; set; } = null!;
    public Dictionary<string, Object> Filters { get; set; } = null!;
    public List<T> List { get; set; } = null!;

    public PagedSearchVO() { }

    public PagedSearchVO(int currentPage, int pageSize, string sortFields, string sortDirections)
    {
        CurrentPage = currentPage;
        PageSize = pageSize;
        SortFields = sortFields;
        SortDirections = sortDirections;
    }

    public PagedSearchVO(int currentPage, int pageSize, string sortFields, string sortDirections, Dictionary<string, Object> filters)
    {
        CurrentPage = currentPage;
        PageSize = pageSize;
        SortFields = sortFields;
        SortDirections = sortDirections;
        Filters = filters;
    }

    public PagedSearchVO(int currentPage, string sortFields, string sortDirections)
        : this(currentPage, 10, sortFields, sortDirections) { }

    public int GetCurrentPage() => CurrentPage == 0 ? 2 : CurrentPage;

    public int GetPageSize() => PageSize == 0 ? 10 : PageSize;
}