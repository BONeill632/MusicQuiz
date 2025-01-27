using MusicQuiz.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicQuiz.Core.Entities
{
    /// <summary>
    /// DB table for practice submissions
    /// </summary>
    public class UsersPracticeQuizResults
    {
        /// <summary>
        /// result ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Username
        /// </summary>
        public required string UserID { get; set; }

        /// <summary>
        /// Score as a percentage
        /// </summary>
        public required decimal UserScore { get; set; }

        /// <summary>
        /// Date user finishes quiz
        /// </summary>
        public DateTime DateOfSubmission { get; set; }

        /// <summary>
        /// Gets or sets the selected topic
        /// </summary>
        public int SelectedTopic { get; set; }

        /// <summary>
        /// Gets or sets the selected difficulty
        /// </summary>
        public int SelectedDifficulty { get; set; }

        /// <summary>
        /// Gets or sets AssessmentId
        /// </summary>
        public int? AssessmentId { get; set; }

        /// <summary>
        /// FK constraint for AssessmentId
        /// </summary>
        [ForeignKey("AssessmentId")]
        public Assessments? Assessment { get; set; }
    }
}
