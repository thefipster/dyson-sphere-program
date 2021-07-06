using Newtonsoft.Json;
using System.Collections.Generic;

namespace theFipster.DysonSphere.Seed.Domain
{
    public class Star
    {
        public Star()
        {
            Planets = new List<Planet>();
        }

        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int Id { get; set; }

        [JsonProperty("i", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public int Index { get; set; }

        [JsonProperty("nam", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("x", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public double X { get; set; }

        [JsonProperty("y", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public double Y { get; set; }

        [JsonProperty("z", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public double Z { get; set; }

        [JsonProperty("cof", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public float ResourceCoeficient { get; set; }

        [JsonProperty("spc", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string SpectralClass { get; set; }

        [JsonProperty("typ", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string Type{ get; set; }

        [JsonProperty("g", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool IsGiant { get; set; }

        [JsonProperty("ice", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool HasIce { get; set; }

        [JsonProperty("gas", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool HasGas { get; set; }

        [JsonProperty("e", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public double Energy { get; set; }

        [JsonProperty("dis", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public double DistanceFromBirth { get; set; }

        [JsonProperty("p", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public ICollection<Planet> Planets { get; set; }

        [JsonProperty("lum", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public float Luminosity { get; set; }

        [JsonProperty("rad", NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore)]
        public float Radius { get; set; }
    }
}
