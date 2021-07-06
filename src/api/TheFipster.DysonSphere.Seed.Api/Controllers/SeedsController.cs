using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TheFipster.DysonSphere.Seed.Api.Abstractions;

namespace TheFipster.DysonSphere.Seed.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeedsController : ControllerBase
    {
        private IFlatClusterLoader loader;

        public SeedsController(IFlatClusterLoader clusterLoader)
            => loader = clusterLoader;

        public async Task<IEnumerable<object[]>> Index()
           => await loader.GetSeeds();
    }
}
