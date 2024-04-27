using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HomeProject.Migrations
{
    /// <inheritdoc />
    public partial class VehicleAlterationOfTheNameOfTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Auto",
                table: "Auto");

            migrationBuilder.RenameTable(
                name: "Auto",
                newName: "Vehicle");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Vehicle",
                table: "Vehicle",
                column: "VehicleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Vehicle",
                table: "Vehicle");

            migrationBuilder.RenameTable(
                name: "Vehicle",
                newName: "Auto");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Auto",
                table: "Auto",
                column: "VehicleId");
        }
    }
}
