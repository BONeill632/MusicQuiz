using System.ComponentModel;

namespace MusicQuiz.Core.Enums
{
    /// <summary>
    /// Represents the different levels of difficulty for the music quiz.
    /// </summary>
    public enum DifficultyLevel
    {
        /// <summary>
        /// Easy difficulty level.
        /// </summary>
        [Description("Easy")]
        Easy = 1,

        /// <summary>
        /// Medium difficulty level.
        /// </summary>
        [Description("Medium")]
        Medium = 2,

        /// <summary>
        /// Hard difficulty level.
        /// </summary>
        [Description("Hard")]
        Hard = 3
    }

    public enum Topic
    {
        /// <summary>
        /// Sine wave frequency.
        /// </summary>
        [Description("Sine wave")]
        SineWave = 1,

        /// <summary>
        /// Ensembles.
        /// </summary>
        [Description("Ensemble")]
        Ensemble = 2,

        /// <summary>
        /// Instrument.
        /// </summary>
        [Description("Instrument")]
        Instrument = 3,

        /// <summary>
        /// Pink Noise.
        /// </summary>
        [Description("Pink noise")]
        PinkNoise = 4
    }

    public enum Instrument
    {
        /// <summary>
        /// Guitar.
        /// </summary>
        [Description("Guitar")]
        Guitar = 1,

        /// <summary>
        /// Piano.
        /// </summary>
        [Description("Piano")]
        Piano = 2,

        /// <summary>
        /// Harp.
        /// </summary>
        [Description("Harp")]
        Harp = 3,

        /// <summary>
        /// Marimba.
        /// </summary>
        [Description("Marimba")]
        Marimba = 4,
    }

    public enum Level
    {
        /// <summary>
        /// Level1
        /// </summary>
        [Description("Level 1")]
        Level1 = 500, // Total: 500

        /// <summary>
        /// Level2
        /// </summary>
        [Description("Level 2")]
        Level2 = 1000, // Total: 1500

        /// <summary>
        /// Level3
        /// </summary>
        [Description("Level 3")]
        Level3 = 1500, // Total: 3000

        /// <summary>
        /// Level4
        /// </summary>
        [Description("Level 4")]
        Level4 = 2000, // Total: 5000

        /// <summary>
        /// Level5
        /// </summary>
        [Description("Level 5")]
        Level5 = 5000 // Max level
    }

    public enum EXP
    {
        /// <summary>
        /// EXP/score on attempt 1
        /// </summary>
        [Description("First attempt:")]
        One = 10,

        /// <summary>
        /// EXP/score on attempt 2
        /// </summary>
        [Description("Second Attempt")]
        Two = 5,

        /// <summary>
        /// EXP/score on attempt 3
        /// </summary>
        [Description("Third attempt:")]
        Three = 2,

        /// <summary>
        /// EXP/score on attempt 4/incorrect
        /// </summary>
        [Description("Fourth attempt/Incorrect:")]
        Default = 0
    }
}