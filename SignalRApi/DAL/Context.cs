using Microsoft.EntityFrameworkCore;

namespace SignalRApi.DAL
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=MyVisitDb;Trusted_Connection=True;TrustServerCertificate=true");
        }
        public DbSet<Visitor> Visitors { get; set; }
    }
}
