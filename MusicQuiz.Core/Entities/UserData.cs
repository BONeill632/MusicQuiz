using Microsoft.AspNetCore.Identity;

namespace MusicQuiz.Core.Entities
{
    /// <summary>
    /// Extra fields for ASPUsersTable
    /// </summary>
    public class UserData : IdentityUser
    {
        /// <summary>
        /// Forename
        /// </summary>
        public required string FirstName { get; set; }

        /// <summary>
        /// Surname
        /// </summary>
        public required string LastName { get; set; }

        /// <summary>
        /// Student ID
        /// </summary>
        public required string StudentID { get; set; }
    }
}