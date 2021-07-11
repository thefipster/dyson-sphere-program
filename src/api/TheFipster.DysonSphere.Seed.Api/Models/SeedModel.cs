namespace TheFipster.DysonSphere.Seed.Api.Models
{
    public class SeedModel
    {
        public int Seed { get; set; }
        public int OTypeCount { get; set; }
        public int GiantCount { get; set; }
        public int DwarfCount { get; set; }
        public int NeutronStarCount { get; set; }
        public int BlackHoleCount { get; set; }
        public int GasGiantCount { get; set; }
        public int IceGiantCount { get; set; }
        public double MaxLuminosity { get; set; }
        public double MaxRadius { get; set; }
        public double AvgResourceCoeficient { get; set; }
        public double UnipolarCoeficient { get; set; }
        public double MaxStarEnergy { get; set; }
        public double TotalEnergy { get; set; }
        public double AverageDistance { get; set; }
        public int BirthMoonCount { get; set; }
        public bool IsBirthGiantIce { get; set; }
    }
}
