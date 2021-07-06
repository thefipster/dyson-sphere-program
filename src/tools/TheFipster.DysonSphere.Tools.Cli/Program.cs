using CommandLine;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Threading.Tasks;
using TheFipster.DysonSphere.Tools.Cli.Import;

namespace TheFipster.DysonSphere.Tools.Cli
{
    class Program
    {
        static async Task<int> Main(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
                .AddJsonFile("appsettings.json", false)
                .Build();

            return await Parser.Default.ParseArguments<ImportVerb>(args)
                .MapResult(
                  (ImportVerb options) => ImportEntry.RunAsync(options, configuration),
                  errors => Task.FromResult(1));
        }
    }
}
