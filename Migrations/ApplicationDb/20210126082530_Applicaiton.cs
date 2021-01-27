using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Baby_Tracker.Migrations.ApplicationDb
{
    public partial class Applicaiton : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Babies",
                columns: table => new
                {
                    BabyId = table.Column<Guid>(nullable: false),
                    OwnerId1 = table.Column<string>(nullable: false),
                    OwnerId2 = table.Column<string>(nullable: true),
                    OwnerId3 = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: false),
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
                    table.PrimaryKey("PK_Babies", x => x.BabyId);
                });

            migrationBuilder.CreateTable(
                name: "Sleeps",
                columns: table => new
                {
                    SleepId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    BabyId = table.Column<int>(nullable: false),
                    StartTime = table.Column<DateTime>(nullable: false),
                    EndTime = table.Column<DateTime>(nullable: false),
                    SleepSummary = table.Column<int>(nullable: false),
                    IsNap = table.Column<bool>(nullable: false),
                    BabyId1 = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sleeps", x => x.SleepId);
                    table.ForeignKey(
                        name: "FK_Sleeps_Babies_BabyId1",
                        column: x => x.BabyId1,
                        principalTable: "Babies",
                        principalColumn: "BabyId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Feeds",
                columns: table => new
                {
                    FeedId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    BabyId = table.Column<int>(nullable: false),
                    SleepId = table.Column<int>(nullable: true),
                    StartTime = table.Column<DateTime>(nullable: false),
                    EndTime = table.Column<DateTime>(nullable: false),
                    LatchQuality = table.Column<int>(nullable: false),
                    ChinEngagement = table.Column<int>(nullable: false),
                    Alertness = table.Column<int>(nullable: false),
                    Fussiness = table.Column<int>(nullable: false),
                    FeedSummary = table.Column<int>(nullable: false),
                    IsDreamFeed = table.Column<bool>(nullable: false),
                    BabyId1 = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feeds", x => x.FeedId);
                    table.ForeignKey(
                        name: "FK_Feeds_Babies_BabyId1",
                        column: x => x.BabyId1,
                        principalTable: "Babies",
                        principalColumn: "BabyId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Feeds_Sleeps_SleepId",
                        column: x => x.SleepId,
                        principalTable: "Sleeps",
                        principalColumn: "SleepId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Intervention",
                columns: table => new
                {
                    InterventionId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    StartTime = table.Column<DateTime>(nullable: false),
                    EndTime = table.Column<DateTime>(nullable: false),
                    FirstTry = table.Column<int>(nullable: false),
                    SecondTry = table.Column<int>(nullable: false),
                    ThirdTry = table.Column<int>(nullable: false),
                    FourthTry = table.Column<int>(nullable: false),
                    InterventionSummary = table.Column<int>(nullable: false),
                    SleepId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Intervention", x => x.InterventionId);
                    table.ForeignKey(
                        name: "FK_Intervention_Sleeps_SleepId",
                        column: x => x.SleepId,
                        principalTable: "Sleeps",
                        principalColumn: "SleepId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Feeds_BabyId1",
                table: "Feeds",
                column: "BabyId1");

            migrationBuilder.CreateIndex(
                name: "IX_Feeds_SleepId",
                table: "Feeds",
                column: "SleepId");

            migrationBuilder.CreateIndex(
                name: "IX_Intervention_SleepId",
                table: "Intervention",
                column: "SleepId");

            migrationBuilder.CreateIndex(
                name: "IX_Sleeps_BabyId1",
                table: "Sleeps",
                column: "BabyId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Feeds");

            migrationBuilder.DropTable(
                name: "Intervention");

            migrationBuilder.DropTable(
                name: "Sleeps");

            migrationBuilder.DropTable(
                name: "Babies");
        }
    }
}
