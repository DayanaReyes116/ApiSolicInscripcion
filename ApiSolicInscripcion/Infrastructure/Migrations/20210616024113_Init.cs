using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiSolicInscripcion.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Solicitud",
                columns: table => new
                {
                    iId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    sName = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    sApellido = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    iIdentificacion = table.Column<int>(type: "INTEGER", nullable: false),
                    iEdad = table.Column<int>(type: "INTEGER", nullable: false),
                    iIdCasa = table.Column<int>(type: "INTEGER", nullable: false),
                    sNameCasa = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Solicitud", x => x.iId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Solicitud");
        }
    }
}
