using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CarRentalManagement.Server.Data.Migrations
{
    public partial class AddedDefaultDataAndUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "ad2bcf0c-20db-474f-8407-5a6b159518ba", "fa609894-4bfb-453e-aa1f-23fe50b0c9a4", "Administrator", "ADMINISTRATOR" },
                    { "bd2bcf0c-20db-474f-8407-5a6b159518bb", "b294cb0f-0828-430b-9deb-60100ea7c4c3", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "3781efa7-66dc-47f0-860f-e506d04102e4", 0, "ffd759da-bd1c-4b8a-881c-9d477b7a6732", "admin@localhost.com", false, "Admin", "User", false, null, "ADMIN@LOCALHOST.COM", "ADMIN", "AQAAAAEAACcQAAAAEKmeJYhQUeXTY6WAVkNfdBl5MsFLT08x5O4jOlJFbi+f/azCIKBULx+nOX6bNZSveQ==", null, false, "889d19c9-7ad7-4d2a-8785-2216488863ec", false, "Admin" });

            migrationBuilder.InsertData(
                table: "Colours",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "DateUpdated", "Name", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, "System", new DateTime(2021, 11, 23, 11, 23, 27, 747, DateTimeKind.Local).AddTicks(735), new DateTime(2021, 11, 23, 11, 23, 27, 751, DateTimeKind.Local).AddTicks(1831), "Black", "System" },
                    { 2, "System", new DateTime(2021, 11, 23, 11, 23, 27, 751, DateTimeKind.Local).AddTicks(3054), new DateTime(2021, 11, 23, 11, 23, 27, 751, DateTimeKind.Local).AddTicks(3060), "Blue", "System" }
                });

            migrationBuilder.InsertData(
                table: "Makes",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "DateUpdated", "Name", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, "System", new DateTime(2021, 11, 23, 11, 23, 27, 753, DateTimeKind.Local).AddTicks(2962), new DateTime(2021, 11, 23, 11, 23, 27, 753, DateTimeKind.Local).AddTicks(2974), "BMW", "System" },
                    { 2, "System", new DateTime(2021, 11, 23, 11, 23, 27, 753, DateTimeKind.Local).AddTicks(2979), new DateTime(2021, 11, 23, 11, 23, 27, 753, DateTimeKind.Local).AddTicks(2981), "Toyota", "System" }
                });

            migrationBuilder.InsertData(
                table: "Models",
                columns: new[] { "Id", "CreatedBy", "DateCreated", "DateUpdated", "Name", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, "System", new DateTime(2021, 11, 23, 11, 23, 27, 754, DateTimeKind.Local).AddTicks(938), new DateTime(2021, 11, 23, 11, 23, 27, 754, DateTimeKind.Local).AddTicks(944), "3 Series", "System" },
                    { 2, "System", new DateTime(2021, 11, 23, 11, 23, 27, 754, DateTimeKind.Local).AddTicks(948), new DateTime(2021, 11, 23, 11, 23, 27, 754, DateTimeKind.Local).AddTicks(949), "X5", "System" },
                    { 3, "System", new DateTime(2021, 11, 23, 11, 23, 27, 754, DateTimeKind.Local).AddTicks(951), new DateTime(2021, 11, 23, 11, 23, 27, 754, DateTimeKind.Local).AddTicks(952), "Prius", "System" },
                    { 4, "System", new DateTime(2021, 11, 23, 11, 23, 27, 754, DateTimeKind.Local).AddTicks(953), new DateTime(2021, 11, 23, 11, 23, 27, 754, DateTimeKind.Local).AddTicks(954), "Rav4", "System" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "ad2bcf0c-20db-474f-8407-5a6b159518ba", "3781efa7-66dc-47f0-860f-e506d04102e4" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bd2bcf0c-20db-474f-8407-5a6b159518bb");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "ad2bcf0c-20db-474f-8407-5a6b159518ba", "3781efa7-66dc-47f0-860f-e506d04102e4" });

            migrationBuilder.DeleteData(
                table: "Colours",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Colours",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Makes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Makes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Models",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ad2bcf0c-20db-474f-8407-5a6b159518ba");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3781efa7-66dc-47f0-860f-e506d04102e4");

            migrationBuilder.AlterColumn<int>(
                name: "LastName",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
