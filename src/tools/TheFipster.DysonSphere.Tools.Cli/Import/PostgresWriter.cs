using Microsoft.Extensions.Configuration;
using Npgsql;
using System;
using System.Threading.Tasks;
using theFipster.DysonSphere.Seed.Domain;

namespace TheFipster.DysonSphere.Tools.Cli.Import
{
    public class PostgresWriter : IDisposable
    {
        private IConfiguration config;
        private NpgsqlConnection conn;

        public PostgresWriter(IConfiguration config)
            => this.config = config;

        public void Connect()
        {
            var connectionString = config.GetConnectionString("Postgres");
            conn = new NpgsqlConnection(connectionString);
            conn.Open();
        }

        public void Dispose()
            => conn.Dispose();

        public void Delete(int seed)
        {
            var cmd = new NpgsqlCommand("DELETE FROM Seeds WHERE \"Seed\"=@Seed", conn);
            cmd.Parameters.AddWithValue("Seed", seed);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
        }

        public async Task<bool> Exists(int seed)
        {
            var cmd = new NpgsqlCommand("SELECT 1 FROM seeds WHERE \"Seed\" = @Seed", conn);
            cmd.Parameters.AddWithValue("Seed", seed);
            var reader = cmd.ExecuteReader();
            var exists = reader.HasRows;
            cmd.Dispose();
            await reader.DisposeAsync();
            return exists;
        }

