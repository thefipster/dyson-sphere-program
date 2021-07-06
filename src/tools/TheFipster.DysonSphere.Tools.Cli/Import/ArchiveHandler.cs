using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using theFipster.DysonSphere.Seed.Domain;

namespace TheFipster.DysonSphere.Tools.Cli.Import
{
    public class ArchiveHandler
    {
        private ImportVerb options;

        public ArchiveHandler(ImportVerb options)
        {
            this.options = options;
        }

        public IEnumerable<string> GetArchives()
            => Directory.GetFiles(options.ImportRoot, "dsp_seeds_*.zip");

        public IEnumerable<int> GetBatches(string archive)
        {
            var entries = ZipFile.OpenRead(archive).Entries;
            foreach (var entry in entries)
            {
                var name = entry.Name.Replace(".zip", string.Empty);
                yield return int.Parse(name);
            }
        }

        internal IEnumerable<Cluster> GetSeeds(string archive, int batch)
        {
            var entry = ZipFile.OpenRead(archive).Entries.Where(x => x.Name == $"{batch.ToString("0000")}.zip").First();
            var clusters = new List<Cluster>();
            using (var entryStream = entry.Open())
            {
                var zip = new ZipArchive(entryStream);
                foreach (var seed in zip.Entries)
                {
                    using(var stream = seed.Open())
                    {
                        var reader = new StreamReader(stream);
                        var json = reader.ReadToEnd();
                        var cluster = JsonConvert.DeserializeObject<Cluster>(json);
                        clusters.Add(cluster);
                    }
                }
            }

            return clusters;
        }
    }
}
