using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Models
{
    public class DumpsterMap
    {
        public List<Dumpster> Dumpsters { get; set; }

        public List<Depot> Depots { get; set; }
    }
}
