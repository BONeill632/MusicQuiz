namespace MusicQuiz.Core.Entities
{
    public class QuizQuestion
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// TopicId
        /// </summary>
        public int TopicId { get; set; }

        /// <summary>
        /// DifficultyId
        /// </summary>
        public int DifficultyId { get; set; }

        /// <summary>
        /// Question
        /// </summary>
        public string Question { get; set; } = null!;

        /// <summary>
        /// CorrectAnswer
        /// </summary>
        public string CorrectAnswer { get; set; } = null!;

        /// <summary>
        /// WrongAnswerOne
        /// </summary>
        public string WrongAnswerOne { get; set; } = null!;

        /// <summary>
        /// WrongAnswerTwo
        /// </summary>
        public string WrongAnswerTwo { get; set; } = null!;

        /// <summary>
        /// WrongAnswerThree
        /// </summary>
        public string WrongAnswerThree { get; set; } = null!;

        /// <summary>
        /// QuestionMusicFilePath
        /// </summary>
        public string QuestionMusicFilePath { get; set; } = null!;

        /// <summary>
        /// ReferenceMusicFilePath
        /// </summary>
        public string ReferenceMusicFilePath { get; set; } = null!;
    }
}