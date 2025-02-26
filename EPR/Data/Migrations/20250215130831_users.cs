using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EPR.Data.Migrations
{
    /// <inheritdoc />
    public partial class users : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "18fa8db1-ff9d-4eb0-a333-bad766024062", null, "Applicant", "APPLICANT" },
                    { "eaddeb3d-dcbf-423c-9e40-3d9a0f1e7dba", null, "HR", "HR" },
                    { "fa7093d6-e5b9-48ce-aea3-df6b3d1b7839", null, "Employee", "EMPLOYEE" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "b5197a51-c458-46ba-b85a-3404ac3e9f51", 0, "b9dae7f7-41c1-4185-bfad-bd262c01c5b9", "admin@epr.com", true, false, null, "ADMIN@EPR.COM", "ADMIN@EPR.COM", "AQAAAAIAAYagAAAAEIAoPXqEjXZRpAyPAiCCMROO2sqh74QIC7rPraHrlsXpwcGDDXYVYP8gLrHsE0qFbA==", null, false, "55ed9d7c-4ec4-45b6-96b8-6d2250d96250", false, "admin@epr.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "eaddeb3d-dcbf-423c-9e40-3d9a0f1e7dba", "b5197a51-c458-46ba-b85a-3404ac3e9f51" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "18fa8db1-ff9d-4eb0-a333-bad766024062");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fa7093d6-e5b9-48ce-aea3-df6b3d1b7839");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "eaddeb3d-dcbf-423c-9e40-3d9a0f1e7dba", "b5197a51-c458-46ba-b85a-3404ac3e9f51" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eaddeb3d-dcbf-423c-9e40-3d9a0f1e7dba");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b5197a51-c458-46ba-b85a-3404ac3e9f51");
        }
    }
}