        public void Insert(FlatCluster cluster)
        {
            var cmd = new NpgsqlCommand(@"INSERT INTO seeds VALUES (
                @Seed, 
                @Starcount, 
                @ATypeCount, 
                @BTypeCount,
                @FTypeCount,
                @GTypeCount,
                @KTypeCount,
                @MTypeCount,
                @OTypeCount,
                @XTypeCount,
                @GiantCount,
                @DwarfCount,
                @NeutronStarCount,
                @BlackHoleCount,
                @IceGiantCount,
                @GasGiantCount,
                @RockyPlanetCount,
                @TotalPlanetCount,
                @MaxLuminosity,
                @AvgLuminosity,
                @MinLuminosity,
                @MaxRadius,
                @AvgRadius,
                @MinRadius,
                @AvgResourceCoeficient,
                @MaxResourceCoeficient,
                @MinResourceCoeficient,
                @UnipolarCoeficient,
                @AEnergy,
                @BEnergy,
                @FEnergy,
                @GEnergy,
                @KEnergy,
                @MEnergy,
                @OEnergy,
                @BHEnergy,
                @NSEnergy,
                @WDEnergy,
                @GiantsEnergy,
                @MinStarEnergy,
                @AvgStarEnergy,
                @MaxStarEnergy,
                @TotalEnergy,
                @AverageDistance,
                @MinDistance,
                @MaxDistance,
                @StarsWithin10Ly,
                @StarsWithin20Ly,
                @StarsWithin30Ly,
                @StarsWithin40Ly,
                @BirthMoonCount,
                @IsBirthGiantIce,
                @UpdatedOn
            )", conn);

            cmd.Parameters.AddWithValue("Seed", cluster.Seed);
            cmd.Parameters.AddWithValue("Starcount", cluster.Starcount);
            cmd.Parameters.AddWithValue("ATypeCount", cluster.ATypeCount);
            cmd.Parameters.AddWithValue("BTypeCount", cluster.BTypeCount);
            cmd.Parameters.AddWithValue("FTypeCount", cluster.FTypeCount);
            cmd.Parameters.AddWithValue("GTypeCount", cluster.GTypeCount);
            cmd.Parameters.AddWithValue("KTypeCount", cluster.KTypeCount);
            cmd.Parameters.AddWithValue("MTypeCount", cluster.MTypeCount);
            cmd.Parameters.AddWithValue("OTypeCount", cluster.OTypeCount);
            cmd.Parameters.AddWithValue("XTypeCount", cluster.XTypeCount);
            cmd.Parameters.AddWithValue("GiantCount", cluster.GiantCount);
            cmd.Parameters.AddWithValue("DwarfCount", cluster.DwarfCount);
            cmd.Parameters.AddWithValue("NeutronStarCount", cluster.NeutronStarCount);
            cmd.Parameters.AddWithValue("BlackHoleCount", cluster.BlackHoleCount);
            cmd.Parameters.AddWithValue("IceGiantCount", cluster.IceGiantCount);
            cmd.Parameters.AddWithValue("GasGiantCount", cluster.GasGiantCount);
            cmd.Parameters.AddWithValue("RockyPlanetCount", cluster.RockyPlanetCount);
            cmd.Parameters.AddWithValue("TotalPlanetCount", cluster.TotalPlanetCount);
            cmd.Parameters.AddWithValue("MaxLuminosity", cluster.MaxLuminosity);
            cmd.Parameters.AddWithValue("AvgLuminosity", cluster.AvgLuminosity);
            cmd.Parameters.AddWithValue("MinLuminosity", cluster.MinLuminosity);
            cmd.Parameters.AddWithValue("MaxRadius", cluster.MaxRadius);
            cmd.Parameters.AddWithValue("AvgRadius", cluster.AvgRadius);
            cmd.Parameters.AddWithValue("MinRadius", cluster.MinRadius);
            cmd.Parameters.AddWithValue("AvgResourceCoeficient", cluster.AvgResourceCoeficient);
            cmd.Parameters.AddWithValue("MaxResourceCoeficient", cluster.MaxResourceCoeficient);
            cmd.Parameters.AddWithValue("MinResourceCoeficient", cluster.MinResourceCoeficient);
            cmd.Parameters.AddWithValue("UnipolarCoeficient", cluster.UnipolarCoeficient);
            cmd.Parameters.AddWithValue("AEnergy", cluster.AEnergy);
            cmd.Parameters.AddWithValue("BEnergy", cluster.BEnergy);
            cmd.Parameters.AddWithValue("FEnergy", cluster.FEnergy);
            cmd.Parameters.AddWithValue("GEnergy", cluster.GEnergy);
            cmd.Parameters.AddWithValue("KEnergy", cluster.KEnergy);
            cmd.Parameters.AddWithValue("MEnergy", cluster.MEnergy);
            cmd.Parameters.AddWithValue("OEnergy", cluster.OEnergy);
            cmd.Parameters.AddWithValue("BHEnergy", cluster.BHEnergy);
            cmd.Parameters.AddWithValue("NSEnergy", cluster.NSEnergy);
            cmd.Parameters.AddWithValue("WDEnergy", cluster.WDEnergy);
            cmd.Parameters.AddWithValue("GiantsEnergy", cluster.GiantsEnergy);
            cmd.Parameters.AddWithValue("MinStarEnergy", cluster.MinStarEnergy);
            cmd.Parameters.AddWithValue("AvgStarEnergy", cluster.AvgStarEnergy);
            cmd.Parameters.AddWithValue("MaxStarEnergy", cluster.MaxStarEnergy);
            cmd.Parameters.AddWithValue("TotalEnergy", cluster.TotalEnergy);
            cmd.Parameters.AddWithValue("AverageDistance", cluster.AverageDistance);
            cmd.Parameters.AddWithValue("MinDistance", cluster.MinDistance);
            cmd.Parameters.AddWithValue("MaxDistance", cluster.MaxDistance);
            cmd.Parameters.AddWithValue("StarsWithin10Ly", cluster.StarsWithin10Ly);
            cmd.Parameters.AddWithValue("StarsWithin20Ly", cluster.StarsWithin20Ly);
            cmd.Parameters.AddWithValue("StarsWithin30Ly", cluster.StarsWithin30Ly);
            cmd.Parameters.AddWithValue("StarsWithin40Ly", cluster.StarsWithin40Ly);
            cmd.Parameters.AddWithValue("BirthMoonCount", cluster.BirthMoonCount);
            cmd.Parameters.AddWithValue("IsBirthGiantIce", cluster.IsBirthGiantIce);
            cmd.Parameters.AddWithValue("UpdatedOn", cluster.UpdatedOn);

            cmd.ExecuteNonQuery();
            cmd.Dispose();
        }
    }
}
