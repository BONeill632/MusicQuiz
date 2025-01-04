using MusicQuiz.Core.Enums;

namespace MusicQuiz.Web.Models
{
    public class DifficultyModel : BaseViewModel
    {
        public DifficultyLevel DifficultyLevel { get; set; }
        public string? Description { get; set; }
    }
}
