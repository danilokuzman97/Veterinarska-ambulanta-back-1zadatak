using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Exam.App.Migrations
{
    /// <inheritdoc />
    public partial class DodavanjeExaminationEntiteta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patients_PetSpecies_AnimalSpeciesId",
                table: "Patients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PetSpecies",
                table: "PetSpecies");

            migrationBuilder.RenameTable(
                name: "PetSpecies",
                newName: "AnimalSpecies");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AnimalSpecies",
                table: "AnimalSpecies",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Examination",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PatientId = table.Column<int>(type: "integer", nullable: false),
                    VetId = table.Column<string>(type: "text", nullable: false),
                    StartTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Examination", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Examination_AspNetUsers_VetId",
                        column: x => x.VetId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Examination_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Examination_PatientId",
                table: "Examination",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Examination_VetId",
                table: "Examination",
                column: "VetId");

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_AnimalSpecies_AnimalSpeciesId",
                table: "Patients",
                column: "AnimalSpeciesId",
                principalTable: "AnimalSpecies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patients_AnimalSpecies_AnimalSpeciesId",
                table: "Patients");

            migrationBuilder.DropTable(
                name: "Examination");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AnimalSpecies",
                table: "AnimalSpecies");

            migrationBuilder.RenameTable(
                name: "AnimalSpecies",
                newName: "PetSpecies");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PetSpecies",
                table: "PetSpecies",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_PetSpecies_AnimalSpeciesId",
                table: "Patients",
                column: "AnimalSpeciesId",
                principalTable: "PetSpecies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
