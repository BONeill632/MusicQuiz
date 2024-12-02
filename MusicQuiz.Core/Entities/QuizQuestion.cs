namespace MusicQuiz.Core.Entities
{

    /// <summary>
    /// 
    /// </summary>
    public class QuizQuestion
    {
        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int TopicId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int DifficultyId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Question { get; set; } = null!;

        /// <summary>
        /// 
        /// </summary>
        public string CorrectAnswer { get; set; } = null!;

        /// <summary>
        /// 
        /// </summary>
        public string WrongAnswerOne { get; set; } = null!;

        /// <summary>
        /// 
        /// </summary>
        public string WrongAnswerTwo { get; set; } = null!;

        /// <summary>
        /// 
        /// </summary>
        public string WrongAnswerThree { get; set; } = null!;

        /// <summary>
        /// 
        /// </summary>
        public string QuestionMusicFilePath { get; set; } = null!;

        /// <summary>
        /// 
        /// </summary>
        public string ReferenceMusicFilePath { get; set; } = null!;
    }
}