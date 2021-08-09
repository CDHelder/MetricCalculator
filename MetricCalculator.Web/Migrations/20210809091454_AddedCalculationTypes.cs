using Microsoft.EntityFrameworkCore.Migrations;

namespace MetricCalculator.Web.Migrations
{
    public partial class AddedCalculationTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CalculationTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CalculationTypes", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "CalculationTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "MeterToCentimeter" },
                    { 2, "CentimeterToMeter" },
                    { 3, "CentimeterToMillimeter" },
                    { 4, "MillimeterToCentimeter" },
                    { 5, "MeterToInch" },
                    { 6, "InchToMeter" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CalculationTypes");
        }
    }
}
