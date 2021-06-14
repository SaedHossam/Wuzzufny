using Microsoft.EntityFrameworkCore.Migrations;

namespace GlassDoor.Migrations
{
    public partial class appJobId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Applications_Jobs_JobId",
                table: "Applications");

            migrationBuilder.RenameColumn(
                name: "JobId",
                table: "Applications",
                newName: "jobId");

            migrationBuilder.RenameIndex(
                name: "IX_Applications_JobId",
                table: "Applications",
                newName: "IX_Applications_jobId");

            migrationBuilder.AlterColumn<int>(
                name: "jobId",
                table: "Applications",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_Jobs_jobId",
                table: "Applications",
                column: "jobId",
                principalTable: "Jobs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Applications_Jobs_jobId",
                table: "Applications");

            migrationBuilder.RenameColumn(
                name: "jobId",
                table: "Applications",
                newName: "JobId");

            migrationBuilder.RenameIndex(
                name: "IX_Applications_jobId",
                table: "Applications",
                newName: "IX_Applications_JobId");

            migrationBuilder.AlterColumn<int>(
                name: "JobId",
                table: "Applications",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_Jobs_JobId",
                table: "Applications",
                column: "JobId",
                principalTable: "Jobs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
