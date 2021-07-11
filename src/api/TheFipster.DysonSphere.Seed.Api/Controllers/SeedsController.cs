using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheFipster.DysonSphere.Seed.Api.Abstractions;
using TheFipster.DysonSphere.Seed.Api.Models;

namespace TheFipster.DysonSphere.Seed.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeedsController : ControllerBase
    {
        private IFlatClusterLoader loader;

        public SeedsController(IFlatClusterLoader clusterLoader)
            => loader = clusterLoader;

        [HttpPost]
        public async Task<IEnumerable<SeedModel>> Search([FromBody]SeedSearchModel searchModel)
        {
            searchModel.SortColumn = capitalize(searchModel.SortColumn);
            for (int i = 0; i < searchModel.Filters.Count(); i++)
                searchModel.Filters[i].Column = capitalize(searchModel.Filters[i].Column);

            return await loader.GetSeeds(searchModel);
        }

        private string capitalize(string text)
            => char.ToUpper(text.First()) + text.Substring(1);
    }
}
