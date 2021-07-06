using Microsoft.Extensions.Configuration;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TheFipster.DysonSphere.Seed.Api.Abstractions;

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

        public async Task<IEnumerable<object[]>> GetSeeds()
        {
            List<object[]> rows = new List<object[]>();
            var cmd = new NpgsqlCommand(@"SELECT 
                ""Seed"",
                ""OTypeCount"",
                ""GiantCount"",
                ""DwarfCount"",
                ""NeutronStarCount"",
                ""BlackHoleCount"",
                ""IceGiantCount"",
                ""GasGiantCount"",
                ""RockyPlanetCount"",
                ""MaxLuminosity"",
                ""MaxRadius"",
                ""AvgResourceCoeficient"",
                ""MaxResourceCoeficient"",
                ""UnipolarCoeficient"",
                ""MaxStarEnergy"",
                ""TotalEnergy"",
                ""AverageDistance"",
                ""StarsWithin10Ly"",
                ""StarsWithin20Ly"",
                ""BirthMoonCount"",
                ""IsBirthGiantIce""
                FROM seeds LIMIT 500", 
                connection);
            using (var reader = await cmd.ExecuteReaderAsync())
            {
                var names = new string[reader.FieldCount];

                for (var i = 0; i < reader.FieldCount; i++)
                    names[i] = reader.GetName(i);

                rows.Add(names);

                while (reader.Read())
                {
                    var values = new object[reader.FieldCount];
                    reader.GetValues(values);
                    rows.Add(values);
                }
            }

            return rows;
        }

        public void Dispose()
            => connection.Dispose();
    }
}
