namespace MusicQuiz.Web.Models
{
    public class QuizResultsViewModel
    {
        /// <summary>
        /// 
        /// </summary>
        public int TotalQuestions { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int CorrectAnswers { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal Score { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<QuestionViewModel>? Questions { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime DateOfSubmission { get; set; }
    }
}
