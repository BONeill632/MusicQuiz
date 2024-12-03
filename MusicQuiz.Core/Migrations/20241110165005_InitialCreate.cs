using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MusicQuiz.Core.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NormalizedName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ConcurrencyStamp = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NormalizedUserName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NormalizedEmail = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EmailConfirmed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    PasswordHash = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SecurityStamp = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ConcurrencyStamp = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PhoneNumber = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PhoneNumberConfirmed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "QuizQuestions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TopicId = table.Column<int>(type: "int", nullable: false),
                    DifficultyId = table.Column<int>(type: "int", nullable: false),
                    Question = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CorrectAnswer = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    WrongAnswerOne = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    WrongAnswerTwo = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    WrongAnswerThree = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    QuestionMusicFilePath = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ReferenceMusicFilePath = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuizQuestions", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", maxLength: 128, nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClaimType = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClaimValue = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", maxLength: 128, nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClaimType = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClaimValue = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProviderKey = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProviderDisplayName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserId = table.Column<string>(type: "varchar(128)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RoleId = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LoginProvider = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Value = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "QuizQuestions",
                columns: ["Id", "CorrectAnswer", "DifficultyId", "Question", "QuestionMusicFilePath", "ReferenceMusicFilePath", "TopicId", "WrongAnswerOne", "WrongAnswerThree", "WrongAnswerTwo"],
                values: new object[,]
                {
                    { 1, "1.25kHz", 1, "Identify the correct frequency.", "/Music/SineWave/1.25kHz.wav", "/Music/SineWave/1kHz.wav", 1, "800Hz", "3kHz", "1.5kHz" },
                    { 2, "1.25kHz", 2, "Identify the correct frequency.", "/Music/SineWave/1.25kHz.wav", "", 1, "1kHz", "1.5kHz", "1.75kHz" },
                    { 3, "1.25kHz", 3, "Identify the correct frequency.", "/Music/SineWave/1.25kHz.wav", "", 1, "1.2kHz", "1.3kHz", "1.4kHz" },

                    { 4, "1.6kHz", 1, "Identify the correct frequency.", "/Music/SineWave/1.6kHz.wav", "/Music/SineWave/1.6kHz.wav", 1, "1kHz", "2.5kHz", "600Hz" },
                    { 5, "1.6kHz", 2, "Identify the correct frequency.", "/Music/SineWave/1.6kHz.wav", "", 1, "1.2kHz", "2kHz", "1.8kHz" },
                    { 6, "1.6kHz", 3, "Identify the correct frequency.", "/Music/SineWave/1.6kHz.wav", "", 1, "1.55kHz", "1.65kHz", "1.7kHz" },

                    { 7, "100Hz", 1, "Identify the correct frequency.", "/Music/SineWave/100Hz.wav", "/Music/SineWave/400Hz.wav", 1, "300Hz", "750Hz", "900Hz" },
                    { 8, "100Hz", 2, "Identify the correct frequency.", "/Music/SineWave/100Hz.wav", "", 1, "300Hz", "500Hz", "250Hz" },
                    { 9, "100Hz", 3, "Identify the correct frequency.", "/Music/SineWave/100Hz.wav", "", 1, "150Hz", "200Hz", "250Hz" },

                    { 10, "10kHz", 1, "Identify the correct frequency.", "/Music/SineWave/10kHz.wav", "/Music/SineWave/6.3kHz.wav", 1, "800Hz", "2kHz", "1.5kHz" },
                    { 11, "10kHz", 2, "Identify the correct frequency.", "/Music/SineWave/10kHz.wav", "", 1, "8kHz", "12kHz", "15kHz" },
                    { 12, "10kHz", 3, "Identify the correct frequency.", "/Music/SineWave/10kHz.wav", "", 1, "9.5kHz", "10.5kHz", "11kHz" },

                    { 13, "12.5kHz", 1, "Identify the correct frequency.", "/Music/SineWave/12.5kHz.wav", "/Music/SineWave/8kHz.wav", 1, "8kHz", "10kHz", "15kHz" },
                    { 14, "12.5kHz", 2, "Identify the correct frequency.", "/Music/SineWave/12.5kHz.wav", "", 1, "11kHz", "13kHz", "14kHz" },
                    { 15, "12.5kHz", 3, "Identify the correct frequency.", "/Music/SineWave/12.5kHz.wav", "", 1, "12kHz", "13kHz", "14kHz" },

                    { 16, "125Hz", 1, "Identify the correct frequency.", "/Music/SineWave/125Hz.wav", "/Music/SineWave/400Hz.wav", 1, "80Hz", "200Hz", "300Hz" },
                    { 17, "125Hz", 2, "Identify the correct frequency.", "/Music/SineWave/125Hz.wav", "", 1, "100Hz", "150Hz", "175Hz" },
                    { 18, "125Hz", 3, "Identify the correct frequency.", "/Music/SineWave/125Hz.wav", "", 1, "120Hz", "130Hz", "140Hz" },

                    { 19, "160Hz", 1, "Identify the correct frequency.", "/Music/SineWave/160Hz.wav", "/Music/SineWave/400Hz.wav", 1, "100Hz", "200Hz", "300Hz" },
                    { 20, "160Hz", 2, "Identify the correct frequency.", "/Music/SineWave/160Hz.wav", "", 1, "120Hz", "180Hz", "200Hz" },
                    { 21, "160Hz", 3, "Identify the correct frequency.", "/Music/SineWave/160Hz.wav", "", 1, "150Hz", "170Hz", "180Hz" },

                    { 22, "16kHz", 1, "Identify the correct frequency.", "/Music/SineWave/16kHz.wav", "/Music/SineWave/12.5kHz.wav", 1, "14kHz", "15kHz", "17kHz" },
                    { 23, "16kHz", 2, "Identify the correct frequency.", "/Music/SineWave/16kHz.wav", "", 1, "15.5kHz", "16.5kHz", "17kHz" },
                    { 24, "16kHz", 3, "Identify the correct frequency.", "/Music/SineWave/16kHz.wav", "", 1, "15.8kHz", "16.2kHz", "16.5kHz" },

                    { 25, "1kHz", 1, "Identify the correct frequency.", "/Music/SineWave/1kHz.wav", "/Music/SineWave/500Hz.wav", 1, "800Hz", "1.2kHz", "1.5kHz" },
                    { 26, "1kHz", 2, "Identify the correct frequency.", "/Music/SineWave/1kHz.wav", "", 1, "900Hz", "1.1kHz", "1.3kHz" },
                    { 27, "1kHz", 3, "Identify the correct frequency.", "/Music/SineWave/1kHz.wav", "", 1, "950Hz", "1.05kHz", "1.1kHz" },

                    { 28, "2.5kHz", 1, "Identify the correct frequency.", "/Music/SineWave/2.5kHz.wav", "/Music/SineWave/4kHz.wav", 1, "2kHz", "3kHz", "3.5kHz" },
                    { 29, "2.5kHz", 2, "Identify the correct frequency.", "/Music/SineWave/2.5kHz.wav", "", 1, "2.3kHz", "2.7kHz", "3kHz" },
                    { 30, "2.5kHz", 3, "Identify the correct frequency.", "/Music/SineWave/2.5kHz.wav", "", 1, "2.4kHz", "2.6kHz", "2.8kHz" },

                    { 31, "200Hz", 1, "Identify the correct frequency.", "/Music/SineWave/200Hz.wav", "/Music/SineWave/400Hz.wav", 1, "150Hz", "250Hz", "300Hz" },
                    { 32, "200Hz", 2, "Identify the correct frequency.", "/Music/SineWave/200Hz.wav", "", 1, "180Hz", "220Hz", "240Hz" },
                    { 33, "200Hz", 3, "Identify the correct frequency.", "/Music/SineWave/200Hz.wav", "", 1, "190Hz", "210Hz", "230Hz" },

                    { 34, "250Hz", 1, "Identify the correct frequency.", "/Music/SineWave/250Hz.wav", "/Music/SineWave/400Hz.wav", 1, "200Hz", "300Hz", "350Hz" },
                    { 35, "250Hz", 2, "Identify the correct frequency.", "/Music/SineWave/250Hz.wav", "", 1, "230Hz", "270Hz", "290Hz" },
                    { 36, "250Hz", 3, "Identify the correct frequency.", "/Music/SineWave/250Hz.wav", "", 1, "240Hz", "260Hz", "280Hz" },

                    { 37, "2kHz", 1, "Identify the correct frequency.", "/Music/SineWave/2kHz.wav", "/Music/SineWave/1.6kHz.wav", 1, "1.5kHz", "2.5kHz", "3kHz" },
                    { 38, "2kHz", 2, "Identify the correct frequency.", "/Music/SineWave/2kHz.wav", "", 1, "1.8kHz", "2.2kHz", "2.4kHz" },
                    { 39, "2kHz", 3, "Identify the correct frequency.", "/Music/SineWave/2kHz.wav", "", 1, "1.9kHz", "2.1kHz", "2.3kHz" },

                    { 40, "3.15kHz", 1, "Identify the correct frequency.", "/Music/SineWave/3.15kHz.wav", "/Music/SineWave/5kHz.wav", 1, "2.5kHz", "3.5kHz", "4kHz" },
                    { 41, "3.15kHz", 2, "Identify the correct frequency.", "/Music/SineWave/3.15kHz.wav", "", 1, "2.8kHz", "3.2kHz", "3.5kHz" },
                    { 42, "3.15kHz", 3, "Identify the correct frequency.", "/Music/SineWave/3.15kHz.wav", "", 1, "3.0kHz", "3.2kHz", "3.3kHz" },

                    { 43, "315Hz", 1, "Identify the correct frequency.", "/Music/SineWave/315Hz.wav", "/Music/SineWave/400Hz.wav", 1, "200Hz", "400Hz", "500Hz" },
                    { 44, "315Hz", 2, "Identify the correct frequency.", "/Music/SineWave/315Hz.wav", "", 1, "290Hz", "330Hz", "350Hz" },
                    { 45, "315Hz", 3, "Identify the correct frequency.", "/Music/SineWave/315Hz.wav", "", 1, "305Hz", "320Hz", "325Hz" },

                    { 46, "400Hz", 1, "Identify the correct frequency.", "/Music/SineWave/400Hz.wav", "/Music/SineWave/400Hz.wav", 1, "200Hz", "600Hz", "800Hz" },
                    { 47, "400Hz", 2, "Identify the correct frequency.", "/Music/SineWave/400Hz.wav", "", 1, "370Hz", "420Hz", "450Hz" },
                    { 48, "400Hz", 3, "Identify the correct frequency.", "/Music/SineWave/400Hz.wav", "", 1, "385Hz", "410Hz", "415Hz" },

                    { 49, "4kHz", 1, "Identify the correct frequency.", "/Music/SineWave/4kHz.wav", "/Music/SineWave/5kHz.wav", 1, "2kHz", "6kHz", "8kHz" },
                    { 50, "4kHz", 2, "Identify the correct frequency.", "/Music/SineWave/4kHz.wav", "", 1, "3.7kHz", "4.2kHz", "4.5kHz" },
                    { 51, "4kHz", 3, "Identify the correct frequency.", "/Music/SineWave/4kHz.wav", "", 1, "3.85kHz", "4.1kHz", "4.15kHz" },

                    { 52, "500Hz", 1, "Identify the correct frequency.", "/Music/SineWave/500Hz.wav", "/Music/SineWave/400Hz.wav", 1, "200Hz", "800Hz", "1kHz" },
                    { 53, "500Hz", 2, "Identify the correct frequency.", "/Music/SineWave/500Hz.wav", "", 1, "470Hz", "520Hz", "550Hz" },
                    { 54, "500Hz", 3, "Identify the correct frequency.", "/Music/SineWave/500Hz.wav", "", 1, "485Hz", "510Hz", "515Hz" },

                    { 55, "5kHz", 1, "Identify the correct frequency.", "/Music/SineWave/5kHz.wav", "/Music/SineWave/6.3kHz.wav", 1, "2kHz", "8kHz", "10kHz" },
                    { 56, "5kHz", 2, "Identify the correct frequency.", "/Music/SineWave/5kHz.wav", "", 1, "4.7kHz", "5.2kHz", "5.5kHz" },
                    { 57, "5kHz", 3, "Identify the correct frequency.", "/Music/SineWave/5kHz.wav", "", 1, "4.85kHz", "5.1kHz", "5.15kHz" },

                    { 58, "6.3kHz", 1, "Identify the correct frequency.", "/Music/SineWave/6.3kHz.wav", "/Music/SineWave/4kHz.wav", 1, "3kHz", "9kHz", "12kHz" },
                    { 59, "6.3kHz", 2, "Identify the correct frequency.", "/Music/SineWave/6.3kHz.wav", "", 1, "5.9kHz", "6.5kHz", "6.8kHz" },
                    { 60, "6.3kHz", 3, "Identify the correct frequency.", "/Music/SineWave/6.3kHz.wav", "", 1, "6.1kHz", "6.4kHz", "6.35kHz" },

                    { 61, "630Hz", 1, "Identify the correct frequency.", "/Music/SineWave/630Hz.wav", "/Music/SineWave/400Hz.wav", 1, "300Hz", "900Hz", "1.2kHz" },
                    { 62, "630Hz", 2, "Identify the correct frequency.", "/Music/SineWave/630Hz.wav", "", 1, "590Hz", "660Hz", "700Hz" },
                    { 63, "630Hz", 3, "Identify the correct frequency.", "/Music/SineWave/630Hz.wav", "", 1, "615Hz", "640Hz", "635Hz" },

                    { 64, "63Hz", 1, "Identify the correct frequency.", "/Music/SineWave/63Hz.wav", "/Music/SineWave/400Hz.wav", 1, "30Hz", "90Hz", "120Hz" },
                    { 65, "63Hz", 2, "Identify the correct frequency.", "/Music/SineWave/63Hz.wav", "", 1, "58Hz", "66Hz", "70Hz" },
                    { 66, "63Hz", 3, "Identify the correct frequency.", "/Music/SineWave/63Hz.wav", "", 1, "61Hz", "64Hz", "63.5Hz" },

                    { 67, "800Hz", 1, "Identify the correct frequency.", "/Music/SineWave/800Hz.wav", "/Music/SineWave/400Hz.wav", 1, "400Hz", "1.2kHz", "1.6kHz" },
                    { 68, "800Hz", 2, "Identify the correct frequency.", "/Music/SineWave/800Hz.wav", "", 1, "770Hz", "820Hz", "850Hz" },
                    { 69, "800Hz", 3, "Identify the correct frequency.", "/Music/SineWave/800Hz.wav", "", 1, "785Hz", "810Hz", "805Hz" },

                    { 70, "80Hz", 1, "Identify the correct frequency.", "/Music/SineWave/80Hz.wav", "/Music/SineWave/400Hz.wav", 1, "40Hz", "120Hz", "160Hz" },
                    { 71, "80Hz", 2, "Identify the correct frequency.", "/Music/SineWave/80Hz.wav", "", 1, "76Hz", "82Hz", "85Hz" },
                    { 72, "80Hz", 3, "Identify the correct frequency.", "/Music/SineWave/80Hz.wav", "", 1, "78Hz", "81Hz", "80.5Hz" },

                    { 73, "8kHz", 1, "Identify the correct frequency.", "/Music/SineWave/8kHz.wav", "/Music/SineWave/6.3kHz.wav", 1, "4kHz", "12kHz", "16kHz" },
                    { 74, "8kHz", 2, "Identify the correct frequency.", "/Music/SineWave/8kHz.wav", "", 1, "7.7kHz", "8.2kHz", "8.5kHz" },
                    { 75, "8kHz", 3, "Identify the correct frequency.", "/Music/SineWave/8kHz.wav", "", 1, "7.85kHz", "8.1kHz", "8.05kHz" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "QuizQuestions");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
