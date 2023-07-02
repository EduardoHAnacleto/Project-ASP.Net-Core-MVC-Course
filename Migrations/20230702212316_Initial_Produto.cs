using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebProjectCourse.Migrations
{
    /// <inheritdoc />
    public partial class Initial_Produto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ISBN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Autor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ListaPreco = table.Column<double>(type: "float", nullable: false),
                    Preco = table.Column<double>(type: "float", nullable: false),
                    Preco50 = table.Column<double>(type: "float", nullable: false),
                    Preco100 = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Produtos",
                columns: new[] { "Id", "Autor", "Descricao", "ISBN", "ListaPreco", "Preco", "Preco100", "Preco50", "Titulo" },
                values: new object[,]
                {
                    { 1, "John Wick", "Dont hurt the dog", "ABC1234567", 40.0, 30.0, 20.0, 25.0, "The Continental" },
                    { 2, "Anakin Skywalker", "The dark force awakens", "ATT8798789", 20.0, 15.0, 8.0, 10.0, "Star Wars Tale" },
                    { 3, "Soldado Ryan", "Pistola contra um tanque", "XZY46846", 45.0, 30.0, 24.0, 28.0, "Segunda Guerra Mundial" },
                    { 4, "Maximus Decimus Meridius", "Eu terei minha vingança", "AEC656454", 50.0, 30.0, 20.0, 25.0, "Imperio Romano" },
                    { 5, "Miriam Smith", "Viva ao imperador", "WH40000", 60.0, 40.0, 30.0, 35.0, "WarHammer 40000" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Produtos");
        }
    }
}
