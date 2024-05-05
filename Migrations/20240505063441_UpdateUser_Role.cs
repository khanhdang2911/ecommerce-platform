using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecommerce_website.Migrations
{
    /// <inheritdoc />
    public partial class UpdateUser_Role : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserRole");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "PassWord",
                table: "Users",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "UserAddress",
                table: "Users",
                newName: "Phone");

            migrationBuilder.CreateTable(
                name: "UsersRole",
                columns: table => new
                {
                    UsersId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersRole", x => new { x.RoleId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_UsersRole_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsersRole_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UsersRole_UsersId",
                table: "UsersRole",
                column: "UsersId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UsersRole");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Users",
                newName: "PassWord");

            migrationBuilder.RenameColumn(
                name: "Phone",
                table: "Users",
                newName: "UserAddress");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "UserRole",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole", x => new { x.RoleId, x.UserId });
                });
        }
    }
}
