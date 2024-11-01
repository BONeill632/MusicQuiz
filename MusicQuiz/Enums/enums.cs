using System.ComponentModel;

namespace MusicQuiz.Enums
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
        Easy,

        /// <summary>
        /// Medium difficulty level.
        /// </summary>
        [Description("Medium")]
        Medium,

        /// <summary>
        /// Hard difficulty level.
        /// </summary>
        [Description("Hard")]
        Hard
    }

    public enum Topic
    {
        /// <summary>
        /// Sine wave frequency.
        /// </summary>
        [Description("Sine wave")]
        SineWave,

        /// <summary>
        /// Ensembles.
        /// </summary>
        [Description("Ensemble")]
        Ensemble,

        /// <summary>
        /// Instrument.
        /// </summary>
        [Description("Instrument")]
        Instrument,

        /// <summary>
        /// Pink Noise.
        /// </summary>
        [Description("Pink noise")]
        PinkNoise
    }

    public enum Instrument
    {
        /// <summary>
        /// Guitar.
        /// </summary>
        [Description("Guitar")]
        Guitar,

        /// <summary>
        /// Piano.
        /// </summary>
        [Description("Piano")]
        Piano,

        /// <summary>
        /// Harp.
        /// </summary>
        [Description("Harp")]
        Harp,

        /// <summary>
        /// Miramba.
        /// </summary>
        [Description("Miramba")]
        Miramba,

    }
}