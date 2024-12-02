using MusicQuiz.Enums;

namespace MusicQuiz.Web.Models
{
    /// <summary>
    /// This is the main model used for the list of questions
    /// </summary>
    public class QuestionViewModel
    {
        /// <summary>
        /// Gets or sets the selected topic
        /// </summary>
        public Topic SelectedTopic { get; set; }

        /// <summary>
        /// Gets or sets the selected difficulty
        /// </summary>
        public DifficultyLevel SelectedDifficulty { get; set; }

        /// <summary>
        /// Gets or sets the question
        /// </summary>
        public string Question { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the location of the question music file
        /// </summary>
        public string MusicQuestionFilePath { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the location of the template music file
        /// </summary>
        public string MusicReferenceFilePath { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the location of the template music file
        /// </summary>
        public string MusicReferenceName { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the list of potential selectable options
        /// </summary>
        public List<string> Options { get; set; } = [];

        /// <summary>
        /// Gets or sets the correct answer
        /// </summary>
        public string CorrectAnswer { get; set; } = string.Empty;

        /// <summary>
        /// Users answer
        /// </summary>
        public string UserAnswer { get; set; } = string.Empty;

        /// <summary>
        /// This is used when going between next & previous to stop the
        /// quesiton being submitted more than once
        /// </summary>
        public bool IsAnswered { get; set; }
    }
}
