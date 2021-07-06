using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using theFipster.DysonSphere.Seed.Domain;

namespace TheFipster.DysonSphere.Tools.Cli.Import
{
    public class Importer
    {
        private IConfigurationRoot config;
        private ArchiveHandler files;
        private CouchWriter couchbase;

        internal async Task ExecuteAsync(ImportVerb options, IConfigurationRoot configuration)
        {
            await setupAsync(options, configuration);

            var archives = files.GetArchives();
            foreach (var archive in archives)
            {
                Console.WriteLine(archive);
                var batches = files.GetBatches(archive);
                var tasks = new List<Task>();
                foreach (var batch in batches)
                    tasks.Add(Task.Run(async () => await runBatch(archive, batch)));

                Task.WaitAll(tasks.ToArray());
                Console.WriteLine();
            }

            teardown();
        }

        private async Task runBatch(string archive, int batch)
        {
            var postgres = new PostgresWriter(config);
            postgres.Connect();

            var clusters = files.GetSeeds(archive, batch);
            foreach (var cluster in clusters)
            {
                Console.Write(".");
                var flat = FlatCluster.FromCluster(cluster);
                postgres.Insert(flat);
                await couchbase.WriteAsync(cluster);
            }
            postgres.Dispose();
        }


        private async Task setupAsync(ImportVerb options, IConfigurationRoot configuration)
        {
            config = configuration;
            files = new ArchiveHandler(options);
            couchbase = new CouchWriter(configuration);

            await couchbase.ConnectAsync();
        }

        private void teardown()
        {
            couchbase.Dispose();
            couchbase = null;
        }
    }
}
