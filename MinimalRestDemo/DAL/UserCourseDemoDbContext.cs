using Microsoft.EntityFrameworkCore;
using MinimalRestDemo.DAL.Models;

namespace MinimalRestDemo.DAL
{
    public class UserCourseDemoDbContext : DbContext
    {
        public UserCourseDemoDbContext(DbContextOptions<UserCourseDemoDbContext> options) : base(options)
        {

        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Server=DESKTOP-CJSO6UL;Database=UserCourseDemo;Trusted_Connection=True;");
        //    base.OnConfiguring(optionsBuilder);
        //}

        public DbSet<User> Users { get; set; }
        public DbSet<Course> Courses { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<User>()
                .HasMany<Course>(u => u.Courses)
                .WithMany(c => c.Users)
                .UsingEntity(x => x.ToTable("UserCourse"));

        }
    }
}
