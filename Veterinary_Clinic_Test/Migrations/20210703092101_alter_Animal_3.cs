using Microsoft.EntityFrameworkCore.Migrations;

namespace Veterinary_Clinic_Test.Migrations
{
    public partial class alter_Animal_3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Diagnoses_Doctors_DoctorId",
                table: "Diagnoses");

            migrationBuilder.DropForeignKey(
                name: "FK_Vaccinations_Doctors_DoctorId",
                table: "Vaccinations");

            migrationBuilder.AddForeignKey(
                name: "FK_Diagnoses_Doctors_DoctorId",
                table: "Diagnoses",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Vaccinations_Doctors_DoctorId",
                table: "Vaccinations",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Diagnoses_Doctors_DoctorId",
                table: "Diagnoses");

            migrationBuilder.DropForeignKey(
                name: "FK_Vaccinations_Doctors_DoctorId",
                table: "Vaccinations");

            migrationBuilder.AddForeignKey(
                name: "FK_Diagnoses_Doctors_DoctorId",
                table: "Diagnoses",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Vaccinations_Doctors_DoctorId",
                table: "Vaccinations",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
