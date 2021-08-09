using Microsoft.EntityFrameworkCore.Migrations;

namespace MetricCalculator.Web.Migrations
{
    public partial class LinkCalculationTypeToCalculate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Logs");

            migrationBuilder.AddColumn<int>(
                name: "CalculationTypeId",
                table: "Logs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Logs_CalculationTypeId",
                table: "Logs",
                column: "CalculationTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Logs_CalculationTypes_CalculationTypeId",
                table: "Logs",
                column: "CalculationTypeId",
                principalTable: "CalculationTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Logs_CalculationTypes_CalculationTypeId",
                table: "Logs");

            migrationBuilder.DropIndex(
                name: "IX_Logs_CalculationTypeId",
                table: "Logs");

            migrationBuilder.DropColumn(
                name: "CalculationTypeId",
                table: "Logs");

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Logs",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
