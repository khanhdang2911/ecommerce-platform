using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecommerce_website.Migrations
{
    /// <inheritdoc />
    public partial class addLinkImage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "linkImage",
                table: "Product",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "linkImage",
                table: "Product");
        }
    }
}
