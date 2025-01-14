using MusicQuiz.Core.Enums;

namespace MusicQuiz.Web.Models.Home
{
    /// <summary>
    /// getting necesscary data for latest quiz attempt on homepage
    /// Used because the user practice quiz results was being fidgety
    /// </summary>
    public class QuizAttempt : BaseViewModel
    {
        /// <summary>
        /// Latest Date
        /// </summary>
        public DateTime LatestAttemptDate { get; set; }

        /// <summary>
        /// User Score
        /// </summary>
        public int LatestUserScore { get; set; }
    }
}
