using MusicQuiz.Core.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace MusicQuiz.Web.Models.Admin
{
    /// <summary>
    /// Model for displaying assessment results in admin dashboard
    /// </summary>
    public class AssessmentResultModel : BaseViewModel
    {
        /// <summary>
        /// User ID from the database
        /// </summary>
        public string UserID { get; set; } = string.Empty;

        /// <summary>
        /// First name of the student
        /// </summary>
        public string Forename { get; set; } = string.Empty;

        /// <summary>
        /// Last name of the student
        /// </summary>
        public string Surname { get; set; } = string.Empty;

        /// <summary>
        /// Student's score as a percentage
        /// </summary>
        [DisplayFormat(DataFormatString = "{0:0.00}%")]
        public decimal UserScore { get; set; }

        /// <summary>
        /// Date the assessment was submitted
        /// </summary>
        public DateTime DateOfSubmission { get; set; }

        /// <summary>
        /// Topic of the assessment
        /// </summary>
        public Topic SelectedTopic { get; set; }

        /// <summary>
        /// ID of the assessment
        /// </summary>
        public int? AssessmentId { get; set; }

        /// <summary>
        /// Academic year of the assessment
        /// </summary>
        public string AcademicYear { get; set; } = string.Empty;

        /// <summary>
        /// Full name of the student (Forename + Surname)
        /// </summary>
        public string FullName => $"{Forename} {Surname}";
    }
}
