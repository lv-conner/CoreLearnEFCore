using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace EFCoreRelationship.Migrations
{
    public partial class onetoone3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_StudentInfo_StudentInfoId",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_StudentInfoId",
                table: "User");

            migrationBuilder.AlterColumn<Guid>(
                name: "StudentInfoId",
                table: "User",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_StudentInfoId",
                table: "User",
                column: "StudentInfoId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_User_StudentInfo_StudentInfoId",
                table: "User",
                column: "StudentInfoId",
                principalTable: "StudentInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_StudentInfo_StudentInfoId",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_StudentInfoId",
                table: "User");

            migrationBuilder.AlterColumn<Guid>(
                name: "StudentInfoId",
                table: "User",
                nullable: true,
                oldClrType: typeof(Guid));

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
    }
}
