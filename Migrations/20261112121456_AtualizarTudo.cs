using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoPortfolio.Migrations
{
    /// <inheritdoc />
    public partial class AtualizarTudo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AreaAtuacaoExperiencia",
                table: "Alunos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FerramentasConhece",
                table: "Alunos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "HabilidadesCertificados",
                table: "Alunos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SobreAluno",
                table: "Alunos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TecnologiasConhecidas",
                table: "Alunos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AreaAtuacaoExperiencia",
                table: "Alunos");

            migrationBuilder.DropColumn(
                name: "FerramentasConhece",
                table: "Alunos");

            migrationBuilder.DropColumn(
                name: "HabilidadesCertificados",
                table: "Alunos");

            migrationBuilder.DropColumn(
                name: "SobreAluno",
                table: "Alunos");

            migrationBuilder.DropColumn(
                name: "TecnologiasConhecidas",
                table: "Alunos");
        }
    }
}
