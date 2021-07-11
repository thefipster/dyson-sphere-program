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

        [HttpGet]
        public async Task<IEnumerable<SeedModel>> Index()
           => await loader.GetSeeds();

        [HttpPost]
        public async Task<IEnumerable<SeedModel>> Search([FromBody]SeedSearchModel searchModel)
        {
            searchModel.SortColumn = char.ToUpper(searchModel.SortColumn.First()) + searchModel.SortColumn.Substring(1);
            return await loader.GetSeeds(searchModel);
        }
    }
}
