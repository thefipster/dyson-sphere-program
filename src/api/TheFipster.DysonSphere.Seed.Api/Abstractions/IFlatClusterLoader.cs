using System.Collections.Generic;
using System.Threading.Tasks;

namespace TheFipster.DysonSphere.Seed.Api.Abstractions
{
    public interface IFlatClusterLoader
    {
        Task<IEnumerable<object[]>> GetSeeds();
    }
}
