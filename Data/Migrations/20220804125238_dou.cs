using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GP.Data.Migrations
{
    public partial class dou : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dossier",
                columns: table => new
                {
                    CIN = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomPatient = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrenomPatient = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Maladies = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dossier", x => x.CIN);
                });

            migrationBuilder.CreateTable(
                name: "Medecins",
                columns: table => new
                {
                    MedecinId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodeMedecin = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NomMedecin = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Specialite = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medecins", x => x.MedecinId);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    PatientId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DossierMedicalFK = table.Column<int>(type: "int", nullable: false),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prenom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DatedeNaissaonce = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ville = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    adress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    sexe = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tele = table.Column<long>(type: "bigint", nullable: false),
                    mail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DossierCIN = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.PatientId);
                    table.ForeignKey(
                        name: "FK_Patients_Dossier_DossierCIN",
                        column: x => x.DossierCIN,
                        principalTable: "Dossier",
                        principalColumn: "CIN",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Consultations",
                columns: table => new
                {
                    CodeConsultation = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Prenom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RendezVous = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Motif = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MedecinFK = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PatientFK = table.Column<int>(type: "int", nullable: false),
                    PatientsPatientId = table.Column<int>(type: "int", nullable: true),
                    MedecinsMedecinId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consultations", x => x.CodeConsultation);
                    table.ForeignKey(
                        name: "FK_Consultations_Medecins_MedecinsMedecinId",
                        column: x => x.MedecinsMedecinId,
                        principalTable: "Medecins",
                        principalColumn: "MedecinId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Consultations_Patients_PatientsPatientId",
                        column: x => x.PatientsPatientId,
                        principalTable: "Patients",
                        principalColumn: "PatientId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Consultations_MedecinsMedecinId",
                table: "Consultations",
                column: "MedecinsMedecinId");

            migrationBuilder.CreateIndex(
                name: "IX_Consultations_PatientsPatientId",
                table: "Consultations",
                column: "PatientsPatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_DossierCIN",
                table: "Patients",
                column: "DossierCIN");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Consultations");

            migrationBuilder.DropTable(
                name: "Medecins");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "Dossier");
        }
    }
}
