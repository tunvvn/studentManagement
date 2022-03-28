using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentManagement.Migrations
{
    public partial class xxx : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "20033862-9838-4779-8005-03367e8ab106");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a07cc7de-c2f5-4ea3-bdd6-f7ccf0dfa68d");

            migrationBuilder.DropColumn(
                name: "ClassId",
                table: "Subjects");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "c26cab89-17d4-41d0-8aa7-d3d377b613e0", "3e0b6692-cb6d-4fb4-acd5-4602da2d9021", "User", "USER" },
                    { "cb8c86ce-a912-4764-894b-2b52bc895ab1", "a366caf9-2e1d-4f2e-b219-7c6801bc1bd3", "ADMINSTRATOR", "ADMINSTRATOR" }
                });

            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "Id", "Block", "CreateBy", "CreateDate", "Name", "Semester", "SlotPerWeek", "UpdateBy", "UpdateDate" },
                values: new object[,]
                {
                    { 1, 12, 1, new DateTime(2022, 3, 25, 11, 47, 19, 27, DateTimeKind.Local).AddTicks(5307), "Toan", "1", 6, 1, new DateTime(2022, 3, 25, 11, 47, 19, 27, DateTimeKind.Local).AddTicks(5295) },
                    { 2, 12, 1, new DateTime(2022, 3, 25, 11, 47, 19, 27, DateTimeKind.Local).AddTicks(5311), "Ly", "1", 3, 1, new DateTime(2022, 3, 25, 11, 47, 19, 27, DateTimeKind.Local).AddTicks(5310) },
                    { 3, 11, 1, new DateTime(2022, 3, 25, 11, 47, 19, 27, DateTimeKind.Local).AddTicks(5313), "hoa", "1", 3, 1, new DateTime(2022, 3, 25, 11, 47, 19, 27, DateTimeKind.Local).AddTicks(5312) }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c26cab89-17d4-41d0-8aa7-d3d377b613e0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cb8c86ce-a912-4764-894b-2b52bc895ab1");

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.AddColumn<int>(
                name: "ClassId",
                table: "Subjects",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "20033862-9838-4779-8005-03367e8ab106", "24e95c7d-7d32-4884-89a2-751d05536e84", "ADMINSTRATOR", "ADMINSTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a07cc7de-c2f5-4ea3-bdd6-f7ccf0dfa68d", "df92a4b1-d3fa-4f80-a91e-6f168a1a76eb", "User", "USER" });
        }
    }
}
