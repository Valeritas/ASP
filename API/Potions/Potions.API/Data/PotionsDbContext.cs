using Microsoft.EntityFrameworkCore;
using Potions.API.Models.PotionAPI;

namespace Potions.API.Data
{


    namespace PotionAPI
    {
        public class PotionsDbContext : DbContext
        {
            public PotionsDbContext(DbContextOptions options) : base(options)
            {
            }
            public DbSet<Potion> Potions { set; get; }
        }
    }
}