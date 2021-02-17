using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Baby_Tracker.Migrations
{
    public partial class AddIntervention : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Intervention_Sleep_SleepId",
                table: "Intervention");

            migrationBuilder.AlterColumn<Guid>(
                name: "SleepId",
                table: "Intervention",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Intervention_Sleep_SleepId",
                table: "Intervention",
                column: "SleepId",
                principalTable: "Sleep",
                principalColumn: "SleepId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Intervention_Sleep_SleepId",
                table: "Intervention");

            migrationBuilder.AlterColumn<Guid>(
                name: "SleepId",
                table: "Intervention",
                type: "char(36)",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddForeignKey(
                name: "FK_Intervention_Sleep_SleepId",
                table: "Intervention",
                column: "SleepId",
                principalTable: "Sleep",
                principalColumn: "SleepId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
