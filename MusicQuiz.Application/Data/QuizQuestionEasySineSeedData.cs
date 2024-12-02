using Microsoft.EntityFrameworkCore;
using MusicQuiz.Core.Entities;

namespace MusicQuiz.Application.Data
{
    public static class QuizQuestionEasySineSeedData
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            var seedData = GenerateSeedData();
            modelBuilder.Entity<QuizQuestion>().HasData(seedData);
        }

        /// <summary>
        /// Generates the base data for Sine wave questions at each difficulty level
        /// Wrong answer data needs entered manually across all 75 answers
        /// </summary>
        /// <returns></returns>
        private static List<QuizQuestion> GenerateSeedData()
        {
            var seedData = new List<QuizQuestion>();
            var files = Directory.GetFiles("wwwroot/Music/SineWave", "*.wav");

            int id = 1;
            foreach (var file in files)
            {
                var fileName = Path.GetFileNameWithoutExtension(file);
                for (int difficultyId = 1; difficultyId <= 3; difficultyId++)
                {
                    seedData.Add(new QuizQuestion
                    {
                        Id = id++,
                        TopicId = 1,
                        DifficultyId = difficultyId,
                        Question = $"Identify the correct frequency.",
                        CorrectAnswer = fileName,
                        WrongAnswerOne = "800Hz",
                        WrongAnswerTwo = "1.5kHz",
                        WrongAnswerThree = "2kHz",
                        QuestionMusicFilePath = $"/Music/SineWave/{fileName}.wav",
                        ReferenceMusicFilePath = !fileName.Contains('k') && difficultyId == 1 ? $"/Music/SineWave/400Hz.wav" : "",
                    });
                }
            }

            return seedData;
        }
    }
}
