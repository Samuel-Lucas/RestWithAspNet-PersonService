using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ApiPersonService.Hypermedia.Filters;

public class HyperMediaFilter : ResultFilterAttribute
{
    private readonly HyperMediaFilterOptions _hyperMediaFilterOptions;

    public HyperMediaFilter(HyperMediaFilterOptions hyperMediaFilterOptions)
    {
        _hyperMediaFilterOptions = hyperMediaFilterOptions;
    }

    public override void OnResultExecuting(ResultExecutingContext context)
    {
        tryEnrichResult(context);
        base.OnResultExecuting(context);
    }

    private void tryEnrichResult(ResultExecutingContext context)
    {
        if (context.Result is OkObjectResult)
        {
            var enricher = _hyperMediaFilterOptions
                            .ContentResponseEnricherList
                            .FirstOrDefault(x => x.CanEnrich(context));

            if (enricher != null) Task.FromResult(enricher.Enrich(context));
        }
    }
}