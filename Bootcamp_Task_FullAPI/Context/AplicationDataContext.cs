using Bootcamp_Task_FullAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace Bootcamp_Task_FullAPI.Context
{
    public class AplicationDataContext : DbContext
    {
        public AplicationDataContext(DbContextOptions<AplicationDataContext> options) : base(options) {}

        public DbSet<Product> Product { get; set; }
    }
}
