using Dapper;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TheFipster.DysonSphere.Seed.Api.Abstractions;
using TheFipster.DysonSphere.Seed.Api.Models;

namespace TheFipster.DysonSphere.Seed.Api.Services
{
    public class FlatClusterLoader : IFlatClusterLoader, IDisposable
    {
        private NpgsqlConnection connection;

        public FlatClusterLoader(IConfiguration config)
        {
            var connectionString = config.GetConnectionString("Postgres");
            connection = new NpgsqlConnection(connectionString);
            connection.Open();
        }

        public async Task<IEnumerable<SeedModel>> GetSeeds()
        {
            return await connection.QueryAsync<SeedModel>(@"SELECT 
                ""Seed"",
                ""OTypeCount"",
                ""GiantCount"",
                ""DwarfCount"",
                ""NeutronStarCount"",
                ""BlackHoleCount"",
                ""IceGiantCount"",
                ""GasGiantCount"",
                ""MaxLuminosity"",
                ""MaxRadius"",
                ""AvgResourceCoeficient"",
                ""UnipolarCoeficient"",
                ""MaxStarEnergy"",
                ""TotalEnergy"",
                ""AverageDistance"",
                ""BirthMoonCount"",
                ""IsBirthGiantIce""
                FROM seeds LIMIT 500");
        }

        public async Task<IEnumerable<SeedModel>> GetSeeds(SeedSearchModel search)
        {
            return await connection.QueryAsync<SeedModel>(@$"SELECT 
                ""Seed"",
                ""OTypeCount"",
                ""GiantCount"",
                ""DwarfCount"",
                ""NeutronStarCount"",
                ""BlackHoleCount"",
                ""IceGiantCount"",
                ""GasGiantCount"",
                ""MaxLuminosity"",
                ""MaxRadius"",
                ""AvgResourceCoeficient"",
                ""UnipolarCoeficient"",
                ""MaxStarEnergy"",
                ""TotalEnergy"",
                ""AverageDistance"",
                ""BirthMoonCount"",
                ""IsBirthGiantIce""
                FROM seeds 
                ORDER BY ""{search.SortColumn}"" {search.SortDirection}
                LIMIT 500");
        }

        public void Dispose()
            => connection.Dispose();
    }
}
