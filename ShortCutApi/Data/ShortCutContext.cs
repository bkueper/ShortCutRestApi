using Microsoft.EntityFrameworkCore;
using ShortCutApi.Models;

namespace ShortCutApi.Data
{
    public class ShortCutContext: DbContext
    {
        public ShortCutContext(DbContextOptions<ShortCutContext> options): base(options)
        {
            
        }
        public DbSet<Machine> Machines {get; set;}
        public DbSet<Customer> Customers {get; set;}
    }
}