using Microsoft.EntityFrameworkCore.Migrations;

namespace Baby_Tracker.Migrations
{
    public partial class OwnerIds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OwnerId1",
                table: "Sleep",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OwnerId2",
                table: "Sleep",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OwnerId3",
                table: "Sleep",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OwnerId1",
                table: "Intervention",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OwnerId2",
                table: "Intervention",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OwnerId3",
                table: "Intervention",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OwnerId1",
                table: "Feed",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OwnerId2",
                table: "Feed",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OwnerId3",
                table: "Feed",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OwnerId1",
                table: "Sleep");

            migrationBuilder.DropColumn(
                name: "OwnerId2",
                table: "Sleep");

            migrationBuilder.DropColumn(
                name: "OwnerId3",
                table: "Sleep");

            migrationBuilder.DropColumn(
                name: "OwnerId1",
                table: "Intervention");

            migrationBuilder.DropColumn(
                name: "OwnerId2",
                table: "Intervention");

            migrationBuilder.DropColumn(
                name: "OwnerId3",
                table: "Intervention");

            migrationBuilder.DropColumn(
                name: "OwnerId1",
                table: "Feed");

            migrationBuilder.DropColumn(
                name: "OwnerId2",
                table: "Feed");

            migrationBuilder.DropColumn(
                name: "OwnerId3",
                table: "Feed");
        }
    }
}
