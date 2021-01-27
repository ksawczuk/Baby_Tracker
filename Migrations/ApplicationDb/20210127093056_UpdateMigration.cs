using Microsoft.EntityFrameworkCore.Migrations;

namespace Baby_Tracker.Migrations.ApplicationDb
{
    public partial class UpdateMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Feeds_Babies_BabyId1",
                table: "Feeds");

            migrationBuilder.DropForeignKey(
                name: "FK_Feeds_Sleeps_SleepId",
                table: "Feeds");

            migrationBuilder.DropForeignKey(
                name: "FK_Intervention_Sleeps_SleepId",
                table: "Intervention");

            migrationBuilder.DropForeignKey(
                name: "FK_Sleeps_Babies_BabyId1",
                table: "Sleeps");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sleeps",
                table: "Sleeps");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Feeds",
                table: "Feeds");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Babies",
                table: "Babies");

            migrationBuilder.RenameTable(
                name: "Sleeps",
                newName: "Sleep");

            migrationBuilder.RenameTable(
                name: "Feeds",
                newName: "Feed");

            migrationBuilder.RenameTable(
                name: "Babies",
                newName: "Baby");

            migrationBuilder.RenameIndex(
                name: "IX_Sleeps_BabyId1",
                table: "Sleep",
                newName: "IX_Sleep_BabyId1");

            migrationBuilder.RenameIndex(
                name: "IX_Feeds_SleepId",
                table: "Feed",
                newName: "IX_Feed_SleepId");

            migrationBuilder.RenameIndex(
                name: "IX_Feeds_BabyId1",
                table: "Feed",
                newName: "IX_Feed_BabyId1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sleep",
                table: "Sleep",
                column: "SleepId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Feed",
                table: "Feed",
                column: "FeedId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Baby",
                table: "Baby",
                column: "BabyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Feed_Baby_BabyId1",
                table: "Feed",
                column: "BabyId1",
                principalTable: "Baby",
                principalColumn: "BabyId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Feed_Sleep_SleepId",
                table: "Feed",
                column: "SleepId",
                principalTable: "Sleep",
                principalColumn: "SleepId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Intervention_Sleep_SleepId",
                table: "Intervention",
                column: "SleepId",
                principalTable: "Sleep",
                principalColumn: "SleepId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Sleep_Baby_BabyId1",
                table: "Sleep",
                column: "BabyId1",
                principalTable: "Baby",
                principalColumn: "BabyId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Feed_Baby_BabyId1",
                table: "Feed");

            migrationBuilder.DropForeignKey(
                name: "FK_Feed_Sleep_SleepId",
                table: "Feed");

            migrationBuilder.DropForeignKey(
                name: "FK_Intervention_Sleep_SleepId",
                table: "Intervention");

            migrationBuilder.DropForeignKey(
                name: "FK_Sleep_Baby_BabyId1",
                table: "Sleep");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sleep",
                table: "Sleep");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Feed",
                table: "Feed");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Baby",
                table: "Baby");

            migrationBuilder.RenameTable(
                name: "Sleep",
                newName: "Sleeps");

            migrationBuilder.RenameTable(
                name: "Feed",
                newName: "Feeds");

            migrationBuilder.RenameTable(
                name: "Baby",
                newName: "Babies");

            migrationBuilder.RenameIndex(
                name: "IX_Sleep_BabyId1",
                table: "Sleeps",
                newName: "IX_Sleeps_BabyId1");

            migrationBuilder.RenameIndex(
                name: "IX_Feed_SleepId",
                table: "Feeds",
                newName: "IX_Feeds_SleepId");

            migrationBuilder.RenameIndex(
                name: "IX_Feed_BabyId1",
                table: "Feeds",
                newName: "IX_Feeds_BabyId1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sleeps",
                table: "Sleeps",
                column: "SleepId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Feeds",
                table: "Feeds",
                column: "FeedId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Babies",
                table: "Babies",
                column: "BabyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Feeds_Babies_BabyId1",
                table: "Feeds",
                column: "BabyId1",
                principalTable: "Babies",
                principalColumn: "BabyId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Feeds_Sleeps_SleepId",
                table: "Feeds",
                column: "SleepId",
                principalTable: "Sleeps",
                principalColumn: "SleepId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Intervention_Sleeps_SleepId",
                table: "Intervention",
                column: "SleepId",
                principalTable: "Sleeps",
                principalColumn: "SleepId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Sleeps_Babies_BabyId1",
                table: "Sleeps",
                column: "BabyId1",
                principalTable: "Babies",
                principalColumn: "BabyId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
