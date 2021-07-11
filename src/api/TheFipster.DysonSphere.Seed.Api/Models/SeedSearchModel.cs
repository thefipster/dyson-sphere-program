using System.Collections.Generic;

namespace TheFipster.DysonSphere.Seed.Api.Models
{
    public class SeedSearchModel
    {
        public SeedSearchModel()
            => Filters = new SeedFilterModel[0];

        public string SortColumn { get; set; }

        public string SortDirection { get; set; }

        public SeedFilterModel[] Filters { get;  set; }
    }
}
