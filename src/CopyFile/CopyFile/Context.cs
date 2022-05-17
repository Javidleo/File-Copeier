using Microsoft.EntityFrameworkCore;

namespace CopyFile
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> option) : base(option)
        {
            Database.EnsureCreated();
        }

        public Context()
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<FilePath>().Property(i => i.SourcePath).IsRequired();
            modelBuilder.Entity<FilePath>().Property(i => i.TargetPath).IsRequired();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server= DESKTOP-DE1P6BA;DataBase=work;Trusted_Connection=True;");
        }

        public DbSet<FilePath> FilePath { get; set; }
    }
}
