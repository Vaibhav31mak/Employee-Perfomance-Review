using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EPR.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSettingsDetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Designation",
                table: "SystemCodes",
                newName: "Description");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Description",
                table: "SystemCodes",
                newName: "Designation");
        }
    }
}
