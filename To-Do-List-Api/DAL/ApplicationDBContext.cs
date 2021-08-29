using Microsoft.EntityFrameworkCore;

namespace To_Do_List_Api.DAL
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
            .UseSqlite(@"Data Source = C:\\Sqlite\\testdb.db;");
        }

        public DbSet<To_Do_List_Api.Models.Task> Task { get; set; }
    }
}