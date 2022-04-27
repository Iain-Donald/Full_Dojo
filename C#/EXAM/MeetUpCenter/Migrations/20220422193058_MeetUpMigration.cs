using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MeetUpCenter.Migrations
{
    public partial class MeetUpMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MeetUps",
                columns: table => new
                {
                    MeetUpID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(nullable: false),
                    dateAndTime = table.Column<string>(nullable: false),
                    duration = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeetUps", x => x.MeetUpID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    userID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(nullable: false),
                    email = table.Column<string>(nullable: false),
                    password = table.Column<string>(nullable: false),
                    createdAt = table.Column<DateTime>(nullable: false),
                    updatedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.userID);
                });

            migrationBuilder.CreateTable(
                name: "MeetUpsJoined",
                columns: table => new
                {
                    meetUpJoinedID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    meetUpID_J = table.Column<int>(nullable: false),
                    MeetUpID = table.Column<int>(nullable: true),
                    userID_J = table.Column<int>(nullable: false),
                    userID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeetUpsJoined", x => x.meetUpJoinedID);
                    table.ForeignKey(
                        name: "FK_MeetUpsJoined_MeetUps_MeetUpID",
                        column: x => x.MeetUpID,
                        principalTable: "MeetUps",
                        principalColumn: "MeetUpID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MeetUpsJoined_Users_userID",
                        column: x => x.userID,
                        principalTable: "Users",
                        principalColumn: "userID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MeetUpsJoined_MeetUpID",
                table: "MeetUpsJoined",
                column: "MeetUpID");

            migrationBuilder.CreateIndex(
                name: "IX_MeetUpsJoined_userID",
                table: "MeetUpsJoined",
                column: "userID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MeetUpsJoined");

            migrationBuilder.DropTable(
                name: "MeetUps");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
