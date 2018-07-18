using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace P01_HospitalDatabase.Migrations
{
    public partial class _5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Diagnoses_Patients_PatientId",
                table: "Diagnoses");

            migrationBuilder.DropForeignKey(
                name: "FK_Visitations_Patients_PatientId",
                table: "Visitations");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Visitations",
                type: "DATETIME2",
                nullable: false,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<bool>(
                name: "HasInsurance",
                table: "Patients",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool));

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Patients",
                unicode: false,
                maxLength: 80,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 80);

            migrationBuilder.CreateTable(
                name: "Medicaments",
                columns: table => new
                {
                    MedicamentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicaments", x => x.MedicamentId);
                });

            migrationBuilder.CreateTable(
                name: "Perscriptions",
                columns: table => new
                {
                    PatientId = table.Column<int>(nullable: false),
                    MedicamentId = table.Column<int>(nullable: false),
                    MedicamentId1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Perscriptions", x => new { x.PatientId, x.MedicamentId });
                    table.ForeignKey(
                        name: "FK_PatientsMedicaments_Medicaments",
                        column: x => x.MedicamentId,
                        principalTable: "Patients",
                        principalColumn: "PatientId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Perscriptions_Medicaments_MedicamentId1",
                        column: x => x.MedicamentId1,
                        principalTable: "Medicaments",
                        principalColumn: "MedicamentId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Perscriptions_MedicamentId",
                table: "Perscriptions",
                column: "MedicamentId");

            migrationBuilder.CreateIndex(
                name: "IX_Perscriptions_MedicamentId1",
                table: "Perscriptions",
                column: "MedicamentId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Diagnoses_Patients",
                table: "Diagnoses",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "PatientId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Visitation_Patients",
                table: "Visitations",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "PatientId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Diagnoses_Patients",
                table: "Diagnoses");

            migrationBuilder.DropForeignKey(
                name: "FK_Visitation_Patients",
                table: "Visitations");

            migrationBuilder.DropTable(
                name: "Perscriptions");

            migrationBuilder.DropTable(
                name: "Medicaments");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Visitations",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "DATETIME2",
                oldDefaultValueSql: "GETDATE()");

            migrationBuilder.AlterColumn<bool>(
                name: "HasInsurance",
                table: "Patients",
                nullable: false,
                oldClrType: typeof(bool),
                oldDefaultValue: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Patients",
                maxLength: 80,
                nullable: false,
                oldClrType: typeof(string),
                oldUnicode: false,
                oldMaxLength: 80,
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Diagnoses_Patients_PatientId",
                table: "Diagnoses",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "PatientId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Visitations_Patients_PatientId",
                table: "Visitations",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "PatientId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
