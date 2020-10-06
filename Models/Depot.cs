using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Models
{
    public class Depot
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public Organization Org { get; set; }
    }
}
