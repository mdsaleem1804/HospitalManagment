using Microsoft.EntityFrameworkCore.Migrations;

namespace HospitalWebApp.Migrations
{
    public partial class addcasetypefk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_OutPatients_CaseTypeId",
                table: "OutPatients",
                column: "CaseTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_OutPatients_CaseTypes_CaseTypeId",
                table: "OutPatients",
                column: "CaseTypeId",
                principalTable: "CaseTypes",
                principalColumn: "CaseTypeId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OutPatients_CaseTypes_CaseTypeId",
                table: "OutPatients");

            migrationBuilder.DropIndex(
                name: "IX_OutPatients_CaseTypeId",
                table: "OutPatients");
        }
    }
}
