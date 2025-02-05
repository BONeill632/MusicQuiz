namespace MusicQuiz.Core.Entities
{
    public class LastAssignedUserID
    {
        /// <summary>
        /// ID of the new user
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// ID of the last assigned user
        /// </summary>
        public int LastUserID { get; set; }
    }
}