using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GlassDoor.Migrations
{
    public partial class updateAppV2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ArchiveDate",
                table: "Applications");

            migrationBuilder.DropColumn(
                name: "IsArchived",
                table: "Applications");

            migrationBuilder.DropColumn(
                name: "IsViewed",
                table: "Applications");

            migrationBuilder.DropColumn(
                name: "IsWithdrawn",
                table: "Applications");

            migrationBuilder.DropColumn(
                name: "WithDrawDate",
                table: "Applications");

            migrationBuilder.DropColumn(
                name: "WithdrawReason",
                table: "Applications");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ArchiveDate",
                table: "Applications",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsArchived",
                table: "Applications",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsViewed",
                table: "Applications",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsWithdrawn",
                table: "Applications",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "WithDrawDate",
                table: "Applications",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WithdrawReason",
                table: "Applications",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
