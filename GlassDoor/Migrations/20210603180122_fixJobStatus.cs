using Microsoft.EntityFrameworkCore.Migrations;

namespace GlassDoor.Migrations
{
    public partial class fixJobStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_JobStatuses_JobStatusId",
                table: "Jobs");

            migrationBuilder.DropTable(
                name: "JobStatuses");

            migrationBuilder.DropIndex(
                name: "IX_Jobs_JobStatusId",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "JobStatusId",
                table: "Jobs");

            migrationBuilder.AddColumn<bool>(
                name: "IsOpen",
                table: "Jobs",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Companies",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsOpen",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Companies");

            migrationBuilder.AddColumn<int>(
                name: "JobStatusId",
                table: "Jobs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "JobStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobStatuses", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_JobStatusId",
                table: "Jobs",
                column: "JobStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Jobs_JobStatuses_JobStatusId",
                table: "Jobs",
                column: "JobStatusId",
                principalTable: "JobStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
