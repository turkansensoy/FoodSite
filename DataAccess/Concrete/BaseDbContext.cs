using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class BaseDbContext:DbContext
    {
        public DbSet<Category> categories { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<RecipeMaterial> RecipeMaterials { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<Menu> Menu { get; set; }
        public DbSet<RecipeMenu> RecipeMenu { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                base.OnConfiguring(
                   optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb; Database=FoodSiteDb;Trusted_Connection=true"));
            }
            
        }

    }
}
