using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace MusicQuiz.Web.Models
{
    public class ManageUserRolesViewModel
    {
        public required string UserId { get; set; }
        public required string Email { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string StudentID { get; set; }
        public required List<IdentityRole> Roles { get; set; }
        public required IList<string> UserRoles { get; set; }
        public required string SelectedRole { get; set; }
    }
}
