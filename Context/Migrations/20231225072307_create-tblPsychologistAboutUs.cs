using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PC.Context.Migrations
{
    /// <inheritdoc />
    public partial class createtblPsychologistAboutUs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PsychologistAboutUs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TextAbout = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PsychologistId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PsychologistAboutUs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PsychologistAboutUs_Psychologists_PsychologistId",
                        column: x => x.PsychologistId,
                        principalTable: "Psychologists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_PsychologistAboutUs_PsychologistId",
                table: "PsychologistAboutUs",
                column: "PsychologistId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PsychologistAboutUs");

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 19, 13, 58, 39, 835, DateTimeKind.Local).AddTicks(3582));

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 19, 13, 58, 39, 835, DateTimeKind.Local).AddTicks(3585));

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 19, 13, 58, 39, 835, DateTimeKind.Local).AddTicks(3586));

            migrationBuilder.UpdateData(
                table: "PsychologistWorkingDays",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 19, 13, 58, 39, 837, DateTimeKind.Local).AddTicks(4347));

            migrationBuilder.UpdateData(
                table: "PsychologistWorkingDays",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 19, 13, 58, 39, 837, DateTimeKind.Local).AddTicks(4356));

            migrationBuilder.UpdateData(
                table: "PsychologistWorkingDays",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 19, 13, 58, 39, 837, DateTimeKind.Local).AddTicks(4357));

            migrationBuilder.UpdateData(
                table: "PsychologistWorkingDays",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 19, 13, 58, 39, 837, DateTimeKind.Local).AddTicks(4358));

            migrationBuilder.UpdateData(
                table: "PsychologistWorkingDays",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 19, 13, 58, 39, 837, DateTimeKind.Local).AddTicks(4359));

            migrationBuilder.UpdateData(
                table: "PsychologistWorkingDays",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 19, 13, 58, 39, 837, DateTimeKind.Local).AddTicks(4360));

            migrationBuilder.UpdateData(
                table: "PsychologistWorkingDays",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 19, 13, 58, 39, 837, DateTimeKind.Local).AddTicks(4361));

            migrationBuilder.UpdateData(
                table: "PsychologistWorkingHours",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2023, 12, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 19, 1, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 19, 13, 58, 39, 837, DateTimeKind.Local).AddTicks(4079) });

            migrationBuilder.UpdateData(
                table: "PsychologistWorkingHours",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2023, 12, 19, 1, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 19, 2, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 19, 13, 58, 39, 837, DateTimeKind.Local).AddTicks(4086) });

            migrationBuilder.UpdateData(
                table: "PsychologistWorkingHours",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2023, 12, 19, 2, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 19, 3, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 19, 13, 58, 39, 837, DateTimeKind.Local).AddTicks(4105) });

            migrationBuilder.UpdateData(
                table: "PsychologistWorkingHours",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2023, 12, 19, 3, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 19, 4, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 19, 13, 58, 39, 837, DateTimeKind.Local).AddTicks(4109) });

            migrationBuilder.UpdateData(
                table: "PsychologistWorkingHours",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2023, 12, 19, 4, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 19, 5, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 19, 13, 58, 39, 837, DateTimeKind.Local).AddTicks(4112) });

            migrationBuilder.UpdateData(
                table: "PsychologistWorkingHours",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2023, 12, 19, 5, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 19, 6, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 19, 13, 58, 39, 837, DateTimeKind.Local).AddTicks(4120) });

            migrationBuilder.UpdateData(
                table: "PsychologistWorkingHours",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2023, 12, 19, 6, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 19, 7, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 19, 13, 58, 39, 837, DateTimeKind.Local).AddTicks(4124) });

            migrationBuilder.UpdateData(
                table: "PsychologistWorkingHours",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2023, 12, 19, 7, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 19, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 19, 13, 58, 39, 837, DateTimeKind.Local).AddTicks(4127) });

            migrationBuilder.UpdateData(
                table: "PsychologistWorkingHours",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2023, 12, 19, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 19, 9, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 19, 13, 58, 39, 837, DateTimeKind.Local).AddTicks(4130) });

            migrationBuilder.UpdateData(
                table: "PsychologistWorkingHours",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2023, 12, 19, 9, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 19, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 19, 13, 58, 39, 837, DateTimeKind.Local).AddTicks(4135) });

            migrationBuilder.UpdateData(
                table: "PsychologistWorkingHours",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2023, 12, 19, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 19, 11, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 19, 13, 58, 39, 837, DateTimeKind.Local).AddTicks(4139) });

            migrationBuilder.UpdateData(
                table: "PsychologistWorkingHours",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2023, 12, 19, 11, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 19, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 19, 13, 58, 39, 837, DateTimeKind.Local).AddTicks(4142) });

            migrationBuilder.UpdateData(
                table: "PsychologistWorkingHours",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2023, 12, 19, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 19, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 19, 13, 58, 39, 837, DateTimeKind.Local).AddTicks(4146) });

            migrationBuilder.UpdateData(
                table: "PsychologistWorkingHours",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2023, 12, 19, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 19, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 19, 13, 58, 39, 837, DateTimeKind.Local).AddTicks(4150) });

            migrationBuilder.UpdateData(
                table: "PsychologistWorkingHours",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedAt", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2023, 12, 19, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 19, 15, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 19, 13, 58, 39, 837, DateTimeKind.Local).AddTicks(4154) });

            migrationBuilder.UpdateData(
                table: "PsychologistWorkingHours",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedAt", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2023, 12, 19, 15, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 19, 16, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 19, 13, 58, 39, 837, DateTimeKind.Local).AddTicks(4157) });

            migrationBuilder.UpdateData(
                table: "PsychologistWorkingHours",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedAt", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2023, 12, 19, 16, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 19, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 19, 13, 58, 39, 837, DateTimeKind.Local).AddTicks(4160) });

            migrationBuilder.UpdateData(
                table: "PsychologistWorkingHours",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CreatedAt", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2023, 12, 19, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 19, 18, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 19, 13, 58, 39, 837, DateTimeKind.Local).AddTicks(4166) });

            migrationBuilder.UpdateData(
                table: "PsychologistWorkingHours",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CreatedAt", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2023, 12, 19, 18, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 19, 19, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 19, 13, 58, 39, 837, DateTimeKind.Local).AddTicks(4170) });

            migrationBuilder.UpdateData(
                table: "PsychologistWorkingHours",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedAt", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2023, 12, 19, 19, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 19, 20, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 19, 13, 58, 39, 837, DateTimeKind.Local).AddTicks(4174) });

            migrationBuilder.UpdateData(
                table: "PsychologistWorkingHours",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "CreatedAt", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2023, 12, 19, 20, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 19, 21, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 19, 13, 58, 39, 837, DateTimeKind.Local).AddTicks(4178) });

            migrationBuilder.UpdateData(
                table: "PsychologistWorkingHours",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "CreatedAt", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2023, 12, 19, 21, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 19, 22, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 19, 13, 58, 39, 837, DateTimeKind.Local).AddTicks(4182) });

            migrationBuilder.UpdateData(
                table: "PsychologistWorkingHours",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "CreatedAt", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2023, 12, 19, 22, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 19, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 19, 13, 58, 39, 837, DateTimeKind.Local).AddTicks(4186) });

            migrationBuilder.UpdateData(
                table: "PsychologistWorkingHours",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "CreatedAt", "EndTime", "StartTime" },
                values: new object[] { new DateTime(2023, 12, 19, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 19, 13, 58, 39, 837, DateTimeKind.Local).AddTicks(4190) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 19, 13, 58, 39, 835, DateTimeKind.Local).AddTicks(3521));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 19, 13, 58, 39, 835, DateTimeKind.Local).AddTicks(3530));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 19, 13, 58, 39, 835, DateTimeKind.Local).AddTicks(3532));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2023, 12, 19, 13, 58, 39, 835, DateTimeKind.Local).AddTicks(3533));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ActivationCode", "CreatedAt", "Password" },
                values: new object[] { "c4c319fc-e797-4bdf-8aea-891d0ed89f43", new DateTime(2023, 12, 19, 13, 58, 39, 837, DateTimeKind.Local).AddTicks(3848), "AQAAAAEAACcQAAAAEG+YBBbeDtvMpLivynR3ZGoK++/QpQu30H3el+8heloGZvtczz832wrSPLNdERv0hw==" });
        }
    }
}
