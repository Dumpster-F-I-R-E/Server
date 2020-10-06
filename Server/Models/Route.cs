using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Models
{
    public class Route
    {
        public List<Location> Path { get; set; }
        public DumpsterMap AssignedMap { get; set; }
    }
}
