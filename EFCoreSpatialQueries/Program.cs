using NetTopologySuite;
using NetTopologySuite.Geometries;
using System;
using System.Linq;

namespace EFCoreSpatialQueries
{
    class Program
    {
        static void Main(string[] args)
        {

            var geometryFactory = NtsGeometryServices.Instance.CreateGeometryFactory(srid: 4326);

            var myLocation = geometryFactory.CreatePoint(new Coordinate(-69.938951, 18.481188));

            using (var context = new ApplicationDbContext())
            {
                var restaurants = context.Restaurants
                    .OrderBy(x => x.Location.Distance(myLocation))
                    .Where(x => x.Location.IsWithinDistance(myLocation, 2000))
                    .Select(x => new { x.Name, x.City, Distance = x.Location.Distance(myLocation) })
                    .ToList();

                Console.WriteLine("-----------");

                foreach (var restaurant in restaurants)
                {
                    Console.WriteLine($"{restaurant.Name} from {restaurant.City} ({restaurant.Distance.ToString("N0")} meters away)");
                }
            }
        }
    }
}
