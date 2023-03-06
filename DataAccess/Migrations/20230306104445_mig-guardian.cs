using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class migguardian : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SurName2",
                table: "Guardians",
                newName: "GuardianSurName2");

            migrationBuilder.RenameColumn(
                name: "SurName",
                table: "Guardians",
                newName: "GuardianSurName");

            migrationBuilder.RenameColumn(
                name: "Phone2",
                table: "Guardians",
                newName: "GuardianPhone2");

            migrationBuilder.RenameColumn(
                name: "Phone",
                table: "Guardians",
                newName: "GuardianPhone");

            migrationBuilder.RenameColumn(
                name: "Name2",
                table: "Guardians",
                newName: "GuardianName2");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Guardians",
                newName: "GuardianName");

            migrationBuilder.RenameColumn(
                name: "Condition",
                table: "Guardians",
                newName: "GuardianCondition");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "GuardianSurName2",
                table: "Guardians",
                newName: "SurName2");

            migrationBuilder.RenameColumn(
                name: "GuardianSurName",
                table: "Guardians",
                newName: "SurName");

            migrationBuilder.RenameColumn(
                name: "GuardianPhone2",
                table: "Guardians",
                newName: "Phone2");

            migrationBuilder.RenameColumn(
                name: "GuardianPhone",
                table: "Guardians",
                newName: "Phone");

            migrationBuilder.RenameColumn(
                name: "GuardianName2",
                table: "Guardians",
                newName: "Name2");

            migrationBuilder.RenameColumn(
                name: "GuardianName",
                table: "Guardians",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "GuardianCondition",
                table: "Guardians",
                newName: "Condition");
        }
    }
}
