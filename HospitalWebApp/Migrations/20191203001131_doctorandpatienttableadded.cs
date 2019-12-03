using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HospitalWebApp.Migrations
{
    public partial class doctorandpatienttableadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    DoctorId = table.Column<int>(nullable: false),
                    DoctorName = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.DoctorId);
                });

            migrationBuilder.CreateTable(
                name: "OutPatients",
                columns: table => new
                {
                    OutPatientId = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    PatientId = table.Column<int>(nullable: false),
                    DoctorId = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Fees = table.Column<double>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    PaymentStatus = table.Column<string>(nullable: false),
                    CreateOperator = table.Column<string>(nullable: true),
                    UpdateOperator = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OutPatients", x => x.OutPatientId);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    PatientId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Address = table.Column<string>(maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.PatientId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Doctors");

            migrationBuilder.DropTable(
                name: "OutPatients");

            migrationBuilder.DropTable(
                name: "Patients");
        }
    }
}
