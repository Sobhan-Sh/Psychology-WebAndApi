using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PC.Context.Migrations
{
    /// <inheritdoc />
    public partial class updatetablepatient : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsPatient",
                table: "Patients",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 15, 22, 17, 53, 112, DateTimeKind.Local).AddTicks(1444));

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 15, 22, 17, 53, 112, DateTimeKind.Local).AddTicks(1451));

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 15, 22, 17, 53, 112, DateTimeKind.Local).AddTicks(1453));

            migrationBuilder.UpdateData(
                table: "PsychologistWorkingDays",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 15, 22, 17, 53, 113, DateTimeKind.Local).AddTicks(9423));

            migrationBuilder.UpdateData(
                table: "PsychologistWorkingDays",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 15, 22, 17, 53, 113, DateTimeKind.Local).AddTicks(9429));

            migrationBuilder.UpdateData(
                table: "PsychologistWorkingDays",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 15, 22, 17, 53, 113, DateTimeKind.Local).AddTicks(9431));

            migrationBuilder.UpdateData(
                table: "PsychologistWorkingDays",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 15, 22, 17, 53, 113, DateTimeKind.Local).AddTicks(9432));

            migrationBuilder.UpdateData(
                table: "PsychologistWorkingDays",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 15, 22, 17, 53, 113, DateTimeKind.Local).AddTicks(9433));

            migrationBuilder.UpdateData(
                table: "PsychologistWorkingDays",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 15, 22, 17, 53, 113, DateTimeKind.Local).AddTicks(9436));

            migrationBuilder.UpdateData(
                table: "PsychologistWorkingDays",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 15, 22, 17, 53, 113, DateTimeKind.Local).AddTicks(9437));

            migrationBuilder.UpdateData(
                table: "PsychologistWorkingHours",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2023, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 15, 1, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 15, 22, 17, 53, 113, DateTimeKind.Local).AddTicks(9124) });

            migrationBuilder.UpdateData(
                table: "PsychologistWorkingHours",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2023, 12, 15, 1, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 15, 2, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 15, 22, 17, 53, 113, DateTimeKind.Local).AddTicks(9129) });

            migrationBuilder.UpdateData(
                table: "PsychologistWorkingHours",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2023, 12, 15, 2, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 15, 3, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 15, 22, 17, 53, 113, DateTimeKind.Local).AddTicks(9133) });

            migrationBuilder.UpdateData(
                table: "PsychologistWorkingHours",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2023, 12, 15, 3, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 15, 4, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 15, 22, 17, 53, 113, DateTimeKind.Local).AddTicks(9137) });

            migrationBuilder.UpdateData(
                table: "PsychologistWorkingHours",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2023, 12, 15, 4, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 15, 5, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 15, 22, 17, 53, 113, DateTimeKind.Local).AddTicks(9141) });

            migrationBuilder.UpdateData(
                table: "PsychologistWorkingHours",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2023, 12, 15, 5, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 15, 6, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 15, 22, 17, 53, 113, DateTimeKind.Local).AddTicks(9153) });

            migrationBuilder.UpdateData(
                table: "PsychologistWorkingHours",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2023, 12, 15, 6, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 15, 7, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 15, 22, 17, 53, 113, DateTimeKind.Local).AddTicks(9158) });

            migrationBuilder.UpdateData(
                table: "PsychologistWorkingHours",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2023, 12, 15, 7, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 15, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 15, 22, 17, 53, 113, DateTimeKind.Local).AddTicks(9162) });

            migrationBuilder.UpdateData(
                table: "PsychologistWorkingHours",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2023, 12, 15, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 15, 9, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 15, 22, 17, 53, 113, DateTimeKind.Local).AddTicks(9166) });

            migrationBuilder.UpdateData(
                table: "PsychologistWorkingHours",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2023, 12, 15, 9, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 15, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 15, 22, 17, 53, 113, DateTimeKind.Local).AddTicks(9171) });

            migrationBuilder.UpdateData(
                table: "PsychologistWorkingHours",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2023, 12, 15, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 15, 11, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 15, 22, 17, 53, 113, DateTimeKind.Local).AddTicks(9175) });

            migrationBuilder.UpdateData(
                table: "PsychologistWorkingHours",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2023, 12, 15, 11, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 15, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 15, 22, 17, 53, 113, DateTimeKind.Local).AddTicks(9179) });

            migrationBuilder.UpdateData(
                table: "PsychologistWorkingHours",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2023, 12, 15, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 15, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 15, 22, 17, 53, 113, DateTimeKind.Local).AddTicks(9183) });

            migrationBuilder.UpdateData(
                table: "PsychologistWorkingHours",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2023, 12, 15, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 15, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 15, 22, 17, 53, 113, DateTimeKind.Local).AddTicks(9187) });

            migrationBuilder.UpdateData(
                table: "PsychologistWorkingHours",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedAt", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2023, 12, 15, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 15, 15, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 15, 22, 17, 53, 113, DateTimeKind.Local).AddTicks(9191) });

            migrationBuilder.UpdateData(
                table: "PsychologistWorkingHours",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedAt", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2023, 12, 15, 15, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 15, 16, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 15, 22, 17, 53, 113, DateTimeKind.Local).AddTicks(9195) });

            migrationBuilder.UpdateData(
                table: "PsychologistWorkingHours",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedAt", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2023, 12, 15, 16, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 15, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 15, 22, 17, 53, 113, DateTimeKind.Local).AddTicks(9199) });

            migrationBuilder.UpdateData(
                table: "PsychologistWorkingHours",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CreatedAt", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2023, 12, 15, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 15, 18, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 15, 22, 17, 53, 113, DateTimeKind.Local).AddTicks(9204) });

            migrationBuilder.UpdateData(
                table: "PsychologistWorkingHours",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CreatedAt", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2023, 12, 15, 18, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 15, 19, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 15, 22, 17, 53, 113, DateTimeKind.Local).AddTicks(9208) });

            migrationBuilder.UpdateData(
                table: "PsychologistWorkingHours",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedAt", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2023, 12, 15, 19, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 15, 20, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 15, 22, 17, 53, 113, DateTimeKind.Local).AddTicks(9212) });

            migrationBuilder.UpdateData(
                table: "PsychologistWorkingHours",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "CreatedAt", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2023, 12, 15, 20, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 15, 21, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 15, 22, 17, 53, 113, DateTimeKind.Local).AddTicks(9216) });

            migrationBuilder.UpdateData(
                table: "PsychologistWorkingHours",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "CreatedAt", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2023, 12, 15, 21, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 15, 22, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 15, 22, 17, 53, 113, DateTimeKind.Local).AddTicks(9220) });

            migrationBuilder.UpdateData(
                table: "PsychologistWorkingHours",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "CreatedAt", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2023, 12, 15, 22, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 15, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 15, 22, 17, 53, 113, DateTimeKind.Local).AddTicks(9224) });

            migrationBuilder.UpdateData(
                table: "PsychologistWorkingHours",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "CreatedAt", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2023, 12, 15, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 15, 22, 17, 53, 113, DateTimeKind.Local).AddTicks(9228) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 15, 22, 17, 53, 112, DateTimeKind.Local).AddTicks(1369));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 15, 22, 17, 53, 112, DateTimeKind.Local).AddTicks(1378));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 15, 22, 17, 53, 112, DateTimeKind.Local).AddTicks(1380));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 15, 22, 17, 53, 112, DateTimeKind.Local).AddTicks(1382));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ActivationCode", "CreatedAt", "Password" },
                values: new object[] { "7693ce0f-f3c5-4e1d-9c3d-6ba22502db83", new DateTime(2023, 12, 15, 22, 17, 53, 113, DateTimeKind.Local).AddTicks(8829), "AQAAAAEAACcQAAAAEGWPUtpUtF/oCGPVhgOlujC6PAI1pnelN9+qX5djRDrVl0BtvpzJQ8GoLUSybRICqg==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsPatient",
                table: "Patients");

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 13, 12, 48, 55, 398, DateTimeKind.Local).AddTicks(3613));

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 13, 12, 48, 55, 398, DateTimeKind.Local).AddTicks(3617));

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 13, 12, 48, 55, 398, DateTimeKind.Local).AddTicks(3619));

            migrationBuilder.UpdateData(
                table: "PsychologistWorkingDays",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 13, 12, 48, 55, 400, DateTimeKind.Local).AddTicks(5614));

            migrationBuilder.UpdateData(
                table: "PsychologistWorkingDays",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 13, 12, 48, 55, 400, DateTimeKind.Local).AddTicks(5622));

            migrationBuilder.UpdateData(
                table: "PsychologistWorkingDays",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 13, 12, 48, 55, 400, DateTimeKind.Local).AddTicks(5623));

            migrationBuilder.UpdateData(
                table: "PsychologistWorkingDays",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 13, 12, 48, 55, 400, DateTimeKind.Local).AddTicks(5624));

            migrationBuilder.UpdateData(
                table: "PsychologistWorkingDays",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 13, 12, 48, 55, 400, DateTimeKind.Local).AddTicks(5625));

            migrationBuilder.UpdateData(
                table: "PsychologistWorkingDays",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 13, 12, 48, 55, 400, DateTimeKind.Local).AddTicks(5626));

            migrationBuilder.UpdateData(
                table: "PsychologistWorkingDays",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 13, 12, 48, 55, 400, DateTimeKind.Local).AddTicks(5627));

            migrationBuilder.UpdateData(
                table: "PsychologistWorkingHours",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2023, 12, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 13, 1, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 13, 12, 48, 55, 400, DateTimeKind.Local).AddTicks(4929) });

            migrationBuilder.UpdateData(
                table: "PsychologistWorkingHours",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2023, 12, 13, 1, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 13, 2, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 13, 12, 48, 55, 400, DateTimeKind.Local).AddTicks(4935) });

            migrationBuilder.UpdateData(
                table: "PsychologistWorkingHours",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2023, 12, 13, 2, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 13, 3, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 13, 12, 48, 55, 400, DateTimeKind.Local).AddTicks(4938) });

            migrationBuilder.UpdateData(
                table: "PsychologistWorkingHours",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2023, 12, 13, 3, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 13, 4, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 13, 12, 48, 55, 400, DateTimeKind.Local).AddTicks(4945) });

            migrationBuilder.UpdateData(
                table: "PsychologistWorkingHours",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2023, 12, 13, 4, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 13, 5, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 13, 12, 48, 55, 400, DateTimeKind.Local).AddTicks(4948) });

            migrationBuilder.UpdateData(
                table: "PsychologistWorkingHours",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2023, 12, 13, 5, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 13, 6, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 13, 12, 48, 55, 400, DateTimeKind.Local).AddTicks(4959) });

            migrationBuilder.UpdateData(
                table: "PsychologistWorkingHours",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2023, 12, 13, 6, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 13, 7, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 13, 12, 48, 55, 400, DateTimeKind.Local).AddTicks(4961) });

            migrationBuilder.UpdateData(
                table: "PsychologistWorkingHours",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2023, 12, 13, 7, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 13, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 13, 12, 48, 55, 400, DateTimeKind.Local).AddTicks(4964) });

            migrationBuilder.UpdateData(
                table: "PsychologistWorkingHours",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2023, 12, 13, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 13, 9, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 13, 12, 48, 55, 400, DateTimeKind.Local).AddTicks(4966) });

            migrationBuilder.UpdateData(
                table: "PsychologistWorkingHours",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2023, 12, 13, 9, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 13, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 13, 12, 48, 55, 400, DateTimeKind.Local).AddTicks(4970) });

            migrationBuilder.UpdateData(
                table: "PsychologistWorkingHours",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2023, 12, 13, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 13, 11, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 13, 12, 48, 55, 400, DateTimeKind.Local).AddTicks(4973) });

            migrationBuilder.UpdateData(
                table: "PsychologistWorkingHours",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2023, 12, 13, 11, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 13, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 13, 12, 48, 55, 400, DateTimeKind.Local).AddTicks(4975) });

            migrationBuilder.UpdateData(
                table: "PsychologistWorkingHours",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2023, 12, 13, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 13, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 13, 12, 48, 55, 400, DateTimeKind.Local).AddTicks(4978) });

            migrationBuilder.UpdateData(
                table: "PsychologistWorkingHours",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2023, 12, 13, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 13, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 13, 12, 48, 55, 400, DateTimeKind.Local).AddTicks(4981) });

            migrationBuilder.UpdateData(
                table: "PsychologistWorkingHours",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedAt", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2023, 12, 13, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 13, 15, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 13, 12, 48, 55, 400, DateTimeKind.Local).AddTicks(4983) });

            migrationBuilder.UpdateData(
                table: "PsychologistWorkingHours",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedAt", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2023, 12, 13, 15, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 13, 16, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 13, 12, 48, 55, 400, DateTimeKind.Local).AddTicks(4986) });

            migrationBuilder.UpdateData(
                table: "PsychologistWorkingHours",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedAt", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2023, 12, 13, 16, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 13, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 13, 12, 48, 55, 400, DateTimeKind.Local).AddTicks(4988) });

            migrationBuilder.UpdateData(
                table: "PsychologistWorkingHours",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CreatedAt", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2023, 12, 13, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 13, 18, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 13, 12, 48, 55, 400, DateTimeKind.Local).AddTicks(4993) });

            migrationBuilder.UpdateData(
                table: "PsychologistWorkingHours",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CreatedAt", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2023, 12, 13, 18, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 13, 19, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 13, 12, 48, 55, 400, DateTimeKind.Local).AddTicks(4995) });

            migrationBuilder.UpdateData(
                table: "PsychologistWorkingHours",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedAt", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2023, 12, 13, 19, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 13, 20, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 13, 12, 48, 55, 400, DateTimeKind.Local).AddTicks(4998) });

            migrationBuilder.UpdateData(
                table: "PsychologistWorkingHours",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "CreatedAt", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2023, 12, 13, 20, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 13, 21, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 13, 12, 48, 55, 400, DateTimeKind.Local).AddTicks(5000) });

            migrationBuilder.UpdateData(
                table: "PsychologistWorkingHours",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "CreatedAt", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2023, 12, 13, 21, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 13, 22, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 13, 12, 48, 55, 400, DateTimeKind.Local).AddTicks(5003) });

            migrationBuilder.UpdateData(
                table: "PsychologistWorkingHours",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "CreatedAt", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2023, 12, 13, 22, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 13, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 13, 12, 48, 55, 400, DateTimeKind.Local).AddTicks(5006) });

            migrationBuilder.UpdateData(
                table: "PsychologistWorkingHours",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "CreatedAt", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2023, 12, 13, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 13, 12, 48, 55, 400, DateTimeKind.Local).AddTicks(5008) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 13, 12, 48, 55, 398, DateTimeKind.Local).AddTicks(3554));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 13, 12, 48, 55, 398, DateTimeKind.Local).AddTicks(3566));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 13, 12, 48, 55, 398, DateTimeKind.Local).AddTicks(3567));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 13, 12, 48, 55, 398, DateTimeKind.Local).AddTicks(3568));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ActivationCode", "CreatedAt", "Password" },
                values: new object[] { "c8e62252-e614-4052-908d-6871af651f32", new DateTime(2023, 12, 13, 12, 48, 55, 400, DateTimeKind.Local).AddTicks(4725), "AQAAAAEAACcQAAAAENu9skvcG/JH7+9Rx81yiYNkFZ9n71vkiGhsyfovVldqL6+vFiLUiKO/NZtQbnnTNA==" });
        }
    }
}
