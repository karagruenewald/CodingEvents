using Microsoft.EntityFrameworkCore.Migrations;

namespace CodingEvents.Migrations
{
    public partial class EventContactMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContactEmail",
                table: "Events");

            migrationBuilder.AddColumn<int>(
                name: "ContactId",
                table: "Events",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Events_ContactId",
                table: "Events",
                column: "ContactId");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Contacts_ContactId",
                table: "Events",
                column: "ContactId",
                principalTable: "Contacts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_Contacts_ContactId",
                table: "Events");

            migrationBuilder.DropIndex(
                name: "IX_Events_ContactId",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "ContactId",
                table: "Events");

            migrationBuilder.AddColumn<string>(
                name: "ContactEmail",
                table: "Events",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);
        }
    }
}
