using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CzytelnikAplikacjaProjekt.Migrations
{
    /// <inheritdoc />
    public partial class Init3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Bookstore");

            migrationBuilder.CreateTable(
                name: "Reader",
                schema: "Bookstore",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reader", x => x.Id);
                });

            
                

           
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Book",
                schema: "Bookstore");

            migrationBuilder.DropTable(
                name: "Order",
                schema: "Bookstore");

            migrationBuilder.DropTable(
                name: "Reader",
                schema: "Bookstore");
        }
    }
}
