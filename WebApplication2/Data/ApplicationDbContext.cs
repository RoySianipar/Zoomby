using Microsoft.EntityFrameworkCore;
using WebApplication2.Models.Masters;
using WebApplication2.Models.Transaction;

namespace WebApplication2.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<PIC> PICs { get; set; }
        public DbSet<ZoomAccount> ZoomAccounts { get; set; }
        public DbSet<ZoomScheduler> ZoomSchedulers { get; set; }


    }
}
