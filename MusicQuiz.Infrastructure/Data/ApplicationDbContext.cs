using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MusicQuiz.Core.Entities;

namespace MusicQuiz.Infrastructure.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext(options)
    {
        public DbSet<QuizQuestion> QuizQuestions { get; set; } = null!;

        public DbSet<UsersPracticeQuizResults> UsersPracticeQuizResults { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Configure Identity tables to use the correct data types for MySQL
            builder.Entity<IdentityRole>(entity =>
            {
                entity.Property(m => m.Id).HasMaxLength(128);
                entity.Property(m => m.Name).HasMaxLength(256);
                entity.Property(m => m.NormalizedName).HasMaxLength(256);
                entity.Property(m => m.ConcurrencyStamp).HasColumnType("longtext");
            });

            builder.Entity<IdentityUser>(entity =>
            {
                entity.Property(m => m.Id).HasMaxLength(128);
                entity.Property(m => m.UserName).HasMaxLength(256);
                entity.Property(m => m.NormalizedUserName).HasMaxLength(256);
                entity.Property(m => m.Email).HasMaxLength(256);
                entity.Property(m => m.NormalizedEmail).HasMaxLength(256);
                entity.Property(m => m.ConcurrencyStamp).HasColumnType("longtext");
                entity.Property(m => m.PasswordHash).HasColumnType("longtext");
                entity.Property(m => m.SecurityStamp).HasColumnType("longtext");
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
