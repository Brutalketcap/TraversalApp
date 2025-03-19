using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig_add_commnet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Commnets_Destinations_DestinationID1",
                table: "Commnets");

            migrationBuilder.DropIndex(
                name: "IX_Commnets_DestinationID1",
                table: "Commnets");

            migrationBuilder.DropColumn(
                name: "DestinationID1",
                table: "Commnets");

            migrationBuilder.AlterColumn<int>(
                name: "DestinationID",
                table: "Commnets",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<bool>(
                name: "CommentState",
                table: "Commnets",
                type: "bit",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CommentDate",
                table: "Commnets",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Commnets_DestinationID",
                table: "Commnets",
                column: "DestinationID");

            migrationBuilder.AddForeignKey(
                name: "FK_Commnets_Destinations_DestinationID",
                table: "Commnets",
                column: "DestinationID",
                principalTable: "Destinations",
                principalColumn: "DestinationID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Commnets_Destinations_DestinationID",
                table: "Commnets");

            migrationBuilder.DropIndex(
                name: "IX_Commnets_DestinationID",
                table: "Commnets");

            migrationBuilder.AlterColumn<string>(
                name: "DestinationID",
                table: "Commnets",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "CommentState",
                table: "Commnets",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<string>(
                name: "CommentDate",
                table: "Commnets",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<int>(
                name: "DestinationID1",
                table: "Commnets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Commnets_DestinationID1",
                table: "Commnets",
                column: "DestinationID1");

            migrationBuilder.AddForeignKey(
                name: "FK_Commnets_Destinations_DestinationID1",
                table: "Commnets",
                column: "DestinationID1",
                principalTable: "Destinations",
                principalColumn: "DestinationID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
