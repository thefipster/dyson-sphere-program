using Dapper;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using TheFipster.DysonSphere.Seed.Api.Abstractions;
using TheFipster.DysonSphere.Seed.Api.Models;

namespace TheFipster.DysonSphere.Seed.Api.Services
{
    public class FlatClusterLoader : IFlatClusterLoader, IDisposable
    {
        private const int limit = 50;

        private List<string> columns = new List<string>
        {
                "Seed",
                "OTypeCount",
                "GiantCount",
                "DwarfCount",
                "NeutronStarCount",
                "BlackHoleCount",
                "IceGiantCount",
                "GasGiantCount",
                "MaxLuminosity",
                "MaxRadius",
                "AvgResourceCoeficient",
                "UnipolarCoeficient",
                "MaxStarEnergy",
                "TotalEnergy",
                "AverageDistance",
                "BirthMoonCount",
                "IsBirthGiantIce"
        };

        private NpgsqlConnection connection;

        public FlatClusterLoader(IConfiguration config)
        {
            var connectionString = config.GetConnectionString("Postgres");
            connection = new NpgsqlConnection(connectionString);
            connection.Open();
        }

        public async Task<IEnumerable<SeedModel>> GetSeeds(SeedSearchModel search)
        {
            if (!columns.Contains(search.SortColumn))
                throw new Exception("Invalid sort column.");
            
            var query = "SELECT ";
            query += string.Join(", ", columns.Select(x => $"\"{x}\""));
            query += $" FROM {SeedModel.Table}";

            if (search.Filters.Any())
            {
                var first = search.Filters.First();
                query += $" WHERE \"{first.Column}\" BETWEEN {first.Min.ToString(CultureInfo.CreateSpecificCulture("en-US"))} AND {first.Max.ToString(CultureInfo.CreateSpecificCulture("en-US"))}";

                if (search.Filters.Count() > 1)
                {
                    foreach (var filter in search.Filters.Skip(1))
                    {
                        if (!columns.Contains(filter.Column))
                            throw new Exception("Invalid filter column.");

                        query += $" AND \"{filter.Column}\" BETWEEN {filter.Min.ToString(CultureInfo.CreateSpecificCulture("en-US"))} AND {filter.Max.ToString(CultureInfo.CreateSpecificCulture("en-US"))}";
                    }
                }
            }

            query += $" ORDER BY \"{search.SortColumn}\" {search.SortDirection}";
            query += $" LIMIT {limit}";

            return await connection.QueryAsync<SeedModel>(query);
        }

        public void Dispose()
            => connection.Dispose();
    }
}
