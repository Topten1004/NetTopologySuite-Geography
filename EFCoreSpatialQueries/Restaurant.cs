using NetTopologySuite.Geometries;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCoreSpatialQueries
{
    public class Restaurant
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public Point Location { get; set; }
    }
}
