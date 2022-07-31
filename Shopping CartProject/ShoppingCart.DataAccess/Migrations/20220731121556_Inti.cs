using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShoppingCart.DataAccess.Migrations
{
    public partial class Inti : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CategoriesId",
                table: "products");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoriesId",
                table: "products",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
