using Microsoft.EntityFrameworkCore;
using API.Entities;

namespace API;

public class PostgresDbContext(DbContextOptions<PostgresDbContext> options) : DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserBadge>()
            .HasKey(ub => new { ub.UserId, ub.BadgeId });

        modelBuilder.Entity<UserLesson>()
            .HasKey(ul => new { ul.UserId, ul.LessonId });

        modelBuilder.Entity<UserCourse>()
            .HasKey(uc => new { uc.UserId, uc.CourseId });

        modelBuilder.Entity<User>()
            .HasMany<Role>(u => u.Roles)
            .WithMany(r => r.Users);

        modelBuilder.Entity<Course>()
            .HasMany<Tag>(c => c.Tags)
            .WithMany(t => t.Courses);

        modelBuilder.Entity<Course>()
            .HasMany<Lesson>(c => c.Lessons)
            .WithOne(l => l.Course);

        modelBuilder.Entity<Course>()
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

        modelBuilder.Entity<Badge>()
            .Property(b => b.Image)
            .HasColumnType("bytea");

        modelBuilder.Entity<UserBadge>()
            .HasOne<User>(ub => ub.User)
            .WithMany()
            .HasForeignKey(ub => ub.UserId);

        modelBuilder.Entity<UserBadge>()
            .HasOne<Badge>(ub => ub.Badge)
            .WithMany()
            .HasForeignKey(ub => ub.BadgeId);

        modelBuilder.Entity<UserLesson>()
            .HasOne<User>(ul => ul.User)
            .WithMany()
            .HasForeignKey(ul => ul.UserId);

        modelBuilder.Entity<UserLesson>()
            .HasOne<Lesson>(ul => ul.Lesson)
            .WithMany()
            .HasForeignKey(ul => ul.LessonId);

        modelBuilder.Entity<UserCourse>()
            .HasOne<User>(uc => uc.User)
            .WithMany()
            .HasForeignKey(uc => uc.UserId);

        modelBuilder.Entity<UserCourse>()
            .HasOne<Course>(uc => uc.Course)
            .WithMany()
            .HasForeignKey(uc => uc.CourseId);
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Tag> Tags { get; set; }
    public DbSet<Badge> Badges { get; set; }
    public DbSet<Lesson> Lessons { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<UserBadge> UserBadges { get; set; }
    public DbSet<UserLesson> UserLessons { get; set; }
    public DbSet<UserCourse> UserCourses { get; set; }
}