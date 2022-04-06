using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DentalApps.API.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tenants",
                columns: table => new
                {
                    TenantID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TenantName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TenantStatus = table.Column<int>(type: "int", nullable: false),
                    JoinDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tenants", x => x.TenantID);
                });

            migrationBuilder.CreateTable(
                name: "TreatmentCategories",
                columns: table => new
                {
                    TreatmentCategoryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TreatmentName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TreatmentCategories", x => x.TreatmentCategoryID);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TenantID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    Birthdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MobilePhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JoinDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeID);
                    table.ForeignKey(
                        name: "FK_Employees_Tenants_TenantID",
                        column: x => x.TenantID,
                        principalTable: "Tenants",
                        principalColumn: "TenantID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    PatientID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TenantID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MRNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    Birthdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MobilePhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BPJSNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JoinDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.PatientID);
                    table.ForeignKey(
                        name: "FK_Patients_Tenants_TenantID",
                        column: x => x.TenantID,
                        principalTable: "Tenants",
                        principalColumn: "TenantID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubTreatmentCategories",
                columns: table => new
                {
                    SubTreatmentCategoryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TreatmentCategoryID = table.Column<int>(type: "int", nullable: false),
                    SubTreatmentCategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DefaultPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubTreatmentCategories", x => x.SubTreatmentCategoryID);
                    table.ForeignKey(
                        name: "FK_SubTreatmentCategories_TreatmentCategories_TreatmentCategoryID",
                        column: x => x.TreatmentCategoryID,
                        principalTable: "TreatmentCategories",
                        principalColumn: "TreatmentCategoryID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DoctorSchedules",
                columns: table => new
                {
                    DoctorScheduleID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BeginDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorSchedules", x => x.DoctorScheduleID);
                    table.ForeignKey(
                        name: "FK_DoctorSchedules_Employees_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "Employees",
                        principalColumn: "EmployeeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Treatments",
                columns: table => new
                {
                    TreatmentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EmployeeID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Anamnesis = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Diagnosis = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Recipe = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TreatmentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TenantID = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Treatments", x => x.TreatmentID);
                    table.ForeignKey(
                        name: "FK_Treatments_Employees_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "Employees",
                        principalColumn: "EmployeeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Treatments_Patients_PatientID",
                        column: x => x.PatientID,
                        principalTable: "Patients",
                        principalColumn: "PatientID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Treatments_Tenants_TenantID",
                        column: x => x.TenantID,
                        principalTable: "Tenants",
                        principalColumn: "TenantID");
                });

            migrationBuilder.CreateTable(
                name: "RegisterSchedules",
                columns: table => new
                {
                    ScheduleID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoctorScheduleID = table.Column<int>(type: "int", nullable: false),
                    PatientID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegisterSchedules", x => x.ScheduleID);
                    table.ForeignKey(
                        name: "FK_RegisterSchedules_DoctorSchedules_DoctorScheduleID",
                        column: x => x.DoctorScheduleID,
                        principalTable: "DoctorSchedules",
                        principalColumn: "DoctorScheduleID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RegisterSchedules_Patients_PatientID",
                        column: x => x.PatientID,
                        principalTable: "Patients",
                        principalColumn: "PatientID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SubTreatments",
                columns: table => new
                {
                    SubTreatmentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubTreatmentCategoryID = table.Column<int>(type: "int", nullable: false),
                    TreatmentID = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Position = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubTreatments", x => x.SubTreatmentID);
                    table.ForeignKey(
                        name: "FK_SubTreatments_Treatments_TreatmentID",
                        column: x => x.TreatmentID,
                        principalTable: "Treatments",
                        principalColumn: "TreatmentID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DoctorSchedules_EmployeeID",
                table: "DoctorSchedules",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_TenantID",
                table: "Employees",
                column: "TenantID");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_TenantID",
                table: "Patients",
                column: "TenantID");

            migrationBuilder.CreateIndex(
                name: "IX_RegisterSchedules_DoctorScheduleID",
                table: "RegisterSchedules",
                column: "DoctorScheduleID");

            migrationBuilder.CreateIndex(
                name: "IX_RegisterSchedules_PatientID",
                table: "RegisterSchedules",
                column: "PatientID");

            migrationBuilder.CreateIndex(
                name: "IX_SubTreatmentCategories_TreatmentCategoryID",
                table: "SubTreatmentCategories",
                column: "TreatmentCategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_SubTreatments_TreatmentID",
                table: "SubTreatments",
                column: "TreatmentID");

            migrationBuilder.CreateIndex(
                name: "IX_Treatments_EmployeeID",
                table: "Treatments",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_Treatments_PatientID",
                table: "Treatments",
                column: "PatientID");

            migrationBuilder.CreateIndex(
                name: "IX_Treatments_TenantID",
                table: "Treatments",
                column: "TenantID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RegisterSchedules");

            migrationBuilder.DropTable(
                name: "SubTreatmentCategories");

            migrationBuilder.DropTable(
                name: "SubTreatments");

            migrationBuilder.DropTable(
                name: "DoctorSchedules");

            migrationBuilder.DropTable(
                name: "TreatmentCategories");

            migrationBuilder.DropTable(
                name: "Treatments");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "Tenants");
        }
    }
}
