using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace shirtPactice.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Shirts",
                columns: table => new
                {
                    shirtId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    shirtName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    shirtDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    size = table.Column<int>(type: "int", nullable: true),
                    shirtModel = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shirts", x => x.shirtId);
                });

            migrationBuilder.InsertData(
                table: "Shirts",
                columns: new[] { "shirtId", "gender", "shirtDescription", "shirtModel", "shirtName", "size" },
                values: new object[,]
                {
                    { 1, "Male", "A casual t-shirt", "Model A", "T-Shirt", 42 },
                    { 2, "Female", "A formal polo shirt", "Model B", "Polo Shirt", 38 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Shirts");
        }
    }
}
