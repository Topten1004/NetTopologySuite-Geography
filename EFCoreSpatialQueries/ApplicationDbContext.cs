using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NetTopologySuite;
using NetTopologySuite.Geometries;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCoreSpatialQueries
{
    public class ApplicationDbContext: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=EFCoreSpatial;Integrated Security=True",
                    x => x.UseNetTopologySuite())
                .UseLoggerFactory(MyLoggerFactory);

            base.OnConfiguring(optionsBuilder);
        }

        public static readonly ILoggerFactory MyLoggerFactory = LoggerFactory.Create(builder =>
        {
            builder
               .AddFilter((category, level) =>
                   category == DbLoggerCategory.Database.Command.Name
                   && level == LogLevel.Information)
               .AddConsole();
        });

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            var geometryFactory = NtsGeometryServices.Instance.CreateGeometryFactory(srid: 4326);

            modelBuilder.Entity<Restaurant>()
                .HasData(
                    new List<Restaurant>()
            {
                new Restaurant(){Id = 1, Name = "Agora", City = "Santo Domingo", Location = geometryFactory.CreatePoint(new Coordinate(-69.9388777, 18.4839233))},
                new Restaurant(){Id = 2, Name = "Sambil", City = "Santo Domingo", Location = geometryFactory.CreatePoint(new Coordinate(-69.9118804, 18.4826214))},
                new Restaurant(){Id = 3, Name = "Adrian Tropical", City = "Santo Domingo", Location = geometryFactory.CreatePoint(new Coordinate(-69.9334673, 18.4718075))},
                new Restaurant(){Id = 4, Name = "Restaurante El Cardenal", City = "Mexito City", Location = geometryFactory.CreatePoint(new Coordinate(-99.1353659,19.4336164))}
            });

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Restaurant> Restaurants { get; set; }
    }
}
