using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace theFipster.DysonSphere.Seed.Domain
{
    public class Cluster
    {
        public Cluster()
        {
            Stars = new List<Star>();
            DataVersion = 1;
            UpdatedOn = DateTime.UtcNow;
        }

        [JsonProperty("s", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int Seed { get; set; }

        [JsonProperty("stars", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public ICollection<Star> Stars { get; set; }

        public int DataVersion { get; set; }

        public DateTime UpdatedOn { get; set; }
    }
}
