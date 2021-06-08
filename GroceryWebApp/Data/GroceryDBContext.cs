using GroceryWebApp.BusinessLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryWebApp.Data
{
    public class GroceryDBContext : DbContext
    {
        public GroceryDBContext(DbContextOptions<GroceryDBContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Brand> Brands { get; set; }

        public DbSet<Grocery> Groceries { get; set; }

        public DbSet<Order> Orders { get; set; }
    }
}
