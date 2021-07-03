using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Veterinary_Clinic_Test.Migrations
{
    public partial class alter_Diagnosis_deleteDateTime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductionDate",
                table: "Diagnoses");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ProductionDate",
                table: "Diagnoses",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
