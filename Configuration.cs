using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace Backup
{
    [Serializable]
    public class Configuration
    {
        public string HistoryDirectory;
        public List<string> DirectorySources = new List<string>();
        public List<string> FileSources = new List<string>();
        public List<string> Targets = new List<string>();
        public List<string> DirectoryExcludes = new List<string>();
        public List<string> FileExcludes = new List<string>();
    }
}
