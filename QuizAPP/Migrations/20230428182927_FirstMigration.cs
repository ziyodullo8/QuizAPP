using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuizAPP.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Quiz",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Savol = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Javob1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Javob2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tugri_Javob = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quiz", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Quiz");
        }
    }
}
