using Microsoft.AspNetCore.Identity;
using MusicQuiz.Core.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MusicQuiz.Web.Models.Assessment
{
    public class AssessmentViewModel
    {
        public int ID { get; set; }
        public required string AcademicYear { get; set; }
        public DateTime OpenFrom { get; set; }
        public DateTime OpenTo { get; set; }
        public Topic TopicName { get; set; }
        public bool IsUnlocked { get; set; }
    }
}
