using System;
using System.Linq;

namespace theFipster.DysonSphere.Seed.Domain
{
    public class FlatCluster
    {
        public FlatCluster()
        {
            UpdatedOn = DateTime.UtcNow;
        }

        public int Seed { get; set; }
        public int Starcount { get; set; }

        public int ATypeCount { get; set; }
        public int BTypeCount { get; set; }
        public int FTypeCount { get; set; }
        public int GTypeCount { get; set; }
        public int KTypeCount { get; set; }
        public int MTypeCount { get; set; }
        public int OTypeCount { get; set; }
        public int XTypeCount => DwarfCount + NeutronStarCount + BlackHoleCount;

        public int GiantCount { get; set; }
        public int DwarfCount { get; set; }
        public int NeutronStarCount { get; set; }
        public int BlackHoleCount { get; set; }

        public int IceGiantCount { get; set; }
        public int GasGiantCount { get; set; }
        public int RockyPlanetCount => TotalPlanetCount - IceGiantCount - GasGiantCount;
        public int TotalPlanetCount { get; set; }

        public float MaxLuminosity { get; set; }
        public float AvgLuminosity { get; set; }
        public float MinLuminosity { get; set; }

        public float MaxRadius { get; set; }
        public float AvgRadius { get; set; }
        public float MinRadius { get; set; }

        public float AvgResourceCoeficient { get; set; }
        public float MaxResourceCoeficient { get; set; }
        public float MinResourceCoeficient { get; set; }
        public float UnipolarCoeficient { get; set; }

        public float AEnergy { get; set; }
        public float BEnergy { get; set; }
        public float FEnergy { get; set; }
        public float GEnergy { get; set; }
        public float KEnergy { get; set; }
        public float MEnergy { get; set; }
        public float OEnergy { get; set; }
        public float BHEnergy { get; set; }
        public float NSEnergy { get; set; }
        public float WDEnergy { get; set; }
        public float GiantsEnergy { get; set; }

        public float MinStarEnergy { get; set; }
        public float AvgStarEnergy { get; private set; }
        public float MaxStarEnergy { get; set; }
        public float TotalEnergy { get; set; }

        public float AverageDistance { get; set; }
        public float MinDistance { get; set; }
        public float MaxDistance { get; set; }

        public int StarsWithin10Ly { get; set; }
        public int StarsWithin20Ly { get; set; }
        public int StarsWithin30Ly { get; set; }
        public int StarsWithin40Ly { get; set; }

        public bool IsBirthGiantIce { get; set; }
        public int BirthMoonCount { get; set; }

        public DateTime UpdatedOn { get; set; }

