using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace groceriesBE
{
    public class GroceriesContext : DbContext
    {
        public GroceriesContext(DbContextOptions options)
            : base(options)
        {
        }
        public DbSet<Groceries> Groceries { get; set; }
    }
}