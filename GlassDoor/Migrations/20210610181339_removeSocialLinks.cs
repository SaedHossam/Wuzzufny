using Microsoft.EntityFrameworkCore.Migrations;

namespace GlassDoor.Migrations
{
    public partial class removeSocialLinks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SocialLinks_Companies_CompanyId",
                table: "SocialLinks");

            migrationBuilder.DropForeignKey(
                name: "FK_SocialLinks_Employees_EmployeeId",
                table: "SocialLinks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SocialLinks",
                table: "SocialLinks");

            migrationBuilder.DropIndex(
                name: "IX_SocialLinks_CompanyId",
                table: "SocialLinks");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "SocialLinks");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "SocialLinks");

            migrationBuilder.RenameTable(
                name: "SocialLinks",
                newName: "EmployeeLinks");

            migrationBuilder.RenameIndex(
                name: "IX_SocialLinks_EmployeeId",
                table: "EmployeeLinks",
                newName: "IX_EmployeeLinks_EmployeeId");

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeId",
                table: "EmployeeLinks",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeeLinks",
                table: "EmployeeLinks",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "CompanyLinks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Link = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyLinks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompanyLinks_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CompanyLinks_CompanyId",
                table: "CompanyLinks",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeLinks_Employees_EmployeeId",
                table: "EmployeeLinks",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeLinks_Employees_EmployeeId",
                table: "EmployeeLinks");

            migrationBuilder.DropTable(
                name: "CompanyLinks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeeLinks",
                table: "EmployeeLinks");

            migrationBuilder.RenameTable(
                name: "EmployeeLinks",
                newName: "SocialLinks");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeLinks_EmployeeId",
                table: "SocialLinks",
                newName: "IX_SocialLinks_EmployeeId");

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeId",
                table: "SocialLinks",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                table: "SocialLinks",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "SocialLinks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SocialLinks",
                table: "SocialLinks",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_SocialLinks_CompanyId",
                table: "SocialLinks",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_SocialLinks_Companies_CompanyId",
                table: "SocialLinks",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SocialLinks_Employees_EmployeeId",
                table: "SocialLinks",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
