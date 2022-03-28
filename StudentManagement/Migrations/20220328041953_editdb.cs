using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentManagement.Migrations
{
    public partial class editdb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Classes_ClassId",
                table: "Students");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c26cab89-17d4-41d0-8aa7-d3d377b613e0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cb8c86ce-a912-4764-894b-2b52bc895ab1");

            migrationBuilder.RenameColumn(
                name: "slot",
                table: "Schedules",
                newName: "Slot");

            migrationBuilder.AlterColumn<int>(
                name: "ClassId",
                table: "Students",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3a04dbc8-f210-47eb-8db1-b5b46de0e736", "1c96765d-3ea7-41a2-8a5f-b13dcd655db2", "ADMINSTRATOR", "ADMINSTRATOR" },
                    { "92582bea-7817-4afd-9b9f-228dfdb25078", "0d8f383e-c3d5-4a41-9b1f-68aeedaf9349", "User", "USER" }
                });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2022, 3, 28, 11, 19, 52, 456, DateTimeKind.Local).AddTicks(1964), new DateTime(2022, 3, 28, 11, 19, 52, 456, DateTimeKind.Local).AddTicks(1952) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2022, 3, 28, 11, 19, 52, 456, DateTimeKind.Local).AddTicks(1968), new DateTime(2022, 3, 28, 11, 19, 52, 456, DateTimeKind.Local).AddTicks(1967) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2022, 3, 28, 11, 19, 52, 456, DateTimeKind.Local).AddTicks(1970), new DateTime(2022, 3, 28, 11, 19, 52, 456, DateTimeKind.Local).AddTicks(1970) });

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Classes_ClassId",
                table: "Students",
                column: "ClassId",
                principalTable: "Classes",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Classes_ClassId",
                table: "Students");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3a04dbc8-f210-47eb-8db1-b5b46de0e736");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "92582bea-7817-4afd-9b9f-228dfdb25078");

            migrationBuilder.RenameColumn(
                name: "Slot",
                table: "Schedules",
                newName: "slot");

            migrationBuilder.AlterColumn<int>(
                name: "ClassId",
                table: "Students",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "c26cab89-17d4-41d0-8aa7-d3d377b613e0", "3e0b6692-cb6d-4fb4-acd5-4602da2d9021", "User", "USER" },
                    { "cb8c86ce-a912-4764-894b-2b52bc895ab1", "a366caf9-2e1d-4f2e-b219-7c6801bc1bd3", "ADMINSTRATOR", "ADMINSTRATOR" }
                });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2022, 3, 25, 11, 47, 19, 27, DateTimeKind.Local).AddTicks(5307), new DateTime(2022, 3, 25, 11, 47, 19, 27, DateTimeKind.Local).AddTicks(5295) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2022, 3, 25, 11, 47, 19, 27, DateTimeKind.Local).AddTicks(5311), new DateTime(2022, 3, 25, 11, 47, 19, 27, DateTimeKind.Local).AddTicks(5310) });

            migrationBuilder.UpdateData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreateDate", "UpdateDate" },
                values: new object[] { new DateTime(2022, 3, 25, 11, 47, 19, 27, DateTimeKind.Local).AddTicks(5313), new DateTime(2022, 3, 25, 11, 47, 19, 27, DateTimeKind.Local).AddTicks(5312) });

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Classes_ClassId",
                table: "Students",
                column: "ClassId",
                principalTable: "Classes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
