using Microsoft.EntityFrameworkCore.Migrations;

namespace Veterinary_Clinic_Test.Migrations
{
    public partial class alter_Animal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Animals_Doctors_DoctorId",
                table: "Animals");

            migrationBuilder.AddColumn<int>(
                name: "DoctorId1",
                table: "Animals",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Animals_DoctorId1",
                table: "Animals",
                column: "DoctorId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Animals_Doctors_DoctorId",
                table: "Animals",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Animals_Doctors_DoctorId1",
                table: "Animals",
                column: "DoctorId1",
                principalTable: "Doctors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Animals_Doctors_DoctorId",
                table: "Animals");

            migrationBuilder.DropForeignKey(
                name: "FK_Animals_Doctors_DoctorId1",
                table: "Animals");

            migrationBuilder.DropIndex(
                name: "IX_Animals_DoctorId1",
                table: "Animals");

            migrationBuilder.DropColumn(
                name: "DoctorId1",
                table: "Animals");

            migrationBuilder.AddForeignKey(
                name: "FK_Animals_Doctors_DoctorId",
                table: "Animals",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
