using System.Collections.Generic;
using System.Threading.Tasks;
using TheFipster.DysonSphere.Seed.Api.Models;

namespace TheFipster.DysonSphere.Seed.Api.Abstractions
{
    public interface IFlatClusterLoader
    {
        Task<IEnumerable<SeedModel>> GetSeeds();
        Task<IEnumerable<SeedModel>> GetSeeds(SeedSearchModel search);
    }
}
