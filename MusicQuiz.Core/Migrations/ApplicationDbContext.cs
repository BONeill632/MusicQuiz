using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MusicQuiz.Core.Entities;
using MusicQuiz.Infrastructure.Data;

namespace MusicQuiz.Core.Migrations
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<UserData>(options)
    {
        public DbSet<QuizQuestion> QuizQuestions { get; set; } = null!;
        public DbSet<UsersPracticeQuizResults> UsersPracticeQuizResults { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<IdentityRole>(entity =>
            {
                entity.Property(m => m.Id).HasMaxLength(128);
                entity.Property(m => m.Name).HasMaxLength(256);
                entity.Property(m => m.NormalizedName).HasMaxLength(256);
                entity.Property(m => m.ConcurrencyStamp).HasColumnType("longtext");
            });

            builder.Entity<UserData>(entity =>
            {
                entity.Property(m => m.Id).HasMaxLength(128);
                entity.Property(m => m.UserName).HasMaxLength(256);
                entity.Property(m => m.NormalizedUserName).HasMaxLength(256);
                entity.Property(m => m.Email).HasMaxLength(256);
                entity.Property(m => m.NormalizedEmail).HasMaxLength(256);
                entity.Property(m => m.ConcurrencyStamp).HasColumnType("longtext");
                entity.Property(m => m.PasswordHash).HasColumnType("longtext");
                entity.Property(m => m.SecurityStamp).HasColumnType("longtext");
                entity.Property(m => m.FirstName).HasMaxLength(256);
                entity.Property(m => m.LastName).HasMaxLength(256);
                entity.Property(m => m.StudentID).HasMaxLength(256);
            });

            builder.Entity<IdentityUserLogin<string>>(entity =>
            {
                entity.Property(m => m.LoginProvider).HasMaxLength(128);
                entity.Property(m => m.ProviderKey).HasMaxLength(128);
                entity.Property(m => m.ProviderDisplayName).HasColumnType("longtext");
            });

            builder.Entity<IdentityUserToken<string>>(entity =>
            {
                entity.Property(m => m.UserId).HasMaxLength(128);
                entity.Property(m => m.LoginProvider).HasMaxLength(128);
                entity.Property(m => m.Name).HasMaxLength(128);
                entity.Property(m => m.Value).HasColumnType("longtext");
            });

            builder.Entity<IdentityUserRole<string>>(entity =>
            {
                entity.Property(m => m.UserId).HasMaxLength(128);
                entity.Property(m => m.RoleId).HasMaxLength(128);
            });

            builder.Entity<IdentityRoleClaim<string>>(entity =>
            {
                entity.Property(m => m.Id).HasMaxLength(128);
                entity.Property(m => m.RoleId).HasMaxLength(128);
                entity.Property(m => m.ClaimType).HasColumnType("longtext");
                entity.Property(m => m.ClaimValue).HasColumnType("longtext");
            });

            builder.Entity<IdentityUserClaim<string>>(entity =>
            {
                entity.Property(m => m.Id).HasMaxLength(128);
                entity.Property(m => m.UserId).HasMaxLength(128);
                entity.Property(m => m.ClaimType).HasColumnType("longtext");
                entity.Property(m => m.ClaimValue).HasColumnType("longtext");
            });

            // Call the seed data configuration
            QuizQuestionEasySineSeedData.Seed(builder);
        }
    }
}
