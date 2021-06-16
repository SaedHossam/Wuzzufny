using Microsoft.EntityFrameworkCore.Migrations;

namespace GlassDoor.Migrations
{
    public partial class companyapplicationstatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CompanyApplicationStatusId",
                table: "Applications",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CompanyApplicationStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyApplicationStatuses", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Applications_CompanyApplicationStatusId",
                table: "Applications",
                column: "CompanyApplicationStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_CompanyApplicationStatuses_CompanyApplicationStatusId",
                table: "Applications",
                column: "CompanyApplicationStatusId",
                principalTable: "CompanyApplicationStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Applications_CompanyApplicationStatuses_CompanyApplicationStatusId",
                table: "Applications");

            migrationBuilder.DropTable(
                name: "CompanyApplicationStatuses");

            migrationBuilder.DropIndex(
                name: "IX_Applications_CompanyApplicationStatusId",
                table: "Applications");

            migrationBuilder.DropColumn(
                name: "CompanyApplicationStatusId",
                table: "Applications");
        }
    }
}
