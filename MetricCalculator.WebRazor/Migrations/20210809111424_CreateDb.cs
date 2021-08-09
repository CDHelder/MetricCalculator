using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MetricCalculator.WebRazor.Migrations
{
    public partial class CreateDb : Migration
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

            migrationBuilder.CreateTable(
                name: "Logs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BeforeValue = table.Column<double>(type: "float", nullable: false),
                    AfterValue = table.Column<double>(type: "float", nullable: false),
                    CalculationTypeId = table.Column<int>(type: "int", nullable: false),
                    DateTimeCalculated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Logs_CalculationTypes_CalculationTypeId",
                        column: x => x.CalculationTypeId,
                        principalTable: "CalculationTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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

            migrationBuilder.CreateIndex(
                name: "IX_Logs_CalculationTypeId",
                table: "Logs",
                column: "CalculationTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Logs");

            migrationBuilder.DropTable(
                name: "CalculationTypes");
        }
    }
}
