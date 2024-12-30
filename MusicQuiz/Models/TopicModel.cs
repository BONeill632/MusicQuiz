using MusicQuiz.Enums;

namespace MusicQuiz.Web.Models
{
    public class TopicModel : BaseViewModel
    {
        public Topic Topic { get; set; }
        public string? Description { get; set; }
    }
}
