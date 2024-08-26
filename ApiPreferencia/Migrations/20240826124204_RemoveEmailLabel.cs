using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiPreferencia.Migrations
{
    /// <inheritdoc />
    public partial class RemoveEmailLabel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmailLabels");

            migrationBuilder.DropTable(
                name: "EmailModel");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmailModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Body = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    Email = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    Subject = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    Title = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmailLabels",
                columns: table => new
                {
                    EmailId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    LabelId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailLabels", x => new { x.EmailId, x.LabelId });
                    table.ForeignKey(
                        name: "FK_EmailLabels_EmailModel_EmailId",
                        column: x => x.EmailId,
                        principalTable: "EmailModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmailLabels_Label_LabelId",
                        column: x => x.LabelId,
                        principalTable: "Label",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmailLabels_LabelId",
                table: "EmailLabels",
                column: "LabelId");
        }
    }
}
