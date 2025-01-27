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

        /// <summary>
        /// Created for ease of seeding. The ID field which is a hashed string changed every seed
        /// </summary>
        public int IntID { get; set; }

        /// <summary>
        /// Experience points
        /// </summary>
        public int EXP { get; set; }

        /// <summary>
        /// Academic year of the student to help guage assessments/leaderboards
        /// </summary>
        public required string AcademicYear { get; set; }

        /// <summary>
        /// Last logged in date
        /// </summary>
        public DateTime LastLoggedIn { get; set; }

        /// <summary>
        /// WORK OUT USER LEVEL
        /// </summary>
        /// <returns></returns>
        public int GetLevel()
        {
            if (EXP < (int)MusicQuiz.Core.Enums.Level.Level1)
                return 1;
            else if (EXP < ((int)MusicQuiz.Core.Enums.Level.Level1 +
                        (int)MusicQuiz.Core.Enums.Level.Level2))
                return 2;
            else if (EXP < ((int)MusicQuiz.Core.Enums.Level.Level1 +
                        (int)MusicQuiz.Core.Enums.Level.Level2
                        + (int)MusicQuiz.Core.Enums.Level.Level3))
                return 3;
            else if (EXP < ((int)MusicQuiz.Core.Enums.Level.Level1 +
                        (int)MusicQuiz.Core.Enums.Level.Level2
                        + (int)MusicQuiz.Core.Enums.Level.Level3
                        + (int)MusicQuiz.Core.Enums.Level.Level4))
                return 4;
            else
                return 5;
        }
    }
}