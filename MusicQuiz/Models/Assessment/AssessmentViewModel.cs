using Microsoft.AspNetCore.Identity;
using MusicQuiz.Core.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MusicQuiz.Web.Models.Assessment
{
    public class AssessmentViewModel
    {
        /// <summary>
        /// Assessment ID from the DB
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Academic year
        /// </summary>
        public required string AcademicYear { get; set; }

        /// <summary>
        /// When the assessment will unlock
        /// </summary>
        public DateTime OpenFrom { get; set; }

        /// <summary>
        /// When the assessment is available to
        /// </summary>
        public DateTime OpenTo { get; set; }

        /// <summary>
        /// The topic of the assessment
        /// </summary>
        public Topic TopicName { get; set; }

        /// <summary>
        /// Boolean for when the assessment is available
        /// </summary>
        public bool IsUnlocked { get; set; }

        /// <summary>
        /// Boolean to check if the user has already completed the assessment
        /// </summary>
        public bool IsCompleted { get; set; }
    }
}
