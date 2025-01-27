using Microsoft.EntityFrameworkCore;
using MusicQuiz.Core.Entities;

namespace MusicQuiz.Core.Data
{
    public static class QuizQuestionSeedData
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            var seedData = GenerateSeedData();
            modelBuilder.Entity<QuizQuestion>().HasData(seedData);
        }

        /// <summary>
        /// Generates the seed data for all quiz questions.
        /// </summary>
        /// <returns></returns>
        public static List<QuizQuestion> GenerateSeedData()
        {
            var seedData = new List<QuizQuestion>();

            var quizQuestions = new List<(int Id, string CorrectAnswer, int DifficultyId, string Question, string QuestionMusicFilePath, string ReferenceMusicFilePath, int TopicId, string WrongAnswerOne, string WrongAnswerTwo, string WrongAnswerThree)>
        {
                    ( 1, "1.25kHz", 1, "Identify the correct frequency of the sine wave.", "/Music/SineWave/1.25kHz.wav", "/Music/SineWave/1kHz.wav", 1, "800Hz", "3kHz", "1.5kHz" ),
                    ( 2, "1.25kHz", 2, "Identify the correct frequency of the sine wave.", "/Music/SineWave/1.25kHz.wav", "/Music/SineWave/1kHz.wav", 1, "1kHz", "1.5kHz", "1.75kHz" ),
                    ( 3, "1.25kHz", 3, "Identify the correct frequency of the sine wave.", "/Music/SineWave/1.25kHz.wav", "/Music/SineWave/1kHz.wav", 1, "1.2kHz", "1.3kHz", "1.4kHz" ),

                    ( 4, "1.6kHz", 1, "Identify the correct frequency of the sine wave.", "/Music/SineWave/1.6kHz.wav", "/Music/SineWave/1.6kHz.wav", 1, "1kHz", "2.5kHz", "600Hz" ),
                    ( 5, "1.6kHz", 2, "Identify the correct frequency of the sine wave.", "/Music/SineWave/1.6kHz.wav", "/Music/SineWave/1.6kHz.wav", 1, "1.2kHz", "2kHz", "1.8kHz" ),
                    ( 6, "1.6kHz", 3, "Identify the correct frequency of the sine wave.", "/Music/SineWave/1.6kHz.wav", "/Music/SineWave/1.6kHz.wav", 1, "1.55kHz", "1.65kHz", "1.7kHz" ),

                    ( 7, "100Hz", 1, "Identify the correct frequency of the sine wave.", "/Music/SineWave/100Hz.wav", "/Music/SineWave/400Hz.wav", 1, "300Hz", "750Hz", "900Hz" ),
                    ( 8, "100Hz", 2, "Identify the correct frequency of the sine wave.", "/Music/SineWave/100Hz.wav", "/Music/SineWave/400Hz.wav", 1, "300Hz", "500Hz", "250Hz" ),
                    ( 9, "100Hz", 3, "Identify the correct frequency of the sine wave.", "/Music/SineWave/100Hz.wav", "/Music/SineWave/400Hz.wav", 1, "150Hz", "200Hz", "250Hz" ),

                    ( 10, "10kHz", 1, "Identify the correct frequency of the sine wave.", "/Music/SineWave/10kHz.wav", "/Music/SineWave/6.3kHz.wav", 1, "800Hz", "2kHz", "1.5kHz" ),
                    ( 11, "10kHz", 2, "Identify the correct frequency of the sine wave.", "/Music/SineWave/10kHz.wav", "/Music/SineWave/6.3kHz.wav", 1, "8kHz", "12kHz", "15kHz" ),
                    ( 12, "10kHz", 3, "Identify the correct frequency of the sine wave.", "/Music/SineWave/10kHz.wav", "/Music/SineWave/6.3kHz.wav", 1, "9.5kHz", "10.5kHz", "11kHz" ),

                    ( 13, "12.5kHz", 1, "Identify the correct frequency of the sine wave.", "/Music/SineWave/12.5kHz.wav", "/Music/SineWave/8kHz.wav", 1, "8kHz", "10kHz", "15kHz" ),
                    ( 14, "12.5kHz", 2, "Identify the correct frequency of the sine wave.", "/Music/SineWave/12.5kHz.wav", "/Music/SineWave/8kHz.wav", 1, "11kHz", "13kHz", "14kHz" ),
                    ( 15, "12.5kHz", 3, "Identify the correct frequency of the sine wave.", "/Music/SineWave/12.5kHz.wav", "/Music/SineWave/8kHz.wav", 1, "12kHz", "13kHz", "14kHz" ),

                    ( 16, "125Hz", 1, "Identify the correct frequency of the sine wave.", "/Music/SineWave/125Hz.wav", "/Music/SineWave/400Hz.wav", 1, "80Hz", "200Hz", "300Hz" ),
                    ( 17, "125Hz", 2, "Identify the correct frequency of the sine wave.", "/Music/SineWave/125Hz.wav", "/Music/SineWave/400Hz.wav", 1, "100Hz", "150Hz", "175Hz" ),
                    ( 18, "125Hz", 3, "Identify the correct frequency of the sine wave.", "/Music/SineWave/125Hz.wav", "/Music/SineWave/400Hz.wav", 1, "120Hz", "130Hz", "140Hz" ),

                    ( 19, "160Hz", 1, "Identify the correct frequency of the sine wave.", "/Music/SineWave/160Hz.wav", "/Music/SineWave/400Hz.wav", 1, "100Hz", "200Hz", "300Hz" ),
                    ( 20, "160Hz", 2, "Identify the correct frequency of the sine wave.", "/Music/SineWave/160Hz.wav", "/Music/SineWave/400Hz.wav", 1, "120Hz", "180Hz", "200Hz" ),
                    ( 21, "160Hz", 3, "Identify the correct frequency of the sine wave.", "/Music/SineWave/160Hz.wav", "/Music/SineWave/400Hz.wav", 1, "150Hz", "170Hz", "180Hz" ),

                    ( 22, "16kHz", 1, "Identify the correct frequency of the sine wave.", "/Music/SineWave/16kHz.wav", "/Music/SineWave/12.5kHz.wav", 1, "14kHz", "15kHz", "17kHz" ),
                    ( 23, "16kHz", 2, "Identify the correct frequency of the sine wave.", "/Music/SineWave/16kHz.wav", "/Music/SineWave/12.5kHz.wav", 1, "15.5kHz", "16.5kHz", "17kHz" ),
                    ( 24, "16kHz", 3, "Identify the correct frequency of the sine wave.", "/Music/SineWave/16kHz.wav", "/Music/SineWave/12.5kHz.wav", 1, "15.8kHz", "16.2kHz", "16.5kHz" ),

                    ( 25, "1kHz", 1, "Identify the correct frequency of the sine wave.", "/Music/SineWave/1kHz.wav", "/Music/SineWave/500Hz.wav", 1, "800Hz", "1.2kHz", "1.5kHz" ),
                    ( 26, "1kHz", 2, "Identify the correct frequency of the sine wave.", "/Music/SineWave/1kHz.wav", "/Music/SineWave/500Hz.wav", 1, "900Hz", "1.1kHz", "1.3kHz" ),
                    ( 27, "1kHz", 3, "Identify the correct frequency of the sine wave.", "/Music/SineWave/1kHz.wav", "/Music/SineWave/500Hz.wav", 1, "950Hz", "1.05kHz", "1.1kHz" ),

                    ( 28, "2.5kHz", 1, "Identify the correct frequency of the sine wave.", "/Music/SineWave/2.5kHz.wav", "/Music/SineWave/4kHz.wav", 1, "2kHz", "3kHz", "3.5kHz" ),
                    ( 29, "2.5kHz", 2, "Identify the correct frequency of the sine wave.", "/Music/SineWave/2.5kHz.wav", "/Music/SineWave/4kHz.wav", 1, "2.3kHz", "2.7kHz", "3kHz" ),
                    ( 30, "2.5kHz", 3, "Identify the correct frequency of the sine wave.", "/Music/SineWave/2.5kHz.wav", "/Music/SineWave/4kHz.wav", 1, "2.4kHz", "2.6kHz", "2.8kHz" ),

                    ( 31, "200Hz", 1, "Identify the correct frequency of the sine wave.", "/Music/SineWave/200Hz.wav", "/Music/SineWave/400Hz.wav", 1, "150Hz", "250Hz", "300Hz" ),
                    ( 32, "200Hz", 2, "Identify the correct frequency of the sine wave.", "/Music/SineWave/200Hz.wav", "/Music/SineWave/400Hz.wav", 1, "180Hz", "220Hz", "240Hz" ),
                    ( 33, "200Hz", 3, "Identify the correct frequency of the sine wave.", "/Music/SineWave/200Hz.wav", "/Music/SineWave/400Hz.wav", 1, "190Hz", "210Hz", "230Hz" ),

                    ( 34, "250Hz", 1, "Identify the correct frequency of the sine wave.", "/Music/SineWave/250Hz.wav", "/Music/SineWave/400Hz.wav", 1, "200Hz", "300Hz", "350Hz" ),
                    ( 35, "250Hz", 2, "Identify the correct frequency of the sine wave.", "/Music/SineWave/250Hz.wav", "/Music/SineWave/400Hz.wav", 1, "230Hz", "270Hz", "290Hz" ),
                    ( 36, "250Hz", 3, "Identify the correct frequency of the sine wave.", "/Music/SineWave/250Hz.wav", "/Music/SineWave/400Hz.wav", 1, "240Hz", "260Hz", "280Hz" ),

                    ( 37, "2kHz", 1, "Identify the correct frequency of the sine wave.", "/Music/SineWave/2kHz.wav", "/Music/SineWave/1.6kHz.wav", 1, "1.5kHz", "2.5kHz", "3kHz" ),
                    ( 38, "2kHz", 2, "Identify the correct frequency of the sine wave.", "/Music/SineWave/2kHz.wav", "/Music/SineWave/1.6kHz.wav", 1, "1.8kHz", "2.2kHz", "2.4kHz" ),
                    ( 39, "2kHz", 3, "Identify the correct frequency of the sine wave.", "/Music/SineWave/2kHz.wav", "/Music/SineWave/1.6kHz.wav", 1, "1.9kHz", "2.1kHz", "2.3kHz" ),

                    ( 40, "3.15kHz", 1, "Identify the correct frequency of the sine wave.", "/Music/SineWave/3.15kHz.wav", "/Music/SineWave/5kHz.wav", 1, "2.5kHz", "3.5kHz", "4kHz" ),
                    ( 41, "3.15kHz", 2, "Identify the correct frequency of the sine wave.", "/Music/SineWave/3.15kHz.wav", "/Music/SineWave/5kHz.wav", 1, "2.8kHz", "3.2kHz", "3.5kHz" ),
                    ( 42, "3.15kHz", 3, "Identify the correct frequency of the sine wave.", "/Music/SineWave/3.15kHz.wav", "/Music/SineWave/5kHz.wav", 1, "3.0kHz", "3.2kHz", "3.3kHz" ),

                    ( 43, "315Hz", 1, "Identify the correct frequency of the sine wave.", "/Music/SineWave/315Hz.wav", "/Music/SineWave/400Hz.wav", 1, "200Hz", "400Hz", "500Hz" ),
                    ( 44, "315Hz", 2, "Identify the correct frequency of the sine wave.", "/Music/SineWave/315Hz.wav", "/Music/SineWave/400Hz.wav", 1, "290Hz", "330Hz", "350Hz" ),
                    ( 45, "315Hz", 3, "Identify the correct frequency of the sine wave.", "/Music/SineWave/315Hz.wav", "/Music/SineWave/400Hz.wav", 1, "305Hz", "320Hz", "325Hz" ),

                    ( 46, "400Hz", 1, "Identify the correct frequency of the sine wave.", "/Music/SineWave/400Hz.wav", "/Music/SineWave/400Hz.wav", 1, "200Hz", "600Hz", "800Hz" ),
                    ( 47, "400Hz", 2, "Identify the correct frequency of the sine wave.", "/Music/SineWave/400Hz.wav", "/Music/SineWave/400Hz.wav", 1, "370Hz", "420Hz", "450Hz" ),
                    ( 48, "400Hz", 3, "Identify the correct frequency of the sine wave.", "/Music/SineWave/400Hz.wav", "/Music/SineWave/400Hz.wav", 1, "385Hz", "410Hz", "415Hz" ),

                    ( 49, "4kHz", 1, "Identify the correct frequency of the sine wave.", "/Music/SineWave/4kHz.wav", "/Music/SineWave/5kHz.wav", 1, "2kHz", "6kHz", "8kHz" ),
                    ( 50, "4kHz", 2, "Identify the correct frequency of the sine wave.", "/Music/SineWave/4kHz.wav", "/Music/SineWave/5kHz.wav", 1, "3.7kHz", "4.2kHz", "4.5kHz" ),
                    ( 51, "4kHz", 3, "Identify the correct frequency of the sine wave.", "/Music/SineWave/4kHz.wav", "/Music/SineWave/5kHz.wav", 1, "3.85kHz", "4.1kHz", "4.15kHz" ),

                    ( 52, "500Hz", 1, "Identify the correct frequency of the sine wave.", "/Music/SineWave/500Hz.wav", "/Music/SineWave/400Hz.wav", 1, "200Hz", "800Hz", "1kHz" ),
                    ( 53, "500Hz", 2, "Identify the correct frequency of the sine wave.", "/Music/SineWave/500Hz.wav", "/Music/SineWave/400Hz.wav", 1, "470Hz", "520Hz", "550Hz" ),
                    ( 54, "500Hz", 3, "Identify the correct frequency of the sine wave.", "/Music/SineWave/500Hz.wav", "/Music/SineWave/400Hz.wav", 1, "485Hz", "510Hz", "515Hz" ),

                    ( 55, "5kHz", 1, "Identify the correct frequency of the sine wave.", "/Music/SineWave/5kHz.wav", "/Music/SineWave/6.3kHz.wav", 1, "2kHz", "8kHz", "10kHz" ),
                    ( 56, "5kHz", 2, "Identify the correct frequency of the sine wave.", "/Music/SineWave/5kHz.wav", "/Music/SineWave/6.3kHz.wav", 1, "4.7kHz", "5.2kHz", "5.5kHz" ),
                    ( 57, "5kHz", 3, "Identify the correct frequency of the sine wave.", "/Music/SineWave/5kHz.wav", "/Music/SineWave/6.3kHz.wav", 1, "4.85kHz", "5.1kHz", "5.15kHz" ),

                    ( 58, "6.3kHz", 1, "Identify the correct frequency of the sine wave.", "/Music/SineWave/6.3kHz.wav", "/Music/SineWave/4kHz.wav", 1, "3kHz", "9kHz", "12kHz" ),
                    ( 59, "6.3kHz", 2, "Identify the correct frequency of the sine wave.", "/Music/SineWave/6.3kHz.wav", "/Music/SineWave/4kHz.wav", 1, "5.9kHz", "6.5kHz", "6.8kHz" ),
                    ( 60, "6.3kHz", 3, "Identify the correct frequency of the sine wave.", "/Music/SineWave/6.3kHz.wav", "/Music/SineWave/4kHz.wav", 1, "6.1kHz", "6.4kHz", "6.35kHz" ),

                    ( 61, "630Hz", 1, "Identify the correct frequency of the sine wave.", "/Music/SineWave/630Hz.wav", "/Music/SineWave/400Hz.wav", 1, "300Hz", "900Hz", "1.2kHz" ),
                    ( 62, "630Hz", 2, "Identify the correct frequency of the sine wave.", "/Music/SineWave/630Hz.wav", "/Music/SineWave/400Hz.wav", 1, "590Hz", "660Hz", "700Hz" ),
                    ( 63, "630Hz", 3, "Identify the correct frequency of the sine wave.", "/Music/SineWave/630Hz.wav", "/Music/SineWave/400Hz.wav", 1, "615Hz", "640Hz", "635Hz" ),

                    ( 64, "63Hz", 1, "Identify the correct frequency of the sine wave.", "/Music/SineWave/63Hz.wav", "/Music/SineWave/400Hz.wav", 1, "30Hz", "90Hz", "120Hz" ),
                    ( 65, "63Hz", 2, "Identify the correct frequency of the sine wave.", "/Music/SineWave/63Hz.wav", "/Music/SineWave/400Hz.wav", 1, "58Hz", "66Hz", "70Hz" ),
                    ( 66, "63Hz", 3, "Identify the correct frequency of the sine wave.", "/Music/SineWave/63Hz.wav", "/Music/SineWave/400Hz.wav", 1, "61Hz", "64Hz", "63.5Hz" ),

                    ( 67, "800Hz", 1, "Identify the correct frequency of the sine wave.", "/Music/SineWave/800Hz.wav", "/Music/SineWave/400Hz.wav", 1, "400Hz", "1.2kHz", "1.6kHz" ),
                    ( 68, "800Hz", 2, "Identify the correct frequency of the sine wave.", "/Music/SineWave/800Hz.wav", "/Music/SineWave/400Hz.wav", 1, "770Hz", "820Hz", "850Hz" ),
                    ( 69, "800Hz", 3, "Identify the correct frequency of the sine wave.", "/Music/SineWave/800Hz.wav", "/Music/SineWave/400Hz.wav", 1, "785Hz", "810Hz", "805Hz" ),

                    ( 70, "80Hz", 1, "Identify the correct frequency of the sine wave.", "/Music/SineWave/80Hz.wav", "/Music/SineWave/400Hz.wav", 1, "40Hz", "120Hz", "160Hz" ),
                    ( 71, "80Hz", 2, "Identify the correct frequency of the sine wave.", "/Music/SineWave/80Hz.wav", "/Music/SineWave/400Hz.wav", 1, "76Hz", "82Hz", "85Hz" ),
                    ( 72, "80Hz", 3, "Identify the correct frequency of the sine wave.", "/Music/SineWave/80Hz.wav", "/Music/SineWave/400Hz.wav", 1, "78Hz", "81Hz", "80.5Hz" ),

                    ( 73, "8kHz", 1, "Identify the correct frequency of the sine wave.", "/Music/SineWave/8kHz.wav", "/Music/SineWave/6.3kHz.wav", 1, "4kHz", "12kHz", "16kHz" ),
                    ( 74, "8kHz", 2, "Identify the correct frequency of the sine wave.", "/Music/SineWave/8kHz.wav", "/Music/SineWave/400Hz.wav", 1, "7.7kHz", "8.2kHz", "8.5kHz" ),
                    ( 75, "8kHz", 3, "Identify the correct frequency of the sine wave.", "/Music/SineWave/8kHz.wav", "/Music/SineWave/400Hz.wav", 1, "7.85kHz", "8.1kHz", "8.05kHz" ),

                    ( 76, "HPF 125Hz", 1, "Identify the correct frequency of the pink noise.", "/Music/Pink Noise/HPF 125Hz.wav", "/Music/Pink Noise/HPF Reference.wav", 4, "HPF 12.5Hz", "HPF 500Hz", "HPF 125kHz" ),
                    ( 77, "HPF 125Hz", 2, "Identify the correct frequency of the pink noise.", "/Music/Pink Noise/HPF 125Hz.wav", "/Music/Pink Noise/HPF Reference.wav", 4, "HPF 12.5Hz", "HPF 500Hz", "HPF 125kHz" ),
                    ( 78, "HPF 125Hz", 3, "Identify the correct frequency of the pink noise.", "/Music/Pink Noise/HPF 125Hz.wav", "/Music/Pink Noise/HPF Reference.wav", 4, "HPF 12.5Hz", "HPF 500Hz", "HPF 125kHz" ),

                    ( 79, "HPF 250Hz", 1, "Identify the correct frequency of the pink noise.", "/Music/Pink Noise/HPF 250Hz.wav", "/Music/Pink Noise/HPF Reference.wav", 4, "HPF 25Hz", "HPF 750Hz", "HPF 250kHz" ),
                    ( 80, "HPF 250Hz", 2, "Identify the correct frequency of the pink noise.", "/Music/Pink Noise/HPF 250Hz.wav", "/Music/Pink Noise/HPF Reference.wav", 4, "HPF 25Hz", "HPF 750Hz", "HPF 250kHz" ),
                    ( 81, "HPF 250Hz", 3, "Identify the correct frequency of the pink noise.", "/Music/Pink Noise/HPF 250Hz.wav", "/Music/Pink Noise/HPF Reference.wav", 4, "HPF 25Hz", "HPF 750Hz", "HPF 250kHz" ),

                    ( 82, "HPF 500Hz", 1, "Identify the correct frequency of the pink noise.", "/Music/Pink Noise/HPF 500Hz.wav", "/Music/Pink Noise/HPF Reference.wav", 4, "HPF 5Hz", "HPF 50Hz", "HPF 5kHz" ),
                    ( 83, "HPF 500Hz", 2, "Identify the correct frequency of the pink noise.", "/Music/Pink Noise/HPF 500Hz.wav", "/Music/Pink Noise/HPF Reference.wav", 4, "HPF 5Hz", "HPF 50Hz", "HPF 5kHz" ),
                    ( 84, "HPF 500Hz", 3, "Identify the correct frequency of the pink noise.", "/Music/Pink Noise/HPF 500Hz.wav", "/Music/Pink Noise/HPF Reference.wav", 4, "HPF 5Hz", "HPF 50Hz", "HPF 5kHz" ),

                    ( 85, "HPF 1000Hz", 1, "Identify the correct frequency of the pink noise.", "/Music/Pink Noise/HPF 1000Hz.wav", "/Music/Pink Noise/HPF Reference.wav", 4, "HPF 100Hz", "HPF 10kHz", "HPF 1kHz" ),
                    ( 86, "HPF 1000Hz", 2, "Identify the correct frequency of the pink noise.", "/Music/Pink Noise/HPF 1000Hz.wav", "/Music/Pink Noise/HPF Reference.wav", 4, "HPF 100Hz", "HPF 10kHz", "HPF 1kHz" ),
                    ( 87, "HPF 1000Hz", 3, "Identify the correct frequency of the pink noise.", "/Music/Pink Noise/HPF 1000Hz.wav", "/Music/Pink Noise/HPF Reference.wav", 4, "HPF 100Hz", "HPF 10kHz", "HPF 1kHz" ),

                    ( 88, "LPF 1kHz", 1, "Identify the correct frequency of the pink noise.", "/Music/Pink Noise/LPF 1kHz.wav", "/Music/Pink Noise/LPF Reference.wav", 4, "LPF 1.5kHz", "LPF 10.5kHz", "LPF 100Hz" ),
                    ( 89, "LPF 1kHz", 2, "Identify the correct frequency of the pink noise.", "/Music/Pink Noise/LPF 1kHz.wav", "/Music/Pink Noise/LPF Reference.wav", 4, "LPF 1.5kHz", "LPF 10.5kHz", "LPF 100Hz" ),
                    ( 90, "LPF 1kHz", 3, "Identify the correct frequency of the pink noise.", "/Music/Pink Noise/LPF 1kHz.wav", "/Music/Pink Noise/LPF Reference.wav", 4, "LPF 1.5kHz", "LPF 10.5kHz", "LPF 100Hz" ),

                    ( 91, "LPF 2kHz", 1, "Identify the correct frequency of the pink noise.", "/Music/Pink Noise/LPF 2kHz.wav", "/Music/Pink Noise/LPF Reference.wav", 4, "LPF 2.5kHz", "LPF 250Hz", "LPF 200Hz" ),
                    ( 92, "LPF 2kHz", 2, "Identify the correct frequency of the pink noise.", "/Music/Pink Noise/LPF 2kHz.wav", "/Music/Pink Noise/LPF Reference.wav", 4, "LPF 2.5kHz", "LPF 250Hz", "LPF 200Hz" ),
                    ( 93, "LPF 2kHz", 3, "Identify the correct frequency of the pink noise.", "/Music/Pink Noise/LPF 2kHz.wav", "/Music/Pink Noise/LPF Reference.wav", 4, "LPF 2.5kHz", "LPF 250Hz", "LPF 200Hz" ),

                    ( 94, "LPF 4kHz", 1, "Identify the correct frequency of the pink noise.", "/Music/Pink Noise/LPF 4kHz.wav", "/Music/Pink Noise/LPF Reference.wav", 4, "LPF 45kHz", "LPF 450Hz", "LPF 400Hz" ),
                    ( 95, "LPF 4kHz", 2, "Identify the correct frequency of the pink noise.", "/Music/Pink Noise/LPF 4kHz.wav", "/Music/Pink Noise/LPF Reference.wav", 4, "LPF 45kHz", "LPF 450Hz", "LPF 400Hz" ),
                    ( 96, "LPF 4kHz", 3, "Identify the correct frequency of the pink noise.", "/Music/Pink Noise/LPF 4kHz.wav", "/Music/Pink Noise/LPF Reference.wav", 4, "LPF 45kHz", "LPF 450Hz", "LPF 400Hz" ),

                    ( 97, "LPF 8kHz", 1, "Identify the correct frequency of the pink noise.", "/Music/Pink Noise/LPF 8kHz.wav", "/Music/Pink Noise/LPF Reference.wav", 4, "LPF 80kHz", "LPF 5kHz", "LPF 800Hz" ),
                    ( 98, "LPF 8kHz", 2, "Identify the correct frequency of the pink noise.", "/Music/Pink Noise/LPF 8kHz.wav", "/Music/Pink Noise/LPF Reference.wav", 4, "LPF 80kHz", "LPF 5kHz", "LPF 800Hz" ),
                    ( 99, "LPF 8kHz", 3, "Identify the correct frequency of the pink noise.", "/Music/Pink Noise/LPF 8kHz.wav", "/Music/Pink Noise/LPF Reference.wav", 4, "LPF 80kHz", "LPF 5kHz", "LPF 800Hz" ),

                    ( 100, "80Hz 3rd octave", 1, "Identify the correct frequency of the pink noise.", "/Music/Pink Noise/80Hz 3rd Octave Noise.wav", "/Music/Pink Noise/200Hz 3rd Octave Noise.wav", 4, "20Hz 3rd octave", "500Hz 3rd octave", "160Hz 3rd octave" ),
                    ( 101, "100Hz 3rd octave", 1, "Identify the correct frequency of the pink noise.", "/Music/Pink Noise/100Hz 3rd Octave Noise.wav", "/Music/Pink Noise/250Hz 3rd Octave Noise.wav", 4, "50Hz 3rd octave", "500Hz 3rd octave", "200Hz 3rd octave" ),
                    ( 102, "125Hz 3rd octave", 1, "Identify the correct frequency of the pink noise.", "/Music/Pink Noise/125Hz 3rd Octave Noise.wav", "/Music/Pink Noise/315Hz 3rd Octave Noise.wav", 4, "50Hz 3rd octave", "500Hz 3rd octave", "250Hz 3rd octave" ),

                    ( 103, "160Hz 3rd octave", 1, "Identify the correct frequency of the pink noise.", "/Music/Pink Noise/160Hz 3rd Octave Noise.wav", "/Music/Pink Noise/400Hz 3rd Octave Noise.wav", 4, "80Hz 3rd octave", "1000Hz 3rd octave", "400Hz 3rd octave" ),
                    ( 104, "200Hz 3rd octave", 1, "Identify the correct frequency of the pink noise.", "/Music/Pink Noise/200Hz 3rd Octave Noise.wav", "/Music/Pink Noise/500Hz 3rd Octave Noise.wav", 4, "100Hz 3rd octave", "1000Hz 3rd octave", "500Hz 3rd octave" ),
                    ( 105, "250Hz 3rd octave", 1, "Identify the correct frequency of the pink noise.", "/Music/Pink Noise/250Hz 3rd Octave Noise.wav", "/Music/Pink Noise/630Hz 3rd Octave Noise.wav", 4, "125Hz 3rd octave", "1000Hz 3rd octave", "630Hz 3rd octave" ),

                    ( 106, "315Hz 3rd octave", 1, "Identify the correct frequency of the pink noise.", "/Music/Pink Noise/315Hz 3rd Octave Noise.wav", "/Music/Pink Noise/800Hz 3rd Octave Noise.wav", 4, "160Hz 3rd octave", "2000Hz 3rd octave", "800Hz 3rd octave" ),
                    ( 107, "400Hz 3rd octave", 1, "Identify the correct frequency of the pink noise.", "/Music/Pink Noise/400Hz 3rd Octave Noise.wav", "/Music/Pink Noise/1000Hz 3rd Octave Noise.wav", 4, "200Hz 3rd octave", "3150Hz 3rd octave", "1000Hz 3rd octave" ),
                    ( 108, "500Hz 3rd octave", 1, "Identify the correct frequency of the pink noise.", "/Music/Pink Noise/500Hz 3rd Octave Noise.wav", "/Music/Pink Noise/1250Hz 3rd Octave Noise.wav", 4, "250Hz 3rd octave", "3150Hz 3rd octave", "1250Hz 3rd octave" ),

                    ( 109, "630Hz 3rd octave", 1, "Identify the correct frequency of the pink noise.", "/Music/Pink Noise/630Hz 3rd Octave Noise.wav", "/Music/Pink Noise/1600Hz 3rd Octave Noise.wav", 4, "315Hz 3rd octave", "5000Hz 3rd octave", "2000Hz 3rd octave" ),
                    ( 110, "800Hz 3rd octave", 1, "Identify the correct frequency of the pink noise.", "/Music/Pink Noise/800Hz 3rd Octave Noise.wav", "/Music/Pink Noise/2000Hz 3rd Octave Noise.wav", 4, "400Hz 3rd octave", "4000Hz 3rd octave", "1600Hz 3rd octave" ),
                    ( 111, "1000Hz 3rd octave", 1, "Identify the correct frequency of the pink noise.", "/Music/Pink Noise/1000Hz 3rd Octave Noise.wav", "/Music/Pink Noise/2500Hz 3rd Octave Noise.wav", 4, "500Hz 3rd octave", "5000Hz 3rd octave", "2000Hz 3rd octave" ),

                    ( 112, "1250Hz 3rd octave", 1, "Identify the correct frequency of the pink noise.", "/Music/Pink Noise/1250Hz 3rd Octave Noise.wav", "/Music/Pink Noise/3150Hz 3rd Octave Noise.wav", 4, "630Hz 3rd octave", "8000Hz 3rd octave", "3150Hz 3rd octave" ),
                    ( 113, "1600Hz 3rd octave", 1, "Identify the correct frequency of the pink noise.", "/Music/Pink Noise/1600Hz 3rd Octave Noise.wav", "/Music/Pink Noise/4000Hz 3rd Octave Noise.wav", 4, "800Hz 3rd octave", "10000Hz 3rd octave", "4000Hz 3rd octave" ),
                    ( 114, "2000Hz 3rd octave", 1, "Identify the correct frequency of the pink noise.", "/Music/Pink Noise/2000Hz 3rd Octave Noise.wav", "/Music/Pink Noise/5000Hz 3rd Octave Noise.wav", 4, "1000Hz 3rd octave", "12500Hz 3rd octave", "5000Hz 3rd octave" ),

                    ( 115, "2500Hz 3rd octave", 1, "Identify the correct frequency of the pink noise.", "/Music/Pink Noise/2500Hz 3rd Octave Noise.wav", "/Music/Pink Noise/6300Hz 3rd Octave Noise.wav", 4, "1250Hz 3rd octave", "16000Hz 3rd octave", "6300Hz 3rd octave" ),
                    ( 116, "3150Hz 3rd octave", 1, "Identify the correct frequency of the pink noise.", "/Music/Pink Noise/3150Hz 3rd Octave Noise.wav", "/Music/Pink Noise/8000Hz 3rd Octave Noise.wav", 4, "1600Hz 3rd octave", "20000Hz 3rd octave", "8000Hz 3rd octave" ),
                    ( 117, "4000Hz 3rd octave", 1, "Identify the correct frequency of the pink noise.", "/Music/Pink Noise/4000Hz 3rd Octave Noise.wav", "/Music/Pink Noise/10000Hz 3rd Octave Noise.wav", 4, "2000Hz 3rd octave", "25000Hz 3rd octave", "10000Hz 3rd octave" ),

                    ( 118, "5000Hz 3rd octave", 1, "Identify the correct frequency of the pink noise.", "/Music/Pink Noise/5000Hz 3rd Octave Noise.wav", "/Music/Pink Noise/12500Hz 3rd Octave Noise.wav", 4, "2500Hz 3rd octave", "31500Hz 3rd octave", "12500Hz 3rd octave" ),
                    ( 119, "6300Hz 3rd octave", 1, "Identify the correct frequency of the pink noise.", "/Music/Pink Noise/6300Hz 3rd Octave Noise.wav", "/Music/Pink Noise/16000Hz 3rd Octave Noise.wav", 4, "3150Hz 3rd octave", "40000Hz 3rd octave", "16000Hz 3rd octave" ),
                    ( 120, "8000Hz 3rd octave", 1, "Identify the correct frequency of the pink noise.", "/Music/Pink Noise/8000Hz 3rd Octave Noise.wav", "/Music/Pink Noise/2000Hz 3rd Octave Noise.wav", 4, "4000Hz 3rd octave", "50000Hz 3rd octave", "20000Hz 3rd octave" ),

                    ( 121, "10000Hz 3rd octave", 1, "Identify the correct frequency of the pink noise.", "/Music/Pink Noise/10000Hz 3rd Octave Noise.wav", "/Music/Pink Noise/3150Hz 3rd Octave Noise.wav", 4, "5000Hz 3rd octave", "63000Hz 3rd octave", "25000Hz 3rd octave" ),
                    ( 122, "12500Hz 3rd octave", 1, "Identify the correct frequency of the pink noise.", "/Music/Pink Noise/12500Hz 3rd Octave Noise.wav", "/Music/Pink Noise/5000Hz 3rd Octave Noise.wav", 4, "6300Hz 3rd octave", "80000Hz 3rd octave", "31500Hz 3rd octave" ),
                    ( 123, "16000Hz 3rd octave", 1, "Identify the correct frequency of the pink noise.", "/Music/Pink Noise/16000Hz 3rd Octave Noise.wav", "/Music/Pink Noise/1250Hz 3rd Octave Noise.wav", 4, "8000Hz 3rd octave", "100000Hz 3rd octave", "40000Hz 3rd octave" ),

                    ( 124, "80Hz 3rd octave", 2, "Identify the correct frequency of the pink noise.", "/Music/Pink Noise/80Hz 3rd Octave Noise.wav", "/Music/Pink Noise/200Hz 3rd Octave Noise.wav", 4, "30Hz 3rd octave", "400Hz 3rd octave", "160Hz 3rd octave" ),
                    ( 125, "100Hz 3rd octave", 2, "Identify the correct frequency of the pink noise.", "/Music/Pink Noise/100Hz 3rd Octave Noise.wav", "/Music/Pink Noise/250Hz 3rd Octave Noise.wav", 4, "50Hz 3rd octave", "400Hz 3rd octave", "200Hz 3rd octave" ),
                    ( 126, "125Hz 3rd octave", 2, "Identify the correct frequency of the pink noise.", "/Music/Pink Noise/125Hz 3rd Octave Noise.wav", "/Music/Pink Noise/315Hz 3rd Octave Noise.wav", 4, "60Hz 3rd octave", "500Hz 3rd octave", "250Hz 3rd octave" ),

                    ( 127, "160Hz 3rd octave", 2, "Identify the correct frequency of the pink noise.", "/Music/Pink Noise/160Hz 3rd Octave Noise.wav", "/Music/Pink Noise/400Hz 3rd Octave Noise.wav", 4, "80Hz 3rd octave", "630Hz 3rd octave", "315Hz 3rd octave" ),
                    ( 128, "200Hz 3rd octave", 2, "Identify the correct frequency of the pink noise.", "/Music/Pink Noise/200Hz 3rd Octave Noise.wav", "/Music/Pink Noise/500Hz 3rd Octave Noise.wav", 4, "100Hz 3rd octave", "800Hz 3rd octave", "400Hz 3rd octave" ),
                    ( 129, "250Hz 3rd octave", 2, "Identify the correct frequency of the pink noise.", "/Music/Pink Noise/250Hz 3rd Octave Noise.wav", "/Music/Pink Noise/630Hz 3rd Octave Noise.wav", 4, "125Hz 3rd octave", "1000Hz 3rd octave", "500Hz 3rd octave" ),

                    ( 130, "315Hz 3rd octave", 2, "Identify the correct frequency of the pink noise.", "/Music/Pink Noise/315Hz 3rd Octave Noise.wav", "/Music/Pink Noise/800Hz 3rd Octave Noise.wav", 4, "160Hz 3rd octave", "1250Hz 3rd octave", "630Hz 3rd octave" ),
                    ( 131, "400Hz 3rd octave", 2, "Identify the correct frequency of the pink noise.", "/Music/Pink Noise/400Hz 3rd Octave Noise.wav", "/Music/Pink Noise/1000Hz 3rd Octave Noise.wav", 4, "200Hz 3rd octave", "1600Hz 3rd octave", "800Hz 3rd octave" ),
                    ( 132, "500Hz 3rd octave", 2, "Identify the correct frequency of the pink noise.", "/Music/Pink Noise/500Hz 3rd Octave Noise.wav", "/Music/Pink Noise/1250Hz 3rd Octave Noise.wav", 4, "250Hz 3rd octave", "2000Hz 3rd octave", "1000Hz 3rd octave" ),

                    ( 133, "630Hz 3rd octave", 2, "Identify the correct frequency of the pink noise.", "/Music/Pink Noise/630Hz 3rd Octave Noise.wav", "/Music/Pink Noise/1600Hz 3rd Octave Noise.wav", 4, "315Hz 3rd octave", "2500Hz 3rd octave", "1250Hz 3rd octave" ),
                    ( 134, "800Hz 3rd octave", 2, "Identify the correct frequency of the pink noise.", "/Music/Pink Noise/800Hz 3rd Octave Noise.wav", "/Music/Pink Noise/2000Hz 3rd Octave Noise.wav", 4, "400Hz 3rd octave", "3150Hz 3rd octave", "1600Hz 3rd octave" ),
                    ( 135, "1000Hz 3rd octave", 2, "Identify the correct frequency of the pink noise.", "/Music/Pink Noise/1000Hz 3rd Octave Noise.wav", "/Music/Pink Noise/2500Hz 3rd Octave Noise.wav", 4, "500Hz 3rd octave", "4000Hz 3rd octave", "2000Hz 3rd octave" ),

                    ( 136, "1250Hz 3rd octave", 2, "Identify the correct frequency of the pink noise.", "/Music/Pink Noise/1250Hz 3rd Octave Noise.wav", "/Music/Pink Noise/3150Hz 3rd Octave Noise.wav", 4, "630Hz 3rd octave", "5000Hz 3rd octave", "2500Hz 3rd octave" ),
                    ( 137, "1600Hz 3rd octave", 2, "Identify the correct frequency of the pink noise.", "/Music/Pink Noise/1600Hz 3rd Octave Noise.wav", "/Music/Pink Noise/4000Hz 3rd Octave Noise.wav", 4, "800Hz 3rd octave", "6300Hz 3rd octave", "3150Hz 3rd octave" ),
                    ( 138, "2000Hz 3rd octave", 2, "Identify the correct frequency of the pink noise.", "/Music/Pink Noise/2000Hz 3rd Octave Noise.wav", "/Music/Pink Noise/5000Hz 3rd Octave Noise.wav", 4, "1000Hz 3rd octave", "8000Hz 3rd octave", "4000Hz 3rd octave" ),

                    ( 139, "2500Hz 3rd octave", 2, "Identify the correct frequency of the pink noise.", "/Music/Pink Noise/2500Hz 3rd Octave Noise.wav", "/Music/Pink Noise/6300Hz 3rd Octave Noise.wav", 4, "1250Hz 3rd octave", "10000Hz 3rd octave", "5000Hz 3rd octave" ),
                    ( 140, "3150Hz 3rd octave", 2, "Identify the correct frequency of the pink noise.", "/Music/Pink Noise/3150Hz 3rd Octave Noise.wav", "/Music/Pink Noise/8000Hz 3rd Octave Noise.wav", 4, "1600Hz 3rd octave", "12500Hz 3rd octave", "6300Hz 3rd octave" ),
                    ( 141, "4000Hz 3rd octave", 2, "Identify the correct frequency of the pink noise.", "/Music/Pink Noise/4000Hz 3rd Octave Noise.wav", "/Music/Pink Noise/10000Hz 3rd Octave Noise.wav", 4, "2000Hz 3rd octave", "16000Hz 3rd octave", "8000Hz 3rd octave" ),

                    ( 142, "5000Hz 3rd octave", 2, "Identify the correct frequency of the pink noise.", "/Music/Pink Noise/5000Hz 3rd Octave Noise.wav", "/Music/Pink Noise/12500Hz 3rd Octave Noise.wav", 4, "2500Hz 3rd octave", "20000Hz 3rd octave", "10000Hz 3rd octave" ),
                    ( 143, "6300Hz 3rd octave", 2, "Identify the correct frequency of the pink noise.", "/Music/Pink Noise/6300Hz 3rd Octave Noise.wav", "/Music/Pink Noise/16000Hz 3rd Octave Noise.wav", 4, "3150Hz 3rd octave", "25000Hz 3rd octave", "12500Hz 3rd octave" ),
                    ( 144, "8000Hz 3rd octave", 2, "Identify the correct frequency of the pink noise.", "/Music/Pink Noise/8000Hz 3rd Octave Noise.wav", "/Music/Pink Noise/2000Hz 3rd Octave Noise.wav", 4, "4000Hz 3rd octave", "31500Hz 3rd octave", "16000Hz 3rd octave" ),

                    ( 145, "10000Hz 3rd octave", 2, "Identify the correct frequency of the pink noise.", "/Music/Pink Noise/10000Hz 3rd Octave Noise.wav", "/Music/Pink Noise/3150Hz 3rd Octave Noise.wav", 4, "5000Hz 3rd octave", "40000Hz 3rd octave", "20000Hz 3rd octave" ),
                    ( 146, "12500Hz 3rd octave", 2, "Identify the correct frequency of the pink noise.", "/Music/Pink Noise/12500Hz 3rd Octave Noise.wav", "/Music/Pink Noise/5000Hz 3rd Octave Noise.wav", 4, "6300Hz 3rd octave", "50000Hz 3rd octave", "25000Hz 3rd octave" ),
                    ( 147, "16000Hz 3rd octave", 2, "Identify the correct frequency of the pink noise.", "/Music/Pink Noise/16000Hz 3rd Octave Noise.wav", "/Music/Pink Noise/1250Hz 3rd Octave Noise.wav", 4, "8000Hz 3rd octave", "63000Hz 3rd octave", "31500Hz 3rd octave" ),

                    ( 148, "80Hz 3rd octave", 3, "Identify the correct frequency of the pink noise.", "/Music/Pink Noise/80Hz 3rd Octave Noise.wav", "/Music/Pink Noise/125Hz 3rd Octave Noise.wav", 4, "70Hz 3rd octave", "120Hz 3rd octave", "90Hz 3rd octave" ),
                    ( 149, "100Hz 3rd octave", 3, "Identify the correct frequency of the pink noise.", "/Music/Pink Noise/100Hz 3rd Octave Noise.wav", "/Music/Pink Noise/160Hz 3rd Octave Noise.wav", 4, "85Hz 3rd octave", "140Hz 3rd octave", "115Hz 3rd octave" ),
                    ( 150, "125Hz 3rd octave", 3, "Identify the correct frequency of the pink noise.", "/Music/Pink Noise/125Hz 3rd Octave Noise.wav", "/Music/Pink Noise/200Hz 3rd Octave Noise.wav", 4, "110Hz 3rd octave", "180Hz 3rd octave", "140Hz 3rd octave" ),

                    ( 151, "160Hz 3rd octave", 3, "Identify the correct frequency of the pink noise.", "/Music/Pink Noise/160Hz 3rd Octave Noise.wav", "/Music/Pink Noise/250Hz 3rd Octave Noise.wav", 4, "140Hz 3rd octave", "220Hz 3rd octave", "180Hz 3rd octave" ),
                    ( 152, "200Hz 3rd octave", 3, "Identify the correct frequency of the pink noise.", "/Music/Pink Noise/200Hz 3rd Octave Noise.wav", "/Music/Pink Noise/315Hz 3rd Octave Noise.wav", 4, "180Hz 3rd octave", "280Hz 3rd octave", "220Hz 3rd octave" ),
                    ( 153, "250Hz 3rd octave", 3, "Identify the correct frequency of the pink noise.", "/Music/Pink Noise/250Hz 3rd Octave Noise.wav", "/Music/Pink Noise/400Hz 3rd Octave Noise.wav", 4, "220Hz 3rd octave", "340Hz 3rd octave", "280Hz 3rd octave" ),

                    ( 154, "315Hz 3rd octave", 3, "Identify the correct frequency of the pink noise.", "/Music/Pink Noise/315Hz 3rd Octave Noise.wav", "/Music/Pink Noise/500Hz 3rd Octave Noise.wav", 4, "280Hz 3rd octave", "410Hz 3rd octave", "350Hz 3rd octave" ),
                    ( 155, "400Hz 3rd octave", 3, "Identify the correct frequency of the pink noise.", "/Music/Pink Noise/400Hz 3rd Octave Noise.wav", "/Music/Pink Noise/630Hz 3rd Octave Noise.wav", 4, "360Hz 3rd octave", "500Hz 3rd octave", "440Hz 3rd octave" ),
                    ( 156, "500Hz 3rd octave", 3, "Identify the correct frequency of the pink noise.", "/Music/Pink Noise/500Hz 3rd Octave Noise.wav", "/Music/Pink Noise/800Hz 3rd Octave Noise.wav", 4, "450Hz 3rd octave", "630Hz 3rd octave", "550Hz 3rd octave" ),

                    ( 157, "630Hz 3rd octave", 3, "Identify the correct frequency of the pink noise.", "/Music/Pink Noise/630Hz 3rd Octave Noise.wav", "/Music/Pink Noise/1000Hz 3rd Octave Noise.wav", 4, "580Hz 3rd octave", "800Hz 3rd octave", "680Hz 3rd octave" ),
                    ( 158, "800Hz 3rd octave", 3, "Identify the correct frequency of the pink noise.", "/Music/Pink Noise/800Hz_3rd Octave Noise.wav", "/Music/Pink Noise/1250Hz 3rd Octave Noise.wav", 4, "700Hz 3rd octave", "1000Hz 3rd octave", "880Hz 3rd octave" ),
                    ( 159, "1000Hz 3rd octave", 3, "Identify the correct frequency of the pink noise.", "/Music/Pink Noise/1000Hz 3rd Octave Noise.wav", "/Music/Pink Noise/1600Hz 3rd Octave Noise.wav", 4, "880Hz 3rd octave", "1250Hz 3rd octave", "1100Hz 3rd octave" ),

                    ( 160, "1250Hz 3rd octave", 3, "Identify the correct frequency of the pink noise.", "/Music/Pink Noise/1250Hz 3rd Octave Noise.wav", "/Music/Pink Noise/2000Hz 3rd Octave Noise.wav", 4, "1100Hz 3rd octave", "1600Hz 3rd octave", "1400Hz 3rd octave" ),
                    ( 161, "1600Hz 3rd octave", 3, "Identify the correct frequency of the pink noise.", "/Music/Pink Noise/1600Hz 3rd Octave Noise.wav", "/Music/Pink Noise/2500Hz 3rd Octave Noise.wav", 4, "1400Hz 3rd octave", "2000Hz 3rd octave", "1800Hz 3rd octave" ),
                    ( 162, "2000Hz 3rd octave", 3, "Identify the correct frequency of the pink noise.", "/Music/Pink Noise/2000Hz 3rd Octave Noise.wav", "/Music/Pink Noise/3150Hz 3rd Octave Noise.wav", 4, "1800Hz 3rd octave", "2500Hz 3rd octave", "2200Hz 3rd octave" ),

                    ( 163, "2500Hz 3rd octave", 3, "Identify the correct frequency of the pink noise.", "/Music/Pink Noise/2500Hz 3rd Octave Noise.wav", "/Music/Pink Noise/4000Hz 3rd Octave Noise.wav", 4, "2200Hz 3rd octave", "3150Hz 3rd octave", "2800Hz 3rd octave" ),
                    ( 164, "3150Hz 3rd octave", 3, "Identify the correct frequency of the pink noise.", "/Music/Pink Noise/3150Hz 3rd Octave Noise.wav", "/Music/Pink Noise/5000Hz 3rd Octave Noise.wav", 4, "2800Hz 3rd octave", "4000Hz 3rd octave", "3500Hz 3rd octave" ),
                    ( 165, "4000Hz 3rd octave", 3, "Identify the correct frequency of the pink noise.", "/Music/Pink Noise/4000Hz 3rd Octave Noise.wav", "/Music/Pink Noise/6300Hz 3rd Octave Noise.wav", 4, "3500Hz 3rd octave", "5000Hz 3rd octave", "4500Hz 3rd octave" ),

                    ( 166, "5000Hz 3rd octave", 3, "Identify the correct frequency of the pink noise.", "/Music/Pink Noise/5000Hz 3rd Octave Noise.wav", "/Music/Pink Noise/8000Hz 3rd Octave Noise.wav", 4, "4400Hz 3rd octave", "6300Hz 3rd octave", "5600Hz 3rd octave" ),
                    ( 167, "6300Hz 3rd octave", 3, "Identify the correct frequency of the pink noise.", "/Music/Pink Noise/6300Hz 3rd Octave Noise.wav", "/Music/Pink Noise/10000Hz 3rd Octave Noise.wav", 4, "5600Hz 3rd octave", "8000Hz 3rd octave", "6800Hz 3rd octave" ),
                    ( 168, "8000Hz 3rd octave", 3, "Identify the correct frequency of the pink noise.", "/Music/Pink Noise/8000Hz 3rd Octave Noise.wav", "/Music/Pink Noise/12500Hz 3rd Octave Noise.wav", 4, "7000Hz 3rd octave", "10000Hz 3rd octave", "8800Hz 3rd octave" ),

                    ( 169, "10000Hz 3rd octave", 3, "Identify the correct frequency of the pink noise.", "/Music/Pink Noise/10000Hz 3rd Octave Noise.wav", "/Music/Pink Noise/16000Hz 3rd Octave Noise.wav", 4, "8800Hz 3rd octave", "12500Hz 3rd octave", "11200Hz 3rd octave" ),
                    ( 170, "12500Hz 3rd octave", 3, "Identify the correct frequency of the pink noise.", "/Music/Pink Noise/12500Hz 3rd Octave Noise.wav", "/Music/Pink Noise/20000Hz 3rd Octave Noise.wav", 4, "11200Hz 3rd octave", "16000Hz 3rd octave", "14000Hz 3rd octave" ),
                    ( 171, "16000Hz 3rd octave", 3, "Identify the correct frequency of the pink noise.", "/Music/Pink Noise/16000Hz 3rd Octave Noise.wav", "/Music/Pink Noise/2500Hz 3rd Octave Noise.wav", 4, "14000Hz 3rd octave", "20000Hz 3rd octave", "18000Hz 3rd octave" ),

                    ( 172, "Minus 1kHz Octave", 1, "Identify the correct frequency of the pink noise.", "/Music/Pink Noise/Minus 1kHz Octave.wav", "/Music/Pink Noise/Minus Reference.wav", 4, "Minus 2kHz Octave", "Minus 4kHz Octave", "Minus 8kHz Octave" ),
                    ( 173, "Minus 2kHz Octave", 1, "Identify the correct frequency of the pink noise.", "/Music/Pink Noise/Minus 2kHz Octave.wav", "/Music/Pink Noise/Minus Reference.wav", 4, "Minus 1kHz Octave", "Minus 4kHz Octave", "Minus 8kHz Octave" ),
                    ( 174, "Minus 4kHz Octave", 1, "Identify the correct frequency of the pink noise.", "/Music/Pink Noise/Minus 4kHz Octave.wav", "/Music/Pink Noise/Minus Reference.wav", 4, "Minus 2kHz Octave", "Minus 1kHz Octave", "Minus 8kHz Octave" ),

                    ( 175, "Minus 8kHz Octave", 1, "Identify the correct frequency of the pink noise.", "/Music/Pink Noise/Minus 8kHz Octave.wav", "/Music/Pink Noise/Minus Reference.wav", 4, "Minus 4kHz Octave", "Minus 2kHz Octave", "Minus 1kHz Octave" ),
                    ( 176, "Minus 125Hz Octave", 1, "Identify the correct frequency of the pink noise.", "/Music/Pink Noise/Minus 125Hz Octave.wav", "/Music/Pink Noise/Minus Reference.wav", 4, "Minus 250Hz Octave", "Minus 500Hz Octave", "Minus 1kHz Octave" ),
                    ( 177, "Minus 250Hz Octave", 1, "Identify the correct frequency of the pink noise.", "/Music/Pink Noise/Minus 250Hz Octave.wav", "/Music/Pink Noise/Minus Reference.wav", 4, "Minus 125Hz Octave", "Minus 500Hz Octave", "Minus 1kHz Octave" ),

                    ( 178, "Minus 500Hz Octave", 1, "Identify the correct frequency of the pink noise.", "/Music/Pink Noise/Minus 500Hz Octave.wav", "/Music/Pink Noise/Minus Reference.wav", 4, "Minus 250Hz Octave", "Minus 125Hz Octave", "Minus 1kHz Octave" ),
                    ( 179, "Minus 1kHz Octave", 2, "Identify the correct frequency of the pink noise.", "/Music/Pink Noise/Minus 1kHz Octave.wav", "/Music/Pink Noise/Minus Reference.wav", 4, "Minus 2kHz Octave", "Minus 4kHz Octave", "Minus 8kHz Octave" ),
                    ( 180, "Minus 2kHz Octave", 2, "Identify the correct frequency of the pink noise.", "/Music/Pink Noise/Minus 2kHz Octave.wav", "/Music/Pink Noise/Minus Reference.wav", 4, "Minus 1kHz Octave", "Minus 4kHz Octave", "Minus 8kHz Octave" ),

                    ( 181, "Minus 4kHz Octave", 2, "Identify the correct frequency of the pink noise.", "/Music/Pink Noise/Minus 4kHz Octave.wav", "/Music/Pink Noise/Minus Reference.wav", 4, "Minus 2kHz Octave", "Minus 1kHz Octave", "Minus 8kHz Octave" ),
                    ( 182, "Minus 8kHz Octave", 2, "Identify the correct frequency of the pink noise.", "/Music/Pink Noise/Minus 8kHz Octave.wav", "/Music/Pink Noise/Minus Reference.wav", 4, "Minus 4kHz Octave", "Minus 2kHz Octave", "Minus 1kHz Octave" ),
                    ( 183, "Minus 125Hz Octave", 2, "Identify the correct frequency of the pink noise.", "/Music/Pink Noise/Minus 125Hz Octave.wav", "/Music/Pink Noise/Minus Reference.wav", 4, "Minus 250Hz Octave", "Minus 500Hz Octave", "Minus 1kHz Octave" ),

                    ( 184, "Minus 250Hz Octave", 2, "Identify the correct frequency of the pink noise.", "/Music/Pink Noise/Minus 250Hz Octave.wav", "/Music/Pink Noise/Minus Reference.wav", 4, "Minus 125Hz Octave", "Minus 500Hz Octave", "Minus 1kHz Octave" ),
                    ( 185, "Minus 500Hz Octave", 2, "Identify the correct frequency of the pink noise.", "/Music/Pink Noise/Minus 500Hz Octave.wav", "/Music/Pink Noise/Minus Reference.wav", 4, "Minus 250Hz Octave", "Minus 125Hz Octave", "Minus 1kHz Octave" ),
                    ( 186, "Minus 1kHz Octave", 3, "Identify the correct frequency of the pink noise.", "/Music/Pink Noise/Minus 1kHz Octave.wav", "/Music/Pink Noise/Minus Reference.wav", 4, "Minus 2kHz Octave", "Minus 4kHz Octave", "Minus 8kHz Octave" ),

                    ( 187, "Minus 2kHz Octave", 3, "Identify the correct frequency of the pink noise.", "/Music/Pink Noise/Minus 2kHz Octave.wav", "/Music/Pink Noise/Minus Reference.wav", 4, "Minus 1kHz Octave", "Minus 4kHz Octave", "Minus 8kHz Octave" ),
                    ( 188, "Minus 4kHz Octave", 3, "Identify the correct frequency of the pink noise.", "/Music/Pink Noise/Minus 4kHz Octave.wav", "/Music/Pink Noise/Minus Reference.wav", 4, "Minus 2kHz Octave", "Minus 1kHz Octave", "Minus 8kHz Octave" ),
                    ( 189, "Minus 8kHz Octave", 3, "Identify the correct frequency of the pink noise.", "/Music/Pink Noise/Minus 8kHz Octave.wav", "/Music/Pink Noise/Minus Reference.wav", 4, "Minus 4kHz Octave", "Minus 2kHz Octave", "Minus 1kHz Octave" ),

                    ( 190, "Minus 125Hz Octave", 3, "Identify the correct frequency of the pink noise.", "/Music/Pink Noise/Minus 125Hz Octave.wav", "/Music/Pink Noise/Minus Reference.wav", 4, "Minus 250Hz Octave", "Minus 500Hz Octave", "Minus 1kHz Octave" ),
                    ( 191, "Minus 250Hz Octave", 3, "Identify the correct frequency of the pink noise.", "/Music/Pink Noise/Minus 250Hz Octave.wav", "/Music/Pink Noise/Minus Reference.wav", 4, "Minus 125Hz Octave", "Minus 500Hz Octave", "Minus 1kHz Octave" ),
                    ( 192, "Minus 500Hz Octave", 3, "Identify the correct frequency of the pink noise.", "/Music/Pink Noise/Minus 500Hz Octave.wav", "/Music/Pink Noise/Minus Reference.wav", 4, "Minus 250Hz Octave", "Minus 125Hz Octave", "Minus 1kHz Octave" ),

                    ( 193, "HPF 125Hz", 1, "Identify the correct frequency of the ensemble.", "/Music/Ensembles/Ensemble 1 HPF 125Hz.wav", "/Music/Ensembles/Ensemble 1 Reference.wav", 2, "HPF 250Hz", "HPF 1kHz", "HPF 500Hz" ),
                    ( 194, "HPF 250Hz", 1, "Identify the correct frequency of the ensemble.", "/Music/Ensembles/Ensemble 1 HPF 250Hz.wav", "/Music/Ensembles/Ensemble 1 Reference.wav", 2, "HPF 125Hz", "HPF 1kHz", "HPF 500Hz" ),
                    ( 195, "HPF 500Hz", 1, "Identify the correct frequency of the ensemble.", "/Music/Ensembles/Ensemble 1 HPF 500Hz.wav", "/Music/Ensembles/Ensemble 1 Reference.wav", 2, "HPF 125Hz", "HPF 1kHz", "HPF 250Hz" ),

                    ( 196, "HPF 1kHz", 1, "Identify the correct frequency of the ensemble.", "/Music/Ensembles/Ensemble 1 HPF 1000Hz.wav", "/Music/Ensembles/Ensemble 1 Reference.wav", 2, "HPF 125Hz", "HPF 500Hz", "HPF 250Hz" ),
                    ( 197, "LPF 1kHz", 1, "Identify the correct frequency of the ensemble.", "/Music/Ensembles/Ensemble 1 LPF 1kHz.wav", "/Music/Ensembles/Ensemble 1 Reference.wav", 2, "LPF 2kHz", "LPF 8kHz", "LPF 4kHz" ),
                    ( 198, "LPF 2kHz", 1, "Identify the correct frequency of the ensemble.", "/Music/Ensembles/Ensemble 1 LPF 2kHz.wav", "/Music/Ensembles/Ensemble 1 Reference.wav", 2, "LPF 1kHz", "LPF 8kHz", "LPF 4kHz" ),

                    ( 199, "LPF 4kHz", 1, "Identify the correct frequency of the ensemble.", "/Music/Ensembles/Ensemble 1 LPF 4kHz.wav", "/Music/Ensembles/Ensemble 1 Reference.wav", 2, "LPF 1kHz", "LPF 8kHz", "LPF 2kHz" ),
                    ( 200, "LPF 8kHz", 1, "Identify the correct frequency of the ensemble.", "/Music/Ensembles/Ensemble 1 LPF 8kHz.wav", "/Music/Ensembles/Ensemble 1 Reference.wav", 2, "LPF 1kHz", "LPF 4kHz", "LPF 2kHz" ),
                    ( 201, "Minus 1kHz Octave", 1, "Identify the correct frequency of the ensemble.", "/Music/Ensembles/Ensemble 1 Minus 1kHz Octave.wav", "/Music/Ensembles/Ensemble 1 Reference.wav", 2, "Minus 2kHz Octave", "Minus 8kHz Octave", "Minus 4kHz Octave" ),

                    ( 202, "Minus 2kHz Octave", 1, "Identify the correct frequency of the ensemble.", "/Music/Ensembles/Ensemble 1 Minus 2kHz Octave.wav", "/Music/Ensembles/Ensemble 1 Reference.wav", 2, "Minus 1kHz Octave", "Minus 8kHz Octave", "Minus 4kHz Octave" ),
                    ( 203, "Minus 4kHz Octave", 1, "Identify the correct frequency of the ensemble.", "/Music/Ensembles/Ensemble 1 Minus 4kHz Octave.wav", "/Music/Ensembles/Ensemble 1 Reference.wav", 2, "Minus 1kHz Octave", "Minus 8kHz Octave", "Minus 2kHz Octave" ),
                    ( 204, "Minus 8kHz Octave", 1, "Identify the correct frequency of the ensemble.", "/Music/Ensembles/Ensemble 1 Minus 8kHz Octave.wav", "/Music/Ensembles/Ensemble 1 Reference.wav", 2, "Minus 1kHz Octave", "Minus 4kHz Octave", "Minus 2kHz Octave" ),

                    ( 205, "Minus 125Hz Octave", 1, "Identify the correct frequency of the ensemble.", "/Music/Ensembles/Ensemble 1 Minus 125Hz Octave.wav", "/Music/Ensembles/Ensemble 1 Reference.wav", 2, "Minus 250Hz Octave", "Minus 1kHz Octave", "Minus 500Hz Octave" ),
                    ( 206, "Minus 250Hz Octave", 1, "Identify the correct frequency of the ensemble.", "/Music/Ensembles/Ensemble 1 Minus 250Hz Octave.wav", "/Music/Ensembles/Ensemble 1 Reference.wav", 2, "Minus 125Hz Octave", "Minus 1kHz Octave", "Minus 500Hz Octave" ),
                    ( 207, "Minus 500Hz Octave", 1, "Identify the correct frequency of the ensemble.", "/Music/Ensembles/Ensemble 1 Minus 500Hz Octave.wav", "/Music/Ensembles/Ensemble 1 Reference.wav", 2, "Minus 125Hz Octave", "Minus 1kHz Octave", "Minus 250Hz Octave" ),

                    ( 208, "HPF 125Hz", 2, "Identify the correct frequency of the ensemble.", "/Music/Ensembles/Ensemble 1 HPF 125Hz.wav", "/Music/Ensembles/Ensemble 1 Reference.wav", 2, "HPF 110Hz", "HPF 150Hz", "HPF 135Hz" ),
                    ( 209, "HPF 250Hz", 2, "Identify the correct frequency of the ensemble.", "/Music/Ensembles/Ensemble 1 HPF 250Hz.wav", "/Music/Ensembles/Ensemble 1 Reference.wav", 2, "HPF 230Hz", "HPF 275Hz", "HPF 260Hz" ),
                    ( 210, "HPF 500Hz", 2, "Identify the correct frequency of the ensemble.", "/Music/Ensembles/Ensemble 1 HPF 500Hz.wav", "/Music/Ensembles/Ensemble 1 Reference.wav", 2, "HPF 475Hz", "HPF 550Hz", "HPF 525Hz" ),

                    ( 211, "HPF 1kHz", 2, "Identify the correct frequency of the ensemble.", "/Music/Ensembles/Ensemble 1 HPF 1000Hz.wav", "/Music/Ensembles/Ensemble 1 Reference.wav", 2, "HPF 950Hz", "HPF 1100Hz", "HPF 1050Hz" ),
                    ( 212, "LPF 1kHz", 2, "Identify the correct frequency of the ensemble.", "/Music/Ensembles/Ensemble 1 LPF 1kHz.wav", "/Music/Ensembles/Ensemble 1 Reference.wav", 2, "LPF 950Hz", "LPF 1100Hz", "LPF 1050Hz" ),
                    ( 213, "LPF 2kHz", 2, "Identify the correct frequency of the ensemble.", "/Music/Ensembles/Ensemble 1 LPF 2kHz.wav", "/Music/Ensembles/Ensemble 1 Reference.wav", 2, "LPF 1900Hz", "LPF 2100Hz", "LPF 2050Hz" ),

                    ( 214, "LPF 4kHz", 2, "Identify the correct frequency of the ensemble.", "/Music/Ensembles/Ensemble 1 LPF 4kHz.wav", "/Music/Ensembles/Ensemble 1 Reference.wav", 2, "LPF 3900Hz", "LPF 4200Hz", "LPF 4100Hz" ),
                    ( 215, "LPF 8kHz", 2, "Identify the correct frequency of the ensemble.", "/Music/Ensembles/Ensemble 1 LPF 8kHz.wav", "/Music/Ensembles/Ensemble 1 Reference.wav", 2, "LPF 7800Hz", "LPF 8500Hz", "LPF 8100Hz" ),
                    ( 216, "Minus 1kHz Octave", 2, "Identify the correct frequency of the ensemble.", "/Music/Ensembles/Ensemble 1 Minus 1kHz Octave.wav", "/Music/Ensembles/Ensemble 1 Reference.wav", 2, "Minus 950Hz Octave", "Minus 1100Hz Octave", "Minus 1050Hz Octave" ),

                    ( 217, "Minus 2kHz Octave", 2, "Identify the correct frequency of the ensemble.", "/Music/Ensembles/Ensemble 1 Minus 2kHz Octave.wav", "/Music/Ensembles/Ensemble 1 Reference.wav", 2, "Minus 1900Hz Octave", "Minus 2100Hz Octave", "Minus 2050Hz Octave" ),
                    ( 218, "Minus 4kHz Octave", 2, "Identify the correct frequency of the ensemble.", "/Music/Ensembles/Ensemble 1 Minus 4kHz Octave.wav", "/Music/Ensembles/Ensemble 1 Reference.wav", 2, "Minus 3900Hz Octave", "Minus 4200Hz Octave", "Minus 4100Hz Octave" ),
                    ( 219, "Minus 8kHz Octave", 2, "Identify the correct frequency of the ensemble.", "/Music/Ensembles/Ensemble 1 Minus 8kHz Octave.wav", "/Music/Ensembles/Ensemble 1 Reference.wav", 2, "Minus 7800Hz Octave", "Minus 8500Hz Octave", "Minus 8100Hz Octave" ),

                    ( 220, "Minus 125Hz Octave", 2, "Identify the correct frequency of the ensemble.", "/Music/Ensembles/Ensemble 1 Minus 125Hz Octave.wav", "/Music/Ensembles/Ensemble 1 Reference.wav", 2, "Minus 110Hz Octave", "Minus 150Hz Octave", "Minus 135Hz Octave" ),
                    ( 221, "Minus 250Hz Octave", 2, "Identify the correct frequency of the ensemble.", "/Music/Ensembles/Ensemble 1 Minus 250Hz Octave.wav", "/Music/Ensembles/Ensemble 1 Reference.wav", 2, "Minus 230Hz Octave", "Minus 275Hz Octave", "Minus 260Hz Octave" ),
                    ( 222, "Minus 500Hz Octave", 2, "Identify the correct frequency of the ensemble.", "/Music/Ensembles/Ensemble 1 Minus 500Hz Octave.wav", "/Music/Ensembles/Ensemble 1 Reference.wav", 2, "Minus 475Hz Octave", "Minus 550Hz Octave", "Minus 525Hz Octave" ),

                    ( 223, "HPF 125Hz", 3, "Identify the correct frequency of the ensemble.", "/Music/Ensembles/Ensemble 1 HPF 125Hz.wav", "/Music/Ensembles/Ensemble 1 Reference.wav", 2, "HPF 120Hz", "HPF 127Hz", "HPF 130Hz" ),
                    ( 224, "HPF 250Hz", 3, "Identify the correct frequency of the ensemble.", "/Music/Ensembles/Ensemble 1 HPF 250Hz.wav", "/Music/Ensembles/Ensemble 1 Reference.wav", 2, "HPF 245Hz", "HPF 248Hz", "HPF 255Hz" ),
                    ( 225, "HPF 500Hz", 3, "Identify the correct frequency of the ensemble.", "/Music/Ensembles/Ensemble 1 HPF 500Hz.wav", "/Music/Ensembles/Ensemble 1 Reference.wav", 2, "HPF 495Hz", "HPF 502Hz", "HPF 505Hz" ),

                    ( 226, "HPF 1kHz", 3, "Identify the correct frequency of the ensemble.", "/Music/Ensembles/Ensemble 1 HPF 1000Hz.wav", "/Music/Ensembles/Ensemble 1 Reference.wav", 2, "HPF 995Hz", "HPF 998Hz", "HPF 1005Hz" ),
                    ( 227, "LPF 1kHz", 3, "Identify the correct frequency of the ensemble.", "/Music/Ensembles/Ensemble 1 LPF 1kHz.wav", "/Music/Ensembles/Ensemble 1 Reference.wav", 2, "LPF 995Hz", "LPF 998Hz", "LPF 1005Hz" ),
                    ( 228, "LPF 2kHz", 3, "Identify the correct frequency of the ensemble.", "/Music/Ensembles/Ensemble 1 LPF 2kHz.wav", "/Music/Ensembles/Ensemble 1 Reference.wav", 2, "LPF 1990Hz", "LPF 2005Hz", "LPF 2010Hz" ),

                    ( 229, "LPF 4kHz", 3, "Identify the correct frequency of the ensemble.", "/Music/Ensembles/Ensemble 1 LPF 4kHz.wav", "/Music/Ensembles/Ensemble 1 Reference.wav", 2, "LPF 3990Hz", "LPF 4005Hz", "LPF 4010Hz" ),
                    ( 230, "LPF 8kHz", 3, "Identify the correct frequency of the ensemble.", "/Music/Ensembles/Ensemble 1 LPF 8kHz.wav", "/Music/Ensembles/Ensemble 1 Reference.wav", 2, "LPF 7990Hz", "LPF 8005Hz", "LPF 8010Hz" ),
                    ( 231, "Minus 1kHz Octave", 3, "Identify the correct frequency of the ensemble.", "/Music/Ensembles/Ensemble 1 Minus 1kHz Octave.wav", "/Music/Ensembles/Ensemble 1 Reference.wav", 2, "Minus 995Hz Octave", "Minus 998Hz Octave", "Minus 1005Hz Octave" ),

                    ( 232, "Minus 2kHz Octave", 3, "Identify the correct frequency of the ensemble.", "/Music/Ensembles/Ensemble 1 Minus 2kHz Octave.wav", "/Music/Ensembles/Ensemble 1 Reference.wav", 2, "Minus 1990Hz Octave", "Minus 2005Hz Octave", "Minus 2010Hz Octave" ),
                    ( 233, "Minus 4kHz Octave", 3, "Identify the correct frequency of the ensemble.", "/Music/Ensembles/Ensemble 1 Minus 4kHz Octave.wav", "/Music/Ensembles/Ensemble 1 Reference.wav", 2, "Minus 3990Hz Octave", "Minus 4005Hz Octave", "Minus 4010Hz Octave" ),
                    ( 234, "Minus 8kHz Octave", 3, "Identify the correct frequency of the ensemble.", "/Music/Ensembles/Ensemble 1 Minus 8kHz Octave.wav", "/Music/Ensembles/Ensemble 1 Reference.wav", 2, "Minus 7990Hz Octave", "Minus 8005Hz Octave", "Minus 8010Hz Octave" ),

                    ( 235, "Minus 125Hz Octave", 3, "Identify the correct frequency of the ensemble.", "/Music/Ensembles/Ensemble 1 Minus 125Hz Octave.wav", "/Music/Ensembles/Ensemble 1 Reference.wav", 2, "Minus 122Hz Octave", "Minus 124Hz Octave", "Minus 128Hz Octave" ),
                    ( 236, "Minus 250Hz Octave", 3, "Identify the correct frequency of the ensemble.", "/Music/Ensembles/Ensemble 1 Minus 250Hz Octave.wav", "/Music/Ensembles/Ensemble 1 Reference.wav", 2, "Minus 245Hz Octave", "Minus 248Hz Octave", "Minus 255Hz Octave" ),
                    ( 237, "Minus 500Hz Octave", 3, "Identify the correct frequency of the ensemble.", "/Music/Ensembles/Ensemble 1 Minus 500Hz Octave.wav", "/Music/Ensembles/Ensemble 1 Reference.wav", 2, "Minus 495Hz Octave", "Minus 502Hz Octave", "Minus 505Hz Octave" ),

                    ( 238, "HPF 125Hz", 1, "Identify the correct frequency of the ensemble.", "/Music/Ensembles/Ensemble 2 HPF 125Hz.wav", "/Music/Ensembles/Ensemble 2 Reference.wav", 2, "HPF 250Hz", "HPF 1kHz", "HPF 500Hz" ),
                    ( 239, "HPF 250Hz", 1, "Identify the correct frequency of the ensemble.", "/Music/Ensembles/Ensemble 2 HPF 250Hz.wav", "/Music/Ensembles/Ensemble 2 Reference.wav", 2, "HPF 125Hz", "HPF 1kHz", "HPF 500Hz" ),
                    ( 240, "HPF 500Hz", 1, "Identify the correct frequency of the ensemble.", "/Music/Ensembles/Ensemble 2 HPF 500Hz.wav", "/Music/Ensembles/Ensemble 2 Reference.wav", 2, "HPF 125Hz", "HPF 1kHz", "HPF 250Hz" ),

                    ( 241, "HPF 1kHz", 1, "Identify the correct frequency of the ensemble.", "/Music/Ensembles/Ensemble 2 HPF 1000Hz.wav", "/Music/Ensembles/Ensemble 2 Reference.wav", 2, "HPF 125Hz", "HPF 500Hz", "HPF 250Hz" ),
                    ( 242, "LPF 1kHz", 1, "Identify the correct frequency of the ensemble.", "/Music/Ensembles/Ensemble 2 LPF 1kHz.wav", "/Music/Ensembles/Ensemble 2 Reference.wav", 2, "LPF 2kHz", "LPF 8kHz", "LPF 4kHz" ),
                    ( 243, "LPF 2kHz", 1, "Identify the correct frequency of the ensemble.", "/Music/Ensembles/Ensemble 2 LPF 2kHz.wav", "/Music/Ensembles/Ensemble 2 Reference.wav", 2, "LPF 1kHz", "LPF 8kHz", "LPF 4kHz" ),

                    ( 244, "LPF 4kHz", 1, "Identify the correct frequency of the ensemble.", "/Music/Ensembles/Ensemble 2 LPF 4kHz.wav", "/Music/Ensembles/Ensemble 2 Reference.wav", 2, "LPF 1kHz", "LPF 8kHz", "LPF 2kHz" ),
                    ( 245, "LPF 8kHz", 1, "Identify the correct frequency of the ensemble.", "/Music/Ensembles/Ensemble 2 LPF 8kHz.wav", "/Music/Ensembles/Ensemble 2 Reference.wav", 2, "LPF 1kHz", "LPF 4kHz", "LPF 2kHz" ),
                    ( 246, "Minus 1kHz Octave", 1, "Identify the correct frequency of the ensemble.", "/Music/Ensembles/Ensemble 2 Minus 1kHz Octave.wav", "/Music/Ensembles/Ensemble 2 Reference.wav", 2, "Minus 2kHz Octave", "Minus 8kHz Octave", "Minus 4kHz Octave" ),

                    ( 247, "Minus 2kHz Octave", 1, "Identify the correct frequency of the ensemble.", "/Music/Ensembles/Ensemble 2 Minus 2kHz Octave.wav", "/Music/Ensembles/Ensemble 2 Reference.wav", 2, "Minus 1kHz Octave", "Minus 8kHz Octave", "Minus 4kHz Octave" ),
                    ( 248, "Minus 4kHz Octave", 1, "Identify the correct frequency of the ensemble.", "/Music/Ensembles/Ensemble 2 Minus 4kHz Octave.wav", "/Music/Ensembles/Ensemble 2 Reference.wav", 2, "Minus 1kHz Octave", "Minus 8kHz Octave", "Minus 2kHz Octave" ),
                    ( 249, "Minus 8kHz Octave", 1, "Identify the correct frequency of the ensemble.", "/Music/Ensembles/Ensemble 2 Minus 8kHz Octave.wav", "/Music/Ensembles/Ensemble 2 Reference.wav", 2, "Minus 1kHz Octave", "Minus 4kHz Octave", "Minus 2kHz Octave" ),

                    ( 250, "Minus 125Hz Octave", 1, "Identify the correct frequency of the ensemble.", "/Music/Ensembles/Ensemble 2 Minus 125Hz Octave.wav", "/Music/Ensembles/Ensemble 2 Reference.wav", 2, "Minus 250Hz Octave", "Minus 1kHz Octave", "Minus 500Hz Octave" ),
                    ( 251, "Minus 250Hz Octave", 1, "Identify the correct frequency of the ensemble.", "/Music/Ensembles/Ensemble 2 Minus 250Hz Octave.wav", "/Music/Ensembles/Ensemble 2 Reference.wav", 2, "Minus 125Hz Octave", "Minus 1kHz Octave", "Minus 500Hz Octave" ),
                    ( 252, "Minus 500Hz Octave", 1, "Identify the correct frequency of the ensemble.", "/Music/Ensembles/Ensemble 2 Minus 500Hz Octave.wav", "/Music/Ensembles/Ensemble 2 Reference.wav", 2, "Minus 125Hz Octave", "Minus 250Hz Octave", "Minus 1kHz Octave" ),

                    ( 253, "HPF 125Hz", 2, "Identify the correct frequency of the ensemble.", "/Music/Ensembles/Ensemble 2 HPF 125Hz.wav", "/Music/Ensembles/Ensemble 2 Reference.wav", 2, "HPF 110Hz", "HPF 150Hz", "HPF 135Hz" ),
                    ( 254, "HPF 250Hz", 2, "Identify the correct frequency of the ensemble.", "/Music/Ensembles/Ensemble 2 HPF 250Hz.wav", "/Music/Ensembles/Ensemble 2 Reference.wav", 2, "HPF 225Hz", "HPF 275Hz", "HPF 300Hz" ),
                    ( 255, "HPF 500Hz", 2, "Identify the correct frequency of the ensemble.", "/Music/Ensembles/Ensemble 2 HPF 500Hz.wav", "/Music/Ensembles/Ensemble 2 Reference.wav", 2, "HPF 450Hz", "HPF 550Hz", "HPF 600Hz" ),

                    ( 256, "HPF 1kHz", 2, "Identify the correct frequency of the ensemble.", "/Music/Ensembles/Ensemble 2 HPF 1000Hz.wav", "/Music/Ensembles/Ensemble 2 Reference.wav", 2, "HPF 900Hz", "HPF 1100Hz", "HPF 1200Hz" ),
                    ( 257, "LPF 1kHz", 2, "Identify the correct frequency of the ensemble.", "/Music/Ensembles/Ensemble 2 LPF 1kHz.wav", "/Music/Ensembles/Ensemble 2 Reference.wav", 2, "LPF 900Hz", "LPF 1100Hz", "LPF 1200Hz" ),
                    ( 258, "LPF 2kHz", 2, "Identify the correct frequency of the ensemble.", "/Music/Ensembles/Ensemble 2 LPF 2kHz.wav", "/Music/Ensembles/Ensemble 2 Reference.wav", 2, "LPF 1800Hz", "LPF 2200Hz", "LPF 2500Hz" ),

                    ( 259, "LPF 4kHz", 2, "Identify the correct frequency of the ensemble.", "/Music/Ensembles/Ensemble 2 LPF 4kHz.wav", "/Music/Ensembles/Ensemble 2 Reference.wav", 2, "LPF 3600Hz", "LPF 4400Hz", "LPF 5000Hz" ),
                    ( 260, "LPF 8kHz", 2, "Identify the correct frequency of the ensemble.", "/Music/Ensembles/Ensemble 2 LPF 8kHz.wav", "/Music/Ensembles/Ensemble 2 Reference.wav", 2, "LPF 7200Hz", "LPF 8800Hz", "LPF 10kHz" ),
                    ( 261, "Minus 1kHz Octave", 2, "Identify the correct frequency of the ensemble.", "/Music/Ensembles/Ensemble 2 Minus 1kHz Octave.wav", "/Music/Ensembles/Ensemble 2 Reference.wav", 2, "Minus 900Hz Octave", "Minus 1100Hz Octave", "Minus 1200Hz Octave" ),

                    ( 262, "Minus 2kHz Octave", 2, "Identify the correct frequency of the ensemble.", "/Music/Ensembles/Ensemble 2 Minus 2kHz Octave.wav", "/Music/Ensembles/Ensemble 2 Reference.wav", 2, "Minus 1800Hz Octave", "Minus 2200Hz Octave", "Minus 2500Hz Octave" ),
                    ( 263, "Minus 4kHz Octave", 2, "Identify the correct frequency of the ensemble.", "/Music/Ensembles/Ensemble 2 Minus 4kHz Octave.wav", "/Music/Ensembles/Ensemble 2 Reference.wav", 2, "Minus 3600Hz Octave", "Minus 4400Hz Octave", "Minus 5000Hz Octave" ),
                    ( 264, "Minus 8kHz Octave", 2, "Identify the correct frequency of the ensemble.", "/Music/Ensembles/Ensemble 2 Minus 8kHz Octave.wav", "/Music/Ensembles/Ensemble 2 Reference.wav", 2, "Minus 7200Hz Octave", "Minus 8800Hz Octave", "Minus 10kHz Octave" ),

                    ( 265, "Minus 125Hz Octave", 2, "Identify the correct frequency of the ensemble.", "/Music/Ensembles/Ensemble 2 Minus 125Hz Octave.wav", "/Music/Ensembles/Ensemble 2 Reference.wav", 2, "Minus 110Hz Octave", "Minus 135Hz Octave", "Minus 150Hz Octave" ),
                    ( 266, "Minus 250Hz Octave", 2, "Identify the correct frequency of the ensemble.", "/Music/Ensembles/Ensemble 2 Minus 250Hz Octave.wav", "/Music/Ensembles/Ensemble 2 Reference.wav", 2, "Minus 225Hz Octave", "Minus 275Hz Octave", "Minus 300Hz Octave" ),
                    ( 267, "Minus 500Hz Octave", 2, "Identify the correct frequency of the ensemble.", "/Music/Ensembles/Ensemble 2 Minus 500Hz Octave.wav", "/Music/Ensembles/Ensemble 2 Reference.wav", 2, "Minus 450Hz Octave", "Minus 550Hz Octave", "Minus 600Hz Octave" ),

                    ( 268, "HPF 125Hz", 3, "Identify the correct frequency of the ensemble.", "/Music/Ensembles/Ensemble 2 HPF 125Hz.wav", "/Music/Ensembles/Ensemble 2 Reference.wav", 2, "HPF 120Hz", "HPF 127Hz", "HPF 130Hz" ),
                    ( 269, "HPF 250Hz", 3, "Identify the correct frequency of the ensemble.", "/Music/Ensembles/Ensemble 2 HPF 250Hz.wav", "/Music/Ensembles/Ensemble 2 Reference.wav", 2, "HPF 245Hz", "HPF 252Hz", "HPF 255Hz" ),
                    ( 270, "HPF 500Hz", 3, "Identify the correct frequency of the ensemble.", "/Music/Ensembles/Ensemble 2 HPF 500Hz.wav", "/Music/Ensembles/Ensemble 2 Reference.wav", 2, "HPF 490Hz", "HPF 505Hz", "HPF 510Hz" ),

                    ( 271, "HPF 1kHz", 3, "Identify the correct frequency of the ensemble.", "/Music/Ensembles/Ensemble 2 HPF 1000Hz.wav", "/Music/Ensembles/Ensemble 2 Reference.wav", 2, "HPF 980Hz", "HPF 1010Hz", "HPF 995Hz" ),
                    ( 272, "LPF 1kHz", 3, "Identify the correct frequency of the ensemble.", "/Music/Ensembles/Ensemble 2 LPF 1kHz.wav", "/Music/Ensembles/Ensemble 2 Reference.wav", 2, "LPF 980Hz", "LPF 1010Hz", "LPF 995Hz" ),
                    ( 273, "LPF 2kHz", 3, "Identify the correct frequency of the ensemble.", "/Music/Ensembles/Ensemble 2 LPF 2kHz.wav", "/Music/Ensembles/Ensemble 2 Reference.wav", 2, "LPF 1975Hz", "LPF 1990Hz", "LPF 2020Hz" ),

                    ( 274, "LPF 4kHz", 3, "Identify the correct frequency of the ensemble.", "/Music/Ensembles/Ensemble 2 LPF 4kHz.wav", "/Music/Ensembles/Ensemble 2 Reference.wav", 2, "LPF 3975Hz", "LPF 3990Hz", "LPF 4020Hz" ),
                    ( 275, "LPF 8kHz", 3, "Identify the correct frequency of the ensemble.", "/Music/Ensembles/Ensemble 2 LPF 8kHz.wav", "/Music/Ensembles/Ensemble 2 Reference.wav", 2, "LPF 7975Hz", "LPF 7990Hz", "LPF 8020Hz" ),
                    ( 276, "Minus 1kHz Octave", 3, "Identify the correct frequency of the ensemble.", "/Music/Ensembles/Ensemble 2 Minus 1kHz Octave.wav", "/Music/Ensembles/Ensemble 2 Reference.wav", 2, "Minus 975Hz Octave", "Minus 990Hz Octave", "Minus 1020Hz Octave" ),

                    ( 277, "Minus 2kHz Octave", 3, "Identify the correct frequency of the ensemble.", "/Music/Ensembles/Ensemble 2 Minus 2kHz Octave.wav", "/Music/Ensembles/Ensemble 2 Reference.wav", 2, "Minus 1975Hz Octave", "Minus 1990Hz Octave", "Minus 2020Hz Octave" ),
                    ( 278, "Minus 4kHz Octave", 3, "Identify the correct frequency of the ensemble.", "/Music/Ensembles/Ensemble 2 Minus 4kHz Octave.wav", "/Music/Ensembles/Ensemble 2 Reference.wav", 2, "Minus 3975Hz Octave", "Minus 3990Hz Octave", "Minus 4020Hz Octave" ),
                    ( 279, "Minus 8kHz Octave", 3, "Identify the correct frequency of the ensemble.", "/Music/Ensembles/Ensemble 2 Minus 8kHz Octave.wav", "/Music/Ensembles/Ensemble 2 Reference.wav", 2, "Minus 7975Hz Octave", "Minus 7990Hz Octave", "Minus 8020Hz Octave" ),

                    ( 280, "Minus 125Hz Octave", 3, "Identify the correct frequency of the ensemble.", "/Music/Ensembles/Ensemble 2 Minus 125Hz Octave.wav", "/Music/Ensembles/Ensemble 2 Reference.wav", 2, "Minus 120Hz Octave", "Minus 127Hz Octave", "Minus 130Hz Octave" ),
                    ( 281, "Minus 250Hz Octave", 3, "Identify the correct frequency of the ensemble.", "/Music/Ensembles/Ensemble 2 Minus 250Hz Octave.wav", "/Music/Ensembles/Ensemble 2 Reference.wav", 2, "Minus 245Hz Octave", "Minus 252Hz Octave", "Minus 255Hz Octave" ),
                    ( 282, "Minus 500Hz Octave", 3, "Identify the correct frequency of the ensemble.", "/Music/Ensembles/Ensemble 2 Minus 500Hz Octave.wav", "/Music/Ensembles/Ensemble 2 Reference.wav", 2, "Minus 490Hz Octave", "Minus 505Hz Octave", "Minus 510Hz Octave" ),

                    ( 283, "HPF 125Hz", 1, "Identify the correct frequency of the ensemble.", "/Music/Ensembles/Ensemble 3 HPF 125Hz.wav", "/Music/Ensembles/Ensemble 3 Reference.wav", 2, "HPF 100Hz", "HPF 150Hz", "HPF 200Hz" ),
                    ( 284, "HPF 250Hz", 1, "Identify the correct frequency of the ensemble.", "/Music/Ensembles/Ensemble 3 HPF 250Hz.wav", "/Music/Ensembles/Ensemble 3 Reference.wav", 2, "HPF 200Hz", "HPF 300Hz", "HPF 350Hz" ),
                    ( 285, "HPF 500Hz", 1, "Identify the correct frequency of the ensemble.", "/Music/Ensembles/Ensemble 3 HPF 500Hz.wav", "/Music/Ensembles/Ensemble 3 Reference.wav", 2, "HPF 400Hz", "HPF 600Hz", "HPF 700Hz" ),

                    ( 286, "HPF 1kHz", 1, "Identify the correct frequency of the ensemble.", "/Music/Ensembles/Ensemble 3 HPF 1000Hz.wav", "/Music/Ensembles/Ensemble 3 Reference.wav", 2, "HPF 800Hz", "HPF 1.2kHz", "HPF 1.5kHz" ),
                    ( 287, "LPF 1kHz", 1, "Identify the correct frequency of the ensemble.", "/Music/Ensembles/Ensemble 3 LPF 1kHz.wav", "/Music/Ensembles/Ensemble 3 Reference.wav", 2, "LPF 800Hz", "LPF 1.2kHz", "LPF 1.5kHz" ),
                    ( 288, "LPF 2kHz", 1, "Identify the correct frequency of the ensemble.", "/Music/Ensembles/Ensemble 3 LPF 2kHz.wav", "/Music/Ensembles/Ensemble 3 Reference.wav", 2, "LPF 1.5kHz", "LPF 2.5kHz", "LPF 3kHz" ),

                    ( 289, "LPF 4kHz", 1, "Identify the correct frequency of the ensemble.", "/Music/Ensembles/Ensemble 3 LPF 4kHz.wav", "/Music/Ensembles/Ensemble 3 Reference.wav", 2, "LPF 3kHz", "LPF 5kHz", "LPF 6kHz" ),
                    ( 290, "LPF 8kHz", 1, "Identify the correct frequency of the ensemble.", "/Music/Ensembles/Ensemble 3 LPF 8kHz.wav", "/Music/Ensembles/Ensemble 3 Reference.wav", 2, "LPF 6kHz", "LPF 10kHz", "LPF 12kHz" ),
                    ( 291, "Minus 1kHz Octave", 1, "Identify the correct frequency of the ensemble.", "/Music/Ensembles/Ensemble 3 Minus 1kHz Octave.wav", "/Music/Ensembles/Ensemble 3 Reference.wav", 2, "Minus 800Hz Octave", "Minus 1.2kHz Octave", "Minus 1.5kHz Octave" ),

                    ( 292, "Minus 2kHz Octave", 1, "Identify the correct frequency of the ensemble.", "/Music/Ensembles/Ensemble 3 Minus 2kHz Octave.wav", "/Music/Ensembles/Ensemble 3 Reference.wav", 2, "Minus 1.5kHz Octave", "Minus 2.5kHz Octave", "Minus 3kHz Octave" ),
                    ( 293, "Minus 4kHz Octave", 1, "Identify the correct frequency of the ensemble.", "/Music/Ensembles/Ensemble 3 Minus 4kHz Octave.wav", "/Music/Ensembles/Ensemble 3 Reference.wav", 2, "Minus 3kHz Octave", "Minus 5kHz Octave", "Minus 6kHz Octave" ),
                    ( 294, "Minus 8kHz Octave", 1, "Identify the correct frequency of the ensemble.", "/Music/Ensembles/Ensemble 3 Minus 8kHz Octave.wav", "/Music/Ensembles/Ensemble 3 Reference.wav", 2, "Minus 6kHz Octave", "Minus 10kHz Octave", "Minus 12kHz Octave" ),

                    ( 295, "Minus 125Hz Octave", 1, "Identify the correct frequency of the ensemble.", "/Music/Ensembles/Ensemble 3 Minus 125Hz Octave.wav", "/Music/Ensembles/Ensemble 3 Reference.wav", 2, "Minus 100Hz Octave", "Minus 150Hz Octave", "Minus 200Hz Octave" ),
                    ( 296, "Minus 250Hz Octave", 1, "Identify the correct frequency of the ensemble.", "/Music/Ensembles/Ensemble 3 Minus 250Hz Octave.wav", "/Music/Ensembles/Ensemble 3 Reference.wav", 2, "Minus 200Hz Octave", "Minus 300Hz Octave", "Minus 350Hz Octave" ),
                    ( 297, "Minus 500Hz Octave", 1, "Identify the correct frequency of the ensemble.", "/Music/Ensembles/Ensemble 3 Minus 500Hz Octave.wav", "/Music/Ensembles/Ensemble 3 Reference.wav", 2, "Minus 400Hz Octave", "Minus 600Hz Octave", "Minus 700Hz Octave" ),

                    ( 298, "HPF 125Hz", 2, "Identify the correct frequency of the ensemble.", "/Music/Ensembles/Ensemble 3 HPF 125Hz.wav", "/Music/Ensembles/Ensemble 3 Reference.wav", 2, "HPF 100Hz", "HPF 150Hz", "HPF 175Hz" ),
                    ( 299, "HPF 250Hz", 2, "Identify the correct frequency of the ensemble.", "/Music/Ensembles/Ensemble 3 HPF 250Hz.wav", "/Music/Ensembles/Ensemble 3 Reference.wav", 2, "HPF 230Hz", "HPF 270Hz", "HPF 300Hz" ),
                    ( 300, "HPF 500Hz", 2, "Identify the correct frequency of the ensemble.", "/Music/Ensembles/Ensemble 3 HPF 500Hz.wav", "/Music/Ensembles/Ensemble 3 Reference.wav", 2, "HPF 450Hz", "HPF 550Hz", "HPF 600Hz" ),

                    ( 301, "HPF 1kHz", 2, "Identify the correct frequency of the ensemble.", "/Music/Ensembles/Ensemble 3 HPF 1000Hz.wav", "/Music/Ensembles/Ensemble 3 Reference.wav", 2, "HPF 950Hz", "HPF 1050Hz", "HPF 1.2kHz" ),
                    ( 302, "LPF 1kHz", 2, "Identify the correct frequency of the ensemble.", "/Music/Ensembles/Ensemble 3 LPF 1kHz.wav", "/Music/Ensembles/Ensemble 3 Reference.wav", 2, "LPF 900Hz", "LPF 1.1kHz", "LPF 1.3kHz" ),
                    ( 303, "LPF 2kHz", 2, "Identify the correct frequency of the ensemble.", "/Music/Ensembles/Ensemble 3 LPF 2kHz.wav", "/Music/Ensembles/Ensemble 3 Reference.wav", 2, "LPF 1.8kHz", "LPF 2.1kHz", "LPF 2.5kHz" ),

                    ( 304, "LPF 4kHz", 2, "Identify the correct frequency of the ensemble.", "/Music/Ensembles/Ensemble 3 LPF 4kHz.wav", "/Music/Ensembles/Ensemble 3 Reference.wav", 2, "LPF 3.5kHz", "LPF 4.5kHz", "LPF 5kHz" ),
                    ( 305, "LPF 8kHz", 2, "Identify the correct frequency of the ensemble.", "/Music/Ensembles/Ensemble 3 LPF 8kHz.wav", "/Music/Ensembles/Ensemble 3 Reference.wav", 2, "LPF 7kHz", "LPF 8.5kHz", "LPF 9kHz" ),
                    ( 306, "Minus 1kHz Octave", 2, "Identify the correct frequency of the ensemble.", "/Music/Ensembles/Ensemble 3 Minus 1kHz Octave.wav", "/Music/Ensembles/Ensemble 3 Reference.wav", 2, "Minus 950Hz Octave", "Minus 1.1kHz Octave", "Minus 1.3kHz Octave" ),

                    ( 307, "Minus 2kHz Octave", 2, "Identify the correct frequency of the ensemble.", "/Music/Ensembles/Ensemble 3 Minus 2kHz Octave.wav", "/Music/Ensembles/Ensemble 3 Reference.wav", 2, "Minus 1.8kHz Octave", "Minus 2.2kHz Octave", "Minus 2.5kHz Octave" ),
                    ( 308, "Minus 4kHz Octave", 2, "Identify the correct frequency of the ensemble.", "/Music/Ensembles/Ensemble 3 Minus 4kHz Octave.wav", "/Music/Ensembles/Ensemble 3 Reference.wav", 2, "Minus 3.5kHz Octave", "Minus 4.2kHz Octave", "Minus 4.5kHz Octave" ),
                    ( 309, "Minus 8kHz Octave", 2, "Identify the correct frequency of the ensemble.", "/Music/Ensembles/Ensemble 3 Minus 8kHz Octave.wav", "/Music/Ensembles/Ensemble 3 Reference.wav", 2, "Minus 7.5kHz Octave", "Minus 8.2kHz Octave", "Minus 8.5kHz Octave" ),

                    ( 310, "Minus 125Hz Octave", 2, "Identify the correct frequency of the ensemble.", "/Music/Ensembles/Ensemble 3 Minus 125Hz Octave.wav", "/Music/Ensembles/Ensemble 3 Reference.wav", 2, "Minus 100Hz Octave", "Minus 150Hz Octave", "Minus 200Hz Octave" ),
                     ( 311, "Minus 250Hz Octave", 2, "Identify the correct frequency of the ensemble.", "/Music/Ensembles/Ensemble 3 Minus 250Hz Octave.wav", "/Music/Ensembles/Ensemble 3 Reference.wav", 2, "Minus 230Hz Octave", "Minus 300Hz Octave", "Minus 270Hz Octave" ),
                    ( 312, "Minus 500Hz Octave", 2, "Identify the correct frequency of the ensemble.", "/Music/Ensembles/Ensemble 3 Minus 500Hz Octave.wav", "/Music/Ensembles/Ensemble 3 Reference.wav", 2, "Minus 450Hz Octave", "Minus 600Hz Octave", "Minus 550Hz Octave" ),

                    ( 313, "HPF 125Hz", 3, "Identify the correct frequency of the ensemble.", "/Music/Ensembles/Ensemble 3 HPF 125Hz.wav", "/Music/Ensembles/Ensemble 3 Reference.wav", 2, "HPF 110Hz", "HPF 180Hz", "HPF 140Hz" ),
                    ( 314, "HPF 250Hz", 3, "Identify the correct frequency of the ensemble.", "/Music/Ensembles/Ensemble 3 HPF 250Hz.wav", "/Music/Ensembles/Ensemble 3 Reference.wav", 2, "HPF 200Hz", "HPF 280Hz", "HPF 220Hz" ),
                    ( 315, "HPF 500Hz", 3, "Identify the correct frequency of the ensemble.", "/Music/Ensembles/Ensemble 3 HPF 500Hz.wav", "/Music/Ensembles/Ensemble 3 Reference.wav", 2, "HPF 420Hz", "HPF 550Hz", "HPF 480Hz" ),

                    ( 316, "HPF 1kHz", 3, "Identify the correct frequency of the ensemble.", "/Music/Ensembles/Ensemble 3 HPF 1000Hz.wav", "/Music/Ensembles/Ensemble 3 Reference.wav", 2, "HPF 900Hz", "HPF 1.3kHz", "HPF 1.1kHz" ),
                    ( 317, "LPF 1kHz", 3, "Identify the correct frequency of the ensemble.", "/Music/Ensembles/Ensemble 3 LPF 1kHz.wav", "/Music/Ensembles/Ensemble 3 Reference.wav", 2, "LPF 850Hz", "LPF 1.5kHz", "LPF 1.2kHz" ),
                    ( 318, "LPF 2kHz", 3, "Identify the correct frequency of the ensemble.", "/Music/Ensembles/Ensemble 3 LPF 2kHz.wav", "/Music/Ensembles/Ensemble 3 Reference.wav", 2, "LPF 1.7kHz", "LPF 2.7kHz", "LPF 2.3kHz" ),

                    ( 319, "LPF 4kHz", 3, "Identify the correct frequency of the ensemble.", "/Music/Ensembles/Ensemble 3 LPF 4kHz.wav", "/Music/Ensembles/Ensemble 3 Reference.wav", 2, "LPF 3.5kHz", "LPF 4.7kHz", "LPF 4.2kHz" ),
                    ( 320, "LPF 8kHz", 3, "Identify the correct frequency of the ensemble.", "/Music/Ensembles/Ensemble 3 LPF 8kHz.wav", "/Music/Ensembles/Ensemble 3 Reference.wav", 2, "LPF 7.2kHz", "LPF 8.7kHz", "LPF 8.3kHz" ),
                    ( 321, "Minus 1kHz Octave", 3, "Identify the correct frequency of the ensemble.", "/Music/Ensembles/Ensemble 3 Minus 1kHz Octave.wav", "/Music/Ensembles/Ensemble 3 Reference.wav", 2, "Minus 950Hz Octave", "Minus 1.3kHz Octave", "Minus 1.15kHz Octave" ),

                    ( 322, "Minus 2kHz Octave", 3, "Identify the correct frequency of the ensemble.", "/Music/Ensembles/Ensemble 3 Minus 2kHz Octave.wav", "/Music/Ensembles/Ensemble 3 Reference.wav", 2, "Minus 1.8kHz Octave", "Minus 2.3kHz Octave", "Minus 2.1kHz Octave" ),
                    ( 323, "Minus 4kHz Octave", 3, "Identify the correct frequency of the ensemble.", "/Music/Ensembles/Ensemble 3 Minus 4kHz Octave.wav", "/Music/Ensembles/Ensemble 3 Reference.wav", 2, "Minus 3.6kHz Octave", "Minus 4.8kHz Octave", "Minus 4.3kHz Octave" ),
                    ( 324, "Minus 8kHz Octave", 3, "Identify the correct frequency of the ensemble.", "/Music/Ensembles/Ensemble 3 Minus 8kHz Octave.wav", "/Music/Ensembles/Ensemble 3 Reference.wav", 2, "Minus 7.5kHz Octave", "Minus 9kHz Octave", "Minus 8.3kHz Octave" ),

                    ( 325, "Minus 125Hz Octave", 3, "Identify the correct frequency of the ensemble.", "/Music/Ensembles/Ensemble 3 Minus 125Hz Octave.wav", "/Music/Ensembles/Ensemble 3 Reference.wav", 2, "Minus 100Hz Octave", "Minus 200Hz Octave", "Minus 150Hz Octave" ),
                    ( 326, "Minus 250Hz Octave", 3, "Identify the correct frequency of the ensemble.", "/Music/Ensembles/Ensemble 3 Minus 250Hz Octave.wav", "/Music/Ensembles/Ensemble 3 Reference.wav", 2, "Minus 230Hz Octave", "Minus 290Hz Octave", "Minus 270Hz Octave" ),
                    ( 327, "Minus 500Hz Octave", 3, "Identify the correct frequency of the ensemble.", "/Music/Ensembles/Ensemble 3 Minus 500Hz Octave.wav", "/Music/Ensembles/Ensemble 3 Reference.wav", 2, "Minus 470Hz Octave", "Minus 550Hz Octave", "Minus 520Hz Octave" ),

                    ( 328, "110Hz", 1, "Identify the correct frequency of the guitar.", "/Music/Instrument/Guitar 110Hz.wav", "/Music/Instrument/Guitar 131Hz.wav", 3, "220Hz", "330Hz", "440Hz" ),
                    ( 329, "131Hz", 1, "Identify the correct frequency of the guitar.", "/Music/Instrument/Guitar 131Hz.wav", "/Music/Instrument/Guitar 165Hz.wav", 3, "220Hz", "330Hz", "440Hz" ),
                    ( 330, "165Hz", 1, "Identify the correct frequency of the guitar.", "/Music/Instrument/Guitar 165Hz.wav", "/Music/Instrument/Guitar 220Hz.wav", 3, "220Hz", "330Hz", "440Hz" ),

                    ( 331, "220Hz", 1, "Identify the correct frequency of the guitar.", "/Music/Instrument/Guitar 220Hz.wav", "/Music/Instrument/Guitar 262Hz.wav", 3, "330Hz", "440Hz", "880Hz" ),
                    ( 332, "262Hz", 1, "Identify the correct frequency of the guitar.", "/Music/Instrument/Guitar 262Hz.wav", "/Music/Instrument/Guitar 330Hz.wav", 3, "330Hz", "440Hz", "880Hz" ),
                    ( 333, "330Hz", 1, "Identify the correct frequency of the guitar.", "/Music/Instrument/Guitar 330Hz.wav", "/Music/Instrument/Guitar 440Hz.wav", 3, "220Hz", "440Hz", "880Hz" ),

                    ( 334, "440Hz", 1, "Identify the correct frequency of the guitar.", "/Music/Instrument/Guitar 440Hz.wav", "/Music/Instrument/Guitar 880Hz.wav", 3, "110Hz", "131Hz", "165Hz" ),
                    ( 335, "880Hz", 1, "Identify the correct frequency of the guitar.", "/Music/Instrument/Guitar 880Hz.wav", "/Music/Instrument/Guitar 110Hz.wav", 3, "110Hz", "131Hz", "165Hz" ),
                    ( 336, "110Hz", 1, "Identify the correct frequency of the guitar.", "/Music/Instrument/Guitar 110Hz.wav", "/Music/Instrument/Guitar 131Hz.wav", 3, "220Hz", "330Hz", "440Hz" ),

                    ( 337, "131Hz", 1, "Identify the correct frequency of the guitar.", "/Music/Instrument/Guitar 131Hz.wav", "/Music/Instrument/Guitar 165Hz.wav", 3, "220Hz", "330Hz", "440Hz" ),
                    ( 338, "165Hz", 1, "Identify the correct frequency of the guitar.", "/Music/Instrument/Guitar 165Hz.wav", "/Music/Instrument/Guitar 220Hz.wav", 3, "220Hz", "330Hz", "440Hz" ),
                    ( 339, "220Hz", 1, "Identify the correct frequency of the guitar.", "/Music/Instrument/Guitar 220Hz.wav", "/Music/Instrument/Guitar 262Hz.wav", 3, "330Hz", "440Hz", "880Hz" ),

                    ( 340, "262Hz", 1, "Identify the correct frequency of the guitar.", "/Music/Instrument/Guitar 262Hz.wav", "/Music/Instrument/Guitar 330Hz.wav", 3, "330Hz", "440Hz", "880Hz" ),
                    ( 341, "330Hz", 1, "Identify the correct frequency of the guitar.", "/Music/Instrument/Guitar 330Hz.wav", "/Music/Instrument/Guitar 440Hz.wav", 3, "440Hz", "880Hz", "110Hz" ),
                    ( 342, "440Hz", 1, "Identify the correct frequency of the guitar.", "/Music/Instrument/Guitar 440Hz.wav", "/Music/Instrument/Guitar 880Hz.wav", 3, "880Hz", "110Hz", "131Hz" ),

                    ( 343, "110Hz", 2, "Identify the correct frequency of the guitar.", "/Music/Instrument/Guitar 110Hz.wav", "/Music/Instrument/Guitar 131Hz.wav", 3, "50Hz", "200Hz", "300Hz" ),
                    ( 344, "131Hz", 2, "Identify the correct frequency of the guitar.", "/Music/Instrument/Guitar 131Hz.wav", "/Music/Instrument/Guitar 165Hz.wav", 3, "60Hz", "210Hz", "310Hz" ),
                    ( 345, "165Hz", 2, "Identify the correct frequency of the guitar.", "/Music/Instrument/Guitar 165Hz.wav", "/Music/Instrument/Guitar 220Hz.wav", 3, "70Hz", "220Hz", "320Hz" ),

                    ( 346, "220Hz", 2, "Identify the correct frequency of the guitar.", "/Music/Instrument/Guitar 220Hz.wav", "/Music/Instrument/Guitar 262Hz.wav", 3, "80Hz", "230Hz", "330Hz" ),
                    ( 347, "262Hz", 2, "Identify the correct frequency of the guitar.", "/Music/Instrument/Guitar 262Hz.wav", "/Music/Instrument/Guitar 330Hz.wav", 3, "90Hz", "240Hz", "340Hz" ),
                    ( 348, "330Hz", 2, "Identify the correct frequency of the guitar.", "/Music/Instrument/Guitar 330Hz.wav", "/Music/Instrument/Guitar 440Hz.wav", 3, "100Hz", "250Hz", "350Hz" ),

                    ( 349, "440Hz", 2, "Identify the correct frequency of the guitar.", "/Music/Instrument/Guitar 440Hz.wav", "/Music/Instrument/Guitar 880Hz.wav", 3, "110Hz", "260Hz", "360Hz" ),
                    ( 350, "880Hz", 2, "Identify the correct frequency of the guitar.", "/Music/Instrument/Guitar 880Hz.wav", "/Music/Instrument/Guitar 110Hz.wav", 3, "120Hz", "270Hz", "370Hz" ),
                    ( 351, "110Hz", 2, "Identify the correct frequency of the guitar.", "/Music/Instrument/Guitar 110Hz.wav", "/Music/Instrument/Guitar 131Hz.wav", 3, "50Hz", "200Hz", "300Hz" ),

                    ( 352, "131Hz", 2, "Identify the correct frequency of the guitar.", "/Music/Instrument/Guitar 131Hz.wav", "/Music/Instrument/Guitar 165Hz.wav", 3, "60Hz", "210Hz", "310Hz" ),
                    ( 353, "165Hz", 2, "Identify the correct frequency of the guitar.", "/Music/Instrument/Guitar 165Hz.wav", "/Music/Instrument/Guitar 220Hz.wav", 3, "70Hz", "220Hz", "320Hz" ),
                    ( 354, "220Hz", 2, "Identify the correct frequency of the guitar.", "/Music/Instrument/Guitar 220Hz.wav", "/Music/Instrument/Guitar 262Hz.wav", 3, "80Hz", "230Hz", "330Hz" ),

                    ( 355, "262Hz", 2, "Identify the correct frequency of the guitar.", "/Music/Instrument/Guitar 262Hz.wav", "/Music/Instrument/Guitar 330Hz.wav", 3, "90Hz", "240Hz", "340Hz" ),
                    ( 356, "330Hz", 2, "Identify the correct frequency of the guitar.", "/Music/Instrument/Guitar 330Hz.wav", "/Music/Instrument/Guitar 440Hz.wav", 3, "100Hz", "250Hz", "350Hz" ),
                    ( 357, "440Hz", 2, "Identify the correct frequency of the guitar.", "/Music/Instrument/Guitar 440Hz.wav", "/Music/Instrument/Guitar 880Hz.wav", 3, "110Hz", "260Hz", "360Hz" ),

                    ( 358, "110Hz", 3, "Identify the correct frequency of the guitar.", "/Music/Instrument/Guitar 110Hz.wav", "/Music/Instrument/Guitar 131Hz.wav", 3, "105Hz", "115Hz", "120Hz" ),
                    ( 359, "131Hz", 3, "Identify the correct frequency of the guitar.", "/Music/Instrument/Guitar 131Hz.wav", "/Music/Instrument/Guitar 165Hz.wav", 3, "125Hz", "135Hz", "140Hz" ),
                    ( 360, "165Hz", 3, "Identify the correct frequency of the guitar.", "/Music/Instrument/Guitar 165Hz.wav", "/Music/Instrument/Guitar 220Hz.wav", 3, "160Hz", "170Hz", "175Hz" ),

                    ( 361, "220Hz", 3, "Identify the correct frequency of the guitar.", "/Music/Instrument/Guitar 220Hz.wav", "/Music/Instrument/Guitar 262Hz.wav", 3, "215Hz", "225Hz", "230Hz" ),
                    ( 362, "262Hz", 3, "Identify the correct frequency of the guitar.", "/Music/Instrument/Guitar 262Hz.wav", "/Music/Instrument/Guitar 330Hz.wav", 3, "255Hz", "265Hz", "270Hz" ),
                    ( 363, "330Hz", 3, "Identify the correct frequency of the guitar.", "/Music/Instrument/Guitar 330Hz.wav", "/Music/Instrument/Guitar 440Hz.wav", 3, "320Hz", "335Hz", "340Hz" ),

                    ( 364, "440Hz", 3, "Identify the correct frequency of the guitar.", "/Music/Instrument/Guitar 440Hz.wav", "/Music/Instrument/Guitar 880Hz.wav", 3, "430Hz", "445Hz", "450Hz" ),
                    ( 365, "880Hz", 3, "Identify the correct frequency of the guitar.", "/Music/Instrument/Guitar 880Hz.wav", "/Music/Instrument/Guitar 110Hz.wav", 3, "870Hz", "885Hz", "890Hz" ),
                    ( 366, "110Hz", 3, "Identify the correct frequency of the guitar.", "/Music/Instrument/Guitar 110Hz.wav", "/Music/Instrument/Guitar 131Hz.wav", 3, "105Hz", "115Hz", "120Hz" ),

                    ( 367, "131Hz", 3, "Identify the correct frequency of the guitar.", "/Music/Instrument/Guitar 131Hz.wav", "/Music/Instrument/Guitar 165Hz.wav", 3, "125Hz", "135Hz", "140Hz" ),
                    ( 368, "165Hz", 3, "Identify the correct frequency of the guitar.", "/Music/Instrument/Guitar 165Hz.wav", "/Music/Instrument/Guitar 220Hz.wav", 3, "160Hz", "170Hz", "175Hz" ),
                    ( 369, "220Hz", 3, "Identify the correct frequency of the guitar.", "/Music/Instrument/Guitar 220Hz.wav", "/Music/Instrument/Guitar 262Hz.wav", 3, "215Hz", "225Hz", "230Hz" ),

                    ( 370, "262Hz", 3, "Identify the correct frequency of the guitar.", "/Music/Instrument/Guitar 262Hz.wav", "/Music/Instrument/Guitar 330Hz.wav", 3, "255Hz", "265Hz", "270Hz" ),
                    ( 371, "330Hz", 3, "Identify the correct frequency of the guitar.", "/Music/Instrument/Guitar 330Hz.wav", "/Music/Instrument/Guitar 440Hz.wav", 3, "320Hz", "340Hz", "335Hz" ),
                    ( 372, "440Hz", 3, "Identify the correct frequency of the guitar.", "/Music/Instrument/Guitar 440Hz.wav", "/Music/Instrument/Guitar 880Hz.wav", 3, "430Hz", "450Hz", "445Hz" ),

                    ( 373, "110Hz", 1, "Identify the correct frequency of the harp.", "/Music/Instrument/Harp 110Hz.wav", "/Music/Instrument/Harp 131Hz.wav", 3, "50Hz", "300Hz", "200Hz" ),
                    ( 374, "131Hz", 1, "Identify the correct frequency of the harp.", "/Music/Instrument/Harp 131Hz.wav", "/Music/Instrument/Harp 165Hz.wav", 3, "60Hz", "310Hz", "210Hz" ),
                    ( 375, "165Hz", 1, "Identify the correct frequency of the harp.", "/Music/Instrument/Harp 165Hz.wav", "/Music/Instrument/Harp 220Hz.wav", 3, "70Hz", "320Hz", "220Hz" ),

                    ( 376, "220Hz", 1, "Identify the correct frequency of the harp.", "/Music/Instrument/Harp 220Hz.wav", "/Music/Instrument/Harp 262Hz.wav", 3, "80Hz", "230Hz", "330Hz" ),
                    ( 377, "262Hz", 1, "Identify the correct frequency of the harp.", "/Music/Instrument/Harp 262Hz.wav", "/Music/Instrument/Harp 330Hz.wav", 3, "90Hz", "240Hz", "340Hz" ),
                    ( 378, "330Hz", 1, "Identify the correct frequency of the harp.", "/Music/Instrument/Harp 330Hz.wav", "/Music/Instrument/Harp 440Hz.wav", 3, "100Hz", "250Hz", "350Hz" ),

                    ( 379, "440Hz", 1, "Identify the correct frequency of the harp.", "/Music/Instrument/Harp 440Hz.wav", "/Music/Instrument/Harp 880Hz.wav", 3, "110Hz", "260Hz", "360Hz" ),
                    ( 380, "880Hz", 1, "Identify the correct frequency of the harp.", "/Music/Instrument/Harp 880Hz.wav", "/Music/Instrument/Harp 110Hz.wav", 3, "120Hz", "270Hz", "370Hz" ),
                    ( 381, "523Hz", 1, "Identify the correct frequency of the harp.", "/Music/Instrument/Harp 523Hz.wav", "/Music/Instrument/Harp 659Hz.wav", 3, "130Hz", "280Hz", "380Hz" ),

                    ( 382, "659Hz", 1, "Identify the correct frequency of the harp.", "/Music/Instrument/Harp 659Hz.wav", "/Music/Instrument/Harp 1.05kHz.wav", 3, "140Hz", "290Hz", "390Hz" ),
                    ( 383, "1.05kHz", 1, "Identify the correct frequency of the harp.", "/Music/Instrument/Harp 1.05kHz.wav", "/Music/Instrument/Harp 1.32kHz.wav", 3, "150Hz", "300Hz", "400Hz" ),
                    ( 384, "1.32kHz", 1, "Identify the correct frequency of the harp.", "/Music/Instrument/Harp 1.32kHz.wav", "/Music/Instrument/Harp 110Hz.wav", 3, "160Hz", "310Hz", "410Hz" ),

                    ( 385, "110Hz", 2, "Identify the correct frequency of the harp.", "/Music/Instrument/Harp 110Hz.wav", "/Music/Instrument/Harp 131Hz.wav", 3, "90Hz", "150Hz", "130Hz" ),
                    ( 386, "131Hz", 2, "Identify the correct frequency of the harp.", "/Music/Instrument/Harp 131Hz.wav", "/Music/Instrument/Harp 165Hz.wav", 3, "110Hz", "170Hz", "150Hz" ),
                    ( 387, "165Hz", 2, "Identify the correct frequency of the harp.", "/Music/Instrument/Harp 165Hz.wav", "/Music/Instrument/Harp 220Hz.wav", 3, "140Hz", "185Hz", "205Hz" ),

                    ( 388, "220Hz", 2, "Identify the correct frequency of the harp.", "/Music/Instrument/Harp 220Hz.wav", "/Music/Instrument/Harp 262Hz.wav", 3, "200Hz", "240Hz", "260Hz" ),
                    ( 389, "262Hz", 2, "Identify the correct frequency of the harp.", "/Music/Instrument/Harp 262Hz.wav", "/Music/Instrument/Harp 330Hz.wav", 3, "240Hz", "282Hz", "302Hz" ),
                    ( 390, "330Hz", 2, "Identify the correct frequency of the harp.", "/Music/Instrument/Harp 330Hz.wav", "/Music/Instrument/Harp 440Hz.wav", 3, "310Hz", "350Hz", "370Hz" ),

                    ( 391, "440Hz", 2, "Identify the correct frequency of the harp.", "/Music/Instrument/Harp 440Hz.wav", "/Music/Instrument/Harp 880Hz.wav", 3, "420Hz", "460Hz", "480Hz" ),
                    ( 392, "880Hz", 2, "Identify the correct frequency of the harp.", "/Music/Instrument/Harp 880Hz.wav", "/Music/Instrument/Harp 110Hz.wav", 3, "860Hz", "900Hz", "920Hz" ),
                    ( 393, "523Hz", 2, "Identify the correct frequency of the harp.", "/Music/Instrument/Harp 523Hz.wav", "/Music/Instrument/Harp 659Hz.wav", 3, "500Hz", "540Hz", "560Hz" ),

                    ( 394, "659Hz", 2, "Identify the correct frequency of the harp.", "/Music/Instrument/Harp 659Hz.wav", "/Music/Instrument/Harp 1.05kHz.wav", 3, "640Hz", "680Hz", "700Hz" ),
                    ( 395, "1.05kHz", 2, "Identify the correct frequency of the harp.", "/Music/Instrument/Harp 1.05kHz.wav", "/Music/Instrument/Harp 1.32kHz.wav", 3, "1.00kHz", "1.10kHz", "1.15kHz" ),
                    ( 396, "1.32kHz", 2, "Identify the correct frequency of the harp.", "/Music/Instrument/Harp 1.32kHz.wav", "/Music/Instrument/Harp 110Hz.wav", 3, "1.20kHz", "1.35kHz", "1.40kHz" ),

                    ( 397, "110Hz", 3, "Identify the correct frequency of the harp.", "/Music/Instrument/Harp 110Hz.wav", "/Music/Instrument/Harp 131Hz.wav", 3, "100Hz", "130Hz", "120Hz" ),
                    ( 398, "131Hz", 3, "Identify the correct frequency of the harp.", "/Music/Instrument/Harp 131Hz.wav", "/Music/Instrument/Harp 165Hz.wav", 3, "120Hz", "150Hz", "140Hz" ),
                    ( 399, "165Hz", 3, "Identify the correct frequency of the harp.", "/Music/Instrument/Harp 165Hz.wav", "/Music/Instrument/Harp 220Hz.wav", 3, "150Hz", "180Hz", "170Hz" ),

                    ( 400, "220Hz", 3, "Identify the correct frequency of the harp.", "/Music/Instrument/Harp 220Hz.wav", "/Music/Instrument/Harp 262Hz.wav", 3, "200Hz", "240Hz", "230Hz" ),
                    ( 401, "262Hz", 3, "Identify the correct frequency of the harp.", "/Music/Instrument/Harp 262Hz.wav", "/Music/Instrument/Harp 330Hz.wav", 3, "250Hz", "270Hz", "280Hz" ),
                    ( 402, "330Hz", 3, "Identify the correct frequency of the harp.", "/Music/Instrument/Harp 330Hz.wav", "/Music/Instrument/Harp 440Hz.wav", 3, "300Hz", "340Hz", "350Hz" ),

                    ( 403, "440Hz", 3, "Identify the correct frequency of the harp.", "/Music/Instrument/Harp 440Hz.wav", "/Music/Instrument/Harp 880Hz.wav", 3, "400Hz", "460Hz", "450Hz" ),
                    ( 404, "880Hz", 3, "Identify the correct frequency of the harp.", "/Music/Instrument/Harp 880Hz.wav", "/Music/Instrument/Harp 110Hz.wav", 3, "800Hz", "920Hz", "900Hz" ),
                    ( 405, "523Hz", 3, "Identify the correct frequency of the harp.", "/Music/Instrument/Harp 523Hz.wav", "/Music/Instrument/Harp 659Hz.wav", 3, "500Hz", "540Hz", "560Hz" ),

                    ( 406, "659Hz", 3, "Identify the correct frequency of the harp.", "/Music/Instrument/Harp 659Hz.wav", "/Music/Instrument/Harp 1.05kHz.wav", 3, "600Hz", "680Hz", "700Hz" ),
                    ( 407, "1.05kHz", 3, "Identify the correct frequency of the harp.", "/Music/Instrument/Harp 1.05kHz.wav", "/Music/Instrument/Harp 1.32kHz.wav", 3, "1.00kHz", "1.10kHz", "1.15kHz" ),
                    ( 408, "1.32kHz", 3, "Identify the correct frequency of the harp.", "/Music/Instrument/Harp 1.32kHz.wav", "/Music/Instrument/Harp 110Hz.wav", 3, "1.20kHz", "1.35kHz", "1.40kHz" ),

                    ( 409, "110Hz", 1, "Identify the correct frequency of the piano.", "/Music/Instrument/Piano 110Hz.wav", "/Music/Instrument/Piano 110Hz.wav", 3, "50Hz", "200Hz", "500Hz" ),
                    ( 410, "131Hz", 1, "Identify the correct frequency of the piano.", "/Music/Instrument/Piano 131Hz.wav", "/Music/Instrument/Piano 131Hz.wav", 3, "60Hz", "250Hz", "600Hz" ),
                    ( 411, "165Hz", 1, "Identify the correct frequency of the piano.", "/Music/Instrument/Piano 165Hz.wav", "/Music/Instrument/Piano 165Hz.wav", 3, "80Hz", "300Hz", "700Hz" ),

                    ( 412, "220Hz", 1, "Identify the correct frequency of the piano.", "/Music/Instrument/Piano 220Hz.wav", "/Music/Instrument/Piano 220Hz.wav", 3, "100Hz", "350Hz", "800Hz" ),
                    ( 413, "262Hz", 1, "Identify the correct frequency of the piano.", "/Music/Instrument/Piano 262Hz.wav", "/Music/Instrument/Piano 262Hz.wav", 3, "120Hz", "400Hz", "900Hz" ),
                    ( 414, "330Hz", 1, "Identify the correct frequency of the piano.", "/Music/Instrument/Piano 330Hz.wav", "/Music/Instrument/Piano 330Hz.wav", 3, "150Hz", "450Hz", "1000Hz" ),

                    ( 415, "440Hz", 1, "Identify the correct frequency of the piano.", "/Music/Instrument/Piano 440Hz.wav", "/Music/Instrument/Piano 440Hz.wav", 3, "200Hz", "500Hz", "1100Hz" ),
                    ( 416, "523Hz", 1, "Identify the correct frequency of the piano.", "/Music/Instrument/Piano 523Hz.wav", "/Music/Instrument/Piano 523Hz.wav", 3, "250Hz", "600Hz", "1200Hz" ),
                    ( 417, "659Hz", 1, "Identify the correct frequency of the piano.", "/Music/Instrument/Piano 659Hz.wav", "/Music/Instrument/Piano 659Hz.wav", 3, "300Hz", "700Hz", "1300Hz" ),

                    ( 418, "880Hz", 1, "Identify the correct frequency of the piano.", "/Music/Instrument/Piano 880Hz.wav", "/Music/Instrument/Piano 880Hz.wav", 3, "400Hz", "800Hz", "1400Hz" ),
                    ( 419, "1.05kHz", 1, "Identify the correct frequency of the piano.", "/Music/Instrument/Piano 1.05kHz.wav", "/Music/Instrument/Piano 1.05kHz.wav", 3, "500Hz", "900Hz", "1500Hz" ),
                    ( 420, "1.32kHz", 1, "Identify the correct frequency of the piano.", "/Music/Instrument/Piano 1.32kHz.wav", "/Music/Instrument/Piano 1.32kHz.wav", 3, "600Hz", "1.00kHz", "1600Hz" ),

                    ( 433, "110Hz", 2, "Identify the correct frequency of the piano.", "/Music/Instrument/Piano 110Hz.wav", "/Music/Instrument/Piano 110Hz.wav", 3, "70Hz", "150Hz", "170Hz" ),
                    ( 434, "131Hz", 2, "Identify the correct frequency of the piano.", "/Music/Instrument/Piano 131Hz.wav", "/Music/Instrument/Piano 131Hz.wav", 3, "90Hz", "170Hz", "190Hz" ),
                    ( 435, "165Hz", 2, "Identify the correct frequency of the piano.", "/Music/Instrument/Piano 165Hz.wav", "/Music/Instrument/Piano 165Hz.wav", 3, "120Hz", "210Hz", "230Hz" ),

                    ( 436, "220Hz", 2, "Identify the correct frequency of the piano.", "/Music/Instrument/Piano 220Hz.wav", "/Music/Instrument/Piano 220Hz.wav", 3, "160Hz", "270Hz", "290Hz" ),
                    ( 437, "262Hz", 2, "Identify the correct frequency of the piano.", "/Music/Instrument/Piano 262Hz.wav", "/Music/Instrument/Piano 262Hz.wav", 3, "200Hz", "320Hz", "340Hz" ),
                    ( 438, "330Hz", 2, "Identify the correct frequency of the piano.", "/Music/Instrument/Piano 330Hz.wav", "/Music/Instrument/Piano 330Hz.wav", 3, "250Hz", "390Hz", "410Hz" ),

                    ( 439, "440Hz", 2, "Identify the correct frequency of the piano.", "/Music/Instrument/Piano 440Hz.wav", "/Music/Instrument/Piano 440Hz.wav", 3, "300Hz", "500Hz", "520Hz" ),
                    ( 440, "523Hz", 2, "Identify the correct frequency of the piano.", "/Music/Instrument/Piano 523Hz.wav", "/Music/Instrument/Piano 523Hz.wav", 3, "380Hz", "580Hz", "600Hz" ),
                    ( 441, "659Hz", 2, "Identify the correct frequency of the piano.", "/Music/Instrument/Piano 659Hz.wav", "/Music/Instrument/Piano 659Hz.wav", 3, "480Hz", "740Hz", "720Hz" ),

                    ( 442, "880Hz", 2, "Identify the correct frequency of the piano.", "/Music/Instrument/Piano 880Hz.wav", "/Music/Instrument/Piano 880Hz.wav", 3, "650Hz", "960Hz", "940Hz" ),
                    ( 443, "1.05kHz", 2, "Identify the correct frequency of the piano.", "/Music/Instrument/Piano 1.05kHz.wav", "/Music/Instrument/Piano 1.05kHz.wav", 3, "800Hz", "1.30kHz", "1.20kHz" ),
                    ( 444, "1.32kHz", 2, "Identify the correct frequency of the piano.", "/Music/Instrument/Piano 1.32kHz.wav", "/Music/Instrument/Piano 1.32kHz.wav", 3, "950Hz", "1.50kHz", "1.60kHz" ),

                    ( 445, "110Hz", 3, "Identify the correct frequency of the piano.", "/Music/Instrument/Piano 110Hz.wav", "/Music/Instrument/Piano 110Hz.wav", 3, "60Hz", "190Hz", "170Hz" ),
                    ( 446, "131Hz", 3, "Identify the correct frequency of the piano.", "/Music/Instrument/Piano 131Hz.wav", "/Music/Instrument/Piano 131Hz.wav", 3, "80Hz", "210Hz", "190Hz" ),
                    ( 447, "165Hz", 3, "Identify the correct frequency of the piano.", "/Music/Instrument/Piano 165Hz.wav", "/Music/Instrument/Piano 165Hz.wav", 3, "100Hz", "250Hz", "230Hz" ),

                    ( 448, "220Hz", 3, "Identify the correct frequency of the piano.", "/Music/Instrument/Piano 220Hz.wav", "/Music/Instrument/Piano 220Hz.wav", 3, "140Hz", "310Hz", "290Hz" ),
                    ( 449, "262Hz", 3, "Identify the correct frequency of the piano.", "/Music/Instrument/Piano 262Hz.wav", "/Music/Instrument/Piano 262Hz.wav", 3, "180Hz", "360Hz", "340Hz" ),
                    ( 450, "330Hz", 3, "Identify the correct frequency of the piano.", "/Music/Instrument/Piano 330Hz.wav", "/Music/Instrument/Piano 330Hz.wav", 3, "220Hz", "430Hz", "410Hz" ),

                    ( 451, "440Hz", 3, "Identify the correct frequency of the piano.", "/Music/Instrument/Piano 440Hz.wav", "/Music/Instrument/Piano 440Hz.wav", 3, "280Hz", "540Hz", "520Hz" ),
                    ( 452, "523Hz", 3, "Identify the correct frequency of the piano.", "/Music/Instrument/Piano 523Hz.wav", "/Music/Instrument/Piano 523Hz.wav", 3, "320Hz", "600Hz", "620Hz" ),
                    ( 453, "659Hz", 3, "Identify the correct frequency of the piano.", "/Music/Instrument/Piano 659Hz.wav", "/Music/Instrument/Piano 659Hz.wav", 3, "420Hz", "740Hz", "760Hz" ),

                    ( 454, "880Hz", 3, "Identify the correct frequency of the piano.", "/Music/Instrument/Piano 880Hz.wav", "/Music/Instrument/Piano 880Hz.wav", 3, "550Hz", "960Hz", "980Hz" ),
                    ( 455, "1.05kHz", 3, "Identify the correct frequency of the piano.", "/Music/Instrument/Piano 1.05kHz.wav", "/Music/Instrument/Piano 1.05kHz.wav", 3, "700Hz", "1.30kHz", "1.40kHz" ),
                    ( 456, "1.32kHz", 3, "Identify the correct frequency of the piano.", "/Music/Instrument/Piano 1.32kHz.wav", "/Music/Instrument/Piano 1.32kHz.wav", 3, "850Hz", "1.60kHz", "1.70kHz" ),

                    ( 457, "110Hz", 1, "Identify the correct frequency of the marimba.", "/Music/Instrument/Marimba 110Hz.wav", "/Music/Instrument/Marimba 220Hz.wav", 3, "10Hz", "1000Hz", "500Hz" ),
                    ( 458, "131Hz", 1, "Identify the correct frequency of the marimba.", "/Music/Instrument/Marimba 131Hz.wav", "/Music/Instrument/Marimba 165Hz.wav", 3, "20Hz", "600Hz", "1100Hz" ),
                    ( 459, "165Hz", 1, "Identify the correct frequency of the marimba.", "/Music/Instrument/Marimba 165Hz.wav", "/Music/Instrument/Marimba 131Hz.wav", 3, "30Hz", "1200Hz", "700Hz" ),

                    ( 460, "220Hz", 1, "Identify the correct frequency of the marimba.", "/Music/Instrument/Marimba 220Hz.wav", "/Music/Instrument/Marimba 262Hz.wav", 3, "40Hz", "1300Hz", "800Hz" ),
                    ( 461, "262Hz", 1, "Identify the correct frequency of the marimba.", "/Music/Instrument/Marimba 262Hz.wav", "/Music/Instrument/Marimba 220Hz.wav", 3, "50Hz", "1400Hz", "900Hz" ),
                    ( 462, "330Hz", 1, "Identify the correct frequency of the marimba.", "/Music/Instrument/Marimba 330Hz.wav", "/Music/Instrument/Marimba 440Hz.wav", 3, "60Hz", "1500Hz", "1000Hz" ),

                    ( 463, "440Hz", 1, "Identify the correct frequency of the marimba.", "/Music/Instrument/Marimba 440Hz.wav", "/Music/Instrument/Marimba 330Hz.wav", 3, "70Hz", "1600Hz", "1100Hz" ),
                    ( 464, "523Hz", 1, "Identify the correct frequency of the marimba.", "/Music/Instrument/Marimba 523Hz.wav", "/Music/Instrument/Marimba 659Hz.wav", 3, "80Hz", "1700Hz", "1200Hz" ),
                    ( 465, "659Hz", 1, "Identify the correct frequency of the marimba.", "/Music/Instrument/Marimba 659Hz.wav", "/Music/Instrument/Marimba 523Hz.wav", 3, "90Hz", "1800Hz", "1300Hz" ),

                    ( 466, "880Hz", 1, "Identify the correct frequency of the marimba.", "/Music/Instrument/Marimba 880Hz.wav", "/Music/Instrument/Marimba 659Hz.wav", 3, "100Hz", "1900Hz", "1400Hz" ),
                    ( 467, "1.32kHz", 1, "Identify the correct frequency of the marimba.", "/Music/Instrument/Marimba 1.32kHz.wav", "/Music/Instrument/Marimba 1.76kHz.wav", 3, "200Hz", "3kHz", "2kHz" ),
                    ( 468, "1.76kHz", 1, "Identify the correct frequency of the marimba.", "/Music/Instrument/Marimba 1.76kHz.wav", "/Music/Instrument/Marimba 2.1kHz.wav", 3, "300Hz", "3.5kHz", "2.5kHz" ),

                    ( 469, "2.1kHz", 1, "Identify the correct frequency of the marimba.", "/Music/Instrument/Marimba 2.1kHz.wav", "/Music/Instrument/Marimba 1.32kHz.wav", 3, "400Hz", "4kHz", "3kHz" ),
                    ( 470, "110Hz", 2, "Identify the correct frequency of the marimba.", "/Music/Instrument/Marimba 110Hz.wav", "/Music/Instrument/Marimba 220Hz.wav", 3, "160Hz", "190Hz", "180Hz" ),
                    ( 471, "131Hz", 2, "Identify the correct frequency of the marimba.", "/Music/Instrument/Marimba 131Hz.wav", "/Music/Instrument/Marimba 165Hz.wav", 3, "180Hz", "200Hz", "210Hz" ),

                    ( 472, "165Hz", 2, "Identify the correct frequency of the marimba.", "/Music/Instrument/Marimba 165Hz.wav", "/Music/Instrument/Marimba 131Hz.wav", 3, "210Hz", "230Hz", "240Hz" ),
                    ( 473, "220Hz", 2, "Identify the correct frequency of the marimba.", "/Music/Instrument/Marimba 220Hz.wav", "/Music/Instrument/Marimba 262Hz.wav", 3, "260Hz", "290Hz", "300Hz" ),
                    ( 474, "262Hz", 2, "Identify the correct frequency of the marimba.", "/Music/Instrument/Marimba 262Hz.wav", "/Music/Instrument/Marimba 220Hz.wav", 3, "310Hz", "330Hz", "340Hz" ),

                    ( 475, "330Hz", 2, "Identify the correct frequency of the marimba.", "/Music/Instrument/Marimba 330Hz.wav", "/Music/Instrument/Marimba 440Hz.wav", 3, "360Hz", "400Hz", "410Hz" ),
                    ( 476, "440Hz", 2, "Identify the correct frequency of the marimba.", "/Music/Instrument/Marimba 440Hz.wav", "/Music/Instrument/Marimba 330Hz.wav", 3, "460Hz", "510Hz", "520Hz" ),
                    ( 477, "523Hz", 2, "Identify the correct frequency of the marimba.", "/Music/Instrument/Marimba 523Hz.wav", "/Music/Instrument/Marimba 659Hz.wav", 3, "560Hz", "590Hz", "600Hz" ),

                    ( 478, "659Hz", 2, "Identify the correct frequency of the marimba.", "/Music/Instrument/Marimba 659Hz.wav", "/Music/Instrument/Marimba 523Hz.wav", 3, "660Hz", "730Hz", "740Hz" ),
                    ( 479, "880Hz", 2, "Identify the correct frequency of the marimba.", "/Music/Instrument/Marimba 880Hz.wav", "/Music/Instrument/Marimba 659Hz.wav", 3, "860Hz", "950Hz", "960Hz" ),
                    ( 480, "1.32kHz", 2, "Identify the correct frequency of the marimba.", "/Music/Instrument/Marimba 1.32kHz.wav", "/Music/Instrument/Marimba 1.76kHz.wav", 3, "1.26kHz", "1.46kHz", "1.56kHz" ),

                    ( 481, "1.76kHz", 2, "Identify the correct frequency of the marimba.", "/Music/Instrument/Marimba 1.76kHz.wav", "/Music/Instrument/Marimba 2.1kHz.wav", 3, "1.66kHz", "1.86kHz", "1.96kHz" ),
                    ( 482, "2.1kHz", 2, "Identify the correct frequency of the marimba.", "/Music/Instrument/Marimba 2.1kHz.wav", "/Music/Instrument/Marimba 1.32kHz.wav", 3, "2.06kHz", "2.26kHz", "2.36kHz" ),
                    ( 483, "110Hz", 3, "Identify the correct frequency of the marimba.", "/Music/Instrument/Marimba 110Hz.wav", "/Music/Instrument/Marimba 220Hz.wav", 3, "120Hz", "140Hz", "150Hz" ),

                    ( 484, "131Hz", 3, "Identify the correct frequency of the marimba.", "/Music/Instrument/Marimba 131Hz.wav", "/Music/Instrument/Marimba 165Hz.wav", 3, "140Hz", "160Hz", "170Hz" ),
                    ( 485, "165Hz", 3, "Identify the correct frequency of the marimba.", "/Music/Instrument/Marimba 165Hz.wav", "/Music/Instrument/Marimba 131Hz.wav", 3, "170Hz", "190Hz", "200Hz" ),
                    ( 486, "220Hz", 3, "Identify the correct frequency of the marimba.", "/Music/Instrument/Marimba 220Hz.wav", "/Music/Instrument/Marimba 262Hz.wav", 3, "250Hz", "260Hz", "220Hz" ),

                    ( 487, "262Hz", 3, "Identify the correct frequency of the marimba.", "/Music/Instrument/Marimba 262Hz.wav", "/Music/Instrument/Marimba 220Hz.wav", 3, "270Hz", "290Hz", "300Hz" ),
                    ( 488, "330Hz", 3, "Identify the correct frequency of the marimba.", "/Music/Instrument/Marimba 330Hz.wav", "/Music/Instrument/Marimba 440Hz.wav", 3, "320Hz", "360Hz", "370Hz" ),
                    ( 489, "440Hz", 3, "Identify the correct frequency of the marimba.", "/Music/Instrument/Marimba 440Hz.wav", "/Music/Instrument/Marimba 330Hz.wav", 3, "420Hz", "470Hz", "480Hz" ),

                    ( 490, "523Hz", 3, "Identify the correct frequency of the marimba.", "/Music/Instrument/Marimba 523Hz.wav", "/Music/Instrument/Marimba 659Hz.wav", 3, "520Hz", "550Hz", "560Hz" ),
                    ( 491, "659Hz", 3, "Identify the correct frequency of the marimba.", "/Music/Instrument/Marimba 659Hz.wav", "/Music/Instrument/Marimba 523Hz.wav", 3, "620Hz", "690Hz", "700Hz" ),
                    ( 492, "880Hz", 3, "Identify the correct frequency of the marimba.", "/Music/Instrument/Marimba 880Hz.wav", "/Music/Instrument/Marimba 659Hz.wav", 3, "820Hz", "910Hz", "920Hz" ),

                    ( 493, "1.32kHz", 3, "Identify the correct frequency of the marimba.", "/Music/Instrument/Marimba 1.32kHz.wav", "/Music/Instrument/Marimba 1.76kHz.wav", 3, "1.22kHz", "1.42kHz", "1.52kHz" ),
                    ( 494, "1.76kHz", 3, "Identify the correct frequency of the marimba.", "/Music/Instrument/Marimba 1.76kHz.wav", "/Music/Instrument/Marimba 2.1kHz.wav", 3, "1.62kHz", "1.82kHz", "1.92kHz" ),
                    ( 495, "2.1kHz", 3, "Identify the correct frequency of the marimba.", "/Music/Instrument/Marimba 2.1kHz.wav", "/Music/Instrument/Marimba 1.32kHz.wav", 3, "2.02kHz", "2.22kHz", "2.32kHz" )
            };

            // Loop through and create QuizQuestion entities
            foreach (var (Id, CorrectAnswer, DifficultyId, Question, QuestionMusicFilePath, ReferenceMusicFilePath, TopicId, WrongAnswerOne, WrongAnswerTwo, WrongAnswerThree) in quizQuestions)
            {
                seedData.Add(new QuizQuestion
                {
                    Id = Id,
                    TopicId = TopicId,
                    DifficultyId = DifficultyId,
                    Question = Question,
                    CorrectAnswer = CorrectAnswer,
                    WrongAnswerOne = WrongAnswerOne,
                    WrongAnswerTwo = WrongAnswerTwo,
                    WrongAnswerThree = WrongAnswerThree,
                    QuestionMusicFilePath = QuestionMusicFilePath,
                    ReferenceMusicFilePath = ReferenceMusicFilePath
                });
            }

            return seedData;
        }
    }
}