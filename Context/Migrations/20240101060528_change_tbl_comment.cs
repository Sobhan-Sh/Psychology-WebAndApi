using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PC.Context.Migrations
{
    /// <inheritdoc />
    public partial class change_tbl_comment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsVisit",
                table: "Comments",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 1, 9, 35, 28, 477, DateTimeKind.Local).AddTicks(5578));

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 1, 9, 35, 28, 477, DateTimeKind.Local).AddTicks(5582));

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 1, 9, 35, 28, 477, DateTimeKind.Local).AddTicks(5584));

            migrationBuilder.UpdateData(
                table: "PsychologistWorkingDays",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 1, 9, 35, 28, 479, DateTimeKind.Local).AddTicks(673));

            migrationBuilder.UpdateData(
                table: "PsychologistWorkingDays",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 1, 9, 35, 28, 479, DateTimeKind.Local).AddTicks(679));

            migrationBuilder.UpdateData(
                table: "PsychologistWorkingDays",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 1, 9, 35, 28, 479, DateTimeKind.Local).AddTicks(680));

            migrationBuilder.UpdateData(
                table: "PsychologistWorkingDays",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 1, 9, 35, 28, 479, DateTimeKind.Local).AddTicks(681));

            migrationBuilder.UpdateData(
                table: "PsychologistWorkingDays",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 1, 9, 35, 28, 479, DateTimeKind.Local).AddTicks(681));

            migrationBuilder.UpdateData(
                table: "PsychologistWorkingDays",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 1, 9, 35, 28, 479, DateTimeKind.Local).AddTicks(683));

            migrationBuilder.UpdateData(
                table: "PsychologistWorkingDays",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 1, 9, 35, 28, 479, DateTimeKind.Local).AddTicks(684));

            migrationBuilder.UpdateData(
                table: "PsychologistWorkingHours",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 1, 1, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 1, 9, 35, 28, 479, DateTimeKind.Local).AddTicks(501) });

            migrationBuilder.UpdateData(
                table: "PsychologistWorkingHours",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2024, 1, 1, 1, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 1, 2, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 1, 9, 35, 28, 479, DateTimeKind.Local).AddTicks(507) });

            migrationBuilder.UpdateData(
                table: "PsychologistWorkingHours",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2024, 1, 1, 2, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 1, 3, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 1, 9, 35, 28, 479, DateTimeKind.Local).AddTicks(512) });

            migrationBuilder.UpdateData(
                table: "PsychologistWorkingHours",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2024, 1, 1, 3, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 1, 4, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 1, 9, 35, 28, 479, DateTimeKind.Local).AddTicks(516) });

            migrationBuilder.UpdateData(
                table: "PsychologistWorkingHours",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2024, 1, 1, 4, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 1, 5, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 1, 9, 35, 28, 479, DateTimeKind.Local).AddTicks(520) });

            migrationBuilder.UpdateData(
                table: "PsychologistWorkingHours",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2024, 1, 1, 5, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 1, 6, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 1, 9, 35, 28, 479, DateTimeKind.Local).AddTicks(528) });

            migrationBuilder.UpdateData(
                table: "PsychologistWorkingHours",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2024, 1, 1, 6, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 1, 7, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 1, 9, 35, 28, 479, DateTimeKind.Local).AddTicks(532) });

            migrationBuilder.UpdateData(
                table: "PsychologistWorkingHours",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2024, 1, 1, 7, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 1, 9, 35, 28, 479, DateTimeKind.Local).AddTicks(536) });

            migrationBuilder.UpdateData(
                table: "PsychologistWorkingHours",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2024, 1, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 1, 9, 35, 28, 479, DateTimeKind.Local).AddTicks(540) });

            migrationBuilder.UpdateData(
                table: "PsychologistWorkingHours",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2024, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 1, 9, 35, 28, 479, DateTimeKind.Local).AddTicks(545) });

            migrationBuilder.UpdateData(
                table: "PsychologistWorkingHours",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 1, 11, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 1, 9, 35, 28, 479, DateTimeKind.Local).AddTicks(549) });

            migrationBuilder.UpdateData(
                table: "PsychologistWorkingHours",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2024, 1, 1, 11, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 1, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 1, 9, 35, 28, 479, DateTimeKind.Local).AddTicks(553) });

            migrationBuilder.UpdateData(
                table: "PsychologistWorkingHours",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2024, 1, 1, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 1, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 1, 9, 35, 28, 479, DateTimeKind.Local).AddTicks(556) });

            migrationBuilder.UpdateData(
                table: "PsychologistWorkingHours",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2024, 1, 1, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 1, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 1, 9, 35, 28, 479, DateTimeKind.Local).AddTicks(560) });

            migrationBuilder.UpdateData(
                table: "PsychologistWorkingHours",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedAt", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2024, 1, 1, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 1, 15, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 1, 9, 35, 28, 479, DateTimeKind.Local).AddTicks(564) });

            migrationBuilder.UpdateData(
                table: "PsychologistWorkingHours",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedAt", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2024, 1, 1, 15, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 1, 16, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 1, 9, 35, 28, 479, DateTimeKind.Local).AddTicks(567) });

            migrationBuilder.UpdateData(
                table: "PsychologistWorkingHours",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedAt", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2024, 1, 1, 16, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 1, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 1, 9, 35, 28, 479, DateTimeKind.Local).AddTicks(571) });

            migrationBuilder.UpdateData(
                table: "PsychologistWorkingHours",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CreatedAt", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2024, 1, 1, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 1, 18, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 1, 9, 35, 28, 479, DateTimeKind.Local).AddTicks(576) });

            migrationBuilder.UpdateData(
                table: "PsychologistWorkingHours",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CreatedAt", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2024, 1, 1, 18, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 1, 19, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 1, 9, 35, 28, 479, DateTimeKind.Local).AddTicks(579) });

            migrationBuilder.UpdateData(
                table: "PsychologistWorkingHours",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedAt", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2024, 1, 1, 19, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 1, 20, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 1, 9, 35, 28, 479, DateTimeKind.Local).AddTicks(585) });

            migrationBuilder.UpdateData(
                table: "PsychologistWorkingHours",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "CreatedAt", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2024, 1, 1, 20, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 1, 21, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 1, 9, 35, 28, 479, DateTimeKind.Local).AddTicks(588) });

            migrationBuilder.UpdateData(
                table: "PsychologistWorkingHours",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "CreatedAt", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2024, 1, 1, 21, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 1, 22, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 1, 9, 35, 28, 479, DateTimeKind.Local).AddTicks(591) });

            migrationBuilder.UpdateData(
                table: "PsychologistWorkingHours",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "CreatedAt", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2024, 1, 1, 22, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 1, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 1, 9, 35, 28, 479, DateTimeKind.Local).AddTicks(594) });

            migrationBuilder.UpdateData(
                table: "PsychologistWorkingHours",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "CreatedAt", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2024, 1, 1, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 1, 9, 35, 28, 479, DateTimeKind.Local).AddTicks(597) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 1, 9, 35, 28, 477, DateTimeKind.Local).AddTicks(5503));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 1, 9, 35, 28, 477, DateTimeKind.Local).AddTicks(5516));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 1, 9, 35, 28, 477, DateTimeKind.Local).AddTicks(5518));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 1, 9, 35, 28, 477, DateTimeKind.Local).AddTicks(5520));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ActivationCode", "CreatedAt", "Password" },
                values: new object[] { "0f8a42f1-0a30-4bdb-bae1-4ba29cd34bbb", new DateTime(2024, 1, 1, 9, 35, 28, 479, DateTimeKind.Local).AddTicks(339), "AQAAAAEAACcQAAAAEGqjLRCxrBEGbbyXkWrxhEzJ7RvnWpzT9u8U6ZlsFVLNZJIm+VXT+o5GOQqZrNr0GA==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsVisit",
                table: "Comments");

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
    }
}
