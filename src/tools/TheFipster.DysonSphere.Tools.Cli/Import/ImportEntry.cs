using CommandLine;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;

namespace TheFipster.DysonSphere.Tools.Cli.Import
{
    public class ImportEntry
    {
        public static async Task<int> RunAsync(ImportVerb options, IConfigurationRoot configuration)
        {
            try
            {
                await new Importer().ExecuteAsync(options, configuration);
                return 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.GetType().Name);
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                return 1;
            }
        }
    }

    [Verb("import", HelpText = "Import the archived seeds into the data warehouse.")]
    public class ImportVerb
    {
        [Option('i', "input", HelpText = "The root directory in which the seed archives are located.", Required = true)]
        public string ImportRoot { get; set; }
    }
}
