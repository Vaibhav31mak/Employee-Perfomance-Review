using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EPR.Data.Migrations
{
    /// <inheritdoc />
    public partial class Applicants : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Applicants_Designations_DesignationId",
                table: "Applicants");

            migrationBuilder.DropTable(
                name: "Interviewees");

            migrationBuilder.DropIndex(
                name: "IX_Applicants_DesignationId",
                table: "Applicants");

            migrationBuilder.DropColumn(
                name: "DesignationId",
                table: "Applicants");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Applicants",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Applicants",
                newName: "MiddleName");

            migrationBuilder.RenameColumn(
                name: "ResumePath",
                table: "Applicants",
                newName: "EmailAddress");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Applicants",
                newName: "Designation");

            migrationBuilder.RenameColumn(
                name: "ApplicationDate",
                table: "Applicants",
                newName: "DateOfBirth");

            migrationBuilder.AlterColumn<int>(
                name: "PhoneNumber",
                table: "Applicants",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Applicants",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Applicants",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Resume",
                table: "Applicants",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Applicants");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "Applicants");

            migrationBuilder.DropColumn(
                name: "Resume",
                table: "Applicants");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Applicants",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "MiddleName",
                table: "Applicants",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "EmailAddress",
                table: "Applicants",
                newName: "ResumePath");

            migrationBuilder.RenameColumn(
                name: "Designation",
                table: "Applicants",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "DateOfBirth",
                table: "Applicants",
                newName: "ApplicationDate");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Applicants",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "DesignationId",
                table: "Applicants",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Interviewees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicantId = table.Column<int>(type: "int", nullable: false),
                    InterviewDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Interviewer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Result = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interviewees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Interviewees_Applicants_ApplicantId",
                        column: x => x.ApplicantId,
                        principalTable: "Applicants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Applicants_DesignationId",
                table: "Applicants",
                column: "DesignationId");

            migrationBuilder.CreateIndex(
                name: "IX_Interviewees_ApplicantId",
                table: "Interviewees",
                column: "ApplicantId");

            migrationBuilder.AddForeignKey(
                name: "FK_Applicants_Designations_DesignationId",
                table: "Applicants",
                column: "DesignationId",
                principalTable: "Designations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
