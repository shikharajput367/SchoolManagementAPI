using Microsoft.EntityFrameworkCore;
using Repository.Entities;

namespace Repository
{
    /// <summary>
    /// Represents the SQL database context for accessing SQL database entities.
    /// This context provides access to the Teachers and Courses tables and configures their relationships.
    /// </summary>
    public class SqlDbContext : DbContext
    {
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Course> Courses { get; set; }

        public SqlDbContext(DbContextOptions<SqlDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuring the relationship between Teacher and Course
            modelBuilder.Entity<Teacher>()
                .HasMany(t => t.Courses)
                .WithOne(c => c.Teacher)
                .HasForeignKey(c => c.TeacherId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
