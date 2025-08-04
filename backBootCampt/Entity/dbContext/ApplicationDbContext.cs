using Entity.DataInit;
using Entity.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Entity.dbContext
{
    public class ApplicationDbContext : DbContext
    {


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
        }
        public DbSet<Card> cards { get; set; }
        public DbSet<Games> games { get; set; }
        public DbSet<Player> players { get; set; }
        public DbSet<GamePlayer> gamesPlayers { get; set; }
        public DbSet<PlayerCard> playerCards { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.dataPlayers();
            modelBuilder.dataCard();
            modelBuilder.dataGames();
            modelBuilder.dataGamePlayers();
            modelBuilder.dataPlayersCard();

           base.OnModelCreating(modelBuilder);
        }
    }
}
