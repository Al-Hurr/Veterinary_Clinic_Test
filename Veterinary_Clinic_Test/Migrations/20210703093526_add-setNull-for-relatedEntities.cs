using Microsoft.EntityFrameworkCore.Migrations;

namespace Veterinary_Clinic_Test.Migrations
{
    public partial class addsetNullforrelatedEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Animals_Diagnoses_DiagnosisId",
                table: "Animals");

            migrationBuilder.DropForeignKey(
                name: "FK_Animals_Owners_OwnerId",
                table: "Animals");

            migrationBuilder.DropForeignKey(
                name: "FK_Vaccinations_Animals_AnimalId",
                table: "Vaccinations");

            migrationBuilder.DropForeignKey(
                name: "FK_Vaccinations_Diagnoses_DiagnosisId",
                table: "Vaccinations");

            migrationBuilder.AddForeignKey(
                name: "FK_Animals_Diagnoses_DiagnosisId",
                table: "Animals",
                column: "DiagnosisId",
                principalTable: "Diagnoses",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Animals_Owners_OwnerId",
                table: "Animals",
                column: "OwnerId",
                principalTable: "Owners",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Vaccinations_Animals_AnimalId",
                table: "Vaccinations",
                column: "AnimalId",
                principalTable: "Animals",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Vaccinations_Diagnoses_DiagnosisId",
                table: "Vaccinations",
                column: "DiagnosisId",
                principalTable: "Diagnoses",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Animals_Diagnoses_DiagnosisId",
                table: "Animals");

            migrationBuilder.DropForeignKey(
                name: "FK_Animals_Owners_OwnerId",
                table: "Animals");

            migrationBuilder.DropForeignKey(
                name: "FK_Vaccinations_Animals_AnimalId",
                table: "Vaccinations");

            migrationBuilder.DropForeignKey(
                name: "FK_Vaccinations_Diagnoses_DiagnosisId",
                table: "Vaccinations");

            migrationBuilder.AddForeignKey(
                name: "FK_Animals_Diagnoses_DiagnosisId",
                table: "Animals",
                column: "DiagnosisId",
                principalTable: "Diagnoses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Animals_Owners_OwnerId",
                table: "Animals",
                column: "OwnerId",
                principalTable: "Owners",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Vaccinations_Animals_AnimalId",
                table: "Vaccinations",
                column: "AnimalId",
                principalTable: "Animals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Vaccinations_Diagnoses_DiagnosisId",
                table: "Vaccinations",
                column: "DiagnosisId",
                principalTable: "Diagnoses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
