namespace MusicQuiz.Core.Entities
{
    /// <summary>
    /// Creating the assessments which the users will be able to access
    /// </summary>
    public class Assessments
    {
        /// <summary>
        /// Assessment ID
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Academic Year
        /// </summary>
        public required string AcademicYear { get; set; }

        /// <summary>
        /// Date the assessment is accessible from
        /// </summary>
        public required DateTime OpenFrom { get; set; }

        /// <summary>
        /// Date the assessment is accessible from
        /// </summary>
        public required DateTime OpenTo { get; set; }

        /// <summary>
        /// Assessment Topic
        /// </summary>
        public int TopicId { get; set; }

        /// <summary>
        /// Submission date
        /// </summary>
        public DateTime DateSubmitted { get; set; }
    }
}