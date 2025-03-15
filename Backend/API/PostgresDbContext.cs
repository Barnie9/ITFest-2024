using Microsoft.EntityFrameworkCore;
using API.Entities;

namespace API;

public class PostgresDbContext(DbContextOptions<PostgresDbContext> options) : DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Primary Keys
        modelBuilder.Entity<UserChapter>()
            .HasKey(uc => new { uc.UserId, uc.ChapterId });

        modelBuilder.Entity<UserLesson>()
            .HasKey(ul => new { ul.UserId, ul.LessonId });

        modelBuilder.Entity<UserLearningCourse>()
            .HasKey(uc => new { uc.UserId, uc.CourseId });

        // Foreign Keys
        modelBuilder.Entity<User>()
            .HasMany<Role>(u => u.Roles)
            .WithMany(r => r.Users);

        modelBuilder.Entity<User>()
            .HasMany<Badge>(u => u.Badges)
            .WithMany();

        modelBuilder.Entity<LearningCourse>()
            .HasMany<Tag>(l => l.Tags)
            .WithMany(t => t.LearningCourses);

        modelBuilder.Entity<LearningCourse>()
            .HasMany<Lesson>(l => l.Lessons)
            .WithOne(l => l.LearningCourse);

        modelBuilder.Entity<LearningCourse>()
            .HasOne<Badge>(c => c.Badge)
            .WithOne();

        modelBuilder.Entity<Lesson>()
            .HasMany<Chapter>(l => l.Chapters)
            .WithOne();

        modelBuilder.Entity<Chapter>()
            .HasMany<ChapterElement>(c => c.Elements)
            .WithOne();

        modelBuilder.Entity<ChapterElement>()
            .HasOne<QuizForm>(c => c.Form)
            .WithOne();

        modelBuilder.Entity<UserChapter>()
            .HasOne<User>(uc => uc.User)
            .WithMany()
            .HasForeignKey(uc => uc.UserId);

        modelBuilder.Entity<UserChapter>()
            .HasOne<Chapter>(uc => uc.Chapter)
            .WithMany()
            .HasForeignKey(uc => uc.ChapterId);

        modelBuilder.Entity<UserLesson>()
            .HasOne<User>(ul => ul.User)
            .WithMany()
            .HasForeignKey(ul => ul.UserId);

        modelBuilder.Entity<UserLesson>()
            .HasOne<Lesson>(ul => ul.Lesson)
            .WithMany()
            .HasForeignKey(ul => ul.LessonId);

        modelBuilder.Entity<UserLearningCourse>()
            .HasOne<User>(ulc => ulc.User)
            .WithMany()
            .HasForeignKey(uc => uc.UserId);

        modelBuilder.Entity<UserLearningCourse>()
            .HasOne<LearningCourse>(ulc => ulc.LearningCourse)
            .WithMany()
            .HasForeignKey(uc => uc.CourseId);
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Tag> Tags { get; set; }
    public DbSet<Badge> Badges { get; set; }
    public DbSet<ChapterElement> ChapterElements { get; set; }
    public DbSet<Chapter> Chapters { get; set; }
    public DbSet<Lesson> Lessons { get; set; }
    public DbSet<LearningCourse> LearningCourses { get; set; }
    public DbSet<UserChapter> UserChapters { get; set; }
    public DbSet<UserLesson> UserLessons { get; set; }
    public DbSet<UserLearningCourse> UserLearningCourses { get; set; }
}