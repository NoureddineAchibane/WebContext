using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebContext.Migrations
{
    public partial class initial3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Etudiants",
                columns: table => new
                {
                    EtudiantId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prenom = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Etudiants", x => x.EtudiantId);
                });

            migrationBuilder.InsertData(
                table: "Etudiants",
                columns: new[] { "EtudiantId", "Name", "Prenom" },
                values: new object[] { 1, "Achibane", "Noureddine" });

            migrationBuilder.InsertData(
                table: "Etudiants",
                columns: new[] { "EtudiantId", "Name", "Prenom" },
                values: new object[] { 2, "Labrag", "Hassan" });

            migrationBuilder.InsertData(
                table: "Etudiants",
                columns: new[] { "EtudiantId", "Name", "Prenom" },
                values: new object[] { 3, "Yeah", "Mouad" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Etudiants");
        }
    }
}
