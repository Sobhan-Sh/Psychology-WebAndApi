using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PC.Context.Migrations
{
    /// <inheritdoc />
    public partial class addtblArticl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Users_FirstUserId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_FirstUserId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "FirstUserId",
                table: "Comments");

            migrationBuilder.RenameColumn(
                name: "LastUserId",
                table: "Comments",
                newName: "PsychologistId");

            migrationBuilder.AddColumn<int>(
                name: "PaitentId",
                table: "Comments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Comments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Articles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PsychologistId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Articles_Psychologists_PsychologistId",
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

            migrationBuilder.CreateIndex(
                name: "IX_Comments_PaitentId",
                table: "Comments",
                column: "PaitentId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_PsychologistId",
                table: "Comments",
                column: "PsychologistId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserId",
                table: "Comments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_PsychologistId",
                table: "Articles",
                column: "PsychologistId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Patients_PaitentId",
                table: "Comments",
                column: "PaitentId",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Psychologists_PsychologistId",
                table: "Comments",
                column: "PsychologistId",
                principalTable: "Psychologists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Users_UserId",
                table: "Comments",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Patients_PaitentId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Psychologists_PsychologistId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Users_UserId",
                table: "Comments");

            migrationBuilder.DropTable(
                name: "Articles");

            migrationBuilder.DropIndex(
                name: "IX_Comments_PaitentId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_PsychologistId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_UserId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "PaitentId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Comments");

            migrationBuilder.RenameColumn(
                name: "PsychologistId",
                table: "Comments",
                newName: "LastUserId");

            migrationBuilder.AddColumn<int>(
                name: "FirstUserId",
                table: "Comments",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.CreateIndex(
                name: "IX_Comments_FirstUserId",
                table: "Comments",
                column: "FirstUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Users_FirstUserId",
                table: "Comments",
                column: "FirstUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
