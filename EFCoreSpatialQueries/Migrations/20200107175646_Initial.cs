using Microsoft.EntityFrameworkCore.Migrations;
using NetTopologySuite.Geometries;

namespace EFCoreSpatialQueries.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Restaurants",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    Location = table.Column<Point>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restaurants", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Restaurants",
                columns: new[] { "Id", "City", "Location", "Name" },
                values: new object[,]
                {
                    { 1, "Santo Domingo", (NetTopologySuite.Geometries.Point)new NetTopologySuite.IO.WKTReader().Read("SRID=4326;POINT (-69.9388777 18.4839233)"), "Agora" },
                    { 2, "Santo Domingo", (NetTopologySuite.Geometries.Point)new NetTopologySuite.IO.WKTReader().Read("SRID=4326;POINT (-69.9118804 18.4826214)"), "Sambil" },
                    { 3, "Santo Domingo", (NetTopologySuite.Geometries.Point)new NetTopologySuite.IO.WKTReader().Read("SRID=4326;POINT (-69.9334673 18.4718075)"), "Adrian Tropical" },
                    { 4, "Mexito City", (NetTopologySuite.Geometries.Point)new NetTopologySuite.IO.WKTReader().Read("SRID=4326;POINT (-99.1353659 19.4336164)"), "Restaurante El Cardenal" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Restaurants");
        }
    }
}
