using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiPreferencia.Migrations
{
    /// <inheritdoc />
    public partial class ModifierTableUserColumnUserEmail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "User_email",
                table: "User",
                newName: "UserEmail");

            migrationBuilder.AlterColumn<string>(
                name: "UserEmail",
                table: "User",
                type: "NVARCHAR2(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(2000)");

            migrationBuilder.CreateIndex(
                name: "IX_User_UserEmail",
                table: "User",
                column: "UserEmail",
                unique: true,
                filter: "\"UserEmail\" IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_User_UserEmail",
                table: "User");

            migrationBuilder.RenameColumn(
                name: "UserEmail",
                table: "User",
                newName: "User_email");

            migrationBuilder.AlterColumn<string>(
                name: "User_email",
                table: "User",
                type: "NVARCHAR2(2000)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(450)",
                oldNullable: true);
        }
    }
}
