using Sitecore.ContentSearch;
using Sitecore.ContentSearch.Maintenance;
using Sitecore.Services.Infrastructure.Security;
using System.Web.Http;

namespace SolrSchemaPopulationApi.Controllers
{
  [RoutePrefix("api/solrschemamaintenance")]
  [RequiredApiKey]
  public class SolrSchemaController : ApiController
  {
    [HttpGet]
    [Route("populate")]
    public IHttpActionResult Populate()
    {
      foreach (ISearchIndex index in ContentSearchManager.Indexes)
      {
        SchemaCustodian.PopulateManagedSchema(index);
      }

      return Ok("Done");
    }
  }
}
