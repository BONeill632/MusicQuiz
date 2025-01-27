using Microsoft.AspNetCore.Identity;
using MusicQuiz.Core.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MusicQuiz.Web.Models.Admin
{
    public class AssessmentViewModel
    {
        [Required]
        public string? AcademicYear { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime OpenFrom { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime OpenTo { get; set; }

        [Required]
        public Topic SelectedTopic { get; set; }

        /// <summary>
        /// List of Academic years for the admin to select
        /// </summary>
        public List<string> AcademicYearOptions { get; set; } = [];
    }
}
