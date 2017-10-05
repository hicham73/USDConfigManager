using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USDManager.Model
{
    class Configuration
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Dictionary<string, int> Stats { get; set; }
    }
}