        public static FlatCluster FromCluster(Cluster cluster)
        {
            var flat = new FlatCluster();

            flat.Seed = cluster.Seed;
            flat.Starcount = cluster.Stars.Count();

            flat.ATypeCount = cluster.Stars.Count(x => x.SpectralClass == "A");
            flat.BTypeCount = cluster.Stars.Count(x => x.SpectralClass == "B");
            flat.FTypeCount = cluster.Stars.Count(x => x.SpectralClass == "F");
            flat.GTypeCount = cluster.Stars.Count(x => x.SpectralClass == "G");
            flat.KTypeCount = cluster.Stars.Count(x => x.SpectralClass == "K");
            flat.MTypeCount = cluster.Stars.Count(x => x.SpectralClass == "M");
            flat.OTypeCount = cluster.Stars.Count(x => x.SpectralClass == "O");

            flat.BlackHoleCount = cluster.Stars.Count(x => x.Type == "BlackHole");
            flat.NeutronStarCount = cluster.Stars.Count(x => x.Type == "NeutronStar");
            flat.DwarfCount = cluster.Stars.Count(x => x.Type == "WhiteDwarf");

            flat.GiantCount = cluster.Stars.Count(x => x.IsGiant);

            flat.GasGiantCount = cluster.Stars.Count(x => x.HasGas);
            flat.IceGiantCount = cluster.Stars.Count(x => x.HasIce);
            flat.TotalPlanetCount = cluster.Stars.Sum(x => x.Planets.Count());

            flat.MaxLuminosity = cluster.Stars.Max(x => x.Luminosity);
            flat.AvgLuminosity = cluster.Stars.Average(x => x.Luminosity);
            flat.MinLuminosity = cluster.Stars.Min(x => x.Luminosity);

            flat.MaxRadius = cluster.Stars.Max(x => x.Radius);
            flat.AvgRadius = cluster.Stars.Average(x => x.Radius);
            flat.MinRadius = cluster.Stars.Min(x => x.Radius);

            flat.MaxResourceCoeficient = cluster.Stars.Max(x => x.ResourceCoeficient);
            flat.AvgResourceCoeficient = cluster.Stars.Average(x => x.ResourceCoeficient);
            flat.MinResourceCoeficient = cluster.Stars.Min(x => x.ResourceCoeficient);

            if (cluster.Stars.Any(x => x.Type == "NeutronStar"))
                flat.UnipolarCoeficient += cluster.Stars.Where(x => x.Type == "NeutronStar").Sum(x => x.ResourceCoeficient);

            if (cluster.Stars.Any(x => x.Type == "BlackHole"))
                flat.UnipolarCoeficient += cluster.Stars.Where(x => x.Type == "BlackHole").Sum(x => x.ResourceCoeficient);

            flat.AEnergy = (float)cluster.Stars.Where(x => x.SpectralClass == "A").Sum(x => x.Energy);
            flat.BEnergy = (float)cluster.Stars.Where(x => x.SpectralClass == "B").Sum(x => x.Energy);
            flat.FEnergy = (float)cluster.Stars.Where(x => x.SpectralClass == "F").Sum(x => x.Energy);
            flat.GEnergy = (float)cluster.Stars.Where(x => x.SpectralClass == "G").Sum(x => x.Energy);
            flat.KEnergy = (float)cluster.Stars.Where(x => x.SpectralClass == "K").Sum(x => x.Energy);
            flat.MEnergy = (float)cluster.Stars.Where(x => x.SpectralClass == "M").Sum(x => x.Energy);
            flat.OEnergy = (float)cluster.Stars.Where(x => x.SpectralClass == "O").Sum(x => x.Energy);
            flat.BHEnergy = (float)cluster.Stars.Where(x => x.Type == "BlackHole").Sum(x => x.Energy);
            flat.NSEnergy = (float)cluster.Stars.Where(x => x.Type == "NeutronStar").Sum(x => x.Energy);
            flat.WDEnergy = (float)cluster.Stars.Where(x => x.Type == "WhiteDwarf").Sum(x => x.Energy);
            flat.GiantsEnergy = (float)cluster.Stars.Where(x => x.IsGiant).Sum(x => x.Energy);

            flat.MaxStarEnergy = (float)cluster.Stars.Max(x => x.Energy);
            flat.AvgStarEnergy = (float)cluster.Stars.Average(x => x.Energy);
            flat.MinStarEnergy = (float)cluster.Stars.Min(x => x.Energy);
            flat.TotalEnergy= (float)cluster.Stars.Sum(x => x.Energy);

            flat.MaxDistance = (float)cluster.Stars.Max(x => x.DistanceFromBirth);
            flat.AverageDistance = (float)cluster.Stars.Where(x => x.DistanceFromBirth > 0).Average(x => x.DistanceFromBirth);
            flat.MinDistance = (float)cluster.Stars.Where(x => x.DistanceFromBirth > 0).Min(x => x.DistanceFromBirth);

            flat.StarsWithin10Ly = cluster.Stars.Count(x => x.DistanceFromBirth <= 10);
            flat.StarsWithin20Ly = cluster.Stars.Count(x => x.DistanceFromBirth <= 20);
            flat.StarsWithin30Ly = cluster.Stars.Count(x => x.DistanceFromBirth <= 30);
            flat.StarsWithin40Ly = cluster.Stars.Count(x => x.DistanceFromBirth <= 40);

            var birth = cluster.Stars.OrderBy(x => x.DistanceFromBirth).First();

            if (birth.HasIce)
                flat.IsBirthGiantIce = true;

            flat.BirthMoonCount = birth.Planets.Count(x => x.OrbitsAround != 0);

            return flat;
        }
    }
}
