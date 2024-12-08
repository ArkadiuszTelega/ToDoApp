using Microsoft.EntityFrameworkCore;
using RestAPIforToDos;

namespace RestAPIforToDos.Models
{
    public partial class AppDbContext : DbContext
    {
        public DbSet<ToDo> ToDos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
        { 
            var connectionString = "Host=localhost;Port=5432;Username=user;Password=pass;Database=RestAPIforToDos;SslMode=Disable;"; 
            optionsBuilder.UseNpgsql(connectionString);  
        }
    }
}
