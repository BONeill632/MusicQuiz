using MusicQuiz.Core.Enums;
using MusicQuiz.Enums;

namespace MusicQuiz.Web.Models
{
    /// <summary>
    /// This is the main model used for the music quiz
    /// </summary>
    public class MusicQuizViewModel : BaseViewModel
    {
        /// <summary>
        /// Gets or sets the list of topics from the enum page
        /// </summary>
        public List<TopicModel> Topics { get; set; }

        /// <summary>
        /// Gets or sets the selected topic
        /// </summary>
        public Topic SelectedTopic { get; set; }

        /// <summary>
        /// Gets or sets the list of difficulty levels
        /// </summary>
        public List<DifficultyModel> Difficulty { get; set; }

        /// <summary>
        /// Gets or sets the selected difficulty
        /// </summary>
        public DifficultyLevel SelectedDifficulty { get; set; }

        public List<QuestionViewModel> QuizQuestions { get; set; } = [];

        public MusicQuizViewModel()
        {
            Topics = ((Topic[])Enum.GetValues(typeof(Topic)))
                .Select(t => new TopicModel
                {
                    Topic = t,
                    Description = t.GetDescription()
                })
                .ToList();

            Difficulty = ((DifficultyLevel[])Enum.GetValues(typeof(DifficultyLevel)))
                .Select(d => new DifficultyModel
                {
                    DifficultyLevel = d,
                    Description = d.GetDescription()
                })
                .ToList();
        }
    }
}
