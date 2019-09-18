using GameProject.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject.DataAccess.Context
{
    public class GameProjectContext : DbContext
    {
        public GameProjectContext()
        {

        }
        public DbSet<Log> Logs { get; set; }
        public DbSet<Gamer> Gamers { get; set; }
        public DbSet<War> Wars { get; set; }
        public DbSet<Ability> Abilities { get; set; }
        public DbSet<GamerAbility> GamerAbilities { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer("Server=DTCAFER;Database=GameDb;Trusted_Connection=True");
            //optionsBuilder.UseLazyLoadingProxies();
        }

    }
}
