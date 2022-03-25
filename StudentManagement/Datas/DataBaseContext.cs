using StudentManagement.Configruations.Entities;
using StudentManagement.Configrurations.Entities;
using StudentManagement.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace StudentManagement.Datas
{
    public class DataBaseContext : IdentityDbContext<ApiUser>
    {
        public DataBaseContext()
        {
        }

        public DataBaseContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<Class> Classes { get; set; }
        public DbSet<Transcript> Transcripts { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Schedule> Schedules { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new ClassConfiguration());
            modelBuilder.ApplyConfiguration(new StudentConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguation());
        }




    }
}
