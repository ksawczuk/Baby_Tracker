using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Baby_Tracker.Migrations.ApplicationDb
{
    public partial class InitialAppDbMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Baby",
                columns: table => new
                {
                    BabyId = table.Column<Guid>(nullable: false),
                    OwnerId1 = table.Column<string>(nullable: false),
                    OwnerId2 = table.Column<string>(nullable: true),
                    OwnerId3 = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Nickname = table.Column<string>(nullable: true),
                    ImageFileName = table.Column<string>(nullable: true),
                    Weight = table.Column<double>(nullable: false),
                    Height = table.Column<double>(nullable: false),
                    DateAdded = table.Column<DateTime>(nullable: false),
                    BirthDateTime = table.Column<DateTime>(nullable: false),
                    BirthWeight = table.Column<double>(nullable: false),
                    BirthHeight = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Baby", x => x.BabyId);
                });

            migrationBuilder.CreateTable(
                name: "Sleep",
                columns: table => new
                {
                    SleepId = table.Column<Guid>(nullable: false),
                    BabyId = table.Column<Guid>(nullable: false),
                    StartTime = table.Column<DateTime>(nullable: false),
                    EndTime = table.Column<DateTime>(nullable: false),
                    SleepSummary = table.Column<int>(nullable: false),
                    IsNap = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sleep", x => x.SleepId);
                    table.ForeignKey(
                        name: "FK_Sleep_Baby_BabyId",
                        column: x => x.BabyId,
                        principalTable: "Baby",
                        principalColumn: "BabyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Feed",
                columns: table => new
                {
                    FeedId = table.Column<Guid>(nullable: false),
                    BabyId = table.Column<Guid>(nullable: false),
                    SleepId = table.Column<Guid>(nullable: true),
                    StartTime = table.Column<DateTime>(nullable: false),
                    EndTime = table.Column<DateTime>(nullable: false),
                    LatchQuality = table.Column<int>(nullable: false),
                    ChinEngagement = table.Column<int>(nullable: false),
                    Alertness = table.Column<int>(nullable: false),
                    Fussiness = table.Column<int>(nullable: false),
                    FeedSummary = table.Column<int>(nullable: false),
                    IsDreamFeed = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feed", x => x.FeedId);
                    table.ForeignKey(
                        name: "FK_Feed_Baby_BabyId",
                        column: x => x.BabyId,
                        principalTable: "Baby",
                        principalColumn: "BabyId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Feed_Sleep_SleepId",
                        column: x => x.SleepId,
                        principalTable: "Sleep",
                        principalColumn: "SleepId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Intervention",
                columns: table => new
                {
                    InterventionId = table.Column<Guid>(nullable: false),
                    StartTime = table.Column<DateTime>(nullable: false),
                    EndTime = table.Column<DateTime>(nullable: false),
                    FirstTry = table.Column<int>(nullable: false),
                    SecondTry = table.Column<int>(nullable: false),
                    ThirdTry = table.Column<int>(nullable: false),
                    FourthTry = table.Column<int>(nullable: false),
                    InterventionSummary = table.Column<int>(nullable: false),
                    SleepId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Intervention", x => x.InterventionId);
                    table.ForeignKey(
                        name: "FK_Intervention_Sleep_SleepId",
                        column: x => x.SleepId,
                        principalTable: "Sleep",
                        principalColumn: "SleepId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Feed_BabyId",
                table: "Feed",
                column: "BabyId");

            migrationBuilder.CreateIndex(
                name: "IX_Feed_SleepId",
                table: "Feed",
                column: "SleepId");

            migrationBuilder.CreateIndex(
                name: "IX_Intervention_SleepId",
                table: "Intervention",
                column: "SleepId");

            migrationBuilder.CreateIndex(
                name: "IX_Sleep_BabyId",
                table: "Sleep",
                column: "BabyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Feed");

            migrationBuilder.DropTable(
                name: "Intervention");

            migrationBuilder.DropTable(
                name: "Sleep");

            migrationBuilder.DropTable(
                name: "Baby");
        }
    }
}
