using System.ComponentModel.DataAnnotations;

namespace MusicQuiz.Models
{
    /// <summary>
    /// This is the main model used for the music quiz
    /// </summary>
    public class MusicQuiz
    {
        /// <summary>
        /// Gets or sets the question
        /// </summary>
        [Required]
        public string Question { get; set; }

        /// <summary>
        /// Gets or sets the location of the question music file
        /// </summary>
        public string MusicQuestionFilePath { get; set; }

        /// <summary>
        /// Gets or sets the location of the template music file
        /// </summary>
        public string MusicTemplateFilePath { get; set; }

        /// <summary>
        /// Gets or sets the list of potential selectable options
        /// </summary>
        public List<string> Options { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string CorrectAnswer { get; set; }
    }
}
