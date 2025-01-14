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
        /// Miramba.
        /// </summary>
        [Description("Miramba")]
        Miramba = 4,

    }

    public enum Level
    {
        /// <summary>
        /// Level1
        /// </summary>
        [Description("Level 1")]
        Level1 = 150,

        /// <summary>
        /// Level2
        /// </summary>
        [Description("Level 2")]
        Level2 = 300,

        /// <summary>
        /// Level3
        /// </summary>
        [Description("Level 3")]
        Level3 = 500,

        /// <summary>
        /// Level4
        /// </summary>
        [Description("Level 4")]
        Level4 = 1000,

        /// <summary>
        /// Level5
        /// </summary>
        [Description("Level 5")]
        Level5 = 1500
    }
}