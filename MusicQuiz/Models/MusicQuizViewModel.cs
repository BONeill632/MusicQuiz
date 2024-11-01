using System.ComponentModel.DataAnnotations;

namespace MusicQuiz.Models
{
    /// <summary>
    /// This is the main model used for the music quiz
    /// </summary>
    public class MusicQuizViewModel
    {
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
        public string MusicTemplateFilePath { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the list of potential selectable options
        /// </summary>
        public List<string> Options { get; set; } = new List<string>();

        /// <summary>
        /// Gets or sets the correct answer
        /// </summary>
        public string CorrectAnswer { get; set; } = string.Empty;
    }
}
