using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Context.Migrations
{
    /// <inheritdoc />
    public partial class initpsychologydb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Psychologists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NationalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MedicalLicennseCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Commission = table.Column<int>(type: "int", nullable: true),
                    EvidencePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Psychologists", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PsychologistWorkingDays",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Day = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PsychologistWorkingDays", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PsychologistWorkingHours",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PsychologistWorkingHours", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypeOfConsultation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeOfConsultation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PsychologistWorkingDateAndTime",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PsychologistId = table.Column<int>(type: "int", nullable: false),
                    PsychologistWorkingDaysId = table.Column<int>(type: "int", nullable: false),
                    PsychologistWorkingHoursId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PsychologistWorkingDateAndTime", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PsychologistWorkingDateAndTime_PsychologistWorkingDays_PsychologistWorkingDaysId",
                        column: x => x.PsychologistWorkingDaysId,
                        principalTable: "PsychologistWorkingDays",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PsychologistWorkingDateAndTime_PsychologistWorkingHours_PsychologistWorkingHoursId",
                        column: x => x.PsychologistWorkingHoursId,
                        principalTable: "PsychologistWorkingHours",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PsychologistWorkingDateAndTime_Psychologists_PsychologistId",
                        column: x => x.PsychologistId,
                        principalTable: "Psychologists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MobailActiveStatus = table.Column<bool>(type: "bit", nullable: false),
                    ActivationCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Avatar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoleID = table.Column<int>(type: "int", nullable: false),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleID",
                        column: x => x.RoleID,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TestId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Questions_Tests_TestId",
                        column: x => x.TestId,
                        principalTable: "Tests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NationalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    TheReason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Patients_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Answers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Score = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QuestionId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Answers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Answers_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Discount",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    PsychologistId = table.Column<int>(type: "int", nullable: false),
                    DiscountWithMoney = table.Column<int>(type: "int", nullable: true),
                    DiscountWithPercentage = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discount", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Discount_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Discount_Psychologists_PsychologistId",
                        column: x => x.PsychologistId,
                        principalTable: "Psychologists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PatientExams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    TestId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientExams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PatientExams_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PatientExams_Tests_TestId",
                        column: x => x.TestId,
                        principalTable: "Tests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PatientFiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientFiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PatientFiles_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PatientTurn",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PsychologistWorkingDateAndTimeId = table.Column<int>(type: "int", nullable: false),
                    TypeOfConsultationId = table.Column<int>(type: "int", nullable: false),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    ConsultationDay = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientTurn", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PatientTurn_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PatientTurn_PsychologistWorkingDateAndTime_PsychologistWorkingDateAndTimeId",
                        column: x => x.PsychologistWorkingDateAndTimeId,
                        principalTable: "PsychologistWorkingDateAndTime",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PatientTurn_TypeOfConsultation_TypeOfConsultationId",
                        column: x => x.TypeOfConsultationId,
                        principalTable: "TypeOfConsultation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PatientResponsesExamies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientExamId = table.Column<int>(type: "int", nullable: false),
                    Score = table.Column<int>(type: "int", nullable: false),
                    PathFile = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientResponsesExamies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PatientResponsesExamies_PatientExams_PatientExamId",
                        column: x => x.PatientExamId,
                        principalTable: "PatientExams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientTurnId = table.Column<int>(type: "int", nullable: true),
                    TestId = table.Column<int>(type: "int", nullable: true),
                    PsychologistId = table.Column<int>(type: "int", nullable: false),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    IsPaid = table.Column<bool>(type: "bit", nullable: false),
                    RefId = table.Column<int>(type: "int", nullable: false),
                    PayAmount = table.Column<int>(type: "int", nullable: false),
                    DiscountAmount = table.Column<int>(type: "int", nullable: false),
                    TotalAmount = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Order_PatientTurn_PatientTurnId",
                        column: x => x.PatientTurnId,
                        principalTable: "PatientTurn",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Order_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Order_Psychologists_PsychologistId",
                        column: x => x.PsychologistId,
                        principalTable: "Psychologists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Order_Tests_TestId",
                        column: x => x.TestId,
                        principalTable: "Tests",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "PsychologistWorkingDays",
                columns: new[] { "Id", "CreatedAt", "Day", "IsActive", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 11, 5, 14, 0, 12, 848, DateTimeKind.Local).AddTicks(5898), "شنبه", true, null },
                    { 2, new DateTime(2023, 11, 5, 14, 0, 12, 848, DateTimeKind.Local).AddTicks(5901), "یکشنبه", true, null },
                    { 3, new DateTime(2023, 11, 5, 14, 0, 12, 848, DateTimeKind.Local).AddTicks(5903), "دوشنبه", true, null },
                    { 4, new DateTime(2023, 11, 5, 14, 0, 12, 848, DateTimeKind.Local).AddTicks(5904), "سه شنبه", true, null },
                    { 5, new DateTime(2023, 11, 5, 14, 0, 12, 848, DateTimeKind.Local).AddTicks(5906), "چهار شنبه", true, null },
                    { 6, new DateTime(2023, 11, 5, 14, 0, 12, 848, DateTimeKind.Local).AddTicks(5908), "پنج شنبه", true, null },
                    { 7, new DateTime(2023, 11, 5, 14, 0, 12, 848, DateTimeKind.Local).AddTicks(5909), "جمعه", true, null }
                });

            migrationBuilder.InsertData(
                table: "PsychologistWorkingHours",
                columns: new[] { "Id", "CreatedAt", "EndTime", "IsActive", "StartTime", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 11, 5, 1, 0, 0, 0, DateTimeKind.Unspecified), true, new DateTime(2023, 11, 5, 14, 0, 12, 848, DateTimeKind.Local).AddTicks(5752), null },
                    { 2, new DateTime(2023, 11, 5, 1, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 11, 5, 2, 0, 0, 0, DateTimeKind.Unspecified), true, new DateTime(2023, 11, 5, 14, 0, 12, 848, DateTimeKind.Local).AddTicks(5758), null },
                    { 3, new DateTime(2023, 11, 5, 2, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 11, 5, 3, 0, 0, 0, DateTimeKind.Unspecified), true, new DateTime(2023, 11, 5, 14, 0, 12, 848, DateTimeKind.Local).AddTicks(5761), null },
                    { 4, new DateTime(2023, 11, 5, 3, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 11, 5, 4, 0, 0, 0, DateTimeKind.Unspecified), true, new DateTime(2023, 11, 5, 14, 0, 12, 848, DateTimeKind.Local).AddTicks(5764), null },
                    { 5, new DateTime(2023, 11, 5, 4, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 11, 5, 5, 0, 0, 0, DateTimeKind.Unspecified), true, new DateTime(2023, 11, 5, 14, 0, 12, 848, DateTimeKind.Local).AddTicks(5767), null },
                    { 6, new DateTime(2023, 11, 5, 5, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 11, 5, 6, 0, 0, 0, DateTimeKind.Unspecified), true, new DateTime(2023, 11, 5, 14, 0, 12, 848, DateTimeKind.Local).AddTicks(5772), null },
                    { 7, new DateTime(2023, 11, 5, 6, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 11, 5, 7, 0, 0, 0, DateTimeKind.Unspecified), true, new DateTime(2023, 11, 5, 14, 0, 12, 848, DateTimeKind.Local).AddTicks(5775), null },
                    { 8, new DateTime(2023, 11, 5, 7, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 11, 5, 8, 0, 0, 0, DateTimeKind.Unspecified), true, new DateTime(2023, 11, 5, 14, 0, 12, 848, DateTimeKind.Local).AddTicks(5777), null },
                    { 9, new DateTime(2023, 11, 5, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 11, 5, 9, 0, 0, 0, DateTimeKind.Unspecified), true, new DateTime(2023, 11, 5, 14, 0, 12, 848, DateTimeKind.Local).AddTicks(5780), null },
                    { 10, new DateTime(2023, 11, 5, 9, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 11, 5, 10, 0, 0, 0, DateTimeKind.Unspecified), true, new DateTime(2023, 11, 5, 14, 0, 12, 848, DateTimeKind.Local).AddTicks(5784), null },
                    { 11, new DateTime(2023, 11, 5, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 11, 5, 11, 0, 0, 0, DateTimeKind.Unspecified), true, new DateTime(2023, 11, 5, 14, 0, 12, 848, DateTimeKind.Local).AddTicks(5786), null },
                    { 12, new DateTime(2023, 11, 5, 11, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 11, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), true, new DateTime(2023, 11, 5, 14, 0, 12, 848, DateTimeKind.Local).AddTicks(5789), null },
                    { 13, new DateTime(2023, 11, 5, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 11, 5, 13, 0, 0, 0, DateTimeKind.Unspecified), true, new DateTime(2023, 11, 5, 14, 0, 12, 848, DateTimeKind.Local).AddTicks(5791), null },
                    { 14, new DateTime(2023, 11, 5, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 11, 5, 14, 0, 0, 0, DateTimeKind.Unspecified), true, new DateTime(2023, 11, 5, 14, 0, 12, 848, DateTimeKind.Local).AddTicks(5794), null },
                    { 15, new DateTime(2023, 11, 5, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 11, 5, 15, 0, 0, 0, DateTimeKind.Unspecified), true, new DateTime(2023, 11, 5, 14, 0, 12, 848, DateTimeKind.Local).AddTicks(5797), null },
                    { 16, new DateTime(2023, 11, 5, 15, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 11, 5, 16, 0, 0, 0, DateTimeKind.Unspecified), true, new DateTime(2023, 11, 5, 14, 0, 12, 848, DateTimeKind.Local).AddTicks(5799), null },
                    { 17, new DateTime(2023, 11, 5, 16, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 11, 5, 17, 0, 0, 0, DateTimeKind.Unspecified), true, new DateTime(2023, 11, 5, 14, 0, 12, 848, DateTimeKind.Local).AddTicks(5802), null },
                    { 18, new DateTime(2023, 11, 5, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 11, 5, 18, 0, 0, 0, DateTimeKind.Unspecified), true, new DateTime(2023, 11, 5, 14, 0, 12, 848, DateTimeKind.Local).AddTicks(5832), null },
                    { 19, new DateTime(2023, 11, 5, 18, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 11, 5, 19, 0, 0, 0, DateTimeKind.Unspecified), true, new DateTime(2023, 11, 5, 14, 0, 12, 848, DateTimeKind.Local).AddTicks(5835), null },
                    { 20, new DateTime(2023, 11, 5, 19, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 11, 5, 20, 0, 0, 0, DateTimeKind.Unspecified), true, new DateTime(2023, 11, 5, 14, 0, 12, 848, DateTimeKind.Local).AddTicks(5838), null },
                    { 21, new DateTime(2023, 11, 5, 20, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 11, 5, 21, 0, 0, 0, DateTimeKind.Unspecified), true, new DateTime(2023, 11, 5, 14, 0, 12, 848, DateTimeKind.Local).AddTicks(5841), null },
                    { 22, new DateTime(2023, 11, 5, 21, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 11, 5, 22, 0, 0, 0, DateTimeKind.Unspecified), true, new DateTime(2023, 11, 5, 14, 0, 12, 848, DateTimeKind.Local).AddTicks(5843), null },
                    { 23, new DateTime(2023, 11, 5, 22, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 11, 5, 23, 0, 0, 0, DateTimeKind.Unspecified), true, new DateTime(2023, 11, 5, 14, 0, 12, 848, DateTimeKind.Local).AddTicks(5846), null },
                    { 24, new DateTime(2023, 11, 5, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), true, new DateTime(2023, 11, 5, 14, 0, 12, 848, DateTimeKind.Local).AddTicks(5849), null }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedAt", "IsActive", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 11, 5, 14, 0, 12, 847, DateTimeKind.Local).AddTicks(1553), true, "AdminManagment", null },
                    { 2, new DateTime(2023, 11, 5, 14, 0, 12, 847, DateTimeKind.Local).AddTicks(1558), true, "Customer", null },
                    { 3, new DateTime(2023, 11, 5, 14, 0, 12, 847, DateTimeKind.Local).AddTicks(1560), true, "Patient", null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "ActivationCode", "Address", "Avatar", "CreatedAt", "FName", "Gender", "IsActive", "LName", "MobailActiveStatus", "Password", "Phone", "RoleID", "Token", "UpdatedAt" },
                values: new object[] { 1, "b7046348-8092-4767-92db-3b4b6d985090", null, null, new DateTime(2023, 11, 5, 14, 0, 12, 848, DateTimeKind.Local).AddTicks(5605), "مدیر", null, true, "سیستم", true, "AQAAAAEAACcQAAAAEDxYZAslO66mvQjhMfpyzRhFOZIxFKKu3AJUJqUVPOFp7TbjPt/94XpblU29KL+4AA==", "Administrator@1402", 1, null, null });

            migrationBuilder.CreateIndex(
                name: "IX_Answers_QuestionId",
                table: "Answers",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_Discount_PatientId",
                table: "Discount",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Discount_PsychologistId",
                table: "Discount",
                column: "PsychologistId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_PatientId",
                table: "Order",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_PatientTurnId",
                table: "Order",
                column: "PatientTurnId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_PsychologistId",
                table: "Order",
                column: "PsychologistId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_TestId",
                table: "Order",
                column: "TestId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientExams_PatientId",
                table: "PatientExams",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientExams_TestId",
                table: "PatientExams",
                column: "TestId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientFiles_PatientId",
                table: "PatientFiles",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientResponsesExamies_PatientExamId",
                table: "PatientResponsesExamies",
                column: "PatientExamId");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_UserId",
                table: "Patients",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientTurn_PatientId",
                table: "PatientTurn",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientTurn_PsychologistWorkingDateAndTimeId",
                table: "PatientTurn",
                column: "PsychologistWorkingDateAndTimeId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientTurn_TypeOfConsultationId",
                table: "PatientTurn",
                column: "TypeOfConsultationId");

            migrationBuilder.CreateIndex(
                name: "IX_PsychologistWorkingDateAndTime_PsychologistId",
                table: "PsychologistWorkingDateAndTime",
                column: "PsychologistId");

            migrationBuilder.CreateIndex(
                name: "IX_PsychologistWorkingDateAndTime_PsychologistWorkingDaysId",
                table: "PsychologistWorkingDateAndTime",
                column: "PsychologistWorkingDaysId");

            migrationBuilder.CreateIndex(
                name: "IX_PsychologistWorkingDateAndTime_PsychologistWorkingHoursId",
                table: "PsychologistWorkingDateAndTime",
                column: "PsychologistWorkingHoursId");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_TestId",
                table: "Questions",
                column: "TestId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleID",
                table: "Users",
                column: "RoleID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Answers");

            migrationBuilder.DropTable(
                name: "Discount");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "PatientFiles");

            migrationBuilder.DropTable(
                name: "PatientResponsesExamies");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "PatientTurn");

            migrationBuilder.DropTable(
                name: "PatientExams");

            migrationBuilder.DropTable(
                name: "PsychologistWorkingDateAndTime");

            migrationBuilder.DropTable(
                name: "TypeOfConsultation");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "Tests");

            migrationBuilder.DropTable(
                name: "PsychologistWorkingDays");

            migrationBuilder.DropTable(
                name: "PsychologistWorkingHours");

            migrationBuilder.DropTable(
                name: "Psychologists");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
