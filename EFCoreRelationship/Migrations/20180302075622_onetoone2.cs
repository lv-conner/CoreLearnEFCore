using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace EFCoreRelationship.Migrations
{
    public partial class onetoone2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "StudentInfoId",
                table: "User",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "StudentInfo",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    StudentNumber = table.Column<string>(maxLength: 50, nullable: true),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentInfo", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_User_StudentInfoId",
                table: "User",
                column: "StudentInfoId",
                unique: true,
                filter: "[StudentInfoId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_User_StudentInfo_StudentInfoId",
                table: "User",
                column: "StudentInfoId",
                principalTable: "StudentInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_StudentInfo_StudentInfoId",
                table: "User");

            migrationBuilder.DropTable(
                name: "StudentInfo");

            migrationBuilder.DropIndex(
                name: "IX_User_StudentInfoId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "StudentInfoId",
                table: "User");
        }
    }
}
