using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Models
{
    public class Organization
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Id { get; set; }

        public List<Dumpster> Dumspters { get; set; }
        public List<Driver> Drivers { get; set; }
        public List<Manager> Managers { get; set; }

    }
}
