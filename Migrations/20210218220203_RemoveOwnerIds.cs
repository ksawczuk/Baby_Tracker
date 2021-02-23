using Microsoft.EntityFrameworkCore.Migrations;

namespace Baby_Tracker.Migrations
{
    public partial class RemoveOwnerIds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OwnerId1",
                table: "Sleep",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OwnerId2",
                table: "Sleep",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OwnerId3",
                table: "Sleep",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OwnerId1",
                table: "Intervention",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OwnerId2",
                table: "Intervention",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OwnerId3",
                table: "Intervention",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OwnerId1",
                table: "Feed",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OwnerId2",
                table: "Feed",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OwnerId3",
                table: "Feed",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);
        }
    }
}
