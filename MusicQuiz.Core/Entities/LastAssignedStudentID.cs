namespace MusicQuiz.Core.Entities
{

    /// <summary>
    /// 
    /// </summary>
    public class LastAssignedUserID
    {
        public int Id { get; set; }  // Primary key
        public int LastUserID { get; set; }  // The last used user ID
    }
}