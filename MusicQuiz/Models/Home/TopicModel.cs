using MusicQuiz.Core.Enums;

namespace MusicQuiz.Web.Models.Home
{
    public class TopicModel : BaseViewModel
    {
        public Topic Topic { get; set; }
        public string? Description { get; set; }
    }
}
