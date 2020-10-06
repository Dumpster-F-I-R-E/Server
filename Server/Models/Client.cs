using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Models
{
    public class Client
    {
        public string Name { get; set; }
        public string Id { get; set; }
        public Organization Org { get; set; }
    }
}
