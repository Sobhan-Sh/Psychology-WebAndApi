using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PC.Context.Migrations
{
    /// <inheritdoc />
    public partial class Change_tblComment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Sender",
                table: "Comments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 29, 1, 29, 10, 3, DateTimeKind.Local).AddTicks(1289));

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 29, 1, 29, 10, 3, DateTimeKind.Local).AddTicks(1293));

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 29, 1, 29, 10, 3, DateTimeKind.Local).AddTicks(1294));

            migrationBuilder.UpdateData(
                table: "PsychologistWorkingDays",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 29, 1, 29, 10, 6, DateTimeKind.Local).AddTicks(503));

            migrationBuilder.UpdateData(
                table: "PsychologistWorkingDays",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 29, 1, 29, 10, 6, DateTimeKind.Local).AddTicks(512));

            migrationBuilder.UpdateData(
                table: "PsychologistWorkingDays",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 29, 1, 29, 10, 6, DateTimeKind.Local).AddTicks(513));

            migrationBuilder.UpdateData(
                table: "PsychologistWorkingDays",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 29, 1, 29, 10, 6, DateTimeKind.Local).AddTicks(514));

            migrationBuilder.UpdateData(
                table: "PsychologistWorkingDays",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 29, 1, 29, 10, 6, DateTimeKind.Local).AddTicks(515));

            migrationBuilder.UpdateData(
                table: "PsychologistWorkingDays",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 29, 1, 29, 10, 6, DateTimeKind.Local).AddTicks(517));

            migrationBuilder.UpdateData(
                table: "PsychologistWorkingDays",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 29, 1, 29, 10, 6, DateTimeKind.Local).AddTicks(518));

            migrationBuilder.UpdateData(
                table: "PsychologistWorkingHours",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2023, 12, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 29, 1, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 29, 1, 29, 10, 6, DateTimeKind.Local).AddTicks(203) });

            migrationBuilder.UpdateData(
                table: "PsychologistWorkingHours",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2023, 12, 29, 1, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 29, 2, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 29, 1, 29, 10, 6, DateTimeKind.Local).AddTicks(209) });

            migrationBuilder.UpdateData(
                table: "PsychologistWorkingHours",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2023, 12, 29, 2, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 29, 3, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 29, 1, 29, 10, 6, DateTimeKind.Local).AddTicks(212) });

            migrationBuilder.UpdateData(
                table: "PsychologistWorkingHours",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2023, 12, 29, 3, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 29, 4, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 29, 1, 29, 10, 6, DateTimeKind.Local).AddTicks(215) });

            migrationBuilder.UpdateData(
                table: "PsychologistWorkingHours",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2023, 12, 29, 4, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 29, 5, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 29, 1, 29, 10, 6, DateTimeKind.Local).AddTicks(218) });

            migrationBuilder.UpdateData(
                table: "PsychologistWorkingHours",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2023, 12, 29, 5, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 29, 6, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 29, 1, 29, 10, 6, DateTimeKind.Local).AddTicks(294) });

            migrationBuilder.UpdateData(
                table: "PsychologistWorkingHours",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2023, 12, 29, 6, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 29, 7, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 29, 1, 29, 10, 6, DateTimeKind.Local).AddTicks(297) });

            migrationBuilder.UpdateData(
                table: "PsychologistWorkingHours",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2023, 12, 29, 7, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 29, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 29, 1, 29, 10, 6, DateTimeKind.Local).AddTicks(300) });

            migrationBuilder.UpdateData(
                table: "PsychologistWorkingHours",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2023, 12, 29, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 29, 9, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 29, 1, 29, 10, 6, DateTimeKind.Local).AddTicks(303) });

            migrationBuilder.UpdateData(
                table: "PsychologistWorkingHours",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2023, 12, 29, 9, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 29, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 29, 1, 29, 10, 6, DateTimeKind.Local).AddTicks(307) });

            migrationBuilder.UpdateData(
                table: "PsychologistWorkingHours",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2023, 12, 29, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 29, 11, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 29, 1, 29, 10, 6, DateTimeKind.Local).AddTicks(310) });

            migrationBuilder.UpdateData(
                table: "PsychologistWorkingHours",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2023, 12, 29, 11, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 29, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 29, 1, 29, 10, 6, DateTimeKind.Local).AddTicks(313) });

            migrationBuilder.UpdateData(
                table: "PsychologistWorkingHours",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2023, 12, 29, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 29, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 29, 1, 29, 10, 6, DateTimeKind.Local).AddTicks(316) });

            migrationBuilder.UpdateData(
                table: "PsychologistWorkingHours",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2023, 12, 29, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 29, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 29, 1, 29, 10, 6, DateTimeKind.Local).AddTicks(319) });

            migrationBuilder.UpdateData(
                table: "PsychologistWorkingHours",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedAt", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2023, 12, 29, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 29, 15, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 29, 1, 29, 10, 6, DateTimeKind.Local).AddTicks(322) });

            migrationBuilder.UpdateData(
                table: "PsychologistWorkingHours",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedAt", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2023, 12, 29, 15, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 29, 16, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 29, 1, 29, 10, 6, DateTimeKind.Local).AddTicks(325) });

            migrationBuilder.UpdateData(
                table: "PsychologistWorkingHours",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedAt", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2023, 12, 29, 16, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 29, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 29, 1, 29, 10, 6, DateTimeKind.Local).AddTicks(328) });

            migrationBuilder.UpdateData(
                table: "PsychologistWorkingHours",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CreatedAt", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2023, 12, 29, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 29, 18, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 29, 1, 29, 10, 6, DateTimeKind.Local).AddTicks(331) });

            migrationBuilder.UpdateData(
                table: "PsychologistWorkingHours",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CreatedAt", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2023, 12, 29, 18, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 29, 19, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 29, 1, 29, 10, 6, DateTimeKind.Local).AddTicks(334) });

            migrationBuilder.UpdateData(
                table: "PsychologistWorkingHours",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedAt", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2023, 12, 29, 19, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 29, 20, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 29, 1, 29, 10, 6, DateTimeKind.Local).AddTicks(337) });

            migrationBuilder.UpdateData(
                table: "PsychologistWorkingHours",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "CreatedAt", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2023, 12, 29, 20, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 29, 21, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 29, 1, 29, 10, 6, DateTimeKind.Local).AddTicks(340) });

            migrationBuilder.UpdateData(
                table: "PsychologistWorkingHours",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "CreatedAt", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2023, 12, 29, 21, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 29, 22, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 29, 1, 29, 10, 6, DateTimeKind.Local).AddTicks(343) });

            migrationBuilder.UpdateData(
                table: "PsychologistWorkingHours",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "CreatedAt", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2023, 12, 29, 22, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 29, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 29, 1, 29, 10, 6, DateTimeKind.Local).AddTicks(346) });

            migrationBuilder.UpdateData(
                table: "PsychologistWorkingHours",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "CreatedAt", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2023, 12, 29, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 29, 1, 29, 10, 6, DateTimeKind.Local).AddTicks(349) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 29, 1, 29, 10, 3, DateTimeKind.Local).AddTicks(1223));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 29, 1, 29, 10, 3, DateTimeKind.Local).AddTicks(1235));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 29, 1, 29, 10, 3, DateTimeKind.Local).AddTicks(1237));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 29, 1, 29, 10, 3, DateTimeKind.Local).AddTicks(1238));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ActivationCode", "CreatedAt", "Password" },
                values: new object[] { "6b2b0293-4f98-49fd-bb5a-6db80a982f69", new DateTime(2023, 12, 29, 1, 29, 10, 6, DateTimeKind.Local).AddTicks(23), "AQAAAAEAACcQAAAAEE9rw45wxMYB+O/EmA0FsCgDzCZEuYbcfU7A6kos+ZKCr/kuSpfSENKdi+yqRW9NVQ==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Sender",
                table: "Comments");

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 25, 10, 53, 7, 140, DateTimeKind.Local).AddTicks(4225));

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 25, 10, 53, 7, 140, DateTimeKind.Local).AddTicks(4228));

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 25, 10, 53, 7, 140, DateTimeKind.Local).AddTicks(4229));

            migrationBuilder.UpdateData(
                table: "PsychologistWorkingDays",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 25, 10, 53, 7, 142, DateTimeKind.Local).AddTicks(7186));

            migrationBuilder.UpdateData(
                table: "PsychologistWorkingDays",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 25, 10, 53, 7, 142, DateTimeKind.Local).AddTicks(7192));

            migrationBuilder.UpdateData(
                table: "PsychologistWorkingDays",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 25, 10, 53, 7, 142, DateTimeKind.Local).AddTicks(7193));

            migrationBuilder.UpdateData(
                table: "PsychologistWorkingDays",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 25, 10, 53, 7, 142, DateTimeKind.Local).AddTicks(7194));

            migrationBuilder.UpdateData(
                table: "PsychologistWorkingDays",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 25, 10, 53, 7, 142, DateTimeKind.Local).AddTicks(7195));

            migrationBuilder.UpdateData(
                table: "PsychologistWorkingDays",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 25, 10, 53, 7, 142, DateTimeKind.Local).AddTicks(7197));

            migrationBuilder.UpdateData(
                table: "PsychologistWorkingDays",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 25, 10, 53, 7, 142, DateTimeKind.Local).AddTicks(7197));

            migrationBuilder.UpdateData(
                table: "PsychologistWorkingHours",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2023, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 25, 1, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 25, 10, 53, 7, 142, DateTimeKind.Local).AddTicks(6790) });

            migrationBuilder.UpdateData(
                table: "PsychologistWorkingHours",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2023, 12, 25, 1, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 25, 2, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 25, 10, 53, 7, 142, DateTimeKind.Local).AddTicks(6794) });

            migrationBuilder.UpdateData(
                table: "PsychologistWorkingHours",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2023, 12, 25, 2, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 25, 3, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 25, 10, 53, 7, 142, DateTimeKind.Local).AddTicks(6798) });

            migrationBuilder.UpdateData(
                table: "PsychologistWorkingHours",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2023, 12, 25, 3, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 25, 4, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 25, 10, 53, 7, 142, DateTimeKind.Local).AddTicks(6800) });

            migrationBuilder.UpdateData(
                table: "PsychologistWorkingHours",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2023, 12, 25, 4, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 25, 5, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 25, 10, 53, 7, 142, DateTimeKind.Local).AddTicks(6803) });

            migrationBuilder.UpdateData(
                table: "PsychologistWorkingHours",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2023, 12, 25, 5, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 25, 6, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 25, 10, 53, 7, 142, DateTimeKind.Local).AddTicks(6817) });

            migrationBuilder.UpdateData(
                table: "PsychologistWorkingHours",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2023, 12, 25, 6, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 25, 7, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 25, 10, 53, 7, 142, DateTimeKind.Local).AddTicks(6820) });

            migrationBuilder.UpdateData(
                table: "PsychologistWorkingHours",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2023, 12, 25, 7, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 25, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 25, 10, 53, 7, 142, DateTimeKind.Local).AddTicks(6823) });

            migrationBuilder.UpdateData(
                table: "PsychologistWorkingHours",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2023, 12, 25, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 25, 9, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 25, 10, 53, 7, 142, DateTimeKind.Local).AddTicks(6826) });

            migrationBuilder.UpdateData(
                table: "PsychologistWorkingHours",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2023, 12, 25, 9, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 25, 10, 53, 7, 142, DateTimeKind.Local).AddTicks(6829) });

            migrationBuilder.UpdateData(
                table: "PsychologistWorkingHours",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2023, 12, 25, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 25, 11, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 25, 10, 53, 7, 142, DateTimeKind.Local).AddTicks(6832) });

            migrationBuilder.UpdateData(
                table: "PsychologistWorkingHours",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2023, 12, 25, 11, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 25, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 25, 10, 53, 7, 142, DateTimeKind.Local).AddTicks(6835) });

            migrationBuilder.UpdateData(
                table: "PsychologistWorkingHours",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2023, 12, 25, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 25, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 25, 10, 53, 7, 142, DateTimeKind.Local).AddTicks(6838) });

            migrationBuilder.UpdateData(
                table: "PsychologistWorkingHours",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2023, 12, 25, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 25, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 25, 10, 53, 7, 142, DateTimeKind.Local).AddTicks(6897) });

            migrationBuilder.UpdateData(
                table: "PsychologistWorkingHours",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedAt", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2023, 12, 25, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 25, 15, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 25, 10, 53, 7, 142, DateTimeKind.Local).AddTicks(6900) });

            migrationBuilder.UpdateData(
                table: "PsychologistWorkingHours",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedAt", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2023, 12, 25, 15, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 25, 16, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 25, 10, 53, 7, 142, DateTimeKind.Local).AddTicks(6902) });

            migrationBuilder.UpdateData(
                table: "PsychologistWorkingHours",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedAt", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2023, 12, 25, 16, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 25, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 25, 10, 53, 7, 142, DateTimeKind.Local).AddTicks(6905) });

            migrationBuilder.UpdateData(
                table: "PsychologistWorkingHours",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CreatedAt", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2023, 12, 25, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 25, 18, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 25, 10, 53, 7, 142, DateTimeKind.Local).AddTicks(6909) });

            migrationBuilder.UpdateData(
                table: "PsychologistWorkingHours",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CreatedAt", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2023, 12, 25, 18, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 25, 19, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 25, 10, 53, 7, 142, DateTimeKind.Local).AddTicks(6911) });

            migrationBuilder.UpdateData(
                table: "PsychologistWorkingHours",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedAt", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2023, 12, 25, 19, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 25, 20, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 25, 10, 53, 7, 142, DateTimeKind.Local).AddTicks(6914) });

            migrationBuilder.UpdateData(
                table: "PsychologistWorkingHours",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "CreatedAt", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2023, 12, 25, 20, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 25, 21, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 25, 10, 53, 7, 142, DateTimeKind.Local).AddTicks(6917) });

            migrationBuilder.UpdateData(
                table: "PsychologistWorkingHours",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "CreatedAt", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2023, 12, 25, 21, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 25, 22, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 25, 10, 53, 7, 142, DateTimeKind.Local).AddTicks(6919) });

            migrationBuilder.UpdateData(
                table: "PsychologistWorkingHours",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "CreatedAt", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2023, 12, 25, 22, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 25, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 25, 10, 53, 7, 142, DateTimeKind.Local).AddTicks(6922) });

            migrationBuilder.UpdateData(
                table: "PsychologistWorkingHours",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "CreatedAt", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2023, 12, 25, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 25, 10, 53, 7, 142, DateTimeKind.Local).AddTicks(6924) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 25, 10, 53, 7, 140, DateTimeKind.Local).AddTicks(4179));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 25, 10, 53, 7, 140, DateTimeKind.Local).AddTicks(4186));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 25, 10, 53, 7, 140, DateTimeKind.Local).AddTicks(4187));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 25, 10, 53, 7, 140, DateTimeKind.Local).AddTicks(4189));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ActivationCode", "CreatedAt", "Password" },
                values: new object[] { "7124626f-30d5-47d1-bcdc-6ea36177ecea", new DateTime(2023, 12, 25, 10, 53, 7, 142, DateTimeKind.Local).AddTicks(6525), "AQAAAAEAACcQAAAAEKAusIjJ2SfSH4QOulby4WfRX0Xhf1D66O28v9Uw2xNEu9c0cNK/JQId4pj7sxPbCA==" });
        }
    }
}
