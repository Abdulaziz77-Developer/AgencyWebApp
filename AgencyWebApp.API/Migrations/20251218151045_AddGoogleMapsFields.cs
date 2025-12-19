using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgencyWebApp.API.Migrations
{
    /// <inheritdoc />
    public partial class AddGoogleMapsFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "HomeLatitude",
                table: "Users",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "HomeLongitude",
                table: "Users",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "StartLatitude",
                table: "Tours",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "StartLongitude",
                table: "Tours",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Latitude",
                table: "Hotels",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Longitude",
                table: "Hotels",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "FromLatitude",
                table: "Flights",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "FromLongitude",
                table: "Flights",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "ToLatitude",
                table: "Flights",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "ToLongitude",
                table: "Flights",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "TourPoint",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TourId = table.Column<int>(type: "int", nullable: false),
                    Latitude = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Longitude = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TourPoint", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TourPoint_Tours_TourId",
                        column: x => x.TourId,
                        principalTable: "Tours",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TourPoint_TourId",
                table: "TourPoint",
                column: "TourId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TourPoint");

            migrationBuilder.DropColumn(
                name: "HomeLatitude",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "HomeLongitude",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "StartLatitude",
                table: "Tours");

            migrationBuilder.DropColumn(
                name: "StartLongitude",
                table: "Tours");

            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "Hotels");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "Hotels");

            migrationBuilder.DropColumn(
                name: "FromLatitude",
                table: "Flights");

            migrationBuilder.DropColumn(
                name: "FromLongitude",
                table: "Flights");

            migrationBuilder.DropColumn(
                name: "ToLatitude",
                table: "Flights");

            migrationBuilder.DropColumn(
                name: "ToLongitude",
                table: "Flights");
        }
    }
}
