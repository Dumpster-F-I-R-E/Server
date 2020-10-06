using Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server
{

    public class Dumpster
    {
        public int Fullness { get; set; }
        public int Battery { get; set; }

        public bool Open { get; set; }

        public Location Location { get; set; }

        public Organization Org { get; set; }
    }
}
