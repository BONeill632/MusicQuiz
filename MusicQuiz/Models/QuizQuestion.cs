public class QuizQuestion
{
    public int Id { get; set; }

    public int TopicId { get; set; }

    public int DifficultyId { get; set; }

    public string Question { get; set; } = null!;

    public string CorrectAnswer { get; set; } = null!;

    public string WrongAnswerOne { get; set; } = null!;

    public string WrongAnswerTwo { get; set; } = null!;

    public string WrongAnswerThree { get; set; } = null!;

    public string QuestionMusicFilePath { get; set; } = null!;

    public string ReferenceMusicFilePath { get; set; } = null!;
}
