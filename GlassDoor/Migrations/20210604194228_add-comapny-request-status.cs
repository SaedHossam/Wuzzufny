using Microsoft.EntityFrameworkCore.Migrations;

namespace GlassDoor.Migrations
{
    public partial class addcomapnyrequeststatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompanyManagers_Companies_CompanyId",
                table: "CompanyManagers");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Companies");

            migrationBuilder.AlterColumn<int>(
                name: "CompanyId",
                table: "CompanyManagers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "CompanyManagers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RequestStatusId",
                table: "Companies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "CompanyRequestStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyRequestStatus", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Companies_RequestStatusId",
                table: "Companies",
                column: "RequestStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_CompanyRequestStatus_RequestStatusId",
                table: "Companies",
                column: "RequestStatusId",
                principalTable: "CompanyRequestStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyManagers_Companies_CompanyId",
                table: "CompanyManagers",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Companies_CompanyRequestStatus_RequestStatusId",
                table: "Companies");

            migrationBuilder.DropForeignKey(
                name: "FK_CompanyManagers_Companies_CompanyId",
                table: "CompanyManagers");

            migrationBuilder.DropTable(
                name: "CompanyRequestStatus");

            migrationBuilder.DropIndex(
                name: "IX_Companies_RequestStatusId",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "CompanyManagers");

            migrationBuilder.DropColumn(
                name: "RequestStatusId",
                table: "Companies");

            migrationBuilder.AlterColumn<int>(
                name: "CompanyId",
                table: "CompanyManagers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Companies",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyManagers_Companies_CompanyId",
                table: "CompanyManagers",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
