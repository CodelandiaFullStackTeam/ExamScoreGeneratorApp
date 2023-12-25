using ExamScoreGeneratorApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ExamScoreGeneratorApp
{
    public class ExamDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=ExamDb;Integrated Security=True");
        }

        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<GroupSubject> GroupSubject { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<GroupSubject>().HasKey(x => new { x.GroupId, x.SubjectId });

            base.OnModelCreating(modelBuilder);
        }
    }
}
