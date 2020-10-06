using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Models
{
    public class Location
    {
        public int Lattitude { get; set; }
        public int Longitude { get; set; }

        public Location(int x, int y)
        {
            Lattitude = x;
            Longitude = y;
        }
    }
}
