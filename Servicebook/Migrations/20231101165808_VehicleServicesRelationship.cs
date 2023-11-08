using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Servicebook.Migrations
{
    /// <inheritdoc />
    public partial class VehicleServicesRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Services_VehicleId",
                table: "Services",
                column: "VehicleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Services_Vehicles_VehicleId",
                table: "Services",
                column: "VehicleId",
                principalTable: "Vehicles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Services_Vehicles_VehicleId",
                table: "Services");

            migrationBuilder.DropIndex(
                name: "IX_Services_VehicleId",
                table: "Services");
        }
    }
}
