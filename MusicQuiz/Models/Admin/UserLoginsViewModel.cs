using System;
using System.Collections.Generic;

namespace MusicQuiz.Web.Models.Admin
{
    public class UserLoginsViewModel
    {
        public string? Id { get; set; }
        public string? UserName { get; set; }

        public string? StudentID { get; set; }
        public string? Email { get; set; }
        public DateTime LastLoginDate { get; set; }
        public int[] WeeklyLoginCounts { get; set; } = new int[5];
    }
}