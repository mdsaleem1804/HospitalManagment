using Microsoft.EntityFrameworkCore.Migrations;

namespace HospitalWebApp.Migrations
{
    public partial class patient_fk_added : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_OutPatients_PatientId",
                table: "OutPatients",
                column: "PatientId");

            migrationBuilder.AddForeignKey(
                name: "FK_OutPatients_Patients_PatientId",
                table: "OutPatients",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "PatientId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OutPatients_Patients_PatientId",
                table: "OutPatients");

            migrationBuilder.DropIndex(
                name: "IX_OutPatients_PatientId",
                table: "OutPatients");
        }
    }
}
