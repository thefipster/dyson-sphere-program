using Couchbase;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;
using TheFipster.DysonSphere.Tools.Cli.Config;

namespace TheFipster.DysonSphere.Tools.Cli.Import
{
    public class CouchWriter : IDisposable
    {
        private CouchbaseConfig config;
        private ICluster cluster;

        public CouchWriter(IConfiguration config)
        {
            this.config = new CouchbaseConfig();
            config.GetSection("Couchbase").Bind(this.config);
        }

        public async Task ConnectAsync()
            => cluster = await Cluster.ConnectAsync(config.Host, config.User, config.Password);

        public async Task WriteAsync(theFipster.DysonSphere.Seed.Domain.Cluster starCluster)
        {
            var bucket = await cluster.BucketAsync("seeds");
            var collection = bucket.DefaultCollection();
            await collection.InsertAsync(starCluster.Seed.ToString(), starCluster);
        }

        public async Task UpsertAsync(theFipster.DysonSphere.Seed.Domain.Cluster starCluster)
        {
            var bucket = await cluster.BucketAsync("seeds");
            var collection = bucket.DefaultCollection();
            await collection.UpsertAsync(starCluster.Seed.ToString(), starCluster);
        }

        public void Dispose()
            => cluster.Dispose();
    }
}
