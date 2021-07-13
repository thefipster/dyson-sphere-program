using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System;
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
        private IMemoryCache cache;

        private MemoryCacheEntryOptions cacheOptions = new MemoryCacheEntryOptions()
        {
            AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5)
        };

        public SeedsController(IFlatClusterLoader clusterLoader, IMemoryCache memoryCache)
        { 
            loader = clusterLoader;
            cache = memoryCache;
        }

        [HttpPost]
        public async Task<IEnumerable<SeedModel>> Search([FromBody] SeedSearchModel searchModel)
        {
            var searchHash = searchModel.GetHashCode();
            if (cache.TryGetValue(searchHash, out var cachedResult))
                return (IEnumerable<SeedModel>)cachedResult;

            searchModel.SortColumn = capitalize(searchModel.SortColumn);
            for (int i = 0; i < searchModel.Filters.Count(); i++)
                searchModel.Filters[i].Column = capitalize(searchModel.Filters[i].Column);

            var computedResult = await loader.GetSeeds(searchModel);
            cache.Set(searchHash, computedResult, cacheOptions);
            return computedResult;
        }

        private string capitalize(string text)
            => char.ToUpper(text.First()) + text.Substring(1);
    }
}
