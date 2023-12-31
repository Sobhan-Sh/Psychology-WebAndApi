﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PC.Context.Migrations
{
    /// <inheritdoc />
    public partial class initdatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Genders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PsychologistWorkingDays",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Day = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DayEn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
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
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
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
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
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
                    Price = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
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
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeOfConsultation", x => x.Id);
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
                    RoleID = table.Column<int>(type: "int", nullable: false),
                    GenderId = table.Column<int>(type: "int", nullable: false),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Genders_GenderId",
                        column: x => x.GenderId,
                        principalTable: "Genders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleID",
                        column: x => x.RoleID,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Questions_Tests_TestId",
                        column: x => x.TestId,
                        principalTable: "Tests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstUserId = table.Column<int>(type: "int", nullable: false),
                    LastUserId = table.Column<int>(type: "int", nullable: false),
                    ObjPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Users_FirstUserId",
                        column: x => x.FirstUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Patients_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Psychologists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Psychologists_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Answers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Answers_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PatientExams_Tests_TestId",
                        column: x => x.TestId,
                        principalTable: "Tests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientFiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PatientFiles_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discount", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Discount_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Discount_Psychologists_PsychologistId",
                        column: x => x.PsychologistId,
                        principalTable: "Psychologists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PsychologistTypeOfConsultations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PsychologistId = table.Column<int>(type: "int", nullable: false),
                    TypeOfConsultationId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PsychologistTypeOfConsultations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PsychologistTypeOfConsultations_Psychologists_PsychologistId",
                        column: x => x.PsychologistId,
                        principalTable: "Psychologists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PsychologistTypeOfConsultations_TypeOfConsultation_TypeOfConsultationId",
                        column: x => x.TypeOfConsultationId,
                        principalTable: "TypeOfConsultation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PsychologistWorkingDateAndTime", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PsychologistWorkingDateAndTime_PsychologistWorkingDays_PsychologistWorkingDaysId",
                        column: x => x.PsychologistWorkingDaysId,
                        principalTable: "PsychologistWorkingDays",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PsychologistWorkingDateAndTime_PsychologistWorkingHours_PsychologistWorkingHoursId",
                        column: x => x.PsychologistWorkingHoursId,
                        principalTable: "PsychologistWorkingHours",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PsychologistWorkingDateAndTime_Psychologists_PsychologistId",
                        column: x => x.PsychologistId,
                        principalTable: "Psychologists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientResponsesExamies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PatientResponsesExamies_PatientExams_PatientExamId",
                        column: x => x.PatientExamId,
                        principalTable: "PatientExams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                    ConsultationDay = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    IsVisited = table.Column<bool>(type: "bit", nullable: false),
                    IsCanseled = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientTurn", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PatientTurn_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PatientTurn_PsychologistWorkingDateAndTime_PsychologistWorkingDateAndTimeId",
                        column: x => x.PsychologistWorkingDateAndTimeId,
                        principalTable: "PsychologistWorkingDateAndTime",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PatientTurn_TypeOfConsultation_TypeOfConsultationId",
                        column: x => x.TypeOfConsultationId,
                        principalTable: "TypeOfConsultation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                    RefId = table.Column<int>(type: "int", nullable: true),
                    PayAmount = table.Column<int>(type: "int", nullable: true),
                    DiscountAmount = table.Column<int>(type: "int", nullable: true),
                    TotalAmount = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Order_PatientTurn_PatientTurnId",
                        column: x => x.PatientTurnId,
                        principalTable: "PatientTurn",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Order_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Order_Psychologists_PsychologistId",
                        column: x => x.PsychologistId,
                        principalTable: "Psychologists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Order_Tests_TestId",
                        column: x => x.TestId,
                        principalTable: "Tests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Genders",
                columns: new[] { "Id", "CreatedAt", "IsActive", "IsDeleted", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 12, 13, 12, 48, 55, 398, DateTimeKind.Local).AddTicks(3613), true, false, "آقا", null },
                    { 2, new DateTime(2023, 12, 13, 12, 48, 55, 398, DateTimeKind.Local).AddTicks(3617), true, false, "خانم", null },
                    { 3, new DateTime(2023, 12, 13, 12, 48, 55, 398, DateTimeKind.Local).AddTicks(3619), true, false, "دیگر", null }
                });

            migrationBuilder.InsertData(
                table: "PsychologistWorkingDays",
                columns: new[] { "Id", "CreatedAt", "Day", "DayEn", "IsActive", "IsDeleted", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 12, 13, 12, 48, 55, 400, DateTimeKind.Local).AddTicks(5614), "شنبه", "Saturday", true, false, null },
                    { 2, new DateTime(2023, 12, 13, 12, 48, 55, 400, DateTimeKind.Local).AddTicks(5622), "یک‌شنبه", "Sunday", true, false, null },
                    { 3, new DateTime(2023, 12, 13, 12, 48, 55, 400, DateTimeKind.Local).AddTicks(5623), "دو‌شنبه", "Monday", true, false, null },
                    { 4, new DateTime(2023, 12, 13, 12, 48, 55, 400, DateTimeKind.Local).AddTicks(5624), "سه‌شنبه", "Tuesday", true, false, null },
                    { 5, new DateTime(2023, 12, 13, 12, 48, 55, 400, DateTimeKind.Local).AddTicks(5625), "چهارشنبه", "Wednesday", true, false, null },
                    { 6, new DateTime(2023, 12, 13, 12, 48, 55, 400, DateTimeKind.Local).AddTicks(5626), "پنج‌شنبه", "Thursday", true, false, null },
                    { 7, new DateTime(2023, 12, 13, 12, 48, 55, 400, DateTimeKind.Local).AddTicks(5627), "جمعه", "Friday", true, false, null }
                });

            migrationBuilder.InsertData(
                table: "PsychologistWorkingHours",
                columns: new[] { "Id", "CreatedAt", "EndTime", "IsActive", "IsDeleted", "StartTime", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 12, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 13, 1, 0, 0, 0, DateTimeKind.Unspecified), true, false, new DateTime(2023, 12, 13, 12, 48, 55, 400, DateTimeKind.Local).AddTicks(4929), null },
                    { 2, new DateTime(2023, 12, 13, 1, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 13, 2, 0, 0, 0, DateTimeKind.Unspecified), true, false, new DateTime(2023, 12, 13, 12, 48, 55, 400, DateTimeKind.Local).AddTicks(4935), null },
                    { 3, new DateTime(2023, 12, 13, 2, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 13, 3, 0, 0, 0, DateTimeKind.Unspecified), true, false, new DateTime(2023, 12, 13, 12, 48, 55, 400, DateTimeKind.Local).AddTicks(4938), null },
                    { 4, new DateTime(2023, 12, 13, 3, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 13, 4, 0, 0, 0, DateTimeKind.Unspecified), true, false, new DateTime(2023, 12, 13, 12, 48, 55, 400, DateTimeKind.Local).AddTicks(4945), null },
                    { 5, new DateTime(2023, 12, 13, 4, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 13, 5, 0, 0, 0, DateTimeKind.Unspecified), true, false, new DateTime(2023, 12, 13, 12, 48, 55, 400, DateTimeKind.Local).AddTicks(4948), null },
                    { 6, new DateTime(2023, 12, 13, 5, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 13, 6, 0, 0, 0, DateTimeKind.Unspecified), true, false, new DateTime(2023, 12, 13, 12, 48, 55, 400, DateTimeKind.Local).AddTicks(4959), null },
                    { 7, new DateTime(2023, 12, 13, 6, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 13, 7, 0, 0, 0, DateTimeKind.Unspecified), true, false, new DateTime(2023, 12, 13, 12, 48, 55, 400, DateTimeKind.Local).AddTicks(4961), null },
                    { 8, new DateTime(2023, 12, 13, 7, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 13, 8, 0, 0, 0, DateTimeKind.Unspecified), true, false, new DateTime(2023, 12, 13, 12, 48, 55, 400, DateTimeKind.Local).AddTicks(4964), null },
                    { 9, new DateTime(2023, 12, 13, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 13, 9, 0, 0, 0, DateTimeKind.Unspecified), true, false, new DateTime(2023, 12, 13, 12, 48, 55, 400, DateTimeKind.Local).AddTicks(4966), null },
                    { 10, new DateTime(2023, 12, 13, 9, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 13, 10, 0, 0, 0, DateTimeKind.Unspecified), true, false, new DateTime(2023, 12, 13, 12, 48, 55, 400, DateTimeKind.Local).AddTicks(4970), null },
                    { 11, new DateTime(2023, 12, 13, 10, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 13, 11, 0, 0, 0, DateTimeKind.Unspecified), true, false, new DateTime(2023, 12, 13, 12, 48, 55, 400, DateTimeKind.Local).AddTicks(4973), null },
                    { 12, new DateTime(2023, 12, 13, 11, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 13, 12, 0, 0, 0, DateTimeKind.Unspecified), true, false, new DateTime(2023, 12, 13, 12, 48, 55, 400, DateTimeKind.Local).AddTicks(4975), null },
                    { 13, new DateTime(2023, 12, 13, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 13, 13, 0, 0, 0, DateTimeKind.Unspecified), true, false, new DateTime(2023, 12, 13, 12, 48, 55, 400, DateTimeKind.Local).AddTicks(4978), null },
                    { 14, new DateTime(2023, 12, 13, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 13, 14, 0, 0, 0, DateTimeKind.Unspecified), true, false, new DateTime(2023, 12, 13, 12, 48, 55, 400, DateTimeKind.Local).AddTicks(4981), null },
                    { 15, new DateTime(2023, 12, 13, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 13, 15, 0, 0, 0, DateTimeKind.Unspecified), true, false, new DateTime(2023, 12, 13, 12, 48, 55, 400, DateTimeKind.Local).AddTicks(4983), null },
                    { 16, new DateTime(2023, 12, 13, 15, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 13, 16, 0, 0, 0, DateTimeKind.Unspecified), true, false, new DateTime(2023, 12, 13, 12, 48, 55, 400, DateTimeKind.Local).AddTicks(4986), null },
                    { 17, new DateTime(2023, 12, 13, 16, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 13, 17, 0, 0, 0, DateTimeKind.Unspecified), true, false, new DateTime(2023, 12, 13, 12, 48, 55, 400, DateTimeKind.Local).AddTicks(4988), null },
                    { 18, new DateTime(2023, 12, 13, 17, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 13, 18, 0, 0, 0, DateTimeKind.Unspecified), true, false, new DateTime(2023, 12, 13, 12, 48, 55, 400, DateTimeKind.Local).AddTicks(4993), null },
                    { 19, new DateTime(2023, 12, 13, 18, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 13, 19, 0, 0, 0, DateTimeKind.Unspecified), true, false, new DateTime(2023, 12, 13, 12, 48, 55, 400, DateTimeKind.Local).AddTicks(4995), null },
                    { 20, new DateTime(2023, 12, 13, 19, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 13, 20, 0, 0, 0, DateTimeKind.Unspecified), true, false, new DateTime(2023, 12, 13, 12, 48, 55, 400, DateTimeKind.Local).AddTicks(4998), null },
                    { 21, new DateTime(2023, 12, 13, 20, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 13, 21, 0, 0, 0, DateTimeKind.Unspecified), true, false, new DateTime(2023, 12, 13, 12, 48, 55, 400, DateTimeKind.Local).AddTicks(5000), null },
                    { 22, new DateTime(2023, 12, 13, 21, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 13, 22, 0, 0, 0, DateTimeKind.Unspecified), true, false, new DateTime(2023, 12, 13, 12, 48, 55, 400, DateTimeKind.Local).AddTicks(5003), null },
                    { 23, new DateTime(2023, 12, 13, 22, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 13, 23, 0, 0, 0, DateTimeKind.Unspecified), true, false, new DateTime(2023, 12, 13, 12, 48, 55, 400, DateTimeKind.Local).AddTicks(5006), null },
                    { 24, new DateTime(2023, 12, 13, 23, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false, new DateTime(2023, 12, 13, 12, 48, 55, 400, DateTimeKind.Local).AddTicks(5008), null }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedAt", "IsActive", "IsDeleted", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 12, 13, 12, 48, 55, 398, DateTimeKind.Local).AddTicks(3554), true, false, "AdminManagment", null },
                    { 2, new DateTime(2023, 12, 13, 12, 48, 55, 398, DateTimeKind.Local).AddTicks(3566), true, false, "Customer", null },
                    { 3, new DateTime(2023, 12, 13, 12, 48, 55, 398, DateTimeKind.Local).AddTicks(3567), true, false, "Patient", null },
                    { 4, new DateTime(2023, 12, 13, 12, 48, 55, 398, DateTimeKind.Local).AddTicks(3568), true, false, "Psychologist", null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "ActivationCode", "Address", "Avatar", "CreatedAt", "FName", "GenderId", "IsActive", "IsDeleted", "LName", "MobailActiveStatus", "Password", "Phone", "RoleID", "Token", "UpdatedAt" },
                values: new object[] { 1, "c8e62252-e614-4052-908d-6871af651f32", null, null, new DateTime(2023, 12, 13, 12, 48, 55, 400, DateTimeKind.Local).AddTicks(4725), "مدیر", 2, true, false, "سیستم", true, "AQAAAAEAACcQAAAAENu9skvcG/JH7+9Rx81yiYNkFZ9n71vkiGhsyfovVldqL6+vFiLUiKO/NZtQbnnTNA==", "Administrator@1402", 1, null, null });

            migrationBuilder.CreateIndex(
                name: "IX_Answers_QuestionId",
                table: "Answers",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_FirstUserId",
                table: "Comments",
                column: "FirstUserId");

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
                name: "IX_Psychologists_UserId",
                table: "Psychologists",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PsychologistTypeOfConsultations_PsychologistId",
                table: "PsychologistTypeOfConsultations",
                column: "PsychologistId");

            migrationBuilder.CreateIndex(
                name: "IX_PsychologistTypeOfConsultations_TypeOfConsultationId",
                table: "PsychologistTypeOfConsultations",
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
                name: "IX_Users_GenderId",
                table: "Users",
                column: "GenderId");

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
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Discount");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "PatientFiles");

            migrationBuilder.DropTable(
                name: "PatientResponsesExamies");

            migrationBuilder.DropTable(
                name: "PsychologistTypeOfConsultations");

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
                name: "Genders");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
