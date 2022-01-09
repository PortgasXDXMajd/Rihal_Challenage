using Microsoft.EntityFrameworkCore;
using rihal_challenge.Models;

namespace rihal_challenge.Context
{
    public class MyDbContext : DbContext
    {
        public DbSet<Student>? student_table{ get; set; }
        public DbSet<Class>? class_table { get; set; }
        public DbSet<Country>? country_table{ get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlite(connectionString);
        }

        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {

        }
    }
}
