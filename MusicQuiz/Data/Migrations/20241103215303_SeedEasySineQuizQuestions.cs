using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MusicQuiz.Data.Migrations
{
    public partial class SeedEasySineQuizQuestions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "QuizQuestions",
                columns: new[] { "Id", "CorrectAnswer", "DifficultyId", "Question", "QuestionMusicFilePath", "ReferenceMusicFilePath", "TopicId", "WrongAnswerOne", "WrongAnswerThree", "WrongAnswerTwo" },
                values: new object[,]
                {
                    { 1, "1.25kHz", 1, "Identify the correct frequency.", "/Music/SineWave/1.25kHz.wav", "", 1, "800Hz", "3kHz", "1.5kHz" },
                    { 2, "1.25kHz", 2, "Identify the correct frequency.", "/Music/SineWave/1.25kHz.wav", "", 1, "1kHz", "2kHz", "1.5kHz" },
                    { 3, "1.25kHz", 3, "Identify the correct frequency.", "/Music/SineWave/1.25kHz.wav", "", 1, "1.25Hz", "1.75kHz", "1.5kHz" },

                    { 4, "1.6kHz", 1, "Identify the correct frequency.", "/Music/SineWave/1.6kHz.wav", "", 1, "1kHz", "2.5kHz", "600Hz" },
                    { 5, "1.6kHz", 2, "Identify the correct frequency.", "/Music/SineWave/1.6kHz.wav", "", 1, "1.2kHz", "2kHz", "1.8kHz" },
                    { 6, "1.6kHz", 3, "Identify the correct frequency.", "/Music/SineWave/1.6kHz.wav", "", 1, "1.2kHz", "1.4kHz", "1.8kHz" },

                    { 7, "100Hz", 1, "Identify the correct frequency.", "/Music/SineWave/100Hz.wav", "/Music/SineWave/400Hz.wav", 1, "300Hz", "750Hz", "900Hz" },
                    { 8, "100Hz", 2, "Identify the correct frequency.", "/Music/SineWave/100Hz.wav", "", 1, "300Hz", "500Hz", "250Hz" },
                    { 9, "100Hz", 3, "Identify the correct frequency.", "/Music/SineWave/100Hz.wav", "", 1, "150Hz", "200Hz", "250Hz" },

                    { 10, "10kHz", 1, "Identify the correct frequency.", "/Music/SineWave/10kHz.wav", "", 1, "800Hz", "2kHz", "1.5kHz" },
                    { 11, "10kHz", 2, "Identify the correct frequency.", "/Music/SineWave/10kHz.wav", "", 1, "800Hz", "2kHz", "1.5kHz" },
                    { 12, "10kHz", 3, "Identify the correct frequency.", "/Music/SineWave/10kHz.wav", "", 1, "800Hz", "2kHz", "1.5kHz" },

                    { 13, "12.5kHz", 1, "Identify the correct frequency.", "/Music/SineWave/12.5kHz.wav", "", 1, "800Hz", "2kHz", "1.5kHz" },
                    { 14, "12.5kHz", 2, "Identify the correct frequency.", "/Music/SineWave/12.5kHz.wav", "", 1, "800Hz", "2kHz", "1.5kHz" },
                    { 15, "12.5kHz", 3, "Identify the correct frequency.", "/Music/SineWave/12.5kHz.wav", "", 1, "800Hz", "2kHz", "1.5kHz" },

                    { 16, "125Hz", 1, "Identify the correct frequency.", "/Music/SineWave/125Hz.wav", "/Music/SineWave/400Hz.wav", 1, "800Hz", "2kHz", "1.5kHz" },
                    { 17, "125Hz", 2, "Identify the correct frequency.", "/Music/SineWave/125Hz.wav", "", 1, "800Hz", "2kHz", "1.5kHz" },
                    { 18, "125Hz", 3, "Identify the correct frequency.", "/Music/SineWave/125Hz.wav", "", 1, "800Hz", "2kHz", "1.5kHz" },

                    { 19, "160Hz", 1, "Identify the correct frequency.", "/Music/SineWave/160Hz.wav", "/Music/SineWave/400Hz.wav", 1, "800Hz", "2kHz", "1.5kHz" },
                    { 20, "160Hz", 2, "Identify the correct frequency.", "/Music/SineWave/160Hz.wav", "", 1, "800Hz", "2kHz", "1.5kHz" },
                    { 21, "160Hz", 3, "Identify the correct frequency.", "/Music/SineWave/160Hz.wav", "", 1, "800Hz", "2kHz", "1.5kHz" },

                    { 22, "16kHz", 1, "Identify the correct frequency.", "/Music/SineWave/16kHz.wav", "", 1, "800Hz", "2kHz", "1.5kHz" },
                    { 23, "16kHz", 2, "Identify the correct frequency.", "/Music/SineWave/16kHz.wav", "", 1, "800Hz", "2kHz", "1.5kHz" },
                    { 24, "16kHz", 3, "Identify the correct frequency.", "/Music/SineWave/16kHz.wav", "", 1, "800Hz", "2kHz", "1.5kHz" },

                    { 25, "1kHz", 1, "Identify the correct frequency.", "/Music/SineWave/1kHz.wav", "", 1, "800Hz", "2kHz", "1.5kHz" },
                    { 26, "1kHz", 2, "Identify the correct frequency.", "/Music/SineWave/1kHz.wav", "", 1, "800Hz", "2kHz", "1.5kHz" },
                    { 27, "1kHz", 3, "Identify the correct frequency.", "/Music/SineWave/1kHz.wav", "", 1, "800Hz", "2kHz", "1.5kHz" },
                    { 28, "2.5kHz", 1, "Identify the correct frequency.", "/Music/SineWave/2.5kHz.wav", "", 1, "800Hz", "2kHz", "1.5kHz" },
                    { 29, "2.5kHz", 2, "Identify the correct frequency.", "/Music/SineWave/2.5kHz.wav", "", 1, "800Hz", "2kHz", "1.5kHz" },
                    { 30, "2.5kHz", 3, "Identify the correct frequency.", "/Music/SineWave/2.5kHz.wav", "", 1, "800Hz", "2kHz", "1.5kHz" },
                    { 31, "200Hz", 1, "Identify the correct frequency.", "/Music/SineWave/200Hz.wav", "/Music/SineWave/400Hz.wav", 1, "800Hz", "2kHz", "1.5kHz" },
                    { 32, "200Hz", 2, "Identify the correct frequency.", "/Music/SineWave/200Hz.wav", "", 1, "800Hz", "2kHz", "1.5kHz" },
                    { 33, "200Hz", 3, "Identify the correct frequency.", "/Music/SineWave/200Hz.wav", "", 1, "800Hz", "2kHz", "1.5kHz" },
                    { 34, "250Hz", 1, "Identify the correct frequency.", "/Music/SineWave/250Hz.wav", "/Music/SineWave/400Hz.wav", 1, "800Hz", "2kHz", "1.5kHz" },
                    { 35, "250Hz", 2, "Identify the correct frequency.", "/Music/SineWave/250Hz.wav", "", 1, "800Hz", "2kHz", "1.5kHz" },
                    { 36, "250Hz", 3, "Identify the correct frequency.", "/Music/SineWave/250Hz.wav", "", 1, "800Hz", "2kHz", "1.5kHz" },
                    { 37, "2kHz", 1, "Identify the correct frequency.", "/Music/SineWave/2kHz.wav", "", 1, "800Hz", "2kHz", "1.5kHz" },
                    { 38, "2kHz", 2, "Identify the correct frequency.", "/Music/SineWave/2kHz.wav", "", 1, "800Hz", "2kHz", "1.5kHz" },
                    { 39, "2kHz", 3, "Identify the correct frequency.", "/Music/SineWave/2kHz.wav", "", 1, "800Hz", "2kHz", "1.5kHz" },
                    { 40, "3.15kHz", 1, "Identify the correct frequency.", "/Music/SineWave/3.15kHz.wav", "", 1, "800Hz", "2kHz", "1.5kHz" },
                    { 41, "3.15kHz", 2, "Identify the correct frequency.", "/Music/SineWave/3.15kHz.wav", "", 1, "800Hz", "2kHz", "1.5kHz" },
                    { 42, "3.15kHz", 3, "Identify the correct frequency.", "/Music/SineWave/3.15kHz.wav", "", 1, "800Hz", "2kHz", "1.5kHz" },
                    { 43, "315Hz", 1, "Identify the correct frequency.", "/Music/SineWave/315Hz.wav", "/Music/SineWave/400Hz.wav", 1, "800Hz", "2kHz", "1.5kHz" },
                    { 44, "315Hz", 2, "Identify the correct frequency.", "/Music/SineWave/315Hz.wav", "", 1, "800Hz", "2kHz", "1.5kHz" },
                    { 45, "315Hz", 3, "Identify the correct frequency.", "/Music/SineWave/315Hz.wav", "", 1, "800Hz", "2kHz", "1.5kHz" },
                    { 46, "400Hz", 1, "Identify the correct frequency.", "/Music/SineWave/400Hz.wav", "/Music/SineWave/400Hz.wav", 1, "800Hz", "2kHz", "1.5kHz" },
                    { 47, "400Hz", 2, "Identify the correct frequency.", "/Music/SineWave/400Hz.wav", "", 1, "800Hz", "2kHz", "1.5kHz" },
                    { 48, "400Hz", 3, "Identify the correct frequency.", "/Music/SineWave/400Hz.wav", "", 1, "800Hz", "2kHz", "1.5kHz" },
                    { 49, "4kHz", 1, "Identify the correct frequency.", "/Music/SineWave/4kHz.wav", "", 1, "800Hz", "2kHz", "1.5kHz" },
                    { 50, "4kHz", 2, "Identify the correct frequency.", "/Music/SineWave/4kHz.wav", "", 1, "800Hz", "2kHz", "1.5kHz" },
                    { 51, "4kHz", 3, "Identify the correct frequency.", "/Music/SineWave/4kHz.wav", "", 1, "800Hz", "2kHz", "1.5kHz" },
                    { 52, "500Hz", 1, "Identify the correct frequency.", "/Music/SineWave/500Hz.wav", "/Music/SineWave/400Hz.wav", 1, "800Hz", "2kHz", "1.5kHz" },
                    { 53, "500Hz", 2, "Identify the correct frequency.", "/Music/SineWave/500Hz.wav", "", 1, "800Hz", "2kHz", "1.5kHz" },
                    { 54, "500Hz", 3, "Identify the correct frequency.", "/Music/SineWave/500Hz.wav", "", 1, "800Hz", "2kHz", "1.5kHz" },
                    { 55, "5kHz", 1, "Identify the correct frequency.", "/Music/SineWave/5kHz.wav", "", 1, "800Hz", "2kHz", "1.5kHz" },
                    { 56, "5kHz", 2, "Identify the correct frequency.", "/Music/SineWave/5kHz.wav", "", 1, "800Hz", "2kHz", "1.5kHz" },
                    { 57, "5kHz", 3, "Identify the correct frequency.", "/Music/SineWave/5kHz.wav", "", 1, "800Hz", "2kHz", "1.5kHz" },
                    { 58, "6.3kHz", 1, "Identify the correct frequency.", "/Music/SineWave/6.3kHz.wav", "", 1, "800Hz", "2kHz", "1.5kHz" },
                    { 59, "6.3kHz", 2, "Identify the correct frequency.", "/Music/SineWave/6.3kHz.wav", "", 1, "800Hz", "2kHz", "1.5kHz" },
                    { 60, "6.3kHz", 3, "Identify the correct frequency.", "/Music/SineWave/6.3kHz.wav", "", 1, "800Hz", "2kHz", "1.5kHz" },
                    { 61, "630Hz", 1, "Identify the correct frequency.", "/Music/SineWave/630Hz.wav", "/Music/SineWave/400Hz.wav", 1, "800Hz", "2kHz", "1.5kHz" },
                    { 62, "630Hz", 2, "Identify the correct frequency.", "/Music/SineWave/630Hz.wav", "", 1, "800Hz", "2kHz", "1.5kHz" },
                    { 63, "630Hz", 3, "Identify the correct frequency.", "/Music/SineWave/630Hz.wav", "", 1, "800Hz", "2kHz", "1.5kHz" },
                    { 64, "63Hz", 1, "Identify the correct frequency.", "/Music/SineWave/63Hz.wav", "/Music/SineWave/400Hz.wav", 1, "800Hz", "2kHz", "1.5kHz" },
                    { 65, "63Hz", 2, "Identify the correct frequency.", "/Music/SineWave/63Hz.wav", "", 1, "800Hz", "2kHz", "1.5kHz" },
                    { 66, "63Hz", 3, "Identify the correct frequency.", "/Music/SineWave/63Hz.wav", "", 1, "800Hz", "2kHz", "1.5kHz" },
                    { 67, "800Hz", 1, "Identify the correct frequency.", "/Music/SineWave/800Hz.wav", "/Music/SineWave/400Hz.wav", 1, "800Hz", "2kHz", "1.5kHz" },
                    { 68, "800Hz", 2, "Identify the correct frequency.", "/Music/SineWave/800Hz.wav", "", 1, "800Hz", "2kHz", "1.5kHz" },
                    { 69, "800Hz", 3, "Identify the correct frequency.", "/Music/SineWave/800Hz.wav", "", 1, "800Hz", "2kHz", "1.5kHz" },
                    { 70, "80Hz", 1, "Identify the correct frequency.", "/Music/SineWave/80Hz.wav", "/Music/SineWave/400Hz.wav", 1, "800Hz", "2kHz", "1.5kHz" },
                    { 71, "80Hz", 2, "Identify the correct frequency.", "/Music/SineWave/80Hz.wav", "", 1, "800Hz", "2kHz", "1.5kHz" },
                    { 72, "80Hz", 3, "Identify the correct frequency.", "/Music/SineWave/80Hz.wav", "", 1, "800Hz", "2kHz", "1.5kHz" },
                    { 73, "8kHz", 1, "Identify the correct frequency.", "/Music/SineWave/8kHz.wav", "", 1, "800Hz", "2kHz", "1.5kHz" },
                    { 74, "8kHz", 2, "Identify the correct frequency.", "/Music/SineWave/8kHz.wav", "", 1, "800Hz", "2kHz", "1.5kHz" },
                    { 75, "8kHz", 3, "Identify the correct frequency.", "/Music/SineWave/8kHz.wav", "", 1, "800Hz", "2kHz", "1.5kHz" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: 75);
        }
    }
}
