using Microsoft.EntityFrameworkCore;
using ToDoApp_api.Model;

namespace ToDoApp_api.DataBase.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<Tasks> TasksTable { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tasks>().HasKey(x => x.IdTask);

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer($"Data Source=PCHOME;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

            base.OnConfiguring(optionsBuilder);
        }
    }
}
