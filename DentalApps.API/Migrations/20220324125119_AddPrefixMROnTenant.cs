using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DentalApps.API.Migrations
{
    public partial class AddPrefixMROnTenant : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Treatments_Tenants_TenantID",
                table: "Treatments");

            migrationBuilder.DropIndex(
                name: "IX_Treatments_TenantID",
                table: "Treatments");

            migrationBuilder.DropColumn(
                name: "TenantID",
                table: "Treatments");

            migrationBuilder.DropColumn(
                name: "MRNumber",
                table: "Patients");

            migrationBuilder.AddColumn<string>(
                name: "PrefixMR",
                table: "Tenants",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MedicalRecordNumber",
                table: "Patients",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_MedicalRecordNumber",
                table: "Patients",
                column: "MedicalRecordNumber",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Patients_MedicalRecordNumber",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "PrefixMR",
                table: "Tenants");

            migrationBuilder.DropColumn(
                name: "MedicalRecordNumber",
                table: "Patients");

            migrationBuilder.AddColumn<string>(
                name: "TenantID",
                table: "Treatments",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MRNumber",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Treatments_TenantID",
                table: "Treatments",
                column: "TenantID");

            migrationBuilder.AddForeignKey(
                name: "FK_Treatments_Tenants_TenantID",
                table: "Treatments",
                column: "TenantID",
                principalTable: "Tenants",
                principalColumn: "TenantID");
        }
    }
}
