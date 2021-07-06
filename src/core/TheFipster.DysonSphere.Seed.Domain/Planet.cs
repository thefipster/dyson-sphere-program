using Newtonsoft.Json;
using System.Collections.Generic;

namespace theFipster.DysonSphere.Seed.Domain
{
    public class Planet
    {
        public Planet()
        {
            Veins = new List<Vein>();
        }

        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int Id { get; set; }
        [JsonProperty("i", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int Index { get; set; }
        [JsonProperty("n", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int Number { get; set; }

        [JsonProperty("nam", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Name { get; set; }
        [JsonProperty("typ", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Type { get; set; }
        [JsonProperty("sin", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Singularity { get; set; }
        [JsonProperty("land", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public float LandArea { get; set; }
        [JsonProperty("wat", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int Ocean { get; set; }

        [JsonProperty("dis", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public float Distance { get; set; }

        [JsonProperty("win", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public float Wind { get; set; }
        [JsonProperty("sol", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public float Solar { get; set; }

        [JsonProperty("g", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool IsGiant { get; set; }
        [JsonProperty("gTyp", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string GiantType { get; set; }

        [JsonProperty("v", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public IList<Vein> Veins { get; set; }

        [JsonProperty("orb", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int OrbitsAround { get; set; }
    }
}
