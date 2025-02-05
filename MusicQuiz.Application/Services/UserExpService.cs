using MusicQuiz.Core.Entities;
using MusicQuiz.Core.Enums;

namespace MusicQuiz.Application.Services
{
    public class UserExpService
    {
        /// <summary>
        /// Calculate the user's experience points progress.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static (int expProgress, int expNeeded, double progressPercentage) CalculateExpProgress(UserData user)
        {
            int exp = user?.EXP ?? 0;
            int level = user?.GetLevel() ?? 1;
            int expForNextLevel = level switch
            {
                1 => (int)Level.Level1,
                2 => (int)Level.Level2,
                3 => (int)Level.Level3,
                4 => (int)Level.Level4,
                _ => (int)Level.Level5
            };
            int expForCurrentLevel = level switch
            {
                1 => 0,
                2 => (int)Level.Level1,
                3 => (int)Level.Level2,
                4 => (int)Level.Level3,
                _ => (int)Level.Level4
            };

            // Calculate the progress for the current level
            int expProgress = exp - expForCurrentLevel;
            int expNeeded = expForNextLevel;
            double progressPercentage = (double)expProgress / expNeeded * 100;

            // Ensure the progress bar resets when the user levels up
            if (exp >= expForNextLevel)
            {
                expProgress = exp - expForNextLevel;
                expForNextLevel = level switch
                {
                    1 => (int)Level.Level2,
                    2 => (int)Level.Level3,
                    3 => (int)Level.Level4,
                    4 => (int)Level.Level5,
                    _ => (int)Level.Level5
                };
                expNeeded = expForNextLevel;
                progressPercentage = (double)expProgress / expNeeded * 100;
            }

            // If the user is at level 5, set the progress percentage to 100%
            if (level == 5)
            {
                progressPercentage = 100;
            }

            return (expProgress, expNeeded, progressPercentage);
        }
    }
}