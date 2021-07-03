using Microsoft.EntityFrameworkCore.Migrations;

namespace Veterinary_Clinic_Test.Migrations
{
    public partial class alter_Diagnosis : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Diagnoses",
                newName: "ProductionDate");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProductionDate",
                table: "Diagnoses",
                newName: "Date");
        }
    }
}
